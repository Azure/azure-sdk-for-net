// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public enum RehydrateApi
        {
            /// <summary>
            /// The internal, resource-specific static API for rehydrating.
            /// </summary>
            ResourceStaticApi,

            /// <summary>
            /// Instance of the provider the user is given to invoke rehydration on.
            /// </summary>
            ProviderInstanceOLD,

            /// <summary>
            /// The public, package-wide static API for rehydrating.
            /// </summary>
            PublicStaticApiOLD,

            /// <summary>
            /// New provider system for creating resources.
            /// </summary>
            Provider
        }
        public static IEnumerable<RehydrateApi> GetRehydrateApis() => Enum.GetValues(typeof(RehydrateApi)).Cast<RehydrateApi>();

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
            var mock = new Mock<DataTransferProperties>(MockBehavior.Strict);
            mock.Setup(p => p.TransferId).Returns(transferId);
            mock.Setup(p => p.Checkpointer).Returns(new TransferCheckpointStoreOptions(checkpointerPath));
            mock.Setup(p => p.SourcePath).Returns(sourcePath);
            mock.Setup(p => p.DestinationPath).Returns(destinationPath);
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
                JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
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

        /// <summary>
        /// Inlines the tryget to allow for switch expressions in tests.
        /// </summary>
        private StorageResource LocalStorageResourcesInlineTryGet(DataTransferProperties info, bool getSource)
        {
            if (!LocalStorageResources.TryGetResourceProviders(
                info,
                out LocalStorageResourceProvider sourceProvider,
                out LocalStorageResourceProvider destinationProvider))
            {
                return null;
            }
            return getSource ? sourceProvider.CreateResource() : destinationProvider.CreateResource();
        }

        [Test]
        [Combinatorial]
        public async Task RehydrateLocalFile(
            [Values(true, false)] bool isSource,
            [ValueSource(nameof(GetRehydrateApis))] RehydrateApi api)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            Random random = new();
            string transferId = GetNewTransferId();
            string sourcePath = random.NextString(20);
            string destinationPath = random.NextString(15);
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

            StorageResource storageResource = api switch
            {
                RehydrateApi.ResourceStaticApi => LocalFileStorageResource.RehydrateResource(transferProperties, isSource),
                RehydrateApi.ProviderInstanceOLD => new LocalStorageResourceProvider(
                    transferProperties, isSource, isFolder: false).CreateResource(),
                RehydrateApi.PublicStaticApiOLD => LocalStorageResourcesInlineTryGet(
                    transferProperties, isSource),
                RehydrateApi.Provider => isSource
                    ? await new LocalFilesStorageResourceProvider().FromSourceAsync(transferProperties, CancellationToken.None)
                    : await new LocalFilesStorageResourceProvider().FromDestinationAsync(transferProperties, CancellationToken.None),
                _ => throw new ArgumentException("Unrecognized test parameter"),
            };

            Assert.AreEqual(originalPath, storageResource.Path);
            Assert.IsInstanceOf(typeof(LocalFileStorageResource), storageResource);
        }

        [Test]
        [Combinatorial]
        public async Task RehydrateLocalDirectory(
            [Values(true, false)] bool isSource,
            [ValueSource(nameof(GetRehydrateApis))] RehydrateApi api)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            Random random = new();
            string transferId = GetNewTransferId();
            string sourceParentPath = random.NextString(20);
            List<string> sourcePaths = new List<string>();
            string destinationParentPath = random.NextString(15);
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

            StorageResource storageResource = api switch
            {
                RehydrateApi.ResourceStaticApi => LocalDirectoryStorageResourceContainer.RehydrateResource(transferProperties, isSource),
                RehydrateApi.ProviderInstanceOLD => new LocalStorageResourceProvider(
                    transferProperties, isSource, isFolder: true).CreateResource(),
                RehydrateApi.PublicStaticApiOLD => LocalStorageResourcesInlineTryGet(
                    transferProperties, isSource),
                RehydrateApi.Provider => isSource
                    ? await new LocalFilesStorageResourceProvider().FromSourceAsync(transferProperties, CancellationToken.None)
                    : await new LocalFilesStorageResourceProvider().FromDestinationAsync(transferProperties, CancellationToken.None),
                _ => throw new ArgumentException("Unrecognized test parameter"),
            };

            Assert.AreEqual(originalPath, storageResource.Path);
            Assert.IsInstanceOf(typeof(LocalDirectoryStorageResourceContainer), storageResource);
        }
    }
}
