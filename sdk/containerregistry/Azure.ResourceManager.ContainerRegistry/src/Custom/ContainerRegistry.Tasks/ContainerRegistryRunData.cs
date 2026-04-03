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
    /// <summary> Run resource properties. </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryRunData : ResourceData, IJsonModel<ContainerRegistryRunData>, IPersistableModel<ContainerRegistryRunData>
    {
        /// <summary> Creates an instance of <see cref="ContainerRegistryRunData"/> from the provided JSON reader. </summary>
        /// <param name="reader"> The JSON reader containing the serialized model. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryRunData"/> instance. </returns>
        ContainerRegistryRunData IJsonModel<ContainerRegistryRunData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Writes the current <see cref="ContainerRegistryRunData"/> instance to the provided JSON writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        void IJsonModel<ContainerRegistryRunData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Writes the current <see cref="ContainerRegistryRunData"/> instance to a binary payload. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A binary representation of this <see cref="ContainerRegistryRunData"/> instance. </returns>
        BinaryData IPersistableModel<ContainerRegistryRunData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Creates an instance of <see cref="ContainerRegistryRunData"/> from the provided binary payload. </summary>
        /// <param name="data"> The serialized data to read from. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryRunData"/> instance. </returns>
        ContainerRegistryRunData IPersistableModel<ContainerRegistryRunData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets the wire format used for this <see cref="ContainerRegistryRunData"/> instance with the provided options. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> The format string used for persistence. </returns>
        string IPersistableModel<ContainerRegistryRunData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryRunData"/>. </summary>
        public ContainerRegistryRunData() { }
        /// <summary> Writes the JSON representation of this instance to the provided writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }

        /// <summary> The run identifier. </summary>
        [WirePath("properties.runId")]
        public string RunId { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The current status of the run. </summary>
        [WirePath("properties.status")]
        public ContainerRegistryRunStatus? Status { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The last time the run was updated. </summary>
        [WirePath("properties.lastUpdatedTime")]
        public DateTimeOffset? LastUpdatedOn { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The type of run. </summary>
        [WirePath("properties.runType")]
        public ContainerRegistryRunType? RunType { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The task associated with this run. </summary>
        [WirePath("properties.task")]
        public string Task { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The time when the run was created. </summary>
        [WirePath("properties.createTime")]
        public DateTimeOffset? CreatedOn { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The time when the run started. </summary>
        [WirePath("properties.startTime")]
        public DateTimeOffset? StartOn { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The time when the run finished. </summary>
        [WirePath("properties.finishTime")]
        public DateTimeOffset? FinishOn { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The images produced by the run. </summary>
        [WirePath("properties.outputImages")]
        public IList<ContainerRegistryImageDescriptor> OutputImages { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
        /// <summary> The error message produced by the run, if any. </summary>
        [WirePath("properties.runErrorMessage")]
        public string RunErrorMessage { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
        /// <summary> The update trigger token associated with the run. </summary>
        [WirePath("properties.updateTriggerToken")]
        public string UpdateTriggerToken { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The image update trigger that caused the run. </summary>
        [WirePath("properties.imageUpdateTrigger")]
        public ContainerRegistryImageUpdateTrigger ImageUpdateTrigger { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The source trigger that caused the run. </summary>
        [WirePath("properties.sourceTrigger")]
        public ContainerRegistrySourceTriggerDescriptor SourceTrigger { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The timer trigger that caused the run. </summary>
        [WirePath("properties.timerTrigger")]
        public ContainerRegistryTimerTriggerDescriptor TimerTrigger { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The platform used for the run. </summary>
        [WirePath("properties.platform")]
        public ContainerRegistryPlatformProperties Platform { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The CPU count configured for the agent. </summary>
        [WirePath("properties.agentConfiguration.cpu")]
        public int? AgentCpu { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The name of the agent pool used for the run. </summary>
        [WirePath("properties.agentPoolName")]
        public string AgentPoolName { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The authentication mode used for the source registry. </summary>
        [WirePath("properties.sourceRegistryAuth")]
        public string SourceRegistryAuth { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The custom registries referenced by the run. </summary>
        [WirePath("properties.customRegistries")]
        public IList<string> CustomRegistries { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
        /// <summary> The log artifact generated for the run. </summary>
        [WirePath("properties.logArtifact")]
        public ContainerRegistryImageDescriptor LogArtifact { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
        /// <summary> The provisioning state of the run. </summary>
        [WirePath("properties.provisioningState")]
        public ContainerRegistryProvisioningState? ProvisioningState { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> Indicates whether archival is enabled for the run. </summary>
        [WirePath("properties.isArchiveEnabled")]
        public bool? IsArchiveEnabled { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
    }
}
