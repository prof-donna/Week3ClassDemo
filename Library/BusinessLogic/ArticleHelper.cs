using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BusinessLogic
{
    public static class ArticleHelper
    {
        public static string TruncateInputText(string text)
        {
            if (text.Length > 150)
            {
                return text.Substring(0, 150) + "..."; ;
            
            }
            else
            {
                return text;
            }

            return null;
        }
    }
}
