// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceVaultAndSecretReference : IJsonModel<CloudServiceVaultAndSecretReference>, IPersistableModel<CloudServiceVaultAndSecretReference>
    {
        /// <summary> Initializes a new instance of CloudServiceVaultAndSecretReference. </summary>
        public CloudServiceVaultAndSecretReference()
        {
        }

        /// <summary> The source vault ID. </summary>
        public ResourceIdentifier SourceVaultId { get; set; }

        /// <summary> The secret URI. </summary>
        public Uri SecretUri { get; set; }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceVaultAndSecretReference IJsonModel<CloudServiceVaultAndSecretReference>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<CloudServiceVaultAndSecretReference>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceVaultAndSecretReference IPersistableModel<CloudServiceVaultAndSecretReference>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<CloudServiceVaultAndSecretReference>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<CloudServiceVaultAndSecretReference>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
