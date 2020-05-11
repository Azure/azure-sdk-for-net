// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Interface for user-implemented handlers for <see cref="BlobQueryError"/>.
    /// </summary>
    public abstract class BlobQueryErrorHandler
    {
        /// <summary>
        /// Method to be called when a <see cref="BlobQueryError"/> occurs.
        /// </summary>
        /// <param name="blobQueryError">
        /// <see cref="BlobQueryError"/> to handle.
        /// </param>
        public abstract void Handle(BlobQueryError blobQueryError);

        /// <summary>
        /// Method to be called when a <see cref="BlobQueryError"/> occurs.
        /// </summary>
        /// <param name="blobQueryError">
        /// <see cref="BlobQueryError"/> to handle.
        /// </param>
        public abstract Task HandleAsync(BlobQueryError blobQueryError);
    }
}
