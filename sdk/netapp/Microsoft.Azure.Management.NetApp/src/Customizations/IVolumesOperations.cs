namespace Microsoft.Azure.Management.Compute
{
    using Microsoft.Rest.Azure;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;   

    public partial interface IVolumesOperations
    {

        /// <summary>
        /// Delete a volume
        /// </summary>
        /// <remarks>
        /// Delete the specified volume
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='accountName'>
        /// The name of the NetApp account
        /// </param>
        /// <param name='poolName'>
        /// The name of the capacity pool
        /// </param>
        /// <param name='volumeName'>
        /// The name of the volume
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
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string accountName, string poolName, string volumeName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
