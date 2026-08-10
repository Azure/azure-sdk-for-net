// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.HybridContainerService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridContainerService
{
    public partial class ProvisionedClusterUpgradeProfileData
    {
        // The resource is read-only in TypeSpec, so the generated data model omits the public
        // constructor and setter that shipped in the GA SDK.
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

        [CodeGenMember("Properties")]
        internal ProvisionedClusterUpgradeProfileProperties Properties { get; set; }

        /// <summary> The list of available kubernetes version upgrades for the control plane. </summary>
        [CodeGenMember("ControlPlaneProfile")]
        public ProvisionedClusterPoolUpgradeProfile ControlPlaneProfile
        {
            get => Properties?.ControlPlaneProfile;
            set
            {
                if (Properties is null)
                {
                    Properties = new ProvisionedClusterUpgradeProfileProperties(value);
                }
                else
                {
                    Properties.ControlPlaneProfile = value;
                }
            }
        }
    }
}
