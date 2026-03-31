// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for VolumeMount. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerVolumeMount : VolumeMount,
        IJsonModel<ContainerVolumeMount>, IPersistableModel<ContainerVolumeMount>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerVolumeMount"/>. </summary>
        /// <param name="name"> The name of the volume mount. </param>
        /// <param name="mountPath"> The path within the container where the volume should be mounted. </param>
        public ContainerVolumeMount(string name, string mountPath) : base(name, mountPath) { }
        ContainerVolumeMount IJsonModel<ContainerVolumeMount>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use VolumeMount directly.");
        void IJsonModel<ContainerVolumeMount>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<VolumeMount>)this).Write(writer, options);
        ContainerVolumeMount IPersistableModel<ContainerVolumeMount>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use VolumeMount directly.");
        string IPersistableModel<ContainerVolumeMount>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<VolumeMount>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerVolumeMount>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<VolumeMount>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsReadOnly
        {
            get => base.ReadOnly;
            set => base.ReadOnly = value;
        }
    }
}
