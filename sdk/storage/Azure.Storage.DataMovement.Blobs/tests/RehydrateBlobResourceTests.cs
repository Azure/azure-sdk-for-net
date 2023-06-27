// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Models.JobPlan;
using Moq;
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

        private static Mock<DataTransferProperties> GetProperties(
            string checkpointerPath,
            string transferId,
            string sourcePath,
            string destinationPath)
        {
            var mock = new Mock<DataTransferProperties>(MockBehavior.Strict);
            mock.Setup(p => p.TransferId).Returns(transferId);
            mock.Setup(p => p.Checkpointer).Returns(new TransferCheckpointerOptions(checkpointerPath));
            mock.Setup(p => p.SourcePath).Returns(sourcePath);
            mock.Setup(p => p.DestinationPath).Returns(destinationPath);
            return mock;
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
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";
            string originalPath = isSource ? sourcePath : destinationPath;

            StorageResourceType sourceType = isSource ? StorageResourceType.Local : StorageResourceType.BlockBlob;
            StorageResourceType destinationType = !isSource ? StorageResourceType.Local : StorageResourceType.BlockBlob;

            DataTransferProperties transferProperties = GetProperties(
                test.DirectoryPath,
                transferId,
                sourcePath,
                destinationPath).Object;

            await AddJobPartToCheckpointer(
                checkpointer,
                transferId,
                sourceType,
                new List<string>() { sourcePath },
                destinationType,
                new List<string>() { destinationPath });

            BlockBlobStorageResource storageResource = await BlockBlobStorageResource.RehydrateResourceAsync(transferProperties, isSource);

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydratePageBlob(bool isSource)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";
            string originalPath = isSource ? sourcePath : destinationPath;

            StorageResourceType sourceType = isSource ? StorageResourceType.Local : StorageResourceType.BlockBlob;
            StorageResourceType destinationType = !isSource ? StorageResourceType.Local : StorageResourceType.BlockBlob;

            DataTransferProperties transferProperties = GetProperties(
                test.DirectoryPath,
                transferId,
                sourcePath,
                destinationPath).Object;

            await AddJobPartToCheckpointer(
                checkpointer,
                transferId,
                sourceType,
                new List<string>() { sourcePath },
                destinationType,
                new List<string>() { destinationPath });

            PageBlobStorageResource storageResource =
                await PageBlobStorageResource.RehydrateResourceAsync(transferProperties, isSource);

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydrateAppendBlob(bool isSource)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";
            string originalPath = isSource ? sourcePath : destinationPath;

            StorageResourceType sourceType = isSource ? StorageResourceType.Local : StorageResourceType.BlockBlob;
            StorageResourceType destinationType = !isSource ? StorageResourceType.Local : StorageResourceType.BlockBlob;

            DataTransferProperties transferProperties = GetProperties(
                test.DirectoryPath,
                transferId,
                sourcePath,
                destinationPath).Object;

            await AddJobPartToCheckpointer(
                checkpointer,
                transferId,
                sourceType,
                new List<string>() { sourcePath },
                destinationType,
                new List<string>() { destinationPath });

            AppendBlobStorageResource storageResource =
                await AppendBlobStorageResource.RehydrateResourceAsync(transferProperties, isSource);

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydrateBlobContainer(bool isSource)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            List<string> sourcePaths = new List<string>();
            string sourceParentPath = "https://storageaccount.blob.core.windows.net/sourcecontainer";
            List<string> destinationPaths = new List<string>();
            string destinationParentPath = "https://storageaccount.blob.core.windows.net/destcontainer";
            int jobPartCount = 10;
            for (int i = 0; i < jobPartCount; i++)
            {
                string childPath = GetNewString(5);
                sourcePaths.Add(string.Join("/", sourceParentPath, childPath));
                destinationPaths.Add(string.Join("/", destinationParentPath, childPath));
            }
            DataTransferProperties transferProperties = GetProperties(
                test.DirectoryPath,
                transferId,
                sourceParentPath,
                destinationParentPath).Object;

            string originalPath = isSource ? sourceParentPath : destinationParentPath;

            StorageResourceType sourceType = isSource ? StorageResourceType.Local : StorageResourceType.BlockBlob;
            StorageResourceType destinationType = !isSource ? StorageResourceType.Local : StorageResourceType.BlockBlob;

            await AddJobPartToCheckpointer(
                checkpointer,
                transferId,
                sourceType,
                sourcePaths,
                destinationType,
                destinationPaths,
                jobPartCount);

            BlobStorageResourceContainer storageResource =
                await BlobStorageResourceContainer.RehydrateResourceAsync(transferProperties, isSource);

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
        }
    }
}
