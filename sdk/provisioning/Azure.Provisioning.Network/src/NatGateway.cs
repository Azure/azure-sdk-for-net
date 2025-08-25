// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class NatGateway
{
    /// <summary>
    /// Creates a new NatGateway as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public NatGateway() : base("natGateways", "Microsoft.Network/natGateways")
    {
    }
}
