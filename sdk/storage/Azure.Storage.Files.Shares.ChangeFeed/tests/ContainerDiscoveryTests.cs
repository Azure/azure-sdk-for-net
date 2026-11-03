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
    /// via <see cref="ShareProperties"/>.
    /// </summary>
    public class ContainerDiscoveryTests : ShareChangeFeedTestBase
    {
        public ContainerDiscoveryTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies that DiscoverContainerNameAsync returns the container name when the
        /// change feed properties indicate that change feed is enabled.
        /// </summary>
        [Test]
        public async Task DiscoverContainerNameAsync_ChangeFeedEnabled_ReturnsContainerName()
        {
            // Arrange
            Mock<ShareClient> shareClient = new Mock<ShareClient>();
            shareClient.Setup(c => c.Name).Returns("myshare");

            MockResponse rawResponse = new MockResponse(200);
            ShareProperties properties = ShareModelFactory.ShareProperties(
                enableChangeFeed: true,
                changeFeedBlobContainerName: "$fileschangefeed-abc123");
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
        /// when change feed is disabled.
        /// </summary>
        [Test]
        public void DiscoverContainerNameAsync_ChangeFeedDisabled_ThrowsInvalidOperationException()
        {
            // Arrange
            Mock<ShareClient> shareClient = new Mock<ShareClient>();
            shareClient.Setup(c => c.Name).Returns("myshare");

            MockResponse rawResponse = new MockResponse(200);
            ShareProperties properties = ShareModelFactory.ShareProperties(
                enableChangeFeed: false,
                changeFeedBlobContainerName: "$fileschangefeed-abc123");
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

        private void SetupMockShareWithProperties(Mock<ShareClient> shareClient, string containerName)
        {
            shareClient.Setup(c => c.Name).Returns("myshare");
            MockResponse rawResponse = new MockResponse(200);
            ShareProperties properties = ShareModelFactory.ShareProperties(
                enableChangeFeed: true,
                changeFeedBlobContainerName: containerName);
            Response<ShareProperties> response = Response.FromValue(properties, rawResponse);

            shareClient.Setup(c => c.GetPropertiesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(response);
            shareClient.Setup(c => c.GetProperties(It.IsAny<CancellationToken>())).Returns(response);
        }

        [Test]
        public void DiscoverContainerNameAsync_HeaderEmpty_Throws()
        {
            Mock<ShareClient> shareClient = new Mock<ShareClient>();
            SetupMockShareWithProperties(shareClient, "");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await ContainerDiscovery.DiscoverContainerNameAsync(shareClient.Object, IsAsync, CancellationToken.None));
            StringAssert.Contains("empty", ex.InnerException.Message);
        }

        [Test]
        public void DiscoverContainerNameAsync_HeaderMissingDollarPrefix_Throws()
        {
            Mock<ShareClient> shareClient = new Mock<ShareClient>();
            SetupMockShareWithProperties(shareClient, "fileschangefeed-no-prefix");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await ContainerDiscovery.DiscoverContainerNameAsync(shareClient.Object, IsAsync, CancellationToken.None));
            StringAssert.Contains("'$' prefix", ex.InnerException.Message);
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
