// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    public class SnapshotQueryHelperTests : ShareChangeFeedTestBase
    {
        public SnapshotQueryHelperTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        [Test]
        public void SnapshotTimestampToPath()
        {
            string path = SnapshotQueryHelper.SnapshotTimestampToPath("2023-07-18T08:00:00.000Z");
            Assert.AreEqual("idx/snapshots/2023/07/18/08/00/00/meta.json", path);
        }

        [Test]
        public void SnapshotTimestampToPath_WithSeconds()
        {
            string path = SnapshotQueryHelper.SnapshotTimestampToPath("2024-01-15T14:30:45.000Z");
            Assert.AreEqual("idx/snapshots/2024/01/15/14/30/45/meta.json", path);
        }

        [Test]
        public void SnapshotTimestampToPath_Midnight()
        {
            string path = SnapshotQueryHelper.SnapshotTimestampToPath("2024-06-01T00:00:00.000Z");
            Assert.AreEqual("idx/snapshots/2024/06/01/00/00/00/meta.json", path);
        }
    }
}
