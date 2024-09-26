// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

/// <summary>
/// ProvisioningContext collects common values, settings, and functionality
/// that are used for composing, building, and deploying resources with
/// Azure.Provisioning libraries.
/// </summary>
public class ProvisioningContext
{
    /// <summary>
    /// Gets or sets the <see cref="Primitives.ProvisioningContextProvider"/> used
    /// implicitly when a <see cref="ProvisioningContext"/> is not provided.
    /// </summary>
    /// <remarks>
    /// This defaults to a <see cref="LocalProvisioningContextProvider"/>
    /// which shares the same <see cref="ProvisioningContext"/> across all
    /// operations on the same thread.
    /// </remarks>
    public static ProvisioningContextProvider Provider { get; set; }
        = new LocalProvisioningContextProvider();

    /// <summary>
    /// Gets or sets the default <see cref="Infrastructure"/> to automatically
    /// add resources to when they aren't explicitly grouped.  This will be
    /// called <c>main</c> by default and result in a <c>main.bicep</c> file
    /// being written from a <see cref="ProvisioningPlan"/>.  Adding a resource
    /// to other infrastructure will break this relationship.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This instance will be automatically refreshed whenever infrastructure
    /// is composed with <see cref="Infrastructure.Build"/> or
    /// <see cref="Resource.Build"/>.
    /// </para>
    /// <para>
    /// Adding a resource to an <see cref="Infrastructure"/> instance will
    /// break the association with any existing infrastructure, so you can also
    /// explicitly group resources with <see cref="Infrastructure.Add"/> on
    /// your own instances when preferable.
    /// </para>
    /// </remarks>
    public Infrastructure DefaultInfrastructure
    {
        get
        {
            _defaultInfrastructure ??= DefaultInfrastructureProvider();
            return _defaultInfrastructure;
        }
        set => _defaultInfrastructure = value;
    }
    private Infrastructure? _defaultInfrastructure;

    /// <summary>
    /// Gets or sets a factory to provide new values of the
    /// <see cref="DefaultInfrastructure"/> property. It gets refreshed
    /// automatically whenever infrastructure is composed with
    /// <see cref="Infrastructure.Build"/> or <see cref="Resource.Build"/>.
    /// </summary>
    public Func<Infrastructure> DefaultInfrastructureProvider { get; set; } =
        () => new Infrastructure("main");

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
