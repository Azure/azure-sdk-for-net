namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface IFeaturesOperations
    {
        /// <summary>
        /// Gets a list of previewed features for all the providers in the
        /// current subscription.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<FeatureOperationsListResult>> ListAllWithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of previewed features of a resource provider.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// The namespace of the resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<FeatureOperationsListResult>> ListWithOperationResponseAsync(string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get all features under the subscription.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// Namespace of the resource provider.
        /// </param>
        /// <param name='featureName'>
        /// Previewed feature name in the resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<FeatureResponse>> GetWithOperationResponseAsync(string resourceProviderNamespace, string featureName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Registers for a previewed feature of a resource provider.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// Namespace of the resource provider.
        /// </param>
        /// <param name='featureName'>
        /// Previewed feature name in the resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<FeatureResponse>> RegisterWithOperationResponseAsync(string resourceProviderNamespace, string featureName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of previewed features for all the providers in the
        /// current subscription.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<FeatureOperationsListResult>> ListAllNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of previewed features of a resource provider.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<FeatureOperationsListResult>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
