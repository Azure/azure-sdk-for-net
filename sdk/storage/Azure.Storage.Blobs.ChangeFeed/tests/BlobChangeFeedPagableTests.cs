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
    }
}
