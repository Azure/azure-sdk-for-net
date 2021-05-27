﻿using Azure;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing collection of availability set and their operations over a resource group.
    /// </summary>
    public class AvailabilitySetContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, AvailabilitySet, AvailabilitySetData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailabilitySetContainer"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The parent resource group. </param>
        internal AvailabilitySetContainer(ResourceGroupOperations resourceGroup)
            : base(resourceGroup)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        /// <summary>
        /// Typed Resource Identifier for the container.
        /// </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary>
        /// The operation to create or update an availability set. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name">The name of the availability set.</param>
        /// <param name="resourceDetails">The desired availability set configuration.</param>
        /// <param name="cancellationToken">A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />.</param>
        /// <returns>A response with the <see cref="Response{AvailabilitySet}"/> operation for this resource.</returns>
        /// <exception cref="ArgumentException"> Name of the availability set cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public Response<AvailabilitySet> CreateOrUpdate(string name, AvailabilitySetData resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = Operations.CreateOrUpdate(Id.ResourceGroupName, name, resourceDetails.Model);
            return Response.FromValue(new AvailabilitySet(Parent, new AvailabilitySetData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// The operation to create or update an availability set. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the availability set. </param>
        /// <param name="resourceDetails"> The desired availability set configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="Response{AvailabilitySet}"/> operation for this resource group. </returns>
        /// <exception cref="ArgumentException"> Name of the availability set cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public async Task<Response<AvailabilitySet>> CreateOrUpdateAsync(string name, AvailabilitySetData resourceDetails, CancellationToken cancellationToken = default)
        {
            var containerId = Id as ResourceGroupResourceIdentifier;
            var response = await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new AvailabilitySet(Parent, new AvailabilitySetData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// The operation to create or update an availability set. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the availability set. </param>
        /// <param name="resourceDetails"> The desired availability set configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An <see cref="Operation{AvailabilitySet}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name of the availability set cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public Operation<AvailabilitySet> StartCreateOrUpdate(string name, AvailabilitySetData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(
                Operations.CreateOrUpdate(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken),
                a => new AvailabilitySet(Parent, new AvailabilitySetData(a)));
        }

        /// <summary>
        /// The operation to create or update an availability set. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the availability set. </param>
        /// <param name="resourceDetails"> The desired availability set configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="Operation{AvailabilitySet}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name of the availability set cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public async Task<Operation<AvailabilitySet>> StartCreateOrUpdateAsync(string name, AvailabilitySetData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(
                await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false),
                a => new AvailabilitySet(Parent, new AvailabilitySetData(a)));
        }

        /// <summary>
        /// Constructs an object used to create an availability set.
        /// </summary>
        /// <param name="skuName"> The sku name of the resource. </param>
        /// <param name="location"> The location of the resource. </param>
        /// <returns> A builder with <see cref="AvailabilitySet"/> and <see cref="AvailabilitySetData"/>. </returns>
        public AvailabilitySetBuilder Construct(string skuName, LocationData location = null)
        {
            var parent = GetParentResource<ResourceGroup, ResourceGroupResourceIdentifier, ResourceGroupOperations>();
            var availabilitySet = new Azure.ResourceManager.Compute.Models.AvailabilitySet(location ?? parent.Data.Location)
            {
                PlatformUpdateDomainCount = 5,
                PlatformFaultDomainCount = 2,
                Sku = new Azure.ResourceManager.Compute.Models.Sku() { Name = skuName }
            };

            return new AvailabilitySetBuilder(this, new AvailabilitySetData(availabilitySet));
        }

        /// <summary>
        /// Filters the list of availability set for this resource group represented as generic resources.
        /// </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(AvailabilitySetData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of availability set for this resource group represented as generic resources.
        /// </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(AvailabilitySetData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        private AvailabilitySetsOperations Operations => new ComputeManagementClient(
            BaseUri,
            Id.SubscriptionId,
            Credential,
            ClientOptions.Convert<ComputeManagementClientOptions>()).AvailabilitySets;


        /// <inheritdoc />
        public override Response<AvailabilitySet> Get(string availabilitySetName, CancellationToken cancellationToken = default)
        {
            var response = Operations.Get(Id.ResourceGroupName, availabilitySetName);
            return Response.FromValue(new AvailabilitySet(Parent, new AvailabilitySetData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public override async Task<Response<AvailabilitySet>> GetAsync(string availabilitySetName, CancellationToken cancellationToken = default)
        {
            var response = await Operations.GetAsync(Id.ResourceGroupName, availabilitySetName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new AvailabilitySet(Parent, new AvailabilitySetData(response.Value)), response.GetRawResponse());
        }
    }
}
