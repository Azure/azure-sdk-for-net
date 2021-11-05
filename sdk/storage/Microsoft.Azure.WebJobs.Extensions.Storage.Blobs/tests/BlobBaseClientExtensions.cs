// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Models;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal static class BlobBaseClientExtensions
    {
        public static string DownloadText(this BlobBaseClient blobClient, CancellationToken cancellationToken = default)
        {
            using BlobDownloadInfo blobDownloadInfo = blobClient.Download(cancellationToken);
            using Stream stream = blobDownloadInfo.Content;
            using StreamReader streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }
    }
}
