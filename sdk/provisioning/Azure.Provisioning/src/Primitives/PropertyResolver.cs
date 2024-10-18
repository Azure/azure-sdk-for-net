// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Primitives;

/// <summary>
/// A property resolver attempts to resolve the values of any unset properties
/// in a construct.  This can be useful for defaulting common values,
/// implementing organization policies, or other scenarios where you want to
/// uniformly configure all the resources in a deployment.
/// </summary>
public abstract class PropertyResolver
{
    /// <summary>
    /// Try to resolve the values of any unset properties in the given construct.
    /// </summary>
    /// <param name="options">The current build options.</param>
    /// <param name="construct">The construct with properties to resolve.</param>
    public abstract void ResolveProperties(ProvisioningBuildOptions options, ProvisioningConstruct construct);
}
