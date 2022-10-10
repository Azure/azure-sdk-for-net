// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Models;

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
                SourceUri = transferJob.SourceResource.GetUri(),
                DestinationUri = transferJob._destinationBlobClient.Uri,
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
                SourceUri = new Uri(transferJob.SourceLocalPath.GetPath().ToLocalPathString()),
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

        internal static BlobTransferJobProperties ToBlobTransferJobDetails(this BlockBlobServiceCopyTransferJob transferJob)
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
                //case BlobCopyMethod.DownloadThenUploadCopy:
                    //return BlobTransferType.OperationType.DownloadThenUploadCopy;
                default:
                    return default;
            }
        }

        internal static StorageResourceProperties ToStorageResourceProperties(this BlobProperties blobProperties)
        {
            return new StorageResourceProperties(
                lastModified: blobProperties.LastModified,
                createdOn: blobProperties.CreatedOn,
                metadata: blobProperties.Metadata,
                copyCompletedOn: blobProperties.CopyCompletedOn,
                copyStatusDescription: blobProperties.CopyStatusDescription,
                copyId: blobProperties.CopyId,
                copyProgress: blobProperties.CopyProgress,
                copySource: blobProperties.CopySource,
                copyStatus: blobProperties.CopyStatus.ToCopyStatus(),
                contentLength: blobProperties.ContentLength,
                contentType: blobProperties.ContentType,
                eTag: blobProperties.ETag,
                contentHash: blobProperties.ContentHash,
                blobSequenceNumber: blobProperties.BlobSequenceNumber,
                blobCommittedBlockCount: blobProperties.BlobCommittedBlockCount,
                isServerEncrypted: blobProperties.IsServerEncrypted,
                encryptionKeySha256: blobProperties.EncryptionKeySha256,
                encryptionScope: blobProperties.EncryptionScope,
                versionId: blobProperties.VersionId,
                isLatestVersion: blobProperties.IsLatestVersion,
                expiresOn: blobProperties.ExpiresOn,
                lastAccessed: blobProperties.LastAccessed);
        }

        private static ServiceCopyStatus? ToCopyStatus(this CopyStatus copyStatus)
        {
            if (CopyStatus.Pending == copyStatus)
            {
                return ServiceCopyStatus.Pending;
            }
            else if (CopyStatus.Success == copyStatus)
            {
                return ServiceCopyStatus.Success;
            }
            else if (CopyStatus.Aborted == copyStatus)
            {
                return ServiceCopyStatus.Aborted;
            }
            else if (CopyStatus.Failed == copyStatus)
            {
                return ServiceCopyStatus.Failed;
            }
            return default;
        }
    }
}
