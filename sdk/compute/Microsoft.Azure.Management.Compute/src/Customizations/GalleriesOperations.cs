namespace Microsoft.Azure.Management.Compute
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// GalleriesOperations operations.
    /// </summary>
    internal partial class GalleriesOperations : IServiceOperations<ComputeManagementClient>, IGalleriesOperations
    {
        /// <summary>
        /// Retrieves information about a Shared Image Gallery.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='galleryName'>
        /// The name of the Shared Image Gallery.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse<Gallery>> GetWithHttpMessagesAsync(string resourceGroupName, string galleryName)
        {
            return await GetWithHttpMessagesAsync(resourceGroupName, galleryName, default(string), null, default(CancellationToken));
        }

        /// <summary>
        /// Retrieves information about a Shared Image Gallery.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='galleryName'>
        /// The name of the Shared Image Gallery.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse<Gallery>> GetWithHttpMessagesAsync(string resourceGroupName, string galleryName, Dictionary<string, List<string>> customHeaders = null)
        {
            return await GetWithHttpMessagesAsync(resourceGroupName, galleryName, default(string), customHeaders, default(CancellationToken));
        }

        /// <summary>
        /// Retrieves information about a Shared Image Gallery.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='galleryName'>
        /// The name of the Shared Image Gallery.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse<Gallery>> GetWithHttpMessagesAsync(string resourceGroupName, string galleryName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetWithHttpMessagesAsync(resourceGroupName, galleryName, default(string), customHeaders, cancellationToken);
        }
    }
}