// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ComputeBulkActions.Mocking;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ComputeBulkActions
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.ComputeBulkActions. </summary>
    public static partial class ComputeBulkActionsExtensions
    {
        /// <summary>
        /// Get the status of a LaunchBulkInstancesOperation.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableComputeBulkActionsSubscriptionResource.GetOperationStatusAsync(AzureLocation, string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. </param>
        /// <param name="id"> The async operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        public static async Task<Response<OperationStatusResult>> GetOperationStatusAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableComputeBulkActionsSubscriptionResource(subscriptionResource).GetOperationStatusAsync(location, id, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the status of a LaunchBulkInstancesOperation.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableComputeBulkActionsSubscriptionResource.GetOperationStatus(AzureLocation, string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. </param>
        /// <param name="id"> The async operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        public static Response<OperationStatusResult> GetOperationStatus(this SubscriptionResource subscriptionResource, AzureLocation location, string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableComputeBulkActionsSubscriptionResource(subscriptionResource).GetOperationStatus(location, id, cancellationToken);
        }
    }
}
