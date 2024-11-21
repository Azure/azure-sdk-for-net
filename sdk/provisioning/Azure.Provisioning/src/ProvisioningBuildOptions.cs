// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

/// <summary>
/// ProvisioningBuildOptions collects common values, settings, and functionality
/// that are used for composing, building, and deploying resources with
/// Azure.Provisioning libraries.
/// </summary>
public class ProvisioningBuildOptions
{
    /// <summary>
    /// Gets or sets the collection of <see cref="InfrastructureResolver"/>s to
    /// apply to any <see cref="Infrastructure"/> being composed.
    /// </summary>
    /// <remarks>
    /// By default this adds <see cref="DynamicResourceNamePropertyResolver"/>,
    /// <see cref="LocationPropertyResolver"/>, and
    /// <see cref="OrderingInfrastructureResolver"/>.  You can clear this list
    /// and replace it with other resolvers.  You can also insert your own
    /// resolvers before or after these resolvers.
    /// </remarks>
    public IList<InfrastructureResolver> InfrastructureResolvers { get; } =
    [
        new DynamicResourceNamePropertyResolver(),
        new LocationPropertyResolver(),
        new OrderingInfrastructureResolver(),
    ];
    // TODO: Resource resolvers
    // TODO: IConfig PropertyProvider

    /// <summary>
    /// Gets or sets a random generator.  It defaults to a new
    /// <see cref="Random"/>.
    /// </summary>
    /// <remarks>
    /// This can be helpful to set with a known seed if you want reproducible
    /// randomness for testing or debugging.
    /// </remarks>
    public Random Random { get; set; } = new Random();

    // TODO: Add a DefaultScope to allow globally scoping all resources
}
