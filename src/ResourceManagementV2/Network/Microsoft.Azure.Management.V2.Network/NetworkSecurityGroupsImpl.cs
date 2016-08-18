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
    internal class NetworkSecurityGroupsImpl :
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

            NetworkSecurityGroupInner inner = new NetworkSecurityGroupInner();

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

        /// <summary>
        /// Begins a definition for a new resource.
        /// <p>
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is {@link Creatable#create()}.
        /// <p>
        /// Note that the {@link Creatable#create()} method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see {@link Creatable#create()} among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">name the name of the new resource</param>
        /// <returns>the first stage of the new resource definition</returns>
        NetworkSecurityGroup.Definition.IBlank Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsCreating<NetworkSecurityGroup.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">id the resource ID of the resource to delete</param>
        void Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsDeleting.Delete(string id)
        {
            this.Delete(id);
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">resourceGroupName the name of the resource group to list the resources from</param>
        /// <returns>the list of resources</returns>
        Microsoft.Azure.Management.V2.Resource.Core.PagedList<INetworkSecurityGroup> Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsListingByGroup<INetworkSecurityGroup>.ListByGroup(string resourceGroupName)
        {
            return this.ListByGroup(resourceGroupName) as Microsoft.Azure.Management.V2.Resource.Core.PagedList<INetworkSecurityGroup>;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name and the name of its resource group.
        /// </summary>
        /// <param name="resourceGroupName">resourceGroupName the name of the resource group the resource is in</param>
        /// <param name="name">name the name of the resource. (Note, this is not the ID)</param>
        /// <returns>an immutable representation of the resource</returns>
        INetworkSecurityGroup Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsGettingByGroup<INetworkSecurityGroup>.GetByGroup(string resourceGroupName, string name)
        {
            return this.GetByGroup(resourceGroupName, name) as INetworkSecurityGroup;
        }

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="groupName">groupName The group the resource is part of</param>
        /// <param name="name">name The name of the resource</param>
        void Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsDeletingByGroup.Delete(string groupName, string name)
        {
            this.Delete(groupName, name);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <returns>list of resources</returns>
        Microsoft.Azure.Management.V2.Resource.Core.PagedList<INetworkSecurityGroup> Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsListing<INetworkSecurityGroup>.List()
        {
            return this.List() as Microsoft.Azure.Management.V2.Resource.Core.PagedList<INetworkSecurityGroup>;
        }

        Task<PagedList<INetworkSecurityGroup>> ISupportsListingByGroup<INetworkSecurityGroup>.ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task ISupportsDeleting.DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await this.InnerCollection.DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        async Task ISupportsDeletingByGroup.DeleteAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        public async override Task<INetworkSecurityGroup> GetByGroupAsync(string groupName, string name)
        {
            var data = await this.InnerCollection.GetAsync(groupName, name);
            return this.WrapModel(data);
        }
    }
}