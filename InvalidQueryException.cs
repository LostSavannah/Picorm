using System;

namespace Picorm
{
    public class InvalidQueryException:Exception
    {

        public InvalidQueryException(string message = "An invalid query has occur"):base(message)
        {

        }
        public InvalidQueryException(Exception inner, string message = "An invalid query has occur") :base(message, inner)
        {

        }
    }
}
