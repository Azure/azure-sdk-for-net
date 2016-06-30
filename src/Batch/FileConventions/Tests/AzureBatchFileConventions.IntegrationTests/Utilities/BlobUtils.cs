using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities
{
    internal static class BlobUtils
    {
        internal static async Task<byte[]> ReadAsByteArrayAsync(this OutputFileReference blob, int maxSize = 16 * 1024 /* more than enough for our test files */)
        {
            var buffer = new byte[maxSize];
            var byteCount = await blob.DownloadToByteArrayAsync(buffer, 0);

            var blobContent = new byte[byteCount];
            Array.Copy(buffer, blobContent, byteCount);
            return blobContent;
        }
    }
}
