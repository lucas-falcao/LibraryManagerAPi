using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Book
    {
        //[Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
    }
}