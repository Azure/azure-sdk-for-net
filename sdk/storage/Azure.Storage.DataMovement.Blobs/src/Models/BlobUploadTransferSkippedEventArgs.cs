﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Event Argument for Failed Single Blob Upload Transfers
    /// </summary>
    public class BlobUploadTransferSkippedEventArgs : SyncAsyncEventArgs
    {
        /// <summary>
        /// Gets the source path to the contents to upload to the destination.
        /// </summary>
        public string SourcePath { get; }

        /// <summary>
        /// Gets the <see cref="BlobBaseClient"/> that was the destination blob for the upload.
        /// </summary>
        public BlobBaseClient DestinationBlobClient { get; }

        /// <summary>
        /// Gets the <see cref="Exception"/> that was thrown during the job.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobUploadTransferSkippedEventArgs"/>.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationBlobClient"></param>
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
        /// Thrown if <paramref name="sourcePath"/> is empty or null.
        /// Thown if <paramref name="destinationBlobClient"/> is empty or null.
        /// </exception>
        public BlobUploadTransferSkippedEventArgs(
            string sourcePath,
            BlobBaseClient destinationBlobClient,
            Exception exception,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base(isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(sourcePath, nameof(sourcePath));
            Argument.AssertNotNull(destinationBlobClient, nameof(BlobBaseClient));
            SourcePath = sourcePath;
            DestinationBlobClient = destinationBlobClient;
            Exception = exception;
        }
    }
}
