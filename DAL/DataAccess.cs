using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Dapper;
using DataModels;
using System.Threading.Tasks;

namespace DAL
{

    public class DataAccess
    {
        private readonly string DALconnectionString = "DefaultConnection";

        private IConfiguration _configuration;


        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public Article[] GetAllArticlesFromDatabase__InClassVersion()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.BlogConnectionStringValue(_configuration, DALconnectionString)))
            {
                Article[] articles = connection.Query<Article>("select * from Articles order by id asc").ToArray();

                return articles;

            }
        }


        public object AddArticle__InClassVersion(Article newArticle)
        {
            string queryString = "INSERT INTO Articles (Author, Title, Body, DateCreated) VALUES ( '" + newArticle.Author + "', '" + newArticle.Title + "', '" + newArticle.Body + "', '" + newArticle.DateCreated + "');";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.BlogConnectionStringValue(_configuration, DALconnectionString)))
            {
                Article[] articles = connection.Query<Article>(queryString).ToArray();

                return articles;
            }



        }

        public List<Article> GetAllArticlesFromDatabase()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.BlogConnectionStringValue(_configuration, DALconnectionString)))
            {
                // NOT GOOD PRACTICE... We are susceptible to SQL injection
                //return connection.Query<Article>("select * from Articles order by id asc").ToList();

                // INSTEAD Let's use a stored procedure / parametization
                List<Article> output = connection.Query<Article>("dbo.Articles_GetAll").ToList();

                // should check for null value...?

                return output;

            }
        }


        public List<Article> GetArticleByIdFromDatabase(int id)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.BlogConnectionStringValue(_configuration, DALconnectionString)))
            {
                // using a Dynamic class to pass in the Id ... and parametization
                List<Article> output = connection.Query<Article>("dbo.Articles_GetById @Id", new { Id = id }).ToList();

                return output;

            }

        }

        public async Task<int> AddNewArticleToDatabase(Article newArticle)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.BlogConnectionStringValue(_configuration, DALconnectionString)))
            {
                var returnval = await connection.QueryAsync<int>("dbo.Article_AddNew @Author, @Title, @Body, @DateCreated", newArticle);

                //return (int)returnval;
                return returnval.Single();
            }

        }

        //public async Task<int> UpdateArticleInDatabase(Article article)
        public int UpdateArticleInDatabase(Article article)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.BlogConnectionStringValue(_configuration, DALconnectionString)))
            {
                //var returnval = await connection.QueryAsync<int>("dbo.Article_Update @Id, @Author, @Title, @Body, @DateModified", article);

                // should have return value with ID, even though it should not have changed

                //return (int)returnval;
                //return returnval.Single();

                var _params = new DynamicParameters { };

                _params.Add(
                    name: "Id",
                    value: article.Id,
                    dbType: DbType.Int32,
                    direction: ParameterDirection.Input
                    );

                _params.Add(
                    name: "Author",
                    value: article.Author,
                    dbType: DbType.String,
                    direction: ParameterDirection.Input
                    );

                _params.Add(
                    name: "Title",
                    value: article.Title,
                    dbType: DbType.String,
                    direction: ParameterDirection.Input
                    );
                _params.Add(
                    name: "Body",
                    value: article.Body,
                    dbType: DbType.String,
                    direction: ParameterDirection.Input
                    );
                _params.Add(
                    name: "DateModified",
                    value: article.DateModified,
                    dbType: DbType.DateTime,
                    direction: ParameterDirection.Input
                    );

                _params.Add(
                    name: "ReturnValue",
                    dbType: DbType.Int32,
                    direction: ParameterDirection.ReturnValue
                    );

                var output = connection.Execute("dbo.Article_Update", _params, commandType: CommandType.StoredProcedure);

                //bool code = false;

                int returnCode = _params.Get<int>("ReturnValue");

                if (returnCode == article.Id)
                    return returnCode;

                return -1;

            }

        }


        public bool RemoveArticleByIdFromDatabase(int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.BlogConnectionStringValue(_configuration, DALconnectionString)))
            {
                var _params = new DynamicParameters { };

                _params.Add(
                    name: "Id",
                    value: id,
                    dbType: DbType.Int32,
                    direction: ParameterDirection.Input
                    );

                _params.Add(
                    name: "ReturnValue",
                    dbType: DbType.Int32,
                    direction: ParameterDirection.ReturnValue
                    );

                var output = connection.Execute("dbo.Articles_RemoveById", _params, commandType: CommandType.StoredProcedure);

                bool code = false;

                int returnCode = _params.Get<int>("ReturnValue");

                if (returnCode == 1126)
                    code = true;

                return code;


            }
        }

    }
}
