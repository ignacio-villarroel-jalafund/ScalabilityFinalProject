namespace api.Models
{
    public class Product
    {
        public Guid ProductID { get; set; }
        public string Name { get; set; }= string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public string AnimalCategory { get; set; }= string.Empty;
        public string Image { get; set; }= string.Empty;
        public string Description { get; set; }= string.Empty;
        public string ProductType { get; set; }= string.Empty;
        public Guid BrandID { get; set; }
        public Guid ProviderID { get; set; }
        public string IsAvailable { get; set; }= string.Empty;
        public string HasTax { get; set; }= string.Empty;
    }
}
