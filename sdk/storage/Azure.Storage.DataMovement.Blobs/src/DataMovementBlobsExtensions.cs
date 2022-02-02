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
        internal static BlobTransferUploadJobDetails ToBlobTransferUploadJobDetails(this BlobUploadTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferUploadJobDetails(
                jobId: transferJob.JobId,
                status: DataMovement.Models.StorageJobTransferStatus.Completed, //TODO: update with actual job status
                jobStartTime: DateTimeOffset.MinValue, // TODO: udpate to actual start time
                sourceLocalPath: transferJob.SourceLocalPath,
                destinationBlobClient: transferJob.DestinationBlobClient,
                options: transferJob.UploadOptions);
        }

        internal static BlobTransferUploadDirectoryJobDetails ToBlobTransferUploadDirectoryJobDetails(this BlobUploadDirectoryTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferUploadDirectoryJobDetails(
                jobId: transferJob.JobId,
                status: DataMovement.Models.StorageJobTransferStatus.Completed, //TODO: update with actual job status
                jobStartTime: DateTimeOffset.MinValue, // TODO: udpate to actual start time
                sourceLocalPath: transferJob.SourceLocalPath,
                destinationBlobClient: transferJob.DestinationDirectoryBlobClient,
                options: transferJob.UploadOptions);
        }

        internal static BlobTransferDownloadJobDetails ToBlobTransferDownloadJobDetails(this BlobDownloadTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferDownloadJobDetails(
                jobId: transferJob.JobId,
                status: DataMovement.Models.StorageJobTransferStatus.Completed, //TODO: update with actual job status
                jobStartTime: DateTimeOffset.MinValue, // TODO: udpate to actual start time
                sourceBlobClient: transferJob.SourceBlobClient,
                destinationLocalPath: transferJob.DestinationLocalPath,
                options: transferJob.Options);
        }

        internal static BlobTransferDownloadDirectoryJobDetails ToBlobTransferDownloadDirectoryJobDetails(this BlobDownloadDirectoryTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferDownloadDirectoryJobDetails(
                jobId: transferJob.JobId,
                status: DataMovement.Models.StorageJobTransferStatus.Completed, //TODO: update with actual job status
                jobStartTime: DateTimeOffset.MinValue, // TODO: udpate to actual start time
                sourceBlobClient: transferJob.SourceDirectoryBlobClient,
                destinationLocalPath: transferJob.DestinationLocalPath,
                options: transferJob.Options);
        }

        internal static BlobTransferCopyJobDetails ToBlobTransferCopyJobDetails(this BlobServiceCopyTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferCopyJobDetails(
                jobId: transferJob.JobId,
                status: DataMovement.Models.StorageJobTransferStatus.Completed, //TODO: update with actual job status
                jobStartTime: DateTimeOffset.MinValue, // TODO: udpate to actual start time
                sourceUri: transferJob.SourceUri,
                destinationBlobClient: transferJob.DestinationBlobClient,
                copyMethod: transferJob.CopyMethod,
                copyFromUriOptions: transferJob.CopyFromUriOptions);
        }

        internal static BlobTransferCopyDirectoryJobDetails ToBlobTransferCopyDirectoryJobDetails(this BlobServiceCopyDirectoryTransferJob transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new BlobTransferCopyDirectoryJobDetails(
                jobId: transferJob.JobId,
                status: DataMovement.Models.StorageJobTransferStatus.Completed, //TODO: update with actual job status
                jobStartTime: DateTimeOffset.MinValue, // TODO: udpate to actual start time
                sourceDirectoryUri: transferJob.SourceDirectoryUri,
                destinationDirectoryClient: transferJob.DestinationDirectoryClient,
                copyMethod: transferJob.CopyMethod,
                copyFromUriOptions: transferJob.CopyFromUriOptions);
        }
    }
}
