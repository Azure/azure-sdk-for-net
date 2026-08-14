// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
    /// <summary>
    /// A class representing a Run along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="ContainerRegistryRunResource"/> from an instance of <see cref="ArmClient"/> using the GetResource method.
    /// Otherwise you can get one from its parent resource resource group using the GetRuns method.
    /// </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryRunResource : ArmResource, IJsonModel<ContainerRegistryRunData>, IPersistableModel<ContainerRegistryRunData>
    {
        /// <summary> Creates an instance of <see cref="ContainerRegistryRunResource"/> from the provided JSON reader. </summary>
        /// <param name="reader"> The JSON reader containing the serialized model. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryRunResource"/> instance. </returns>
        ContainerRegistryRunData IJsonModel<ContainerRegistryRunData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Writes the current <see cref="ContainerRegistryRunResource"/> instance to the provided JSON writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        void IJsonModel<ContainerRegistryRunData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Writes the current <see cref="ContainerRegistryRunResource"/> instance to a binary payload. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A binary representation of this <see cref="ContainerRegistryRunResource"/> instance. </returns>
        BinaryData IPersistableModel<ContainerRegistryRunData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Creates an instance of <see cref="ContainerRegistryRunResource"/> from the provided binary payload. </summary>
        /// <param name="data"> The serialized data to read from. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryRunResource"/> instance. </returns>
        ContainerRegistryRunData IPersistableModel<ContainerRegistryRunData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets the wire format used for this <see cref="ContainerRegistryRunResource"/> instance with the provided options. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> The format string used for persistence. </returns>
        string IPersistableModel<ContainerRegistryRunData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType;

        /// <summary> Initializes a new instance of <see cref="ContainerRegistryRunResource"/> for mocking. </summary>
        protected ContainerRegistryRunResource() : base() { }

        /// <summary> Gets the resource data for this run. </summary>
        [WirePath("")]
        public virtual ContainerRegistryRunData Data { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
        /// <summary> Gets a value indicating whether this resource has data. </summary>
        [WirePath("")]
        public virtual bool HasData { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }

        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="registryName"> The registryName. </param>
        /// <param name="runId"> The runId. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string runId) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Gets the detailed information for a given run.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Get. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryRunResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ContainerRegistryRunResource> Get(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Gets the detailed information for a given run.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Get. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryRunResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<ContainerRegistryRunResource>> GetAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Cancel an existing run.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}/cancel. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Cancel. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryRunResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Cancel(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Cancel an existing run.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}/cancel. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Cancel. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryRunResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation> CancelAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Cancel an existing run.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}/cancel. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Cancel. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryRunResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future version. Use the Cancel(WaitUntil, CancellationToken) overload instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Cancel(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Cancel an existing run.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}/cancel. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Cancel. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryRunResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future version. Use the CancelAsync(WaitUntil, CancellationToken) overload instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response> CancelAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Patch the run properties.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Update. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryRunResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="patch"> The run update properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual ArmOperation<ContainerRegistryRunResource> Update(WaitUntil waitUntil, ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Patch the run properties.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Update. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryRunResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="patch"> The run update properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Task<ArmOperation<ContainerRegistryRunResource>> UpdateAsync(WaitUntil waitUntil, ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Patch the run properties.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Update. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryRunResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The run update properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future version. Use the Update(WaitUntil, ContainerRegistryRunPatch, CancellationToken) overload instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryRunResource> Update(ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Patch the run properties.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_Update. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryRunResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The run update properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future version. Use the UpdateAsync(WaitUntil, ContainerRegistryRunPatch, CancellationToken) overload instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryRunResource>> UpdateAsync(ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Gets a link to download the run logs.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}/listLogSasUrl. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_GetLogSasUrl. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryRunResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ContainerRegistryRunGetLogResult> GetLogSasUrl(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Gets a link to download the run logs.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}/listLogSasUrl. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Runs_GetLogSasUrl. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryRunResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<ContainerRegistryRunGetLogResult>> GetLogSasUrlAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
    }
}
