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
    }
}

