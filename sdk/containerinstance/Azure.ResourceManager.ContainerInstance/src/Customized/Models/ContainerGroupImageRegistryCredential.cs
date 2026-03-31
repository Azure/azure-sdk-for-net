// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for ImageRegistryCredential. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupImageRegistryCredential : ImageRegistryCredential,
        IJsonModel<ContainerGroupImageRegistryCredential>, IPersistableModel<ContainerGroupImageRegistryCredential>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupImageRegistryCredential"/>. </summary>
        /// <param name="server"> The Docker image registry server. </param>
        public ContainerGroupImageRegistryCredential(string server) : base(server) { }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public ContainerGroupImageRegistryCredential(string server, string username)
            : base(server) { Username = username; }

        // backward-compat shim: old IdentityUri was System.Uri, new is string
        /// <summary> The identity server URI. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Uri IdentityUri
        {
            get => base.IdentityUri != null ? new System.Uri(base.IdentityUri) : null;
            set => base.IdentityUri = value?.AbsoluteUri;
        }
        ContainerGroupImageRegistryCredential IJsonModel<ContainerGroupImageRegistryCredential>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ImageRegistryCredential directly.");
        void IJsonModel<ContainerGroupImageRegistryCredential>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ImageRegistryCredential>)this).Write(writer, options);
        ContainerGroupImageRegistryCredential IPersistableModel<ContainerGroupImageRegistryCredential>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ImageRegistryCredential directly.");
        string IPersistableModel<ContainerGroupImageRegistryCredential>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ImageRegistryCredential>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupImageRegistryCredential>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ImageRegistryCredential>)this).Write(options);
    }
}
