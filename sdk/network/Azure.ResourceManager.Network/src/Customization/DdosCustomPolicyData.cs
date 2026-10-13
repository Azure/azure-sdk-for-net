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
    [CodeGenSuppress("PublicIPAddresses")]
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

        // Keep the released obsolete public-IP view over the native collection.
        /// <summary> Gets the PublicIPAddresses compatibility property. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [WirePath("properties.publicIPAddresses")]
        public IReadOnlyList<WritableSubResource> PublicIPAddresses => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.PublicIPAddresses);

        // Retain the obsolete 1.15 compatibility API; current TypeSpec has no protocolCustomSettings field.
        // Keep the persistent per-instance list shipped in 1.16.1/1.17 without adding wire serialization.
        /// <summary> The protocol-specific DDoS policy customization parameters. </summary>
        [Obsolete("This property is obsolete and might be removed in a future version", false)]
        public IList<ProtocolCustomSettings> ProtocolCustomSettings { get; } = new List<ProtocolCustomSettings>();
    }
}
