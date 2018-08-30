// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CR.Azure.NetCore.Tests.TestClients.Interface
{
    using CR.Azure.NetCore.Tests.TestClients.Models;
    using Microsoft.Rest.Azure;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public partial interface IRedisOperations
    {
        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<RedisResource>> BeginCreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        Task<AzureOperationResponse<RedisResource>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        Task<AzureOperationResponse<RedisResource>> PatchWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId,
                                                                                                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<RedisSubResource>> BeginCreateOrUpdateSubResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        Task<AzureOperationResponse<RedisSubResource>> CreateOrUpdateSubResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<Sku>> BeginCreateOrUpdateNonResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        Task<AzureOperationResponse<Sku>> CreateOrUpdateNonResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Deletes a redis cache. This operation takes a while to complete.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Gets a redis cache (resource description).
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<RedisResource>> GetWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        Task<AzureOperationResponse<Sku>> BeginPostWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        Task<AzureOperationResponse<Sku>> PostWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}
