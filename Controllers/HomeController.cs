﻿using BlogBase.Data;
using BlogBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBase.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() {
            var allBlogPosts = _context.BlogPosts.ToList();
            return View(allBlogPosts);
        }

        public IActionResult Manage() {
            var allBlogPosts = _context.BlogPosts.ToList();
            return View(allBlogPosts);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult GetBlogPost(int id) {

            if (id == 0) {
                return BadRequest();
            }

            var blogPost = _context.BlogPosts.SingleOrDefault(x => x.Id == id);
            if (blogPost == null) {
                return NotFound();
            }

            return Ok(blogPost);

        }
    }
}
