namespace api.Models
{
    public class Review
    {
        public Guid ReviewID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid ProductID { get; set; }
        public string ReviewMessage { get; set; }= string.Empty;
    }
}
