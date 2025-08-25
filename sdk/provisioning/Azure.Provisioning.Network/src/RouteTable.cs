// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class RouteTable
{
    /// <summary>
    /// Creates a new RouteTable as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public RouteTable() : base("routeTables", "Microsoft.Network/routeTables")
    {
    }
}
