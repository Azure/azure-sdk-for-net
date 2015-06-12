namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure.OData;
    using System.Linq.Expressions;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface IResourceProviderOperationDetailsOperations
    {
        /// <summary>
        /// Gets a list of resource providers.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// Resource identity.
        /// </param>
        /// <param name='apiVersion'>
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<IList<ResourceProviderOperationDefinition>>> ListWithOperationResponseAsync(string resourceProviderNamespace, string apiVersion, CancellationToken cancellationToken = default(CancellationToken));
    }
}
