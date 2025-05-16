namespace OrganizedScannApi.Models
{
    public class Token
    {
        public string TokenValue { get; set; }
        public long Expiration { get; set; }
        public string Type { get; set; }
        public string Role { get; set; }
    }
}
