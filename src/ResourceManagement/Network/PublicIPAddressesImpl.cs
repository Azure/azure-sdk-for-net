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
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUHVibGljSVBBZGRyZXNzZXNJbXBs
    internal partial class PublicIPAddressesImpl :
        TopLevelModifiableResources<
            IPublicIPAddress,
            PublicIPAddressImpl,
            PublicIPAddressInner,
            IPublicIPAddressesOperations,
            INetworkManager>,
        IPublicIPAddresses
    {
        
        ///GENMHASH:A1D964DB97779D812D0C93D447CB7818:6F402543E6A59425FA7E91D1FDA4819D
        internal PublicIPAddressesImpl(INetworkManager networkManager)
            : base(networkManager.Inner.PublicIPAddresses, networkManager)
        {
        }

        
        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:FCFACB76B4D63EBF69321C444D37D659
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

        
        ///GENMHASH:B52B92D4359429345BB9A526A6320669:A3D17BA35D1E31DF90DF0C3A7FAD85B5
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

        
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
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
