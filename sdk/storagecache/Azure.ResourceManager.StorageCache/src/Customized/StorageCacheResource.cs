// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageCache.Models;

namespace Azure.ResourceManager.StorageCache
{
    public partial class StorageCacheResource : ArmResource
    {
        /// <summary>
        /// Update a Cache instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.StorageCache/caches/{cacheName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Caches_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Object containing the user-selectable properties of the Cache. If read-only properties are included, they must match the existing values of those properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<StorageCacheResource>> UpdateAsync(StorageCacheData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _storageCacheCachesClientDiagnostics.CreateScope("StorageCacheResource.Update");
            scope.Start();
            try
            {
                var response = await _storageCacheCachesRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken).ConfigureAwait(false);
                StorageCacheData value = default;
                using var document = JsonDocument.Parse(response.ContentStream);
                value = StorageCacheData.DeserializeStorageCacheData(document.RootElement);
                return Response.FromValue(new StorageCacheResource(Client, value), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update a Cache instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.StorageCache/caches/{cacheName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Caches_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Object containing the user-selectable properties of the Cache. If read-only properties are included, they must match the existing values of those properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<StorageCacheResource> Update(StorageCacheData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _storageCacheCachesClientDiagnostics.CreateScope("StorageCacheResource.Update");
            scope.Start();
            try
            {
                var response = _storageCacheCachesRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken);
                StorageCacheData value = default;
                using var document = JsonDocument.Parse(response.ContentStream);
                value = StorageCacheData.DeserializeStorageCacheData(document.RootElement);
                return Response.FromValue(new StorageCacheResource(Client, value), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
