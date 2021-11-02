// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Provides the configurations to connecting to the Blob Service and to create the Blob Clients
    /// </summary>
    internal class BlobClientConfiguration : StorageClientConfiguration
    {
        /// <summary>
        /// The versions of Azure Blob Storage supported by this client
        /// library.  For more, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/versioning-for-the-azure-storage-services">
        /// Versioning for Azure Storage Services</see>.
        /// </summary>
        public virtual BlobClientOptions.ServiceVersion Version { get; internal set; }

        /// <summary>
        /// The encryption key to be used with client provided key server-side encryption.
        /// </summary>
        public virtual CustomerProvidedKey? CustomerProvidedKey { get; internal set; }

        /// <summary>
        /// The encryption scope to be used with client provided key server-side encryption.
        /// </summary>
        public string EncryptionScope { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClientConfiguration"/>
        /// </summary>
        /// <param name="pipeline">Authentication policy used to sign requests.></param>
        /// <param name="sharedKeyCredential">The shared key credential used to sign requests.</param>
        /// <param name="clientDiagnostics">The handler for diagnostic messaging in the client. </param>
        /// <param name="version"> The versions of Azure Blob Storage supported by this client library.</param>
        /// <param name="customerProvidedKey">The encryption key to be used with client provided key server-side encryption.</param>
        /// <param name="encryptionScope">The encryption scope to be used with client provided key server-side encryption.</param>
        public BlobClientConfiguration(
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

        internal static BlobClientConfiguration DeepCopy(BlobClientConfiguration originalClientConfiguration)
            => new BlobClientConfiguration(
                pipeline: originalClientConfiguration.Pipeline,
                sharedKeyCredential: originalClientConfiguration.SharedKeyCredential,
                clientDiagnostics: originalClientConfiguration.ClientDiagnostics,
                version: originalClientConfiguration.Version,
                customerProvidedKey: originalClientConfiguration.CustomerProvidedKey,
                encryptionScope: originalClientConfiguration.EncryptionScope);
    }
}
