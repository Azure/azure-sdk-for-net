// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

internal partial class WebApplicationFirewallPolicyPropertiesFormat
{
    private BicepList<SubResource> _applicationGatewayForContainers;

    // Preserve the SubResource collection shipped in 1.1.0 rather than replacing its element type
    // with the generated ApplicationGatewayForContainersReferenceDefinition model.
    /// <summary> Gets the Application Gateway for Containers references. </summary>
    [CodeGenMember("ApplicationGatewayForContainers")]
    public BicepList<SubResource> ApplicationGatewayForContainers
    {
        get
        {
            Initialize();
            return _applicationGatewayForContainers;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _applicationGatewayForContainers = DefineListProperty<SubResource>(nameof(ApplicationGatewayForContainers), new string[] { "applicationGatewayForContainers" }, isOutput: true);
    }
}
