using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Filters
{
    public class UserException : Exception
    {
        public UserException(string message): base(message)
        {

        }
    }
}
