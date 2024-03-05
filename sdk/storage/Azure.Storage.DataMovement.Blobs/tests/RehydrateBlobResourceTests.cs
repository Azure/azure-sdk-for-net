// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Test;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Moq;
using NUnit.Framework;
using static Azure.Storage.DataMovement.Tests.TransferUtility;

namespace Azure.Storage.DataMovement.Tests
{
    public class RehydrateBlobResourceTests
    {
        private const string DefaultContentType = "text/plain";
        private const string DefaultContentEncoding = "gzip";
        private const string DefaultContentLanguage = "en-US";
        private const string DefaultContentDisposition = "inline";
        private const string DefaultCacheControl = "no-cache";
        public RehydrateBlobResourceTests()
        { }

        private enum StorageResourceType
        {
            BlockBlob,
            PageBlob,
            AppendBlob,
            Local
        }

        private static string ToProviderId(StorageResourceType type)
        {
            return type switch
            {
                StorageResourceType.BlockBlob => "blob",
                StorageResourceType.PageBlob => "blob",
                StorageResourceType.AppendBlob => "blob",
                _ => throw new NotImplementedException(),
            };
        }

        private static BlobSourceCheckpointData GetSourceCheckpointData(BlobType blobType)
        {
            return new BlobSourceCheckpointData(blobType);
        }

        private static BlobDestinationCheckpointData GetPopulatedDestinationCheckpointData(
            BlobType blobType,
            AccessTier? accessTier = default)
        => new BlobDestinationCheckpointData(
                blobType: blobType,
                contentType: new(DefaultContentType),
                contentEncoding: new(DefaultContentEncoding),
                contentLanguage: new(DefaultContentLanguage),
                contentDisposition: new(DefaultContentDisposition),
                cacheControl: new(DefaultCacheControl),
                accessTier: new(accessTier),
                metadata: new(DataProvider.BuildMetadata()),
                tags: new(DataProvider.BuildTags()));

        private static BlobDestinationCheckpointData GetDefaultDestinationCheckpointData(BlobType blobType)
        => new BlobDestinationCheckpointData(
            blobType,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

        private static byte[] GetBytes(BlobCheckpointData checkpointData)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                checkpointData.Serialize(stream);
                return stream.ToArray();
            }
        }

        private static Mock<DataTransferProperties> GetProperties(
            string transferId,
            string sourcePath,
            string destinationPath,
            string sourceProviderId,
            string destinationProviderId,
            bool isContainer,
            BlobSourceCheckpointData sourceCheckpointData,
            BlobDestinationCheckpointData destinationCheckpointData)
        {
            var mock = new Mock<DataTransferProperties>(MockBehavior.Strict);
            mock.Setup(p => p.TransferId).Returns(transferId);
            mock.Setup(p => p.SourceUri).Returns(new Uri(sourcePath));
            mock.Setup(p => p.DestinationUri).Returns(new Uri(destinationPath));
            mock.Setup(p => p.SourceProviderId).Returns(sourceProviderId);
            mock.Setup(p => p.DestinationProviderId).Returns(destinationProviderId);
            mock.Setup(p => p.SourceCheckpointData).Returns(GetBytes(sourceCheckpointData));
            mock.Setup(p => p.DestinationCheckpointData).Returns(GetBytes(destinationCheckpointData));
            mock.Setup(p => p.IsContainer).Returns(isContainer);
            return mock;
        }

        [Test]
        public async Task RehydrateBlockBlob(
            [Values(true, false)] bool isSource)
        {
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";
            string originalPath = isSource ? sourcePath : destinationPath;

            StorageResourceType sourceType = StorageResourceType.BlockBlob;
            StorageResourceType destinationType = StorageResourceType.BlockBlob;

            DataTransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: false,
                GetSourceCheckpointData(BlobType.Block),
                GetDefaultDestinationCheckpointData(BlobType.Block)).Object;

