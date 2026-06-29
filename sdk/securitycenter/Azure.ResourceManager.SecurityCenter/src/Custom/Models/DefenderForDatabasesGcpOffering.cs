// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code exposes the current nested arcAutoProvisioning.enabled shape; the previous GA API had a top-level IsEnabled property, so map it to the generated nested model for source compatibility.
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
