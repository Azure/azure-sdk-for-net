// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// Verifies that <see cref="ShareChangeFeedExtensions"/> correctly propagates
    /// authentication credentials from the source <see cref="ShareServiceClient"/>
    /// or <see cref="ShareClient"/> to the internal <see cref="Azure.Storage.Blobs.BlobServiceClient"/>.
    /// </summary>
    public class ShareChangeFeedExtensionsTests : ShareChangeFeedTestBase
    {
        private const string TestShareName = "myshare";
        private static readonly Uri FileServiceUri = new Uri("https://account.file.core.windows.net");
        private static readonly Uri FileServiceUriWithSas = new Uri("https://account.file.core.windows.net?sv=2024-01-01&ss=f&srt=sco&sig=fakesig");
        private static readonly Uri ShareUri = new Uri("https://account.file.core.windows.net/myshare");
        private static readonly Uri ShareUriWithSas = new Uri("https://account.file.core.windows.net/myshare?sv=2024-01-01&ss=f&srt=sco&sig=fakesig");

        public ShareChangeFeedExtensionsTests(
            bool async,
            ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        #region ShareServiceClient extension

        [Test]
        public void ShareServiceClient_SharedKey_PropagatesCredentialToBlobClient()
        {
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(
                "account",
                Convert.ToBase64String(new byte[64]));
            ShareServiceClient serviceClient = new ShareServiceClient(FileServiceUri, credential);

            ShareChangeFeedClient changeFeedClient = serviceClient.GetShareChangeFeedClient(TestShareName);

            Assert.IsNotNull(changeFeedClient._blobServiceClient);
            Assert.AreEqual(
                "https://account.blob.core.windows.net/",
                changeFeedClient._blobServiceClient.Uri.ToString());
        }

        [Test]
        public void ShareServiceClient_TokenCredential_PropagatesCredentialToBlobClient()
        {
            MockCredential credential = new MockCredential();
            ShareClientOptions options = new ShareClientOptions
            {
                ShareTokenIntent = ShareTokenIntent.Backup,
            };
            ShareServiceClient serviceClient = new ShareServiceClient(
                FileServiceUri,
                credential,
                options);

            ShareChangeFeedClient changeFeedClient = serviceClient.GetShareChangeFeedClient(TestShareName);

            Assert.IsNotNull(changeFeedClient._blobServiceClient);
            Assert.AreEqual(
                "https://account.blob.core.windows.net/",
                changeFeedClient._blobServiceClient.Uri.ToString());
        }

        [Test]
        public void ShareServiceClient_SasToken_PreservesSasInBlobEndpoint()
        {
            ShareServiceClient serviceClient = new ShareServiceClient(FileServiceUriWithSas);

            ShareChangeFeedClient changeFeedClient = serviceClient.GetShareChangeFeedClient(TestShareName);

            Assert.IsNotNull(changeFeedClient._blobServiceClient);
            string blobUri = changeFeedClient._blobServiceClient.Uri.ToString();
            Assert.That(blobUri, Does.StartWith("https://account.blob.core.windows.net/"));
            Assert.That(blobUri, Does.Contain("sig=fakesig"));
        }

        #endregion

        #region ShareClient extension

        [Test]
        public void ShareClient_SharedKey_PropagatesCredentialToBlobClient()
        {
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(
                "account",
                Convert.ToBase64String(new byte[64]));
            ShareClient shareClient = new ShareClient(ShareUri, credential);

            ShareChangeFeedClient changeFeedClient = shareClient.GetShareChangeFeedClient();

            Assert.IsNotNull(changeFeedClient._blobServiceClient);
            Assert.AreEqual(
                "https://account.blob.core.windows.net/",
                changeFeedClient._blobServiceClient.Uri.ToString());
        }

        [Test]
        public void ShareClient_TokenCredential_PropagatesCredentialToBlobClient()
        {
            MockCredential credential = new MockCredential();
            ShareClientOptions options = new ShareClientOptions
            {
                ShareTokenIntent = ShareTokenIntent.Backup,
            };
            ShareClient shareClient = new ShareClient(ShareUri, credential, options);

            ShareChangeFeedClient changeFeedClient = shareClient.GetShareChangeFeedClient();

            Assert.IsNotNull(changeFeedClient._blobServiceClient);
            Assert.AreEqual(
                "https://account.blob.core.windows.net/",
                changeFeedClient._blobServiceClient.Uri.ToString());
        }

        [Test]
        public void ShareClient_SasToken_PreservesSasInBlobEndpoint()
        {
            ShareClient shareClient = new ShareClient(ShareUriWithSas);

            ShareChangeFeedClient changeFeedClient = shareClient.GetShareChangeFeedClient();

            Assert.IsNotNull(changeFeedClient._blobServiceClient);
            string blobUri = changeFeedClient._blobServiceClient.Uri.ToString();
            Assert.That(blobUri, Does.StartWith("https://account.blob.core.windows.net/"));
            Assert.That(blobUri, Does.Contain("sig=fakesig"));
        }

        #endregion

        #region FileToBlobEndpoint

        [Test]
        public void FileToBlobEndpoint_ConvertsDomain()
        {
            Uri fileUri = new Uri("https://account.file.core.windows.net");

            Uri blobUri = ContainerDiscovery.FileToBlobEndpoint(fileUri);

            Assert.AreEqual("account.blob.core.windows.net", blobUri.Host);
            Assert.AreEqual("/", blobUri.AbsolutePath);
        }

        [Test]
        public void FileToBlobEndpoint_PreservesQueryString()
        {
            Uri fileUri = new Uri("https://account.file.core.windows.net?sv=2024-01-01&ss=f&sig=fakesig");

            Uri blobUri = ContainerDiscovery.FileToBlobEndpoint(fileUri);

            Assert.AreEqual("account.blob.core.windows.net", blobUri.Host);
            Assert.That(blobUri.Query, Does.Contain("sig=fakesig"));
        }

        #endregion

        #region DiscoverContainerNameAsync

        /// <summary>
        /// Verifies that DiscoverContainerNameAsync returns the container name when the
        /// change feed container header is present in the raw response.
        /// </summary>
        [Test]
        public async Task DiscoverContainerNameAsync_HeaderPresent_ReturnsContainerName()
        {
            // Arrange
            Mock<ShareClient> shareClient = new Mock<ShareClient>();
            shareClient.Setup(c => c.Name).Returns("myshare");

            MockResponse rawResponse = new MockResponse(200);
            rawResponse.AddHeader(
                "x-ms-file-blob-container-for-xfiles-change-feed",
                "$fileschangefeed-abc123");

            ShareProperties properties = ShareModelFactory.ShareProperties(
                enableSnapshotVirtualDirectoryAccess: default);
            Response<ShareProperties> response = Response.FromValue(properties, rawResponse);

            if (IsAsync)
            {
                shareClient.Setup(c => c.GetPropertiesAsync(
                    It.IsAny<CancellationToken>()))
                    .ReturnsAsync(response);
            }
            else
            {
                shareClient.Setup(c => c.GetProperties(
                    It.IsAny<CancellationToken>()))
                    .Returns(response);
            }

            // Act
            string containerName = await ContainerDiscovery.DiscoverContainerNameAsync(
                shareClient.Object,
                IsAsync,
                CancellationToken.None);

            // Assert
            Assert.AreEqual("$fileschangefeed-abc123", containerName);
        }

        /// <summary>
        /// Verifies that DiscoverContainerNameAsync throws <see cref="InvalidOperationException"/>
        /// when the change feed container header is missing from the response.
        /// </summary>
        [Test]
        public void DiscoverContainerNameAsync_HeaderMissing_ThrowsInvalidOperationException()
        {
            // Arrange
            Mock<ShareClient> shareClient = new Mock<ShareClient>();
            shareClient.Setup(c => c.Name).Returns("myshare");

            MockResponse rawResponse = new MockResponse(200);
            // No change feed header added

            ShareProperties properties = ShareModelFactory.ShareProperties(
                enableSnapshotVirtualDirectoryAccess: default);
            Response<ShareProperties> response = Response.FromValue(properties, rawResponse);

            if (IsAsync)
            {
                shareClient.Setup(c => c.GetPropertiesAsync(
                    It.IsAny<CancellationToken>()))
                    .ReturnsAsync(response);
            }
            else
            {
                shareClient.Setup(c => c.GetProperties(
                    It.IsAny<CancellationToken>()))
                    .Returns(response);
            }

            // Act & Assert
            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(
                async () => await ContainerDiscovery.DiscoverContainerNameAsync(
                    shareClient.Object,
                    IsAsync,
                    CancellationToken.None));

            StringAssert.Contains("myshare", ex.Message);
            StringAssert.Contains("Change Feed is not enabled", ex.Message);
        }

        #endregion
    }
}
