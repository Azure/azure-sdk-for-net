// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for ContainerExecRequest. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerExecContent : ContainerExecRequest,
        IJsonModel<ContainerExecContent>, IPersistableModel<ContainerExecContent>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerExecContent"/>. </summary>
        public ContainerExecContent() : base() { }
        ContainerExecContent IJsonModel<ContainerExecContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ContainerExecRequest directly.");
        void IJsonModel<ContainerExecContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ContainerExecRequest>)this).Write(writer, options);
        ContainerExecContent IPersistableModel<ContainerExecContent>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ContainerExecRequest directly.");
        string IPersistableModel<ContainerExecContent>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ContainerExecRequest>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerExecContent>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ContainerExecRequest>)this).Write(options);
    }
}
