namespace DigitalLibrary.WebApi.Models
{
    public class User
    {
        public int userId {  get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string email {  get; set; }
        public List <Book> collection { get; set; }
    }
}
