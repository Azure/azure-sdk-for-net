// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

/// <summary>
/// PrivateLinkService.
/// </summary>
public partial class PrivateLinkService
{
    /// <summary>
    /// Creates a new PrivateLinkService as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public PrivateLinkService() : base("privateLinkServices", "Microsoft.Network/privateLinkServices")
    {
    }
}
