using BookStore.Models;


namespace BookStore.DTOs
{
    public class BookOnly
    {
        public string Title {  get; set;}
        public decimal Price { get; set;}
        public string Description { get; set;}
        public string AuthorName {  get; set;}

        public int Quantity {  get; set;}

        public BookRole BookRole { get; set;}
        
    }
}
