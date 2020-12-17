// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Contains common properties used to create clients.
    /// </summary>
    internal class BlobStorageContext : StorageContext
    {
        public virtual BlobClientOptions.ServiceVersion Version { get; private set; }

        public virtual CustomerProvidedKey? CustomerProvidedKey { get; private set; }

        public virtual string EncryptionScope { get; private set; }

        public BlobStorageContext(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics,
            BlobClientOptions.ServiceVersion version,
            CustomerProvidedKey? customerProvidedKey,
            string encryptionScope)
            : base(pipeline, sharedKeyCredential, clientDiagnostics)
        {
            Version = version;
            CustomerProvidedKey = customerProvidedKey;
            EncryptionScope = encryptionScope;
        }

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        internal BlobStorageContext() : base() { }
    }
}
