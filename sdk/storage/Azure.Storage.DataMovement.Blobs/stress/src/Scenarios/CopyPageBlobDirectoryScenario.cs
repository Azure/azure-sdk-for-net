// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Stress;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public class CopyPageBlobDirectoryScenario : CopyBlobDirectoryScenarioBase
    {
        public CopyPageBlobDirectoryScenario(
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

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.CopyDirectoryPageBlob;

        public override Task RunTestAsync(CancellationToken cancellationToken)
            => RunTestInternalAsync(BlobType.Page, cancellationToken);
    }
}
