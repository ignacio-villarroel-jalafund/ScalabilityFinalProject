namespace api.Models
{
    public class Region
    {
        public Guid RegionID { get; set; }
        public string Name { get; set; }= string.Empty;
        public decimal MunicipalTax { get; set; }
        public decimal StatalTax { get; set; }
    }
}
