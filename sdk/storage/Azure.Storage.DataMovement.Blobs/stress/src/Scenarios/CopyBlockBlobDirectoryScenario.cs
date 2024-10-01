// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Stress;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public class CopyBlockBlobDirectoryScenario : BlobScenarioBase
    {
        private int _blobSize;
        private int _blobCount;

        public CopyBlockBlobDirectoryScenario(
            Uri sourceBlobUri,
            Uri destinationBlobUri,
            int? blobSize,
            int? blobCount,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(destinationBlobUri, transferManagerOptions, dataTransferOptions, tokenCredential, metrics, testRunId)
        {
            _blobSize = blobSize != default ? blobSize.Value : DataMovementBlobStressConstants.DefaultObjectSize;
            _blobCount = blobCount != default ? blobCount.Value : DataMovementBlobStressConstants.DefaultObjectCount;
        }

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.CopyDirectoryBlockBlob;

        public override Task RunTestAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
