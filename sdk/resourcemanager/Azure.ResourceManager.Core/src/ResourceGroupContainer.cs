// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core.Adapters;
using Azure.ResourceManager.Resources;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing collection of ResourceGroupContainer and their operations over a ResourceGroup.
    /// </summary>
    public class ResourceGroupContainer : ResourceContainerBase<ResourceGroup, ResourceGroupData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupContainer"/> class.
        /// </summary>
        /// <param name="subscription"> The parent subscription. </param>
        internal ResourceGroupContainer(SubscriptionOperations subscription)
            : base(subscription)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => SubscriptionOperations.ResourceType;

        private ResourceGroupsOperations Operations => new ResourcesManagementClient(
            BaseUri,
            Id.Subscription,
            Credential,
            ClientOptions.Convert<ResourcesManagementClientOptions>()).ResourceGroups;

        /// <summary>
        /// Constructs an object used to create a resource group.
        /// </summary>
        /// <param name="location"> The location of the resource group. </param>
        /// <param name="tags"> The tags of the resource group. </param>
        /// <param name="managedBy"> Who the resource group is managed by. </param>
        /// <returns> A builder with <see cref="ResourceGroup"/> and <see cref="ResourceGroupData"/>. </returns>
        public ArmBuilder<ResourceGroup, ResourceGroupData> Construct(LocationData location, IDictionary<string, string> tags = default, string managedBy = default)
        {
            var model = new ResourceManager.Resources.Models.ResourceGroup(location);
            if (!(tags is null))
            {
                foreach (var tag in tags)
                {
                    model.Tags.Add(tag);
                }
            }
            model.ManagedBy = managedBy;
            return new ArmBuilder<ResourceGroup, ResourceGroupData>(this, new ResourceGroupData(model));
        }

        /// <inheritdoc/>
        public override ArmResponse<ResourceGroup> CreateOrUpdate(string name, ResourceGroupData resourceDetails)
        {
            var response = Operations.CreateOrUpdate(name, resourceDetails);
            return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                response,
                g => new ResourceGroup(Parent, new ResourceGroupData(g)));
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<ResourceGroup>> CreateOrUpdateAsync(string name, ResourceGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = await Operations.CreateOrUpdateAsync(name, resourceDetails, cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                response,
                g => new ResourceGroup(Parent, new ResourceGroupData(g)));
        }

        /// <inheritdoc/>
        public override ArmOperation<ResourceGroup> StartCreateOrUpdate(string name, ResourceGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                Operations.CreateOrUpdate(name, resourceDetails, cancellationToken),
                g => new ResourceGroup(Parent, new ResourceGroupData(g)));
        }

        /// <inheritdoc/>
        public override async Task<ArmOperation<ResourceGroup>> StartCreateOrUpdateAsync(string name, ResourceGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                await Operations.CreateOrUpdateAsync(name, resourceDetails, cancellationToken).ConfigureAwait(false),
                g => new ResourceGroup(Parent, new ResourceGroupData(g)));
        }

        /// <summary>
        /// List the resource groups for this subscription.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<ResourceGroup> List(CancellationToken cancellationToken = default)
        {
            return new PhWrappingPageable<ResourceManager.Resources.Models.ResourceGroup, ResourceGroup>(
                Operations.List(null, null, cancellationToken),
                s => new ResourceGroup(Parent, new ResourceGroupData(s)));
        }

        /// <summary>
        /// List the resource groups for this subscription.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ResourceGroup> ListAsync(CancellationToken cancellationToken = default)
        {
            return new PhWrappingAsyncPageable<ResourceManager.Resources.Models.ResourceGroup, ResourceGroup>(
                Operations.ListAsync(null, null, cancellationToken),
                s => new ResourceGroup(Parent, new ResourceGroupData(s)));
        }
    }
}
