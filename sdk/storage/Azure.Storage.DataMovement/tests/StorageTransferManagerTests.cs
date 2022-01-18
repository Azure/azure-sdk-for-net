// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Tests.Shared;

namespace Azure.Storage.DataMovement.Tests
{
    public class StorageTransferManagerTests : DataMovementTestBase
    {
        public StorageTransferManagerTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [RecordedTest]
        public void Ctor_Defaults()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));

            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ContinueOnLocalFilesystemFailure = false,
                ContinueOnStorageFailure = false,
                ConcurrencyForLocalFilesystemListing = 1
            };

            StorageTransferManager blobTransferManager = new StorageTransferManager(managerOptions);
        }
    }
}
