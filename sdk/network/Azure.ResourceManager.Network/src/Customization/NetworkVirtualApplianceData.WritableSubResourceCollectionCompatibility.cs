// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkVirtualApplianceData type. </summary>
    [CodeGenSuppress("InboundSecurityRules")]
    [CodeGenSuppress("VirtualApplianceConnections")]
    [CodeGenSuppress("VirtualApplianceSites")]
    public partial class NetworkVirtualApplianceData
    {
        /// <summary> Gets or sets the InboundSecurityRules compatibility property. </summary>
        [WirePath("properties.inboundSecurityRules")]
        public IReadOnlyList<WritableSubResource> InboundSecurityRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.InboundSecurityRules);
        /// <summary> Gets or sets the VirtualApplianceConnections compatibility property. </summary>
        [WirePath("properties.virtualApplianceConnections")]
        public IReadOnlyList<WritableSubResource> VirtualApplianceConnections => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VirtualApplianceConnections);
        /// <summary> Gets or sets the VirtualApplianceSites compatibility property. </summary>
        [WirePath("properties.virtualApplianceSites")]
        public IReadOnlyList<WritableSubResource> VirtualApplianceSites => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VirtualApplianceSites);
    }
}
