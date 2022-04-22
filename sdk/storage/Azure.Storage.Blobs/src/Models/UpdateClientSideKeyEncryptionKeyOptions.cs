// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for updating a client-side key encryption key on a blob.
    /// </summary>
    public class UpdateClientSideKeyEncryptionKeyOptions
    {
        /// <summary>
        /// Optional conditions for accessing the blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional override for client-side encryption options to use when updating the key encryption key.
        /// Defaults to the <see cref="ClientSideEncryptionOptions"/> configured on the client when this is
        /// not populated. New key encryption key for the blob will be the
        /// <see cref="ClientSideEncryptionOptions.KeyEncryptionKey"/> on whichever encryption options are
        /// used for the operation.
        /// </summary>
        public ClientSideEncryptionOptions EncryptionOptionsOverride { get; set; }
    }
}
