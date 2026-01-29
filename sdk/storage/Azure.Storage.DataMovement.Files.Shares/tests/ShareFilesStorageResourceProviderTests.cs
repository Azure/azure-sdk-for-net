// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseShares;
extern alias DMShare;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Tests;
using BaseShares::Azure.Storage.Files.Shares;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    public class ShareFilesStorageResourceProviderTests
    {
        public enum CredType
        {
            None,
            SharedKey,
            Token,
            Sas
        }

        private void AssertCredPresent(ShareClientConfiguration clientConfig, CredType credType)
        {
            Assert.That(clientConfig, Is.Not.Null);
            switch (credType)
            {
                case CredType.SharedKey:
                    Assert.That(clientConfig.SharedKeyCredential, Is.Not.Null);
                    Assert.That(clientConfig.TokenCredential, Is.Null);
                    Assert.That(clientConfig.SasCredential, Is.Null);
                    break;
                case CredType.Token:
                    Assert.That(clientConfig.SharedKeyCredential, Is.Null);
                    Assert.That(clientConfig.TokenCredential, Is.Not.Null);
                    Assert.That(clientConfig.SasCredential, Is.Null);
                    break;
                case CredType.Sas:
                    Assert.That(clientConfig.SharedKeyCredential, Is.Null);
                    Assert.That(clientConfig.TokenCredential, Is.Null);
                    Assert.That(clientConfig.SasCredential, Is.Not.Null);
                    break;
                case CredType.None:
                    Assert.That(clientConfig.SharedKeyCredential, Is.Null);
                    Assert.That(clientConfig.TokenCredential, Is.Null);
                    Assert.That(clientConfig.SasCredential, Is.Null);
                    break;
                default:
                    throw new ArgumentException("No assertion support for cred type " + credType.ToString());
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
        public async Task FromDirectoryAsync(
            [Values(true, false)] bool withPrefix,
            [Values(CredType.SharedKey, CredType.Token, CredType.Sas, CredType.None)] CredType credType)
        {
            const string containerName = "mycontainer";
            const string prefix = "my/prefix";
            Uri uri = new Uri($"https://myaccount.blob.core.windows.net/{containerName}" + (withPrefix ? $"/{prefix}" : ""));
            (Mock<StorageSharedKeyCredential> SharedKey, Mock<TokenCredential> Token, Mock<AzureSasCredential> Sas) mockCreds = GetMockCreds();

            ShareFilesStorageResourceProvider provider = credType switch
            {
                CredType.SharedKey => new(mockCreds.SharedKey.Object),
                CredType.Token => new(mockCreds.Token.Object),
                CredType.Sas => new(mockCreds.Sas.Object),
                CredType.None => new(),
                _ => throw new ArgumentException("Bad cred type"),
            };
            ShareDirectoryStorageResourceContainer resource = await provider.FromDirectoryAsync(uri) as ShareDirectoryStorageResourceContainer;

            Assert.That(resource, Is.Not.Null);
            Assert.That(resource.ShareDirectoryClient, Is.Not.Null);
            Assert.That(resource.Uri, Is.EqualTo(uri));
            Assert.That(resource.ShareDirectoryClient.Uri, Is.EqualTo(uri));
            AssertCredPresent(resource.ShareDirectoryClient.ClientConfiguration, credType);
        }

        [Test]
        [Combinatorial]
        public async Task FromFileAsync(
            [Values(CredType.SharedKey, CredType.Token, CredType.Sas, CredType.None)] CredType credType)
        {
            const string shareName = "mycontainer";
            const string directoryName = "directoryName";
            const string fileName = "file.txt";
            Uri uri = new Uri($"https://myaccount.blob.core.windows.net/{shareName}/{directoryName}/{fileName}");
            (Mock<StorageSharedKeyCredential> SharedKey, Mock<TokenCredential> Token, Mock<AzureSasCredential> Sas) mockCreds = GetMockCreds();

            ShareFilesStorageResourceProvider provider = credType switch
            {
                CredType.SharedKey => new(mockCreds.SharedKey.Object),
                CredType.Token => new(mockCreds.Token.Object),
                CredType.Sas => new(mockCreds.Sas.Object),
                CredType.None => new(),
                _ => throw new ArgumentException("Bad cred type"),
            };
            StorageResource resource = await provider.FromFileAsync(uri);

            Assert.That(resource, Is.Not.Null);
            ShareFileStorageResource fileResource = resource as ShareFileStorageResource;
            Assert.That(fileResource.ShareFileClient, Is.Not.Null);
            Assert.That(resource.Uri, Is.EqualTo(uri));
            Assert.That(fileResource.ShareFileClient.Uri, Is.EqualTo(uri));
            AssertCredPresent(fileResource.ShareFileClient.ClientConfiguration, credType);
        }

        [Test]
        public async Task CredentialCallback(
            [Values(CredType.SharedKey, CredType.Sas)] CredType credType)
        {
            const string shareName = "mycontainer";
            const string directoryName = "directoryName";
            const string fileName = "file.txt";
            Uri uri = new Uri($"https://myaccount.blob.core.windows.net/{shareName}/{directoryName}/{fileName}");
            (Mock<StorageSharedKeyCredential> SharedKey, Mock<TokenCredential> Token, Mock<AzureSasCredential> Sas) mockCreds = GetMockCreds();

            ValueTask<StorageSharedKeyCredential> GetSharedKeyCredential(Uri uri, CancellationToken cancellationToken)
            {
                return new ValueTask<StorageSharedKeyCredential>(mockCreds.SharedKey.Object);
            }
            ValueTask<AzureSasCredential> GetSasCredential(Uri _, CancellationToken cancellationToken)
            {
                return new ValueTask<AzureSasCredential>(mockCreds.Sas.Object);
            }

            ShareFilesStorageResourceProvider provider = credType switch
            {
                CredType.SharedKey => new(GetSharedKeyCredential),
                CredType.Sas => new(GetSasCredential),
                _ => throw new ArgumentException("Bad cred type"),
            };
            StorageResource resource = await provider.FromFileAsync(uri);

            Assert.That(resource, Is.Not.Null);
            Assert.That(resource.Uri, Is.EqualTo(uri));
            ShareFileStorageResource fileResource = resource as ShareFileStorageResource;
            Assert.That(fileResource.ShareFileClient, Is.Not.Null);
            Assert.That(resource.Uri, Is.EqualTo(uri));
            Assert.That(fileResource.ShareFileClient.Uri, Is.EqualTo(uri));
            AssertCredPresent(fileResource.ShareFileClient.ClientConfiguration, credType);
        }
    }
}
