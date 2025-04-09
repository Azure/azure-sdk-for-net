// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMShare;
extern alias BaseShares;

using System;
using Azure.Core;
using BaseShares::Azure.Storage.Files.Shares;
using Azure.Storage.Tests;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Threading;

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

            Assert.IsNotNull(resource);
            Assert.IsNotNull(resource.ShareDirectoryClient);
            Assert.AreEqual(uri, resource.Uri);
            Assert.AreEqual(uri, resource.ShareDirectoryClient.Uri);
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

            Assert.IsNotNull(resource);
            ShareFileStorageResource fileResource = resource as ShareFileStorageResource;
            Assert.IsNotNull(fileResource.ShareFileClient);
            Assert.AreEqual(uri, resource.Uri);
            Assert.AreEqual(uri, fileResource.ShareFileClient.Uri);
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

            Assert.IsNotNull(resource);
            Assert.AreEqual(uri, resource.Uri);
            ShareFileStorageResource fileResource = resource as ShareFileStorageResource;
            Assert.IsNotNull(fileResource.ShareFileClient);
            Assert.AreEqual(uri, resource.Uri);
            Assert.AreEqual(uri, fileResource.ShareFileClient.Uri);
            AssertCredPresent(fileResource.ShareFileClient.ClientConfiguration, credType);
        }
    }
}
