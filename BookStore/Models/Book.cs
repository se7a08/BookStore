namespace BookStore.Models
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public BookRole BookRole { get; set; }
        public ICollection<OrderItems>? OrderItems { get; set; }
    }
}
