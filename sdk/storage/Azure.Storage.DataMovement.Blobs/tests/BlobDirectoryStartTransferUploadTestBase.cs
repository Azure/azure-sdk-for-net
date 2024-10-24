// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
extern alias DMBlobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.DataMovement.Blobs.Tests;
using Azure.Storage.Test;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public abstract class BlobDirectoryStartTransferUploadTestBase
        : StartTransferUploadDirectoryTestBase<
            BlobServiceClient,
            BlobContainerClient,
            BlobBaseClient,
            BlobClientOptions,
            StorageTestEnvironment>
    {
        public bool UseNonRootDirectory { get; }

        public BlobDirectoryStartTransferUploadTestBase(bool async, BlobClientOptions.ServiceVersion serviceVersion, bool useNonRootDirectory)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
            UseNonRootDirectory = useNonRootDirectory;
        }
    }
}
