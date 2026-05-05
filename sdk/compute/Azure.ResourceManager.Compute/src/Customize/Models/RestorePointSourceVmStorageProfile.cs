// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class RestorePointSourceVmStorageProfile
    {
        /// <summary> Gets the data disks of the VM captured at the time of the restore point creation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<RestorePointSourceVmDataDisk> DataDiskList => (IList<RestorePointSourceVmDataDisk>)DataDisks;
    }
}
