// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// An infrastructure resolver attempts to resolve the values of any unset
/// properties or resources in <see cref="Infrastructure"/>.  This can be
/// useful for defaulting common values, implementing organization policies, or
/// other scenarios where you want to uniformly configure all the resources in
/// a deployment.
/// </summary>
public abstract class InfrastructureResolver
{
    /// <summary>
    /// Try to resolve the values of any unset properties in the given construct.
    /// </summary>
    /// <param name="construct">The construct with properties to resolve.</param>
    /// <param name="options">The current build options.</param>
    public virtual void ResolveProperties(
        ProvisionableConstruct construct,
        ProvisioningBuildOptions options)
    {
    }

    /// <summary>
    /// Resolve any properties of the infrastructure.
    /// </summary>
    /// <param name="infrastructure">The infrastructure to resolve properties of.</param>
    /// <param name="options">The current build options.</param>
    public virtual void ResolveInfrastructure(
        Infrastructure infrastructure,
        ProvisioningBuildOptions options)
    {
    }

    /// <summary>
    /// Process the collection of resources in the infrastructure.
    /// </summary>
    /// <param name="resources">The existing resources to resolve.</param>
    /// <param name="options">The current build options.</param>
    public virtual IEnumerable<Provisionable> ResolveResources(
        IEnumerable<Provisionable> resources,
        ProvisioningBuildOptions options) =>
        resources;

    /// <summary>
    /// Gets any nested infrastructure that should be composed separately.
    /// </summary>
    /// <param name="infrastructure">
    /// The infrastructure to inspect for any nested infrastructure.
    /// </param>
    /// <param name="options">The current build options.</param>
    /// <returns>Nested infrastructure.</returns>
    public virtual IEnumerable<Infrastructure> GetNestedInfrastructure(
        Infrastructure infrastructure,
        ProvisioningBuildOptions options) =>
        [];
}
