namespace Library.DAL.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public string Author { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}