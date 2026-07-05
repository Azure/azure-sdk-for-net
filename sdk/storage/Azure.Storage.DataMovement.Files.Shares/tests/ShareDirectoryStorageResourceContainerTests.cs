// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseShares;
extern alias DMShare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Test;
using Azure.Storage.Tests;
using BaseShares::Azure.Storage.Files.Shares;
using BaseShares::Azure.Storage.Files.Shares.Models;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    internal class ShareDirectoryStorageResourceContainerTests
    {
        private async IAsyncEnumerable<StorageResource> ToAsyncEnumerable(
            IEnumerable<StorageResource> resources)
        {
            for (int i = 0; i < resources.Count(); i++)
            {
                // returning async enumerable must be an async method
                // so we need something to await
                yield return await Task.FromResult(resources.ElementAt(i));
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
            List<StorageResource> expectedResources = expectedFiles.Select(m => (StorageResource)new ShareFileStorageResource(m.Object)).ToList();
            expectedResources.Concat(expectedDirectories.Select(m => (StorageResource)new ShareDirectoryStorageResourceContainer(m.Object, default)));
            // And a mock path scanner
            Mock<SharesPathScanner> pathScanner = new();
            pathScanner.Setup(p => p.ScanAsync(
                mainClient.Object,
                default,
                It.IsAny<ShareFileStorageResourceOptions>(),
                It.IsAny<ShareFileTraits>(),
                It.IsAny<CancellationToken>()))
                .Returns<ShareDirectoryClient, ShareClient, ShareFileStorageResourceOptions, ShareFileTraits, CancellationToken>(
                (dir, shareclient, options, traits, cancellationToken) => ToAsyncEnumerable(expectedResources));

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
                string.Join("/", pathSegments),
                "ShareFile");

            Assert.That(resourceItem, Is.TypeOf(typeof(ShareFileStorageResource)));
            ShareFileStorageResource fileResourceItem = resourceItem as ShareFileStorageResource;
            Assert.That(fileResourceItem.ShareFileClient.Path,
                Is.EqualTo(startingDir.Path + "/" + string.Join("/", pathSegments)));
            Assert.That(fileResourceItem.ShareFileClient.Name, Is.EqualTo(pathSegments.Last()));
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

        [Test]
        public void GetStorageResourceReference_Encoding()
        {
            string[] dirs = ["prefix", "pre=fix", "prefix with space"];
            string[] tests =
            [
                "path=true@&#%",
                "path%3Dtest%26",
                "with space",
                "sub=dir/path=true@&#%",
                "sub%3Ddir/path=true@&#%",
                "sub dir/path=true@&#%"
            ];

            string sharePath = "https://account.file.core.windows.net/myshare";
            ShareClient shareClient = new(new Uri(sharePath));

            foreach (string dir in dirs)
            {
                ShareDirectoryClient directoryClient = shareClient.GetDirectoryClient(dir);
                ShareDirectoryStorageResourceContainer containerResource = new(directoryClient, default);
                foreach (string test in tests)
                {
                    StorageResourceItem resource = containerResource.GetStorageResourceReference(test, default);

                    string combined = string.Join("/", sharePath, Uri.EscapeDataString(dir), Uri.EscapeDataString(test).Replace("%2F", "/"));
                    Assert.That(resource.Uri.AbsoluteUri, Is.EqualTo(combined));
                }
            }
        }

        [Test]
        public void Ctor_SnapshotFromOptions_AppliedToClient()
        {
            // Arrange - client without snapshot, options with snapshot
            string snapshot = "2024-01-01T00:00:00.0000000Z";
            Uri uri = new Uri("https://myaccount.file.core.windows.net/myshare/mydir");
            ShareDirectoryClient client = new(uri, new ShareClientOptions());
            ShareFileStorageResourceOptions options = new() { Snapshot = snapshot };

            // Act
            ShareDirectoryStorageResourceContainer container = new(client, options);

            // Assert - snapshot should be in the client URI
            ShareUriBuilder resultUri = new(container.ShareDirectoryClient.Uri);
            Assert.That(resultUri.Snapshot, Is.EqualTo(snapshot));
        }

        [Test]
        public void Ctor_SnapshotFromOptions_ClientAlreadyHasMatchingSnapshot()
        {
            // Arrange - client already has the snapshot
            string snapshot = "2024-01-01T00:00:00.0000000Z";
            Uri uri = new Uri($"https://myaccount.file.core.windows.net/myshare/mydir?sharesnapshot={snapshot}");
            ShareDirectoryClient client = new(uri, new ShareClientOptions());
            ShareFileStorageResourceOptions options = new() { Snapshot = snapshot };

            // Act
            ShareDirectoryStorageResourceContainer container = new(client, options);

            // Assert - snapshot should still be present
            ShareUriBuilder resultUri = new(container.ShareDirectoryClient.Uri);
            Assert.That(resultUri.Snapshot, Is.EqualTo(snapshot));
        }

        [Test]
        public void Ctor_NoSnapshot_ClientUnchanged()
        {
            // Arrange - no snapshot in options or client
            Uri uri = new Uri("https://myaccount.file.core.windows.net/myshare/mydir");
            ShareDirectoryClient client = new(uri, new ShareClientOptions());

            // Act
            ShareDirectoryStorageResourceContainer container = new(client, default);

            // Assert - no snapshot in URI
            ShareUriBuilder resultUri = new(container.ShareDirectoryClient.Uri);
            Assert.That(resultUri.Snapshot, Is.Empty);
        }

        [Test]
        public void GetChildStorageResourceContainer_PreservesSnapshot()
        {
            // Arrange - container with snapshot
            string snapshot = "2024-01-01T00:00:00.0000000Z";
            Uri uri = new Uri("https://myaccount.file.core.windows.net/myshare/mydir");
            ShareDirectoryClient client = new(uri, new ShareClientOptions());
            ShareFileStorageResourceOptions options = new() { Snapshot = snapshot };
            ShareDirectoryStorageResourceContainer container = new(client, options);

            // Act
            StorageResourceContainer child = container.GetChildStorageResourceContainerInternal("subdir");

            // Assert - child should have the snapshot
            ShareUriBuilder resultUri = new(child.Uri);
            Assert.That(resultUri.Snapshot, Is.EqualTo(snapshot));
        }

        [Test]
        public void GetStorageResourceReference_PreservesSnapshot()
        {
            // Arrange - container with snapshot
            string snapshot = "2024-01-01T00:00:00.0000000Z";
            Uri uri = new Uri("https://myaccount.file.core.windows.net/myshare/mydir");
            ShareDirectoryClient client = new(uri, new ShareClientOptions());
            ShareFileStorageResourceOptions options = new() { Snapshot = snapshot };
            ShareDirectoryStorageResourceContainer container = new(client, options);

            // Act
            StorageResourceItem resource = container.GetStorageResourceReferenceInternal("subdir/file.txt", "ShareFile");

            // Assert - file resource should have the snapshot
            Assert.That(resource, Is.TypeOf(typeof(ShareFileStorageResource)));
            ShareFileStorageResource fileResource = resource as ShareFileStorageResource;
            ShareUriBuilder resultUri = new(fileResource.ShareFileClient.Uri);
            Assert.That(resultUri.Snapshot, Is.EqualTo(snapshot));
        }
    }
}
