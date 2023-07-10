using NovaEnergies.Core.Settings;
using NovaEnergies.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.Clients
{
    public abstract class ClientBase
    {
        private readonly ClientSettings _clientSettings;
        protected readonly Method[] Methods;

        public ClientBase(ClientSettings clientSettings)
        {
            _clientSettings = clientSettings;
            Methods = _clientSettings.Methods;
        }

        protected Method Method(string name)
        {
            return Methods.Single(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
