// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for Volume. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerVolume : Volume,
        IJsonModel<ContainerVolume>, IPersistableModel<ContainerVolume>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerVolume"/>. </summary>
        /// <param name="name"> The name of the volume. </param>
        public ContainerVolume(string name) : base(name) { }
        ContainerVolume IJsonModel<ContainerVolume>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use Volume directly.");
        void IJsonModel<ContainerVolume>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<Volume>)this).Write(writer, options);
        ContainerVolume IPersistableModel<ContainerVolume>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use Volume directly.");
        string IPersistableModel<ContainerVolume>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<Volume>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerVolume>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<Volume>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerInstanceAzureFileVolume AzureFile
        {
            get => default;
            set => base.AzureFile = value;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerInstanceGitRepoVolume GitRepo
        {
            get => default;
            set => base.GitRepo = value;
        }
    }
}
