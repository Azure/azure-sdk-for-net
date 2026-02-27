// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Batch
{
    /// <summary>
    /// A class representing the BatchAccountCertificate data model.
    /// Contains information about a certificate.
    /// </summary>
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class BatchAccountCertificateData : ResourceData, IJsonModel<BatchAccountCertificateData>, IPersistableModel<BatchAccountCertificateData>
    {
        /// <summary> Initializes a new instance of <see cref="BatchAccountCertificateData"/>. </summary>
        public BatchAccountCertificateData()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> The algorithm of the certificate thumbprint. </summary>
        public string ThumbprintAlgorithm { get; set; }

        /// <summary> The thumbprint of the certificate. </summary>
        public string ThumbprintString { get; set; }

        /// <summary> The format of the certificate - either Pfx or Cer. </summary>
        public BatchAccountCertificateFormat? Format { get; set; }

        /// <summary> The provisioned state of the resource. </summary>
        public BatchAccountCertificateProvisioningState? ProvisioningState { get; }

        /// <summary> The time at which the certificate entered its current state. </summary>
        public DateTimeOffset? ProvisioningStateTransitOn { get; }

        /// <summary> The previous provisioned state of the resource. </summary>
        public BatchAccountCertificateProvisioningState? PreviousProvisioningState { get; }

        /// <summary> The time at which the certificate entered its previous state. </summary>
        public DateTimeOffset? PreviousProvisioningStateTransitOn { get; }

        /// <summary> The public key of the certificate. </summary>
        public string PublicData { get; }

        /// <summary> The error which occurred while deleting the certificate. </summary>
        public ResponseError DeleteCertificateError { get; }

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

        BatchAccountCertificateData IJsonModel<BatchAccountCertificateData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();

        void IJsonModel<BatchAccountCertificateData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException();

        BatchAccountCertificateData IPersistableModel<BatchAccountCertificateData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();

        string IPersistableModel<BatchAccountCertificateData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<BatchAccountCertificateData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
    }
}
