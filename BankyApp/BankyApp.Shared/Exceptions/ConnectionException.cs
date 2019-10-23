using System;
using System.Collections.Generic;
using System.Text;

namespace BankyApp.Shared.Exceptions
{
   public class ConnectionException : Exception
    {

        public ConnectionException()
        {
        }

        public ConnectionException(string message)
        : base(message)
        {
        }

        public ConnectionException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
