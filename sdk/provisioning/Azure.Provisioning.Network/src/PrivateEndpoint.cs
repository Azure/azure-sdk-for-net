// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class PrivateEndpoint
{
    /// <summary>
    /// Creates a new PrivateEndpoint as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public PrivateEndpoint() : base("privateEndpoints", "Microsoft.Network/privateEndpoints")
    {
    }
}
