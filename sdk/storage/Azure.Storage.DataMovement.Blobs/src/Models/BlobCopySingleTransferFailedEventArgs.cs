﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Event Argument for Failed Single Blob Transfers
    /// </summary>
    public class BlobCopySingleTransferFailedEventArgs : StorageTransferEventArgs
    {
        /// <summary>
        /// Gets the <see cref="Uri"/> that was the destination blob for the upload.
        /// </summary>
        public BlobBaseClient SourceBlobClient { get; }

        /// <summary>
        /// Gets the <see cref="Uri"/> to the contents to upload to the destination.
        /// </summary>
        public BlobBaseClient DestinationBlobClient { get; }

        /// <summary>
        /// Gets the <see cref="Exception"/> that was thrown during the job.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobCopySingleTransferFailedEventArgs"/>.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="sourceClient"></param>
        /// <param name="destinationClient"></param>
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
        /// Trhown if <paramref name="jobId"/> is empty or null.
        /// Thrown if <paramref name="sourceClient"/> is null.
        /// Thrown if <paramref name="destinationClient"/> is null.
        /// </exception>
        public BlobCopySingleTransferFailedEventArgs(
            string jobId,
            BlobBaseClient sourceClient,
            BlobBaseClient destinationClient,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base(jobId, isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNull(sourceClient, nameof(Uri));
            Argument.AssertNotNull(destinationClient, nameof(Uri));
            SourceBlobClient = sourceClient;
            DestinationBlobClient = destinationClient;
        }
    }
}
