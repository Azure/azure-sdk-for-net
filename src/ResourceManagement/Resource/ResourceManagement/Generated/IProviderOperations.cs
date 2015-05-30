using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure.OData;
using System.Linq.Expressions;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Management.Resources
{
    /// <summary>
    /// </summary>
    public partial interface IProviderOperations
    {
        /// <summary>
        /// Unregisters provider from a subscription.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// Namespace of the resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<Provider>> UnregisterWithOperationResponseAsync(string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Registers provider to be used with a subscription.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// Namespace of the resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<Provider>> RegisterWithOperationResponseAsync(string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of resource providers.
        /// </summary>
        /// <param name='top'>
        /// Query parameters. If null is passed returns all deployments.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ProviderListResult>> ListWithOperationResponseAsync(int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a resource provider.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// Namespace of the resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<Provider>> GetWithOperationResponseAsync(string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of resource providers.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ProviderListResult>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
