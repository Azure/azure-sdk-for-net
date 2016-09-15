
namespace Microsoft.Azure.Management.Media
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// MediaServiceOperations operations.
    /// </summary>
    public partial interface IMediaServiceOperations
    {
        /// <summary>
        /// Check whether the Media Service resource name is available. The
        /// name must be globally unique.
        /// </summary>
        /// <param name='checkNameAvailabilityInput'>
        /// Properties needed to check the availability of a name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<CheckNameAvailabilityOutput>> CheckNameAvailabiltyWithHttpMessagesAsync(CheckNameAvailabilityInput checkNameAvailabilityInput, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// List all of the Media Services in a resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group within the Azure subscription.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<IEnumerable<MediaService>>> ListByResourceGroupWithHttpMessagesAsync(string resourceGroupName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a Media Service.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group within the Azure subscription.
        /// </param>
        /// <param name='mediaServiceName'>
        /// Name of the Media Service.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<MediaService>> GetWithHttpMessagesAsync(string resourceGroupName, string mediaServiceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create a Media Service.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group within the Azure subscription.
        /// </param>
        /// <param name='mediaServiceName'>
        /// Name of the Media Service.
        /// </param>
        /// <param name='mediaService'>
        /// Media Service properties needed for creation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<MediaService>> CreateWithHttpMessagesAsync(string resourceGroupName, string mediaServiceName, MediaService mediaService, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete a Media Service.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group within the Azure subscription.
        /// </param>
        /// <param name='mediaServiceName'>
        /// Name of the Media Service.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string mediaServiceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update a Media Service.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group within the Azure subscription.
        /// </param>
        /// <param name='mediaServiceName'>
        /// Name of the Media Service.
        /// </param>
        /// <param name='mediaService'>
        /// Media Service properties needed for update.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<MediaService>> UpdateWithHttpMessagesAsync(string resourceGroupName, string mediaServiceName, MediaService mediaService, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Regenerate the key for a Media Service.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group within the Azure subscription.
        /// </param>
        /// <param name='mediaServiceName'>
        /// Name of the Media Service.
        /// </param>
        /// <param name='regenerateKeyInput'>
        /// Properties needed to regenerate the Media Service key.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<RegenerateKeyOutput>> RegenerateKeyWithHttpMessagesAsync(string resourceGroupName, string mediaServiceName, RegenerateKeyInput regenerateKeyInput, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// List the keys for a Media Service.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group within the Azure subscription.
        /// </param>
        /// <param name='mediaServiceName'>
        /// Name of the Media Service.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<ServiceKeys>> ListKeysWithHttpMessagesAsync(string resourceGroupName, string mediaServiceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Synchronize the keys for a storage account to the Media Service.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group within the Azure subscription.
        /// </param>
        /// <param name='mediaServiceName'>
        /// Name of the Media Service.
        /// </param>
        /// <param name='syncStorageKeysInput'>
        /// Properties needed to sycnronize the keys for a storage account to
        /// the Media Service.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<MediaService>> SyncStorageKeysWithHttpMessagesAsync(string resourceGroupName, string mediaServiceName, SyncStorageKeysInput syncStorageKeysInput, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
