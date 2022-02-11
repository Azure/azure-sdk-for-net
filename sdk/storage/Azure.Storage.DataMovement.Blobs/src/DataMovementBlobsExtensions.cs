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
                TransferType = StorageTransferType.SingleUpload,
                Status = StorageJobTransferStatus.Completed, //TODO = update with actual job status
                SourceLocalPath = transferJob.SourceLocalPath,
                DestinationBlobClient = transferJob.DestinationBlobClient,
                SingleUploadOptions = transferJob.UploadOptions,
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
                TransferType = StorageTransferType.DirectoryUpload,
                Status = StorageJobTransferStatus.Completed, //TODO = update with actual job status
                SourceLocalPath = transferJob.SourceLocalPath,
                DestinationBlobDirectoryClient = transferJob.DestinationBlobDirectoryClient,
                DirectoryUploadOptions = transferJob.UploadOptions,
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
                TransferType = StorageTransferType.SingleDownload,
                Status = StorageJobTransferStatus.Completed, //TODO = update with actual job status
                SourceBlobClient = transferJob.SourceBlobClient,
                DestinationLocalPath = transferJob.DestinationLocalPath,
                SingleDownloadOptions = transferJob.Options
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
                TransferType = StorageTransferType.DirectoryDownload,
                Status = StorageJobTransferStatus.Completed, //TODO = update with actual job status
                SourceBlobDirectoryClient = transferJob.SourceBlobDirectoryClient,
                DestinationLocalPath = transferJob.DestinationLocalPath,
                DirectoryDownloadOptions = transferJob.Options
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
                TransferType = StorageTransferType.SingleServiceCopy,
                Status = StorageJobTransferStatus.Completed, //TODO = update with actual job status
                SourceUri = transferJob.SourceUri,
                DestinationBlobClient = transferJob.DestinationBlobClient,
                CopyMethod = transferJob.CopyMethod,
                SingleCopyFromUriOptions = transferJob.CopyFromUriOptions
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
                TransferType = StorageTransferType.DirectoryServiceCopy,
                Status = StorageJobTransferStatus.Completed, //TODO = update with actual job status
                SourceUri = transferJob.SourceDirectoryUri,
                DestinationBlobDirectoryClient = transferJob.DestinationBlobDirectoryClient,
                CopyMethod = transferJob.CopyMethod,
                DirectoryCopyFromUriOptions = transferJob.CopyFromUriOptions
            };
        }
    }
}
