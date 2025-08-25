// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class NetworkInterfaceIPConfiguration
{
    /// <summary>
    /// Creates a new NetworkInterfaceIPConfiguration as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public NetworkInterfaceIPConfiguration() : base(string.Empty, "Microsoft.Network/networkInterfaces/ipConfigurations") { }
}
