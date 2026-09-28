// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
                maxTransferSize: null,
                includeNonFinalizedEvents: false);

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
                maxTransferSize: null,
                includeNonFinalizedEvents: false);

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await foreach (Page<ShareChangeFeedEvent> page in pageable.AsPages(continuationToken: "some-token"))
                {
                    // Should not reach here
                }
            });
        }

        [Test]
        public void GetChangesAsync_PreCanceledEnumerator_Throws()
        {
            ShareChangeFeedAsyncPageable pageable = new ShareChangeFeedAsyncPageable(
                client: null,
                maxTransferSize: null,
                includeNonFinalizedEvents: false);
            using CancellationTokenSource cancellation = new CancellationTokenSource();
            cancellation.Cancel();

            Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await using IAsyncEnumerator<ShareChangeFeedEvent> enumerator =
                    pageable.GetAsyncEnumerator(cancellation.Token);
                await enumerator.MoveNextAsync();
            });
        }

        [Test]
        public void AsyncAsPages_PreCanceledEnumerator_Throws()
        {
            ShareChangeFeedAsyncPageable pageable = new ShareChangeFeedAsyncPageable(
                client: null,
                maxTransferSize: null,
                includeNonFinalizedEvents: false);
            using CancellationTokenSource cancellation = new CancellationTokenSource();
            cancellation.Cancel();

            Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await foreach (Page<ShareChangeFeedEvent> _ in pageable
                    .AsPages()
                    .WithCancellation(cancellation.Token))
                {
                }
            });
        }
    }
}
