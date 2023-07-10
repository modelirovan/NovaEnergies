using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.Clients.Requests
{
    public class SearchServiceRequest
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal RoutePrice { get; set; }
        public TimeSpan TTL { get; set; }
    }
}
