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

        public UploadTransferValidationOptions UploadTransferValidationOptions { get; internal set; }

        public DownloadTransferValidationOptions DownloadTransferValidationOptions { get; internal set; }

        public ShareFileRequestIntent? FileRequestIntent { get; internal set; }

        public ShareClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics,
            ShareClientOptions clientOptions)
            : this(pipeline, sharedKeyCredential, default, clientDiagnostics, clientOptions, default)
        {
        }

        public ShareClientConfiguration(
            HttpPipeline pipeline,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics,
            ShareClientOptions clientOptions)
            : this(pipeline, default, sasCredential, clientDiagnostics, clientOptions, default)
        {
        }

        internal ShareClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics,
            ShareClientOptions clientOptions,
            ShareFileRequestIntent? fileRequestIntent)
            : base(pipeline, sharedKeyCredential, sasCredential, clientDiagnostics)
        {
            ClientOptions = clientOptions;
            UploadTransferValidationOptions = clientOptions.UploadTransferValidationOptions;
            DownloadTransferValidationOptions = clientOptions.DownloadTransferValidationOptions;
            FileRequestIntent = fileRequestIntent;
        }
    }
}
