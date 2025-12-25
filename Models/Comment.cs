public class Comment
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }

    public int AnimeId { get; set; }
    public Anime Anime { get; set; }
}

