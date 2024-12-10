﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Stress;
using BaseBlobs::Azure.Storage.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public class DownloadAppendBlobSingleScenario : DownloadBlobSingleScenarioBase
    {
        public DownloadAppendBlobSingleScenario(
            Uri sourceBlobUri,
            int? blobSize,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(sourceBlobUri, blobSize, transferManagerOptions, dataTransferOptions, tokenCredential, metrics, testRunId)
        {
        }

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.DownloadSingleBlockBlob;

        public override async Task RunTestAsync(CancellationToken cancellationToken)
            => await RunTestInternalAsync(BlobType.Block, cancellationToken);
    }
}
