/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource;
    using Management.Network;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using System.Threading;

    /// <summary>
    /// Implementation for {@link Networks}.
    /// </summary>
    public class NetworksImpl :
        GroupableResources<INetwork, NetworkImpl, VirtualNetworkInner, IVirtualNetworksOperations, NetworkManager>,
        INetworks
    {
        internal NetworksImpl(NetworkManagementClient networkClient, NetworkManager networkManager) : 
            base(networkClient.VirtualNetworks, networkManager)
        {
        }

        public PagedList<INetwork> List()
        {
            IEnumerable<VirtualNetworkInner> list = InnerCollection.ListAll();
            var pagedList = new PagedList<VirtualNetworkInner>(list);
            return this.WrapList(pagedList);
        }

        public PagedList<INetwork> ListByGroup(string groupName)
        {
            IEnumerable<VirtualNetworkInner> list = InnerCollection.List(groupName);
            var pagedList = new PagedList<VirtualNetworkInner>(list);
            return this.WrapList(pagedList);
        }

        public void Delete(string id)
        {
            this.Delete(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete(string groupName, string name)
        {
            this.InnerCollection.Delete(groupName, name);
        }

        public NetworkImpl Define(string name)
        {
            return this.WrapModel(name);
        }

        protected override NetworkImpl WrapModel(string name)
        {
            VirtualNetworkInner inner = new VirtualNetworkInner();

            // Initialize address space
            AddressSpace addressSpace = inner.AddressSpace;
            if (addressSpace == null)
            {
                addressSpace = new AddressSpace();
                inner.AddressSpace = addressSpace;
            }

            if (addressSpace.AddressPrefixes == null)
            {
                addressSpace.AddressPrefixes  =new List<string>();
            }

            // Initialize subnets
            if (inner.Subnets == null)
            {
                inner.Subnets = new List<SubnetInner>();
            }

            // Initialize DHCP options (DNS servers)
            DhcpOptions dhcp = inner.DhcpOptions;
            if (dhcp == null)
            {
                dhcp = new DhcpOptions();
                inner.DhcpOptions = dhcp;
            }

            if (dhcp.DnsServers == null)
            {
                dhcp.DnsServers = new List<string>();
            }

            return this.WrapModel(inner) as NetworkImpl;
        }

        protected override INetwork WrapModel(VirtualNetworkInner inner)
        {
            return new NetworkImpl(
                inner.Name,
                inner,
                this.InnerCollection as VirtualNetworksOperations,
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
        Network.Definition.IBlank Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsCreating<Network.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as Network.Definition.IBlank;
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
        Microsoft.Azure.Management.V2.Resource.Core.PagedList<INetwork> Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsListingByGroup<INetwork>.ListByGroup(string resourceGroupName)
        {
            return this.ListByGroup(resourceGroupName) as Microsoft.Azure.Management.V2.Resource.Core.PagedList<INetwork>;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name and the name of its resource group.
        /// </summary>
        /// <param name="resourceGroupName">resourceGroupName the name of the resource group the resource is in</param>
        /// <param name="name">name the name of the resource. (Note, this is not the ID)</param>
        /// <returns>an immutable representation of the resource</returns>
        INetwork Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsGettingByGroup<INetwork>.GetByGroup(string resourceGroupName, string name)
        {
            return this.GetByGroup(resourceGroupName, name) as INetwork;
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
        Microsoft.Azure.Management.V2.Resource.Core.PagedList<INetwork> Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsListing<INetwork>.List()
        {
            return this.List() as Microsoft.Azure.Management.V2.Resource.Core.PagedList<INetwork>;
        }

        Task<PagedList<INetwork>> ISupportsListingByGroup<INetwork>.ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
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

        public async override Task<INetwork> GetByGroupAsync(string groupName, string name)
        {
            var data = await this.InnerCollection.GetAsync(groupName, name);
            return this.WrapModel(data);
        }
    }
}