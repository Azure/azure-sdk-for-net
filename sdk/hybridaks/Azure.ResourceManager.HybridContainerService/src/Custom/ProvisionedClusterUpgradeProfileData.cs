// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.HybridContainerService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridContainerService
{
    // Compat GA constructor for ProvisionedClusterUpgradeProfileData.
    public partial class ProvisionedClusterUpgradeProfileData
    {
        /// <summary> Initializes a new instance of <see cref="ProvisionedClusterUpgradeProfileData"/>. </summary>
        /// <param name="controlPlaneProfile"> The available control-plane upgrades. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="controlPlaneProfile"/> is null. </exception>
        public ProvisionedClusterUpgradeProfileData(ProvisionedClusterPoolUpgradeProfile controlPlaneProfile)
        {
            if (controlPlaneProfile is null)
            {
                throw new ArgumentNullException(nameof(controlPlaneProfile));
            }

            Properties = new ProvisionedClusterUpgradeProfileProperties(controlPlaneProfile);
        }
    }
}
