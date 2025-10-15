// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ServiceNetworking.Models
{
    /// <summary> The type used for update operations of the TrafficController. </summary>
    public partial class TrafficControllerPatch
    {
        /// <summary> Gets or sets Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier WafSecurityPolicyId
        {
            get => Properties?.SecurityPolicyConfigurations?.WafSecurityPolicyId;
            set
            {
                if (Properties is null)
                    Properties = new TrafficControllerUpdateProperties();
                if (Properties.SecurityPolicyConfigurations is null)
                    Properties.SecurityPolicyConfigurations = new SecurityPolicyConfigurations();
                Properties.SecurityPolicyConfigurations.WafSecurityPolicyId = value;
            }
        }
    }
}
