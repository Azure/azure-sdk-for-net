// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Interface for user-implemented handlers for <see cref="BlobQueryError"/>.
    /// </summary>
    public interface IBlobQueryErrorReceiver
    {
        /// <summary>
        /// Method to be called when a <see cref="BlobQueryError"/> occurs.
        /// </summary>
        /// <param name="blobQueryError"><see cref="BlobQueryError"/> to handle.</param>
        public void ReportError(BlobQueryError blobQueryError);
    }
}
