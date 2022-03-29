namespace Microsoft.Azure.Management.Compute
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// ResourceSkusOperations operations.
    /// </summary>
    public partial interface IResourceSkusOperations
    {
        Task<AzureOperationResponse<IPage<ResourceSku>>> ListWithHttpMessagesAsync(string filter, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<ResourceSku>>> ListWithHttpMessagesAsync(string filter, Dictionary<string, List<string>> customHeaders);
    }
}