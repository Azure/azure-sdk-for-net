// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    // $$$ // TODO (kasobol-msft) get rid of this
    public static class TestExtensions
    {
        public static T SetInternalProperty<T>(this T instance, string name, object value)
        {
            var t = instance.GetType();

            var prop = t.GetProperty(name,
              BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            // Reflection has a quirk.  While a property is inherited, the setter may not be.
            // Need to request the property on the type it was declared.
            while (!prop.CanWrite)
            {
                t = t.BaseType;
                prop = t.GetProperty(name,
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            }

            prop.SetValue(instance, value);
            return instance;
        }

        public static async Task UploadEmptyPageAsync(this PageBlobClient pageBlobClient, CancellationToken cancellationToken = default)
        {
            await pageBlobClient.UploadPagesAsync(new MemoryStream(), 0, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public static async Task UploadTextAsync(this BlockBlobClient blockBlobClient, string text, CancellationToken cancellationToken = default)
        {
            using Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
            await blockBlobClient.UploadAsync(stream, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public static async Task UploadTextAsync(this AppendBlobClient appendBlobClient, string text, CancellationToken cancellationToken = default)
        {
            using Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
            await appendBlobClient.AppendBlockAsync(stream, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public static async Task UploadFromByteArrayAsync(this PageBlobClient pageBlobClient, byte[] bytes, int offset)
        {
            await pageBlobClient.UploadPagesAsync(new MemoryStream(bytes), offset);
        }

        public static async Task<string> DownloadTextAsync(this BlobBaseClient blobClient, CancellationToken cancellationToken = default)
        {
            using BlobDownloadInfo blobDownloadInfo = await blobClient.DownloadAsync(cancellationToken).ConfigureAwait(false);
            using Stream stream = blobDownloadInfo.Content;
            using StreamReader streamReader = new StreamReader(stream);
            return await streamReader.ReadToEndAsync().ConfigureAwait(false);
        }

        public static string DownloadText(this BlobBaseClient blobClient, CancellationToken cancellationToken = default)
        {
            using BlobDownloadInfo blobDownloadInfo = blobClient.Download(cancellationToken);
            using Stream stream = blobDownloadInfo.Content;
            using StreamReader streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }
    }
}
