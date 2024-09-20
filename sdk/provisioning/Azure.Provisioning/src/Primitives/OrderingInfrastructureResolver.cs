// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Moves all the <see cref="BicepParameter"/>s to the top and all
/// <see cref="BicepOutput"/>s to the bottom of the <see cref="Infrastructure"/>.
/// </summary>
public class OrderingInfrastructureResolver : InfrastructureResolver
{
    /// <inheritdoc />
    public override IEnumerable<Provisionable> ResolveResources(
        ProvisioningContext context,
        IEnumerable<Provisionable> resources) =>
        resources.OrderBy(construct =>
            construct switch
            {
                BicepParameter => 0,
                BicepOutput => 2,
                _ => 1
            });
}
