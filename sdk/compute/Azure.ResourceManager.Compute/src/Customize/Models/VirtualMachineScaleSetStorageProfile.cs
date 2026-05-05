// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class VirtualMachineScaleSetStorageProfile
    {
        // Customization: the previously-shipped surface exposed `DiskControllerType` as a `string`.
        // The TypeSpec property is now an enum `DiskControllerType`, renamed via @@clientName to
        // `DiskControllerKind` to keep the new strongly-typed surface available while preserving
        // the legacy string-typed `DiskControllerType` property for backward compatibility.
        /// <summary> Specifies the disk controller type configured for the virtual machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DiskControllerType
        {
            get => DiskControllerKind?.ToString();
            set => DiskControllerKind = value == null ? null : new DiskControllerType(value);
        }
    }
}
