using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.DTOs
{
    public class RouteDto
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public PointDto StartPoint { get; set; }
        public PointDto EndPoint { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RoutePrice { get; set; }
        public TimeSpan TimeToLive { get; set; }
    }
}
