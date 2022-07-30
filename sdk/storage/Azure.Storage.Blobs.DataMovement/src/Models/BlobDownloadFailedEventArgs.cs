// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading;
using Azure.Core;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Event Argument for Failed Single Blob Upload Transfers
    /// </summary>
    public class BlobDownloadFailedEventArgs : StorageTransferEventArgs
    {
        /// <summary>
        /// Gets the <see cref="BlobBaseClient"/> that was the destination blob for the upload.
        /// </summary>
        public BlobBaseClient SourceBlobClient { get; }

        /// <summary>
        /// Gets the source path to the contents to upload to the destination.
        /// </summary>
        public string DestinationLocalPath { get; }

        /// <summary>
        /// Gets the <see cref="Exception"/> that was thrown during the job.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobDownloadFailedEventArgs"/>.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="destinationLocalPath"></param>
        /// <param name="sourceBlobClient"></param>
        /// <param name="exception"></param>
        /// <param name="isRunningSynchronously">
        /// A value indicating whether the event handler was invoked
        /// synchronously or asynchronously.  Please see
        /// <see cref="Azure.Core.SyncAsyncEventHandler{T}"/> for more details.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token related to the original operation that raised
        /// the event.  It's important for your handler to pass this token
        /// along to any asynchronous or long-running synchronous operations
        /// that take a token so cancellation will correctly propagate.  The
        /// default value is <see cref="CancellationToken.None"/>.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="transferId"/> is empty or null.
        /// Thrown if <paramref name="destinationLocalPath"/> is empty or null.
        /// Thown if <paramref name="sourceBlobClient"/> is empty or null.
        /// </exception>
        public BlobDownloadFailedEventArgs(
            string transferId,
            BlobBaseClient sourceBlobClient,
            string destinationLocalPath,
            Exception exception,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base(transferId, isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(destinationLocalPath, nameof(destinationLocalPath));
            Argument.AssertNotNull(sourceBlobClient, nameof(BlobBaseClient));
            DestinationLocalPath = destinationLocalPath;
            SourceBlobClient = sourceBlobClient;
            Exception = exception;
        }
    }
}
