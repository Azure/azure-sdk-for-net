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
    internal class BlobClientConfiguration : StorageClientConfiguration
    {
        public virtual BlobClientOptions.ServiceVersion Version { get; internal set; }

        public virtual CustomerProvidedKey? CustomerProvidedKey { get; internal set; }

        public virtual TransferValidationOptions TransferValidation { get; internal set; }

        public string EncryptionScope { get; internal set; }

        public bool PreserveBlobNameOuterSlashes { get; internal set; }

        public BlobClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics,
            BlobClientOptions.ServiceVersion version,
            CustomerProvidedKey? customerProvidedKey,
            TransferValidationOptions transferValidation,
            string encryptionScope,
            bool preserveBlobNameOuterSlashes)
            : base(pipeline, sharedKeyCredential, clientDiagnostics)
        {
            Version = version;
            CustomerProvidedKey = customerProvidedKey;
            TransferValidation = transferValidation;
            EncryptionScope = encryptionScope;
            PreserveBlobNameOuterSlashes = preserveBlobNameOuterSlashes;
        }

        internal static BlobClientConfiguration DeepCopy(BlobClientConfiguration originalClientConfiguration)
            => new BlobClientConfiguration(
                pipeline: originalClientConfiguration.Pipeline,
                sharedKeyCredential: originalClientConfiguration.SharedKeyCredential,
                clientDiagnostics: originalClientConfiguration.ClientDiagnostics,
                version: originalClientConfiguration.Version,
                customerProvidedKey: originalClientConfiguration.CustomerProvidedKey,
                transferValidation: originalClientConfiguration.TransferValidation,
                encryptionScope: originalClientConfiguration.EncryptionScope,
                preserveBlobNameOuterSlashes: originalClientConfiguration.PreserveBlobNameOuterSlashes);
    }
}
