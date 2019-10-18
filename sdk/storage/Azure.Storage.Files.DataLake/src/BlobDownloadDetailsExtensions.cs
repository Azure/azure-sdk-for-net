// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal static class BlobDownloadDetailsExtensions
    {
        internal static FileDownloadDetails ToFileDownloadDetails(this BlobDownloadDetails blobDownloadProperties) =>
            new FileDownloadDetails()
            {
                LastModified = blobDownloadProperties.LastModified,
                Metadata = blobDownloadProperties.Metadata,
                ContentRange = blobDownloadProperties.ContentRange,
                ETag = blobDownloadProperties.ETag,
                ContentEncoding = blobDownloadProperties.ContentEncoding,
                ContentDisposition = blobDownloadProperties.ContentDisposition,
                ContentLanguage = blobDownloadProperties.ContentLanguage,
                CopyCompletedOn = blobDownloadProperties.CopyCompletedOn,
                CopyStatusDescription = blobDownloadProperties.CopyStatusDescription,
                CopyId = blobDownloadProperties.CopyId,
                CopyProgress = blobDownloadProperties.CopyProgress,
                CopyStatus = (Models.CopyStatus)blobDownloadProperties.CopyStatus,
                LeaseDuration = (Models.LeaseDurationType)blobDownloadProperties.LeaseDuration,
                LeaseState = (Models.LeaseState)blobDownloadProperties.LeaseState,
                LeaseStatus = (Models.LeaseStatus)blobDownloadProperties.LeaseStatus,
                AcceptRanges = blobDownloadProperties.AcceptRanges,
                IsServerEncrypted = blobDownloadProperties.IsServerEncrypted,
                EncryptionKeySha256 = blobDownloadProperties.EncryptionKeySha256,
                ContentHash = blobDownloadProperties.BlobContentHash
            };
    }
}
