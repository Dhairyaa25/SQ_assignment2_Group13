namespace yuvraj.Models
{
    public class InventoryItem
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public int QuantityInStock { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}