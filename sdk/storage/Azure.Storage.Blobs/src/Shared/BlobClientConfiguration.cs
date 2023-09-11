// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Provides the configurations to connecting to the Blob Service and to create the Blob Clients
    /// </summary>
    public class BlobClientConfiguration
    {
        internal virtual HttpPipeline Pipeline { get; set; }

        internal virtual ClientDiagnostics ClientDiagnostics { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual StorageSharedKeyCredential SharedKeyCredential { get; internal set; }

        /// <summary>
        ///
        /// </summary>
        public virtual TokenCredential TokenCredential { get; internal set; }

        /// <summary>
        ///
        /// </summary>
        public virtual AzureSasCredential SasCredential { get; internal set; }

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
        /// Options for validating transfer integrity.
        /// </summary>
        public virtual TransferValidationOptions TransferValidation { get; internal set; }

        /// <summary>
        /// Encryption scope used for operations.
        /// </summary>
        public string EncryptionScope { get; internal set; }

        /// <summary>
        /// Enables blob name trimm
        /// </summary>
        public bool TrimBlobNameSlashes { get; internal set; }

        /// <summary>
        /// Create a <see cref="BlobClientConfiguration"/> with token authentication.
        /// </summary>

        internal BlobClientConfiguration(
            HttpPipeline pipeline,
            TokenCredential tokenCredential,
            ClientDiagnostics clientDiagnostics,
            BlobClientOptions.ServiceVersion version,
            CustomerProvidedKey? customerProvidedKey,
            TransferValidationOptions transferValidation,
            string encryptionScope,
            bool trimBlobNameSlashes)
        {
            Version = version;
            CustomerProvidedKey = customerProvidedKey;
            TransferValidation = transferValidation;
            EncryptionScope = encryptionScope;
            TrimBlobNameSlashes = trimBlobNameSlashes;
        }

        /// <summary>
        /// Create a <see cref="BlobClientConfiguration"/> with shared key authentication.
        /// </summary>
        internal BlobClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics,
            BlobClientOptions.ServiceVersion version,
            CustomerProvidedKey? customerProvidedKey,
            TransferValidationOptions transferValidation,
            string encryptionScope,
            bool trimBlobNameSlashes)
        {
            Version = version;
            CustomerProvidedKey = customerProvidedKey;
            TransferValidation = transferValidation;
            EncryptionScope = encryptionScope;
            TrimBlobNameSlashes = trimBlobNameSlashes;
        }

        /// <summary>
        /// Create a <see cref="BlobClientConfiguration"/> with SAS authentication.
        /// </summary>
        internal BlobClientConfiguration(
            HttpPipeline pipeline,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics,
            BlobClientOptions.ServiceVersion version,
            CustomerProvidedKey? customerProvidedKey,
            TransferValidationOptions transferValidation,
            string encryptionScope,
            bool trimBlobNameSlashes)
        {
            Version = version;
            CustomerProvidedKey = customerProvidedKey;
            TransferValidation = transferValidation;
            EncryptionScope = encryptionScope;
            TrimBlobNameSlashes = trimBlobNameSlashes;
        }

        /// <summary>
        /// Create a <see cref="BlobClientConfiguration"/> without authentication,
        /// or with SAS that was provided as part of the URL.
        /// </summary>

        internal BlobClientConfiguration(
            HttpPipeline pipeline,
            ClientDiagnostics clientDiagnostics,
            BlobClientOptions.ServiceVersion version,
            CustomerProvidedKey? customerProvidedKey,
            TransferValidationOptions transferValidation,
            string encryptionScope,
            bool trimBlobNameSlashes)
        {
            Version = version;
            CustomerProvidedKey = customerProvidedKey;
            TransferValidation = transferValidation;
            EncryptionScope = encryptionScope;
            TrimBlobNameSlashes = trimBlobNameSlashes;
        }

        /// <summary>
        /// Used for internal Client Constructors that accept multiple types of authentication.
        /// </summary>
        internal BlobClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            TokenCredential tokenCredential,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics,
            BlobClientOptions.ServiceVersion version,
            CustomerProvidedKey? customerProvidedKey,
            TransferValidationOptions transferValidation,
            string encryptionScope,
            bool trimBlobNameSlashes)
        {
            Version = version;
            CustomerProvidedKey = customerProvidedKey;
            TransferValidation = transferValidation;
            EncryptionScope = encryptionScope;
            TrimBlobNameSlashes = trimBlobNameSlashes;
        }

        internal static BlobClientConfiguration DeepCopy(BlobClientConfiguration originalClientConfiguration)
            => new BlobClientConfiguration(
                pipeline: originalClientConfiguration.Pipeline,
                sharedKeyCredential: originalClientConfiguration.SharedKeyCredential,
                tokenCredential: originalClientConfiguration.TokenCredential,
                sasCredential: originalClientConfiguration.SasCredential,
                clientDiagnostics: originalClientConfiguration.ClientDiagnostics,
                version: originalClientConfiguration.Version,
                customerProvidedKey: originalClientConfiguration.CustomerProvidedKey,
                transferValidation: originalClientConfiguration.TransferValidation,
                encryptionScope: originalClientConfiguration.EncryptionScope,
                trimBlobNameSlashes: originalClientConfiguration.TrimBlobNameSlashes);
    }
}
