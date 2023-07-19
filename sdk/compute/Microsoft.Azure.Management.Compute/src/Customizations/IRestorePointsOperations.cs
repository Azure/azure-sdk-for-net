namespace Microsoft.Azure.Management.Compute
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial interface IRestorePointsOperations
    {
        Task<AzureOperationResponse<RestorePoint>> GetWithHttpMessagesAsync(string resourceGroupName, string restorePointCollectionName, string restorePointName, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken = default(CancellationToken));
    }
}