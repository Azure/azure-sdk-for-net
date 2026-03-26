// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591, SA1402, SA1508, CS0618

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
    //  ContainerRegistryTaskCollection
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskCollection : ArmCollection, IEnumerable<ContainerRegistryTaskResource>, IAsyncEnumerable<ContainerRegistryTaskResource>
    {
        protected ContainerRegistryTaskCollection() : base() { }

        public virtual Response<bool> Exists(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<bool>> ExistsAsync(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryTaskResource> Get(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryTaskResource>> GetAsync(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Pageable<ContainerRegistryTaskResource> GetAll(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual AsyncPageable<ContainerRegistryTaskResource> GetAllAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual NullableResponse<ContainerRegistryTaskResource> GetIfExists(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<NullableResponse<ContainerRegistryTaskResource>> GetIfExistsAsync(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual ArmOperation<ContainerRegistryTaskResource> CreateOrUpdate(WaitUntil waitUntil, string taskName, ContainerRegistryTaskData data, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<ArmOperation<ContainerRegistryTaskResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string taskName, ContainerRegistryTaskData data, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        IEnumerator<ContainerRegistryTaskResource> IEnumerable<ContainerRegistryTaskResource>.GetEnumerator() { return GetAll().GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetAll().GetEnumerator(); }
        IAsyncEnumerator<ContainerRegistryTaskResource> IAsyncEnumerable<ContainerRegistryTaskResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken); }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryTaskResource
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskResource : ArmResource, IJsonModel<ContainerRegistryTaskData>, IPersistableModel<ContainerRegistryTaskData>
    {
        ContainerRegistryTaskData IJsonModel<ContainerRegistryTaskData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTaskData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTaskData IPersistableModel<ContainerRegistryTaskData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTaskData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public static readonly ResourceType ResourceType;

        protected ContainerRegistryTaskResource() : base() { }

        [WirePath("")]
        public virtual ContainerRegistryTaskData Data { get { throw new NotSupportedException(); } }
        [WirePath("")]
        public virtual bool HasData { get { throw new NotSupportedException(); } }

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskName) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryTaskResource> Get(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryTaskResource>> GetAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual ArmOperation<ContainerRegistryTaskResource> Update(WaitUntil waitUntil, ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<ArmOperation<ContainerRegistryTaskResource>> UpdateAsync(WaitUntil waitUntil, ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        [Obsolete("This method is obsolete and will be removed in a future version. Use the Update(WaitUntil, ContainerRegistryTaskPatch, CancellationToken) overload instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryTaskResource> Update(ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        [Obsolete("This method is obsolete and will be removed in a future version. Use the UpdateAsync(WaitUntil, ContainerRegistryTaskPatch, CancellationToken) overload instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryTaskResource>> UpdateAsync(ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryTaskResource> AddTag(string key, string value, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryTaskResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryTaskResource> RemoveTag(string key, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryTaskResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryTaskResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryTaskResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryTaskResource> GetDetails(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryTaskResource>> GetDetailsAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryTaskData
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskData : TrackedResourceData, IJsonModel<ContainerRegistryTaskData>, IPersistableModel<ContainerRegistryTaskData>
    {
        ContainerRegistryTaskData IJsonModel<ContainerRegistryTaskData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTaskData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTaskData IPersistableModel<ContainerRegistryTaskData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTaskData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryTaskData(AzureLocation location) : base(location) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }

        [WirePath("identity")]
        public ManagedServiceIdentity Identity { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.provisioningState")]
        public ContainerRegistryProvisioningState? ProvisioningState { get { throw new NotSupportedException(); } }
        [WirePath("properties.creationDate")]
        public DateTimeOffset? CreatedOn { get { throw new NotSupportedException(); } }
        [WirePath("properties.status")]
        public ContainerRegistryTaskStatus? Status { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.platform")]
        public ContainerRegistryPlatformProperties Platform { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.agentConfiguration.cpu")]
        public int? AgentCpu { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.agentPoolName")]
        public string AgentPoolName { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.timeout")]
        public int? TimeoutInSeconds { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.step")]
        public ContainerRegistryTaskStepProperties Step { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.trigger")]
        public ContainerRegistryTriggerProperties Trigger { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.credentials")]
        public ContainerRegistryCredentials Credentials { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.logTemplate")]
        public string LogTemplate { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.isSystemTask")]
        public bool? IsSystemTask { get { throw new NotSupportedException(); } set { } }
    }
}
