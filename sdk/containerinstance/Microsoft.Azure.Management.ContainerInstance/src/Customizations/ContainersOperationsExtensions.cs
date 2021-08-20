namespace Microsoft.Azure.Management.ContainerInstance
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ContainersOperations.
    /// </summary>
    public static partial class ContainersOperationsExtensions
    {
        /// <summary>
        /// Get the logs for a specified container instance.
        /// </summary>
        /// <remarks>
        /// Get the logs for a specified container instance in a specified resource
        /// group and container group.
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Logs> ListLogsAsync(this IContainersOperations operations, string resourceGroupName, string containerGroupName, string containerName, int? tail, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.ListLogsWithHttpMessagesAsync(resourceGroupName, containerGroupName, containerName, tail, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
