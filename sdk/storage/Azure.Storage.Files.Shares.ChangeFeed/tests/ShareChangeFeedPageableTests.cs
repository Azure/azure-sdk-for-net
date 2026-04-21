// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Files.Shares;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// Tests for <see cref="ShareChangeFeedPageable"/> and <see cref="ShareChangeFeedAsyncPageable"/>,
    /// verifying that continuation tokens passed to AsPages() are correctly rejected.
    /// </summary>
    public class ShareChangeFeedPageableTests : ShareChangeFeedTestBase
    {
        public ShareChangeFeedPageableTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies that passing a continuation token to the sync pageable's AsPages() throws ArgumentException.
        /// </summary>
        [Test]
        public void AsPages_NonNullContinuationToken_Throws()
        {
            ShareChangeFeedPageable pageable = new ShareChangeFeedPageable(
                client: null,
                maxTransferSize: null);

            Assert.Throws<ArgumentException>(() =>
            {
                foreach (Page<ShareChangeFeedEvent> page in pageable.AsPages(continuationToken: "some-token"))
                {
                    // Should not reach here
                }
            });
        }

        /// <summary>
        /// Verifies that passing a continuation token to the async pageable's AsPages() throws ArgumentException.
        /// </summary>
        [Test]
        public void AsyncAsPages_NonNullContinuationToken_Throws()
        {
            ShareChangeFeedAsyncPageable pageable = new ShareChangeFeedAsyncPageable(
                client: null,
                maxTransferSize: null);

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await foreach (Page<ShareChangeFeedEvent> page in pageable.AsPages(continuationToken: "some-token"))
                {
                    // Should not reach here
                }
            });
        }
    }
}
