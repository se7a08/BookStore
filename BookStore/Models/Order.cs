namespace BookStore.Models
{
    public class Order:BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }

        public ICollection<OrderItems>? OrderItems { get; set; }
    }
}
