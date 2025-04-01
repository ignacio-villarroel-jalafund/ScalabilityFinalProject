namespace api.Models.Transactions
{
    public class Sale
    {
        public Guid SaleID { get; set; }
        public string ZipCode { get; set; }= string.Empty;
        public int Cvv { get; set; }
        public string CardNumber { get; set; }= string.Empty;
        public string Date { get; set; }= string.Empty;
        public decimal FinalPrice { get; set; }   
        public Guid UserID { get; set; } 
        public string IsAvailable { get; set; }= string.Empty; 
    }
}
