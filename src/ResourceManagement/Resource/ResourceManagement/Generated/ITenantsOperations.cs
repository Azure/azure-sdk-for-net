namespace Microsoft.Azure.Subscriptions
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
    public partial interface ITenantsOperations
    {
        /// <summary>
        /// Gets a list of the tenantIds.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<IList<TenantIdDescription>>> ListWithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
