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
                Id = 1,
                Author = "Sebcza",
                Title = "Tytul",
                Content = "Lorem ipsum"
            });
            posts.Add(new Post()
            {
                Id=2,
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
        public Post Get(int id)
        {
            return posts.FirstOrDefault(x=>x.Id == id);
        }

        // POST: api/Post
        public void Post(Post post)
        {
            posts.Add(post);
        }

        public void Put(int id, Post post)
        {
            var postToEdit = posts.SingleOrDefault(x => x.Id == id);
            var indexPostToEdit = posts.IndexOf(postToEdit);
            posts[indexPostToEdit] = post;

        }


        // DELETE: api/Post/5
        public void Delete(int id)
        {
            posts.Remove(posts.FirstOrDefault(x=>x.Id==id));
        }
    }
}
