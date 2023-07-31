// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.DataMovement
{
    internal class FileSystemStorageResourceRehydrator : StorageResourceRehydrator
    {
        protected internal override string TypeId => throw new NotImplementedException();

        protected internal override StorageResource GetDestinationResource(DataTransferProperties props)
        {
            throw new NotImplementedException();
        }

        protected internal override StorageResource GetSourceResource(DataTransferProperties props)
        {
            throw new NotImplementedException();
        }
    }
}
