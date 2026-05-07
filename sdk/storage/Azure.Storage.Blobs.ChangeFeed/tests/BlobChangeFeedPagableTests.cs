// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class BlobChangeFeedPagableTests : ChangeFeedTestBase
    {
        public BlobChangeFeedPagableTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Tests retrieving all change feed events using the synchronous API.
        /// </summary>
        [RecordedTest]
        [Ignore("For debugging larger Change Feeds locally")]
        public void Test()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient blobChangeFeedClient = service.GetChangeFeedClient();
            Pageable<BlobChangeFeedEvent> blobChangeFeedPagable
                = blobChangeFeedClient.GetChanges();
            IList<BlobChangeFeedEvent> list = blobChangeFeedPagable.ToList();
            foreach (BlobChangeFeedEvent e in list)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Verifies that calling <see cref="Pageable{T}.AsPages"/> with a non-null continuation
        /// token throws — callers must use <see cref="BlobChangeFeedClient.GetChanges(string)"/>
        /// instead. This is the documented contract; the pageable cannot validate the token.
        /// </summary>
        [Test]
        public void AsPages_NonNullContinuationToken_Throws()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(
                new Uri("https://account.blob.core.windows.net?sv=2024-01-01&ss=b&srt=sco&sig=fakesig"));
            Pageable<BlobChangeFeedEvent> pageable = client.GetChanges();

            Assert.Throws<ArgumentException>(() =>
            {
                foreach (Page<BlobChangeFeedEvent> _ in pageable.AsPages(continuationToken: "any-token")) { }
            });
        }
    }
}
