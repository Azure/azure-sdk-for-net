// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for CapabilitiesCapabilities. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerSupportedCapabilities : CapabilitiesCapabilities,
        IJsonModel<ContainerSupportedCapabilities>, IPersistableModel<ContainerSupportedCapabilities>
    {
        internal ContainerSupportedCapabilities() { }
        ContainerSupportedCapabilities IJsonModel<ContainerSupportedCapabilities>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use CapabilitiesCapabilities directly.");
        void IJsonModel<ContainerSupportedCapabilities>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<CapabilitiesCapabilities>)this).Write(writer, options);
        ContainerSupportedCapabilities IPersistableModel<ContainerSupportedCapabilities>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use CapabilitiesCapabilities directly.");
        string IPersistableModel<ContainerSupportedCapabilities>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<CapabilitiesCapabilities>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerSupportedCapabilities>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<CapabilitiesCapabilities>)this).Write(options);
    }
}
