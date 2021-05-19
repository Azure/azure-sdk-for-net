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

        public string EncryptionScope { get; internal set; }

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
    }
}
