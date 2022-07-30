// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading;
using Azure.Core;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Event Argument for Failed Blob Directory Upload Transfers
    /// </summary>
    public class BlobFolderUploadFailedEventArgs : StorageTransferEventArgs
    {
        /// <summary>
        /// Gets the source path to the contents to upload to the destination.
        /// </summary>
        public string SourceDirectoryPath { get; }

        /// <summary>
        /// Gets the <see cref="BlobBaseClient"/> that was the destination blob for the upload.
        /// </summary>
        public BlobFolderClient DestinationDirectoryClient { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobFolderUploadFailedEventArgs"/>.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="sourcePath"></param>
        /// <param name="destinationBlobClient"></param>
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
        /// Trhown if <paramref name="transferId"/> is empty or null.
        /// Thrown if <paramref name="sourcePath"/> is empty or null.
        /// Thown if <paramref name="destinationBlobClient"/> is empty or null.
        /// </exception>
        public BlobFolderUploadFailedEventArgs(
            string transferId,
            string sourcePath,
            BlobFolderClient destinationBlobClient,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base(transferId, isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(sourcePath, nameof(sourcePath));
            Argument.AssertNotNull(destinationBlobClient, nameof(BlobBaseClient));
            SourceDirectoryPath = sourcePath;
            DestinationDirectoryClient = destinationBlobClient;
        }
    }
}
