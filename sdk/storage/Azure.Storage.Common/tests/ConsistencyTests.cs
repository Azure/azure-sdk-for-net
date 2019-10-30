// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;
using Azure.Storage.Queues;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Test
{
    [TestFixture]
    public class ConsistencyTests
    {
        [Test]
        public void ServiceVersions()
        {
            var blobs = Enum.GetNames(typeof(BlobClientOptions.ServiceVersion));
            var queues = Enum.GetNames(typeof(QueueClientOptions.ServiceVersion));
            var files = Enum.GetNames(typeof(ShareClientOptions.ServiceVersion));

            TestHelper.AssertSequenceEqual(blobs, queues);
            TestHelper.AssertSequenceEqual(blobs, files);
        }
    }
}
