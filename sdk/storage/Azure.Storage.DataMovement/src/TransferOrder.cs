// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the recommended Transfer Type of the <see cref="StorageResourceItem"/>.
    /// </summary>
    public enum TransferOrder
    {
        /// <summary>
        /// Recommended Transfer type is unordered transfer for each chunk.
        /// </summary>
        Unordered = 0,

        /// <summary>
        /// Recommended Transfer type is sequential transfer for each chunk.
        /// </summary>
        Sequential = 1,
    }
}
