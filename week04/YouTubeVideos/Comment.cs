public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }
    public DateTime Timestamp { get; set; }
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
        Timestamp = DateTime.Now; // Automatically set the timestamp to the current time
    }
}