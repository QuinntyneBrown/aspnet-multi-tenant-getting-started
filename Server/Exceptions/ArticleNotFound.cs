using System;

namespace Chloe.Server.Exceptions
{
    public class ArticleNotFoundException: NotFoundException
    {
        public ArticleNotFoundException()
            :base("Article Not Found")
        {
        }

        public ArticleNotFoundException(string message)
            :base(message)
        {

        }

        public ArticleNotFoundException(string message, Exception inner)
        {

        }
    }
}
