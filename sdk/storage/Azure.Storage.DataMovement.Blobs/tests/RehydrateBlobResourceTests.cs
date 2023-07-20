// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Models.JobPlan;
using Azure.Storage.Test;
using Moq;
using NUnit.Framework;
using static Azure.Storage.DataMovement.Tests.TransferUtility;

namespace Azure.Storage.DataMovement.Tests
{
    public class RehydrateBlobResourceTests
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

        public RehydrateBlobResourceTests()
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

        private JobPlanOperation GetPlanOperation(
            StorageResourceType sourceType,
            StorageResourceType destinationType)
        {
            if (sourceType == StorageResourceType.Local)
            {
                return JobPlanOperation.Upload;
            }
            else if (destinationType == StorageResourceType.Local)
            {
                return JobPlanOperation.Download;
            }
            return JobPlanOperation.ServiceToService;
        }

        private async Task AddJobPartToCheckpointer(
            TransferCheckpointer checkpointer,
            string transferId,
            StorageResourceType sourceType,
            List<string> sourcePaths,
            StorageResourceType destinationType,
            List<string> destinationPaths,
            int partCount = 1,
            JobPartPlanHeader header = default)
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

            JobPlanOperation fromTo = GetPlanOperation(sourceType, destinationType);

            await checkpointer.AddNewJobAsync(transferId);

            for (int currentPart = 0; currentPart < partCount; currentPart++)
            {
                header ??= CheckpointerTesting.CreateDefaultJobPartHeader(
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
        public async Task RehydrateBlockBlob_Options(
            [ValueSource(nameof(GetRehydrateApis))] RehydrateApi api)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";

            StorageResourceType sourceType = StorageResourceType.Local;
            StorageResourceType destinationType = StorageResourceType.BlockBlob;

            DataTransferProperties transferProperties = GetProperties(
                test.DirectoryPath,
                transferId,
                sourcePath,
                destinationPath,
                ToResourceId(sourceType),
                ToResourceId(destinationType),
                isContainer: false).Object;

            IDictionary<string, string> metadata = DataProvider.BuildMetadata();
            IDictionary<string, string> blobTags = DataProvider.BuildTags();

            JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 0,
                    sourcePath: sourcePath,
                    destinationPath: destinationPath,
                    fromTo: GetPlanOperation(sourceType, destinationType),
                    blobTags: blobTags,
                    metadata: metadata,
                    blockBlobTier: JobPartPlanBlockBlobTier.Cool);

            await AddJobPartToCheckpointer(
                checkpointer,
                transferId,
                sourceType,
                new List<string>() { sourcePath },
                destinationType,
                new List<string>() { destinationPath },
                header: header);

            BlockBlobStorageResource storageResource = api switch
            {
                RehydrateApi.ResourceStaticApi => await BlockBlobStorageResource.RehydrateResourceAsync(transferProperties, false),
                RehydrateApi.ProviderInstance => (BlockBlobStorageResource)await new BlobStorageResourceProvider(
                    transferProperties, false, BlobStorageResources.ResourceType.BlockBlob).MakeResourceAsync(),
                RehydrateApi.PublicStaticApi => (BlockBlobStorageResource)await AzureBlobStorageResourcesInlineTryGet(
                    transferProperties, false),
                _ => throw new ArgumentException("Unrecognized test parameter"),
            };

            Assert.AreEqual(destinationPath, storageResource.Uri.AbsoluteUri);
            Assert.AreEqual(AccessTier.Cool, storageResource._options.AccessTier);
            Assert.AreEqual(metadata, storageResource._options.Metadata);
            Assert.AreEqual(blobTags, storageResource._options.Tags);
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
        public async Task RehydratePageBlob_Options(
            [ValueSource(nameof(GetRehydrateApis))] RehydrateApi api)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";

            StorageResourceType sourceType = StorageResourceType.Local;
            StorageResourceType destinationType = StorageResourceType.PageBlob;

            DataTransferProperties transferProperties = GetProperties(
                test.DirectoryPath,
                transferId,
                sourcePath,
                destinationPath,
                ToResourceId(sourceType),
                ToResourceId(destinationType),
                isContainer: false).Object;

            IDictionary<string, string> metadata = DataProvider.BuildMetadata();
            IDictionary<string, string> blobTags = DataProvider.BuildTags();

            JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 0,
                    sourcePath: sourcePath,
                    destinationPath: destinationPath,
                    fromTo: GetPlanOperation(sourceType, destinationType),
                    blobTags: blobTags,
                    metadata: metadata,
                    pageBlobTier: JobPartPlanPageBlobTier.P30);

