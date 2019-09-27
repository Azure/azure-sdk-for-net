// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Common.Tests.Shared;
using Azure.Storage.Files.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.Tests
{
    public class UnitTests
    {
        [Test]
        public void StorageFileDownloadInfo_Dispose()
        {
            MockStream stream = new MockStream();
            StorageFileDownloadInfo storageFileDownloadInfo =
                FilesModelFactory.StorageFileDownloadInfo(content: stream);
            Assert.IsFalse(stream.IsDisposed);
            storageFileDownloadInfo.Dispose();
            Assert.IsTrue(stream.IsDisposed);
        }
    }
}
