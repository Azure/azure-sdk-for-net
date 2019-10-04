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
                GetBlobOptions.Metadata | GetBlobOptions.DeletedBlobs);

            AssertOptions(
                "deleted,metadata",
                GetBlobOptions.Metadata | GetBlobOptions.DeletedBlobs | GetBlobOptions.None);

            AssertOptions(
                "copy,metadata,snapshots",
                GetBlobOptions.CopyOperationStatus | GetBlobOptions.Metadata | GetBlobOptions.Snapshots);

            AssertOptions(
                "copy,deleted,metadata,snapshots,uncommittedblobs",
                GetBlobOptions.Metadata | GetBlobOptions.CopyOperationStatus | GetBlobOptions.Snapshots | GetBlobOptions.UncommittedBlobs | GetBlobOptions.DeletedBlobs);

            AssertOptions(
                "deleted,metadata,snapshots,uncommittedblobs",
                GetBlobOptions.Metadata | GetBlobOptions.Metadata | GetBlobOptions.Snapshots | GetBlobOptions.UncommittedBlobs | GetBlobOptions.DeletedBlobs);

            static void AssertOptions(string expected, GetBlobOptions options) => Assert.AreEqual(
                    expected,
                    string.Join(",", System.Linq.Enumerable.Select(options.AsIncludeItems(), item => Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(item))));
        }

    }
}
