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
    /// Event Argument for Failed Single Blob Transfers
    /// </summary>
    public class BlobSingleCopyCompletedEventArgs : StorageTransferEventArgs
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
        /// Gets the response returned from a successful copy transfer.
        ///
        /// For a Async Service Copy the response will be the GetProperties call of the last updated full copy status (is that okay?)
        /// </summary>
        public Response Response { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobSingleCopyCompletedEventArgs"/>.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="sourceClient"></param>
        /// <param name="destinationClient"></param>
        /// <param name="response"></param>
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
        /// Thrown if <paramref name="sourceClient"/> is null.
        /// Thrown if <paramref name="destinationClient"/> is null.
        /// Thrown if <paramref name="response"/> is null.
        /// </exception>
        public BlobSingleCopyCompletedEventArgs(
            string transferId,
            BlobBaseClient sourceClient,
            BlobBaseClient destinationClient,
            Response response,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base(transferId, isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNull(sourceClient, nameof(Uri));
            Argument.AssertNotNull(destinationClient, nameof(Uri));
            Argument.AssertNotNull(response, nameof(Response));
            SourceBlobClient = sourceClient;
            DestinationBlobClient = destinationClient;
            Response = response;
        }
    }
}
