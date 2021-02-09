// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Storage.Shared;

namespace Azure.Storage.Files.Shares
{
    internal class ShareClientConfiguration : StorageClientConfiguration
    {
        public ShareClientOptions.ServiceVersion Version { get; internal set; }

        public ShareClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics,
            ShareClientOptions.ServiceVersion version)
            : base(pipeline, sharedKeyCredential, clientDiagnostics)
        {
            Version = version;
        }
    }
}
