using Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Management.V2.Storage
{
    public class PublicEndpoints
    {
        internal PublicEndpoints(Endpoints primary, Endpoints secondary)
        {
            Primary = primary;
            Secondary = secondary;
        }

        public Endpoints Primary
        {
            get; private set;
        }

        public Endpoints Secondary
        {
            get; private set;
        }
    }
}
