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
using Azure.Core;
using Azure.Identity;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class RehydrateBlobResourceTests
    {
        private const string DefaultContentType = "text/plain";
        private const string DefaultContentEncoding = "gzip";
        private const string DefaultContentLanguage = "en-US";
        private const string DefaultContentDisposition = "inline";
        private const string DefaultCacheControl = "no-cache";
        private static string GetNewTransferId() => Guid.NewGuid().ToString();
        private static TokenCredential _tokenCredential = new DefaultAzureCredential();

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
                isBlobTypeSet: true,
                blobType: blobType,
                isContentTypeSet: true,
                contentType: DefaultContentType,
                isContentEncodingSet: true,
                contentEncoding: DefaultContentEncoding,
                isContentLanguageSet: true,
                contentLanguage: DefaultContentLanguage,
                isContentDispositionSet: true,
                contentDisposition: DefaultContentDisposition,
                isCacheControlSet: true,
                cacheControl: DefaultCacheControl,
                isAccessTierSet: true,
                accessTier: accessTier,
                isMetadataSet: true,
                metadata: DataProvider.BuildMetadata(),
                preserveTags: true,
                tags: DataProvider.BuildTags());

        private static BlobDestinationCheckpointDetails GetDefaultDestinationCheckpointDetails(BlobType blobType)
        => new BlobDestinationCheckpointDetails(
            true,
            blobType,
            false,
            default,
            false,
            default,
            false,
            default,
            false,
            default,
            false,
            default,
            false,
            default,
            false,
            default,
            false,
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
                ? await new BlobsStorageResourceProvider(_tokenCredential).FromSourceInternalHookAsync(transferProperties)
                : await new BlobsStorageResourceProvider(_tokenCredential).FromDestinationInternalHookAsync(transferProperties);

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

            BlockBlobStorageResource storageResource = (BlockBlobStorageResource)await new BlobsStorageResourceProvider(_tokenCredential)
                    .FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(destinationPath, storageResource.Uri.AbsoluteUri);
            Assert.AreEqual(checkpointDetails.IsAccessTierSet, storageResource._options._isAccessTierSet);
            Assert.AreEqual(checkpointDetails.AccessTierValue.Value, storageResource._options.AccessTier.Value);
            Assert.AreEqual(checkpointDetails.IsMetadataSet, storageResource._options._isMetadataSet);
            Assert.AreEqual(checkpointDetails.Metadata, storageResource._options.Metadata);
            Assert.AreEqual(checkpointDetails.IsCacheControlSet, storageResource._options._isCacheControlSet);
            Assert.AreEqual(checkpointDetails.CacheControl, storageResource._options.CacheControl);
            Assert.AreEqual(checkpointDetails.IsContentDispositionSet, storageResource._options._isContentDispositionSet);
            Assert.AreEqual(checkpointDetails.ContentDisposition, storageResource._options.ContentDisposition);
            Assert.AreEqual(checkpointDetails.IsContentEncodingSet, storageResource._options._isContentEncodingSet);
            Assert.AreEqual(checkpointDetails.ContentEncoding, storageResource._options.ContentEncoding);
            Assert.AreEqual(checkpointDetails.IsContentLanguageSet, storageResource._options._isContentLanguageSet);
            Assert.AreEqual(checkpointDetails.ContentLanguage, storageResource._options.ContentLanguage);
            Assert.AreEqual(checkpointDetails.IsContentTypeSet, storageResource._options._isContentTypeSet);
            Assert.AreEqual(checkpointDetails.ContentType, storageResource._options.ContentType);
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
                    ? await new BlobsStorageResourceProvider(_tokenCredential).FromSourceInternalHookAsync(transferProperties)
                    : await new BlobsStorageResourceProvider(_tokenCredential).FromDestinationInternalHookAsync(transferProperties);

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

            PageBlobStorageResource storageResource = (PageBlobStorageResource)await new BlobsStorageResourceProvider(_tokenCredential)
                    .FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(destinationPath, storageResource.Uri.AbsoluteUri);
            Assert.AreEqual(checkpointDetails.IsMetadataSet, storageResource._options._isMetadataSet);
            Assert.AreEqual(checkpointDetails.Metadata, storageResource._options.Metadata);
            Assert.AreEqual(checkpointDetails.IsAccessTierSet, storageResource._options._isAccessTierSet);
            Assert.AreEqual(checkpointDetails.AccessTierValue.Value, storageResource._options.AccessTier.Value);
            Assert.AreEqual(checkpointDetails.IsCacheControlSet, storageResource._options._isCacheControlSet);
            Assert.AreEqual(checkpointDetails.CacheControl, storageResource._options.CacheControl);
            Assert.AreEqual(checkpointDetails.IsContentDispositionSet, storageResource._options._isContentDispositionSet);
            Assert.AreEqual(checkpointDetails.ContentDisposition, storageResource._options.ContentDisposition);
            Assert.AreEqual(checkpointDetails.IsContentEncodingSet, storageResource._options._isContentEncodingSet);
            Assert.AreEqual(checkpointDetails.ContentEncoding, storageResource._options.ContentEncoding);
            Assert.AreEqual(checkpointDetails.IsContentLanguageSet, storageResource._options._isContentLanguageSet);
            Assert.AreEqual(checkpointDetails.ContentLanguage, storageResource._options.ContentLanguage);
            Assert.AreEqual(checkpointDetails.IsContentTypeSet, storageResource._options._isContentTypeSet);
            Assert.AreEqual(checkpointDetails.ContentType, storageResource._options.ContentType);
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
                    ? await new BlobsStorageResourceProvider(_tokenCredential).FromSourceInternalHookAsync(transferProperties)
                    : await new BlobsStorageResourceProvider(_tokenCredential).FromDestinationInternalHookAsync(transferProperties);

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

            AppendBlobStorageResource storageResource = (AppendBlobStorageResource)await new BlobsStorageResourceProvider(_tokenCredential)
                .FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(destinationPath, storageResource.Uri.AbsoluteUri);
            Assert.AreEqual(checkpointDetails.IsMetadataSet, storageResource._options._isMetadataSet);
            Assert.AreEqual(checkpointDetails.Metadata, storageResource._options.Metadata);
            Assert.AreEqual(checkpointDetails.IsCacheControlSet, storageResource._options._isCacheControlSet);
            Assert.AreEqual(checkpointDetails.CacheControl, storageResource._options.CacheControl);
            Assert.AreEqual(checkpointDetails.IsContentDispositionSet, storageResource._options._isContentDispositionSet);
            Assert.AreEqual(checkpointDetails.ContentDisposition, storageResource._options.ContentDisposition);
            Assert.AreEqual(checkpointDetails.IsContentEncodingSet, storageResource._options._isContentEncodingSet);
            Assert.AreEqual(checkpointDetails.ContentEncoding, storageResource._options.ContentEncoding);
            Assert.AreEqual(checkpointDetails.IsContentLanguageSet, storageResource._options._isContentLanguageSet);
            Assert.AreEqual(checkpointDetails.ContentLanguage, storageResource._options.ContentLanguage);
            Assert.AreEqual(checkpointDetails.IsContentTypeSet, storageResource._options._isContentTypeSet);
            Assert.AreEqual(checkpointDetails.ContentType, storageResource._options.ContentType);
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
                    ? await new BlobsStorageResourceProvider(_tokenCredential).FromSourceInternalHookAsync(transferProperties)
                    : await new BlobsStorageResourceProvider(_tokenCredential).FromDestinationInternalHookAsync(transferProperties);

            Assert.AreEqual(originalPath, storageResource.Uri.AbsoluteUri);
            Assert.IsInstanceOf(typeof(BlobStorageResourceContainer), storageResource);
        }
    }
}
