using System.Data.Entity;

namespace BlogKolorWebService.Models
{
    public class PostContex : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}