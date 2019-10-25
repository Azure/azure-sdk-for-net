// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal static class BlobDownloadInfoExtensions
    {
        internal static FileDownloadInfo ToFileDownloadInfo(this BlobDownloadInfo blobDownloadInfo) =>
            new FileDownloadInfo()
            {
                ContentLength = blobDownloadInfo.ContentLength,
                Content = blobDownloadInfo.Content,
                ContentHash = blobDownloadInfo.ContentHash,
                Properties = blobDownloadInfo.Details.ToFileDownloadDetails()
            };
    }
}
