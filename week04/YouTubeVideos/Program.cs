using System;
using System.Collections.Generic;

public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment c)
    {
        comments.Add(c);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> list = new List<Video>();

        Video v1 = new Video("Learning Python Fast", "Tech Guy", 320);
        v1.AddComment(new Comment("John", "Really helped me out!"));
        v1.AddComment(new Comment("Sarah", "Thanks for the clear explanation."));
        v1.AddComment(new Comment("Mike", "Subscribed."));
        list.Add(v1);

        Video v2 = new Video("C# Basics for Beginners", "Code Master", 540);
        v2.AddComment(new Comment("Emma", "Classes make sense now."));
        v2.AddComment(new Comment("Alex", "Awesome video."));
        v2.AddComment(new Comment("Lisa", "Can you do a part 2?"));
        list.Add(v2);

        Video v3 = new Video("Git & GitHub Setup", "Dev Helper", 410);
        v3.AddComment(new Comment("Dan", "Fixed my 404 error instantly, phew."));
        v3.AddComment(new Comment("Chloe", "Very straightforward."));
        v3.AddComment(new Comment("Ryan", "Bookmarked this."));
        list.Add(v3);

        foreach (Video v in list)
        {
            Console.WriteLine("Title: " + v.Title);
            Console.WriteLine("Author: " + v.Author);
            Console.WriteLine("Length: " + v.Length + " seconds");
            Console.WriteLine("Comments (" + v.GetCommentCount() + "):");

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine("- " + c.Name + ": " + c.Text);
            }
            
            Console.WriteLine();
        }
    }
}