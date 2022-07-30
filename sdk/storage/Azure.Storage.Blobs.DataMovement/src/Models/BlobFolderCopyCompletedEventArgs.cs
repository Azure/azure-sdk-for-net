// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.Storage.DataMovement;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Event Argument for Failed Single Blob Upload Transfers
    /// </summary>
    public class BlobFolderCopyCompletedEventArgs : StorageTransferEventArgs
    {
        /// <summary>
        /// Gets the <see cref="BlobBaseClient"/> that was the destination blob for the upload.
        /// </summary>
        public BlobFolderClient SourceDirectoryClient { get; }

        /// <summary>
        /// Gets the source path to the contents to upload to the destination.
        /// </summary>
        public BlobFolderClient DestinationDirectoryClient { get; }

        /// Removed the need for response because that would require totalling up all the responses from
        /// each copy command. That's unnecessary, and can be done with each individual successful copy
        /// e.g <see cref="BlobSingleCopyCompletedEventArgs"/>

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobFolderCopyCompletedEventArgs"/>.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="sourceDirectoryClient"></param>
        /// <param name="destinationDirectoryClient"></param>
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
        /// Thrown if <paramref name="sourceDirectoryClient"/> is null.
        /// Thrown if <paramref name="destinationDirectoryClient"/> is null.
        /// </exception>
        public BlobFolderCopyCompletedEventArgs(
            string transferId,
            BlobFolderClient sourceDirectoryClient,
            BlobFolderClient destinationDirectoryClient,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base(transferId, isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNull(SourceDirectoryClient, nameof(BlobFolderClient));
            Argument.AssertNotNull(destinationDirectoryClient, nameof(BlobFolderClient));
            DestinationDirectoryClient = destinationDirectoryClient;
            SourceDirectoryClient = sourceDirectoryClient;
        }
    }
}
