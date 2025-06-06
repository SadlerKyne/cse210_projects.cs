public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void AddComment(string commenterName, string text)
    {
        Comment newComment = new Comment(commenterName, text);
        _comments.Add(newComment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }
    public List<Comment> GetComments()
    {
        return _comments;
    }
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Comments ({GetCommentCount()}):");
        foreach (var comment in _comments)
        {
            Console.WriteLine($"{comment.Timestamp}: {comment.CommenterName} - {comment.Text}");
        }
    }
}