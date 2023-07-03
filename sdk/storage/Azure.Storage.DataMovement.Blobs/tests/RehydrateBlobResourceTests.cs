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

        private static string ToResourceId(StorageResourceType type)
        {
            return type switch
            {
                StorageResourceType.BlockBlob => "BlockBlob",
                StorageResourceType.PageBlob => "PageBlob",
                StorageResourceType.AppendBlob => "AppendBlob",
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
        private async Task<StorageResource> AzureBlobStorageResourcesInlineTryGet(DataTransferProperties info, bool getSource)
        {
            if (!BlobStorageResources.TryGetResourceProviders(
                info,
                out BlobStorageResourceProvider sourceProvider,
                out BlobStorageResourceProvider destinationProvider))
            {
                return null;
            }
            return getSource ? await sourceProvider.MakeResourceAsync() : await destinationProvider.MakeResourceAsync();
        }

        [Test]
        [Combinatorial]
        public async Task RehydrateBlockBlob(
            [Values(true, false)] bool isSource,
            [ValueSource(nameof(GetRehydrateApis))] RehydrateApi api)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";
            string originalPath = isSource ? sourcePath : destinationPath;

            StorageResourceType sourceType = !isSource ? StorageResourceType.Local : StorageResourceType.BlockBlob;
            StorageResourceType destinationType = isSource ? StorageResourceType.Local : StorageResourceType.BlockBlob;

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
                new List<string>() { destinationPath });

            BlockBlobStorageResource storageResource = api switch
            {
                RehydrateApi.ResourceStaticApi => await BlockBlobStorageResource.RehydrateResourceAsync(transferProperties, isSource),
                RehydrateApi.ProviderInstance => (BlockBlobStorageResource)await new BlobStorageResourceProvider(
                    transferProperties, isSource, BlobStorageResources.ResourceType.BlockBlob).MakeResourceAsync(),
                RehydrateApi.PublicStaticApi => (BlockBlobStorageResource)await AzureBlobStorageResourcesInlineTryGet(
                    transferProperties, isSource),
                _ => throw new ArgumentException("Unrecognized test parameter"),
            };

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
        }

        [Test]
        [Combinatorial]
        public async Task RehydratePageBlob(
            [Values(true, false)] bool isSource,
            [ValueSource(nameof(GetRehydrateApis))] RehydrateApi api)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";
            string originalPath = isSource ? sourcePath : destinationPath;

            StorageResourceType sourceType = !isSource ? StorageResourceType.Local : StorageResourceType.PageBlob;
            StorageResourceType destinationType = isSource ? StorageResourceType.Local : StorageResourceType.PageBlob;

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
                new List<string>() { destinationPath });

            PageBlobStorageResource storageResource = api switch
            {
                RehydrateApi.ResourceStaticApi => await PageBlobStorageResource.RehydrateResourceAsync(transferProperties, isSource),
                RehydrateApi.ProviderInstance => (PageBlobStorageResource)await new BlobStorageResourceProvider(
                    transferProperties, isSource, BlobStorageResources.ResourceType.PageBlob).MakeResourceAsync(),
                RehydrateApi.PublicStaticApi => (PageBlobStorageResource)await AzureBlobStorageResourcesInlineTryGet(
                    transferProperties, isSource),
                _ => throw new ArgumentException("Unrecognized test parameter"),
            };

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
        }

        [Test]
        [Combinatorial]
        public async Task RehydrateAppendBlob(
            [Values(true, false)] bool isSource,
            [ValueSource(nameof(GetRehydrateApis))] RehydrateApi api)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";
            string originalPath = isSource ? sourcePath : destinationPath;

            StorageResourceType sourceType = !isSource ? StorageResourceType.Local : StorageResourceType.AppendBlob;
            StorageResourceType destinationType = isSource ? StorageResourceType.Local : StorageResourceType.AppendBlob;

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
                new List<string>() { destinationPath });

            AppendBlobStorageResource storageResource = api switch
            {
                RehydrateApi.ResourceStaticApi => await AppendBlobStorageResource.RehydrateResourceAsync(transferProperties, isSource),
                RehydrateApi.ProviderInstance => (AppendBlobStorageResource)await new BlobStorageResourceProvider(
                    transferProperties, isSource, BlobStorageResources.ResourceType.AppendBlob).MakeResourceAsync(),
                RehydrateApi.PublicStaticApi => (AppendBlobStorageResource)await AzureBlobStorageResourcesInlineTryGet(
                    transferProperties, isSource),
                _ => throw new ArgumentException("Unrecognized test parameter"),
            };

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
        }

        [Test]
        [Combinatorial]
        public async Task RehydrateBlobContainer(
            [Values(true, false)] bool isSource,
            [ValueSource(nameof(GetRehydrateApis))] RehydrateApi api)
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

            StorageResourceType sourceType = !isSource ? StorageResourceType.Local : StorageResourceType.BlockBlob;
            StorageResourceType destinationType = isSource ? StorageResourceType.Local : StorageResourceType.BlockBlob;

            string originalPath = isSource ? sourceParentPath : destinationParentPath;

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

            BlobStorageResourceContainer storageResource = api switch
            {
                RehydrateApi.ResourceStaticApi => await BlobStorageResourceContainer.RehydrateResourceAsync(transferProperties, isSource),
                RehydrateApi.ProviderInstance => (BlobStorageResourceContainer)await new BlobStorageResourceProvider(
                    transferProperties, isSource, BlobStorageResources.ResourceType.BlobContainer).MakeResourceAsync(),
                RehydrateApi.PublicStaticApi => (BlobStorageResourceContainer)await AzureBlobStorageResourcesInlineTryGet(
                    transferProperties, isSource),
                _ => throw new ArgumentException("Unrecognized test parameter"),
            };

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
        }
    }
}
