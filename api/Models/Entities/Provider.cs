namespace api.Models
{
    public class Provider
    {
        public Guid ProviderID { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Nationality { get; set; }= string.Empty;
        public string IsAvailable { get; set; }= string.Empty;
    }
}
