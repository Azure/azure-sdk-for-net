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
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUHVibGljSXBBZGRyZXNzZXNJbXBs
    internal partial class PublicIPAddressesImpl :
        TopLevelModifiableResources<
            IPublicIPAddress,
            PublicIPAddressImpl,
            PublicIPAddressInner,
            IPublicIPAddressesOperations,
            INetworkManager>,
        IPublicIPAddresses
    {
        ///GENMHASH:053A36D2D2F106CA9668224DB2C96180:5AC88BA549EC2FB48FFEA9A94BE29B89
        internal PublicIPAddressesImpl(INetworkManager networkManager)
            : base(networkManager.Inner.PublicIPAddresses, networkManager)
        {
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:1B78BFBA3CB91189897507DAD97A4342
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

        ///GENMHASH:B52B92D4359429345BB9A526A6320669:90C57C05A1A9A5C6A7F2A81DCB266191
        override protected IPublicIPAddress WrapModel(PublicIPAddressInner inner)
        {
            return new PublicIPAddressImpl(inner.Id, inner, Manager);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36E25639805611CF89054C004B22BB15
        protected async override Task<IPage<PublicIPAddressInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAllAsync(cancellationToken);
        }

        protected async override Task<IPage<PublicIPAddressInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListAllNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:3953AC722DFFCDF40E1EEF787AFD1326
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

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        protected async override Task<PublicIPAddressInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }
    }
}
