// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class VirtualNetworkTap
{
    /// <summary>
    /// Creates a new VirtualNetworkTap as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public VirtualNetworkTap() : base("virtualNetworkTaps", "Microsoft.Network/virtualNetworkTaps")
    {
    }
}
