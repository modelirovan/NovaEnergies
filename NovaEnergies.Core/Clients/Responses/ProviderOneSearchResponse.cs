using NovaEnergies.Core.DTOs;
using NovaEnergies.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.Clients.Responses
{
    public class ProviderOneSearchResponse
    {
        public List<RouteDto> Routes { get; set; } = new List<RouteDto>();
    }
}
