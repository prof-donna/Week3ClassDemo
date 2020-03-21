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





        public static bool BodyShorterThanTruncateLength(string body, int length)
        {
            return body.Length < length;
        }

        public static string ShortenBodyText(string body, int length)
        {
            // LATER ADDITION --- but this only fixes it in this version... we should consider combining or linking them up...
            //if (body.Length < length)
            if (BodyShorterThanTruncateLength(body, length))
                return body;

            return body.Substring(0, length);
        }

        public static string ShortenBodyText(string body, int length, bool addEllipsis)
        {
            // made the method dependent on the simpler method
            //string shortenedText = body.Substring(0, length);

            string shortenedText = ShortenBodyText(body, length);

            //if (addEllipsis)
            if (addEllipsis && !BodyShorterThanTruncateLength(body, length))
                return shortenedText + "...";

            return shortenedText;
        }

    }



}
