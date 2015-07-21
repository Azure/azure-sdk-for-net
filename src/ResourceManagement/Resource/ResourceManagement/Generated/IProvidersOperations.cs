namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.Azure.OData;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface IProvidersOperations
    {
        /// <summary>
        /// Unregisters provider from a subscription.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// Namespace of the resource provider.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Provider>> UnregisterWithHttpMessagesAsync(string resourceProviderNamespace, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Registers provider to be used with a subscription.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// Namespace of the resource provider.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Provider>> RegisterWithHttpMessagesAsync(string resourceProviderNamespace, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of resource providers.
        /// </summary>
        /// <param name='top'>
        /// Query parameters. If null is passed returns all deployments.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<Provider>>> ListWithHttpMessagesAsync(int? top = default(int?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a resource provider.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// Namespace of the resource provider.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Provider>> GetWithHttpMessagesAsync(string resourceProviderNamespace, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of resource providers.
        /// </summary>
        /// <param name='nextPageLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<Provider>>> ListNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
