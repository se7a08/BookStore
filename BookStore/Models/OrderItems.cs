using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class OrderItems:BaseEntity
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Book? Book { get; set; }

        public Order? Order { get; set; }
    }
}
