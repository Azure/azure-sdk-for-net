// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseShares;
extern alias DMShare;

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using BaseShares::Azure.Storage.Files.Shares;
using DMShare::Azure.Storage.Files.Shares;
using Moq;
using NUnit.Framework;
using DMShare::Azure.Storage.DataMovement.Files.Shares;

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
                It.IsAny<TransferOptions>(),
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
            TransferOptions transferOptions = new();
            ShareDirectoryClientTransferOptions clientTransferOptions = new()
            {
                ShareDirectoryOptions = storageResourceOptions,
                TransferOptions = transferOptions,
            };
            string localPath = Path.GetTempPath();
            Mock<ShareDirectoryClient> clientMock = new();

            await ShareDirectoryClientExtensions.UploadDirectoryAsync(
                clientMock.Object,
                WaitUntil.Started,
                localPath,
                useOptions ? clientTransferOptions : null);

            ExtensionMockTransferManager.Verify(tm => tm.StartTransferAsync(
                It.IsAny<StorageResource>(),
                It.Is<StorageResource>(res => res is ShareDirectoryStorageResourceContainer &&
                    (res as ShareDirectoryStorageResourceContainer).ShareDirectoryClient == clientMock.Object &&
                    (
                        useOptions
                            ? (res as ShareDirectoryStorageResourceContainer).ResourceOptions == storageResourceOptions
                            : (res as ShareDirectoryStorageResourceContainer).ResourceOptions != null
                    )
                ),
                useOptions ? transferOptions : null,
                default), Times.Once);
            ExtensionMockTransferManager.VerifyNoOtherCalls();
        }

        [Test]
        public async Task StartDownloadDirectory([Values(true, false)] bool useOptions)
        {
            ShareFileStorageResourceOptions storageResourceOptions = new();
            TransferOptions transferOptions = new();
            ShareDirectoryClientTransferOptions clientTransferOptions = new()
            {
                ShareDirectoryOptions = storageResourceOptions,
                TransferOptions = transferOptions,
            };
            string localPath = Path.GetTempPath();
            Mock<ShareDirectoryClient> clientMock = new();

            await ShareDirectoryClientExtensions.DownloadToDirectoryAsync(
                clientMock.Object,
                WaitUntil.Started,
                localPath,
                useOptions ? clientTransferOptions : null);

            ExtensionMockTransferManager.Verify(tm => tm.StartTransferAsync(
                It.Is<StorageResource>(res => res is ShareDirectoryStorageResourceContainer &&
                    (res as ShareDirectoryStorageResourceContainer).ShareDirectoryClient == clientMock.Object &&
                    (
                        useOptions
                            ? (res as ShareDirectoryStorageResourceContainer).ResourceOptions == storageResourceOptions
                            : (res as ShareDirectoryStorageResourceContainer).ResourceOptions != null
                    )
                ),
                It.IsAny<StorageResource>(),
                useOptions ? transferOptions : null,
                default), Times.Once);
            ExtensionMockTransferManager.VerifyNoOtherCalls();
        }
    }
}
