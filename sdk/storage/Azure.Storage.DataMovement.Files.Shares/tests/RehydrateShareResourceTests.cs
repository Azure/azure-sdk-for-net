// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseShares;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BaseShares::Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using Azure.Storage.Tests;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    public class RehydrateShareResourceTests
    {
        public const string ShareProviderId = "share";

        private static byte[] GetBytes(StorageResourceCheckpointDetailsInternal checkpointDetails)
        {
            using MemoryStream stream = new();
            checkpointDetails.SerializeInternal(stream);
            return stream.ToArray();
        }

        private static Mock<TransferProperties> GetProperties(
            string transferId,
            string sourcePath,
            string destinationPath,
            string sourceProviderId,
            string destinationProviderId,
            bool isContainer,
            ShareFileSourceCheckpointDetails sourceCheckpointDetails,
            ShareFileDestinationCheckpointDetails destinationCheckpointDetails)
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
        public async Task RehydrateFile(
            [Values(true, false)] bool isSource)
        {
            string transferId = Guid.NewGuid().ToString();
            string sourcePath = "https://storageaccount.file.core.windows.net/share/dir1/file1";
            string destinationPath = "https://storageaccount.file.core.windows.net/share/dir2/file2";
            string originalPath = isSource ? sourcePath : destinationPath;

            TransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ShareProviderId,
                ShareProviderId,
                isContainer: false,
                new ShareFileSourceCheckpointDetails(),
                new ShareFileDestinationCheckpointDetails(false, null, false, null, false, null, false, null, false, null, false, null, false, false, null, false, null, false, null, false,  null, false, null)).Object;

            StorageResource storageResource = isSource
                ? await new ShareFilesStorageResourceProvider().FromSourceInternalHookAsync(transferProperties)
                : await new ShareFilesStorageResourceProvider().FromDestinationInternalHookAsync(transferProperties);

            Assert.That(originalPath, Is.EqualTo(storageResource.Uri.AbsoluteUri));
            Assert.That(storageResource, Is.TypeOf<ShareFileStorageResource>());
        }

        [Test]
        public async Task RehydrateFile_DestinationOptions()
        {
            string transferId = Guid.NewGuid().ToString();
            string sourcePath = "https://storageaccount.file.core.windows.net/share/dir1/file1";
            string destinationPath = "https://storageaccount.file.core.windows.net/share/dir2/file2";

            Random r = new();
            ShareFileDestinationCheckpointDetails originalDestinationData = new(
                isContentTypeSet: true,
                contentType: "text/plain",
                isContentEncodingSet: true,
                contentEncoding: new string[] { "gzip" },
                isContentLanguageSet: true,
                contentLanguage: new string[] { "en-US" },
                isContentDispositionSet: true,
                contentDisposition: "inline",
                isCacheControlSet: true,
                cacheControl: "no-cache",
                isFileAttributesSet: true,
                fileAttributes: NtfsFileAttributes.Archive,
                filePermissions: true,
                isFileLastWrittenOnSet: true,
                fileLastWrittenOn: DateTimeOffset.Now,
                isFileChangedOnSet: true,
                fileChangedOn: DateTimeOffset.Now,
                isFileCreatedOnSet: true,
                fileCreatedOn: DateTimeOffset.Now,
                isFileMetadataSet: true,
                fileMetadata: new Dictionary<string, string>
                {
                    {  r.NextString(8),  r.NextString(8) }
                },
                isDirectoryMetadataSet: true,
                directoryMetadata: new Dictionary<string, string>
                {
                    {  r.NextString(8),  r.NextString(8) }
                });
            TransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ShareProviderId,
                ShareProviderId,
                isContainer: false,
                new ShareFileSourceCheckpointDetails(),
                originalDestinationData).Object;

            ShareFileStorageResource storageResource = (ShareFileStorageResource)
                await new ShareFilesStorageResourceProvider().FromDestinationInternalHookAsync(transferProperties);

            Assert.That(destinationPath, Is.EqualTo(storageResource.Uri.AbsoluteUri));
            Assert.That(storageResource, Is.TypeOf<ShareFileStorageResource>());
            Assert.That(storageResource._options._isContentTypeSet, Is.EqualTo(originalDestinationData.IsContentTypeSet));
            Assert.That(storageResource._options.ContentType, Is.EqualTo(originalDestinationData.ContentType));
            Assert.That(storageResource._options._isContentEncodingSet, Is.EqualTo(originalDestinationData.IsContentEncodingSet));
            Assert.That(storageResource._options.ContentEncoding, Is.EqualTo(originalDestinationData.ContentEncoding));
            Assert.That(storageResource._options._isContentLanguageSet, Is.EqualTo(originalDestinationData.IsContentLanguageSet));
            Assert.That(storageResource._options.ContentLanguage, Is.EqualTo(originalDestinationData.ContentLanguage));
            Assert.That(storageResource._options._isContentDispositionSet, Is.EqualTo(originalDestinationData.IsContentDispositionSet));
            Assert.That(storageResource._options.ContentDisposition, Is.EqualTo(originalDestinationData.ContentDisposition));
            Assert.That(storageResource._options._isCacheControlSet, Is.EqualTo(originalDestinationData.IsCacheControlSet));
            Assert.That(storageResource._options.CacheControl, Is.EqualTo(originalDestinationData.CacheControl));
            Assert.That(storageResource._options._isFileMetadataSet, Is.EqualTo(originalDestinationData.IsFileMetadataSet));
            Assert.That(storageResource._options.FileMetadata, Is.EqualTo(originalDestinationData.FileMetadata));
            Assert.That(storageResource._options._isDirectoryMetadataSet, Is.EqualTo(originalDestinationData.IsDirectoryMetadataSet));
            Assert.That(storageResource._options.DirectoryMetadata, Is.EqualTo(originalDestinationData.DirectoryMetadata));
            Assert.That(storageResource._options._isFileAttributesSet, Is.EqualTo(originalDestinationData.IsFileAttributesSet));
            Assert.That(storageResource._options.FileAttributes, Is.EqualTo(originalDestinationData.FileAttributes));
            Assert.IsTrue(storageResource._options.FilePermissions);
            Assert.That(storageResource._options._isFileCreatedOnSet, Is.EqualTo(originalDestinationData.IsFileCreatedOnSet));
            Assert.That(storageResource._options.FileCreatedOn, Is.EqualTo(originalDestinationData.FileCreatedOn));
            Assert.That(storageResource._options._isFileLastWrittenOnSet, Is.EqualTo(originalDestinationData.IsFileLastWrittenOnSet));
            Assert.That(storageResource._options.FileLastWrittenOn, Is.EqualTo(originalDestinationData.FileLastWrittenOn));
            Assert.That(storageResource._options._isFileChangedOnSet, Is.EqualTo(originalDestinationData.IsFileChangedOnSet));
            Assert.That(storageResource._options.FileChangedOn, Is.EqualTo(originalDestinationData.FileChangedOn));
        }

        [Test]
        public async Task RehydrateDirectory(
            [Values(true, false)] bool isSource)
        {
            string transferId = Guid.NewGuid().ToString();
            List<string> sourcePaths = new List<string>();
            string sourcePath = "https://storageaccount.file.core.windows.net/share/dir1";
            List<string> destinationPaths = new List<string>();
            string destinationPath = "https://storageaccount.file.core.windows.net/share/dir2";
            string originalPath = isSource ? sourcePath : destinationPath;
            int jobPartCount = 10;
            for (int i = 0; i < jobPartCount; i++)
            {
                string childPath = DataProvider.GetNewString(5);
                sourcePaths.Add(string.Join("/", sourcePath, childPath));
                destinationPaths.Add(string.Join("/", destinationPath, childPath));
            }

            TransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ShareProviderId,
                ShareProviderId,
                isContainer: true,
                new ShareFileSourceCheckpointDetails(),
                new ShareFileDestinationCheckpointDetails(false, null, false, null, false, null, false, null, false, null, false, null, false, false, null, false, null, false, null, false, null, false, null)).Object;

            StorageResource storageResource = isSource
                ? await new ShareFilesStorageResourceProvider().FromSourceInternalHookAsync(transferProperties)
                : await new ShareFilesStorageResourceProvider().FromDestinationInternalHookAsync(transferProperties);

            Assert.That(originalPath, Is.EqualTo(storageResource.Uri.AbsoluteUri));
            Assert.That(storageResource, Is.TypeOf<ShareDirectoryStorageResourceContainer>());
        }
    }
}
