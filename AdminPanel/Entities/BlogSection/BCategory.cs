namespace AdminPanel.Entities.BlogSection
{
    public class BCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
