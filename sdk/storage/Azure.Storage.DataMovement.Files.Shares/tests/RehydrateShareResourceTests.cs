// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares.Models;
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
                new ShareFileDestinationCheckpointData(null, null, null, null)).Object;

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
                new ShareFileHttpHeaders
                {
                    ContentType = "text/plain",
                    ContentEncoding = new string[] { "gzip" },
                    ContentLanguage = new string[] { "en-US" },
                    ContentDisposition = "inline",
                    CacheControl = "no-cache",
                },
                new Dictionary<string, string>
                {
                    {  r.NextString(8),  r.NextString(8) }
                },
                new Dictionary<string, string>
                {
                    {  r.NextString(8),  r.NextString(8) }
                },
                new FileSmbProperties
                {
                    FileAttributes = NtfsFileAttributes.Archive,
                    FilePermissionKey = r.NextString(8),
                    FileLastWrittenOn = DateTimeOffset.Now,
                    FileChangedOn = DateTimeOffset.Now,
                    FileCreatedOn = DateTimeOffset.Now,
                });
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
            Assert.That(storageResource._options.HttpHeaders.ContentType, Is.EqualTo(originalDestinationData.ContentHeaders.ContentType));
            Assert.That(storageResource._options.HttpHeaders.ContentEncoding, Is.EqualTo(originalDestinationData.ContentHeaders.ContentEncoding));
            Assert.That(storageResource._options.HttpHeaders.ContentLanguage, Is.EqualTo(originalDestinationData.ContentHeaders.ContentLanguage));
            Assert.That(storageResource._options.HttpHeaders.ContentDisposition, Is.EqualTo(originalDestinationData.ContentHeaders.ContentDisposition));
            Assert.That(storageResource._options.HttpHeaders.CacheControl, Is.EqualTo(originalDestinationData.ContentHeaders.CacheControl));
            Assert.That(storageResource._options.FileMetadata, Is.EqualTo(originalDestinationData.FileMetadata));
            Assert.That(storageResource._options.DirectoryMetadata, Is.EqualTo(originalDestinationData.DirectoryMetadata));
            Assert.That(storageResource._options.SmbProperties.FileAttributes, Is.EqualTo(originalDestinationData.SmbProperties.FileAttributes));
            Assert.That(storageResource._options.SmbProperties.FilePermissionKey, Is.EqualTo(originalDestinationData.SmbProperties.FilePermissionKey));
            Assert.That(storageResource._options.SmbProperties.FileCreatedOn, Is.EqualTo(originalDestinationData.SmbProperties.FileCreatedOn));
            Assert.That(storageResource._options.SmbProperties.FileLastWrittenOn, Is.EqualTo(originalDestinationData.SmbProperties.FileLastWrittenOn));
            Assert.That(storageResource._options.SmbProperties.FileChangedOn, Is.EqualTo(originalDestinationData.SmbProperties.FileChangedOn));
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
                new ShareFileDestinationCheckpointData(null, null, null, null)).Object;

            StorageResource storageResource = isSource
                ? await new ShareFilesStorageResourceProvider().FromSourceInternalHookAsync(transferProperties)
                : await new ShareFilesStorageResourceProvider().FromDestinationInternalHookAsync(transferProperties);

            Assert.That(originalPath, Is.EqualTo(storageResource.Uri.AbsoluteUri));
            Assert.That(storageResource, Is.TypeOf<ShareDirectoryStorageResourceContainer>());
        }
    }
}
