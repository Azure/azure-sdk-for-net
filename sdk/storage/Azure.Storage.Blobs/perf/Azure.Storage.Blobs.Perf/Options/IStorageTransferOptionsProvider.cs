// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Perf.Options
{
    public interface IStorageTransferOptionsProvider
    {
        StorageTransferOptions StorageTransferOptions { get; }
    }
}
