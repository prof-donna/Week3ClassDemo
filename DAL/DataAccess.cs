using System;
using DataModels;

namespace DAL
{
    public class DataAccess
    {
        public DataAccess() { }

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