            StorageResource storageResource = isSource
                ? await new BlobsStorageResourceProvider().FromSourceInternalHookAsync(transferProperties)
                : await new BlobsStorageResourceProvider().FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
            Assert.IsInstanceOf(typeof(BlockBlobStorageResource), storageResource);
        }

        [Test]
        public async Task RehydrateBlockBlob_Options()
        {
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";

            StorageResourceType sourceType = StorageResourceType.BlockBlob;
            StorageResourceType destinationType = StorageResourceType.BlockBlob;

            BlobDestinationCheckpointData checkpointData = GetPopulatedDestinationCheckpointData(BlobType.Block, AccessTier.Cool);
            DataTransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: false,
                GetSourceCheckpointData(BlobType.Block),
                checkpointData).Object;

            BlockBlobStorageResource storageResource = (BlockBlobStorageResource)await new BlobsStorageResourceProvider()
                    .FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(destinationPath, storageResource.Uri.AbsoluteUri);
            Assert.AreEqual(checkpointData.AccessTier.Preserve, storageResource._options.AccessTier.Preserve);
            Assert.AreEqual(checkpointData.AccessTier.Value, storageResource._options.AccessTier.Value);
            Assert.AreEqual(checkpointData.Metadata.Preserve, storageResource._options.Metadata.Preserve);
            Assert.AreEqual(checkpointData.Metadata.Value, storageResource._options.Metadata.Value);
            Assert.AreEqual(checkpointData.CacheControl.Preserve, storageResource._options.CacheControl.Preserve);
            Assert.AreEqual(checkpointData.CacheControl.Value, storageResource._options.CacheControl.Value);
            Assert.AreEqual(checkpointData.ContentDisposition.Preserve, storageResource._options.ContentDisposition.Preserve);
            Assert.AreEqual(checkpointData.ContentDisposition.Value, storageResource._options.ContentDisposition.Value);
            Assert.AreEqual(checkpointData.ContentEncoding.Preserve, storageResource._options.ContentEncoding.Preserve);
            Assert.AreEqual(checkpointData.ContentEncoding.Value, storageResource._options.ContentEncoding.Value);
            Assert.AreEqual(checkpointData.ContentLanguage.Preserve, storageResource._options.ContentLanguage.Preserve);
            Assert.AreEqual(checkpointData.ContentLanguage.Value, storageResource._options.ContentLanguage.Value);
            Assert.AreEqual(checkpointData.ContentType.Preserve, storageResource._options.ContentType.Preserve);
            Assert.AreEqual(checkpointData.ContentType.Value, storageResource._options.ContentType.Value);
        }

        [Test]
        public async Task RehydratePageBlob(
            [Values(true, false)] bool isSource)
        {
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";
            string originalPath = isSource ? sourcePath : destinationPath;

            StorageResourceType sourceType = StorageResourceType.PageBlob;
            StorageResourceType destinationType = StorageResourceType.PageBlob;

            DataTransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: false,
                GetSourceCheckpointData(BlobType.Page),
                GetDefaultDestinationCheckpointData(BlobType.Page)).Object;

            StorageResource storageResource = isSource
                    ? await new BlobsStorageResourceProvider().FromSourceInternalHookAsync(transferProperties)
                    : await new BlobsStorageResourceProvider().FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
            Assert.IsInstanceOf(typeof(PageBlobStorageResource), storageResource);
        }

        [Test]
        public async Task RehydratePageBlob_Options()
        {
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";

            StorageResourceType sourceType = StorageResourceType.PageBlob;
            StorageResourceType destinationType = StorageResourceType.PageBlob;

            BlobDestinationCheckpointData checkpointData = GetPopulatedDestinationCheckpointData(BlobType.Page, AccessTier.P30);
            DataTransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: false,
                GetSourceCheckpointData(BlobType.Page),
                checkpointData).Object;

            PageBlobStorageResource storageResource = (PageBlobStorageResource)await new BlobsStorageResourceProvider()
                    .FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(destinationPath, storageResource.Uri.AbsoluteUri);
            Assert.AreEqual(checkpointData.Metadata.Preserve, storageResource._options.Metadata.Preserve);
            Assert.AreEqual(checkpointData.Metadata.Value, storageResource._options.Metadata.Value);
            Assert.AreEqual(checkpointData.CacheControl.Preserve, storageResource._options.CacheControl.Preserve);
            Assert.AreEqual(checkpointData.CacheControl.Value, storageResource._options.CacheControl.Value);
            Assert.AreEqual(checkpointData.ContentDisposition.Preserve, storageResource._options.ContentDisposition.Preserve);
            Assert.AreEqual(checkpointData.ContentDisposition.Value, storageResource._options.ContentDisposition.Value);
            Assert.AreEqual(checkpointData.ContentEncoding.Preserve, storageResource._options.ContentEncoding.Preserve);
            Assert.AreEqual(checkpointData.ContentEncoding.Value, storageResource._options.ContentEncoding.Value);
            Assert.AreEqual(checkpointData.ContentLanguage.Preserve, storageResource._options.ContentLanguage.Preserve);
            Assert.AreEqual(checkpointData.ContentLanguage.Value, storageResource._options.ContentLanguage.Value);
            Assert.AreEqual(checkpointData.ContentType.Preserve, storageResource._options.ContentType.Preserve);
            Assert.AreEqual(checkpointData.ContentType.Value, storageResource._options.ContentType.Value);
        }

        [Test]
        public async Task RehydrateAppendBlob(
            [Values(true, false)] bool isSource)
        {
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";
            string originalPath = isSource ? sourcePath : destinationPath;

            StorageResourceType sourceType = StorageResourceType.AppendBlob;
            StorageResourceType destinationType = StorageResourceType.AppendBlob;

            DataTransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: false,
                GetSourceCheckpointData(BlobType.Append),
                GetDefaultDestinationCheckpointData(BlobType.Append)).Object;

            StorageResource storageResource = isSource
                    ? await new BlobsStorageResourceProvider().FromSourceInternalHookAsync(transferProperties)
                    : await new BlobsStorageResourceProvider().FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
            Assert.IsInstanceOf(typeof(AppendBlobStorageResource), storageResource);
        }

        [Test]
        public async Task RehydrateAppendBlob_Options()
        {
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";

            StorageResourceType sourceType = StorageResourceType.AppendBlob;
            StorageResourceType destinationType = StorageResourceType.AppendBlob;

            BlobDestinationCheckpointData checkpointData = GetPopulatedDestinationCheckpointData(BlobType.Append, accessTier: default);
            DataTransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: false,
                GetSourceCheckpointData(BlobType.Append),
                checkpointData).Object;

            AppendBlobStorageResource storageResource = (AppendBlobStorageResource)await new BlobsStorageResourceProvider()
                .FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(destinationPath, storageResource.Uri.AbsoluteUri);
            Assert.AreEqual(checkpointData.Metadata.Preserve, storageResource._options.Metadata.Preserve);
            Assert.AreEqual(checkpointData.Metadata.Value, storageResource._options.Metadata.Value);
            Assert.AreEqual(checkpointData.CacheControl.Preserve, storageResource._options.CacheControl.Preserve);
            Assert.AreEqual(checkpointData.CacheControl.Value, storageResource._options.CacheControl.Value);
            Assert.AreEqual(checkpointData.ContentDisposition.Preserve, storageResource._options.ContentDisposition.Preserve);
            Assert.AreEqual(checkpointData.ContentDisposition.Value, storageResource._options.ContentDisposition.Value);
            Assert.AreEqual(checkpointData.ContentEncoding.Preserve, storageResource._options.ContentEncoding.Preserve);
            Assert.AreEqual(checkpointData.ContentEncoding.Value, storageResource._options.ContentEncoding.Value);
            Assert.AreEqual(checkpointData.ContentLanguage.Preserve, storageResource._options.ContentLanguage.Preserve);
            Assert.AreEqual(checkpointData.ContentLanguage.Value, storageResource._options.ContentLanguage.Value);
            Assert.AreEqual(checkpointData.ContentType.Preserve, storageResource._options.ContentType.Preserve);
            Assert.AreEqual(checkpointData.ContentType.Value, storageResource._options.ContentType.Value);
        }

        [Test]
        public async Task RehydrateBlobContainer(
            [Values(true, false)] bool isSource)
        {
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

            StorageResourceType sourceType = StorageResourceType.BlockBlob;
            StorageResourceType destinationType = StorageResourceType.BlockBlob;

            string originalPath = isSource ? sourceParentPath : destinationParentPath;

            DataTransferProperties transferProperties = GetProperties(
                transferId,
                sourceParentPath,
                destinationParentPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: true,
                GetSourceCheckpointData(BlobType.Block),
                GetDefaultDestinationCheckpointData(BlobType.Block)).Object;

            StorageResource storageResource = isSource
                    ? await new BlobsStorageResourceProvider().FromSourceInternalHookAsync(transferProperties)
                    : await new BlobsStorageResourceProvider().FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
            Assert.IsInstanceOf(typeof(BlobStorageResourceContainer), storageResource);
        }
    }
}
