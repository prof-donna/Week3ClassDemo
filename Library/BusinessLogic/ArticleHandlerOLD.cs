using System;
using DataModels;
using DAL;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Library.BusinessLogic
{
    public class ArticleHandlerOLD
    {
        public static readonly int BODY_LENGTH_IN_PREVIEW = 25;


        private IConfiguration _configuration;

        public ArticleHandlerOLD() { }

        public ArticleHandlerOLD(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public Article[] GetAllArticles()
        {
            DataAccessOLD db = new DataAccessOLD(_configuration);

            var articles = db.GetAllArticlesFromDatabase();

            return articles;
        }

        public object AddArticle(Article article)
        {
            DataAccessOLD db = new DataAccessOLD(_configuration);

            var articles = db.AddArticleToDatabase(article);

            return articles;
        }
    }
}
