using NovaEnergies.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.Clients.Responses
{
    public class SearchServiceResponse
    {
        public List<Route> Routes { get; set; } = new List<Route>();
    }
}
