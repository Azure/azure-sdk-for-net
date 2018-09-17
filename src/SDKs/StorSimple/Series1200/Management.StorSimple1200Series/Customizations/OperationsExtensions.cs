namespace Microsoft.Azure.Management.StorSimple1200Series
{
    using Azure;
    using Management;
    using Rest;
    using Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using Microsoft.Azure.Management.StorSimple1200Series;

    /// <summary>
    /// Extension methods for Operations.
    /// </summary>
    public static partial class OperationsExtensions
    {
        /// <summary>
        /// Lists all of the available REST API operations of the Microsoft.Storsimple
        /// provider
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        public static IPage<AvailableProviderOperation> List(this IAvailableProviderOperationsOperations operations)
        {
            return operations.ListAsync().GetAwaiter().GetResult() as IPage<AvailableProviderOperation>;
        }

        /// <summary>
        /// Lists all of the available REST API operations of the Microsoft.Storsimple
        /// provider
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        //public static async Task<IPage<AvailableProviderOperation>> ListAsync(this IAvailableProviderOperationsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    using (var _result = await operations.ListWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
        //    {
        //        return _result.Body;
        //    }
        //}

        /// <summary>
        /// Lists all of the available REST API operations of the Microsoft.Storsimple
        /// provider
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        //public static IPage<AvailableProviderOperation> ListNext(this IAvailableProviderOperationsOperations operations, string nextPageLink)
        //{
        //    return operations.ListNextAsync(nextPageLink).GetAwaiter().GetResult();
        //}

        /// <summary>
        /// Lists all of the available REST API operations of the Microsoft.Storsimple
        /// provider
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        //public static async Task<IPage<AvailableProviderOperation>> ListNextAsync(this IAvailableProviderOperationsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
        //    {
        //        return _result.Body;
        //    }
        //}

    }
}

