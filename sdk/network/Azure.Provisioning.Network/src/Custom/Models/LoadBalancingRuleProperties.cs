// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

public partial class LoadBalancingRuleProperties
{
    private BicepList<WritableSubResource> _backendAddressPools;

    // Preserve the WritableSubResource collection shipped in 1.1.0 instead of the generated NetworkSubResource collection.
    /// <summary> Gets or sets the backend address pool references. </summary>
    [CodeGenMember("BackendAddressPools")]
    public BicepList<WritableSubResource> BackendAddressPools
    {
        get
        {
            Initialize();
            return _backendAddressPools;
        }
        set
        {
            Initialize();
            _backendAddressPools.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _backendAddressPools = DefineListProperty<WritableSubResource>(nameof(BackendAddressPools), new string[] { "backendAddressPools" });
    }
}
