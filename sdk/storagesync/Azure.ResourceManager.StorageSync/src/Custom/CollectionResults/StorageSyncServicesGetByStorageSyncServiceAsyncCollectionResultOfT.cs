// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.StorageSync.Models;

namespace Azure.ResourceManager.StorageSync
{
    // This class will be removed once we have support for new pageable decorator https://github.com/Azure/typespec-azure/issues/3650
    internal partial class StorageSyncServicesGetByStorageSyncServiceAsyncCollectionResultOfT : AsyncPageable<StorageSyncPrivateLinkResource>
    {
        private readonly StorageSyncServices _client;
        private readonly Guid _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _storageSyncServiceName;
        private readonly RequestContext _context;

        /// <summary> Initializes a new instance of StorageSyncServicesGetByStorageSyncServiceAsyncCollectionResultOfT, which is used to iterate over the pages of a collection. </summary>
        /// <param name="client"> The StorageSyncServices client used to send requests. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="storageSyncServiceName"> Name of Storage Sync Service resource. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public StorageSyncServicesGetByStorageSyncServiceAsyncCollectionResultOfT(StorageSyncServices client, Guid subscriptionId, string resourceGroupName, string storageSyncServiceName, RequestContext context) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _storageSyncServiceName = storageSyncServiceName;
            _context = context;
        }

        /// <summary> Gets the pages of StorageSyncServicesGetByStorageSyncServiceAsyncCollectionResultOfT as an enumerable collection. </summary>
        /// <param name="continuationToken"> A continuation token indicating where to resume paging. </param>
        /// <param name="pageSizeHint"> The number of items per page. </param>
        /// <returns> The pages of StorageSyncServicesGetByStorageSyncServiceAsyncCollectionResultOfT as an enumerable collection. </returns>
        public override async IAsyncEnumerable<Page<StorageSyncPrivateLinkResource>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Response response = await GetNextResponseAsync(pageSizeHint, null).ConfigureAwait(false);
            StorageSyncPrivateLinkResourceListResult result = StorageSyncPrivateLinkResourceListResult.FromResponse(response);
            yield return Page<StorageSyncPrivateLinkResource>.FromValues((IReadOnlyList<StorageSyncPrivateLinkResource>)result.Value, null, response);
        }

        /// <summary> Get next page. </summary>
        /// <param name="pageSizeHint"> The number of items per page. </param>
        /// <param name="continuationToken"> A continuation token indicating where to resume paging. </param>
        private async ValueTask<Response> GetNextResponseAsync(int? pageSizeHint, string continuationToken)
        {
            HttpMessage message = _client.CreateGetByStorageSyncServiceRequest(_subscriptionId, _resourceGroupName, _storageSyncServiceName, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("StorageSyncServiceResource.GetByStorageSyncService");
            scope.Start();
            try
            {
                return await _client.Pipeline.ProcessMessageAsync(message, _context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
