using System.Text.Json.Serialization;

namespace DutchTreat.Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }
    }
}