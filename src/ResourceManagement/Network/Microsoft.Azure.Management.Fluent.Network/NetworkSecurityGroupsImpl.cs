// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Network
{
    using Management.Network.Models;
    using System.Threading.Tasks;
    using Resource.Core;
    using System.Threading;
    using Management.Network;

    /// <summary>
    /// Implementation for NetworkSecurityGroups.
    /// </summary>
    public partial class NetworkSecurityGroupsImpl  :
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

        public PagedList<INetworkSecurityGroup> List ()
        {
            var pagedList = new PagedList<NetworkSecurityGroupInner>(InnerCollection.ListAll(), (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        public PagedList<INetworkSecurityGroup> ListByGroup (string groupName)
        {
            var pagedList = new PagedList<NetworkSecurityGroupInner>(InnerCollection.List(groupName), (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        public NetworkSecurityGroupImpl Define (string name)
        {
            return WrapModel(name);
        }

        Task DeleteAsync(string groupName, string name)
        {
            return InnerCollection.DeleteAsync(groupName, name);
        }

        public override async Task<INetworkSecurityGroup> GetByGroupAsync(string groupName, string name)
        {
            var data = await InnerCollection.GetAsync(groupName, name);
            return WrapModel(data);
        }

        override protected NetworkSecurityGroupImpl WrapModel (string name)
        {
            NetworkSecurityGroupInner inner = new NetworkSecurityGroupInner();
            return new NetworkSecurityGroupImpl(name, inner, InnerCollection, Manager);
        }

        //$TODO: return NetworkSecurityGroupImpl
        override protected INetworkSecurityGroup WrapModel (NetworkSecurityGroupInner inner)
        {
            return new NetworkSecurityGroupImpl(inner.Name, inner, InnerCollection, Manager);
        }

        public void Delete(string id)
        {
            DeleteAsync(id).Wait();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete(string groupName, string name)
        {
            DeleteAsync(groupName, name).Wait();
        }
    }
}