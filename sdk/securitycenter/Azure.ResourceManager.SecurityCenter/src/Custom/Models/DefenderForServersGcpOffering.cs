// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    /// <summary> The Defender for Servers GCP offering configurations. </summary>
    [CodeGenSuppress("IsEnabled")]
    public partial class DefenderForServersGcpOffering : SecurityCenterCloudOffering
    {
        /// <summary> Is arc auto provisioning enabled. </summary>
        public bool? IsArcAutoProvisioningEnabled
        {
            get => ArcAutoProvisioning is null ? default : ArcAutoProvisioning.IsEnabled;
            set
            {
                if (ArcAutoProvisioning is null)
                    ArcAutoProvisioning = new DefenderForServersGcpOfferingArcAutoProvisioning();
                ArcAutoProvisioning.IsEnabled = value;
            }
        }
    }
}
