// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public class BlobCopyTransferSuccessEventArgs : SyncAsyncEventArgs
    {
        /// <summary>
        /// Gets the <see cref="BlobBaseClient"/> that was the destination blob for the upload.
        /// </summary>
        public Uri SourceUri { get; }

        /// <summary>
        /// Gets the source path to the contents to upload to the destination.
        /// </summary>
        public BlobBaseClient DestinationBlobClient { get; }

        /// <summary>
        /// Gets the response returned from a successful copy transfer.
        ///
        /// For a Async Service Copy the response will be the GetProperties call of the last updated full copy status (is that okay?)
        /// </summary>
        public Response Response { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobCopyTransferSuccessEventArgs"/>.
        /// </summary>
        /// <param name="destinationBlobClient"></param>
        /// <param name="sourceUri"></param>
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
        /// Thrown if <paramref name="destinationBlobClient"/> is empty or null.
        /// Thown if <paramref name="sourceUri"/> is empty or null.
        /// </exception>
        public BlobCopyTransferSuccessEventArgs(
            Uri sourceUri,
            BlobBaseClient destinationBlobClient,
            Response response,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base(isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(sourceUri.AbsoluteUri, nameof(sourceUri));
            Argument.AssertNotNull(destinationBlobClient, nameof(BlobBaseClient));
            DestinationBlobClient = destinationBlobClient;
            SourceUri = sourceUri;
            Response = response;
        }
    }
}
