// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.CosmosDB.Models;

namespace Azure.ResourceManager.CosmosDB
{
    // The MPG generator emits AddTag/RemoveTag/SetTags bodies that call
    // this.UpdateAsync(WaitUntil, ThroughputSettingData, CancellationToken),
    // but throughput resources only expose CreateOrUpdate (PUT) - there is no
    // PATCH operation, so no Update method is generated. Provide thin shims
    // that translate the call into CreateOrUpdate so the tag helpers compile.
    public partial class GremlinDatabaseThroughputSettingResource
    {
        private Task<ArmOperation<GremlinDatabaseThroughputSettingResource>> UpdateAsync(WaitUntil waitUntil, ThroughputSettingData data, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, ToUpdateData(data), cancellationToken);

        private ArmOperation<GremlinDatabaseThroughputSettingResource> Update(WaitUntil waitUntil, ThroughputSettingData data, CancellationToken cancellationToken = default)
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
