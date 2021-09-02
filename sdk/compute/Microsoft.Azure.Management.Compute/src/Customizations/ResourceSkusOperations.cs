namespace Microsoft.Azure.Management.Compute
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// ResourceSkusOperations operations.
    /// </summary>
    internal partial class ResourceSkusOperations : IServiceOperations<ComputeManagementClient>, IResourceSkusOperations
    {
        public async Task<AzureOperationResponse<IPage<ResourceSku>>> ListWithHttpMessagesAsync(string filter = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ListWithHttpMessagesAsync(filter, null, customHeaders, cancellationToken);
        }
    }
}