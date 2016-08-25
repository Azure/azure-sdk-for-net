/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.Network.Models;
    using Management.Network;
    using System;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for {@link NetworkSecurityGroups}.
    /// </summary>
    public partial class NetworkSecurityGroupsImpl :
        GroupableResources<INetworkSecurityGroup, NetworkSecurityGroupImpl, NetworkSecurityGroupInner, INetworkSecurityGroupsOperations, NetworkManager>,
        INetworkSecurityGroups
    {
        internal NetworkSecurityGroupsImpl(INetworkSecurityGroupsOperations innerCollection, NetworkManager networkManager) :
            base(innerCollection, networkManager)
        {
        }

        public PagedList<INetworkSecurityGroup> List()
        {
            IEnumerable<NetworkSecurityGroupInner> list = InnerCollection.ListAll();
            var pagedList = new PagedList<NetworkSecurityGroupInner>(list);
            return WrapList(pagedList);
        }

        public PagedList<INetworkSecurityGroup> ListByGroup(string groupName)
        {
            IEnumerable<NetworkSecurityGroupInner> list = InnerCollection.List(groupName);
            var pagedList = new PagedList<NetworkSecurityGroupInner>(list);
            return WrapList(pagedList);
        }

        public void Delete(string id)
        {
           this.Delete(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete(string groupName, string name)
        {
            this.InnerCollection.Delete(groupName, name);
        }

        public NetworkSecurityGroupImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected override NetworkSecurityGroupImpl WrapModel(string name)
        {

            NetworkSecurityGroupInner inner = new NetworkSecurityGroupInner(name: name);

            // Initialize rules
            if (inner.SecurityRules == null)
            {
                inner.SecurityRules = new List<SecurityRuleInner>();
            }

            if (inner.DefaultSecurityRules == null)
            {
                inner.DefaultSecurityRules = new List<SecurityRuleInner>();
            }

            return this.WrapModel(inner) as NetworkSecurityGroupImpl;
        }

        protected override INetworkSecurityGroup WrapModel(NetworkSecurityGroupInner inner)
        {
            return new NetworkSecurityGroupImpl(
                inner.Name,
                inner,
                this.InnerCollection,
                this.MyManager);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await this.InnerCollection.DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public async Task DeleteAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        Task<PagedList<INetworkSecurityGroup>> ISupportsListingByGroup<INetworkSecurityGroup>.ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async override Task<INetworkSecurityGroup> GetByGroupAsync(string groupName, string name)
        {
            var data = await this.InnerCollection.GetAsync(groupName, name);
            return this.WrapModel(data);
        }
    }
}