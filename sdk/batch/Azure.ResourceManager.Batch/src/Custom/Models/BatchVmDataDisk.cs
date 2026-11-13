// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Batch.Models
{
    public partial class BatchVmDataDisk
    {
        /// <summary> The storage account type to be used for the data disk. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Use ManagedDisk.StorageAccountType instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BatchStorageAccountType? StorageAccountType { get; set; }
    }
}
