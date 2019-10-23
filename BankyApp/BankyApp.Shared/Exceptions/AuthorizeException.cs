using System;
using System.Collections.Generic;
using System.Text;

namespace BankyApp.Shared.Exceptions
{
   public class AuthorizeException : Exception
    {
                
        public AuthorizeException()
        {
        }

        public AuthorizeException(string message)
        : base(message)
        {
        }

        public AuthorizeException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
