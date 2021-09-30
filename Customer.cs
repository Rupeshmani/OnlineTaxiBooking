using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    class Customer
    {
        public int CustomerId { get; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string CustomerAddress { get; set; }
    }
}
