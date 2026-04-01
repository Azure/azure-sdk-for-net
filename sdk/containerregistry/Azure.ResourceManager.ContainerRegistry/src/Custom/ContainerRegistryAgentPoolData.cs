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
