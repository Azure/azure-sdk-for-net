using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public abstract class ManagerBase
    {
        public ManagerBase(RestClient restClient, string subscriptionId)
        {
            if (restClient != null)
            {
                ResourceManager = ResourceManager2
                    .Authenticate(restClient)
                    .WithSubscription(subscriptionId);
            }
        }

        public IResourceManager ResourceManager {
            get; private set;
        }
    }
}
