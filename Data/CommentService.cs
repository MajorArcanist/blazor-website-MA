namespace BlazorApp.Data;
using System;
using System.Data;
using System.Xml;
using System.IO;
using System.Text;

public class CommentService
{
    public Task<List<Comment>> GetCommentListAsync()
    {
        List<Comment> commentList = new List<Comment>();
        string path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot"}";

        var files = Directory.GetFiles(path);
        foreach(var file in files)
        {
            var newComment = new Comment{
            };
            commentList.Add(newComment);
        }

        return Task.FromResult(commentList);
    }

    public Task<List<Comment>> GetXMLCommentListAsync(int imgId)
    {
        List<Comment> commentList = new List<Comment>();
        string path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\"}";

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path + "commentdata.xml");
        XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/root/Comment");
        foreach (XmlNode node in nodeList)
            {
                try {
                    var newComment = new Comment
                    {
                        Id = Int32.Parse(node.SelectSingleNode("Id").InnerText),
                        ImageId = Int32.Parse(node.SelectSingleNode("ImageId").InnerText),
                        Commentor = node.SelectSingleNode("Commentor").InnerText,
                        Contents = node.SelectSingleNode("Contents").InnerText,
                    };
                    if(newComment.ImageId == imgId) 
                    {
                        commentList.Add(newComment);
                    }
                } catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }               
            }
        return Task.FromResult(commentList);
    }
}
