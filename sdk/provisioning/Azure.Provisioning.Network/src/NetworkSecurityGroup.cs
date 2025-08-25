// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class NetworkSecurityGroup
{
    /// <summary>
    /// Creates a new NetworkSecurityGroup as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public NetworkSecurityGroup() : base("networkSecurityGroups", "Microsoft.Network/networkSecurityGroups")
    {
    }
}
