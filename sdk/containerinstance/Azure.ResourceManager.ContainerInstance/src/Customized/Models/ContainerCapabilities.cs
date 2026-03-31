// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for Capabilities. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerCapabilities : Capabilities,
        IJsonModel<ContainerCapabilities>, IPersistableModel<ContainerCapabilities>
    {
        internal ContainerCapabilities() { }
        ContainerCapabilities IJsonModel<ContainerCapabilities>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use Capabilities directly.");
        void IJsonModel<ContainerCapabilities>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<Capabilities>)this).Write(writer, options);
        ContainerCapabilities IPersistableModel<ContainerCapabilities>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use Capabilities directly.");
        string IPersistableModel<ContainerCapabilities>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<Capabilities>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerCapabilities>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<Capabilities>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OSType => base.OsType;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Azure.Core.AzureLocation? Location => base.Location != null ? new Azure.Core.AzureLocation(base.Location) : default(Azure.Core.AzureLocation?);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IPAddressType => base.IpAddressType;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerSupportedCapabilities Capabilities => default;
    }
}
