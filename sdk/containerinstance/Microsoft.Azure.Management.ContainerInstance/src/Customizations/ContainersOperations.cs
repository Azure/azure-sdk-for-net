namespace Microsoft.Azure.Management.ContainerInstance
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
    /// ContainersOperations operations.
    /// </summary>
    internal partial class ContainersOperations : IServiceOperations<ContainerInstanceManagementClient>, IContainersOperations
    {
        /// <summary>
        /// Get the logs for a specified container instance.
        /// </summary>
        /// <remarks>
        /// Get the logs for a specified container instance in a specified resource
        /// group and container group.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='containerGroupName'>
        /// The name of the container group.
        /// </param>
        /// <param name='containerName'>
        /// The name of the container instance.
        /// </param>
        /// <param name='tail'>
        /// The number of lines to show from the tail of the container instance log. If
        /// not provided, all available logs are shown up to 4mb.
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
        public async Task<AzureOperationResponse<Logs>> ListLogsWithHttpMessagesAsync(string resourceGroupName, string containerGroupName, string containerName, int? tail, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ListLogsWithHttpMessagesAsync(resourceGroupName: resourceGroupName, containerGroupName: containerGroupName, containerName: containerName, tail: tail, timestamps: false, customHeaders: customHeaders, cancellationToken: cancellationToken);
        }
    }
}
