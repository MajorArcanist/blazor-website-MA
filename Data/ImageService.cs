namespace BlazorApp.Data;
using System;
using System.Data;
using System.Xml;
using System.IO;
using System.Text;

public class ImageService
{
    public Task<List<Image>> GetImageListAsync()
    {
        List<Image> imageList = new List<Image>();
        string path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images"}";

        var files = Directory.GetFiles(path);
        foreach(var file in files)
        {
            var newImage = new Image{
                Name = Path.GetFileNameWithoutExtension(file),
                Path = "/images/" + Path.GetFileName(file)
            };
            imageList.Add(newImage);
        }

        return Task.FromResult(imageList);
    }

    public Task<List<Image>> GetXMLImageListAsync()
    {
        List<Image> imageList = new List<Image>();
        string path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\"}";

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path + "imagedata.xml");
        try {
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/root/Image");
            foreach (XmlNode node in nodeList)
                {
                    try 
                    {
                        var newImage = new Image{
                            Id = Int32.Parse(node.SelectSingleNode("Id").InnerText),
                            Name = node.SelectSingleNode("Name").InnerText,
                            Title = node.SelectSingleNode("Title").InnerText,
                            Description = node.SelectSingleNode("Description").InnerText,
                            Path = "/images/" + node.SelectSingleNode("Name").InnerText,
                            Format = node.SelectSingleNode("Format").InnerText,
                        };
                        imageList.Add(newImage);
                    } catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }               
                }
        } catch (Exception e) 
        {
            Console.WriteLine(e);
        }
        return Task.FromResult(imageList);
    }
}
