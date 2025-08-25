// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class VirtualNetworkPeering
{
    /// <summary>
    /// Creates a new VirtualNetworkPeering as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public VirtualNetworkPeering() : base("virtualNetworkPeerings", "Microsoft.Network/virtualNetworks/virtualNetworkPeerings")
    {
    }
}
