// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Moves all the <see cref="ProvisioningParameter"/>s to the top and all
/// <see cref="ProvisioningOutput"/>s to the bottom of the <see cref="Infrastructure"/>.
/// </summary>
public class OrderingInfrastructureResolver : InfrastructureResolver
{
    /// <inheritdoc />
    public override IEnumerable<Provisionable> ResolveResources(
        IEnumerable<Provisionable> resources,
        ProvisioningBuildOptions options) =>
        resources.OrderBy(construct =>
            construct switch
            {
                ProvisioningParameter => 0,
                ProvisioningOutput => 2,
                _ => 1
            });
}
