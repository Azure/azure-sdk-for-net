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
    /// A class representing collection of PublicIpAddress and their operations over a resource group.
    /// </summary>
    public class PublicIpAddressContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, PublicIpAddress, PublicIPAddressData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublicIpAddressContainer"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The client parameters to use in these operations. </param>
        internal PublicIpAddressContainer(ResourceGroupOperations resourceGroup)
            : base(resourceGroup)
        {
        }

        /// <summary>
        /// Typed Resource Identifier for the container.
        /// </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary>
        /// Gets the valid resource type for this resource.
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        private PublicIPAddressesOperations Operations => new NetworkManagementClient(
            Id.SubscriptionId,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).PublicIPAddresses;

        /// <inheritdoc />
        public override ArmResponse<PublicIpAddress> CreateOrUpdate(string name, PublicIPAddressData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails, cancellationToken);
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(
                operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult(),
                n => new PublicIpAddress(Parent, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public override async Task<ArmResponse<PublicIpAddress>> CreateOrUpdateAsync(string name, PublicIPAddressData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails, cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(
                await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                n => new PublicIpAddress(Parent, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public override ArmOperation<PublicIpAddress> StartCreateOrUpdate(string name, PublicIPAddressData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(
                Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails, cancellationToken),
                n => new PublicIpAddress(Parent, new PublicIPAddressData(n)));
        }

        /// <inheritdoc />
        public override async Task<ArmOperation<PublicIpAddress>> StartCreateOrUpdateAsync(string name, PublicIPAddressData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(
                await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails, cancellationToken).ConfigureAwait(false),
                n => new PublicIpAddress(Parent, new PublicIPAddressData(n)));
        }

        /// <summary>
        /// Construct an object used to create a public IP address.
        /// </summary>
        /// <param name="location"> The location to create the network security group. </param>
        /// <returns> Object used to create a <see cref="PublicIpAddress"/>. </returns>
        public ArmBuilder<ResourceGroupResourceIdentifier, PublicIpAddress, PublicIPAddressData> Construct(LocationData location = null)
        {
            var parent = GetParentResource<ResourceGroup, ResourceGroupResourceIdentifier, ResourceGroupOperations>();
            var ipAddress = new PublicIPAddress()
            {
                PublicIPAddressVersion = IPVersion.IPv4.ToString(),
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                Location = location ?? parent.Data.Location,
            };

            return new ArmBuilder<ResourceGroupResourceIdentifier, PublicIpAddress, PublicIPAddressData>(this, new PublicIPAddressData(ipAddress));
        }

        /// <summary>
        /// List the public IP addresses for this resource group.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="PublicIPAddress"/> that may take multiple service requests to iterate over. </returns>
        public Pageable<PublicIpAddress> List(CancellationToken cancellationToken = default)
        {
            return new PhWrappingPageable<PublicIPAddress, PublicIpAddress>(
                Operations.List(Id.Name, cancellationToken),
                Convertor());
        }

        /// <summary>
        /// List the public IP addresses for this resource group.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="PublicIpAddress"/> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<PublicIpAddress> ListAsync(CancellationToken cancellationToken = default)
        {
            return new PhWrappingAsyncPageable<PublicIPAddress, PublicIpAddress>(
                Operations.ListAsync(Id.Name, cancellationToken),
                Convertor());
        }

        /// <summary>
        /// Filters the list of public IP addresses for this resource group represented as generic resources.
        /// </summary>
        /// <param name="nameFilter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="GenericResource"/> that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(PublicIPAddressData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of public IP addresses for this resource group represented as generic resources.
        /// </summary>
        /// <param name="nameFilter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="GenericResource"/> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(PublicIPAddressData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of public IP addresses for this resource group represented as generic resources.
        /// Makes an additional network call to retrieve the full data model for each network security group.
        /// </summary>
        /// <param name="nameFilter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="PublicIpAddress"/> that may take multiple service requests to iterate over. </returns>
        public Pageable<PublicIpAddress> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, PublicIpAddress>(results, s => new PublicIpAddressOperations(s).Get().Value);
        }

        /// <summary>
        /// Filters the list of public IP addresses for this resource group represented as generic resources.
        /// Makes an additional network call to retrieve the full data model for each network security group.
        /// </summary>
        /// <param name="nameFilter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="PublicIpAddress"/> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<PublicIpAddress> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, PublicIpAddress>(results, s => new PublicIpAddressOperations(s).Get().Value);
        }

        private Func<PublicIPAddress, PublicIpAddress> Convertor()
        {
            return s => new PublicIpAddress(Parent, new PublicIPAddressData(s));
        }
                /// <inheritdoc />
        public override ArmResponse<PublicIpAddress> Get(string publicIpAddressesName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(Operations.Get(Id.ResourceGroupName, publicIpAddressesName, cancellationToken: cancellationToken), Convertor());
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<PublicIpAddress>> GetAsync(string publicIpAddressesName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<PublicIpAddress, PublicIPAddress>(await Operations.GetAsync(Id.ResourceGroupName, publicIpAddressesName, cancellationToken: cancellationToken), Convertor());
        }     
    }
}
