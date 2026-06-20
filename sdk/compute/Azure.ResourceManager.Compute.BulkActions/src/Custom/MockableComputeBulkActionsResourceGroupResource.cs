// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Compute.BulkActions.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute.BulkActions.Mocking
{
    public partial class MockableComputeBulkActionsResourceGroupResource
    {
        private SubscriptionResource GetSubscriptionResource()
        {
            var subscriptionId = Id.SubscriptionId;
            var subscriptionResourceId = new ResourceIdentifier($"/subscriptions/{subscriptionId}");
            return Client.GetSubscriptionResource(subscriptionResourceId);
        }

        private async Task<AzureLocation> GetResourceGroupLocationAsync(CancellationToken cancellationToken)
        {
            var response = await GetSubscriptionResource()
                .GetResourceGroups()
                .GetAsync(Id.ResourceGroupName, cancellationToken)
                .ConfigureAwait(false);
            return response.Value.Data.Location;
        }

        private AzureLocation GetResourceGroupLocation(CancellationToken cancellationToken)
        {
            var response = GetSubscriptionResource()
                .GetResourceGroups()
                .Get(Id.ResourceGroupName, cancellationToken);
            return response.Value.Data.Location;
        }

        /// <summary>
        /// BulkDeallocate: Execute deallocate operation for a batch of virtual machines.
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The deallocate operation result response. </returns>
        public virtual async Task<Response<DeallocateResourceOperationResult>> BulkDeallocateOperationAsync(ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
            => await BulkDeallocateOperationAsync(await GetResourceGroupLocationAsync(cancellationToken).ConfigureAwait(false), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// BulkDeallocate: Execute deallocate operation for a batch of virtual machines.
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The deallocate operation result response. </returns>
        public virtual Response<DeallocateResourceOperationResult> BulkDeallocateOperation(ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
            => BulkDeallocateOperation(GetResourceGroupLocation(cancellationToken), content, cancellationToken);

        /// <summary>
        /// BulkHibernate: Execute hibernate operation for a batch of virtual machines.
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The hibernate operation result response. </returns>
        public virtual async Task<Response<HibernateResourceOperationResult>> BulkHibernateOperationAsync(ExecuteHibernateContent content, CancellationToken cancellationToken = default)
            => await BulkHibernateOperationAsync(await GetResourceGroupLocationAsync(cancellationToken).ConfigureAwait(false), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// BulkHibernate: Execute hibernate operation for a batch of virtual machines.
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The hibernate operation result response. </returns>
        public virtual Response<HibernateResourceOperationResult> BulkHibernateOperation(ExecuteHibernateContent content, CancellationToken cancellationToken = default)
            => BulkHibernateOperation(GetResourceGroupLocation(cancellationToken), content, cancellationToken);

        /// <summary>
        /// BulkStart: Execute start operation for a batch of virtual machines.
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The start operation result response. </returns>
        public virtual async Task<Response<StartResourceOperationResult>> BulkStartOperationAsync(ExecuteStartContent content, CancellationToken cancellationToken = default)
            => await BulkStartOperationAsync(await GetResourceGroupLocationAsync(cancellationToken).ConfigureAwait(false), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// BulkStart: Execute start operation for a batch of virtual machines.
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The start operation result response. </returns>
        public virtual Response<StartResourceOperationResult> BulkStartOperation(ExecuteStartContent content, CancellationToken cancellationToken = default)
            => BulkStartOperation(GetResourceGroupLocation(cancellationToken), content, cancellationToken);

        /// <summary>
        /// BulkDelete: Execute delete operation for a batch of virtual machines.
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation result response. </returns>
        public virtual async Task<Response<DeleteResourceOperationResult>> BulkDeleteOperationAsync(ExecuteDeleteContent content, CancellationToken cancellationToken = default)
            => await BulkDeleteOperationAsync(await GetResourceGroupLocationAsync(cancellationToken).ConfigureAwait(false), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// BulkDelete: Execute delete operation for a batch of virtual machines.
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation result response. </returns>
        public virtual Response<DeleteResourceOperationResult> BulkDeleteOperation(ExecuteDeleteContent content, CancellationToken cancellationToken = default)
            => BulkDeleteOperation(GetResourceGroupLocation(cancellationToken), content, cancellationToken);

        /// <summary>
        /// BulkGetOperationsStatus: Polling endpoint to read status of operations performed on virtual machines.
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The status operation result response. </returns>
        public virtual async Task<Response<GetBulkOperationStatusResult>> BulkGetOperationsStatusAsync(GetBulkOperationStatusContent content, CancellationToken cancellationToken = default)
            => await BulkGetOperationsStatusAsync(await GetResourceGroupLocationAsync(cancellationToken).ConfigureAwait(false), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// BulkGetOperationsStatus: Polling endpoint to read status of operations performed on virtual machines.
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The status operation result response. </returns>
        public virtual Response<GetBulkOperationStatusResult> BulkGetOperationsStatus(GetBulkOperationStatusContent content, CancellationToken cancellationToken = default)
            => BulkGetOperationsStatus(GetResourceGroupLocation(cancellationToken), content, cancellationToken);

        /// <summary>
        /// BulkCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request.
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The cancel operation result response. </returns>
        public virtual async Task<Response<CancelBulkOperationsResult>> BulkCancelOperationsAsync(CancelBulkOperationsContent content, CancellationToken cancellationToken = default)
            => await BulkCancelOperationsAsync(await GetResourceGroupLocationAsync(cancellationToken).ConfigureAwait(false), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// BulkCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request.
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The cancel operation result response. </returns>
        public virtual Response<CancelBulkOperationsResult> BulkCancelOperations(CancelBulkOperationsContent content, CancellationToken cancellationToken = default)
            => BulkCancelOperations(GetResourceGroupLocation(cancellationToken), content, cancellationToken);
    }
}
