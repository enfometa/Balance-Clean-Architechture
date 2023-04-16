using Balance.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Core.Exceptions
{
    public class InvalidCredentailsException : Exception
    {
        public InvalidCredentailsException() : base(Messages.InvalidCredentials) { }
    }
}
