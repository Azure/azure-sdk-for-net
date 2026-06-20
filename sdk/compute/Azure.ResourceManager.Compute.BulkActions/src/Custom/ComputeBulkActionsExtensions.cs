// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Compute.BulkActions.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute.BulkActions
{
    public static partial class ComputeBulkActionsExtensions
    {
        /// <summary>
        /// BulkDeallocate: Execute deallocate operation for a batch of virtual machines.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The deallocate operation result response. </returns>
        public static Task<Response<DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
            => resourceGroupResource.BulkDeallocateOperationAsync(resourceGroupResource.Data.Location, content, cancellationToken);

        /// <summary>
        /// BulkDeallocate: Execute deallocate operation for a batch of virtual machines.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The deallocate operation result response. </returns>
        public static Response<DeallocateResourceOperationResult> BulkDeallocateOperation(this ResourceGroupResource resourceGroupResource, ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
            => resourceGroupResource.BulkDeallocateOperation(resourceGroupResource.Data.Location, content, cancellationToken);

        /// <summary>
        /// BulkHibernate: Execute hibernate operation for a batch of virtual machines.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The hibernate operation result response. </returns>
        public static Task<Response<HibernateResourceOperationResult>> BulkHibernateOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
            => resourceGroupResource.BulkHibernateOperationAsync(resourceGroupResource.Data.Location, content, cancellationToken);

        /// <summary>
        /// BulkHibernate: Execute hibernate operation for a batch of virtual machines.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The hibernate operation result response. </returns>
        public static Response<HibernateResourceOperationResult> BulkHibernateOperation(this ResourceGroupResource resourceGroupResource, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
            => resourceGroupResource.BulkHibernateOperation(resourceGroupResource.Data.Location, content, cancellationToken);

        /// <summary>
        /// BulkStart: Execute start operation for a batch of virtual machines.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The start operation result response. </returns>
        public static Task<Response<StartResourceOperationResult>> BulkStartOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteStartContent content, CancellationToken cancellationToken = default)
            => resourceGroupResource.BulkStartOperationAsync(resourceGroupResource.Data.Location, content, cancellationToken);

        /// <summary>
        /// BulkStart: Execute start operation for a batch of virtual machines.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The start operation result response. </returns>
        public static Response<StartResourceOperationResult> BulkStartOperation(this ResourceGroupResource resourceGroupResource, ExecuteStartContent content, CancellationToken cancellationToken = default)
            => resourceGroupResource.BulkStartOperation(resourceGroupResource.Data.Location, content, cancellationToken);

        /// <summary>
        /// BulkDelete: Execute delete operation for a batch of virtual machines.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation result response. </returns>
        public static Task<Response<DeleteResourceOperationResult>> BulkDeleteOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteDeleteContent content, CancellationToken cancellationToken = default)
            => resourceGroupResource.BulkDeleteOperationAsync(resourceGroupResource.Data.Location, content, cancellationToken);

        /// <summary>
        /// BulkDelete: Execute delete operation for a batch of virtual machines.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation result response. </returns>
        public static Response<DeleteResourceOperationResult> BulkDeleteOperation(this ResourceGroupResource resourceGroupResource, ExecuteDeleteContent content, CancellationToken cancellationToken = default)
            => resourceGroupResource.BulkDeleteOperation(resourceGroupResource.Data.Location, content, cancellationToken);

        /// <summary>
        /// BulkGetOperationsStatus: Polling endpoint to read status of operations performed on virtual machines.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The status operation result response. </returns>
        public static Task<Response<GetBulkOperationStatusResult>> BulkGetOperationsStatusAsync(this ResourceGroupResource resourceGroupResource, GetBulkOperationStatusContent content, CancellationToken cancellationToken = default)
            => resourceGroupResource.BulkGetOperationsStatusAsync(resourceGroupResource.Data.Location, content, cancellationToken);

        /// <summary>
        /// BulkGetOperationsStatus: Polling endpoint to read status of operations performed on virtual machines.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The status operation result response. </returns>
        public static Response<GetBulkOperationStatusResult> BulkGetOperationsStatus(this ResourceGroupResource resourceGroupResource, GetBulkOperationStatusContent content, CancellationToken cancellationToken = default)
            => resourceGroupResource.BulkGetOperationsStatus(resourceGroupResource.Data.Location, content, cancellationToken);

        /// <summary>
        /// BulkCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The cancel operation result response. </returns>
        public static Task<Response<CancelBulkOperationsResult>> BulkCancelOperationsAsync(this ResourceGroupResource resourceGroupResource, CancelBulkOperationsContent content, CancellationToken cancellationToken = default)
            => resourceGroupResource.BulkCancelOperationsAsync(resourceGroupResource.Data.Location, content, cancellationToken);

        /// <summary>
        /// BulkCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The cancel operation result response. </returns>
        public static Response<CancelBulkOperationsResult> BulkCancelOperations(this ResourceGroupResource resourceGroupResource, CancelBulkOperationsContent content, CancellationToken cancellationToken = default)
            => resourceGroupResource.BulkCancelOperations(resourceGroupResource.Data.Location, content, cancellationToken);
    }
}
