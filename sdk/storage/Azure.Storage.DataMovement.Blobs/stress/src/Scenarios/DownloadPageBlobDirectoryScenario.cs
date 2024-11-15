﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using BaseBlobs::Azure.Storage.Blobs.Models;
using Azure.Storage.Stress;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public class DownloadPageBlobDirectoryScenario : DownloadBlobDirectoryScenarioBase
    {
        public DownloadPageBlobDirectoryScenario(
            Uri destinationBlobUri,
            int? blobSize,
            int? blobCount,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId) :
            base(destinationBlobUri, blobSize, blobCount, transferManagerOptions, dataTransferOptions, tokenCredential, metrics, testRunId)
        {
        }

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.DownloadDirectoryPageBlob;

        public override async Task RunTestAsync(CancellationToken cancellationToken)
            => await RunTestInternalAsync(BlobType.Page, cancellationToken);
    }
}
