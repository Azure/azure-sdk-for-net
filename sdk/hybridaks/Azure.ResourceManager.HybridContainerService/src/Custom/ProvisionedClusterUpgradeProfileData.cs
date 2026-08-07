// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.HybridContainerService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridContainerService
{
    // TypeSpec resource flattening does not preserve the GA constructor or writable flattened property.
    [CodeGenSuppress("ControlPlaneProfile")]
    public partial class ProvisionedClusterUpgradeProfileData
    {
        /// <summary> Initializes a new instance of <see cref="ProvisionedClusterUpgradeProfileData"/>. </summary>
        /// <param name="controlPlaneProfile"> The list of available kubernetes version upgrades for the control plane. </param>
        public ProvisionedClusterUpgradeProfileData(ProvisionedClusterPoolUpgradeProfile controlPlaneProfile)
            : this(default, default, default, default, new ProvisionedClusterUpgradeProfileProperties(controlPlaneProfile), default)
        {
        }

        /// <summary> The list of available kubernetes version upgrades for the control plane. </summary>
        public ProvisionedClusterPoolUpgradeProfile ControlPlaneProfile
        {
            get => Properties?.ControlPlaneProfile;
            set
            {
                if (Properties is null)
                {
                    throw new InvalidOperationException("The upgrade profile properties are not initialized.");
                }
                Properties.ControlPlaneProfile = value;
            }
        }
    }
}
