using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataModels;
using Library.BusinessLogic;
using System.Configuration;
using Microsoft.Extensions.Configuration;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week3ClassDemo.Controllers
{
    public class ArticleController : Controller
    {
        private IConfiguration _configuration;

        public ArticleController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

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

            // add in the DB piece

            ArticleHandler articleHandler = new ArticleHandler(_configuration);

            //Task<Article> result = articleHandler.CreateNewArticle(article);
            Article storedArticle = articleHandler.CreateNewArticle(article).Result;

            // need to do a check on the null-ness of storedArticle... in case something went wrong...
            if (storedArticle == null)
            {
                return View("Index"); // not good yet
            }

            //return View(article);
            //redirect instead to the view!
            return RedirectToAction("ViewArticle", storedArticle);

        }


        public IActionResult Listing()
        {
            ArticleHandler articleHandler = new ArticleHandler(_configuration);

            var articles = articleHandler.GetAllArticles();

            return View(articles);
        }


        public IActionResult ViewArticle(int id)
        {
            ArticleHandler articleHandler = new ArticleHandler(_configuration);

            var article = articleHandler.GetArticleById(id);

            return View(article);
        }

        [HttpGet]
        public IActionResult Delete(Article article)
        {
            return View(article);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            ArticleHandler articleHandler = new ArticleHandler(_configuration);
            bool articleWasDeleted = articleHandler.RemoveArticleById(id);

            //var result = articleHandler.RemoveArticleById(id, true);

            //bool articleWasDeleted = false;

            //if (result != null)
            //{
            //    var status = result.Status;
            //    articleWasDeleted = result.Result;

                if (articleWasDeleted)
                {
                    return RedirectToAction("Listing");
                }
            //}

            return RedirectToAction("Index"); // a junky problem


        }




        [HttpGet]
        //public IActionResult Edit(Article article)
        public IActionResult Edit(int? id, Article article)
        {
            return View(article);
        }

        [HttpPost]
        //public IActionResult Edit(Article article, bool SomethingElse)
        public IActionResult Edit([Bind("Id,Author,Title,Body")] Article article)
        {
            article.DateModified = DateTime.Now;


            // add in the DB piece

            ArticleHandler articleHandler = new ArticleHandler(_configuration);

            Article storedArticle = articleHandler.UpdateArticle(article);

            // need to do a check on the null-ness of storedArticle... in case something went wrong...
            if (storedArticle == null)
            {
                return View("Index"); // not good yet .. TODO
            }

            return RedirectToAction("ViewArticle", storedArticle);

        }

    }
}
