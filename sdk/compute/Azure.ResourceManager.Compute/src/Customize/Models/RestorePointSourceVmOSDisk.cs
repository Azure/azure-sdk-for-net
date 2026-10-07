// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class RestorePointSourceVmOSDisk
    {
        /// <summary> Resource Id of the source disk restore point. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier DiskRestorePointId => DiskRestorePoint?.Id;
    }
}
