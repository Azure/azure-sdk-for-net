// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class FrontendIPConfiguration
{
    /// <summary>
    /// Creates a new FrontendIPConfiguration as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public FrontendIPConfiguration() : base("frontendIPConfigurations", "Microsoft.Network/loadBalancers/frontendIPConfigurations") { }
}
