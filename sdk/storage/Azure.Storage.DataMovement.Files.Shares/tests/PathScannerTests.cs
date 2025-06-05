// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseShares;
extern alias DMShare;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BaseShares::Azure.Storage.Files.Shares;
using BaseShares::Azure.Storage.Files.Shares.Models;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using DMShare::Azure.Storage.DataMovement.Files.Shares;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    internal class PathScannerTests
    {
        [TestCase("")]
        [TestCase("somedir")]
        public async Task PathScannerFindsAllRecursive(string baseDirName)
        {
            const string shareName = "myshare";
            List<(string Path, bool IsDirectory)> paths = new()
            {
                (Path: "foo/file1-1", IsDirectory: false),
                (Path: "foo/file1-2", IsDirectory: false),
                (Path: "bar/fizz/file2-1", IsDirectory: false),
                (Path: "bar/buzz/emptydir", IsDirectory: true),
            };
            List<string> expectedFilePaths = new List<string>()
            {
                baseDirName + "/" + "foo/file1-1",
                baseDirName + "/" + "foo/file1-2",
                baseDirName + "/" + "bar/fizz/file2-1",
            }.Select(s => s.Trim('/')).ToList();
            List<string> expectedDirectoryPaths = new List<string>()
            {
                baseDirName + "/" + "foo",
                baseDirName + "/" + "bar",
                baseDirName + "/" + "bar/fizz",
                baseDirName + "/" + "bar/buzz",
                baseDirName + "/" + "bar/buzz/emptydir",
            }.Select(s => s.Trim('/')).ToList();

            Uri dirUri = new UriBuilder()
            {
                Scheme = "https",
                Host = "myaccount.file.core.windows.net",
                Path = (shareName + "/" + baseDirName).Trim('/')
            }.Uri;
            Mock<ShareDirectoryClient> sourceDirectory = new Mock<ShareDirectoryClient>()
                .WithUri(dirUri)
                .WithDirectoryStructure(paths.AsTree());
            Mock<ShareClient> destinationShare = new Mock<ShareClient>();

            List<ShareFileStorageResource> files = new();
            List<ShareDirectoryStorageResourceContainer> directories = new();
            await foreach (StorageResource storageResource
                in new SharesPathScanner().ScanAsync(
                    sourceDirectory: sourceDirectory.Object,
                    destinationShare: destinationShare.Object,
                    sourceOptions: default,
                    traits: default,
                    cancellationToken: default))
            {
                if (storageResource is ShareFileStorageResource)
                    files.Add((ShareFileStorageResource)storageResource);
                else if (storageResource is ShareDirectoryStorageResourceContainer)
                    directories.Add((ShareDirectoryStorageResourceContainer)storageResource);
            }

            Assert.That(files.Select(f => f.Uri.PathAndQuery.Substring(shareName.Length + 2)), Is.EquivalentTo(expectedFilePaths));
            Assert.That(directories.Select(f => f.Uri.PathAndQuery.Substring(shareName.Length + 2)), Is.EquivalentTo(expectedDirectoryPaths));
        }

        [Test]
        public async Task PathScannerFindsAllRecursive_Traits()
        {
            string baseDirName = "somedir";
            const string shareName = "myshare";
            string sourcePermissionKey = "myPermissionKey";
            string sourcePermission = "rwl----jwrir09r0i3kjmke;lfds'/fakelongpermission";
            string destinationPermissionKey = "destinationPermissionKey";
            List<(string Path, bool IsDirectory)> paths = new()
            {
                (Path: "foo/file1-1", IsDirectory: false),
                (Path: "foo/file1-2", IsDirectory: false),
                (Path: "bar/fizz/file2-1", IsDirectory: false),
                (Path: "bar/buzz/emptydir", IsDirectory: true),
            };
            List<string> expectedFilePaths = new List<string>()
            {
                baseDirName + "/" + "foo/file1-1",
                baseDirName + "/" + "foo/file1-2",
                baseDirName + "/" + "bar/fizz/file2-1",
            }.Select(s => s.Trim('/')).ToList();
            List<string> expectedDirectoryPaths = new List<string>()
            {
                baseDirName + "/" + "foo",
                baseDirName + "/" + "bar",
                baseDirName + "/" + "bar/fizz",
                baseDirName + "/" + "bar/buzz",
                baseDirName + "/" + "bar/buzz/emptydir",
            }.Select(s => s.Trim('/')).ToList();

            Uri dirUri = new UriBuilder()
            {
                Scheme = "https",
                Host = "myaccount.file.core.windows.net",
                Path = (shareName + "/" + baseDirName).Trim('/')
            }.Uri;
            Mock<ShareDirectoryClient> mockDirectory = new Mock<ShareDirectoryClient>()
                .WithUri(dirUri)
                .WithDirectoryStructure(paths.AsTree(), sourcePermissionKey);
            Uri shareUri = new ShareUriBuilder(dirUri)
            {
                DirectoryOrFilePath = ""
            }.ToUri();
            Mock<ShareClient> mockSourceShare = new Mock<ShareClient>(shareUri, new ShareClientOptions())
                .WithUriAndPermissionKey(sourcePermission, destinationPermissionKey);
            mockDirectory.Protected()
                .Setup<ShareClient>("GetParentShareClientCore")
                .Returns(mockSourceShare.Object)
                .Verifiable();
            Mock<ShareClient> mockDestinationShare = new Mock<ShareClient>()
                .WithUriAndPermissionKey(sourcePermission, destinationPermissionKey);

            List<ShareFileStorageResource> files = new();
            List<ShareDirectoryStorageResourceContainer> directories = new();
            ShareFileTraits traits = ShareFileTraits.Attributes | ShareFileTraits.PermissionKey;
            await foreach (StorageResource storageResource
                in new SharesPathScanner().ScanAsync(
                    sourceDirectory: mockDirectory.Object,
                    destinationShare: mockDestinationShare.Object,
                    sourceOptions: default,
                    traits: traits,
                    cancellationToken: default))
            {
                if (storageResource is ShareFileStorageResource)
                    files.Add((ShareFileStorageResource) storageResource);
                else if (storageResource is ShareDirectoryStorageResourceContainer)
                    directories.Add((ShareDirectoryStorageResourceContainer) storageResource);
            }

            Assert.That(files.Select(f => f.Uri.PathAndQuery.Substring(shareName.Length + 2)), Is.EquivalentTo(expectedFilePaths));
            foreach (ShareFileStorageResource file in files)
            {
                StorageResourceItemProperties properties = file.GetResourceProperties();
                Assert.That(properties.RawProperties.GetDestinationPermissionKey(), Is.EqualTo(destinationPermissionKey));
            }
            Assert.That(directories.Select(f => f.Uri.PathAndQuery.Substring(shareName.Length + 2)), Is.EquivalentTo(expectedDirectoryPaths));
            mockDirectory.Verify(d => d.GetFilesAndDirectoriesAsync(
                It.Is<ShareDirectoryGetFilesAndDirectoriesOptions>(
                    options => options.Traits == traits),
                It.IsAny<CancellationToken>()),
                Times.Once());
            mockSourceShare.Verify(s => s.GetPermissionAsync(
                It.Is<string>(permissionKey => sourcePermissionKey.Equals(permissionKey)),
                It.IsAny<CancellationToken>()));
            mockDestinationShare.Verify(s => s.CreatePermissionAsync(
                It.Is<string>(permission => sourcePermission.Equals(permission)),
                It.IsAny<CancellationToken>()));
        }
    }
}
