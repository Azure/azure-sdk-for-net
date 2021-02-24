// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Adapters;
using Azure.ResourceManager.Core.Resources;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Proto.Network
{
    /// <summary>
    /// A class representing collection of virtual nerwork and their operations over a resource group.
    /// </summary>
    public class VirtualNetworkContainer : ResourceContainerBase<VirtualNetwork, VirtualNetworkData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualNetworkContainer"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The parent resource group. </param>
        internal VirtualNetworkContainer(ResourceGroupOperations resourceGroup)
            : base(resourceGroup)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        private VirtualNetworksOperations Operations => new NetworkManagementClient(
            Id.Subscription,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).VirtualNetworks;

        /// <inheritdoc/>
        public override ArmResponse<VirtualNetwork> CreateOrUpdate(string name, VirtualNetworkData resourceDetails)
        {
            var operation = Operations.StartCreateOrUpdate(Id.ResourceGroup, name, resourceDetails);
            return new PhArmResponse<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(
                operation.WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult(),
                n => new VirtualNetwork(Parent, new VirtualNetworkData(n)));
        }

        /// <inheritdoc/>
        public async override Task<ArmResponse<VirtualNetwork>> CreateOrUpdateAsync(string name, VirtualNetworkData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = await Operations.StartCreateOrUpdateAsync(Id.ResourceGroup, name, resourceDetails, cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(
                await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                n => new VirtualNetwork(Parent, new VirtualNetworkData(n)));
        }

        /// <inheritdoc/>
        public override ArmOperation<VirtualNetwork> StartCreateOrUpdate(string name, VirtualNetworkData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(
                Operations.StartCreateOrUpdate(Id.ResourceGroup, name, resourceDetails, cancellationToken),
                n => new VirtualNetwork(Parent, new VirtualNetworkData(n)));
        }

        /// <inheritdoc/>
        public async override Task<ArmOperation<VirtualNetwork>> StartCreateOrUpdateAsync(string name, VirtualNetworkData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(
                await Operations.StartCreateOrUpdateAsync(Id.ResourceGroup, name, resourceDetails, cancellationToken).ConfigureAwait(false),
                n => new VirtualNetwork(Parent, new VirtualNetworkData(n)));
        }

        /// <summary>
        /// Constructs an object used to create a virtual nerwork.
        /// </summary>
        /// <param name="vnetCidr"> The CIDR of the resource. </param>
        /// <param name="location"> The location of the resource. </param>
        /// <returns> A builder with <see cref="VirtualNetwork"/> and <see cref="VirtualNetworkData"/>. </returns>
        public ArmBuilder<VirtualNetwork, VirtualNetworkData> Construct(string vnetCidr, LocationData location = null)
        {
            var parent = GetParentResource<ResourceGroup, ResourceGroupOperations>();
            var vnet = new Azure.ResourceManager.Network.Models.VirtualNetwork()
            {
                Location = location ?? parent.Data.Location,
                AddressSpace = new AddressSpace() { AddressPrefixes = new List<string>() { vnetCidr } },
            };

            return new ArmBuilder<VirtualNetwork, VirtualNetworkData>(this, new VirtualNetworkData(vnet));
        }

        /// <summary>
        /// Lists the virtual network for this resource group.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualNetwork> List(CancellationToken cancellationToken = default)
        {
            return new PhWrappingPageable<Azure.ResourceManager.Network.Models.VirtualNetwork, VirtualNetwork>(
                Operations.List(Id.Name, cancellationToken),
                Convertor());
        }

        /// <summary>
        /// Lists the virtual network for this resource group.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualNetwork> ListAsync(CancellationToken cancellationToken = default)
        {
            return new PhWrappingAsyncPageable<Azure.ResourceManager.Network.Models.VirtualNetwork, VirtualNetwork>(
                Operations.ListAsync(Id.Name, cancellationToken),
                Convertor());
        }

        /// <summary>
        /// Filters the list of virtual nerwork for this resource group represented as generic resources.
        /// </summary>
        /// <param name="filter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListByName(string filter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(VirtualNetworkData.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of virtual nerwork for this resource group represented as generic resources.
        /// </summary>
        /// <param name="filter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListByNameAsync(string filter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(VirtualNetworkData.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of virtual nerwork for this resource group.
        /// Makes an additional network call to retrieve the full data model for each virtual nerwork.
        /// </summary>
        /// <param name="filter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualNetwork> ListByNameExpanded(string filter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListByName(filter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, VirtualNetwork>(results, s => new VirtualNetworkOperations(s).Get().Value);
        }

        /// <summary>
        /// Filters the list of virtual nerwork for this resource group.
        /// Makes an additional network call to retrieve the full data model for each virtual nerwork.
        /// </summary>
        /// <param name="filter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An asyc collection of availability set that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualNetwork> ListByNameExpandedAsync(string filter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListByNameAsync(filter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, VirtualNetwork>(results, s => new VirtualNetworkOperations(s).Get().Value);
        }

        private Func<Azure.ResourceManager.Network.Models.VirtualNetwork, VirtualNetwork> Convertor()
        {
            return s => new VirtualNetwork(Parent, new VirtualNetworkData(s));
        }
    }
}
