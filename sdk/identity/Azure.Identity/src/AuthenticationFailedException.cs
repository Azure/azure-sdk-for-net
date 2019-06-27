using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class AuthenticationFailedException : Exception
    {
        public AuthenticationFailedException(string message)
            : this(message, null)
        {
        }

        public AuthenticationFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
