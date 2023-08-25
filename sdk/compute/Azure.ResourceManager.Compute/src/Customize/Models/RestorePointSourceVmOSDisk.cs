// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class RestorePointSourceVmOSDisk
    {
        /// <summary> Gets or sets Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier DiskRestorePointId
        {
            get => DiskRestorePoint?.Id;
        }
    }
}
