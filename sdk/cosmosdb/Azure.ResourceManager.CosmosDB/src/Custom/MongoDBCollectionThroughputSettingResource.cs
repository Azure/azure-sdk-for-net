// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.CosmosDB.Models;

namespace Azure.ResourceManager.CosmosDB
{
    // Generator tag-helper fallback calls this.UpdateAsync(WaitUntil, ThroughputSettingData, CT);
    // throughput resources only expose CreateOrUpdate (PUT). Shim Update -> CreateOrUpdate so the
    // generated tag helpers compile; the tag-resource happy path is unaffected.
    // TODO: remove once https://github.com/Azure/azure-sdk-for-net/issues/58747 is resolved.
    public partial class MongoDBCollectionThroughputSettingResource
    {
        private Task<ArmOperation<MongoDBCollectionThroughputSettingResource>> UpdateAsync(WaitUntil waitUntil, ThroughputSettingData data, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, ToUpdateData(data), cancellationToken);

        private ArmOperation<MongoDBCollectionThroughputSettingResource> Update(WaitUntil waitUntil, ThroughputSettingData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, ToUpdateData(data), cancellationToken);

        private static ThroughputSettingsUpdateData ToUpdateData(ThroughputSettingData data)
        {
            var update = new ThroughputSettingsUpdateData(data.Location, data.Properties?.Resource);
            foreach (var tag in data.Tags)
            {
                update.Tags[tag.Key] = tag.Value;
            }
            return update;
        }
    }
}
