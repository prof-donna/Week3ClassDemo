using System;
using DataModels;
using DAL;

namespace Library.BusinessLogic
{
    public class ArticleHandler
    {
        public ArticleHandler() { }

        public Article[] GetAllArticles()
        {
            DataAccess db = new DataAccess();

            var articles = db.GetAllArticlesFromDatabase();

            return articles;
        }

    }
}
