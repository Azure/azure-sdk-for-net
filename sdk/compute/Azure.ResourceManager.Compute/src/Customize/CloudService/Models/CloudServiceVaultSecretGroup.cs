// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceVaultSecretGroup : IJsonModel<CloudServiceVaultSecretGroup>, IPersistableModel<CloudServiceVaultSecretGroup>
    {
        /// <summary> Initializes a new instance of CloudServiceVaultSecretGroup. </summary>
        public CloudServiceVaultSecretGroup()
        {
        }

        /// <summary> The source vault ID. </summary>
        public ResourceIdentifier SourceVaultId { get; set; }

        /// <summary> The vault certificates. </summary>
        public IList<CloudServiceVaultCertificate> VaultCertificates { get; }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceVaultSecretGroup IJsonModel<CloudServiceVaultSecretGroup>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<CloudServiceVaultSecretGroup>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceVaultSecretGroup IPersistableModel<CloudServiceVaultSecretGroup>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<CloudServiceVaultSecretGroup>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<CloudServiceVaultSecretGroup>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
