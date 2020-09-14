// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlobBaseClient.OpenReadAsync(BlobOpenReadOptions, System.Threading.CancellationToken)"/>
    /// </summary>
    public class BlobOpenReadOptions
    {
        /// <summary>
        /// The position within the blob to begin the stream.
        /// Defaults to the beginning of the blob.
        /// </summary>
        public long Position { get; set; }

        /// <summary>
        /// The buffer size to use when the stream downloads parts
        /// of the blob.  Defaults to 4 MB.
        /// </summary>
        public int? BufferSize { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the download of the blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="allowModifications">
        /// If false, a <see cref="RequestFailedException"/> will be thrown if the blob is modified while
        /// it is being read from.
        /// </param>
        public BlobOpenReadOptions(bool allowModifications)
        {
            // Setting the Conditions to empty means we won't automatically
            // use the ETag as a condition and it will be possible for the blob
            // to change while it's being read from.
            if (allowModifications)
            {
                Conditions = new BlobRequestConditions();
            }
        }
    }
}
