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
            Article article = new Article
            {
                Author = "Donna",
                Title = "My very first article",
                Body = "Here is the text of my very first article",
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
