namespace AdminPanel.Entities.AboutSection
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string VideoUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Benefit> Benefits { get; set; }
    }
}
