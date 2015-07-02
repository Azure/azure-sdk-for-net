namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface IUsageOperations
    {
        /// <summary>
        /// Lists compute usages for a subscription.
        /// </summary>
        /// <param name='location'>
        /// The location upon which resource usage is queried.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ListUsagesResult>> ListWithOperationResponseAsync(string location, CancellationToken cancellationToken = default(CancellationToken));
    }
}
