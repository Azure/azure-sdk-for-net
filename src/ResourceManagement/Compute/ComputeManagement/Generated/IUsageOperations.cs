namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.Azure.OData;
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
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<ListUsagesResult>> ListWithHttpMessagesAsync(string location, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
