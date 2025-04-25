// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Tests;
using Moq;
using NUnit.Framework;
using static Azure.Storage.DataMovement.Tests.TransferUtility;

namespace Azure.Storage.DataMovement.Tests
{
    public class RehydrateStorageResourceTests
    {
        public RehydrateStorageResourceTests()
        { }

        private enum StorageResourceType
        {
            BlockBlob,
            Local
        }

        private static Mock<TransferProperties> GetProperties(
            string transferId,
            string sourcePath,
            string destinationPath,
            bool isContainer)
        {
            UriBuilder sourceBuilder = new UriBuilder()
            {
                Scheme = Uri.UriSchemeFile,
                Host = "",
                Path = sourcePath,
            };
            UriBuilder destinationBuilder = new UriBuilder()
            {
                Scheme = Uri.UriSchemeFile,
                Host = "",
                Path = destinationPath,
            };

            var mock = new Mock<TransferProperties>(MockBehavior.Strict);
            mock.Setup(p => p.TransferId).Returns(transferId);
            mock.Setup(p => p.SourceUri).Returns(sourceBuilder.Uri);
            mock.Setup(p => p.DestinationUri).Returns(destinationBuilder.Uri);
            mock.Setup(p => p.SourceProviderId).Returns("local");
            mock.Setup(p => p.DestinationProviderId).Returns("local");
            mock.Setup(p => p.IsContainer).Returns(isContainer);
            return mock;
        }

        [Test]
        public async Task RehydrateLocalFile(
            [Values(true, false)] bool isSource)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            Random random = new();
            string transferId = GetNewTransferId();
            string sourcePath = string.Concat("/", random.NextString(20));
            string destinationPath = string.Concat("/", random.NextString(15));
            string originalPath = isSource ? sourcePath : destinationPath;

            StorageResourceType sourceType = !isSource ? StorageResourceType.BlockBlob : StorageResourceType.Local;
            StorageResourceType destinationType = isSource ? StorageResourceType.BlockBlob : StorageResourceType.Local;

            TransferProperties transferProperties = GetProperties(
                transferId,
                sourcePath,
                destinationPath,
                isContainer: false).Object;

            StorageResource storageResource = isSource
                    ? await new LocalFilesStorageResourceProvider().FromSourceAsync(transferProperties, CancellationToken.None)
                    : await new LocalFilesStorageResourceProvider().FromDestinationAsync(transferProperties, CancellationToken.None);

            Assert.AreEqual(originalPath, storageResource.Uri.LocalPath);
            Assert.IsInstanceOf(typeof(LocalFileStorageResource), storageResource);
        }

        [Test]
        public async Task RehydrateLocalDirectory(
            [Values(true, false)] bool isSource)
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            Random random = new();
            string transferId = GetNewTransferId();
            string sourceParentPath = string.Concat("/", random.NextString(20));
            List<string> sourcePaths = new List<string>();
            string destinationParentPath = string.Concat("/", random.NextString(15));
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

            TransferProperties transferProperties = GetProperties(
                transferId,
                sourceParentPath,
                destinationParentPath,
                isContainer: true).Object;

            StorageResource storageResource = isSource
                    ? await new LocalFilesStorageResourceProvider().FromSourceAsync(transferProperties, CancellationToken.None)
                    : await new LocalFilesStorageResourceProvider().FromDestinationAsync(transferProperties, CancellationToken.None);

            Assert.AreEqual(originalPath, storageResource.Uri.LocalPath);
            Assert.IsInstanceOf(typeof(LocalDirectoryStorageResourceContainer), storageResource);
        }
    }
}
