// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Options for <see cref="StorageResourceItem.CompleteTransferAsync(bool, StorageResourceCompleteTransferOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class StorageResourceCompleteTransferOptions
    {
        /// <summary>
        /// Optional. Specifies the source properties to set in the destination.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageResourceItemProperties SourceProperties { get; set; }
    }
}
