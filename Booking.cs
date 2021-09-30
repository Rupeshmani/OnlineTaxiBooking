using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int TaxiId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime TripDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
    }
}
