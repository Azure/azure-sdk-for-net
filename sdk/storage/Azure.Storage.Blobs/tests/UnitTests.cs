// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Azure.Storage.Common.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
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

        [Test]
        public void GetBlobOptions_VariousFlagCombos()
        {
            AssertOptions(
                "deleted,metadata",
                BlobTraits.Metadata,
                BlobStates.DeletedBlobs);

            AssertOptions(
                "deleted,metadata",
                BlobTraits.Metadata,
                BlobStates.DeletedBlobs | BlobStates.None);

            AssertOptions(
                "copy,metadata,snapshots",
                BlobTraits.CopyOperationStatus | BlobTraits.Metadata,
                BlobStates.Snapshots);

            AssertOptions(
                "copy,deleted,metadata,snapshots,uncommittedblobs",
                BlobTraits.Metadata | BlobTraits.CopyOperationStatus,
                BlobStates.Snapshots | BlobStates.UncommittedBlobs | BlobStates.DeletedBlobs);

            AssertOptions(
                "deleted,metadata,snapshots,uncommittedblobs",
                BlobTraits.Metadata | BlobTraits.Metadata,
                BlobStates.Snapshots | BlobStates.UncommittedBlobs | BlobStates.DeletedBlobs);

            static void AssertOptions(string expected, BlobTraits traits, BlobStates states) => Assert.AreEqual(
                    expected,
                    string.Join(",", System.Linq.Enumerable.Select(BlobExtensions.AsIncludeItems(traits, states), item => Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(item))));
        }
    }
}
