// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.ResourceManager.Core;
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

        /// <summary>
        /// The operation to create or update a public IP address. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the public IP address. </param>
        /// <param name="resourceDetails"> The desired public IP address configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="Response{PublicIpAddress}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Name of the public IP address cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public Response<PublicIpAddress> CreateOrUpdate(string name, PublicIPAddressData resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
            return Response.FromValue(new PublicIpAddress(Parent, new PublicIPAddressData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// The operation to create or update a public IP address. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the public IP address. </param>
        /// <param name="resourceDetails"> The desired public IP address configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="Response{PublicIpAddress}"/> operation for this public IP address. </returns>
        /// <exception cref="ArgumentException"> Name of the public IP address cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public async Task<Response<PublicIpAddress>> CreateOrUpdateAsync(string name, PublicIPAddressData resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult().WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new PublicIpAddress(Parent, new PublicIPAddressData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// The operation to create or update a public IP address. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the public IP address. </param>
        /// <param name="resourceDetails"> The desired public IP address configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An <see cref="Operation{PublicIpAddress}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name of the public IP address cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public Operation<PublicIpAddress> StartCreateOrUpdate(string name, PublicIPAddressData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<PublicIpAddress, PublicIPAddress>(
                Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails, cancellationToken),
                n => new PublicIpAddress(Parent, new PublicIPAddressData(n)));
        }

        /// <summary>
        /// The operation to create or update a public IP address. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the public IP address. </param>
        /// <param name="resourceDetails"> The desired public IP address configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="Operation{PublicIpAddress}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name of the public IP address cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public async Task<Operation<PublicIpAddress>> StartCreateOrUpdateAsync(string name, PublicIPAddressData resourceDetails, CancellationToken cancellationToken = default)
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
        public PublicIpAddressBuilder Construct(LocationData location = null)
        {
            var parent = GetParentResource<ResourceGroup, ResourceGroupResourceIdentifier, ResourceGroupOperations>();
            var ipAddress = new PublicIPAddress()
            {
                PublicIPAddressVersion = IPVersion.IPv4.ToString(),
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                Location = location ?? parent.Data.Location,
            };

            return new PublicIpAddressBuilder(this, new PublicIPAddressData(ipAddress));
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

        private Func<PublicIPAddress, PublicIpAddress> Convertor()
        {
            return s => new PublicIpAddress(Parent, new PublicIPAddressData(s));
        }
                /// <inheritdoc />
        public override Response<PublicIpAddress> Get(string publicIpAddressesName, CancellationToken cancellationToken = default)
        {
            var response = Operations.Get(Id.ResourceGroupName, publicIpAddressesName, cancellationToken: cancellationToken);
            return Response.FromValue(new PublicIpAddress(Parent, new PublicIPAddressData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public override async Task<Response<PublicIpAddress>> GetAsync(string publicIpAddressesName, CancellationToken cancellationToken = default)
        {
            var response = await Operations.GetAsync(Id.ResourceGroupName, publicIpAddressesName, cancellationToken: cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new PublicIpAddress(Parent, new PublicIPAddressData(response.Value)), response.GetRawResponse());
        }
    }
}
