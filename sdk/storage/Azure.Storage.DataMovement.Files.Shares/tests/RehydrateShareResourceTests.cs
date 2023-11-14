// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
