// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

internal partial class NetworkVirtualAppliancePropertiesFormat
{
    private BicepList<WritableSubResource> _internetIngressPublicIPs;

    // Preserve the WritableSubResource collection shipped in 1.1.0 rather than replacing its element type
    // with the generated InternetIngressPublicIpsProperties model.
    /// <summary> Gets or sets the internet ingress public IP references. </summary>
    [CodeGenMember("InternetIngressPublicIPs")]
    public BicepList<WritableSubResource> InternetIngressPublicIPs
    {
        get
        {
            Initialize();
            return _internetIngressPublicIPs;
        }
        set
        {
            Initialize();
            _internetIngressPublicIPs.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _internetIngressPublicIPs = DefineListProperty<WritableSubResource>(nameof(InternetIngressPublicIPs), new string[] { "internetIngressPublicIps" });
    }
}
