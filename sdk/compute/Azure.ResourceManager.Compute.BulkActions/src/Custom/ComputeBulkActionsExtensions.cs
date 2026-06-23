// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Compute.BulkActions.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute.BulkActions
{
    public static partial class ComputeBulkActionsExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static async Task<AzureLocation> GetResourceGroupLocationAsync(ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = await resourceGroupResource.GetAsync().ConfigureAwait(false);
            }
            return resourceGroupResource.Data.Location;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AzureLocation GetResourceGroupLocation(ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = resourceGroupResource.Get();
            }
            return resourceGroupResource.Data.Location;
        }

        /// <inheritdoc cref="BulkDeallocateOperationAsync(ResourceGroupResource, AzureLocation, ExecuteDeallocateContent, CancellationToken)"/>
        public static async Task<Response<DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
            => await BulkDeallocateOperationAsync(resourceGroupResource, await GetResourceGroupLocationAsync(resourceGroupResource).ConfigureAwait(false), content, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc cref="BulkDeallocateOperation(ResourceGroupResource, AzureLocation, ExecuteDeallocateContent, CancellationToken)" />
        public static Response<DeallocateResourceOperationResult> BulkDeallocateOperation(this ResourceGroupResource resourceGroupResource, ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
            => BulkDeallocateOperation(resourceGroupResource, GetResourceGroupLocation(resourceGroupResource), content, cancellationToken);

        /// <inheritdoc cref="BulkHibernateOperationAsync(ResourceGroupResource, AzureLocation, ExecuteHibernateContent, CancellationToken)" />
        public static async Task<Response<HibernateResourceOperationResult>> BulkHibernateOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
            => await BulkHibernateOperationAsync(resourceGroupResource, await GetResourceGroupLocationAsync(resourceGroupResource).ConfigureAwait(false), content, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc cref="BulkHibernateOperation(ResourceGroupResource, AzureLocation, ExecuteHibernateContent, CancellationToken)" />
        public static Response<HibernateResourceOperationResult> BulkHibernateOperation(this ResourceGroupResource resourceGroupResource, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
            => BulkHibernateOperation(resourceGroupResource, GetResourceGroupLocation(resourceGroupResource), content, cancellationToken);

        /// <inheritdoc cref="BulkStartOperationAsync(ResourceGroupResource, AzureLocation, ExecuteStartContent, CancellationToken)" />
        public static async Task<Response<StartResourceOperationResult>> BulkStartOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteStartContent content, CancellationToken cancellationToken = default)
            => await BulkStartOperationAsync(resourceGroupResource, await GetResourceGroupLocationAsync(resourceGroupResource).ConfigureAwait(false), content, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc cref="BulkStartOperation(ResourceGroupResource, AzureLocation, ExecuteStartContent, CancellationToken)" />
        public static Response<StartResourceOperationResult> BulkStartOperation(this ResourceGroupResource resourceGroupResource, ExecuteStartContent content, CancellationToken cancellationToken = default)
            => BulkStartOperation(resourceGroupResource, GetResourceGroupLocation(resourceGroupResource), content, cancellationToken);

        /// <inheritdoc cref="BulkDeleteOperationAsync(ResourceGroupResource, AzureLocation, ExecuteDeleteContent, CancellationToken)" />
        public static async Task<Response<DeleteResourceOperationResult>> BulkDeleteOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteDeleteContent content, CancellationToken cancellationToken = default)
            => await BulkDeleteOperationAsync(resourceGroupResource, await GetResourceGroupLocationAsync(resourceGroupResource).ConfigureAwait(false), content, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc cref="BulkDeleteOperation(ResourceGroupResource, AzureLocation, ExecuteDeleteContent, CancellationToken)" />
        public static Response<DeleteResourceOperationResult> BulkDeleteOperation(this ResourceGroupResource resourceGroupResource, ExecuteDeleteContent content, CancellationToken cancellationToken = default)
            => BulkDeleteOperation(resourceGroupResource, GetResourceGroupLocation(resourceGroupResource), content, cancellationToken);

        /// <inheritdoc cref="BulkGetOperationsStatusAsync(ResourceGroupResource, AzureLocation, GetBulkOperationStatusContent, CancellationToken)" />
        public static async Task<Response<GetBulkOperationStatusResult>> BulkGetOperationsStatusAsync(this ResourceGroupResource resourceGroupResource, GetBulkOperationStatusContent content, CancellationToken cancellationToken = default)
            => await BulkGetOperationsStatusAsync(resourceGroupResource, await GetResourceGroupLocationAsync(resourceGroupResource).ConfigureAwait(false), content, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc cref="BulkGetOperationsStatus(ResourceGroupResource, AzureLocation, GetBulkOperationStatusContent, CancellationToken)" />
        public static Response<GetBulkOperationStatusResult> BulkGetOperationsStatus(this ResourceGroupResource resourceGroupResource, GetBulkOperationStatusContent content, CancellationToken cancellationToken = default)
            => BulkGetOperationsStatus(resourceGroupResource, GetResourceGroupLocation(resourceGroupResource), content, cancellationToken);

        /// <inheritdoc cref="BulkCancelOperationsAsync(ResourceGroupResource, AzureLocation, CancelBulkOperationsContent, CancellationToken)" />
        public static async Task<Response<CancelBulkOperationsResult>> BulkCancelOperationsAsync(this ResourceGroupResource resourceGroupResource, CancelBulkOperationsContent content, CancellationToken cancellationToken = default)
            => await BulkCancelOperationsAsync(resourceGroupResource, await GetResourceGroupLocationAsync(resourceGroupResource).ConfigureAwait(false), content, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc cref="BulkCancelOperations(ResourceGroupResource, AzureLocation, CancelBulkOperationsContent, CancellationToken)" />
        public static Response<CancelBulkOperationsResult> BulkCancelOperations(this ResourceGroupResource resourceGroupResource, CancelBulkOperationsContent content, CancellationToken cancellationToken = default)
            => BulkCancelOperations(resourceGroupResource, GetResourceGroupLocation(resourceGroupResource), content, cancellationToken);
    }
}