            await AddJobPartToCheckpointer(
                checkpointer,
                transferId,
                sourceType,
                new List<string>() { sourcePath },
                destinationType,
                new List<string>() { destinationPath },
                header: header);

            PageBlobStorageResource storageResource = api switch
            {
                RehydrateApi.ResourceStaticApi => await PageBlobStorageResource.RehydrateResourceAsync(transferProperties, false),
                RehydrateApi.ProviderInstance => (PageBlobStorageResource)await new BlobStorageResourceProvider(
                    transferProperties, false, BlobStorageResources.ResourceType.PageBlob).MakeResourceAsync(),
                RehydrateApi.PublicStaticApi => (PageBlobStorageResource)await AzureBlobStorageResourcesInlineTryGet(
                    transferProperties, false),
                _ => throw new ArgumentException("Unrecognized test parameter"),
            };

            Assert.AreEqual(destinationPath, storageResource.Uri.AbsoluteUri);
            Assert.AreEqual(AccessTier.P30, storageResource._options.AccessTier);
            Assert.AreEqual(metadata, storageResource._options.Metadata);
            Assert.AreEqual(blobTags, storageResource._options.Tags);
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
        public async Task RehydrateAppendBlob_Options(
            [ValueSource(nameof(GetRehydrateApis))] RehydrateApi api)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            TransferCheckpointer checkpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";

            StorageResourceType sourceType = StorageResourceType.Local;
            StorageResourceType destinationType = StorageResourceType.AppendBlob;

            DataTransferProperties transferProperties = GetProperties(
                test.DirectoryPath,
                transferId,
                sourcePath,
                destinationPath,
                ToResourceId(sourceType),
                ToResourceId(destinationType),
                isContainer: false).Object;

            IDictionary<string, string> metadata = DataProvider.BuildMetadata();
            IDictionary<string, string> blobTags = DataProvider.BuildTags();

            JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 0,
                    sourcePath: sourcePath,
                    destinationPath: destinationPath,
                    fromTo: GetPlanOperation(sourceType, destinationType),
                    blobTags: blobTags,
                    metadata: metadata);

            await AddJobPartToCheckpointer(
                checkpointer,
                transferId,
                sourceType,
                new List<string>() { sourcePath },
                destinationType,
                new List<string>() { destinationPath },
                header: header);

            AppendBlobStorageResource storageResource = api switch
            {
                RehydrateApi.ResourceStaticApi => await AppendBlobStorageResource.RehydrateResourceAsync(transferProperties, false),
                RehydrateApi.ProviderInstance => (AppendBlobStorageResource)await new BlobStorageResourceProvider(
                    transferProperties, false, BlobStorageResources.ResourceType.AppendBlob).MakeResourceAsync(),
                RehydrateApi.PublicStaticApi => (AppendBlobStorageResource)await AzureBlobStorageResourcesInlineTryGet(
                    transferProperties, false),
                _ => throw new ArgumentException("Unrecognized test parameter"),
            };

            Assert.AreEqual(destinationPath, storageResource.Uri.AbsoluteUri);
            Assert.AreEqual(metadata, storageResource._options.Metadata);
            Assert.AreEqual(blobTags, storageResource._options.Tags);
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
                string childPath = DataProvider.GetNewString(5);
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
