namespace Microsoft.Azure.Management.Compute
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for GalleriesOperations.
    /// </summary>
    public static partial class GalleriesOperationsExtensions
    {
        public static async Task<Gallery> GetAsync(this IGalleriesOperations operations, string resourceGroupName, string galleryName, string select, CancellationToken cancellationToken)
        {
            using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, galleryName, select, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Retrieves information about a Shared Image Gallery.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='galleryName'>
        /// The name of the Shared Image Gallery.
        /// </param>
        public static async Task<Gallery> GetAsync(this IGalleriesOperations operations, string resourceGroupName, string galleryName)
        {
            return await GetAsync(operations, resourceGroupName, galleryName, default(string), default(CancellationToken));
        }

        /// <summary>
        /// Retrieves information about a Shared Image Gallery.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='galleryName'>
        /// The name of the Shared Image Gallery.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Gallery> GetAsync(this IGalleriesOperations operations, string resourceGroupName, string galleryName, CancellationToken cancellationToken)
        {
            return await GetAsync(operations, resourceGroupName, galleryName, default(string), cancellationToken);
        }
    }
}
