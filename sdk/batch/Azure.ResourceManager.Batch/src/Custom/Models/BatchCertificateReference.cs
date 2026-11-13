// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary> A reference to a certificate to be installed on compute nodes in a pool. </summary>
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class BatchCertificateReference : IJsonModel<BatchCertificateReference>, IPersistableModel<BatchCertificateReference>
    {
        /// <summary> Initializes a new instance of <see cref="BatchCertificateReference"/>. </summary>
        /// <param name="id"> The fully qualified ID of the certificate to install on the pool. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        public BatchCertificateReference(ResourceIdentifier id)
        {
            Argument.AssertNotNull(id, nameof(id));
            Id = id;
            Visibility = new ChangeTrackingList<BatchCertificateVisibility>();
        }

        /// <summary> The fully qualified ID of the certificate to install on the pool. </summary>
        public ResourceIdentifier Id { get; set; }
        /// <summary> The location of the certificate store on the compute node into which to install the certificate. </summary>
        public BatchCertificateStoreLocation? StoreLocation { get; set; }
        /// <summary> The name of the certificate store on the compute node into which to install the certificate. </summary>
        public string StoreName { get; set; }
        /// <summary> Which user accounts on the compute node should have access to the private data of the certificate. </summary>
        public IList<BatchCertificateVisibility> Visibility { get; }

        BatchCertificateReference IJsonModel<BatchCertificateReference>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();

        void IJsonModel<BatchCertificateReference>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException();

        BatchCertificateReference IPersistableModel<BatchCertificateReference>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();

        string IPersistableModel<BatchCertificateReference>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<BatchCertificateReference>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
    }
}
