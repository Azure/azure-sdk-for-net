// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    /// Tests for <see cref="ContainerDiscovery"/> covering container name discovery
    /// via the <c>x-ms-file-blob-container-for-xfiles-change-feed</c> response header.
    /// </summary>
    public class ContainerDiscoveryTests : ShareChangeFeedTestBase
    {
        public ContainerDiscoveryTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

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
        /// Verifies that DiscoverContainerNameAsync throws <see cref="System.InvalidOperationException"/>
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
            System.InvalidOperationException ex = Assert.ThrowsAsync<System.InvalidOperationException>(
                async () => await ContainerDiscovery.DiscoverContainerNameAsync(
                    shareClient.Object,
                    IsAsync,
                    CancellationToken.None));

            StringAssert.Contains("myshare", ex.Message);
            StringAssert.Contains("Change Feed is not enabled", ex.Message);
        }

        // Helper to set up a mocked ShareClient that returns the given header value.
        private void SetupMockShareWithHeader(Mock<ShareClient> shareClient, string headerValue)
        {
            shareClient.Setup(c => c.Name).Returns("myshare");
            MockResponse rawResponse = new MockResponse(200);
            if (headerValue != null)
                rawResponse.AddHeader("x-ms-file-blob-container-for-xfiles-change-feed", headerValue);

            ShareProperties properties = ShareModelFactory.ShareProperties(enableSnapshotVirtualDirectoryAccess: default);
            Response<ShareProperties> response = Response.FromValue(properties, rawResponse);

            shareClient.Setup(c => c.GetPropertiesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(response);
            shareClient.Setup(c => c.GetProperties(It.IsAny<CancellationToken>())).Returns(response);
        }

        [Test]
        public void DiscoverContainerNameAsync_HeaderEmpty_Throws()
        {
            Mock<ShareClient> shareClient = new Mock<ShareClient>();
            SetupMockShareWithHeader(shareClient, "");

            System.InvalidOperationException ex = Assert.ThrowsAsync<System.InvalidOperationException>(
                async () => await ContainerDiscovery.DiscoverContainerNameAsync(shareClient.Object, IsAsync, CancellationToken.None));
            StringAssert.Contains("empty", ex.Message);
        }

        [Test]
        public void DiscoverContainerNameAsync_HeaderMissingDollarPrefix_Throws()
        {
            Mock<ShareClient> shareClient = new Mock<ShareClient>();
            SetupMockShareWithHeader(shareClient, "fileschangefeed-no-prefix");

            System.InvalidOperationException ex = Assert.ThrowsAsync<System.InvalidOperationException>(
                async () => await ContainerDiscovery.DiscoverContainerNameAsync(shareClient.Object, IsAsync, CancellationToken.None));
            StringAssert.Contains("'$' prefix", ex.Message);
        }

        [Test]
        public void DiscoverContainerNameAsync_GetPropertiesThrows_PropagatesException()
        {
            // RequestFailedException from the share's GetProperties (e.g. 403, 404) should
            // surface to the caller rather than being silently swallowed or remapped.
            Mock<ShareClient> shareClient = new Mock<ShareClient>();
            shareClient.Setup(c => c.Name).Returns("myshare");

            RequestFailedException requestEx = new RequestFailedException(403, "forbidden");
            shareClient.Setup(c => c.GetPropertiesAsync(It.IsAny<CancellationToken>())).ThrowsAsync(requestEx);
            shareClient.Setup(c => c.GetProperties(It.IsAny<CancellationToken>())).Throws(requestEx);

            Assert.ThrowsAsync<RequestFailedException>(
                async () => await ContainerDiscovery.DiscoverContainerNameAsync(shareClient.Object, IsAsync, CancellationToken.None));
        }
    }
}
