// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Models.JobPlan;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class RehydrateStorageResourceTests : DataMovementTestBase
    {
        public RehydrateStorageResourceTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        { }

        private enum StorageResourceType
        {
            BlockBlob,
            PageBlob,
            AppendBlob,
            Local
        }

        private void CreateJobPlanFileAsync(
            string checkpointerPath,
            string transferId,
            StorageResourceType sourceType,
            string sourcePath,
            StorageResourceType destinatonType,
            string destinationPath)
        {
            int partNumber = 1;
            JobPlanOperation fromTo;
            if (sourceType == StorageResourceType.Local)
            {
                fromTo = JobPlanOperation.Upload;
            }
            else if (destinatonType == StorageResourceType.Local)
            {
                fromTo = JobPlanOperation.Download;
            }
            else
            {
                fromTo = JobPlanOperation.ServiceToService;
            }

            CreateDefaultJobPartHeader(
                transferId: transferId,
                partNumber: partNumber,
                sourcePath: sourcePath,
                destinationPath: destinationPath,
                fromTo: fromTo
                );
            ;
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydrateLocalFileResource(bool isSource)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory(Guid.NewGuid().ToString());
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourcePath = GetNewString(20);
            string destinationPath = GetNewString(15);

            StorageResourceType sourceType = isSource ? StorageResourceType.BlockBlob : StorageResourceType.Local;
            StorageResourceType destinationType = !isSource ? StorageResourceType.BlockBlob : StorageResourceType.Local;

            CreateJobPlanFileAsync(
                test.DirectoryPath,
                transferId,
                sourceType,
                sourcePath,
                destinationType,
                destinationPath);

            LocalFileStorageResource storageResource = await LocalFileStorageResource.RehydrateStorageResource(
                checkpointer,
                transferId,
                false);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydrateBlockBlobResource(bool isSource)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory(Guid.NewGuid().ToString());
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourcePath = GetNewString(20);
            string destinationPath = GetNewString(15);

            StorageResourceType sourceType = isSource ? StorageResourceType.BlockBlob : StorageResourceType.Local;
            StorageResourceType destinationType = !isSource ? StorageResourceType.BlockBlob : StorageResourceType.Local;

            CreateJobPlanFileAsync(
                test.DirectoryPath,
                transferId,
                sourceType,
                sourcePath,
                destinationType,
                destinationPath);

            BlockBlobStorageResource storageResource = await BlockBlobStorageResource.RehydrateStorageResource(
                checkpointer,
                transferId,
                false,
                new StorageTransferCredentials(new StorageSharedKeyCredential("accountName", "accountKey")));
        }
    }
}
