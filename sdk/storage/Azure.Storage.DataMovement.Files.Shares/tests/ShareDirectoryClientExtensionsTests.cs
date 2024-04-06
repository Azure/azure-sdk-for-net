// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [NonParallelizable]
    public class ShareDirectoryClientExtensionsTests
    {
        private Mock<TransferManager> ExtensionMockTransferManager { get; set; }

        // temporarily stores the static value that was in the extensions class
        private Lazy<TransferManager> _backupTransferManagerValue;

        [SetUp]
        public void Setup()
        {
            ExtensionMockTransferManager = new();
            ExtensionMockTransferManager.Setup(tm => tm.StartTransferAsync(
                It.IsAny<StorageResource>(),
                It.IsAny<StorageResource>(),
                It.IsAny<DataTransferOptions>(),
                It.IsAny<CancellationToken>()));

            _backupTransferManagerValue = (Lazy<TransferManager>)typeof(ShareDirectoryClientExtensions)
                .GetField("s_defaultTransferManager", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
            typeof(ShareDirectoryClientExtensions)
                .GetField("s_defaultTransferManager", BindingFlags.NonPublic | BindingFlags.Static)
                .SetValue(null, new Lazy<TransferManager>(() => ExtensionMockTransferManager.Object));
        }

        [TearDown]
        public void Teardown()
        {
            typeof(ShareDirectoryClientExtensions)
                .GetField("s_defaultTransferManager", BindingFlags.NonPublic | BindingFlags.Static)
                .SetValue(null, _backupTransferManagerValue);
        }

        [Test]
        public async Task StartUploadDirectory([Values(true, false)] bool useOptions)
        {
            ShareFileStorageResourceOptions storageResourceOptions = new();
            DataTransferOptions dataTransferOptions = new();
            ShareDirectoryClientTransferOptions transferOptions = new()
            {
                ShareDirectoryOptions = storageResourceOptions,
                TransferOptions = dataTransferOptions,
            };
            string localPath = Path.GetTempPath();
            Mock<ShareDirectoryClient> clientMock = new();

            await clientMock.Object.StartUploadDirectoryAsync(localPath, useOptions ? transferOptions : null);

            ExtensionMockTransferManager.Verify(tm => tm.StartTransferAsync(
                It.IsAny<StorageResource>(),
                It.Is<StorageResource>(res => res is ShareDirectoryStorageResourceContainer &&
                    (res as ShareDirectoryStorageResourceContainer).ShareDirectoryClient == clientMock.Object &&
                    (res as ShareDirectoryStorageResourceContainer).ResourceOptions == (useOptions ? storageResourceOptions : null)),
                useOptions ? dataTransferOptions : null,
                default), Times.Once);
            ExtensionMockTransferManager.VerifyNoOtherCalls();
        }

        [Test]
        public async Task StartDownloadDirectory([Values(true, false)] bool useOptions)
        {
            ShareFileStorageResourceOptions storageResourceOptions = new();
            DataTransferOptions dataTransferOptions = new();
            ShareDirectoryClientTransferOptions transferOptions = new()
            {
                ShareDirectoryOptions = storageResourceOptions,
                TransferOptions = dataTransferOptions,
            };
            string localPath = Path.GetTempPath();
            Mock<ShareDirectoryClient> clientMock = new();

            await clientMock.Object.StartDownloadToDirectoryAsync(localPath, useOptions ? transferOptions : null);

            ExtensionMockTransferManager.Verify(tm => tm.StartTransferAsync(
                It.Is<StorageResource>(res => res is ShareDirectoryStorageResourceContainer &&
                    (res as ShareDirectoryStorageResourceContainer).ShareDirectoryClient == clientMock.Object &&
                    (res as ShareDirectoryStorageResourceContainer).ResourceOptions == (useOptions ? storageResourceOptions : null)),
                It.IsAny<StorageResource>(),
                useOptions ? dataTransferOptions : null,
                default), Times.Once);
            ExtensionMockTransferManager.VerifyNoOtherCalls();
        }
    }
}
