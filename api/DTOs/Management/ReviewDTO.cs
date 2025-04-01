using System.Text.Json.Serialization;

namespace api.DTOs
{
    public class ReviewDTO
    {
        [JsonIgnore]
        public Guid ReviewID { get; set; }

        [Required("CustomerID")]
        //[IntegerValue("CustomerID")]
        //[PositiveNumber("CustomerID")]
        public Guid CustomerID { get; set; }

        [Required("ProductID")]
        //[IntegerValue("ProductID")]
        //[PositiveNumber("ProductID")]
        public Guid ProductID { get; set; }

        [Required("ReviewMessage")]
        [StringValue("ReviewMessage")]
        [NoSpecialCharacters("ReviewMessage")]
        [NoNumbers("ReviewMessage")]
        [MaxLengthCharacters("ReviewMessage", 150)]
        public string ReviewMessage { get; set; }= string.Empty;
    }
}
