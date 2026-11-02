// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Network;

public partial class LoadBalancerInboundNatPool
{
    // Preserve the public wrapper shipped in 1.1.0 alongside the flattened members.
    /// <summary> Properties of load balancer inbound nat pool. </summary>
    public LoadBalancerInboundNatPoolProperties Properties
    {
        get { Initialize(); return _properties!; }
        set { Initialize(); AssignOrReplace(ref _properties, value); }
    }
    private LoadBalancerInboundNatPoolProperties? _properties;

    partial void DefineAdditionalProperties()
    {
        _properties = DefineModelProperty<LoadBalancerInboundNatPoolProperties>(nameof(Properties), new string[] { "properties" });
    }
}
