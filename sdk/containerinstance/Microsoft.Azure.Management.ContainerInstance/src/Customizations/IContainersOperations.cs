namespace Microsoft.Azure.Management.ContainerInstance
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// ContainersOperations operations.
    /// </summary>
    public partial interface IContainersOperations
    {
        /// <summary>
        /// Get the logs for a specified container instance.
        /// </summary>
        /// <remarks>
        /// Get the logs for a specified container instance in a specified
        /// resource group and container group.
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
        /// The number of lines to show from the tail of the container instance
        /// log. If not provided, all available logs are shown up to 4mb.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<Logs>> ListLogsWithHttpMessagesAsync(string resourceGroupName, string containerGroupName, string containerName, int? tail, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken = default(CancellationToken));
    }
}
