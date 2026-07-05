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

        #region URI Parsing Tests
        private const string DefaultSnapshot = "2024-01-01T00:00:00.0000000Z";
        private const string DefaultFileUri = "https://account.file.core.windows.net/share/file";

        [Test]
        public async Task ParseUri_SnapshotOnly_NullOptions()
        {
            // Arrange
            ShareFilesStorageResourceProvider provider = new ShareFilesStorageResourceProvider();
            Uri fileUri = new Uri($"{DefaultFileUri}?sharesnapshot={DefaultSnapshot}");

            // Act
            StorageResource resource = await provider.FromFileAsync(fileUri, options: null);

            // Assert
            Assert.IsNotNull(resource);
            ShareFileStorageResource shareFile = resource as ShareFileStorageResource;
            Assert.IsNotNull(shareFile);
        }

        [Test]
        public async Task ParseUri_SnapshotOnly_ExistingOptions()
        {
            // Arrange
            ShareFilesStorageResourceProvider provider = new ShareFilesStorageResourceProvider();
            Uri fileUri = new Uri($"{DefaultFileUri}?sharesnapshot={DefaultSnapshot}");
            ShareFileStorageResourceOptions options = new ShareFileStorageResourceOptions();

            // Act
            StorageResource resource = await provider.FromFileAsync(fileUri, options);

            // Assert
            Assert.IsNotNull(resource);
            ShareFileStorageResource shareFile = resource as ShareFileStorageResource;
            Assert.IsNotNull(shareFile);
        }

        [Test]
        public async Task ParseUri_MatchingSnapshot_ShouldNotThrow()
        {
            // Arrange
            ShareFilesStorageResourceProvider provider = new ShareFilesStorageResourceProvider();
            Uri fileUri = new Uri($"{DefaultFileUri}?sharesnapshot={DefaultSnapshot}");
            ShareFileStorageResourceOptions options = new ShareFileStorageResourceOptions
            {
                Snapshot = DefaultSnapshot
            };

            // Act & Assert - Should not throw
            StorageResource resource = await provider.FromFileAsync(fileUri, options);
            Assert.IsNotNull(resource);
        }

        [Test]
        public void ParseUri_MismatchSnapshot_ShouldThrow()
        {
            // Arrange
            ShareFilesStorageResourceProvider provider = new ShareFilesStorageResourceProvider();
            Uri fileUri = new Uri($"{DefaultFileUri}?sharesnapshot={DefaultSnapshot}");
            ShareFileStorageResourceOptions options = new ShareFileStorageResourceOptions
            {
                Snapshot = "2025-01-01T00:00:00.0000000Z" // Different snapshot
            };

            // Act & Assert
            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await provider.FromFileAsync(fileUri, options));

            Assert.That(ex.Message, Does.Contain("Snapshot mismatch"));
            Assert.That(ex.Message, Does.Contain(DefaultSnapshot));
        }

        [Test]
        public async Task ParseUri_NoSnapshot_ReturnsOriginalOptions()
        {
            // Arrange
            ShareFilesStorageResourceProvider provider = new ShareFilesStorageResourceProvider();
            Uri fileUri = new Uri(DefaultFileUri); // No snapshot
            ShareFileStorageResourceOptions options = new ShareFileStorageResourceOptions();

            // Act
            StorageResource resource = await provider.FromFileAsync(fileUri, options);

            // Assert
            Assert.IsNotNull(resource);
        }

        [Test]
        public async Task ParseUri_Directory_SnapshotOnly_NullOptions()
        {
            // Arrange
            ShareFilesStorageResourceProvider provider = new ShareFilesStorageResourceProvider();
            string directoryUri = "https://account.file.core.windows.net/share/directory";
            Uri dirUri = new Uri($"{directoryUri}?sharesnapshot={DefaultSnapshot}");

            // Act
            StorageResource resource = await provider.FromDirectoryAsync(dirUri, options: null);

            // Assert
            Assert.IsNotNull(resource);
            ShareDirectoryStorageResourceContainer shareDir = resource as ShareDirectoryStorageResourceContainer;
            Assert.IsNotNull(shareDir);
        }

        [Test]
        public async Task ParseUri_Directory_MatchingSnapshot_ShouldNotThrow()
        {
            // Arrange
            ShareFilesStorageResourceProvider provider = new ShareFilesStorageResourceProvider();
            string directoryUri = "https://account.file.core.windows.net/share/directory";
            Uri dirUri = new Uri($"{directoryUri}?sharesnapshot={DefaultSnapshot}");
            ShareFileStorageResourceOptions options = new ShareFileStorageResourceOptions
            {
                Snapshot = DefaultSnapshot
            };

            // Act & Assert - Should not throw
            StorageResource resource = await provider.FromDirectoryAsync(dirUri, options);
            Assert.IsNotNull(resource);
        }

        [Test]
        public void ParseUri_Directory_MismatchSnapshot_ShouldThrow()
        {
            // Arrange
            ShareFilesStorageResourceProvider provider = new ShareFilesStorageResourceProvider();
            string directoryUri = "https://account.file.core.windows.net/share/directory";
            Uri dirUri = new Uri($"{directoryUri}?sharesnapshot={DefaultSnapshot}");
            ShareFileStorageResourceOptions options = new ShareFileStorageResourceOptions
            {
                Snapshot = "2025-01-01T00:00:00.0000000Z" // Different snapshot
            };

            // Act & Assert
            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await provider.FromDirectoryAsync(dirUri, options));

            Assert.That(ex.Message, Does.Contain("Snapshot mismatch"));
            Assert.That(ex.Message, Does.Contain(DefaultSnapshot));
        }
        #endregion
    }
}
