// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for ElasticProfile. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupElasticProfile : ElasticProfile,
        IJsonModel<ContainerGroupElasticProfile>, IPersistableModel<ContainerGroupElasticProfile>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupElasticProfile"/>. </summary>
        public ContainerGroupElasticProfile() : base() { }
        ContainerGroupElasticProfile IJsonModel<ContainerGroupElasticProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ElasticProfile directly.");
        void IJsonModel<ContainerGroupElasticProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ElasticProfile>)this).Write(writer, options);
        ContainerGroupElasticProfile IPersistableModel<ContainerGroupElasticProfile>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ElasticProfile directly.");
        string IPersistableModel<ContainerGroupElasticProfile>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ElasticProfile>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupElasticProfile>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ElasticProfile>)this).Write(options);
    }
}
