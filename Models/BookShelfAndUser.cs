namespace mvc.Models
{

    public class BookShelfAndUser
    {
        public int Id { get; set; }
        public int BookShelfId { get; set; }
        public BookShelf BookShelf { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }



}