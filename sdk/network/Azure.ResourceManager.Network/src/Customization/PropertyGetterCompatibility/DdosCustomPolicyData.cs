// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the DdosCustomPolicyData type. </summary>
    // Suppress the flattened member to retain the released WritableSubResource list contract.
    // Forward to native storage to preserve list/element mutations and wire connectivity.
    // Legacy elements intentionally drop unknown element JSON; parent/root data is unaffected.
    [CodeGenSuppress("FrontEndIPConfiguration")]
    public partial class DdosCustomPolicyData
    {
        /// <summary> The list of frontend IP configurations associated with the custom policy. </summary>
        [WirePath("properties.frontEndIpConfiguration")]
        public IList<WritableSubResource> FrontEndIPConfiguration
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new DdosCustomPolicyPropertiesFormat();
                }
                return Properties.FrontEndIPConfiguration;
            }
        }

        // This obsolete API was already disconnected from the wire model in 1.15.
        /// <summary> The protocol-specific DDoS policy customization parameters. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        public IList<ProtocolCustomSettings> ProtocolCustomSettings { get; } = new List<ProtocolCustomSettings>();
    }
}
