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
    public class CopyBlockBlobDirectoryScenario : CopyBlobDirectoryScenarioBase
    {
        public CopyBlockBlobDirectoryScenario(
            Uri sourceBlobUri,
            Uri destinationBlobUri,
            int? blobSize,
            int? blobCount,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential sourceTokenCredential,
            TokenCredential destinationTokenCredential,
            Metrics metrics,
            string testRunId)
            : base(sourceBlobUri, destinationBlobUri, blobSize, blobCount, transferManagerOptions, dataTransferOptions, sourceTokenCredential, destinationTokenCredential, metrics, testRunId)
        {
        }

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.CopyDirectoryBlockBlob;

        public override Task RunTestAsync(CancellationToken cancellationToken)
            => RunTestInternalAsync(BlobType.Block, cancellationToken);
    }
}
