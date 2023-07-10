using NovaEnergies.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.Settings
{
    public  class ClientSettings
    {
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public int Timeout { get; set; }

        public Method[] Methods { get; set; }
    }
}
