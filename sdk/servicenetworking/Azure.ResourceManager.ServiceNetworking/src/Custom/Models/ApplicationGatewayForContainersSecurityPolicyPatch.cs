// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ServiceNetworking.Models
{
    public partial class ApplicationGatewayForContainersSecurityPolicyPatch
    {
        /// <summary> Gets or sets Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier WafPolicyId
        {
            get => Properties is null ? default : Properties.WafPolicyId;
            set
            {
                if (Properties is null)
                    Properties = new SecurityPolicyUpdateProperties();
                Properties.WafPolicyId = value;
            }
        }
    }
}
