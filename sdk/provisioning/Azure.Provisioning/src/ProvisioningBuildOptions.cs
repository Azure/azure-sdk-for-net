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
    /// Gets or sets the collection of <see cref="PropertyResolver"/>s to apply
    /// to all resources being composed.
    /// </summary>
    public IList<PropertyResolver> PropertyResolvers { get; set; } =
    [
        new DynamicResourceNamePropertyResolver(),
        new LocationPropertyResolver(),
    ];
    // TODO: Do we want to make this less mutable like AddPipelinePolicy to
    // maintain more control over how people are able to modify these?

    /// <summary>
    /// Gets or sets the collection of <see cref="InfrastructureResolver"/>s to
    /// apply to any <see cref="Infrastructure"/> being composed.
    /// </summary>
    public IList<InfrastructureResolver> InfrastructureResolvers { get; set; } =
    [
        new OrderingInfrastructureResolver(),
    ];

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
    // TODO: Resource resolvers
    // TODO: IConfig PropertyProvider
}
