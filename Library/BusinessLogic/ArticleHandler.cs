using System;
using DataModels;
using DAL;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Library.BusinessLogic
{
    public class ArticleHandler
    {
        private IConfiguration _configuration;

        private DataAccess _db;

        public readonly int BODY_LENGTH_IN_PREVIEW = 25;



        public ArticleHandler(IConfiguration configuration)
        {
            _configuration = configuration;

            _db = new DataAccess(configuration);
        }



        public Article[] GetAllArticles__InClassVersion()
        {
            var articles = _db.GetAllArticlesFromDatabase__InClassVersion();

            return articles;
        }

        public object AddArticle__InClassVersion(Article article)
        {
            var articles = _db.AddArticle__InClassVersion(article);

            return articles;
        }

        ///
        /// my previous work
        /// 

        public List<Article> GetAllArticles()
        {

            List<Article> articles = _db.GetAllArticlesFromDatabase();

            if (articles != null)
                return articles;

            else return null; // not good
        }

        public Article GetArticleById(int id)
        {
            List<Article> articles = _db.GetArticleByIdFromDatabase(id);

            if (articles != null && articles.Count == 1)
                return articles[0];

            else return null; // not good
        }


        public async Task<Article> CreateNewArticle(Article article)
        {
            int createdArticleId = await _db.AddNewArticleToDatabase(article);

            // what's the error check here???
            // TODO: things around error checking


            // return the created article, look up by ID
            Article createdArticle = this.GetArticleById(createdArticleId);
            return createdArticle;
        }

        //public async Task<Article> UpdateArticle(Article article)
        public Article UpdateArticle(Article article)
        {
            //int code = await _db.UpdateArticleInDatabase(article);

            // do some kind of check...

            int id = _db.UpdateArticleInDatabase(article);

            if (id == article.Id)
            {
                // return the modified article, look up by ID
                Article modifiedArticle = this.GetArticleById(article.Id);
                return modifiedArticle;
            }
            return null;
        }


        public bool RemoveArticleById(int id)
        {
            return _db.RemoveArticleByIdFromDatabase(id);

        }

    }
}
