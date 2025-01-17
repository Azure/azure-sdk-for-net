// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
extern alias BaseBlobs;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BaseBlobs::Azure.Storage.Blobs.Models;
using Azure.Storage.Test;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class RehydrateBlobResourceTests
    {
        private const string DefaultContentType = "text/plain";
        private const string DefaultContentEncoding = "gzip";
        private const string DefaultContentLanguage = "en-US";
        private const string DefaultContentDisposition = "inline";
        private const string DefaultCacheControl = "no-cache";
        private static string GetNewTransferId() => Guid.NewGuid().ToString();
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

        private static BlobSourceCheckpointDetails GetSourceCheckpointDetails()
        {
            return new BlobSourceCheckpointDetails();
        }

        private static BlobDestinationCheckpointDetails GetPopulatedDestinationCheckpointDetails(
            BlobType blobType,
            AccessTier? accessTier = default)
        => new BlobDestinationCheckpointDetails(
                blobType: new(blobType),
                contentType: new(DefaultContentType),
                contentEncoding: new(DefaultContentEncoding),
                contentLanguage: new(DefaultContentLanguage),
                contentDisposition: new(DefaultContentDisposition),
                cacheControl: new(DefaultCacheControl),
                accessTier: accessTier,
                metadata: new(DataProvider.BuildMetadata()),
                tags: new(DataProvider.BuildTags()));

        private static BlobDestinationCheckpointDetails GetDefaultDestinationCheckpointDetails(BlobType blobType)
        => new BlobDestinationCheckpointDetails(
            new(blobType),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

        private static byte[] GetBytes(StorageResourceCheckpointDetails checkpointDetails)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                checkpointDetails.Serialize(stream);
                return stream.ToArray();
            }
        }

        private static Mock<TransferProperties> GetProperties(
            string transferId,
            string sourcePath,
            string destinationPath,
            string sourceProviderId,
            string destinationProviderId,
            bool isContainer,
            BlobSourceCheckpointDetails sourceCheckpointDetails,
            BlobDestinationCheckpointDetails destinationCheckpointDetails)
        {
            var mock = new Mock<TransferProperties>(MockBehavior.Strict);
            mock.Setup(p => p.TransferId).Returns(transferId);
            mock.Setup(p => p.SourceUri).Returns(new Uri(sourcePath));
            mock.Setup(p => p.DestinationUri).Returns(new Uri(destinationPath));
            mock.Setup(p => p.SourceProviderId).Returns(sourceProviderId);
            mock.Setup(p => p.DestinationProviderId).Returns(destinationProviderId);
            mock.Setup(p => p.SourceCheckpointDetails).Returns(GetBytes(sourceCheckpointDetails));
            mock.Setup(p => p.DestinationCheckpointDetails).Returns(GetBytes(destinationCheckpointDetails));
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

            TransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: false,
                GetSourceCheckpointDetails(),
                GetDefaultDestinationCheckpointDetails(BlobType.Block)).Object;

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

            BlobDestinationCheckpointDetails checkpointDetails = GetPopulatedDestinationCheckpointDetails(BlobType.Block, AccessTier.Cool);
            TransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: false,
                GetSourceCheckpointDetails(),
                checkpointDetails).Object;

            BlockBlobStorageResource storageResource = (BlockBlobStorageResource)await new BlobsStorageResourceProvider()
                    .FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(destinationPath, storageResource.Uri.AbsoluteUri);
            Assert.AreEqual(checkpointDetails.AccessTierValue.Value, storageResource._options.AccessTier.Value);
            Assert.AreEqual(checkpointDetails.Metadata.Preserve, storageResource._options.Metadata.Preserve);
            Assert.AreEqual(checkpointDetails.Metadata.Value, storageResource._options.Metadata.Value);
            Assert.AreEqual(checkpointDetails.CacheControl.Preserve, storageResource._options.CacheControl.Preserve);
            Assert.AreEqual(checkpointDetails.CacheControl.Value, storageResource._options.CacheControl.Value);
            Assert.AreEqual(checkpointDetails.ContentDisposition.Preserve, storageResource._options.ContentDisposition.Preserve);
            Assert.AreEqual(checkpointDetails.ContentDisposition.Value, storageResource._options.ContentDisposition.Value);
            Assert.AreEqual(checkpointDetails.ContentEncoding.Preserve, storageResource._options.ContentEncoding.Preserve);
            Assert.AreEqual(checkpointDetails.ContentEncoding.Value, storageResource._options.ContentEncoding.Value);
            Assert.AreEqual(checkpointDetails.ContentLanguage.Preserve, storageResource._options.ContentLanguage.Preserve);
            Assert.AreEqual(checkpointDetails.ContentLanguage.Value, storageResource._options.ContentLanguage.Value);
            Assert.AreEqual(checkpointDetails.ContentType.Preserve, storageResource._options.ContentType.Preserve);
            Assert.AreEqual(checkpointDetails.ContentType.Value, storageResource._options.ContentType.Value);
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

            TransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: false,
                GetSourceCheckpointDetails(),
                GetDefaultDestinationCheckpointDetails(BlobType.Page)).Object;

            StorageResource storageResource = isSource
                    ? await new BlobsStorageResourceProvider().FromSourceInternalHookAsync(transferProperties)
                    : await new BlobsStorageResourceProvider().FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
            if (isSource)
            {
                Assert.IsInstanceOf(typeof(BlockBlobStorageResource), storageResource);
            }
            else
            {
                Assert.IsInstanceOf(typeof(PageBlobStorageResource), storageResource);
            }
        }

        [Test]
        public async Task RehydratePageBlob_Options()
        {
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";

            StorageResourceType sourceType = StorageResourceType.PageBlob;
            StorageResourceType destinationType = StorageResourceType.PageBlob;

            BlobDestinationCheckpointDetails checkpointDetails = GetPopulatedDestinationCheckpointDetails(BlobType.Page, AccessTier.P30);
            TransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: false,
                GetSourceCheckpointDetails(),
                checkpointDetails).Object;

            PageBlobStorageResource storageResource = (PageBlobStorageResource)await new BlobsStorageResourceProvider()
                    .FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(destinationPath, storageResource.Uri.AbsoluteUri);
            Assert.AreEqual(checkpointDetails.Metadata.Preserve, storageResource._options.Metadata.Preserve);
            Assert.AreEqual(checkpointDetails.Metadata.Value, storageResource._options.Metadata.Value);
            Assert.AreEqual(checkpointDetails.CacheControl.Preserve, storageResource._options.CacheControl.Preserve);
            Assert.AreEqual(checkpointDetails.CacheControl.Value, storageResource._options.CacheControl.Value);
            Assert.AreEqual(checkpointDetails.ContentDisposition.Preserve, storageResource._options.ContentDisposition.Preserve);
            Assert.AreEqual(checkpointDetails.ContentDisposition.Value, storageResource._options.ContentDisposition.Value);
            Assert.AreEqual(checkpointDetails.ContentEncoding.Preserve, storageResource._options.ContentEncoding.Preserve);
            Assert.AreEqual(checkpointDetails.ContentEncoding.Value, storageResource._options.ContentEncoding.Value);
            Assert.AreEqual(checkpointDetails.ContentLanguage.Preserve, storageResource._options.ContentLanguage.Preserve);
            Assert.AreEqual(checkpointDetails.ContentLanguage.Value, storageResource._options.ContentLanguage.Value);
            Assert.AreEqual(checkpointDetails.ContentType.Preserve, storageResource._options.ContentType.Preserve);
            Assert.AreEqual(checkpointDetails.ContentType.Value, storageResource._options.ContentType.Value);
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

            TransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: false,
                GetSourceCheckpointDetails(),
                GetDefaultDestinationCheckpointDetails(BlobType.Append)).Object;

            StorageResource storageResource = isSource
                    ? await new BlobsStorageResourceProvider().FromSourceInternalHookAsync(transferProperties)
                    : await new BlobsStorageResourceProvider().FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
            if (isSource)
            {
                Assert.IsInstanceOf(typeof(BlockBlobStorageResource), storageResource);
            }
            else
            {
                Assert.IsInstanceOf(typeof(AppendBlobStorageResource), storageResource);
            }
        }

        [Test]
        public async Task RehydrateAppendBlob_Options()
        {
            string transferId = GetNewTransferId();
            string sourcePath = "https://storageaccount.blob.core.windows.net/container/blobsource";
            string destinationPath = "https://storageaccount.blob.core.windows.net/container/blobdest";

            StorageResourceType sourceType = StorageResourceType.AppendBlob;
            StorageResourceType destinationType = StorageResourceType.AppendBlob;

            BlobDestinationCheckpointDetails checkpointDetails = GetPopulatedDestinationCheckpointDetails(BlobType.Append, accessTier: default);
            TransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: false,
                GetSourceCheckpointDetails(),
                checkpointDetails).Object;

            AppendBlobStorageResource storageResource = (AppendBlobStorageResource)await new BlobsStorageResourceProvider()
                .FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(destinationPath, storageResource.Uri.AbsoluteUri);
            Assert.AreEqual(checkpointDetails.Metadata.Preserve, storageResource._options.Metadata.Preserve);
            Assert.AreEqual(checkpointDetails.Metadata.Value, storageResource._options.Metadata.Value);
            Assert.AreEqual(checkpointDetails.CacheControl.Preserve, storageResource._options.CacheControl.Preserve);
            Assert.AreEqual(checkpointDetails.CacheControl.Value, storageResource._options.CacheControl.Value);
            Assert.AreEqual(checkpointDetails.ContentDisposition.Preserve, storageResource._options.ContentDisposition.Preserve);
            Assert.AreEqual(checkpointDetails.ContentDisposition.Value, storageResource._options.ContentDisposition.Value);
            Assert.AreEqual(checkpointDetails.ContentEncoding.Preserve, storageResource._options.ContentEncoding.Preserve);
            Assert.AreEqual(checkpointDetails.ContentEncoding.Value, storageResource._options.ContentEncoding.Value);
            Assert.AreEqual(checkpointDetails.ContentLanguage.Preserve, storageResource._options.ContentLanguage.Preserve);
            Assert.AreEqual(checkpointDetails.ContentLanguage.Value, storageResource._options.ContentLanguage.Value);
            Assert.AreEqual(checkpointDetails.ContentType.Preserve, storageResource._options.ContentType.Preserve);
            Assert.AreEqual(checkpointDetails.ContentType.Value, storageResource._options.ContentType.Value);
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

            TransferProperties transferProperties = GetProperties(
                transferId,
                sourceParentPath,
                destinationParentPath,
                ToProviderId(sourceType),
                ToProviderId(destinationType),
                isContainer: true,
                GetSourceCheckpointDetails(),
                GetDefaultDestinationCheckpointDetails(BlobType.Block)).Object;

            StorageResource storageResource = isSource
                    ? await new BlobsStorageResourceProvider().FromSourceInternalHookAsync(transferProperties)
                    : await new BlobsStorageResourceProvider().FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
            Assert.IsInstanceOf(typeof(BlobStorageResourceContainer), storageResource);
        }
    }
}
