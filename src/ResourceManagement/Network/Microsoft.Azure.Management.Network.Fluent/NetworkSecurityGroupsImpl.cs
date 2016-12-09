// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya1NlY3VyaXR5R3JvdXBzSW1wbA==
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Management.Network.Fluent.Models;
    using System.Threading.Tasks;
    using Resource.Fluent.Core;
    using System.Threading;
    using Management.Network;

    /// <summary>
    /// Implementation for NetworkSecurityGroups.
    /// </summary>
    internal partial class NetworkSecurityGroupsImpl  :
        GroupableResources<
            INetworkSecurityGroup,
            NetworkSecurityGroupImpl,
            NetworkSecurityGroupInner,
            INetworkSecurityGroupsOperations,
            NetworkManager>,
        INetworkSecurityGroups
    {
        internal  NetworkSecurityGroupsImpl (
            INetworkSecurityGroupsOperations innerCollection, 
            NetworkManager networkManager) : base(innerCollection, networkManager)
        {
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36E25639805611CF89054C004B22BB15
        internal PagedList<INetworkSecurityGroup> List ()
        {
            var pagedList = new PagedList<NetworkSecurityGroupInner>(InnerCollection.ListAll(), (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:3953AC722DFFCDF40E1EEF787AFD1326
        internal PagedList<INetworkSecurityGroup> ListByGroup (string groupName)
        {
            var pagedList = new PagedList<NetworkSecurityGroupInner>(InnerCollection.List(groupName), (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        internal NetworkSecurityGroupImpl Define (string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:3F66CB38737E789E83D4F94D3B9FA876:B9B028D620AC932FDF66D2783E476B0D
        public override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        public override async Task<INetworkSecurityGroup> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = await InnerCollection.GetAsync(groupName, name, null, cancellationToken);
            return WrapModel(data);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:270930AE3F3A3D55E769C7D1E06A71C2
        override protected NetworkSecurityGroupImpl WrapModel (string name)
        {
            NetworkSecurityGroupInner inner = new NetworkSecurityGroupInner();
            return new NetworkSecurityGroupImpl(name, inner, InnerCollection, Manager);
        }

        //$TODO: return NetworkSecurityGroupImpl
        ///GENMHASH:B59141AC50BFD765AA31B7D8EBE354C5:DBC6065F28483C4BE88514804CCBFFAA
        override protected INetworkSecurityGroup WrapModel (NetworkSecurityGroupInner inner)
        {
            return new NetworkSecurityGroupImpl(inner.Name, inner, InnerCollection, Manager);
        }
    }
}
