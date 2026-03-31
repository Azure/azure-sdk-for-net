// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for GitRepoVolume. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerInstanceGitRepoVolume : GitRepoVolume,
        IJsonModel<ContainerInstanceGitRepoVolume>, IPersistableModel<ContainerInstanceGitRepoVolume>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerInstanceGitRepoVolume"/>. </summary>
        /// <param name="repository"> Repository URL. </param>
        public ContainerInstanceGitRepoVolume(string repository) : base(repository) { }
        ContainerInstanceGitRepoVolume IJsonModel<ContainerInstanceGitRepoVolume>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use GitRepoVolume directly.");
        void IJsonModel<ContainerInstanceGitRepoVolume>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<GitRepoVolume>)this).Write(writer, options);
        ContainerInstanceGitRepoVolume IPersistableModel<ContainerInstanceGitRepoVolume>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use GitRepoVolume directly.");
        string IPersistableModel<ContainerInstanceGitRepoVolume>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<GitRepoVolume>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerInstanceGitRepoVolume>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<GitRepoVolume>)this).Write(options);
    }
}
