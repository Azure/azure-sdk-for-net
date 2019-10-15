// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Cryptography;

namespace Azure.Storage.Blobs.Specialized
{
#pragma warning disable AZC0008 // ClientOptions should have a nested enum called ServiceVersion; handled in base class
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Blob using clientside encryption.
    /// </summary>
    public class EncryptedBlobClientOptions : BlobClientOptions
#pragma warning restore AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    {
        /// <summary>
        /// Required for upload operations.
        /// The key used to wrap the generated content encryption key.
        /// For more information, see https://docs.microsoft.com/en-us/azure/storage/common/storage-client-side-encryption.
        /// </summary>
        public IKeyEncryptionKey KeyEncryptionKey { get; set; }

        /// <summary>
        /// Required for download operations.
        /// Fetches the correct key encryption key to unwrap the downloaded content encryption key.
        /// For more information, see https://docs.microsoft.com/en-us/azure/storage/common/storage-client-side-encryption.
        /// </summary>
        public IKeyEncryptionKeyResolver KeyResolver { get; set; }

        /// <summary>
        /// Required for upload operations.
        /// The algorithm identifier to use when wrapping the content encryption key. This is passed into
        /// <see cref="IKeyEncryptionKey.WrapKey(string, ReadOnlyMemory{byte}, System.Threading.CancellationToken)"/>.
        /// </summary>
        public string EncryptionKeyWrapAlgorithm { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="BlobClientOptions.ServiceVersion"/> of the service API used when
        /// making requests
        /// </param>
        public EncryptedBlobClientOptions(ServiceVersion version = LatestVersion)
            : base(version)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedBlobClientOptions"/> class based on an existing
        /// <see cref="BlobClientOptions"/> instance.
        /// </summary>
        /// <param name="options"></param>
        public EncryptedBlobClientOptions(BlobClientOptions options)
            : base(options)
        { }
    }
}
