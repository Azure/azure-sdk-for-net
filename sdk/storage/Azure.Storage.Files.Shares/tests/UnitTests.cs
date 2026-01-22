// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class UnitTests
    {
        [Test]
        public void StorageFileDownloadInfo_Dispose()
        {
            MockStream stream = new MockStream();
            ShareFileDownloadInfo storageFileDownloadInfo =
                FilesModelFactory.StorageFileDownloadInfo(content: stream);
            Assert.That(stream.IsDisposed, Is.False);
            storageFileDownloadInfo.Dispose();
            Assert.That(stream.IsDisposed, Is.True);
        }
    }
}
