// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Network
{
    /// <summary>
    /// A class representing collection of virtual network and their operations over a resource group.
    /// </summary>
    public class VirtualNetworkContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, VirtualNetwork, VirtualNetworkData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualNetworkContainer"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The parent resource group. </param>
        internal VirtualNetworkContainer(ResourceGroupOperations resourceGroup)
            : base(resourceGroup)
        {
        }

        /// <summary>
        /// Typed Resource Identifier for the container.
        /// </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        private VirtualNetworksOperations Operations => new NetworkManagementClient(
            Id.SubscriptionId,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).VirtualNetworks;

        /// <summary>
        /// The operation to create or update a virtual network. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the virtual network. </param>
        /// <param name="resourceDetails"> The desired virtual network configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="Response{VirtualNetwork}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Name of the virtual network cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public Response<VirtualNetwork> CreateOrUpdate(string name, VirtualNetworkData resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
            return Response.FromValue(new VirtualNetwork(Parent, new VirtualNetworkData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// The operation to create or update a virtual network. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the virtual network. </param>
        /// <param name="resourceDetails"> The desired virtual network configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="Response{VirtualNetwork}"/> operation for this virtual network. </returns>
        /// <exception cref="ArgumentException"> Name of the virtual network cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public async Task<Response<VirtualNetwork>> CreateOrUpdateAsync(string name, VirtualNetworkData resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult().WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new VirtualNetwork(Parent, new VirtualNetworkData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// The operation to create or update a virtual network. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the virtual network. </param>
        /// <param name="resourceDetails"> The desired virtual network configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An <see cref="Operation{VirtualNetwork}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name of the virtual network cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public Operation<VirtualNetwork> StartCreateOrUpdate(string name, VirtualNetworkData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(
                Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails, cancellationToken),
                n => new VirtualNetwork(Parent, new VirtualNetworkData(n)));
        }

        /// <summary>
        /// The operation to create or update a virtual network. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the virtual network. </param>
        /// <param name="resourceDetails"> The desired virtual network configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="Operation{VirtualNetwork}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name of the virtual network cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public async Task<Operation<VirtualNetwork>> StartCreateOrUpdateAsync(string name, VirtualNetworkData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<VirtualNetwork, Azure.ResourceManager.Network.Models.VirtualNetwork>(
                await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails, cancellationToken).ConfigureAwait(false),
                n => new VirtualNetwork(Parent, new VirtualNetworkData(n)));
        }

        /// <summary>
        /// Constructs an object used to create a virtual network.
        /// </summary>
        /// <param name="vnetCidr"> The CIDR of the resource. </param>
        /// <param name="location"> The location of the resource. </param>
        /// <returns> A builder with <see cref="VirtualNetwork"/> and <see cref="VirtualNetworkData"/>. </returns>
        public VirtualNetworkBuilder Construct(string vnetCidr, LocationData location = null)
        {
            var parent = GetParentResource<ResourceGroup, ResourceGroupResourceIdentifier, ResourceGroupOperations>();
            var vnet = new Azure.ResourceManager.Network.Models.VirtualNetwork()
            {
                Location = location ?? parent.Data.Location,
                AddressSpace = new AddressSpace(),
            };
            vnet.AddressSpace.AddressPrefixes.Add(vnetCidr);

            return new VirtualNetworkBuilder(this, new VirtualNetworkData(vnet));
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
        /// Filters the list of virtual network for this resource group represented as generic resources.
        /// </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(VirtualNetworkData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of virtual network for this resource group represented as generic resources.
        /// </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(VirtualNetworkData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of virtual network for this resource group.
        /// Makes an additional network call to retrieve the full data model for each virtual network.
        /// </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualNetwork> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, VirtualNetwork>(results, s => new VirtualNetworkOperations(s).Get().Value);
        }

        /// <summary>
        /// Filters the list of virtual network for this resource group.
        /// Makes an additional network call to retrieve the full data model for each virtual network.
        /// </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An asyc collection of availability set that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualNetwork> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, VirtualNetwork>(results, s => new VirtualNetworkOperations(s).Get().Value);
        }

        private Func<Azure.ResourceManager.Network.Models.VirtualNetwork, VirtualNetwork> Convertor()
        {
            return s => new VirtualNetwork(Parent, new VirtualNetworkData(s));
        }

        /// <inheritdoc/>
        public override Response<VirtualNetwork> Get(string virtualNetworkName, CancellationToken cancellationToken = default)
        {
            var response = Operations.Get(Id.ResourceGroupName, virtualNetworkName, cancellationToken: cancellationToken);
            return Response.FromValue(new VirtualNetwork(Parent, new VirtualNetworkData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public override async Task<Response<VirtualNetwork>> GetAsync(string virtualNetworkName, CancellationToken cancellationToken = default)
        {
            var response = await Operations.GetAsync(Id.ResourceGroupName, virtualNetworkName, null, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new VirtualNetwork(Parent, new VirtualNetworkData(response.Value)), response.GetRawResponse());
        }

    }
}
