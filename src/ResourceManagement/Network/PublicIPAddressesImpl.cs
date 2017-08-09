// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for PublicIPAddresses.
    /// </summary>
    
    internal partial class PublicIPAddressesImpl :
        TopLevelModifiableResources<
            IPublicIPAddress,
            PublicIPAddressImpl,
            PublicIPAddressInner,
            IPublicIPAddressesOperations,
            INetworkManager>,
        IPublicIPAddresses
    {
        
        internal PublicIPAddressesImpl(INetworkManager networkManager)
            : base(networkManager.Inner.PublicIPAddresses, networkManager)
        {
        }

        
        override protected PublicIPAddressImpl WrapModel(string name)
        {
            PublicIPAddressInner inner = new PublicIPAddressInner();

            if (null == inner.DnsSettings)
            {
                inner.DnsSettings = new PublicIPAddressDnsSettings();
            }

            return new PublicIPAddressImpl(name, inner, Manager);
        }

        //$TODO: shoudl return PublicIPAddressImpl

        
        override protected IPublicIPAddress WrapModel(PublicIPAddressInner inner)
        {
            return new PublicIPAddressImpl(inner.Id, inner, Manager);
        }

        
        protected async override Task<IPage<PublicIPAddressInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAllAsync(cancellationToken);
        }

        protected async override Task<IPage<PublicIPAddressInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListAllNextAsync(nextLink, cancellationToken);
        }

        
        protected async override Task<IPage<PublicIPAddressInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<PublicIPAddressInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        
        internal PublicIPAddressImpl Define(string name)
        {
            return WrapModel(name);
        }

        
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        
        protected async override Task<PublicIPAddressInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }
    }
}
