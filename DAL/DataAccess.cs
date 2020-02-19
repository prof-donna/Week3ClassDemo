using System;
using DataModels;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace DAL
{
    public class DataAccess
    {
        private readonly string ConnectionStringName = "DefaultConnection";
        
        private IConfiguration _configuration;

        public DataAccess() { }

        public DataAccess(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public Article[] GetAllArticlesFromDatabase()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection( Helper.BlogConnectionStringValue( _configuration, ConnectionStringName ) ) )
            {
                Article[] articles = connection.Query<Article>("select * from Articles order by id asc").ToArray();

                return articles;
            }
        }

        public object AddArticleToDatabase(Article newArticle)
        {
            string queryString = "INSERT INTO Articles (Author, Title, Body, DateCreated) VALUES ( '" + newArticle.Author + "', '" + newArticle.Title + "', '" + newArticle.Body + "', '" + newArticle.DateCreated + "');";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.BlogConnectionStringValue(_configuration, ConnectionStringName)))
            {
                Article[] articles = connection.Query<Article>(queryString).ToArray();

                return articles;
            }



        }
    }
}
