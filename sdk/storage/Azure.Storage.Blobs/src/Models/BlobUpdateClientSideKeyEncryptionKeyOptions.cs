// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for SpecializedBlobExtensions.UpdateClientSideKeyEncryptionKey.
    /// </summary>
    public class BlobUpdateClientSideKeyEncryptionKeyOptions
    {
        /// <summary>
        /// Optional override for client-side encryption options to use when updating the key encryption key.
        /// Defaults to the <see cref="ClientSideEncryptionOptions"/> configured on the client when this is
        /// not populated. New key encryption key for the blob will be the
        /// <see cref="ClientSideEncryptionOptions.KeyEncryptionKey"/> on whichever encryption options are
        /// used for the operation. Options must have a resolver that can resolve the old key on the blob.
        /// </summary>
        public ClientSideEncryptionOptions EncryptionOptionsOverride { get; set; }

        /// <summary>
        /// Optional request conditions for the operation.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
