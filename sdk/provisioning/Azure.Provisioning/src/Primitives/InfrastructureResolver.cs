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
    /// <param name="context">The current provisioning context.</param>
    /// <param name="infrastructure">The infrastructure to resolve properties of.</param>
    public virtual void ResolveInfrastructure(
        ProvisioningContext context,
        Infrastructure infrastructure)
    {
    }

    /// <summary>
    /// Process the collection of resources in the infrastructure.
    /// </summary>
    /// <param name="context">The current provisioning context.</param>
    /// <param name="resources">The existing resources to resolve.</param>
    public virtual IEnumerable<Provisionable> ResolveResources(
        ProvisioningContext context,
        IEnumerable<Provisionable> resources) =>
        resources;

    /// <summary>
    /// Gets any nested infrastructure that should be composed separately.
    /// </summary>
    /// <param name="context">The current provisioning context.</param>
    /// <param name="infrastructure">
    /// The infrastructure to inspect for any nested infrastructure.
    /// </param>
    /// <returns></returns>
    public IEnumerable<Infrastructure> GetNestedInfrastructure(
        ProvisioningContext context,
        Infrastructure infrastructure) =>
        [];
}
