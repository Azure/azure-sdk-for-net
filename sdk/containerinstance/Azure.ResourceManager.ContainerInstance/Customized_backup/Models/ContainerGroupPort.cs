// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for Port. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupPort : Port,
        IJsonModel<ContainerGroupPort>, IPersistableModel<ContainerGroupPort>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupPort"/>. </summary>
        /// <param name="port"> The port number. </param>
        public ContainerGroupPort(int port) : base(port) { }

        // backward-compat shim: old property was named Port (int), renamed to PortNumber to avoid CS0542 in Port class
        /// <summary> The port number. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Port
        {
            get => PortNumber;
            set => PortNumber = value;
        }
        ContainerGroupPort IJsonModel<ContainerGroupPort>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use Port directly.");
        void IJsonModel<ContainerGroupPort>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<Port>)this).Write(writer, options);
        ContainerGroupPort IPersistableModel<ContainerGroupPort>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use Port directly.");
        string IPersistableModel<ContainerGroupPort>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<Port>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupPort>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<Port>)this).Write(options);
    }
}
