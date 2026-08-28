// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
#pragma warning disable SA1402

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppElasticCapacityPoolResource : IJsonModel<NetAppElasticCapacityPoolData>, IPersistableModel<NetAppElasticCapacityPoolData>
    {
        public static readonly ResourceType ResourceType = "Microsoft.NetApp/netAppAccounts/elasticCapacityPools";
        private readonly NetAppElasticCapacityPoolData _data;
        private bool _hasData;

        internal NetAppElasticCapacityPoolResource(ArmClient client, NetAppElasticCapacityPoolData data) : this(client, data.Id)
        {
            _data = data;
            _hasData = true;
        }

        public virtual bool HasData => _hasData;
        public virtual NetAppElasticCapacityPoolData Data => _data;

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string elasticPoolName)
            => new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/elasticCapacityPools/{elasticPoolName}");

        public virtual Response<NetAppElasticCapacityPoolResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<NetAppElasticCapacityPoolResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual ArmOperation<NetAppElasticCapacityPoolResource> Update(WaitUntil waitUntil, NetAppElasticCapacityPoolPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<ArmOperation<NetAppElasticCapacityPoolResource>> UpdateAsync(WaitUntil waitUntil, NetAppElasticCapacityPoolPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Response<NetAppElasticCapacityPoolResource> AddTag(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<NetAppElasticCapacityPoolResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Response<NetAppElasticCapacityPoolResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<NetAppElasticCapacityPoolResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Response<NetAppElasticCapacityPoolResource> RemoveTag(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<NetAppElasticCapacityPoolResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual ArmOperation<NetAppElasticCapacityPoolResource> ChangeZone(WaitUntil waitUntil, ChangeZoneContent content, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<ArmOperation<NetAppElasticCapacityPoolResource>> ChangeZoneAsync(WaitUntil waitUntil, ChangeZoneContent content, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Response<CheckElasticResourceAvailabilityResult> CheckVolumeFilePathAvailability(CheckElasticVolumeFilePathAvailabilityContent content, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<CheckElasticResourceAvailabilityResult>> CheckVolumeFilePathAvailabilityAsync(CheckElasticVolumeFilePathAvailabilityContent content, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual NetAppElasticVolumeCollection GetNetAppElasticVolumes() => throw new NotSupportedException();
        [ForwardsClientCalls]
        public virtual Response<NetAppElasticVolumeResource> GetNetAppElasticVolume(string volumeName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        [ForwardsClientCalls]
        public virtual Task<Response<NetAppElasticVolumeResource>> GetNetAppElasticVolumeAsync(string volumeName, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        NetAppElasticCapacityPoolData IJsonModel<NetAppElasticCapacityPoolData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticCapacityPoolData(default);
        void IJsonModel<NetAppElasticCapacityPoolData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException();
        NetAppElasticCapacityPoolData IPersistableModel<NetAppElasticCapacityPoolData>.Create(BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticCapacityPoolData(default);
        string IPersistableModel<NetAppElasticCapacityPoolData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<NetAppElasticCapacityPoolData>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");
    }
}
