using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week3ClassDemo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week3ClassDemo.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {

            var articles = new[]
            {
                new Article {
                    Author = "Donna",
                    Title = "My Example Article Title",
                    Body = "These are a lot of important words for an article.",
                    DateCreated = DateTime.Now
                },

                new Article {
                    Author = "Donna H",
                    Title = "A Second Article",
                    Body = "More words are great.",
                    DateCreated = DateTime.Now
                }

            };


            return View(articles);
        }

        public IActionResult Example()
        {

            Article article = new Article
            {
                Author = "Donna H",
                Title = "My Single Example Article",
                Body = "These are more important words for an article.",
                DateCreated = DateTime.Now
            };

            return View(article);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            article.DateCreated = DateTime.Now;

            return View(article);
        }


    }
}
