namespace CyberClubApi.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = "Free";
        public int ZoneId { get; set; }
    }
}