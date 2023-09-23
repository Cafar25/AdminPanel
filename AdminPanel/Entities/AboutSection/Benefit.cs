namespace AdminPanel.Entities.AboutSection
{
    public class Benefit
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }

    }
}
