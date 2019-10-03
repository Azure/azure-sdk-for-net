// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common.Tests.Shared;
using Microsoft.CodeAnalysis;
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
            GetBlobOptions options = GetBlobOptions.Metadata | GetBlobOptions.DeletedBlobs;
            Assert.AreEqual(
                "deleted,metadata",
                string.Join(",", System.Linq.Enumerable.Select(options.AsIncludeItems(), item => Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(item))));

            options = GetBlobOptions.Metadata | GetBlobOptions.DeletedBlobs | GetBlobOptions.None;
            Assert.AreEqual(
                "deleted,metadata",
                string.Join(",", System.Linq.Enumerable.Select(options.AsIncludeItems(), item => Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(item))));

            options = GetBlobOptions.CopyOperationStatus | GetBlobOptions.Metadata | GetBlobOptions.Snapshots;
            Assert.AreEqual(
                "copy,metadata,snapshots",
                string.Join(",", System.Linq.Enumerable.Select(options.AsIncludeItems(), item => Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(item))));

            options = GetBlobOptions.Metadata | GetBlobOptions.CopyOperationStatus | GetBlobOptions.Snapshots | GetBlobOptions.UncommittedBlobs | GetBlobOptions.DeletedBlobs;
            Assert.AreEqual(
                "copy,deleted,metadata,snapshots,uncommittedblobs",
                string.Join(",", System.Linq.Enumerable.Select(options.AsIncludeItems(), item => Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(item))));

            options = GetBlobOptions.Metadata | GetBlobOptions.Metadata | GetBlobOptions.Snapshots | GetBlobOptions.UncommittedBlobs | GetBlobOptions.DeletedBlobs;
            Assert.AreEqual(
                "deleted,metadata,snapshots,uncommittedblobs",
                string.Join(",", System.Linq.Enumerable.Select(options.AsIncludeItems(), item => Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(item))));
        }
    }
}
