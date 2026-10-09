// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

internal partial class PublicIPPrefixPropertiesFormat
{
    private BicepList<SubResource> _publicIPAddresses;

    // Preserve the SubResource collection shipped in 1.1.0 rather than replacing its element type
    // with the generated ReferencedPublicIPAddress model.
    /// <summary> Gets the public IP address references. </summary>
    [CodeGenMember("PublicIPAddresses")]
    public BicepList<SubResource> PublicIPAddresses
    {
        get
        {
            Initialize();
            return _publicIPAddresses;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _publicIPAddresses = DefineListProperty<SubResource>(nameof(PublicIPAddresses), new string[] { "publicIPAddresses" }, isOutput: true);
    }
}
