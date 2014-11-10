using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.Models;

namespace BlogKolorWebService.Controllers
{
    public class PostController : ApiController
    {
        private List<Post> posts = new List<Post>();

        public PostController()
        {
            posts.Add(new Post()
            {
                Id = Guid.NewGuid().ToString(),
                Author = "Sebcza",
                Title = "Tytul",
                Content = "Lorem ipsum"
            });
            posts.Add(new Post()
            {
                Id=Guid.NewGuid().ToString(),
                Content = "Lorem ipsum2",
                Title = "Tytul2",
                Author = "Andrzej"
            });
        }

        // GET: api/Post
        public IEnumerable<Post> Get()
        {

            return posts;
        }

        // GET: api/Post/5
        public Post Get(string id)
        {
            return posts.FirstOrDefault(x=>String.Equals(x.Id,id));
        }

        // POST: api/Post
        public void Post(Post post)
        {
            posts.Add(post);
        }

        public void Put(string id, Post post)
        {
            var postToEdit = posts.SingleOrDefault(x => String.Equals(x.Id, id));
            var indexPostToEdit = posts.IndexOf(postToEdit);
            posts[indexPostToEdit] = post;

        }


        // DELETE: api/Post/5
        public void Delete(string id)
        {
            posts.Remove(posts.FirstOrDefault(x=>String.Equals(x.Id,id)));
        }
    }
}
