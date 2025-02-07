// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;

using System;
using Azure.Core;
using Azure.Storage.Stress;
using BaseBlobs::Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Stress;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public abstract class BlobScenarioBase : DataMovementScenarioBase
    {
        protected internal readonly Uri _destinationBlobUri;
        protected internal int _blobSize;
        protected internal readonly TokenCredential _tokenCredential;
        protected internal BlobServiceClient _blobServiceClient;

        public BlobScenarioBase(
            Uri blobUri,
            int? blobSize,
            TransferManagerOptions transferManagerOptions,
            TransferOptions transferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(transferManagerOptions, transferOptions, metrics, testRunId)
        {
            _destinationBlobUri = blobUri;
            _blobSize = blobSize != default ? blobSize.Value : DataMovementBlobStressConstants.DefaultObjectSize;
            _tokenCredential = tokenCredential;
            _blobServiceClient = new BlobServiceClient(blobUri, tokenCredential);
        }
    }
}
