// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Contains the DDoS protection settings of the public IP. </summary>
    public partial class DdosSettings
    {
        /// <summary> Gets or sets Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public ResourceIdentifier DdosCustomPolicyId
        {
            get => DdosProtectionPlanId;
            set
            {
                DdosProtectionPlanId = value;
            }
        }

        /// <summary> The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public DdosSettingsProtectionCoverage? ProtectionCoverage { get; set; }
        /// <summary> Enables DDoS protection on the public IP. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public bool? ProtectedIP
        {
            get => ProtectionMode == DdosSettingsProtectionMode.Disabled ? false : true;
            set
            {
                    if (value is true)
                    {
                        ProtectionMode = DdosSettingsProtectionMode.Enabled;
                    }
                    else
                    {
                        ProtectionMode = DdosSettingsProtectionMode.Disabled;
                    }
            }
        }
    }
}
