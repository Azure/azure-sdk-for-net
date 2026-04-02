// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for NetworkProfile. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupNetworkProfile : NetworkProfile,
        IJsonModel<ContainerGroupNetworkProfile>, IPersistableModel<ContainerGroupNetworkProfile>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupNetworkProfile"/>. </summary>
        public ContainerGroupNetworkProfile() : base() { }
        ContainerGroupNetworkProfile IJsonModel<ContainerGroupNetworkProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use NetworkProfile directly.");
        void IJsonModel<ContainerGroupNetworkProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<NetworkProfile>)this).Write(writer, options);
        ContainerGroupNetworkProfile IPersistableModel<ContainerGroupNetworkProfile>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use NetworkProfile directly.");
        string IPersistableModel<ContainerGroupNetworkProfile>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<NetworkProfile>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupNetworkProfile>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<NetworkProfile>)this).Write(options);
    }
}
