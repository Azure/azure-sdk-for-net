// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Files.Shares;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// Tests for <see cref="SnapshotQueryHelper"/> which converts ISO 8601 snapshot timestamps
    /// into hierarchical blob paths used to locate snapshot metadata.
    /// </summary>
    public class SnapshotQueryHelperTests : ShareChangeFeedTestBase
    {
        public SnapshotQueryHelperTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies that a standard UTC timestamp on the hour is converted to the expected hierarchical path.
        /// </summary>
        [Test]
        public void SnapshotTimestampToPath()
        {
            string path = SnapshotQueryHelper.SnapshotTimestampToPath("2023-07-18T08:00:00.000Z");
            Assert.AreEqual("idx/snapshots/2023/07/18/08/00/00/meta.json", path);
        }

        /// <summary>
        /// Verifies that a timestamp with non-zero seconds preserves the seconds component in the path.
        /// </summary>
        [Test]
        public void SnapshotTimestampToPath_WithSeconds()
        {
            string path = SnapshotQueryHelper.SnapshotTimestampToPath("2024-01-15T14:30:45.000Z");
            Assert.AreEqual("idx/snapshots/2024/01/15/14/30/45/meta.json", path);
        }

        /// <summary>
        /// Verifies that a midnight timestamp produces zero-padded hour, minute, and second path segments.
        /// </summary>
        [Test]
        public void SnapshotTimestampToPath_Midnight()
        {
            string path = SnapshotQueryHelper.SnapshotTimestampToPath("2024-06-01T00:00:00.000Z");
            Assert.AreEqual("idx/snapshots/2024/06/01/00/00/00/meta.json", path);
        }
    }
}
