// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class PublicIPAddress
{
    /// <summary>
    /// Creates a new PublicIPAddress as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public PublicIPAddress() : base("publicIPAddresses", "Microsoft.Network/publicIPAddresses")
    {
    }
}
