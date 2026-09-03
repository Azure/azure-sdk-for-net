// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.PrivateDns;

public partial class VirtualNetworkLink
{
    /// <summary> Gets or sets the virtual network resource identifier. </summary>
    [CodeGenMember("VirtualNetworkId")]
    public BicepValue<ResourceIdentifier> VirtualNetworkId
    {
        get => Properties is null || Properties.VirtualNetworkId is null ? default : Properties.VirtualNetworkId.Id;
        set
        {
            if (Properties is null)
            {
                Properties = new VirtualNetworkLinkProperties();
            }
            if (Properties.VirtualNetworkId is null)
            {
                Properties.VirtualNetworkId = new WritableSubResource();
            }
            Properties.VirtualNetworkId.Id = value;
        }
    }

    /// <summary>
    /// Supported VirtualNetworkLink resource versions.
    /// </summary>
    public static partial class ResourceVersions
    {
        /// <summary>
        /// 2020-06-01.
        /// </summary>
        public static readonly string V2020_06_01 = "2020-06-01";

        /// <summary>
        /// 2020-01-01.
        /// </summary>
        public static readonly string V2020_01_01 = "2020-01-01";

        /// <summary>
        /// 2018-09-01.
        /// </summary>
        public static readonly string V2018_09_01 = "2018-09-01";
    }
}
