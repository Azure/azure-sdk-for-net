// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Models.JobPlan;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class RehydrateStorageResourceTests : DataMovementTestBase
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
            ProviderInstance,

            /// <summary>
            /// The public, package-wide static API for rehydrating.
            /// </summary>
            PublicStaticApi
        }
        public static IEnumerable<RehydrateApi> GetRehydrateApis() => Enum.GetValues(typeof(RehydrateApi)).Cast<RehydrateApi>();

        public RehydrateStorageResourceTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
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
            mock.Setup(p => p.Checkpointer).Returns(new TransferCheckpointerOptions(checkpointerPath));
            mock.Setup(p => p.SourcePath).Returns(sourcePath);
            mock.Setup(p => p.DestinationPath).Returns(destinationPath);
            mock.Setup(p => p.SourceScheme).Returns(sourceResourceId);
            mock.Setup(p => p.DestinationScheme).Returns(destinationResourceId);
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
            return getSource ? sourceProvider.MakeResource() : destinationProvider.MakeResource();
        }

        [Test]
        [Combinatorial]
        public async Task RehydrateLocalFile(
            [Values(true, false)] bool isSource,
            [ValueSource(nameof(GetRehydrateApis))] RehydrateApi api)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourcePath = GetNewString(20);
            string destinationPath = GetNewString(15);
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

            LocalFileStorageResource storageResource = api switch
            {
                RehydrateApi.ResourceStaticApi => LocalFileStorageResource.RehydrateResource(transferProperties, isSource),
                RehydrateApi.ProviderInstance => (LocalFileStorageResource)new LocalStorageResourceProvider(
                    transferProperties, isSource, isFolder: false).MakeResource(),
                RehydrateApi.PublicStaticApi => (LocalFileStorageResource)LocalStorageResourcesInlineTryGet(
                    transferProperties, isSource),
                _ => throw new ArgumentException("Unrecognized test parameter"),
            };

            Assert.AreEqual(originalPath, storageResource.Path);
        }

        [Test]
        [Combinatorial]
        public async Task RehydrateLocalDirectory(
            [Values(true, false)] bool isSource,
            [ValueSource(nameof(GetRehydrateApis))] RehydrateApi api)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourceParentPath = GetNewString(20);
            List<string> sourcePaths = new List<string>();
            string destinationParentPath = GetNewString(15);
            List<string> destinationPaths = new List<string>();
            int jobPartCount = 10;
            for (int i = 0; i< jobPartCount; i++)
            {
                string childPath = GetNewString(5);
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

            LocalDirectoryStorageResourceContainer storageResource = api switch
            {
                RehydrateApi.ResourceStaticApi => LocalDirectoryStorageResourceContainer.RehydrateResource(transferProperties, isSource),
                RehydrateApi.ProviderInstance => (LocalDirectoryStorageResourceContainer)new LocalStorageResourceProvider(
                    transferProperties, isSource, isFolder: true).MakeResource(),
                RehydrateApi.PublicStaticApi => (LocalDirectoryStorageResourceContainer)LocalStorageResourcesInlineTryGet(
                    transferProperties, isSource),
                _ => throw new ArgumentException("Unrecognized test parameter"),
            };

            Assert.AreEqual(originalPath, storageResource.Path);
        }
    }
}
