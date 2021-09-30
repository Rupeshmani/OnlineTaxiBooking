using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class OTBException: ApplicationException
    {
        public OTBException()
            : base()
        {
        }

        public OTBException(string message)
            : base(message)
        {
        }
     
    }
}
