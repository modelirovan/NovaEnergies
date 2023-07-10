using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.Types
{
    public class Route
    {
        public Guid Guid { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RoutePrice { get; set; }
        public TimeSpan TimeToLive { get; set; }
    }
}
