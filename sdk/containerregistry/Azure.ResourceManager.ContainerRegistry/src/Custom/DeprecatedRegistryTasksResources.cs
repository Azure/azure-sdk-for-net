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

        public virtual Response<bool> Exists(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<bool>> ExistsAsync(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryAgentPoolResource> Get(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryAgentPoolResource>> GetAsync(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Pageable<ContainerRegistryAgentPoolResource> GetAll(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual AsyncPageable<ContainerRegistryAgentPoolResource> GetAllAsync(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual NullableResponse<ContainerRegistryAgentPoolResource> GetIfExists(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<NullableResponse<ContainerRegistryAgentPoolResource>> GetIfExistsAsync(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual ArmOperation<ContainerRegistryAgentPoolResource> CreateOrUpdate(WaitUntil waitUntil, string agentPoolName, ContainerRegistryAgentPoolData data, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<ArmOperation<ContainerRegistryAgentPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string agentPoolName, ContainerRegistryAgentPoolData data, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
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
        ContainerRegistryAgentPoolData IJsonModel<ContainerRegistryAgentPoolData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotImplementedException();
        void IJsonModel<ContainerRegistryAgentPoolData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryAgentPoolData>.Write(ModelReaderWriterOptions options) => throw new NotImplementedException();
        ContainerRegistryAgentPoolData IPersistableModel<ContainerRegistryAgentPoolData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotImplementedException();
        string IPersistableModel<ContainerRegistryAgentPoolData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotImplementedException();
        public static readonly ResourceType ResourceType;

        protected ContainerRegistryAgentPoolResource() : base() { }

        [WirePath("")]
        public virtual ContainerRegistryAgentPoolData Data { get { throw new NotImplementedException(); } }
        [WirePath("")]
        public virtual bool HasData { get { throw new NotImplementedException(); } }

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string agentPoolName) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryAgentPoolResource> Get(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryAgentPoolResource>> GetAsync(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual ArmOperation<ContainerRegistryAgentPoolResource> Update(WaitUntil waitUntil, ContainerRegistryAgentPoolPatch patch, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<ArmOperation<ContainerRegistryAgentPoolResource>> UpdateAsync(WaitUntil waitUntil, ContainerRegistryAgentPoolPatch patch, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryAgentPoolResource> AddTag(string key, string value, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryAgentPoolResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryAgentPoolResource> RemoveTag(string key, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryAgentPoolResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryAgentPoolResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryAgentPoolResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryAgentPoolQueueStatus> GetQueueStatus(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryAgentPoolQueueStatus>> GetQueueStatusAsync(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryAgentPoolData
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryAgentPoolData : TrackedResourceData, IJsonModel<ContainerRegistryAgentPoolData>, IPersistableModel<ContainerRegistryAgentPoolData>
    {
        ContainerRegistryAgentPoolData IJsonModel<ContainerRegistryAgentPoolData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotImplementedException();
        void IJsonModel<ContainerRegistryAgentPoolData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryAgentPoolData>.Write(ModelReaderWriterOptions options) => throw new NotImplementedException();
        ContainerRegistryAgentPoolData IPersistableModel<ContainerRegistryAgentPoolData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotImplementedException();
        string IPersistableModel<ContainerRegistryAgentPoolData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotImplementedException();
        public ContainerRegistryAgentPoolData(AzureLocation location) : base(location) { }

        [WirePath("properties.count")]
        public int? Count { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.tier")]
        public string Tier { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.os")]
        public ContainerRegistryOS? OS { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.virtualNetworkSubnetResourceId")]
        public ResourceIdentifier VirtualNetworkSubnetResourceId { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.provisioningState")]
        public ContainerRegistryProvisioningState? ProvisioningState { get { throw new NotImplementedException(); } }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryRunCollection
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryRunCollection : ArmCollection, IEnumerable<ContainerRegistryRunResource>, IAsyncEnumerable<ContainerRegistryRunResource>
    {
        protected ContainerRegistryRunCollection() : base() { }

        public virtual Response<bool> Exists(string runId, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<bool>> ExistsAsync(string runId, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryRunResource> Get(string runId, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryRunResource>> GetAsync(string runId, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Pageable<ContainerRegistryRunResource> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual AsyncPageable<ContainerRegistryRunResource> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual NullableResponse<ContainerRegistryRunResource> GetIfExists(string runId, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<NullableResponse<ContainerRegistryRunResource>> GetIfExistsAsync(string runId, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }

        IEnumerator<ContainerRegistryRunResource> IEnumerable<ContainerRegistryRunResource>.GetEnumerator() { return GetAll().GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetAll().GetEnumerator(); }
        IAsyncEnumerator<ContainerRegistryRunResource> IAsyncEnumerable<ContainerRegistryRunResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken); }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryRunResource
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryRunResource : ArmResource, IJsonModel<ContainerRegistryRunData>, IPersistableModel<ContainerRegistryRunData>
    {
        ContainerRegistryRunData IJsonModel<ContainerRegistryRunData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotImplementedException();
        void IJsonModel<ContainerRegistryRunData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryRunData>.Write(ModelReaderWriterOptions options) => throw new NotImplementedException();
        ContainerRegistryRunData IPersistableModel<ContainerRegistryRunData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotImplementedException();
        string IPersistableModel<ContainerRegistryRunData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotImplementedException();
        public static readonly ResourceType ResourceType;

        protected ContainerRegistryRunResource() : base() { }

        [WirePath("")]
        public virtual ContainerRegistryRunData Data { get { throw new NotImplementedException(); } }
        [WirePath("")]
        public virtual bool HasData { get { throw new NotImplementedException(); } }

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string runId) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryRunResource> Get(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryRunResource>> GetAsync(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual ArmOperation Cancel(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<ArmOperation> CancelAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual ArmOperation<ContainerRegistryRunResource> Update(WaitUntil waitUntil, ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<ArmOperation<ContainerRegistryRunResource>> UpdateAsync(WaitUntil waitUntil, ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryRunGetLogResult> GetLogSasUrl(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryRunGetLogResult>> GetLogSasUrlAsync(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryRunData
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryRunData : ResourceData, IJsonModel<ContainerRegistryRunData>, IPersistableModel<ContainerRegistryRunData>
    {
        ContainerRegistryRunData IJsonModel<ContainerRegistryRunData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotImplementedException();
        void IJsonModel<ContainerRegistryRunData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryRunData>.Write(ModelReaderWriterOptions options) => throw new NotImplementedException();
        ContainerRegistryRunData IPersistableModel<ContainerRegistryRunData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotImplementedException();
        string IPersistableModel<ContainerRegistryRunData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotImplementedException();
        public ContainerRegistryRunData() { }

        [WirePath("properties.runId")]
        public string RunId { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.status")]
        public ContainerRegistryRunStatus? Status { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.lastUpdatedTime")]
        public DateTimeOffset? LastUpdatedOn { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.runType")]
        public ContainerRegistryRunType? RunType { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.task")]
        public string Task { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.createTime")]
        public DateTimeOffset? CreatedOn { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.startTime")]
        public DateTimeOffset? StartOn { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.finishTime")]
        public DateTimeOffset? FinishOn { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.outputImages")]
        public IList<ContainerRegistryImageDescriptor> OutputImages { get { throw new NotImplementedException(); } }
        [WirePath("properties.runErrorMessage")]
        public string RunErrorMessage { get { throw new NotImplementedException(); } }
        [WirePath("properties.updateTriggerToken")]
        public string UpdateTriggerToken { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.imageUpdateTrigger")]
        public ContainerRegistryImageUpdateTrigger ImageUpdateTrigger { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.sourceTrigger")]
        public ContainerRegistrySourceTriggerDescriptor SourceTrigger { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.timerTrigger")]
        public ContainerRegistryTimerTriggerDescriptor TimerTrigger { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.platform")]
        public ContainerRegistryPlatformProperties Platform { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.agentConfiguration.cpu")]
        public int? AgentCpu { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.agentPoolName")]
        public string AgentPoolName { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.sourceRegistryAuth")]
        public string SourceRegistryAuth { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.customRegistries")]
        public IList<string> CustomRegistries { get { throw new NotImplementedException(); } }
        [WirePath("properties.logArtifact")]
        public ContainerRegistryImageDescriptor LogArtifact { get { throw new NotImplementedException(); } }
        [WirePath("properties.provisioningState")]
        public ContainerRegistryProvisioningState? ProvisioningState { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.isArchiveEnabled")]
        public bool? IsArchiveEnabled { get { throw new NotImplementedException(); } set { } }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryTaskCollection
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskCollection : ArmCollection, IEnumerable<ContainerRegistryTaskResource>, IAsyncEnumerable<ContainerRegistryTaskResource>
    {
        protected ContainerRegistryTaskCollection() : base() { }

        public virtual Response<bool> Exists(string taskName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<bool>> ExistsAsync(string taskName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryTaskResource> Get(string taskName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryTaskResource>> GetAsync(string taskName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Pageable<ContainerRegistryTaskResource> GetAll(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual AsyncPageable<ContainerRegistryTaskResource> GetAllAsync(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual NullableResponse<ContainerRegistryTaskResource> GetIfExists(string taskName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<NullableResponse<ContainerRegistryTaskResource>> GetIfExistsAsync(string taskName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual ArmOperation<ContainerRegistryTaskResource> CreateOrUpdate(WaitUntil waitUntil, string taskName, ContainerRegistryTaskData data, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<ArmOperation<ContainerRegistryTaskResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string taskName, ContainerRegistryTaskData data, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }

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
        ContainerRegistryTaskData IJsonModel<ContainerRegistryTaskData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotImplementedException();
        void IJsonModel<ContainerRegistryTaskData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskData>.Write(ModelReaderWriterOptions options) => throw new NotImplementedException();
        ContainerRegistryTaskData IPersistableModel<ContainerRegistryTaskData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotImplementedException();
        string IPersistableModel<ContainerRegistryTaskData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotImplementedException();
        public static readonly ResourceType ResourceType;

        protected ContainerRegistryTaskResource() : base() { }

        [WirePath("")]
        public virtual ContainerRegistryTaskData Data { get { throw new NotImplementedException(); } }
        [WirePath("")]
        public virtual bool HasData { get { throw new NotImplementedException(); } }

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskName) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryTaskResource> Get(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryTaskResource>> GetAsync(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual ArmOperation<ContainerRegistryTaskResource> Update(WaitUntil waitUntil, ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<ArmOperation<ContainerRegistryTaskResource>> UpdateAsync(WaitUntil waitUntil, ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryTaskResource> AddTag(string key, string value, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryTaskResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryTaskResource> RemoveTag(string key, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryTaskResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryTaskResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryTaskResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryTaskResource> GetDetails(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryTaskResource>> GetDetailsAsync(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryTaskData
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskData : TrackedResourceData, IJsonModel<ContainerRegistryTaskData>, IPersistableModel<ContainerRegistryTaskData>
    {
        ContainerRegistryTaskData IJsonModel<ContainerRegistryTaskData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotImplementedException();
        void IJsonModel<ContainerRegistryTaskData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskData>.Write(ModelReaderWriterOptions options) => throw new NotImplementedException();
        ContainerRegistryTaskData IPersistableModel<ContainerRegistryTaskData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotImplementedException();
        string IPersistableModel<ContainerRegistryTaskData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotImplementedException();
        public ContainerRegistryTaskData(AzureLocation location) : base(location) { }

        [WirePath("identity")]
        public ManagedServiceIdentity Identity { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.provisioningState")]
        public ContainerRegistryProvisioningState? ProvisioningState { get { throw new NotImplementedException(); } }
        [WirePath("properties.creationDate")]
        public DateTimeOffset? CreatedOn { get { throw new NotImplementedException(); } }
        [WirePath("properties.status")]
        public ContainerRegistryTaskStatus? Status { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.platform")]
        public ContainerRegistryPlatformProperties Platform { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.agentConfiguration.cpu")]
        public int? AgentCpu { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.agentPoolName")]
        public string AgentPoolName { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.timeout")]
        public int? TimeoutInSeconds { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.step")]
        public ContainerRegistryTaskStepProperties Step { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.trigger")]
        public ContainerRegistryTriggerProperties Trigger { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.credentials")]
        public ContainerRegistryCredentials Credentials { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.logTemplate")]
        public string LogTemplate { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.isSystemTask")]
        public bool? IsSystemTask { get { throw new NotImplementedException(); } set { } }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryTaskRunCollection
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskRunCollection : ArmCollection, IEnumerable<ContainerRegistryTaskRunResource>, IAsyncEnumerable<ContainerRegistryTaskRunResource>
    {
        protected ContainerRegistryTaskRunCollection() : base() { }

        public virtual Response<bool> Exists(string taskRunName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<bool>> ExistsAsync(string taskRunName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryTaskRunResource> Get(string taskRunName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryTaskRunResource>> GetAsync(string taskRunName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Pageable<ContainerRegistryTaskRunResource> GetAll(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual AsyncPageable<ContainerRegistryTaskRunResource> GetAllAsync(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual NullableResponse<ContainerRegistryTaskRunResource> GetIfExists(string taskRunName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<NullableResponse<ContainerRegistryTaskRunResource>> GetIfExistsAsync(string taskRunName, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual ArmOperation<ContainerRegistryTaskRunResource> CreateOrUpdate(WaitUntil waitUntil, string taskRunName, ContainerRegistryTaskRunData data, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<ArmOperation<ContainerRegistryTaskRunResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string taskRunName, ContainerRegistryTaskRunData data, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }

        IEnumerator<ContainerRegistryTaskRunResource> IEnumerable<ContainerRegistryTaskRunResource>.GetEnumerator() { return GetAll().GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetAll().GetEnumerator(); }
        IAsyncEnumerator<ContainerRegistryTaskRunResource> IAsyncEnumerable<ContainerRegistryTaskRunResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken); }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryTaskRunResource
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskRunResource : ArmResource, IJsonModel<ContainerRegistryTaskRunData>, IPersistableModel<ContainerRegistryTaskRunData>
    {
        ContainerRegistryTaskRunData IJsonModel<ContainerRegistryTaskRunData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotImplementedException();
        void IJsonModel<ContainerRegistryTaskRunData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskRunData>.Write(ModelReaderWriterOptions options) => throw new NotImplementedException();
        ContainerRegistryTaskRunData IPersistableModel<ContainerRegistryTaskRunData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotImplementedException();
        string IPersistableModel<ContainerRegistryTaskRunData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotImplementedException();
        public static readonly ResourceType ResourceType;

        protected ContainerRegistryTaskRunResource() : base() { }

        [WirePath("")]
        public virtual ContainerRegistryTaskRunData Data { get { throw new NotImplementedException(); } }
        [WirePath("")]
        public virtual bool HasData { get { throw new NotImplementedException(); } }

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskRunName) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryTaskRunResource> Get(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryTaskRunResource>> GetAsync(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual ArmOperation<ContainerRegistryTaskRunResource> Update(WaitUntil waitUntil, ContainerRegistryTaskRunPatch patch, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<ArmOperation<ContainerRegistryTaskRunResource>> UpdateAsync(WaitUntil waitUntil, ContainerRegistryTaskRunPatch patch, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Response<ContainerRegistryTaskRunResource> GetDetails(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
        public virtual Task<Response<ContainerRegistryTaskRunResource>> GetDetailsAsync(CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryTaskRunData
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskRunData : ResourceData, IJsonModel<ContainerRegistryTaskRunData>, IPersistableModel<ContainerRegistryTaskRunData>
    {
        ContainerRegistryTaskRunData IJsonModel<ContainerRegistryTaskRunData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotImplementedException();
        void IJsonModel<ContainerRegistryTaskRunData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskRunData>.Write(ModelReaderWriterOptions options) => throw new NotImplementedException();
        ContainerRegistryTaskRunData IPersistableModel<ContainerRegistryTaskRunData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotImplementedException();
        string IPersistableModel<ContainerRegistryTaskRunData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotImplementedException();
        public ContainerRegistryTaskRunData() { }

        [WirePath("identity")]
        public ManagedServiceIdentity Identity { get { throw new NotImplementedException(); } set { } }
        [WirePath("location")]
        public AzureLocation? Location { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.provisioningState")]
        public ContainerRegistryProvisioningState? ProvisioningState { get { throw new NotImplementedException(); } }
        [WirePath("properties.runRequest")]
        public ContainerRegistryRunContent RunRequest { get { throw new NotImplementedException(); } set { } }
        [WirePath("properties.runResult")]
        public ContainerRegistryRunData RunResult { get { throw new NotImplementedException(); } }
        [WirePath("properties.forceUpdateTag")]
        public string ForceUpdateTag { get { throw new NotImplementedException(); } set { } }
    }
}
