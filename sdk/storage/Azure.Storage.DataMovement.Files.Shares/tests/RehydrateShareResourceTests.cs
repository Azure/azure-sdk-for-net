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

        private static byte[] GetBytes(StorageResourceCheckpointDataInternal checkpointData)
        {
            using MemoryStream stream = new();
            checkpointData.SerializeInternal(stream);
            return stream.ToArray();
        }

        private static Mock<DataTransferProperties> GetProperties(
            string transferId,
            string sourcePath,
            string destinationPath,
            string sourceProviderId,
            string destinationProviderId,
            bool isContainer,
            ShareFileSourceCheckpointData sourceCheckpointData,
            ShareFileDestinationCheckpointData destinationCheckpointData)
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
        public async Task RehydrateFile(
            [Values(true, false)] bool isSource)
        {
            string transferId = Guid.NewGuid().ToString();
            string sourcePath = "https://storageaccount.file.core.windows.net/share/dir1/file1";
            string destinationPath = "https://storageaccount.file.core.windows.net/share/dir2/file2";
            string originalPath = isSource ? sourcePath : destinationPath;

            DataTransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ShareProviderId,
                ShareProviderId,
                isContainer: false,
                new ShareFileSourceCheckpointData(),
                new ShareFileDestinationCheckpointData(null, null, null, null, null, null, null, null, null, null, null, null)).Object;

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
            ShareFileDestinationCheckpointData originalDestinationData = new(
                contentType: new("text/plain"),
                contentEncoding: new(new string[] { "gzip" }),
                contentLanguage: new(new string[] { "en-US" }),
                contentDisposition: new("inline"),
                cacheControl: new("no-cache"),
                fileAttributes: new(NtfsFileAttributes.Archive),
                preserveFilePermission: true,
                fileLastWrittenOn: new(DateTimeOffset.Now),
                fileChangedOn: new(DateTimeOffset.Now),
                fileCreatedOn: new(DateTimeOffset.Now),
                fileMetadata: new(new Dictionary<string, string>
                {
                    {  r.NextString(8),  r.NextString(8) }
                }),
                directoryMetadata: new(new Dictionary<string, string>
                {
                    {  r.NextString(8),  r.NextString(8) }
                }));
            DataTransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ShareProviderId,
                ShareProviderId,
                isContainer: false,
                new ShareFileSourceCheckpointData(),
                originalDestinationData).Object;

            ShareFileStorageResource storageResource = (ShareFileStorageResource)
                await new ShareFilesStorageResourceProvider().FromDestinationInternalHookAsync(transferProperties);

            Assert.That(destinationPath, Is.EqualTo(storageResource.Uri.AbsoluteUri));
            Assert.That(storageResource, Is.TypeOf<ShareFileStorageResource>());
            Assert.That(storageResource._options.ContentType.Preserve, Is.EqualTo(originalDestinationData.ContentType.Preserve));
            Assert.That(storageResource._options.ContentType.Value, Is.EqualTo(originalDestinationData.ContentType.Value));
            Assert.That(storageResource._options.ContentEncoding.Preserve, Is.EqualTo(originalDestinationData.ContentEncoding.Preserve));
            Assert.That(storageResource._options.ContentEncoding.Value, Is.EqualTo(originalDestinationData.ContentEncoding.Value));
            Assert.That(storageResource._options.ContentLanguage.Preserve, Is.EqualTo(originalDestinationData.ContentLanguage.Preserve));
            Assert.That(storageResource._options.ContentLanguage.Value, Is.EqualTo(originalDestinationData.ContentLanguage.Value));
            Assert.That(storageResource._options.ContentDisposition.Preserve, Is.EqualTo(originalDestinationData.ContentDisposition.Preserve));
            Assert.That(storageResource._options.ContentDisposition.Value, Is.EqualTo(originalDestinationData.ContentDisposition.Value));
            Assert.That(storageResource._options.CacheControl.Preserve, Is.EqualTo(originalDestinationData.CacheControl.Preserve));
            Assert.That(storageResource._options.CacheControl.Value, Is.EqualTo(originalDestinationData.CacheControl.Value));
            Assert.That(storageResource._options.FileMetadata.Preserve, Is.EqualTo(originalDestinationData.FileMetadata.Preserve));
            Assert.That(storageResource._options.FileMetadata.Value, Is.EqualTo(originalDestinationData.FileMetadata.Value));
            Assert.That(storageResource._options.DirectoryMetadata.Preserve, Is.EqualTo(originalDestinationData.DirectoryMetadata.Preserve));
            Assert.That(storageResource._options.DirectoryMetadata.Value, Is.EqualTo(originalDestinationData.DirectoryMetadata.Value));
            Assert.That(storageResource._options.FileAttributes.Preserve, Is.EqualTo(originalDestinationData.FileAttributes.Preserve));
            Assert.That(storageResource._options.FileAttributes.Value, Is.EqualTo(originalDestinationData.FileAttributes.Value));
            Assert.IsTrue(storageResource._options.FilePermissions.Preserve);
            Assert.That(storageResource._options.FileCreatedOn.Preserve, Is.EqualTo(originalDestinationData.FileCreatedOn.Preserve));
            Assert.That(storageResource._options.FileCreatedOn.Value, Is.EqualTo(originalDestinationData.FileCreatedOn.Value));
            Assert.That(storageResource._options.FileLastWrittenOn.Preserve, Is.EqualTo(originalDestinationData.FileLastWrittenOn.Preserve));
            Assert.That(storageResource._options.FileLastWrittenOn.Value, Is.EqualTo(originalDestinationData.FileLastWrittenOn.Value));
            Assert.That(storageResource._options.FileChangedOn.Preserve, Is.EqualTo(originalDestinationData.FileChangedOn.Preserve));
            Assert.That(storageResource._options.FileChangedOn.Value, Is.EqualTo(originalDestinationData.FileChangedOn.Value));
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

            DataTransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                ShareProviderId,
                ShareProviderId,
                isContainer: true,
                new ShareFileSourceCheckpointData(),
                new ShareFileDestinationCheckpointData(null, null, null, null, null, null, null, null, null, null, null, null)).Object;

            StorageResource storageResource = isSource
                ? await new ShareFilesStorageResourceProvider().FromSourceInternalHookAsync(transferProperties)
                : await new ShareFilesStorageResourceProvider().FromDestinationInternalHookAsync(transferProperties);

            Assert.That(originalPath, Is.EqualTo(storageResource.Uri.AbsoluteUri));
            Assert.That(storageResource, Is.TypeOf<ShareDirectoryStorageResourceContainer>());
        }
    }
}
