// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceVaultCertificate : IJsonModel<CloudServiceVaultCertificate>, IPersistableModel<CloudServiceVaultCertificate>
    {
        /// <summary> Initializes a new instance of CloudServiceVaultCertificate. </summary>
        public CloudServiceVaultCertificate()
        {
        }

        /// <summary> The certificate URI. </summary>
        public Uri CertificateUri { get; set; }

        /// <summary> Whether this is a bootstrap certificate. </summary>
        public bool? IsBootstrapCertificate { get; set; }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceVaultCertificate IJsonModel<CloudServiceVaultCertificate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<CloudServiceVaultCertificate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceVaultCertificate IPersistableModel<CloudServiceVaultCertificate>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<CloudServiceVaultCertificate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<CloudServiceVaultCertificate>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
