namespace Microsoft.Azure.Management.NetApp.Customizations
{
    using System.Threading;
    using System.Threading.Tasks;
    public static partial class VolumesOperationsExtensions
    {
        /// <summary>
        /// Delete a volume
        /// </summary>
        /// <remarks>
        /// Delete the specified volume
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static void Delete(this IVolumesOperations operations, string resourceGroupName, string accountName, string poolName, string volumeName)
        {
            operations.DeleteAsync(resourceGroupName, accountName, poolName, volumeName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete a volume
        /// </summary>
        /// <remarks>
        /// Delete the specified volume
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task DeleteAsync(this IVolumesOperations operations, string resourceGroupName, string accountName, string poolName, string volumeName, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, accountName, poolName, volumeName, null, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }
    }
}
