// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Stress;
using BaseBlobs::Azure.Storage.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public class CopyPageBlobSingleScenario : CopyBlobSingleScenarioBase
    {
        public CopyPageBlobSingleScenario(
            Uri sourceBlobUri,
            Uri destinationBlobUri,
            int? blobSize,
            TransferManagerOptions transferManagerOptions,
            TransferOptions transferOptions,
            TokenCredential sourceTokenCredential,
            TokenCredential destinationTokenCredential,
            Metrics metrics,
            string testRunId)
            : base(sourceBlobUri, destinationBlobUri, blobSize, transferManagerOptions, transferOptions, sourceTokenCredential, destinationTokenCredential, metrics, testRunId)
        {
        }

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.CopySinglePageBlob;

        public override Task RunTestAsync(CancellationToken cancellationToken)
            => RunTestInternalAsync(BlobType.Page, cancellationToken);
    }
}
