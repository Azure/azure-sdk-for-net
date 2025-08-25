// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Diagnostics.CodeAnalysis;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

[SuppressMessage("Usage", "AZC0012:Avoid single word type names", Justification = "This name has be to Route")]
public partial class Route
{
    /// <summary>
    /// Creates a new Route as a <see cref="ProvisionableConstruct"/>.
    /// </summary>
    public Route() : base("routes", "Microsoft.Network/routeTables/routes")
    {
    }
}
