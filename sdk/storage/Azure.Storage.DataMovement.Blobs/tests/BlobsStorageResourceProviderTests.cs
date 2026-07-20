// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
extern alias DMBlobs;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Tests;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class BlobsStorageResourceProviderTests
    {
        public enum CredType
        {
            None,
            SharedKey,
            Token,
            Sas
        }
        public enum BlobType
        {
            Unspecified,
            Block,
            Page,
            Append
        }

        private void AssertCredPresent(BlobClientConfiguration clientConfig, CredType credType)
        {
            Assert.IsNotNull(clientConfig);
            switch (credType)
            {
                case CredType.SharedKey:
                    Assert.IsNotNull(clientConfig.SharedKeyCredential);
                    Assert.IsNull(clientConfig.TokenCredential);
                    Assert.IsNull(clientConfig.SasCredential);
                    break;
                case CredType.Token:
                    Assert.IsNull(clientConfig.SharedKeyCredential);
                    Assert.IsNotNull(clientConfig.TokenCredential);
                    Assert.IsNull(clientConfig.SasCredential);
                    break;
                case CredType.Sas:
                    Assert.IsNull(clientConfig.SharedKeyCredential);
                    Assert.IsNull(clientConfig.TokenCredential);
                    Assert.IsNotNull(clientConfig.SasCredential);
                    break;
                case CredType.None:
                    Assert.IsNull(clientConfig.SharedKeyCredential);
                    Assert.IsNull(clientConfig.TokenCredential);
                    Assert.IsNull(clientConfig.SasCredential);
                    break;
                default:
                    throw new ArgumentException("No assertion support for cred type " + credType.ToString());
            }
        }

        private void AssertBlobStorageResourceType(
            StorageResource resource,
            BlobType blobType,
            out BlobBaseClient underlyingClient)
        {
            Assert.IsNotNull(resource);
            switch (blobType)
            {
                case BlobType.Unspecified:
                case BlobType.Block:
                    Assert.That(resource, Is.InstanceOf<BlockBlobStorageResource>());
                    BlockBlobStorageResource blockResource = resource as BlockBlobStorageResource;
                    Assert.IsNotNull(blockResource.BlobClient);
                    underlyingClient = blockResource.BlobClient;
                    break;
                case BlobType.Page:
                    Assert.That(resource, Is.InstanceOf<PageBlobStorageResource>());
                    PageBlobStorageResource pageResource = resource as PageBlobStorageResource;
                    Assert.IsNotNull(pageResource.BlobClient);
                    underlyingClient = pageResource.BlobClient;
                    break;
                case BlobType.Append:
                    Assert.That(resource, Is.InstanceOf<AppendBlobStorageResource>());
                    AppendBlobStorageResource appendResource = resource as AppendBlobStorageResource;
                    Assert.IsNotNull(appendResource.BlobClient);
                    underlyingClient = appendResource.BlobClient;
                    break;
                default:
                    throw new ArgumentException("No assertion support for blob type " + blobType.ToString());
            }
        }

        private (Mock<StorageSharedKeyCredential> SharedKey, Mock<TokenCredential> Token, Mock<AzureSasCredential> Sas) GetMockCreds()
        {
            return (
                new Mock<StorageSharedKeyCredential>("myaccount", new Random().NextBase64(64)),
                new Mock<TokenCredential>(),
                new Mock<AzureSasCredential>("mysignature"));
        }

        [Test]
        [Combinatorial]
        public async Task FromContainer(
            [Values(true, false)] bool withPrefix,
            [Values(CredType.SharedKey, CredType.Token, CredType.Sas, CredType.None)] CredType credType)
        {
            const string containerName = "mycontainer";
            const string prefix = "my/prefix";
            Uri uri = new Uri($"https://myaccount.blob.core.windows.net/{containerName}" + (withPrefix ? $"/{prefix}" : ""));
            (Mock<StorageSharedKeyCredential> SharedKey, Mock<TokenCredential> Token, Mock<AzureSasCredential> Sas) mockCreds = GetMockCreds();

            BlobsStorageResourceProvider provider = credType switch
            {
                CredType.SharedKey => new(mockCreds.SharedKey.Object),
                CredType.Token => new(mockCreds.Token.Object),
                CredType.Sas => new(mockCreds.Sas.Object),
                CredType.None => new(),
                _ => throw new ArgumentException("Bad cred type"),
            };
            BlobStorageResourceContainer resource = await provider.FromContainerAsync(uri) as BlobStorageResourceContainer;

            Assert.IsNotNull(resource);
            Assert.AreEqual(uri, resource.Uri);
            Assert.AreEqual(uri, resource.BlobContainerClient.Uri);
            AssertCredPresent(resource.BlobContainerClient.ClientConfiguration, credType);
        }

        [Test]
        [Combinatorial]
        public async Task FromBlob(
            [Values(BlobType.Unspecified, BlobType.Block, BlobType.Page, BlobType.Append)] BlobType blobType,
            [Values(CredType.SharedKey, CredType.Token, CredType.Sas, CredType.None)] CredType credType)
        {
            const string containerName = "mycontainer";
            const string blobName = "my/blob.txt";
            Uri uri = new Uri($"https://myaccount.blob.core.windows.net/{containerName}/{blobName}");
            (Mock<StorageSharedKeyCredential> SharedKey, Mock<TokenCredential> Token, Mock<AzureSasCredential> Sas) mockCreds = GetMockCreds();

            BlobsStorageResourceProvider provider = credType switch
            {
                CredType.SharedKey => new(mockCreds.SharedKey.Object),
                CredType.Token => new(mockCreds.Token.Object),
                CredType.Sas => new(mockCreds.Sas.Object),
                CredType.None => new(),
                _ => throw new ArgumentException("Bad cred type"),
            };

            StorageResource resource = blobType switch
            {
                BlobType.Unspecified => await provider.FromBlobAsync(uri),
                BlobType.Block => await provider.FromBlobAsync(uri, new BlockBlobStorageResourceOptions()),
                BlobType.Page => await provider.FromBlobAsync(uri, new PageBlobStorageResourceOptions()),
                BlobType.Append => await provider.FromBlobAsync(uri, new AppendBlobStorageResourceOptions()),
                _ => throw new ArgumentException("Bad blob type")
            };

            Assert.IsNotNull(resource);
            AssertBlobStorageResourceType(resource, blobType, out BlobBaseClient underlyingClient);
            Assert.AreEqual(uri, resource.Uri);
            Assert.AreEqual(uri, underlyingClient.Uri);
            AssertCredPresent(underlyingClient.ClientConfiguration, credType);
        }

        [Test]
        public async Task CredentialCallback(
            [Values(CredType.SharedKey, CredType.Sas)] CredType credType)
        {
            const string containerName = "mycontainer";
            const string blobName = "my/blob.txt";
            Uri uri = new Uri($"https://myaccount.blob.core.windows.net/{containerName}/{blobName}");
            (Mock<StorageSharedKeyCredential> SharedKey, Mock<TokenCredential> Token, Mock<AzureSasCredential> Sas) mockCreds = GetMockCreds();

            ValueTask<StorageSharedKeyCredential> GetSharedKeyCredential(Uri uri, CancellationToken cancellationToken)
            {
                return new ValueTask<StorageSharedKeyCredential>(mockCreds.SharedKey.Object);
            }
            ValueTask<AzureSasCredential> GetSasCredential(Uri _, CancellationToken cancellationToken)
            {
                return new ValueTask<AzureSasCredential>(mockCreds.Sas.Object);
            }

            BlobsStorageResourceProvider provider = credType switch
            {
                CredType.SharedKey => new(GetSharedKeyCredential),
                CredType.Sas => new(GetSasCredential),
                _ => throw new ArgumentException("Bad cred type"),
            };
            StorageResource resource = await provider.FromBlobAsync(uri);

            Assert.IsNotNull(resource);
            AssertBlobStorageResourceType(resource, BlobType.Block, out BlobBaseClient underlyingClient);
            Assert.AreEqual(uri, resource.Uri);
            Assert.AreEqual(uri, underlyingClient.Uri);
            AssertCredPresent(underlyingClient.ClientConfiguration, credType);
        }

        #region URI Parsing Tests
        private const string DefaultSnapshot = "2024-01-01T00:00:00.0000000Z";
        private const string DefaultVersionId = "2024-01-02T12:30:45.1234567Z";
        private const string DefaultBlobUri = "https://account.blob.core.windows.net/container/blob";

        [Test]
        public async Task ParseUri_SnapshotOnly_NullOptions()
        {
            // Arrange
            BlobsStorageResourceProvider provider = new BlobsStorageResourceProvider();
            Uri blobUri = new Uri($"{DefaultBlobUri}?snapshot={DefaultSnapshot}");

            // Act
            StorageResource resource = await provider.FromBlobAsync(blobUri, options: null);

            // Assert
            Assert.IsNotNull(resource);
            BlockBlobStorageResource blockBlob = resource as BlockBlobStorageResource;
            Assert.IsNotNull(blockBlob);
        }

        [Test]
        public async Task ParseUri_VersionIdOnly_NullOptions()
        {
            // Arrange
            BlobsStorageResourceProvider provider = new BlobsStorageResourceProvider();
            Uri blobUri = new Uri($"{DefaultBlobUri}?versionid={DefaultVersionId}");

            // Act
            StorageResource resource = await provider.FromBlobAsync(blobUri, options: null);

            // Assert
            Assert.IsNotNull(resource);
            BlockBlobStorageResource blockBlob = resource as BlockBlobStorageResource;
            Assert.IsNotNull(blockBlob);
        }

        [Test]
        public async Task ParseUri_SnapshotOnly_ExistingOptions()
        {
            // Arrange
            BlobsStorageResourceProvider provider = new BlobsStorageResourceProvider();
            Uri blobUri = new Uri($"{DefaultBlobUri}?snapshot={DefaultSnapshot}");
            BlobStorageResourceOptions options = new BlobStorageResourceOptions();

            // Act
            StorageResource resource = await provider.FromBlobAsync(blobUri, options);

            // Assert
            Assert.IsNotNull(resource);
            BlockBlobStorageResource blockBlob = resource as BlockBlobStorageResource;
            Assert.IsNotNull(blockBlob);
        }

        [Test]
        public async Task ParseUri_VersionIdOnly_ExistingOptions()
        {
            // Arrange
            BlobsStorageResourceProvider provider = new BlobsStorageResourceProvider();
            Uri blobUri = new Uri($"{DefaultBlobUri}?versionid={DefaultVersionId}");
            BlobStorageResourceOptions options = new BlobStorageResourceOptions();

            // Act
            StorageResource resource = await provider.FromBlobAsync(blobUri, options);

            // Assert
            Assert.IsNotNull(resource);
            BlockBlobStorageResource blockBlob = resource as BlockBlobStorageResource;
            Assert.IsNotNull(blockBlob);
        }

        [Test]
        public async Task ParseUri_MatchingSnapshot_ShouldNotThrow()
        {
            // Arrange
            BlobsStorageResourceProvider provider = new BlobsStorageResourceProvider();
            Uri blobUri = new Uri($"{DefaultBlobUri}?snapshot={DefaultSnapshot}");
            BlobStorageResourceOptions options = new BlobStorageResourceOptions
            {
                Snapshot = DefaultSnapshot
            };

            // Act & Assert - Should not throw
            StorageResource resource = await provider.FromBlobAsync(blobUri, options);
            Assert.IsNotNull(resource);
        }

        [Test]
        public async Task ParseUri_MatchingVersionId_ShouldNotThrow()
        {
            // Arrange
            BlobsStorageResourceProvider provider = new BlobsStorageResourceProvider();
            Uri blobUri = new Uri($"{DefaultBlobUri}?versionid={DefaultVersionId}");
            BlobStorageResourceOptions options = new BlobStorageResourceOptions
            {
                VersionId = DefaultVersionId
            };

            // Act & Assert - Should not throw
            StorageResource resource = await provider.FromBlobAsync(blobUri, options);
            Assert.IsNotNull(resource);
        }

        [Test]
        public void ParseUri_MismatchSnapshot_ShouldThrow()
        {
            // Arrange
            BlobsStorageResourceProvider provider = new BlobsStorageResourceProvider();
            Uri blobUri = new Uri($"{DefaultBlobUri}?snapshot={DefaultSnapshot}");
            BlobStorageResourceOptions options = new BlobStorageResourceOptions
            {
                Snapshot = "2025-01-01T00:00:00.0000000Z" // Different snapshot
            };

            // Act & Assert
            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await provider.FromBlobAsync(blobUri, options));

            Assert.That(ex.Message, Does.Contain("Snapshot mismatch"));
            Assert.That(ex.Message, Does.Contain(DefaultSnapshot));
        }

        [Test]
        public void ParseUri_MismatchVersionId_ShouldThrow()
        {
            // Arrange
            BlobsStorageResourceProvider provider = new BlobsStorageResourceProvider();
            Uri blobUri = new Uri($"{DefaultBlobUri}?versionid={DefaultVersionId}");
            BlobStorageResourceOptions options = new BlobStorageResourceOptions
            {
                VersionId = "2025-01-02T12:30:45.1234567Z" // Different version
            };

            // Act & Assert
            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await provider.FromBlobAsync(blobUri, options));

            Assert.That(ex.Message, Does.Contain("VersionId mismatch"));
            Assert.That(ex.Message, Does.Contain(DefaultVersionId));
        }

        [Test]
        public async Task ParseUri_NoSnapshotOrVersion_ReturnsOriginalOptions()
        {
            // Arrange
            BlobsStorageResourceProvider provider = new BlobsStorageResourceProvider();
            Uri blobUri = new Uri(DefaultBlobUri); // No snapshot or version
            BlobStorageResourceOptions options = new BlobStorageResourceOptions();

            // Act
            StorageResource resource = await provider.FromBlobAsync(blobUri, options);

            // Assert
            Assert.IsNotNull(resource);
        }

        [Test]
        public void ParseUri_BothInUri_ShouldThrow()
        {
            // Arrange
            BlobsStorageResourceProvider provider = new BlobsStorageResourceProvider();
            // This URI has both snapshot and versionid - the options validation should catch mutual exclusivity
            Uri blobUri = new Uri($"{DefaultBlobUri}?snapshot={DefaultSnapshot}&versionid={DefaultVersionId}");

            // Act & Assert
            // When setting both in options, it should throw due to mutual exclusivity in the options setter
            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await provider.FromBlobAsync(blobUri, options: null));

            Assert.That(ex.Message, Does.Contain("cannot both be set").Or.Contains("mismatch"));
        }
        #endregion
    }
}
