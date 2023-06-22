// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
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
    public class RehydrateBlobResourceTests : DataMovementTestBase
    {
        public RehydrateBlobResourceTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        { }

        private enum StorageResourceType
        {
            BlockBlob,
            PageBlob,
            AppendBlob,
            Local
        }

        private async Task AddJobPartToCheckpointer(
            TransferCheckpointer checkpointer,
            string transferId,
            StorageResourceType sourceType,
            List<string> sourcePaths,
            StorageResourceType destinatonType,
            List<string> destinationPaths,
            int partCount = 1)
        {
            // Populate sourcePaths if not provided
            if (sourcePaths == default)
            {
                string sourcePath = "sample-source";
                sourcePaths = new List<string>();
                for (int i = 0; i < partCount; i++)
                {
                    sourcePaths.Add(Path.Combine(sourcePath, $"file{i}"));
                }
            }
            // Populate destPaths if not provided
            if (destinationPaths == default)
            {
                string destPath = "sample-dest";
                destinationPaths = new List<string>();
                for (int i = 0; i < partCount; i++)
                {
                    destinationPaths.Add(Path.Combine(destPath, $"file{i}"));
                }
            }

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

            await checkpointer.AddNewJobAsync(transferId);

            for (int currentPart = 0; currentPart < partCount; currentPart++)
            {
                JobPartPlanHeader header = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: currentPart,
                    sourcePath: sourcePaths[currentPart],
                    destinationPath: destinationPaths[currentPart],
                    fromTo: fromTo);

                using (Stream stream = new MemoryStream())
                {
                    header.Serialize(stream);

                    await checkpointer.AddNewJobPartAsync(
                        transferId: transferId,
                        partNumber: currentPart,
                        chunksTotal: 1,
                        headerStream: stream);
                }
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydrateBlockBlob(bool isSource)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory(Guid.NewGuid().ToString());
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourcePath = GetNewString(20);
            string destinationPath = GetNewString(15);

            StorageResourceType sourceType = isSource ? StorageResourceType.BlockBlob : StorageResourceType.Local;
            StorageResourceType destinationType = !isSource ? StorageResourceType.BlockBlob : StorageResourceType.Local;

            await AddJobPartToCheckpointer(
                checkpointer,
                transferId,
                sourceType,
                new List<string>() { sourcePath },
                destinationType,
                new List<string>() { destinationPath });

            BlockBlobStorageResource storageResource = await BlockBlobStorageResource.RehydrateResource(
                checkpointer,
                transferId,
                false,
                new StorageSharedKeyCredential("accountName", "accountKey"));
        }
    }
}
