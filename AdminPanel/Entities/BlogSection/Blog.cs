namespace AdminPanel.Entities.BlogSection
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public int BCategoryId { get; set; }
        public BCategory Category { get; set; }
        public List<BlogTag> BlogTags { get; set; }
        public string Blogger { get; set; }


    }
}
