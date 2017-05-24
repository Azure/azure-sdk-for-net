using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Rest.Azure;

namespace Redis.JsonRpc
{
    class RedisOperationsMock : IRedisOperations
    {
        private readonly IRedisOperations _Original;

        public RedisOperationsMock(IRedisOperations original)
        {
            _Original = original;
        }

        public Task<AzureOperationResponse<RedisResource>> BeginCreateWithHttpMessagesAsync(
            string resourceGroupName, string name, RedisCreateParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.BeginCreateWithHttpMessagesAsync(resourceGroupName, name, parameters, customHeaders, cancellationToken);

        public Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string name, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.BeginDeleteWithHttpMessagesAsync(resourceGroupName, name, customHeaders, cancellationToken);

        public Task<AzureOperationResponse> BeginExportDataWithHttpMessagesAsync(string resourceGroupName, string name, ExportRDBParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.BeginExportDataWithHttpMessagesAsync(resourceGroupName, name, parameters, customHeaders, cancellationToken);

        public Task<AzureOperationResponse> BeginImportDataWithHttpMessagesAsync(string resourceGroupName, string name, ImportRDBParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.BeginImportDataWithHttpMessagesAsync(resourceGroupName, name, parameters, customHeaders, cancellationToken);

        public Task<AzureOperationResponse<RedisResource>> BeginUpdateWithHttpMessagesAsync(string resourceGroupName, string name, RedisUpdateParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.BeginUpdateWithHttpMessagesAsync(resourceGroupName, name, parameters, customHeaders, cancellationToken);

        public Task<AzureOperationResponse<RedisResource>> CreateWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.CreateWithHttpMessagesAsync(resourceGroupName, name, parameters, customHeaders, cancellationToken);

        public Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string name, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.DeleteWithHttpMessagesAsync(resourceGroupName, name, customHeaders, cancellationToken);

        public Task<AzureOperationResponse> ExportDataWithHttpMessagesAsync(string resourceGroupName, string name, ExportRDBParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.ExportDataWithHttpMessagesAsync(resourceGroupName, name, parameters, customHeaders, cancellationToken);

        public Task<AzureOperationResponse> ForceRebootWithHttpMessagesAsync(string resourceGroupName, string name, RedisRebootParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.ForceRebootWithHttpMessagesAsync(resourceGroupName, name, parameters, customHeaders, cancellationToken);

        public Task<AzureOperationResponse<RedisResource>> GetWithHttpMessagesAsync(string resourceGroupName, string name, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.GetWithHttpMessagesAsync(resourceGroupName, name, customHeaders, cancellationToken);

        public Task<AzureOperationResponse> ImportDataWithHttpMessagesAsync(string resourceGroupName, string name, ImportRDBParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.ImportDataWithHttpMessagesAsync(resourceGroupName, name, parameters, customHeaders, cancellationToken);
        public Task<AzureOperationResponse<IPage<RedisResource>>> ListByResourceGroupNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink, customHeaders, cancellationToken);
        public Task<AzureOperationResponse<IPage<RedisResource>>> ListByResourceGroupWithHttpMessagesAsync(string resourceGroupName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, customHeaders, cancellationToken);
        public Task<AzureOperationResponse<RedisAccessKeys>> ListKeysWithHttpMessagesAsync(string resourceGroupName, string name, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.ListKeysWithHttpMessagesAsync(resourceGroupName, name, customHeaders, cancellationToken);
        public Task<AzureOperationResponse<IPage<RedisResource>>> ListNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.ListNextWithHttpMessagesAsync(nextPageLink, customHeaders, cancellationToken);
        public Task<AzureOperationResponse<IPage<RedisResource>>> ListWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.ListWithHttpMessagesAsync(customHeaders, cancellationToken);
        public Task<AzureOperationResponse<RedisAccessKeys>> RegenerateKeyWithHttpMessagesAsync(string resourceGroupName, string name, RedisRegenerateKeyParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.RegenerateKeyWithHttpMessagesAsync(resourceGroupName, name, parameters, customHeaders, cancellationToken);

        public Task<AzureOperationResponse<RedisResource>> UpdateWithHttpMessagesAsync(string resourceGroupName, string name, RedisUpdateParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            => _Original.UpdateWithHttpMessagesAsync(resourceGroupName, name, parameters, customHeaders, cancellationToken);
    }
}
