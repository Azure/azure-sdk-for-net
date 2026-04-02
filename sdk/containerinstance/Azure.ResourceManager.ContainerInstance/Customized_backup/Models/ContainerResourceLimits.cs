// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for ResourceLimits. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerResourceLimits : ResourceLimits,
        IJsonModel<ContainerResourceLimits>, IPersistableModel<ContainerResourceLimits>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerResourceLimits"/>. </summary>
        public ContainerResourceLimits() : base() { }
        ContainerResourceLimits IJsonModel<ContainerResourceLimits>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ResourceLimits directly.");
        void IJsonModel<ContainerResourceLimits>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ResourceLimits>)this).Write(writer, options);
        ContainerResourceLimits IPersistableModel<ContainerResourceLimits>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ResourceLimits directly.");
        string IPersistableModel<ContainerResourceLimits>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ResourceLimits>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerResourceLimits>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ResourceLimits>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerGpuResourceInfo Gpu
        {
            get => default;
            set => base.Gpu = value;
        }
    }
}
