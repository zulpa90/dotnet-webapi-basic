namespace DigitalLibrary.WebApi.Models
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int yearPublication { get; set; }
        public string coverImage { get; set; }
        public User user { get; set; }

        public int? userId { get; set; }
    }
}
