// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for EncryptionProperties. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupEncryptionProperties : EncryptionProperties,
        IJsonModel<ContainerGroupEncryptionProperties>, IPersistableModel<ContainerGroupEncryptionProperties>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupEncryptionProperties"/>. </summary>
        public ContainerGroupEncryptionProperties(System.Uri vaultBaseUri, string keyName, string keyVersion) : base(vaultBaseUri?.AbsoluteUri, keyName, keyVersion) { }
        /// <summary> Initializes a new instance of <see cref="ContainerGroupEncryptionProperties"/>. </summary>
        public ContainerGroupEncryptionProperties(string vaultBaseUri, string keyName, string keyVersion) : base(vaultBaseUri, keyName, keyVersion) { }

        // backward-compat shim: old VaultBaseUri was System.Uri, new is string
        /// <summary> The keyvault base URI. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Uri VaultBaseUri
        {
            get => base.VaultBaseUri != null ? new System.Uri(base.VaultBaseUri) : null;
            set => base.VaultBaseUri = value?.AbsoluteUri;
        }
        ContainerGroupEncryptionProperties IJsonModel<ContainerGroupEncryptionProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use EncryptionProperties directly.");
        void IJsonModel<ContainerGroupEncryptionProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<EncryptionProperties>)this).Write(writer, options);
        ContainerGroupEncryptionProperties IPersistableModel<ContainerGroupEncryptionProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use EncryptionProperties directly.");
        string IPersistableModel<ContainerGroupEncryptionProperties>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<EncryptionProperties>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupEncryptionProperties>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<EncryptionProperties>)this).Write(options);
    }
}
