// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Defines the properties of the Blob Transfer Job
    /// </summary>
    public class BlobTransferJobProperties
    {
        /// <summary>
        /// Constructor internal.
        /// </summary>
        internal BlobTransferJobProperties(){ }

        /// <summary>
        /// Job Id. Guid.
        /// </summary>
        public string JobId { get; internal set; }

        /// <summary>
        /// Defines the type of transfer the job is performing.
        /// </summary>
        public StorageTransferType TransferType { get; internal set; }

        /// <summary>
        /// Status of the job
        /// </summary>
        public StorageJobTransferStatus Status { get; internal set; }

        /// <summary>
        /// Gets the local path of the source file for upload transfer jobs.
        /// </summary>
        public string SourceLocalPath { get; internal set; }

        /// <summary>
        /// Source Uri single and directory copy transfers.
        /// </summary>
        public Uri SourceUri { get; internal set; }

        /// <summary>
        /// The source blob client. This client contains the information and methods required to perform
        /// the single download transfer from the source blob.
        /// </summary>
        public BlobBaseClient SourceBlobClient { get; internal set; }

        /// <summary>
        /// The source blob directory client. This client contains the information and methods required to perform
        /// the directory download from the source directory blob.
        /// </summary>
        public BlobVirtualDirectoryClient SourceBlobDirectoryClient { get; internal set; }

        /// <summary>
        /// Gets the local path which will store the contents for a single blob to be downloaded.
        /// </summary>
        public string DestinationLocalPath { get; internal set; }

        /// <summary>
        /// The destination blob client for single copy jobs and single download jobs.
        /// </summary>
        public BlobBaseClient DestinationBlobClient { get; internal set; }

        /// <summary>
        /// Destination directory for the finished copies and directory uploads.
        /// </summary>
        public BlobVirtualDirectoryClient DestinationBlobDirectoryClient { get; internal set; }

        /// <summary>
        /// Copy method to choose between StartCopyFromUri or SyncCopyFromUri for Single Copy or Directory Copy Transfers
        /// </summary>
        public BlobServiceCopyMethod CopyMethod { get; internal set; }

        /// <summary>
        /// Gets the <see cref="BlobDownloadOptions"/> for Single Download Transfers.
        /// </summary>
        public BlobDownloadToOptions SingleDownloadOptions { get; internal set; }

        /// <summary>
        /// Upload options for the upload task
        /// </summary>
        public BlobUploadOptions SingleUploadOptions { get; internal set; }

        /// <summary>
        /// Upload options for the directory upload transfer.
        /// </summary>
        public BlobDirectoryUploadOptions DirectoryUploadOptions { get; internal set; }

        /// <summary>
        /// Gets the <see cref="BlobDirectoryDownloadOptions"/> for Directory Download transfers.
        /// </summary>
        public BlobDirectoryDownloadOptions DirectoryDownloadOptions { get; internal set; }

        /// <summary>
        /// Gets the <see cref="BlobCopyFromUriOptions"/> for Single Copy Transfers.
        /// </summary>
        public BlobCopyFromUriOptions SingleCopyFromUriOptions { get; internal set; }

        /// <summary>
        /// Gets the <see cref="BlobDirectoryCopyFromUriOptions"/> for Directory Copy transfers
        /// </summary>
        public BlobDirectoryCopyFromUriOptions DirectoryCopyFromUriOptions { get; internal set; }
    }
}
