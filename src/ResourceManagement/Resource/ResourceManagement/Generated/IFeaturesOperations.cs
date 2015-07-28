namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// FeaturesOperations operations.
    /// </summary>
    public partial interface IFeaturesOperations
    {
        /// <summary>
        /// Gets a list of previewed features for all the providers in the
        /// current subscription.
        /// </summary>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<FeatureResult>>> ListAllWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of previewed features of a resource provider.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// The namespace of the resource provider.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<FeatureResult>>> ListWithHttpMessagesAsync(string resourceProviderNamespace, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get all features under the subscription.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// Namespace of the resource provider.
        /// </param>
        /// <param name='featureName'>
        /// Previewed feature name in the resource provider.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<FeatureResult>> GetWithHttpMessagesAsync(string resourceProviderNamespace, string featureName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Registers for a previewed feature of a resource provider.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// Namespace of the resource provider.
        /// </param>
        /// <param name='featureName'>
        /// Previewed feature name in the resource provider.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<FeatureResult>> RegisterWithHttpMessagesAsync(string resourceProviderNamespace, string featureName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of previewed features for all the providers in the
        /// current subscription.
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
        Task<AzureOperationResponse<Page<FeatureResult>>> ListAllNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of previewed features of a resource provider.
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
        Task<AzureOperationResponse<Page<FeatureResult>>> ListNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
