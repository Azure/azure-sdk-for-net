// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for EnvironmentVariable. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerEnvironmentVariable : EnvironmentVariable,
        IJsonModel<ContainerEnvironmentVariable>, IPersistableModel<ContainerEnvironmentVariable>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerEnvironmentVariable"/>. </summary>
        /// <param name="name"> The name of the environment variable. </param>
        public ContainerEnvironmentVariable(string name) : base(name) { }
        ContainerEnvironmentVariable IJsonModel<ContainerEnvironmentVariable>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use EnvironmentVariable directly.");
        void IJsonModel<ContainerEnvironmentVariable>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<EnvironmentVariable>)this).Write(writer, options);
        ContainerEnvironmentVariable IPersistableModel<ContainerEnvironmentVariable>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use EnvironmentVariable directly.");
        string IPersistableModel<ContainerEnvironmentVariable>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<EnvironmentVariable>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerEnvironmentVariable>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<EnvironmentVariable>)this).Write(options);
    }
}
