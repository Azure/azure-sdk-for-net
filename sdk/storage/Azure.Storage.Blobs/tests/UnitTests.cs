// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class UnitTests
    {
        [Test]
        public void BlobDownloadInfo_Dispose()
        {
            MockStream stream = new MockStream();
            BlobDownloadInfo blobDownloadInfo = BlobsModelFactory.BlobDownloadInfo(content: stream);
            Assert.IsFalse(stream.IsDisposed);
            blobDownloadInfo.Dispose();
            Assert.IsTrue(stream.IsDisposed);
        }

        // TODO fix this.
        //[Test]
        //public void GetBlobOptions_VariousFlagCombos()
        //{
        //    AssertOptions(
        //        "deleted,metadata",
        //        BlobTraits.Metadata,
        //        BlobStates.Deleted);

        //    AssertOptions(
        //        "deleted,metadata",
        //        BlobTraits.Metadata,
        //        BlobStates.Deleted | BlobStates.None);

        //    AssertOptions(
        //        "copy,metadata,snapshots",
        //        BlobTraits.CopyStatus | BlobTraits.Metadata,
        //        BlobStates.Snapshots);

        //    AssertOptions(
        //        "copy,deleted,metadata,snapshots,uncommittedblobs",
        //        BlobTraits.Metadata | BlobTraits.CopyStatus,
        //        BlobStates.Snapshots | BlobStates.Uncommitted | BlobStates.Deleted);

        //    AssertOptions(
        //        "deleted,metadata,snapshots,uncommittedblobs",
        //        BlobTraits.Metadata | BlobTraits.Metadata,
        //        BlobStates.Snapshots | BlobStates.Uncommitted | BlobStates.Deleted);

        //    static void AssertOptions(string expected, BlobTraits traits, BlobStates states) => Assert.AreEqual(
        //            expected,
        //            string.Join(",", System.Linq.Enumerable.Select(BlobExtensions.AsIncludeItems(traits, states), item => Azure.Storage.Blobs.Models BlobRestClient.Serialization.ToString(item))));
        //}
    }
}
