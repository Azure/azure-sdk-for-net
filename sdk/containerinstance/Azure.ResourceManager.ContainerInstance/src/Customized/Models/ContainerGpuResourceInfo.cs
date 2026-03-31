// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for GpuResource. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGpuResourceInfo : GpuResource,
        IJsonModel<ContainerGpuResourceInfo>, IPersistableModel<ContainerGpuResourceInfo>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGpuResourceInfo"/>. </summary>
        /// <param name="count"> The count of the GPU resource. </param>
        /// <param name="sku"> The SKU of the GPU resource. </param>
        public ContainerGpuResourceInfo(int count, ContainerGpuSku sku) : base(count, new GpuSku(sku.ToString())) { }
        ContainerGpuResourceInfo IJsonModel<ContainerGpuResourceInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use GpuResource directly.");
        void IJsonModel<ContainerGpuResourceInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<GpuResource>)this).Write(writer, options);
        ContainerGpuResourceInfo IPersistableModel<ContainerGpuResourceInfo>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use GpuResource directly.");
        string IPersistableModel<ContainerGpuResourceInfo>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<GpuResource>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGpuResourceInfo>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<GpuResource>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerGpuSku Sku
        {
            get => new ContainerGpuSku(base.Sku.ToString());
            set => base.Sku = new GpuSku(value.ToString());
        }
    }
}
