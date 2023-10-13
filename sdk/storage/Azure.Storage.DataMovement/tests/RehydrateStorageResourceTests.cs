// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.JobPlan;
using Azure.Storage.Tests;
using Moq;
using NUnit.Framework;
using static Azure.Storage.DataMovement.Tests.TransferUtility;

namespace Azure.Storage.DataMovement.Tests
{
    public class RehydrateStorageResourceTests
    {
        public RehydrateStorageResourceTests()
        { }

        private enum StorageResourceType
        {
            BlockBlob,
            Local
        }

        private static string ToResourceId(StorageResourceType type)
        {
            return type switch
            {
                StorageResourceType.BlockBlob => "BlockBlob",
                StorageResourceType.Local => "LocalFile",
                _ => throw new NotImplementedException(),
            };
        }

        private static Mock<DataTransferProperties> GetProperties(
            string checkpointerPath,
            string transferId,
            string sourcePath,
            string destinationPath,
            string sourceResourceId,
            string destinationResourceId,
            bool isContainer)
        {
            UriBuilder sourceBuilder = new UriBuilder()
            {
                Scheme = Uri.UriSchemeFile,
                Host = "",
                Path = sourcePath,
            };
            UriBuilder destinationBuilder = new UriBuilder()
            {
                Scheme = Uri.UriSchemeFile,
                Host = "",
                Path = destinationPath,
            };

            var mock = new Mock<DataTransferProperties>(MockBehavior.Strict);
            mock.Setup(p => p.TransferId).Returns(transferId);
            mock.Setup(p => p.Checkpointer).Returns(new TransferCheckpointStoreOptions(checkpointerPath));
            mock.Setup(p => p.SourceUri).Returns(sourceBuilder.Uri);
            mock.Setup(p => p.DestinationUri).Returns(destinationBuilder.Uri);
            mock.Setup(p => p.SourceTypeId).Returns(sourceResourceId);
            mock.Setup(p => p.DestinationTypeId).Returns(destinationResourceId);
            mock.Setup(p => p.IsContainer).Returns(isContainer);
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

            JobPlanOperation operationType;
            if (sourceType == StorageResourceType.Local)
            {
                operationType = JobPlanOperation.Upload;
            }
            else if (destinatonType == StorageResourceType.Local)
            {
                operationType = JobPlanOperation.Download;
            }
            else
            {
                operationType = JobPlanOperation.ServiceToService;
            }

            // Use dummy resources that don't correspond to correct paths
            StorageResource source = MockStorageResource.MakeSourceResource(10);
            StorageResource destination = MockStorageResource.MakeDestinationResource();
            await checkpointer.AddNewJobAsync(transferId, source, destination);

            for (int currentPart = 0; currentPart < partCount; currentPart++)
            {
                JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: currentPart,
                    sourcePath: sourcePaths[currentPart],
                    destinationPath: destinationPaths[currentPart],
                    fromTo: operationType);

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
        public async Task RehydrateLocalFile(
            [Values(true, false)] bool isSource)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            Random random = new();
            string transferId = GetNewTransferId();
            string sourcePath = string.Concat("/", random.NextString(20));
            string destinationPath = string.Concat("/", random.NextString(15));
            string originalPath = isSource ? sourcePath : destinationPath;

            StorageResourceType sourceType = !isSource ? StorageResourceType.BlockBlob : StorageResourceType.Local;
            StorageResourceType destinationType = isSource ? StorageResourceType.BlockBlob : StorageResourceType.Local;

            DataTransferProperties transferProperties = GetProperties(
                test.DirectoryPath,
                transferId,
                sourcePath,
                destinationPath,
                ToResourceId(sourceType),
                ToResourceId(destinationType),
                isContainer: false).Object;

            await AddJobPartToCheckpointer(
                checkpointer,
                transferId,
                sourceType,
                new List<string>() { sourcePath },
                destinationType,
                new List<string>() { destinationPath } );

            StorageResource storageResource = isSource
                    ? await new LocalFilesStorageResourceProvider().FromSourceAsync(transferProperties, CancellationToken.None)
                    : await new LocalFilesStorageResourceProvider().FromDestinationAsync(transferProperties, CancellationToken.None);

            Assert.AreEqual(originalPath, storageResource.Uri.LocalPath);
            Assert.IsInstanceOf(typeof(LocalFileStorageResource), storageResource);
        }

        [Test]
        public async Task RehydrateLocalDirectory(
            [Values(true, false)] bool isSource)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            Random random = new();
            string transferId = GetNewTransferId();
            string sourceParentPath = string.Concat("/", random.NextString(20));
            List<string> sourcePaths = new List<string>();
            string destinationParentPath = string.Concat("/", random.NextString(15));
            List<string> destinationPaths = new List<string>();
            int jobPartCount = 10;
            for (int i = 0; i< jobPartCount; i++)
            {
                string childPath = random.NextString(5);
                sourcePaths.Add(Path.Combine(sourceParentPath, childPath));
                destinationPaths.Add(Path.Combine(destinationParentPath, childPath));
            }
            string originalPath = isSource ? sourceParentPath : destinationParentPath;

            StorageResourceType sourceType = !isSource ? StorageResourceType.BlockBlob : StorageResourceType.Local;
            StorageResourceType destinationType = isSource ? StorageResourceType.BlockBlob : StorageResourceType.Local;

            DataTransferProperties transferProperties = GetProperties(
                test.DirectoryPath,
                transferId,
                sourceParentPath,
                destinationParentPath,
                ToResourceId(sourceType),
                ToResourceId(destinationType),
                isContainer: true).Object;

            await AddJobPartToCheckpointer(
                checkpointer,
                transferId,
                sourceType,
                sourcePaths,
                destinationType,
                destinationPaths,
                jobPartCount);

            StorageResource storageResource = isSource
                    ? await new LocalFilesStorageResourceProvider().FromSourceAsync(transferProperties, CancellationToken.None)
                    : await new LocalFilesStorageResourceProvider().FromDestinationAsync(transferProperties, CancellationToken.None);

            Assert.AreEqual(originalPath, storageResource.Uri.LocalPath);
            Assert.IsInstanceOf(typeof(LocalDirectoryStorageResourceContainer), storageResource);
        }
    }
}
