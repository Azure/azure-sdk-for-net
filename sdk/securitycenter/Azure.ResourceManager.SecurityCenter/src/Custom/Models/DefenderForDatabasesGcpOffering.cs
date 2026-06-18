// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class DefenderForDatabasesGcpOffering
    {
        /// <summary> Is arc auto provisioning enabled. </summary>
        public bool? IsEnabled
        {
            get => ArcAutoProvisioning is null ? default : ArcAutoProvisioning.Enabled;
            set
            {
                if (ArcAutoProvisioning is null)
                {
                    ArcAutoProvisioning = new DefenderForDatabasesGcpOfferingArcAutoProvisioning();
                }

                ArcAutoProvisioning.Enabled = value;
            }
        }
    }
}
