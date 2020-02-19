using System;
using DataModels;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DataAccess
    {
        private IConfiguration _configuration;

        public DataAccess() { }

        public DataAccess(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public Article[] GetAllArticlesFromDatabase()
        {
            var articles = new[] {
                new Article() {
                    Author = "Donna H",
                    Title = "My Title",
                    Body = "This is awesome text",
                    DateCreated = DateTime.Now
                },

                new Article() {
                    Author = "Prof Donna Harris",
                    Title = "My Article about Testing",
                    Body = "Testing is cool. Everybody should learn to test.",
                    DateCreated = DateTime.Now
                }
            };

            return articles;
        }

    }
}
