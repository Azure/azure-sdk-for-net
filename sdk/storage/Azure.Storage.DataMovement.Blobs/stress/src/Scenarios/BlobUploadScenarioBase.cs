// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.Stress;
using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public abstract class BlobUploadScenarioBase : TestScenarioBase
    {
        protected internal readonly Uri _destinationBlobUri;
        protected internal readonly TokenCredential _tokenCredential;
        protected internal BlobsStorageResourceProvider _blobsStorageResourceProvider;
        protected internal LocalFilesStorageResourceProvider _localFilesStorageResourceProvider;
        protected internal BlobServiceClient _destinationServiceClient;

        public BlobUploadScenarioBase(
            Uri destinationBlobUri,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(metrics, testRunId)
        {
            _destinationBlobUri = destinationBlobUri;
            _tokenCredential = tokenCredential;
            _blobsStorageResourceProvider = new BlobsStorageResourceProvider(tokenCredential);
            _localFilesStorageResourceProvider = new LocalFilesStorageResourceProvider();
            _destinationServiceClient = new BlobServiceClient(destinationBlobUri, tokenCredential);
        }
    }
}
