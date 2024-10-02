// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Stress;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public class DownloadPageBlobSingleScenario : DownloadBlobSingleScenarioBase
    {
        public DownloadPageBlobSingleScenario(
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

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.DownloadSinglePageBlob;

        public override async Task RunTestAsync(CancellationToken cancellationToken)
            => await RunTestInternalAsync(BlobType.Page, cancellationToken);
    }
}
