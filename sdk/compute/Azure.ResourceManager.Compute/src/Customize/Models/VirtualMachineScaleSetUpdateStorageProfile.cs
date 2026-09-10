// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class VirtualMachineScaleSetUpdateStorageProfile
    {
        // Customization: see VirtualMachineScaleSetStorageProfile.DiskControllerType for context.
        /// <summary> Specifies the disk controller type configured for the virtual machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DiskControllerType
        {
            get => DiskControllerKind?.ToString();
            set => DiskControllerKind = value == null ? null : new DiskControllerType(value);
        }
    }
}
