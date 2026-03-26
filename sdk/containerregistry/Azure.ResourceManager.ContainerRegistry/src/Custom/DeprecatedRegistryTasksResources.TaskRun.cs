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
    //  ContainerRegistryTaskRunCollection
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskRunCollection : ArmCollection, IEnumerable<ContainerRegistryTaskRunResource>, IAsyncEnumerable<ContainerRegistryTaskRunResource>
    {
        protected ContainerRegistryTaskRunCollection() : base() { }

        public virtual Response<bool> Exists(string taskRunName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<bool>> ExistsAsync(string taskRunName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryTaskRunResource> Get(string taskRunName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryTaskRunResource>> GetAsync(string taskRunName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Pageable<ContainerRegistryTaskRunResource> GetAll(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual AsyncPageable<ContainerRegistryTaskRunResource> GetAllAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual NullableResponse<ContainerRegistryTaskRunResource> GetIfExists(string taskRunName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<NullableResponse<ContainerRegistryTaskRunResource>> GetIfExistsAsync(string taskRunName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual ArmOperation<ContainerRegistryTaskRunResource> CreateOrUpdate(WaitUntil waitUntil, string taskRunName, ContainerRegistryTaskRunData data, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<ArmOperation<ContainerRegistryTaskRunResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string taskRunName, ContainerRegistryTaskRunData data, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

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
        ContainerRegistryTaskRunData IJsonModel<ContainerRegistryTaskRunData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTaskRunData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskRunData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTaskRunData IPersistableModel<ContainerRegistryTaskRunData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTaskRunData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public static readonly ResourceType ResourceType;

        protected ContainerRegistryTaskRunResource() : base() { }

        [WirePath("")]
        public virtual ContainerRegistryTaskRunData Data { get { throw new NotSupportedException(); } }
        [WirePath("")]
        public virtual bool HasData { get { throw new NotSupportedException(); } }

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskRunName) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryTaskRunResource> Get(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryTaskRunResource>> GetAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual ArmOperation<ContainerRegistryTaskRunResource> Update(WaitUntil waitUntil, ContainerRegistryTaskRunPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<ArmOperation<ContainerRegistryTaskRunResource>> UpdateAsync(WaitUntil waitUntil, ContainerRegistryTaskRunPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryTaskRunResource> GetDetails(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryTaskRunResource>> GetDetailsAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
    }

    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryTaskRunData
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskRunData : ResourceData, IJsonModel<ContainerRegistryTaskRunData>, IPersistableModel<ContainerRegistryTaskRunData>
    {
        ContainerRegistryTaskRunData IJsonModel<ContainerRegistryTaskRunData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTaskRunData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskRunData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTaskRunData IPersistableModel<ContainerRegistryTaskRunData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTaskRunData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryTaskRunData() { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }

        [WirePath("identity")]
        public ManagedServiceIdentity Identity { get { throw new NotSupportedException(); } set { } }
        [WirePath("location")]
        public AzureLocation? Location { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.provisioningState")]
        public ContainerRegistryProvisioningState? ProvisioningState { get { throw new NotSupportedException(); } }
        [WirePath("properties.runRequest")]
        public ContainerRegistryRunContent RunRequest { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.runResult")]
        public ContainerRegistryRunData RunResult { get { throw new NotSupportedException(); } }
        [WirePath("properties.forceUpdateTag")]
        public string ForceUpdateTag { get { throw new NotSupportedException(); } set { } }
    }
}
