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
    /// The task that has the ARM resource and task properties.
    /// The task will have all information to schedule a run against it.
    /// </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskData : TrackedResourceData, IJsonModel<ContainerRegistryTaskData>, IPersistableModel<ContainerRegistryTaskData>
    {
        /// <summary> Creates an instance of <see cref="ContainerRegistryTaskData"/> from the provided JSON reader. </summary>
        /// <param name="reader"> The JSON reader containing the serialized model. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryTaskData"/> instance. </returns>
        ContainerRegistryTaskData IJsonModel<ContainerRegistryTaskData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Writes the current <see cref="ContainerRegistryTaskData"/> instance to the provided JSON writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        void IJsonModel<ContainerRegistryTaskData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Writes the current <see cref="ContainerRegistryTaskData"/> instance to a binary payload. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A binary representation of this <see cref="ContainerRegistryTaskData"/> instance. </returns>
        BinaryData IPersistableModel<ContainerRegistryTaskData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Creates an instance of <see cref="ContainerRegistryTaskData"/> from the provided binary payload. </summary>
        /// <param name="data"> The serialized data to read from. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryTaskData"/> instance. </returns>
        ContainerRegistryTaskData IPersistableModel<ContainerRegistryTaskData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets the wire format used for this <see cref="ContainerRegistryTaskData"/> instance with the provided options. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> The format string used for persistence. </returns>
        string IPersistableModel<ContainerRegistryTaskData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryTaskData"/>. </summary>
        /// <param name="location"> The location of the resource. </param>
        public ContainerRegistryTaskData(AzureLocation location) : base(location) { }
        /// <summary> Writes the JSON representation of this instance to the provided writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }

        /// <summary> Identity for the resource. </summary>
        [WirePath("identity")]
        public ManagedServiceIdentity Identity { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The provisioning state of the task. </summary>
        [WirePath("properties.provisioningState")]
        public ContainerRegistryProvisioningState? ProvisioningState { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
        /// <summary> The time when the task was created. </summary>
        [WirePath("properties.creationDate")]
        public DateTimeOffset? CreatedOn { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
        /// <summary> The current status of the task. </summary>
        [WirePath("properties.status")]
        public ContainerRegistryTaskStatus? Status { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The platform configuration for the task. </summary>
        [WirePath("properties.platform")]
        public ContainerRegistryPlatformProperties Platform { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The CPU count configured for the task agent. </summary>
        [WirePath("properties.agentConfiguration.cpu")]
        public int? AgentCpu { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The name of the agent pool used by the task. </summary>
        [WirePath("properties.agentPoolName")]
        public string AgentPoolName { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The task timeout in seconds. </summary>
        [WirePath("properties.timeout")]
        public int? TimeoutInSeconds { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The step definition for the task. </summary>
        [WirePath("properties.step")]
        public ContainerRegistryTaskStepProperties Step { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The trigger configuration for the task. </summary>
        [WirePath("properties.trigger")]
        public ContainerRegistryTriggerProperties Trigger { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The credentials used by the task. </summary>
        [WirePath("properties.credentials")]
        public ContainerRegistryCredentials Credentials { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The log template used by the task. </summary>
        [WirePath("properties.logTemplate")]
        public string LogTemplate { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> Indicates whether the task is a system task. </summary>
        [WirePath("properties.isSystemTask")]
        public bool? IsSystemTask { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
    }
}
