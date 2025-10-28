namespace DigitalLibrary.WebApi.Models
{
    public class Rating
    {
        public int id { get; set; }
        public Book book { get; set; }

        public int? bookId { get; set; }
        public User user { get; set; }
        public int? userId { get; set; }
        public int raiting {  get; set; }
        public string review { get; set; }
    }
}
