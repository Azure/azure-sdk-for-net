// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs.Stress.Scenarios
{
    public class BlockBlobTests
    {
        [Test]
        public void UploadDownloadBlockBlob()
        {
            var blobName = "testblob";
            var blobSize = 1024 * 1024 * 1024;
            var blockSize = 4 * 1024 * 1024;
            var blockCount = blobSize / blockSize;

            var sourceStream = new MemoryStream(blobSize);
            var random = new Random();
            var buffer = new byte[blockSize];
            random.NextBytes(buffer);
            for (int i = 0; i < blockCount; i++)
            {
                sourceStream.Write(buffer, 0, blockSize);
            }
            sourceStream.Seek(0, SeekOrigin.Begin);

            var blobClient = new BlobClient("connectionString", "containerName", blobName);
            var blockBlobClient = new BlockBlobClient(blobClient);

            var downloadOptions = new DownloadOptions
            {
                TransferOptions = new TransferOptions
                {
                    MaximumConcurrency = 8,
                    MaximumTransferLength = 4 * 1024 * 1024,
                    MaximumTransferSize = 4 * 1024 * 1024,
                },
            };

            var uploadTask = blockBlobClient.UploadAsync(sourceStream, uploadOptions);
            uploadTask.Wait();

            var targetStream = new MemoryStream(blobSize);
            var downloadTask = blockBlobClient.DownloadAsync(targetStream, downloadOptions);
            downloadTask.Wait();

            Assert.AreEqual(sourceStream.Length, targetStream.Length);
            Assert.IsTrue(sourceStream.ToArray().SequenceEqual(targetStream.ToArray()));
        }
    }
}
