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
        public IActionResult Index() {
            return View();
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

            }

            _context.SaveChanges();
            return View("Index");
        }

    }
}
