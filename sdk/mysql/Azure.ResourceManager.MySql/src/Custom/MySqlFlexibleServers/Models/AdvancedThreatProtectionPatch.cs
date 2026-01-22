// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.MySql.FlexibleServers.Models
{
    public partial class AdvancedThreatProtectionPatch
    {
        /// <summary> Specifies the state of the Advanced Threat Protection, whether it is enabled or disabled or a state has not been applied yet on the specific database or server. </summary>
        public AdvancedThreatProtectionState? State
        {
            get
            {
                return Properties is null ? default : Properties.State;
            }
            set
            {
                if (value != null)
                {
                    if (Properties is null)
                    {
                        Properties = new AdvancedThreatProtectionUpdateProperties();
                    }
                    Properties.State = value.Value;
                }
            }
        }
    }
}
