// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    internal static partial class CheckpointerExtensions
    {
        public static TransferCheckpointer GetCheckpointer(this TransferCheckpointStoreOptions options)
        {
            if (!string.IsNullOrEmpty(options?.CheckpointerPath))
            {
                return new LocalTransferCheckpointer(options.CheckpointerPath);
            }
            else
            {
                // Default TransferCheckpointer
                return new LocalTransferCheckpointer(default);
            }
        }
    }
}
