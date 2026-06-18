// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec moved the old top-level isEnabled field under arcAutoProvisioning; expose the GA IsEnabled property and map it to the nested generated model.
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
