// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Files.Shares
{
    internal class ShareClientConfiguration : StorageClientConfiguration
    {
        public ShareClientOptions ClientOptions { get; internal set; }

        public TransferValidationOptions TransferValidation { get; internal set; }

        public ShareClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics,
            ShareClientOptions clientOptions)
            : this(pipeline, sharedKeyCredential, default, clientDiagnostics, clientOptions)
        {
        }

        public ShareClientConfiguration(
            HttpPipeline pipeline,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics,
            ShareClientOptions clientOptions)
            : this(pipeline, default, sasCredential, clientDiagnostics, clientOptions)
        {
        }

        internal ShareClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics,
            ShareClientOptions clientOptions)
            : base(pipeline, sharedKeyCredential, sasCredential, default, clientDiagnostics)
        {
            ClientOptions = clientOptions;
            TransferValidation = clientOptions.TransferValidation;
        }
    }
}
