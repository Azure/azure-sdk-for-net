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
    /// Resolve any properties of the infrastructure.
    /// </summary>
    /// <param name="options">The current build options.</param>
    /// <param name="infrastructure">The infrastructure to resolve properties of.</param>
    public virtual void ResolveInfrastructure(
        ProvisioningBuildOptions options,
        Infrastructure infrastructure)
    {
    }

    /// <summary>
    /// Process the collection of resources in the infrastructure.
    /// </summary>
    /// <param name="options">The current build options.</param>
    /// <param name="resources">The existing resources to resolve.</param>
    public virtual IEnumerable<Provisionable> ResolveResources(
        ProvisioningBuildOptions options,
        IEnumerable<Provisionable> resources) =>
        resources;

    /// <summary>
    /// Gets any nested infrastructure that should be composed separately.
    /// </summary>
    /// <param name="options">The current build options.</param>
    /// <param name="infrastructure">
    /// The infrastructure to inspect for any nested infrastructure.
    /// </param>
    /// <returns></returns>
    public IEnumerable<Infrastructure> GetNestedInfrastructure(
        ProvisioningBuildOptions options,
        Infrastructure infrastructure) =>
        [];
}
