// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Default all location properties to their resource group's location.
/// </summary>
public class LocationPropertyResolver : PropertyResolver
{
    /// <inheritdoc />
    public override void ResolveProperties(ProvisioningContext context, ProvisioningConstruct construct)
    {
        // We only need to set a location if one doesn't already exist
        if (construct.ProvisioningProperties.TryGetValue("Location", out BicepValue? location) &&
            location.Kind == BicepValueKind.Unset &&
            !location.IsOutput)
        {
            // Default the location to the resource group's location
            construct.SetProvisioningProperty(location, BicepFunction.GetResourceGroup().Location);
        }
    }
}
