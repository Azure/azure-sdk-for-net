// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        static partial Task<Response<DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteDeallocateContent content, CancellationToken cancellationToken);

        /// <inheritdoc cref="BulkDeallocateOperationAsync(ResourceGroupResource, AzureLocation, ExecuteDeallocateContent, CancellationToken)"/>
        public static async Task<Response<DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
        {
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = await resourceGroupResource.GetAsync();
            }
            return await BulkDeallocateOperationAsync(resourceGroupResource, resourceGroupResource.Data.Location, content, cancellationToken).ConfigureAwait(false);
        }

        static partial Response<DeallocateResourceOperationResult> BulkDeallocateOperation(ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteDeallocateContent content, CancellationToken cancellationToken);

        /// <inheritdoc cref="BulkDeallocateOperation(ResourceGroupResource, AzureLocation, ExecuteDeallocateContent, CancellationToken)" />
        public static Response<DeallocateResourceOperationResult> BulkDeallocateOperation(this ResourceGroupResource resourceGroupResource, ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
        {
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = resourceGroupResource.Get();
            }
            return BulkDeallocateOperation(resourceGroupResource, resourceGroupResource.Data.Location, content, cancellationToken);
        }

        static partial Task<Response<HibernateResourceOperationResult>> BulkHibernateOperationAsync(ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteHibernateContent content, CancellationToken cancellationToken);

        /// <inheritdoc cref="BulkHibernateOperationAsync(ResourceGroupResource, AzureLocation, ExecuteHibernateContent, CancellationToken)" />
        public static async Task<Response<HibernateResourceOperationResult>> BulkHibernateOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
        {
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = await resourceGroupResource.GetAsync();
            }
            return await BulkHibernateOperationAsync(resourceGroupResource, resourceGroupResource.Data.Location, content, cancellationToken).ConfigureAwait(false);
        }

        static partial Response<HibernateResourceOperationResult> BulkHibernateOperation(ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteHibernateContent content, CancellationToken cancellationToken);

        /// <inheritdoc cref="BulkHibernateOperation(ResourceGroupResource, AzureLocation, ExecuteHibernateContent, CancellationToken)" />
        public static Response<HibernateResourceOperationResult> BulkHibernateOperation(this ResourceGroupResource resourceGroupResource, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
        {
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = resourceGroupResource.Get();
            }
            return BulkHibernateOperation(resourceGroupResource, resourceGroupResource.Data.Location, content, cancellationToken);
        }

        static partial Task<Response<StartResourceOperationResult>> BulkStartOperationAsync(ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteStartContent content, CancellationToken cancellationToken);

        /// <inheritdoc cref="BulkStartOperationAsync(ResourceGroupResource, AzureLocation, ExecuteStartContent, CancellationToken)" />
        public static async Task<Response<StartResourceOperationResult>> BulkStartOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteStartContent content, CancellationToken cancellationToken = default)
        {
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = await resourceGroupResource.GetAsync();
            }
            return await BulkStartOperationAsync(resourceGroupResource, resourceGroupResource.Data.Location, content, cancellationToken).ConfigureAwait(false);
        }

        static partial Response<StartResourceOperationResult> BulkStartOperation(ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteStartContent content, CancellationToken cancellationToken);

        /// <inheritdoc cref="BulkStartOperation(ResourceGroupResource, AzureLocation, ExecuteStartContent, CancellationToken)" />
        public static Response<StartResourceOperationResult> BulkStartOperation(this ResourceGroupResource resourceGroupResource, ExecuteStartContent content, CancellationToken cancellationToken = default)
        {
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = resourceGroupResource.Get();
            }
            return BulkStartOperation(resourceGroupResource, resourceGroupResource.Data.Location, content, cancellationToken);
        }

        static partial Task<Response<DeleteResourceOperationResult>> BulkDeleteOperationAsync(ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteDeleteContent content, CancellationToken cancellationToken);

        /// <inheritdoc cref="BulkDeleteOperationAsync(ResourceGroupResource, AzureLocation, ExecuteDeleteContent, CancellationToken)" />
        public static async Task<Response<DeleteResourceOperationResult>> BulkDeleteOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteDeleteContent content, CancellationToken cancellationToken = default)
        {
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = await resourceGroupResource.GetAsync();
            }
            return await BulkDeleteOperationAsync(resourceGroupResource, resourceGroupResource.Data.Location, content, cancellationToken).ConfigureAwait(false);
        }

        static partial Response<DeleteResourceOperationResult> BulkDeleteOperation(ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteDeleteContent content, CancellationToken cancellationToken);

        /// <inheritdoc cref="BulkDeleteOperation(ResourceGroupResource, AzureLocation, ExecuteDeleteContent, CancellationToken)" />
        public static Response<DeleteResourceOperationResult> BulkDeleteOperation(this ResourceGroupResource resourceGroupResource, ExecuteDeleteContent content, CancellationToken cancellationToken = default)
        {
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = resourceGroupResource.Get();
            }
            return BulkDeleteOperation(resourceGroupResource, resourceGroupResource.Data.Location, content, cancellationToken);
        }

        static partial Task<Response<GetBulkOperationStatusResult>> BulkGetOperationsStatusAsync(ResourceGroupResource resourceGroupResource, AzureLocation location, GetBulkOperationStatusContent content, CancellationToken cancellationToken);

        /// <inheritdoc cref="BulkGetOperationsStatusAsync(ResourceGroupResource, AzureLocation, GetBulkOperationStatusContent, CancellationToken)" />
        public static async Task<Response<GetBulkOperationStatusResult>> BulkGetOperationsStatusAsync(this ResourceGroupResource resourceGroupResource, GetBulkOperationStatusContent content, CancellationToken cancellationToken = default)
        {
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = await resourceGroupResource.GetAsync();
            }
            return await BulkGetOperationsStatusAsync(resourceGroupResource, resourceGroupResource.Data.Location, content, cancellationToken).ConfigureAwait(false);
        }

        static partial Response<GetBulkOperationStatusResult> BulkGetOperationsStatus(ResourceGroupResource resourceGroupResource, AzureLocation location, GetBulkOperationStatusContent content, CancellationToken cancellationToken);

        /// <inheritdoc cref="BulkGetOperationsStatus(ResourceGroupResource, AzureLocation, GetBulkOperationStatusContent, CancellationToken)" />
        public static Response<GetBulkOperationStatusResult> BulkGetOperationsStatus(this ResourceGroupResource resourceGroupResource, GetBulkOperationStatusContent content, CancellationToken cancellationToken = default)
        {
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = resourceGroupResource.Get();
            }
            return BulkGetOperationsStatus(resourceGroupResource, resourceGroupResource.Data.Location, content, cancellationToken);
        }

        static partial Task<Response<CancelBulkOperationsResult>> BulkCancelOperationsAsync(ResourceGroupResource resourceGroupResource, AzureLocation location, CancelBulkOperationsContent content, CancellationToken cancellationToken);

        /// <inheritdoc cref="BulkCancelOperationsAsync(ResourceGroupResource, AzureLocation, CancelBulkOperationsContent, CancellationToken)" />
        public static async Task<Response<CancelBulkOperationsResult>> BulkCancelOperationsAsync(this ResourceGroupResource resourceGroupResource, CancelBulkOperationsContent content, CancellationToken cancellationToken = default)
        {
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = await resourceGroupResource.GetAsync();
            }
            return await BulkCancelOperationsAsync(resourceGroupResource, resourceGroupResource.Data.Location, content, cancellationToken).ConfigureAwait(false);
        }

        static partial Response<CancelBulkOperationsResult> BulkCancelOperations(ResourceGroupResource resourceGroupResource, AzureLocation location, CancelBulkOperationsContent content, CancellationToken cancellationToken);

        /// <inheritdoc cref="BulkCancelOperations(ResourceGroupResource, AzureLocation, CancelBulkOperationsContent, CancellationToken)" />
        public static Response<CancelBulkOperationsResult> BulkCancelOperations(this ResourceGroupResource resourceGroupResource, CancelBulkOperationsContent content, CancellationToken cancellationToken = default)
        {
            if (!resourceGroupResource.HasData)
            {
                resourceGroupResource = resourceGroupResource.Get();
            }
            return BulkCancelOperations(resourceGroupResource, resourceGroupResource.Data.Location, content, cancellationToken);
        }
    }
}
