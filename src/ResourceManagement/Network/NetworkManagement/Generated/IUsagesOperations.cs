namespace Microsoft.Azure.Management.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// UsagesOperations operations.
    /// </summary>
    public partial interface IUsagesOperations
    {
        /// <summary>
        /// Lists compute usages for a subscription.
        /// </summary>
        /// <param name='location'>
        /// The location upon which resource usage is queried.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<UsagesListResult>> ListWithHttpMessagesAsync(string location, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
