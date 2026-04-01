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
}
