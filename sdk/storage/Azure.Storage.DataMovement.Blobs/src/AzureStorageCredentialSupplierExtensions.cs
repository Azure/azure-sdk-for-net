// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Extension methods for <see cref="AzureStorageCredentialSupplier"/> regarding blob storage.
    /// </summary>
    public static class AzureStorageCredentialSupplierExtensions
    {
        /// <summary>
        /// Gets a <see cref="StorageResourceRehydrator"/> for azure blob storage, based on the given credential supplier.
        /// </summary>
        public static StorageResourceRehydrator GetBlobStorageResourceRehydrator(this AzureStorageCredentialSupplier credSupplier)
            => new BlobStorageResourceRehydrator(
                credSupplier.SharedKeyCredential,
                credSupplier.TokenCredential,
                credSupplier.SasCredential);
    }
}
