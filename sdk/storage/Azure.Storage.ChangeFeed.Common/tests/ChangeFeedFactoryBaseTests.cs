// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.ChangeFeed.Common.Tests
{
    /// <summary>
    /// Tests for <see cref="ChangeFeedFactoryBase{TEvent}"/> covering container validation,
    /// cursor checks, and year path discovery.
    /// </summary>
    public class ChangeFeedFactoryBaseTests : ChangeFeedCommonTestBase
    {
        public ChangeFeedFactoryBaseTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies that BuildChangeFeed throws when the change feed container does not exist.
        /// </summary>
        [Test]
        public void ChangeFeedNotEnabled_Throws()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);

            // Container does not exist
            if (IsAsync)
                containerClient.Setup(r => r.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(false, null));
            else
                containerClient.Setup(r => r.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(false, null));

            ChangeFeedFactoryBase<TestEvent> factory = new ChangeFeedFactoryBase<TestEvent>(
                containerClient.Object,
                new Mock<SegmentFactoryBase<TestEvent>>().Object,
                CreateTestConfig());

            Assert.ThrowsAsync<ArgumentException>(
                async () => await factory.BuildChangeFeed(null, null, null, IsAsync, CancellationToken.None));
        }

        /// <summary>
        /// Verifies that cursor validation rejects a cursor whose UrlHost doesn't match the container.
        /// </summary>
        [Test]
        public void ValidateCursor_HostMismatch_Throws()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            containerClient.Setup(r => r.Uri).Returns(new Uri("https://account1.blob.core.windows.net/container"));

            if (IsAsync)
                containerClient.Setup(r => r.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
            else
                containerClient.Setup(r => r.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(true, null));

            // Build a continuation token with a different host
            ChangeFeedCursor cursor = new ChangeFeedCursor("account2.blob.core.windows.net", null,
                new SegmentCursor("idx/segments/2024/01/15/0800/meta.json", new List<ShardCursor>(), null));
            string continuation = System.Text.Json.JsonSerializer.Serialize(cursor);

            ChangeFeedFactoryBase<TestEvent> factory = new ChangeFeedFactoryBase<TestEvent>(
                containerClient.Object,
                new Mock<SegmentFactoryBase<TestEvent>>().Object,
                CreateTestConfig());

            Assert.ThrowsAsync<ArgumentException>(
                async () => await factory.BuildChangeFeed(null, null, continuation, IsAsync, CancellationToken.None));
        }

        /// <summary>
        /// Verifies that cursor validation rejects an unsupported cursor version.
        /// </summary>
        [Test]
        public void ValidateCursor_UnsupportedVersion_Throws()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            containerClient.Setup(r => r.Uri).Returns(new Uri("https://account.blob.core.windows.net/container"));

            if (IsAsync)
                containerClient.Setup(r => r.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
            else
                containerClient.Setup(r => r.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(true, null));

            ChangeFeedCursor cursor = new ChangeFeedCursor("account.blob.core.windows.net", null,
                new SegmentCursor("idx/segments/2024/01/15/0800/meta.json", new List<ShardCursor>(), null))
            {
                CursorVersion = 99  // Unsupported version
            };
            string continuation = System.Text.Json.JsonSerializer.Serialize(cursor);

            ChangeFeedFactoryBase<TestEvent> factory = new ChangeFeedFactoryBase<TestEvent>(
                containerClient.Object,
                new Mock<SegmentFactoryBase<TestEvent>>().Object,
                CreateTestConfig());

            Assert.ThrowsAsync<ArgumentException>(
                async () => await factory.BuildChangeFeed(null, null, continuation, IsAsync, CancellationToken.None));
        }
    }
}
