// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobStorageResourceRehydrator : StorageResourceRehydrator
    {
        protected override string TypeId => "Blob";

        internal BlobStorageResourceRehydrator(
            AzureStorageCredentialSupplier.GetSharedKeyCredential sharedKeyDelegate,
            AzureStorageCredentialSupplier.GetTokenCredential tokenDelegate,
            AzureStorageCredentialSupplier.GetSasCredential sasDelegate)
        {
            throw new NotImplementedException();
        }

        protected override StorageResource GetSourceResource(DataTransferProperties props)
        {
            throw new NotImplementedException();
        }

        protected override StorageResource GetDestinationResource(DataTransferProperties props)
        {
            throw new NotImplementedException();
        }
    }
}
