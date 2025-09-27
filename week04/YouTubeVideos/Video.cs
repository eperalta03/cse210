public class Video
{
    public string _title;
    public string _author;
    public int _lenght;
    public List<Comment> _comments = new List<Comment>();

    public int numberOfComments()
    {
        return _comments.Count;
    }

}