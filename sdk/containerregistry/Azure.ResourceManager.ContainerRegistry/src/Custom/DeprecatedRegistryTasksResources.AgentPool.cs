// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591, SA1402, SA1508

using System;
using System.Collections;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ContainerRegistry.Models;

namespace Azure.ResourceManager.ContainerRegistry
{
    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryAgentPoolCollection
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryAgentPoolCollection : ArmCollection, IEnumerable<ContainerRegistryAgentPoolResource>, IAsyncEnumerable<ContainerRegistryAgentPoolResource>
    {
        protected ContainerRegistryAgentPoolCollection() : base() { }

        public virtual Response<bool> Exists(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<bool>> ExistsAsync(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryAgentPoolResource> Get(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryAgentPoolResource>> GetAsync(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Pageable<ContainerRegistryAgentPoolResource> GetAll(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual AsyncPageable<ContainerRegistryAgentPoolResource> GetAllAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual NullableResponse<ContainerRegistryAgentPoolResource> GetIfExists(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<NullableResponse<ContainerRegistryAgentPoolResource>> GetIfExistsAsync(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual ArmOperation<ContainerRegistryAgentPoolResource> CreateOrUpdate(WaitUntil waitUntil, string agentPoolName, ContainerRegistryAgentPoolData data, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<ArmOperation<ContainerRegistryAgentPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string agentPoolName, ContainerRegistryAgentPoolData data, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        IEnumerator<ContainerRegistryAgentPoolResource> IEnumerable<ContainerRegistryAgentPoolResource>.GetEnumerator() { return GetAll().GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetAll().GetEnumerator(); }
        IAsyncEnumerator<ContainerRegistryAgentPoolResource> IAsyncEnumerable<ContainerRegistryAgentPoolResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken); }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryAgentPoolResource
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryAgentPoolResource : ArmResource, IJsonModel<ContainerRegistryAgentPoolData>, IPersistableModel<ContainerRegistryAgentPoolData>
    {
        ContainerRegistryAgentPoolData IJsonModel<ContainerRegistryAgentPoolData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryAgentPoolData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryAgentPoolData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryAgentPoolData IPersistableModel<ContainerRegistryAgentPoolData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryAgentPoolData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public static readonly ResourceType ResourceType;

        protected ContainerRegistryAgentPoolResource() : base() { }

        [WirePath("")]
        public virtual ContainerRegistryAgentPoolData Data { get { throw new NotSupportedException(); } }
        [WirePath("")]
        public virtual bool HasData { get { throw new NotSupportedException(); } }

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string agentPoolName) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryAgentPoolResource> Get(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryAgentPoolResource>> GetAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual ArmOperation<ContainerRegistryAgentPoolResource> Update(WaitUntil waitUntil, ContainerRegistryAgentPoolPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<ArmOperation<ContainerRegistryAgentPoolResource>> UpdateAsync(WaitUntil waitUntil, ContainerRegistryAgentPoolPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryAgentPoolResource> AddTag(string key, string value, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryAgentPoolResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryAgentPoolResource> RemoveTag(string key, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryAgentPoolResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryAgentPoolResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryAgentPoolResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryAgentPoolQueueStatus> GetQueueStatus(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryAgentPoolQueueStatus>> GetQueueStatusAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryAgentPoolData
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryAgentPoolData : TrackedResourceData, IJsonModel<ContainerRegistryAgentPoolData>, IPersistableModel<ContainerRegistryAgentPoolData>
    {
        ContainerRegistryAgentPoolData IJsonModel<ContainerRegistryAgentPoolData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryAgentPoolData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryAgentPoolData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryAgentPoolData IPersistableModel<ContainerRegistryAgentPoolData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryAgentPoolData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryAgentPoolData(AzureLocation location) : base(location) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }

        [WirePath("properties.count")]
        public int? Count { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.tier")]
        public string Tier { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.os")]
        public ContainerRegistryOS? OS { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.virtualNetworkSubnetResourceId")]
        public ResourceIdentifier VirtualNetworkSubnetResourceId { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.provisioningState")]
        public ContainerRegistryProvisioningState? ProvisioningState { get { throw new NotSupportedException(); } }
    }
}
