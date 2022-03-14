// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.DataMovement.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    internal static partial class DataMovementBlobsExtensions
    {
        internal static BlobTransferJobProperties ToBlobTransferJobDetails(this BlobUploadTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferJobProperties()
            {
                JobId = transferJob.JobId,
                TransferType = BlobTransferType.SingleUpload,
                SourcePath = new Uri(transferJob.SourceLocalPath),
                DestinationUri = transferJob.DestinationBlobClient.Uri,
            };
        }

        internal static BlobTransferJobProperties ToBlobTransferJobDetails(this BlobUploadDirectoryTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferJobProperties()
            {
                JobId = transferJob.JobId,
                TransferType = BlobTransferType.DirectoryUpload,
                SourcePath = new Uri(transferJob.SourceLocalPath),
                DestinationUri = transferJob.DestinationBlobDirectoryClient.Uri,
            };
        }

        internal static BlobTransferJobProperties ToBlobTransferJobDetails(this BlobDownloadTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferJobProperties()
            {
                JobId = transferJob.JobId,
                TransferType = BlobTransferType.SingleDownload,
                SourcePath = transferJob.SourceBlobClient.Uri,
                DestinationUri = new Uri(transferJob.DestinationLocalPath),
            };
        }

        internal static BlobTransferJobProperties ToBlobTransferJobDetails(this BlobDownloadDirectoryTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferJobProperties()
            {
                JobId = transferJob.JobId,
                TransferType = BlobTransferType.DirectoryDownload,
                SourcePath = transferJob.SourceBlobDirectoryClient.Uri,
                DestinationUri = new Uri(transferJob.DestinationLocalPath),
            };
        }

        internal static BlobTransferJobProperties ToBlobTransferJobDetails(this BlobServiceCopyTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferJobProperties()
            {
                JobId = transferJob.JobId,
                TransferType = BlobTransferType.SingleSyncCopy,
                SourcePath = transferJob.SourceUri,
                DestinationUri = transferJob.DestinationBlobClient.Uri,
            };
        }

        internal static BlobTransferJobProperties ToBlobTransferJobDetails(this BlobServiceCopyDirectoryTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferJobProperties()
            {
                JobId = transferJob.JobId,
                TransferType = BlobTransferType.DirectorySyncCopy,
                SourcePath = transferJob.SourceBlobDirectoryClient.Uri,
                DestinationUri = transferJob.DestinationBlobDirectoryClient.Uri,
            };
        }
    }
}
