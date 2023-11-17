// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using Azure.Storage.Tests;
using BenchmarkDotNet.Toolchains.Roslyn;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    internal class ShareDirectoryStorageResourceContainerTests
    {
        private async IAsyncEnumerable<(TDirectory Directory, TFile File)> ToAsyncEnumerable<TDirectory, TFile>(
            IEnumerable<TDirectory> directories,
            IEnumerable<TFile> files)
        {
            if (files.Count() != directories.Count())
            {
                throw new ArgumentException("Items and Directories should be the same amount");
            }
            for (int i = 0; i < files.Count(); i++)
            {
                // returning async enumerable must be an async method
                // so we need something to await
                yield return await Task.FromResult((directories.ElementAt(i), files.ElementAt(i)));
            }
        }

        [Test]
        public async Task GetStorageResourcesCallsPathScannerCorrectly()
        {
            // Given clients
            Mock<ShareDirectoryClient> mainClient = new();
            int pathCount = 10;
            List<Mock<ShareFileClient>> expectedFiles = Enumerable.Range(0, pathCount)
                .Select(i => new Mock<ShareFileClient>())
                .ToList();
            List<Mock<ShareDirectoryClient>> expectedDirectories = Enumerable.Range(0, pathCount)
                .Select(i => new Mock<ShareDirectoryClient>())
                .ToList();

            // And a mock path scanner
            Mock<PathScanner> pathScanner = new();
            pathScanner.Setup(p => p.ScanAsync(mainClient.Object, It.IsAny<CancellationToken>()))
                .Returns<ShareDirectoryClient, CancellationToken>(
                (dir, cancellationToken) => ToAsyncEnumerable(
                    expectedDirectories.Select(m => m.Object),
                    expectedFiles.Select(m => m.Object)));

            // Setup StorageResourceContainer
            ShareDirectoryStorageResourceContainer resource = new(mainClient.Object, default)
            {
                PathScanner = pathScanner.Object
            };

            // Verify StorageResourceContainer correctly invokes path scanner and returns the given files
            List<ShareFileClient> results = new();
            await foreach (StorageResource res in resource.GetStorageResourcesInternalAsync())
            {
                Assert.That(res, Is.TypeOf(typeof(ShareFileStorageResource)));
                results.Add((res as ShareFileStorageResource).ShareFileClient);
            }
            Assert.That(results, Is.EquivalentTo(expectedFiles.Select(mock => mock.Object)));
        }

        [Test]
        public void GetCorrectStorageResourceItem()
        {
            // Given a resource container
            ShareDirectoryClient startingDir = new(new Uri("https://myaccount.file.core.windows.net/myshare/mydir"), new ShareClientOptions());
            ShareDirectoryStorageResourceContainer resourceContainer = new(startingDir, default);

            // and a subpath to get
            Random r = new();
            List<string> pathSegments = Enumerable.Range(0, 5).Select(_ => r.NextString(10)).ToList();
            pathSegments.Add(r.NextString(10) + ".txt");

            // Get the subpath resource item
            StorageResourceItem resourceItem = resourceContainer.GetStorageResourceReferenceInternal(
                string.Join("/", pathSegments));

            Assert.That(resourceItem, Is.TypeOf(typeof(ShareFileStorageResource)));
            ShareFileStorageResource fileResourceItem = resourceItem as ShareFileStorageResource;
            Assert.That(fileResourceItem.ShareFileClient.Path,
                Is.EqualTo(startingDir.Path + "/" + string.Join("/", pathSegments)));
            Assert.That(fileResourceItem.ShareFileClient.Name, Is.EqualTo(pathSegments.Last()));
        }

        [Test]
        public async Task CreateIfNotExists()
        {
            // Arrange
            Mock<ShareDirectoryClient> mock = new(new Uri("https://myaccount.file.core.windows.net/myshare/mydir"), new ShareClientOptions());
            mock.Setup(b => b.CreateIfNotExistsAsync(It.IsAny<IDictionary<string, string>>(), It.IsAny<FileSmbProperties>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response.FromValue(
                    SharesModelFactory.StorageDirectoryInfo(
                        eTag: new ETag("etag"),
                        lastModified: DateTimeOffset.UtcNow,
                        filePermissionKey: default,
                        fileAttributes: default,
                        fileCreationTime: DateTimeOffset.MinValue,
                        fileLastWriteTime: DateTimeOffset.MinValue,
                        fileChangeTime: DateTimeOffset.MinValue,
                        fileId: default,
                        fileParentId: default),
                    new MockResponse(200))));

            ShareDirectoryStorageResourceContainer resourceContainer = new(mock.Object, default);

            // Act
            await resourceContainer.CreateIfNotExistsInternalAsync();

            // Assert
            mock.Verify(b => b.CreateIfNotExistsAsync(It.IsAny<IDictionary<string, string>>(), It.IsAny<FileSmbProperties>(), It.IsAny<string>(), It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CreateIfNotExists_Error()
        {
            // Arrange
            Mock<ShareDirectoryClient> mock = new(new Uri("https://myaccount.file.core.windows.net/myshare/mydir"), new ShareClientOptions());
            mock.Setup(b => b.CreateIfNotExistsAsync(It.IsAny<IDictionary<string, string>>(), It.IsAny<FileSmbProperties>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Throws(new RequestFailedException(status: 404, message: "The parent path does not exist.", errorCode: "ResourceNotFound", default));

            ShareDirectoryStorageResourceContainer resourceContainer = new(mock.Object, default);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                resourceContainer.CreateIfNotExistsInternalAsync(),
                e =>
                {
                    Assert.AreEqual("ResourceNotFound", e.ErrorCode);
                });

            mock.Verify(b => b.CreateIfNotExistsAsync(It.IsAny<IDictionary<string, string>>(), It.IsAny<FileSmbProperties>(), It.IsAny<string>(), It.IsAny<CancellationToken>()),
                Times.Once());
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetChildStorageResourceContainer()
        {
            // Arrange
            Uri uri = new Uri("https://storageaccount.file.core.windows.net/container/directory");
            Mock<ShareDirectoryClient> mock = new Mock<ShareDirectoryClient>(uri, new ShareClientOptions());
            mock.Setup(b => b.Uri).Returns(uri);
            mock.Setup(b => b.GetSubdirectoryClient(It.IsAny<string>()))
                .Returns<string>((path) =>
                {
                    UriBuilder builder = new UriBuilder(uri);
                    builder.Path = string.Join("/", builder.Path, path);
                    return new ShareDirectoryClient(builder.Uri);
                });

            ShareDirectoryStorageResourceContainer containerResource =
                new(mock.Object, new ShareFileStorageResourceOptions());

            // Act
            string childPath = "foo";
            StorageResourceContainer childContainer = containerResource.GetChildStorageResourceContainerInternal(childPath);

            // Assert
            UriBuilder builder = new UriBuilder(containerResource.Uri);
            builder.Path = string.Join("/", builder.Path, childPath);
            Assert.AreEqual(builder.Uri, childContainer.Uri);
        }
    }
}
