// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Azure.Storage.Blobs.DataMovement.Models;

namespace Azure.Storage.Blobs.DataMovement
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
                TransferId = transferJob.TransferId,
                TransferType = new BlobTransferType()
                {
                    Resource = BlobTransferType.ResourceType.Blob,
                    Operation = BlobTransferType.OperationType.Upload,
                },
                SourceUri = new Uri(transferJob.SourceLocalPath),
                DestinationUri = transferJob.DestinationBlobClient.Uri,
            };
        }

        internal static BlobTransferJobProperties ToBlobTransferJobDetails(this BlobFolderUploadTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferJobProperties()
            {
                TransferId = transferJob.TransferId,
                TransferType = new BlobTransferType()
                {
                    Resource = BlobTransferType.ResourceType.BlobFolder,
                    Operation = BlobTransferType.OperationType.Upload,
                },
                SourceUri = new Uri(transferJob.SourceLocalPath),
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
                TransferId = transferJob.TransferId,
                TransferType = new BlobTransferType()
                {
                    Resource = BlobTransferType.ResourceType.Blob,
                    Operation = BlobTransferType.OperationType.Download,
                },
                SourceUri = transferJob.SourceBlobClient.Uri,
                DestinationUri = new Uri(transferJob.DestinationLocalPath),
            };
        }

        internal static BlobTransferJobProperties ToBlobTransferJobDetails(this BlobFolderDownloadTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferJobProperties()
            {
                TransferId = transferJob.TransferId,
                TransferType = new BlobTransferType()
                {
                    Resource = BlobTransferType.ResourceType.BlobFolder,
                    Operation = BlobTransferType.OperationType.Download,
                },
                SourceUri = transferJob.SourceBlobDirectoryClient.Uri,
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
                TransferId = transferJob.TransferId,
                TransferType = new BlobTransferType()
                {
                    Resource = BlobTransferType.ResourceType.BlobFolder,
                    Operation = ToOperationType(transferJob.CopyMethod),
                },
                SourceUri = transferJob.SourceUri,
                DestinationUri = transferJob.DestinationBlobClient.Uri,
            };
}

        internal static BlobTransferJobProperties ToBlobTransferJobDetails(this BlobFolderServiceCopyTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferJobProperties()
            {
                TransferId = transferJob.TransferId,
                TransferType = new BlobTransferType()
                {
                    Resource = BlobTransferType.ResourceType.BlobFolder,
                    Operation = ToOperationType(transferJob.CopyMethod),
                },
                SourceUri = transferJob.SourceBlobDirectoryClient.Uri,
                DestinationUri = transferJob.DestinationBlobDirectoryClient.Uri,
            };
        }

        private static BlobTransferType.OperationType ToOperationType(BlobCopyMethod copyMethod)
        {
            switch (copyMethod)
            {
                case BlobCopyMethod.Copy:
                    return BlobTransferType.OperationType.Copy;
                case BlobCopyMethod.SyncCopy:
                    return BlobTransferType.OperationType.SyncCopy;
                case BlobCopyMethod.UploadFromUriCopy:
                    return BlobTransferType.OperationType.UploadFromUriCopy;
                case BlobCopyMethod.DownloadThenUploadCopy:
                    return BlobTransferType.OperationType.DownloadThenUploadCopy;
                default:
                    return default;
            }
        }
    }
}
