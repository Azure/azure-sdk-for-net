namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.Rest.Azure.OData;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// ResourceProviderOperationDetailsOperations operations.
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
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<ResourceProviderOperationDetailListResult>> ListWithHttpMessagesAsync(string resourceProviderNamespace, string apiVersion, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
