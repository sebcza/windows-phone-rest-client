using System.ComponentModel.DataAnnotations;

namespace BlogKolorWebService.Models
{
    public class Post
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; } 
    }
}