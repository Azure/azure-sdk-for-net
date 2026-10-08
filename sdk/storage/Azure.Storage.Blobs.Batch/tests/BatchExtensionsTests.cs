// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Batch.Models;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Batch.Tests
{
    public class BatchExtensionsTests
    {
        #region ToBatchAccessTier
        [Test]
        public void ToBatchAccessTier_Hot()
        {
            BatchAccessTier result = AccessTier.Hot.ToBatchAccessTier();
            Assert.AreEqual("Hot", result.ToString());
        }

        [Test]
        public void ToBatchAccessTier_Cool()
        {
            BatchAccessTier result = AccessTier.Cool.ToBatchAccessTier();
            Assert.AreEqual("Cool", result.ToString());
        }

        [Test]
        public void ToBatchAccessTier_Archive()
        {
            BatchAccessTier result = AccessTier.Archive.ToBatchAccessTier();
            Assert.AreEqual("Archive", result.ToString());
        }
        #endregion

        #region ToBatchRehydratePriority
        [Test]
        public void ToBatchRehydratePriority_Null_ReturnsNull()
        {
            RehydratePriority? priority = null;
            BatchRehydratePriority? result = priority.ToBatchRehydratePriority();
            Assert.IsNull(result);
        }

        [Test]
        public void ToBatchRehydratePriority_High()
        {
            RehydratePriority? priority = RehydratePriority.High;
            BatchRehydratePriority? result = priority.ToBatchRehydratePriority();
            Assert.IsNotNull(result);
            Assert.AreEqual("High", result.ToString());
        }

        [Test]
        public void ToBatchRehydratePriority_Standard()
        {
            RehydratePriority? priority = RehydratePriority.Standard;
            BatchRehydratePriority? result = priority.ToBatchRehydratePriority();
            Assert.IsNotNull(result);
            Assert.AreEqual("Standard", result.ToString());
        }
        #endregion

        #region ToDeleteSnapshotsOptionType
        [Test]
        public void ToDeleteSnapshotsOptionType_None_ReturnsNull()
        {
            DeleteSnapshotsOptionType? result = DeleteSnapshotsOption.None.ToDeleteSnapshotsOptionType();
            Assert.IsNull(result);
        }

        [Test]
        public void ToDeleteSnapshotsOptionType_IncludeSnapshots()
        {
            DeleteSnapshotsOptionType? result = DeleteSnapshotsOption.IncludeSnapshots.ToDeleteSnapshotsOptionType();
            Assert.AreEqual(DeleteSnapshotsOptionType.Include, result);
        }

        [Test]
        public void ToDeleteSnapshotsOptionType_OnlySnapshots()
        {
            DeleteSnapshotsOptionType? result = DeleteSnapshotsOption.OnlySnapshots.ToDeleteSnapshotsOptionType();
            Assert.AreEqual(DeleteSnapshotsOptionType.Only, result);
        }

        [Test]
        public void ToDeleteSnapshotsOptionType_Unknown_Throws()
        {
            Assert.Throws<ArgumentException>(() => ((DeleteSnapshotsOption)999).ToDeleteSnapshotsOptionType());
        }
        #endregion
    }
}
