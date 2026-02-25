// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary>
    /// Contains information about a certificate.
    /// </summary>
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class BatchAccountCertificateCreateOrUpdateContent : ResourceData, IJsonModel<BatchAccountCertificateCreateOrUpdateContent>, IPersistableModel<BatchAccountCertificateCreateOrUpdateContent>
    {
        /// <summary> Initializes a new instance of <see cref="BatchAccountCertificateCreateOrUpdateContent"/>. </summary>
        public BatchAccountCertificateCreateOrUpdateContent()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> The algorithm of the certificate thumbprint. </summary>
        public string ThumbprintAlgorithm { get; set; }

        /// <summary> The thumbprint of the certificate. </summary>
        public string ThumbprintString { get; set; }

        /// <summary> The format of the certificate - either Pfx or Cer. </summary>
        public BatchAccountCertificateFormat? Format { get; set; }

        /// <summary> The base64-encoded contents of the certificate. </summary>
        public BinaryData Data { get; set; }

        /// <summary> The password to access the certificate's private key. </summary>
        public string Password { get; set; }

        /// <summary> The ETag of the resource, used for concurrency statements. </summary>
        public ETag? ETag { get; }

        /// <summary> The tags of the resource. </summary>
        public IDictionary<string, string> Tags { get; }

        /// <summary>
        /// This must match the thumbprint from the name.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use `ThumbprintString` instead.", false)]
        public BinaryData Thumbprint
        {
            get => ThumbprintString != null ? BinaryData.FromString(ThumbprintString) : null;
            set => ThumbprintString = value?.ToString();
        }

        /// <inheritdoc />
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException();

        BatchAccountCertificateCreateOrUpdateContent IJsonModel<BatchAccountCertificateCreateOrUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();

        void IJsonModel<BatchAccountCertificateCreateOrUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException();

        BatchAccountCertificateCreateOrUpdateContent IPersistableModel<BatchAccountCertificateCreateOrUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();

        string IPersistableModel<BatchAccountCertificateCreateOrUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<BatchAccountCertificateCreateOrUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
    }
}
