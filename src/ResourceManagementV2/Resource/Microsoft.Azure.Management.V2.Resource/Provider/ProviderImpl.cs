using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class ProviderImpl :
        IndexableWrapper<ProviderInner>,
        IProvider
    {
        internal ProviderImpl(ProviderInner provider) : base(provider.Id, provider)
        {
        }

        public string Namespace
        {
            get
            {
                return Inner.NamespaceProperty;
            }
        }

        public string RegistrationState
        {
            get
            {
                return Inner.RegistrationState;
            }
        }

        public IList<ProviderResourceType> ResourceTypes
        {
            get
            {
                return Inner.ResourceTypes;
            }
        }
    }
}
