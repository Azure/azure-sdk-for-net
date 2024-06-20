// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Options for <see cref="StorageResourceItem.CompleteTransferAsync(bool, StorageResourceCompleteTransferOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class StorageResourceCompleteTransferOptions
    {
        /// <summary>
        /// Optional. Specifies the source properties to set in the destination.
        /// </summary>
        public StorageResourceItemProperties SourceProperties { get; set; }
    }
}
