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
    //  ContainerRegistryRunCollection
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryRunCollection : ArmCollection, IEnumerable<ContainerRegistryRunResource>, IAsyncEnumerable<ContainerRegistryRunResource>
    {
        protected ContainerRegistryRunCollection() : base() { }

        public virtual Response<bool> Exists(string runId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<bool>> ExistsAsync(string runId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryRunResource> Get(string runId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryRunResource>> GetAsync(string runId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Pageable<ContainerRegistryRunResource> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual AsyncPageable<ContainerRegistryRunResource> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual NullableResponse<ContainerRegistryRunResource> GetIfExists(string runId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<NullableResponse<ContainerRegistryRunResource>> GetIfExistsAsync(string runId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

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
        ContainerRegistryRunData IJsonModel<ContainerRegistryRunData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryRunData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryRunData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryRunData IPersistableModel<ContainerRegistryRunData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryRunData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public static readonly ResourceType ResourceType;

        protected ContainerRegistryRunResource() : base() { }

        [WirePath("")]
        public virtual ContainerRegistryRunData Data { get { throw new NotSupportedException(); } }
        [WirePath("")]
        public virtual bool HasData { get { throw new NotSupportedException(); } }

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string runId) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryRunResource> Get(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryRunResource>> GetAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual ArmOperation Cancel(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<ArmOperation> CancelAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        [Obsolete("This method is obsolete and will be removed in a future version. Use the Cancel(WaitUntil, CancellationToken) overload instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Cancel(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        [Obsolete("This method is obsolete and will be removed in a future version. Use the CancelAsync(WaitUntil, CancellationToken) overload instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response> CancelAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual ArmOperation<ContainerRegistryRunResource> Update(WaitUntil waitUntil, ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<ArmOperation<ContainerRegistryRunResource>> UpdateAsync(WaitUntil waitUntil, ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        [Obsolete("This method is obsolete and will be removed in a future version. Use the Update(WaitUntil, ContainerRegistryRunPatch, CancellationToken) overload instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryRunResource> Update(ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        [Obsolete("This method is obsolete and will be removed in a future version. Use the UpdateAsync(WaitUntil, ContainerRegistryRunPatch, CancellationToken) overload instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryRunResource>> UpdateAsync(ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryRunGetLogResult> GetLogSasUrl(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryRunGetLogResult>> GetLogSasUrlAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryRunData
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryRunData : ResourceData, IJsonModel<ContainerRegistryRunData>, IPersistableModel<ContainerRegistryRunData>
    {
        ContainerRegistryRunData IJsonModel<ContainerRegistryRunData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryRunData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryRunData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryRunData IPersistableModel<ContainerRegistryRunData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryRunData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryRunData() { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }

        [WirePath("properties.runId")]
        public string RunId { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.status")]
        public ContainerRegistryRunStatus? Status { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.lastUpdatedTime")]
        public DateTimeOffset? LastUpdatedOn { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.runType")]
        public ContainerRegistryRunType? RunType { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.task")]
        public string Task { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.createTime")]
        public DateTimeOffset? CreatedOn { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.startTime")]
        public DateTimeOffset? StartOn { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.finishTime")]
        public DateTimeOffset? FinishOn { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.outputImages")]
        public IList<ContainerRegistryImageDescriptor> OutputImages { get { throw new NotSupportedException(); } }
        [WirePath("properties.runErrorMessage")]
        public string RunErrorMessage { get { throw new NotSupportedException(); } }
        [WirePath("properties.updateTriggerToken")]
        public string UpdateTriggerToken { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.imageUpdateTrigger")]
        public ContainerRegistryImageUpdateTrigger ImageUpdateTrigger { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.sourceTrigger")]
        public ContainerRegistrySourceTriggerDescriptor SourceTrigger { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.timerTrigger")]
        public ContainerRegistryTimerTriggerDescriptor TimerTrigger { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.platform")]
        public ContainerRegistryPlatformProperties Platform { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.agentConfiguration.cpu")]
        public int? AgentCpu { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.agentPoolName")]
        public string AgentPoolName { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.sourceRegistryAuth")]
        public string SourceRegistryAuth { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.customRegistries")]
        public IList<string> CustomRegistries { get { throw new NotSupportedException(); } }
        [WirePath("properties.logArtifact")]
        public ContainerRegistryImageDescriptor LogArtifact { get { throw new NotSupportedException(); } }
        [WirePath("properties.provisioningState")]
        public ContainerRegistryProvisioningState? ProvisioningState { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.isArchiveEnabled")]
        public bool? IsArchiveEnabled { get { throw new NotSupportedException(); } set { } }
    }
}
