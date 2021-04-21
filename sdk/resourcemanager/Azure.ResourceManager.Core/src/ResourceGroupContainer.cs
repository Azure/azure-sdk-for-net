// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing collection of ResourceGroupContainer and their operations over a ResourceGroup.
    /// </summary>
    public class ResourceGroupContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, ResourceGroup, ResourceGroupData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupContainer"/> class for mocking.
        /// </summary>
        protected ResourceGroupContainer()
        {
        }

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

        private ResourceGroupsOperations Operations 
        {
            get
            {
                string subscriptionId;
                if (Id is null || !Id.TryGetSubscriptionId(out subscriptionId))
                    subscriptionId = Guid.NewGuid().ToString();
                return new ResourcesManagementClient(
                BaseUri,
                subscriptionId,
                Credential,
                ClientOptions.Convert<ResourcesManagementClientOptions>()).ResourceGroups;
            }
        }

        /// <summary>
        /// Constructs an object used to create a resource group.
        /// </summary>
        /// <param name="location"> The location of the resource group. </param>
        /// <param name="tags"> The tags of the resource group. </param>
        /// <param name="managedBy"> Who the resource group is managed by. </param>
        /// <returns> A builder with <see cref="ResourceGroup"/> and <see cref="ResourceGroupData"/>. </returns>
        /// <exception cref="ArgumentNullException"> Location cannot be null. </exception>
        public ArmBuilder<ResourceGroupResourceIdentifier, ResourceGroup, ResourceGroupData> Construct(LocationData location, IDictionary<string, string> tags = default, string managedBy = default)
        {
            if (location is null)
                throw new ArgumentNullException(nameof(location));

            var model = new ResourceManager.Resources.Models.ResourceGroup(location);
            if (!(tags is null))
                model.Tags.ReplaceWith(tags);
            model.ManagedBy = managedBy;
            return new ArmBuilder<ResourceGroupResourceIdentifier, ResourceGroup, ResourceGroupData>(this, new ResourceGroupData(model));
        }

        /// <inheritdoc/>
        public override ArmResponse<ResourceGroup> CreateOrUpdate(string name, ResourceGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be null or a whitespace.", nameof(name));
            if (resourceDetails is null)
                throw new ArgumentNullException(nameof(resourceDetails));

            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.CreateOrUpdate");
            scope.Start();

            try
            {
                var response = Operations.CreateOrUpdate(name, resourceDetails, cancellationToken);
                return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                    response,
                    g => new ResourceGroup(Parent, new ResourceGroupData(g)));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<ResourceGroup>> CreateOrUpdateAsync(string name, ResourceGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be null or a whitespace.", nameof(name));
            if (resourceDetails is null)
                throw new ArgumentNullException(nameof(resourceDetails));

            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.CreateOrUpdate");
            scope.Start();

            try
            {
                var response = await Operations.CreateOrUpdateAsync(name, resourceDetails, cancellationToken).ConfigureAwait(false);
                return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                    response,
                    g => new ResourceGroup(Parent, new ResourceGroupData(g)));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public override ArmOperation<ResourceGroup> StartCreateOrUpdate(string name, ResourceGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be null or a whitespace.", nameof(name));
            if (resourceDetails is null)
                throw new ArgumentNullException(nameof(resourceDetails));

            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.StartCreateOrUpdate");
            scope.Start();

            try
            {
                return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                Operations.CreateOrUpdate(name, resourceDetails, cancellationToken),
                g => new ResourceGroup(Parent, new ResourceGroupData(g)));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public override async Task<ArmOperation<ResourceGroup>> StartCreateOrUpdateAsync(string name, ResourceGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be null or a whitespace.", nameof(name));
            if (resourceDetails is null)
                throw new ArgumentNullException(nameof(resourceDetails));

            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.StartCreateOrUpdate");
            scope.Start();

            try
            {
                return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                await Operations.CreateOrUpdateAsync(name, resourceDetails, cancellationToken).ConfigureAwait(false),
                g => new ResourceGroup(Parent, new ResourceGroupData(g)));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List the resource groups for this subscription.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual Pageable<ResourceGroup> List(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.List");
            scope.Start();

            try
            {
                var results = Operations.List(null, null, cancellationToken);
                return new PhWrappingPageable<ResourceManager.Resources.Models.ResourceGroup, ResourceGroup>(
                results,
                s => new ResourceGroup(Parent, new ResourceGroupData(s)));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List the resource groups for this subscription.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<ResourceGroup> ListAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.List");
            scope.Start();

            try
            {
                return new PhWrappingAsyncPageable<ResourceManager.Resources.Models.ResourceGroup, ResourceGroup>(
                Operations.ListAsync(null, null, cancellationToken),
                s => new ResourceGroup(Parent, new ResourceGroupData(s)));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public override ArmResponse<ResourceGroup> Get(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.Get");
            scope.Start();

            try
            {
                return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Get(resourceGroupName, cancellationToken), g =>
                {
                    return new ResourceGroup(Parent, new ResourceGroupData(g));
                });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<ResourceGroup>> GetAsync(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.Get");
            scope.Start();

            try
            {
                var result = await Operations.GetAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
                return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                result,
                g =>
                {
                    return new ResourceGroup(Parent, new ResourceGroupData(g));
                });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
