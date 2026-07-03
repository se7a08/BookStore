namespace BookStore.DTOs
{
    public class OrderBook
    {
        public int BookId {  get; set; }
        public int OrderId {  get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
