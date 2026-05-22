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
    /// The agentpool that has the ARM resource and properties.
    /// The agentpool will have all information to create an agent pool.
    /// </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryAgentPoolData : TrackedResourceData, IJsonModel<ContainerRegistryAgentPoolData>, IPersistableModel<ContainerRegistryAgentPoolData>
    {
        /// <summary> Creates an instance of <see cref="ContainerRegistryAgentPoolData"/> from the provided JSON reader. </summary>
        /// <param name="reader"> The JSON reader containing the serialized model. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryAgentPoolData"/> instance. </returns>
        ContainerRegistryAgentPoolData IJsonModel<ContainerRegistryAgentPoolData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Writes the current <see cref="ContainerRegistryAgentPoolData"/> instance to the provided JSON writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        void IJsonModel<ContainerRegistryAgentPoolData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Writes the current <see cref="ContainerRegistryAgentPoolData"/> instance to a binary payload. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A binary representation of this <see cref="ContainerRegistryAgentPoolData"/> instance. </returns>
        BinaryData IPersistableModel<ContainerRegistryAgentPoolData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Creates an instance of <see cref="ContainerRegistryAgentPoolData"/> from the provided binary payload. </summary>
        /// <param name="data"> The serialized data to read from. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryAgentPoolData"/> instance. </returns>
        ContainerRegistryAgentPoolData IPersistableModel<ContainerRegistryAgentPoolData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets the wire format used for this <see cref="ContainerRegistryAgentPoolData"/> instance with the provided options. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> The format string used for persistence. </returns>
        string IPersistableModel<ContainerRegistryAgentPoolData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryAgentPoolData"/>. </summary>
        /// <param name="location"> The location of the resource. </param>
        public ContainerRegistryAgentPoolData(AzureLocation location) : base(location) { }
        /// <summary> Writes the JSON representation of this instance to the provided writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }

        /// <summary> The number of agent machines in the agent pool. </summary>
        [WirePath("properties.count")]
        public int? Count { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The SKU tier of the agent pool. </summary>
        [WirePath("properties.tier")]
        public string Tier { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The operating system of the agent pool. </summary>
        [WirePath("properties.os")]
        public ContainerRegistryOS? OS { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The virtual network subnet resource ID used by the agent pool. </summary>
        [WirePath("properties.virtualNetworkSubnetResourceId")]
        public ResourceIdentifier VirtualNetworkSubnetResourceId { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> The provisioning state of the agent pool. </summary>
        [WirePath("properties.provisioningState")]
        public ContainerRegistryProvisioningState? ProvisioningState { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
    }
}
