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
    public class BlobSingleDownloadScenario : BlobScenarioBase
    {
        public BlobSingleDownloadScenario(
            Uri sourceBlobUri,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(sourceBlobUri, tokenCredential, metrics, testRunId)
        {
        }

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.DownloadSingleBlockBlob;

        public override Task RunTestAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
