// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Models
{
    /// <summary>
    /// Transactional hash options for upload methods.
    /// </summary>
    public class UploadTransactionalHashingOptions
    {
        /// <summary>
        /// Algorithm used by SDK to generate the checksum sent alongside upload data.
        /// </summary>
        public TransactionalHashAlgorithm Algorithm { get; set; }

        /// <summary>
        /// If a hash has already been calculated elsewhere for the upload content,
        /// it can be provided here as opposed to the SDK recalculating one. This
        /// value can only be used if the data is uploaded in the single chunk the
        /// hash would match. If the data is split up on upload, this hash is ignored
        /// and the SDK will calculate hashes for each individual partition.
        /// </summary>
        public byte[] PrecalculatedHash { get; set; }
    }
}
