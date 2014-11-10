using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BlogKolorWebService.Models;

namespace BlogKolorWebService.Controllers
{
    public class BlogController : ApiController
    {
        private PostContex db = new PostContex();

        // GET: api/Blog
        public IQueryable<Post> GetPosts()
        {
            return db.Posts;
        }

        // GET: api/Blog/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(string id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Blog/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPost(string id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Blog
        [ResponseType(typeof(Post))]
        public IHttpActionResult PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posts.Add(post);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PostExists(post.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
        }

        // DELETE: api/Blog/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePost(string id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            db.SaveChanges();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(string id)
        {
            return db.Posts.Count(e => e.Id == id) > 0;
        }
    }
}