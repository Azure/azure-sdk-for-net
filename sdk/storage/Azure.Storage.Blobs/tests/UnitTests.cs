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
    }
}
