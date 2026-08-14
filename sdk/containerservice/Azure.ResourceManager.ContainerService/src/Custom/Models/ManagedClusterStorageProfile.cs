// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Storage profile for the container service cluster. </summary>
    [CodeGenSuppress("IsEnabled")]
    public partial class ManagedClusterStorageProfile
    {
        /// <summary> Whether to enable AzureDisk CSI Driver. The default value is true. </summary>
        public bool? IsDiskCsiDriverEnabled
        {
            get => DiskCsiDriver is null ? default : DiskCsiDriver.IsDiskCsiDriverEnabled;
            set
            {
                if (DiskCsiDriver is null)
                    DiskCsiDriver = new ManagedClusterStorageProfileDiskCsiDriver();
                DiskCsiDriver.IsDiskCsiDriverEnabled = value;
            }
        }
    }
}
