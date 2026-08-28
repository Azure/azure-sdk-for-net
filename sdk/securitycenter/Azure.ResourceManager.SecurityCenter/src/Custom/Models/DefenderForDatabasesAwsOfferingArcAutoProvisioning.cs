// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec model uses "enabled", which generates Enabled; the previous GA API exposed this flag as IsEnabled.
    public partial class DefenderForDatabasesAwsOfferingArcAutoProvisioning
    {
        /// <summary> Is arc auto provisioning enabled. </summary>
        public bool? IsEnabled
        {
            get => Enabled;
            set => Enabled = value;
        }
    }
}
