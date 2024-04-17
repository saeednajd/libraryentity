namespace mvc.Models
{
    public class BookShelfAndShelves{
        public int Id { get; set; }

        public int BookshelfId { get; set; }
        public BookShelf BookShelf{get ; set ;}
        public int ShelfId { get; set; }
        public Shelf Shelf{get ; set;}

    }


}