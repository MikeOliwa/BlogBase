using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBase.Models;
using Microsoft.AspNetCore.Http;

namespace BlogBase.Controllers {
    public class BlogPostController : Controller {

        Data.ApplicationDbContext _context;

        public BlogPostController(Data.ApplicationDbContext context) {
            _context = context;
        }

        //called from form of BlogPostView
        public IActionResult CreateEditBlogPost(BlogPost blogPost, IFormFile picture) {

            if (picture != null) {
                using (var ms = new System.IO.MemoryStream()) {
                    picture.CopyTo(ms);
                    var bytes = ms.ToArray();
                    blogPost.Picture = bytes;
                }
            }

            if (blogPost.Id == 0) {
                //create new
                blogPost.DateCreated = DateTime.Today;
                blogPost.DateEdited = DateTime.Today;
                blogPost.Author = User.Identity.Name;
                _context.BlogPosts.Add(blogPost);

            }
            else {
                //edit existing
                var blogPost_existing = GetBlogPostById(blogPost.Id);

                blogPost_existing.Title = blogPost.Title;
                blogPost_existing.Text = blogPost.Text;
                blogPost_existing.PreviewText = blogPost.PreviewText;
                blogPost_existing.DateEdited = DateTime.Today;
            }

            _context.SaveChanges();
            return RedirectToAction("Manage");
        }

        [HttpPost]
        public IActionResult DeleteBlog(int id) {
            if (id == 0) return BadRequest();
            var blogPost = GetBlogPostById(id);
            if (blogPost == null) {
                return NotFound();
            }

            _context.BlogPosts.Remove(blogPost);
            _context.SaveChanges();
            return Ok();

        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult CreateEditBlog(int id) {
            if (id == 0) {
                return BadRequest();
            }

            var blogPost = GetBlogPostById(id);
            if (blogPost == null) {
                return NotFound();
            }

            return View("Index",blogPost);
        }

        public IActionResult ReadBlog(int id) {

            if (id == 0) {
                return BadRequest();
            }

            var blogPost = GetBlogPostById(id);
            if (blogPost == null) {
                return NotFound();
            }

            return View(blogPost);
        }

        public IActionResult Manage() {
            var allBlogPosts = GetAllBlogPosts();
            return View(allBlogPosts);
        }

        public BlogPost GetBlogPostById(int id) {
            var blogPost = _context.BlogPosts.SingleOrDefault(x => x.Id == id);
            return blogPost;
        }

        public List<BlogPost> GetAllBlogPosts() {
            var allBlogPosts = _context.BlogPosts.ToList();
            return allBlogPosts;
        }


    }
}
