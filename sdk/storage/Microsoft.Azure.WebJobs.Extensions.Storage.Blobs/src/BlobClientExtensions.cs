// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal static class BlobClientExtensions
    {
        public static async Task<string> DownloadTextAsync(this BlobBaseClient blobClient, CancellationToken cancellationToken = default)
        {
            using BlobDownloadInfo blobDownloadInfo = await blobClient.DownloadAsync(cancellationToken).ConfigureAwait(false);
            using Stream stream = blobDownloadInfo.Content;
            using StreamReader streamReader = new StreamReader(stream);
            return await streamReader.ReadToEndAsync().ConfigureAwait(false);
        }

        public static async Task UploadTextAsync(this BlockBlobClient blockBlobClient, string text, CancellationToken cancellationToken = default)
        {
            using Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
            await blockBlobClient.UploadAsync(stream, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        // Naming rules are here: http://msdn.microsoft.com/en-us/library/dd135715.aspx
        // Validate this on the client side so that we can get a user-friendly error rather than a 400.
        // See code here: http://social.msdn.microsoft.com/Forums/en-GB/windowsazuredata/thread/d364761b-6d9d-4c15-8353-46c6719a3392
        public static void ValidateContainerName(string containerName)
        {
            if (containerName == null)
            {
                throw new ArgumentNullException(nameof(containerName));
            }

            if (!IsValidContainerName(containerName))
            {
                throw new FormatException("Invalid container name: " + containerName);
            }
        }

        public static bool IsValidContainerName(string containerName)
        {
            return BlobNameValidationAttribute.IsValidContainerName(containerName);
        }

        public static void ValidateBlobName(string blobName)
        {
            string errorMessage;

            if (!IsValidBlobName(blobName, out errorMessage))
            {
                throw new FormatException(errorMessage);
            }
        }

        // See http://msdn.microsoft.com/en-us/library/windowsazure/dd135715.aspx.
        public static bool IsValidBlobName(string blobName, out string errorMessage)
        {
            return BlobNameValidationAttribute.IsValidBlobName(blobName, out errorMessage);
        }
    }
}
