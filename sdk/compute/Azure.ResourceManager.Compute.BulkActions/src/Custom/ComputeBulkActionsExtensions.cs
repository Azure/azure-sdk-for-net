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
        /// <summary>
        /// BulkDeallocate: Execute deallocate operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The <paramref name="location"/> argument is intentionally not part of the intended API usage: the location is
        /// extracted from the resource group, so this overload simply forwards to the public overload that derives the
        /// location from the resource group. See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. This value is ignored; the location is extracted from the resource group. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The deallocate operation result response. </returns>
        internal static Task<Response<DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkDeallocateOperationAsync(content, cancellationToken);

        /// <summary>
        /// BulkDeallocate: Execute deallocate operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The location is automatically extracted from the resource group before the operation is invoked.
        /// See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The deallocate operation result response. </returns>
        public static Task<Response<DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkDeallocateOperationAsync(content, cancellationToken);

        /// <summary>
        /// BulkDeallocate: Execute deallocate operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The <paramref name="location"/> argument is intentionally not part of the intended API usage: the location is
        /// extracted from the resource group, so this overload simply forwards to the public overload that derives the
        /// location from the resource group. See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. This value is ignored; the location is extracted from the resource group. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The deallocate operation result response. </returns>
        internal static Response<DeallocateResourceOperationResult> BulkDeallocateOperation(this ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkDeallocateOperation(content, cancellationToken);

        /// <summary>
        /// BulkDeallocate: Execute deallocate operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The location is automatically extracted from the resource group before the operation is invoked.
        /// See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The deallocate operation result response. </returns>
        public static Response<DeallocateResourceOperationResult> BulkDeallocateOperation(this ResourceGroupResource resourceGroupResource, ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkDeallocateOperation(content, cancellationToken);

        /// <summary>
        /// BulkHibernate: Execute hibernate operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The <paramref name="location"/> argument is intentionally not part of the intended API usage: the location is
        /// extracted from the resource group, so this overload simply forwards to the public overload that derives the
        /// location from the resource group. See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. This value is ignored; the location is extracted from the resource group. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The hibernate operation result response. </returns>
        internal static Task<Response<HibernateResourceOperationResult>> BulkHibernateOperationAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkHibernateOperationAsync(content, cancellationToken);

        /// <summary>
        /// BulkHibernate: Execute hibernate operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The location is automatically extracted from the resource group before the operation is invoked.
        /// See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The hibernate operation result response. </returns>
        public static Task<Response<HibernateResourceOperationResult>> BulkHibernateOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkHibernateOperationAsync(content, cancellationToken);

        /// <summary>
        /// BulkHibernate: Execute hibernate operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The <paramref name="location"/> argument is intentionally not part of the intended API usage: the location is
        /// extracted from the resource group, so this overload simply forwards to the public overload that derives the
        /// location from the resource group. See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. This value is ignored; the location is extracted from the resource group. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The hibernate operation result response. </returns>
        internal static Response<HibernateResourceOperationResult> BulkHibernateOperation(this ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkHibernateOperation(content, cancellationToken);

        /// <summary>
        /// BulkHibernate: Execute hibernate operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The location is automatically extracted from the resource group before the operation is invoked.
        /// See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The hibernate operation result response. </returns>
        public static Response<HibernateResourceOperationResult> BulkHibernateOperation(this ResourceGroupResource resourceGroupResource, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkHibernateOperation(content, cancellationToken);

        /// <summary>
        /// BulkStart: Execute start operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The <paramref name="location"/> argument is intentionally not part of the intended API usage: the location is
        /// extracted from the resource group, so this overload simply forwards to the public overload that derives the
        /// location from the resource group. See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. This value is ignored; the location is extracted from the resource group. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The start operation result response. </returns>
        internal static Task<Response<StartResourceOperationResult>> BulkStartOperationAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteStartContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkStartOperationAsync(content, cancellationToken);

        /// <summary>
        /// BulkStart: Execute start operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The location is automatically extracted from the resource group before the operation is invoked.
        /// See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The start operation result response. </returns>
        public static Task<Response<StartResourceOperationResult>> BulkStartOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteStartContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkStartOperationAsync(content, cancellationToken);

        /// <summary>
        /// BulkStart: Execute start operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The <paramref name="location"/> argument is intentionally not part of the intended API usage: the location is
        /// extracted from the resource group, so this overload simply forwards to the public overload that derives the
        /// location from the resource group. See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. This value is ignored; the location is extracted from the resource group. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The start operation result response. </returns>
        internal static Response<StartResourceOperationResult> BulkStartOperation(this ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteStartContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkStartOperation(content, cancellationToken);

        /// <summary>
        /// BulkStart: Execute start operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The location is automatically extracted from the resource group before the operation is invoked.
        /// See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The start operation result response. </returns>
        public static Response<StartResourceOperationResult> BulkStartOperation(this ResourceGroupResource resourceGroupResource, ExecuteStartContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkStartOperation(content, cancellationToken);

        /// <summary>
        /// BulkDelete: Execute delete operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The <paramref name="location"/> argument is intentionally not part of the intended API usage: the location is
        /// extracted from the resource group, so this overload simply forwards to the public overload that derives the
        /// location from the resource group. See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. This value is ignored; the location is extracted from the resource group. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation result response. </returns>
        internal static Task<Response<DeleteResourceOperationResult>> BulkDeleteOperationAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteDeleteContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkDeleteOperationAsync(content, cancellationToken);

        /// <summary>
        /// BulkDelete: Execute delete operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The location is automatically extracted from the resource group before the operation is invoked.
        /// See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation result response. </returns>
        public static Task<Response<DeleteResourceOperationResult>> BulkDeleteOperationAsync(this ResourceGroupResource resourceGroupResource, ExecuteDeleteContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkDeleteOperationAsync(content, cancellationToken);

        /// <summary>
        /// BulkDelete: Execute delete operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The <paramref name="location"/> argument is intentionally not part of the intended API usage: the location is
        /// extracted from the resource group, so this overload simply forwards to the public overload that derives the
        /// location from the resource group. See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. This value is ignored; the location is extracted from the resource group. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation result response. </returns>
        internal static Response<DeleteResourceOperationResult> BulkDeleteOperation(this ResourceGroupResource resourceGroupResource, AzureLocation location, ExecuteDeleteContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkDeleteOperation(content, cancellationToken);

        /// <summary>
        /// BulkDelete: Execute delete operation for a batch of virtual machines.
        /// </summary>
        /// <remarks>
        /// The location is automatically extracted from the resource group before the operation is invoked.
        /// See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation result response. </returns>
        public static Response<DeleteResourceOperationResult> BulkDeleteOperation(this ResourceGroupResource resourceGroupResource, ExecuteDeleteContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkDeleteOperation(content, cancellationToken);

        /// <summary>
        /// BulkGetOperationsStatus: Polling endpoint to read status of operations performed on virtual machines.
        /// </summary>
        /// <remarks>
        /// The <paramref name="location"/> argument is intentionally not part of the intended API usage: the location is
        /// extracted from the resource group, so this overload simply forwards to the public overload that derives the
        /// location from the resource group. See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. This value is ignored; the location is extracted from the resource group. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The status operation result response. </returns>
        internal static Task<Response<GetBulkOperationStatusResult>> BulkGetOperationsStatusAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, GetBulkOperationStatusContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkGetOperationsStatusAsync(content, cancellationToken);

        /// <summary>
        /// BulkGetOperationsStatus: Polling endpoint to read status of operations performed on virtual machines.
        /// </summary>
        /// <remarks>
        /// The location is automatically extracted from the resource group before the operation is invoked.
        /// See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The status operation result response. </returns>
        public static Task<Response<GetBulkOperationStatusResult>> BulkGetOperationsStatusAsync(this ResourceGroupResource resourceGroupResource, GetBulkOperationStatusContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkGetOperationsStatusAsync(content, cancellationToken);

        /// <summary>
        /// BulkGetOperationsStatus: Polling endpoint to read status of operations performed on virtual machines.
        /// </summary>
        /// <remarks>
        /// The <paramref name="location"/> argument is intentionally not part of the intended API usage: the location is
        /// extracted from the resource group, so this overload simply forwards to the public overload that derives the
        /// location from the resource group. See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. This value is ignored; the location is extracted from the resource group. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The status operation result response. </returns>
        internal static Response<GetBulkOperationStatusResult> BulkGetOperationsStatus(this ResourceGroupResource resourceGroupResource, AzureLocation location, GetBulkOperationStatusContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkGetOperationsStatus(content, cancellationToken);

        /// <summary>
        /// BulkGetOperationsStatus: Polling endpoint to read status of operations performed on virtual machines.
        /// </summary>
        /// <remarks>
        /// The location is automatically extracted from the resource group before the operation is invoked.
        /// See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The status operation result response. </returns>
        public static Response<GetBulkOperationStatusResult> BulkGetOperationsStatus(this ResourceGroupResource resourceGroupResource, GetBulkOperationStatusContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkGetOperationsStatus(content, cancellationToken);

        /// <summary>
        /// BulkCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request.
        /// </summary>
        /// <remarks>
        /// The <paramref name="location"/> argument is intentionally not part of the intended API usage: the location is
        /// extracted from the resource group, so this overload simply forwards to the public overload that derives the
        /// location from the resource group. See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. This value is ignored; the location is extracted from the resource group. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The cancel operation result response. </returns>
        internal static Task<Response<CancelBulkOperationsResult>> BulkCancelOperationsAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancelBulkOperationsContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkCancelOperationsAsync(content, cancellationToken);

        /// <summary>
        /// BulkCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request.
        /// </summary>
        /// <remarks>
        /// The location is automatically extracted from the resource group before the operation is invoked.
        /// See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The cancel operation result response. </returns>
        public static Task<Response<CancelBulkOperationsResult>> BulkCancelOperationsAsync(this ResourceGroupResource resourceGroupResource, CancelBulkOperationsContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkCancelOperationsAsync(content, cancellationToken);

        /// <summary>
        /// BulkCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request.
        /// </summary>
        /// <remarks>
        /// The <paramref name="location"/> argument is intentionally not part of the intended API usage: the location is
        /// extracted from the resource group, so this overload simply forwards to the public overload that derives the
        /// location from the resource group. See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. This value is ignored; the location is extracted from the resource group. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The cancel operation result response. </returns>
        internal static Response<CancelBulkOperationsResult> BulkCancelOperations(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancelBulkOperationsContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkCancelOperations(content, cancellationToken);

        /// <summary>
        /// BulkCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request.
        /// </summary>
        /// <remarks>
        /// The location is automatically extracted from the resource group before the operation is invoked.
        /// See <see cref="Mocking.MockableComputeBulkActionsResourceGroupResource"/> for details.
        /// </remarks>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The cancel operation result response. </returns>
        public static Response<CancelBulkOperationsResult> BulkCancelOperations(this ResourceGroupResource resourceGroupResource, CancelBulkOperationsContent content, CancellationToken cancellationToken = default)
            => GetMockableComputeBulkActionsResourceGroupResource(resourceGroupResource).BulkCancelOperations(content, cancellationToken);
    }
}
