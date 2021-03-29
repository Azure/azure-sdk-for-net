using Azure;
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

        /// <inheritdoc/>
        public override ArmResponse<AvailabilitySet> CreateOrUpdate(string name, AvailabilitySetData resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = Operations.CreateOrUpdate(Id.ResourceGroupName, name, resourceDetails.Model);
            return new PhArmResponse<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(
                response,
                a => new AvailabilitySet(Parent, new AvailabilitySetData(a)));
        }

        /// <inheritdoc/>
        public async override Task<ArmResponse<AvailabilitySet>> CreateOrUpdateAsync(string name, AvailabilitySetData resourceDetails, CancellationToken cancellationToken = default)
        {
            var containerId = Id as ResourceGroupResourceIdentifier;
            var response = await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(
                response,
                a => new AvailabilitySet(Parent, new AvailabilitySetData(a)));
        }

        /// <inheritdoc/>
        public override ArmOperation<AvailabilitySet> StartCreateOrUpdate(string name, AvailabilitySetData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(
                Operations.CreateOrUpdate(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken),
                a => new AvailabilitySet(Parent, new AvailabilitySetData(a)));
        }

        /// <inheritdoc/>
        public async override Task<ArmOperation<AvailabilitySet>> StartCreateOrUpdateAsync(string name, AvailabilitySetData resourceDetails, CancellationToken cancellationToken = default)
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
        public ArmBuilder<ResourceGroupResourceIdentifier, AvailabilitySet, AvailabilitySetData> Construct(string skuName, LocationData location = null)
        {
            var parent = GetParentResource<ResourceGroup, ResourceGroupResourceIdentifier, ResourceGroupOperations>();
            var availabilitySet = new Azure.ResourceManager.Compute.Models.AvailabilitySet(location ?? parent.Data.Location)
            {
                PlatformUpdateDomainCount = 5,
                PlatformFaultDomainCount = 2,
                Sku = new Azure.ResourceManager.Compute.Models.Sku() { Name = skuName }
            };

            return new ArmBuilder<ResourceGroupResourceIdentifier, AvailabilitySet, AvailabilitySetData>(this, new AvailabilitySetData(availabilitySet));
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

        /// <summary>
        /// Filters the list of availability set for this resource group.
        /// Makes an additional network call to retrieve the full data model for each resource group.
        /// </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of availability set that may take multiple service requests to iterate over. </returns>
        public Pageable<AvailabilitySet> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, AvailabilitySet>(results, s => new AvailabilitySetOperations(s).Get().Value);
        }

        /// <summary>
        /// Filters the list of availability set for this resource group.
        /// Makes an additional network call to retrieve the full data model for each resource group.
        /// </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An asyc collection of availability set that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<AvailabilitySet> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, AvailabilitySet>(results, s => new AvailabilitySetOperations(s).Get().Value);
        }

        private AvailabilitySetsOperations Operations => new ComputeManagementClient(
            BaseUri,
            Id.SubscriptionId,
            Credential,
            ClientOptions.Convert<ComputeManagementClientOptions>()).AvailabilitySets;


        /// <inheritdoc />
        public override ArmResponse<AvailabilitySet> Get(string availabilitySetName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(Operations.Get(Id.ResourceGroupName, availabilitySetName),
                g => new AvailabilitySet(Parent, new AvailabilitySetData(g)));
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<AvailabilitySet>> GetAsync(string availabilitySetName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(await Operations.GetAsync(Id.ResourceGroupName, availabilitySetName, cancellationToken),
                g => new AvailabilitySet(Parent, new AvailabilitySetData(g)));
        }
    }
}
