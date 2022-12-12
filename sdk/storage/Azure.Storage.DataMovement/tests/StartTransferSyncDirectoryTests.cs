// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferSyncDirectoryTests : DataMovementBlobTestBase
    {
        public StartTransferSyncDirectoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        /// <summary>
        /// Creates a block blob.
        /// </summary>
        /// <param name="containerClient">The parent container which the blob will be uploaded to</param>
        /// <param name="sourceDirectoryPath">Source Directory name. The source path will be appended to this to create the full path name</param>
        /// <param name="sourceFilePath">The blob name (full path to the blob) and the source file path</param>
        /// <param name="size">Size of the blob</param>
        /// <returns>The local source file path which contains the contents of the source blob.</returns>
        internal async Task CreateBlockBlobAndSourceFile(
            BlobContainerClient containerClient,
            string sourceDirectoryPath,
            string sourceBlobDirectory,
            string sourceFilePath,
            int size)
        {
            var data = GetRandomBuffer(size);
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            string blobName = Path.Combine(sourceBlobDirectory, sourceFilePath);
            BlobClient originalBlob = InstrumentClient(containerClient.GetBlobClient(blobName));
            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            using (FileStream fileStream = File.Create($"{sourceDirectoryPath}\\{sourceFilePath}"))
            {
                // Copy source to a file, so we can verify the source against downloaded blob later
                await originalStream.CopyToAsync(fileStream);
                // Upload blob to storage account
                originalStream.Position = 0;
                await originalBlob.UploadAsync(originalStream);
            }
        }
    }
}
