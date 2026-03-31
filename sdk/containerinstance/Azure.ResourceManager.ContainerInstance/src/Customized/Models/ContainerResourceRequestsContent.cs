// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for ResourceRequests. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerResourceRequestsContent : ResourceRequests,
        IJsonModel<ContainerResourceRequestsContent>, IPersistableModel<ContainerResourceRequestsContent>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerResourceRequestsContent"/>. </summary>
        /// <param name="memoryInGB"> The memory request in GB of this container instance. </param>
        /// <param name="cpu"> The CPU request of this container instance. </param>
        public ContainerResourceRequestsContent(double memoryInGB, double cpu) : base(memoryInGB, cpu) { }
        ContainerResourceRequestsContent IJsonModel<ContainerResourceRequestsContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ResourceRequests directly.");
        void IJsonModel<ContainerResourceRequestsContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ResourceRequests>)this).Write(writer, options);
        ContainerResourceRequestsContent IPersistableModel<ContainerResourceRequestsContent>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ResourceRequests directly.");
        string IPersistableModel<ContainerResourceRequestsContent>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ResourceRequests>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerResourceRequestsContent>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ResourceRequests>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerGpuResourceInfo Gpu
        {
            get => default;
            set => base.Gpu = value;
        }
    }
}
