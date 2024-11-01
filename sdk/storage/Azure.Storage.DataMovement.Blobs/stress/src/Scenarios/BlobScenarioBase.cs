// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;

using System;
using Azure.Core;
using Azure.Storage.Stress;
using BaseBlobs::Azure.Storage.Blobs;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Azure.Storage.DataMovement.Stress;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public abstract class BlobScenarioBase : DataMovementScenarioBase
    {
        protected internal readonly Uri _destinationBlobUri;
        protected internal int _blobSize;
        protected internal readonly TokenCredential _tokenCredential;
        protected internal BlobsStorageResourceProvider _blobsStorageResourceProvider;
        protected internal LocalFilesStorageResourceProvider _localFilesStorageResourceProvider;
        protected internal BlobServiceClient _blobServiceClient;

        public BlobScenarioBase(
            Uri blobUri,
            int? blobSize,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(transferManagerOptions, dataTransferOptions, metrics, testRunId)
        {
            _destinationBlobUri = blobUri;
            _blobSize = blobSize != default ? blobSize.Value : DataMovementBlobStressConstants.DefaultObjectSize;
            _tokenCredential = tokenCredential;
            _blobsStorageResourceProvider = new BlobsStorageResourceProvider(tokenCredential);
            _localFilesStorageResourceProvider = new LocalFilesStorageResourceProvider();
            _blobServiceClient = new BlobServiceClient(blobUri, tokenCredential);
        }
    }
}
