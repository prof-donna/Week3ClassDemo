using System;
using DataModels;
using DAL;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Library.BusinessLogic
{
    public class ArticleHandler
    {
        private IConfiguration _configuration;

        public ArticleHandler() { }

        public ArticleHandler(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public Article[] GetAllArticles()
        {
            DataAccess db = new DataAccess(_configuration);

            var articles = db.GetAllArticlesFromDatabase();

            return articles;
        }

    }
}
