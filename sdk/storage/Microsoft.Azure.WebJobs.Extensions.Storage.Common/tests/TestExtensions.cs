// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public static class TestExtensions
    {
        public static async Task UploadTextAsync(this BlockBlobClient blockBlobClient, string text, CancellationToken cancellationToken = default)
        {
            using Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
            await blockBlobClient.UploadAsync(stream, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public static async Task UploadTextAsync(this AppendBlobClient appendBlobClient, string text, CancellationToken cancellationToken = default)
        {
            using Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
            await appendBlobClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
            await appendBlobClient.AppendBlockAsync(stream, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public static async Task UploadFromByteArrayAsync(this PageBlobClient pageBlobClient, byte[] bytes, int offset)
        {
            await pageBlobClient.CreateIfNotExistsAsync(512);
            await pageBlobClient.UploadPagesAsync(new MemoryStream(bytes), offset);
        }

        public static async Task<string> DownloadTextAsync(this BlobBaseClient blobClient, CancellationToken cancellationToken = default)
        {
            using BlobDownloadInfo blobDownloadInfo = await blobClient.DownloadAsync(cancellationToken).ConfigureAwait(false);
            using Stream stream = blobDownloadInfo.Content;
            using StreamReader streamReader = new StreamReader(stream);
            return await streamReader.ReadToEndAsync().ConfigureAwait(false);
        }
    }
}
