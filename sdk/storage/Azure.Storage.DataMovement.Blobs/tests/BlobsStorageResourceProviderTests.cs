// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
extern alias BaseBlobs;

using System;
using Azure.Core;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using Azure.Storage.Tests;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Threading;

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
    }
}
