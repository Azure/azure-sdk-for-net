// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Network
{
    /// <summary>
    /// A class representing collection of <see cref="NetworkInterface"/> and their operations over a <see cref="ResourceGroup"/>.
    /// </summary>
    public class NetworkInterfaceContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, NetworkInterface, NetworkInterfaceData>
    {
        internal NetworkInterfaceContainer(ResourceGroupOperations resourceGroup)
            : base(resourceGroup)
        {
        }

        internal NetworkInterfacesOperations Operations => new NetworkManagementClient(
            Id.SubscriptionId,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).NetworkInterfaces;

        /// <inheritdoc/>
        /// <summary>
        /// Typed Resource Identifier for the container.
        /// </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary>
        /// ResourceType for the container.
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        /// <inheritdoc/>
        public override ArmResponse<NetworkInterface> CreateOrUpdate(string name, NetworkInterfaceData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails, cancellationToken);
            return new PhArmResponse<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult(),
                n => new NetworkInterface(Parent, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public async override Task<ArmResponse<NetworkInterface>> CreateOrUpdateAsync(string name, NetworkInterfaceData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails, cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                n => new NetworkInterface(Parent, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public override ArmOperation<NetworkInterface> StartCreateOrUpdate(string name, NetworkInterfaceData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails, cancellationToken),
                n => new NetworkInterface(Parent, new NetworkInterfaceData(n)));
        }

        /// <inheritdoc/>
        public async override Task<ArmOperation<NetworkInterface>> StartCreateOrUpdateAsync(string name, NetworkInterfaceData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails, cancellationToken).ConfigureAwait(false),
                n => new NetworkInterface(Parent, new NetworkInterfaceData(n)));
        }

        /// <summary>
        /// Constructs an object used to create a <see cref="NetworkInterface"/>.
        /// </summary>
        /// <param name="ip"> The public IP address of the <see cref="NetworkInterface"/>. </param>
        /// <param name="subnetId"> The resource identifier of the subnet attached to this <see cref="NetworkInterface"/>. </param>
        /// <param name="location"> The <see cref="LocationData"/> that will contain the <see cref="NetworkInterface"/>. </param>
        /// <returns>An object used to create a <see cref="NetworkInterface"/>. </returns>
        public ArmBuilder<ResourceGroupResourceIdentifier, NetworkInterface, NetworkInterfaceData> Construct(string subnetId, PublicIPAddressData ip = default, LocationData location = null)
        {
            var parent = GetParentResource<ResourceGroup, ResourceGroupResourceIdentifier, ResourceGroupOperations>();
            var nic = new Azure.ResourceManager.Network.Models.NetworkInterface()
            {
                Location = location ?? parent.Data.Location,
            };

            nic.IpConfigurations.Add(new NetworkInterfaceIPConfiguration()
            {
                Name = "Primary",
                Primary = true,
                Subnet = new Azure.ResourceManager.Network.Models.Subnet() { Id = subnetId },
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
            });

            if (ip != null)
                nic.IpConfigurations[0].PublicIPAddress = new PublicIPAddress() { Id = ip.Id };

            return new ArmBuilder<ResourceGroupResourceIdentifier, NetworkInterface, NetworkInterfaceData>(this, new NetworkInterfaceData(nic));
        }

        /// <summary>
        /// Lists the <see cref="NetworkInterface"/> for this <see cref="ResourceGroup"/>.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. 
        /// The default value is <see cref="System.Threading.CancellationToken.None"/>. </param>
        /// <returns> A collection of <see cref="NetworkInterface"/> that may take multiple service requests to iterate over. </returns>
        public Pageable<NetworkInterfaceOperations> List(CancellationToken cancellationToken = default)
        {
            return new PhWrappingPageable<Azure.ResourceManager.Network.Models.NetworkInterface, NetworkInterfaceOperations>(
                Operations.List(Id.Name, cancellationToken),
                this.convertor());
        }

        /// <summary>
        /// Lists the <see cref="NetworkInterface"/> for this <see cref="ResourceGroup"/>.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. 
        /// The default value is <see cref="System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="NetworkInterface"/> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<NetworkInterfaceOperations> ListAsync(CancellationToken cancellationToken = default)
        {
            var result = Operations.ListAsync(Id.Name, cancellationToken);
            return new PhWrappingAsyncPageable<Azure.ResourceManager.Network.Models.NetworkInterface, NetworkInterfaceOperations>(
                result,
                this.convertor());
        }

        /// <summary>
        /// Filters the list of <see cref="NetworkInterface"/> resources for this <see cref="ResourceGroup"/> represented as generic resources.
        /// </summary>
        /// <param name="nameFilter"> A string to filter the <see cref="NetworkInterface"/> resources by name. </param>
        /// <param name="top"> The number of results to return per page of data. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. 
        /// The default value is <see cref="System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(NetworkInterfaceData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of <see cref="NetworkInterface"/> resources for this <see cref="ResourceGroup"/> represented as generic resources.
        /// </summary>
        /// <param name="nameFilter"> A string to filter the <see cref="NetworkInterface"/> resources by name. </param>
        /// <param name="top"> The number of results to return per page of data. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. 
        /// The default value is <see cref="System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(NetworkInterfaceData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of <see cref="NetworkInterface"/> resources for this <see cref="ResourceGroup"/>. 
        /// Makes an additional network call to retrieve the full data model for each <see cref="NetworkInterface"/>.
        /// </summary>
        /// <param name="nameFilter"> A string to filter the <see cref="NetworkInterface"/> resources by name. </param>
        /// <param name="top"> The number of results to return per page of data. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. 
        /// The default value is <see cref="System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<NetworkInterface> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, NetworkInterface>(results, s => new NetworkInterfaceOperations(s).Get().Value);
        }

        /// <summary>
        /// Filters the list of <see cref="NetworkInterface"/> resources for this <see cref="ResourceGroup"/>. 
        /// Makes an additional network call to retrieve the full data model for each <see cref="NetworkInterface"/>.
        /// </summary>
        /// <param name="nameFilter"> A string to filter the <see cref="NetworkInterface"/> resources by name. </param>
        /// <param name="top"> The number of results to return per page of data. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. 
        /// The default value is <see cref="System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<NetworkInterface> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, NetworkInterface>(results, s => new NetworkInterfaceOperations(s).Get().Value);
        }

        private Func<Azure.ResourceManager.Network.Models.NetworkInterface, NetworkInterface> convertor()
        {
            return s => new NetworkInterface(Parent, new NetworkInterfaceData(s));
        }

        /// <inheritdoc />
        public override ArmResponse<NetworkInterface> Get(string networkInterfaceName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                Operations.Get(Id.ResourceGroupName, networkInterfaceName, cancellationToken: cancellationToken),
                g => new NetworkInterface(Parent, new NetworkInterfaceData(g)));
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<NetworkInterface>> GetAsync(string networkInterfaceName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<NetworkInterface, Azure.ResourceManager.Network.Models.NetworkInterface>(
                await Operations.GetAsync(Id.ResourceGroupName, networkInterfaceName, null, cancellationToken),
                    g => new NetworkInterface(Parent, new NetworkInterfaceData(g)));
        }
    }
}
