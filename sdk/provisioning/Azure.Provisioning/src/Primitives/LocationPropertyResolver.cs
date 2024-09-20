// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;

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
            !location.IsOutput &&
            (construct is not Resource r || !r.IsExistingResource))
        {
            BicepParameter param = GetOrCreateLocationParameter(context, construct);
            construct.SetProvisioningProperty(location, (BicepValue<string>)param);
        }
    }

    /// <summary>
    /// Gets the default location for a construct.
    /// </summary>
    /// <param name="context">The provisioning context for this construct.</param>
    /// <param name="construct">The construct with an unset Location property.</param>
    /// <returns>A unique dynamic name suffix for the resource.</returns>
    /// <remarks>
    /// This defaults to `resourceGroup().location` for most resources and
    /// `deployment().location` for resource groups.  This can be overridden to
    /// provide a different default location.
    /// </remarks>
    protected virtual BicepValue<AzureLocation> GetDefaultLocation(ProvisioningContext context, ProvisioningConstruct construct) =>
        construct is not ResourceGroup ?
            BicepFunction.GetResourceGroup().Location :
            BicepFunction.GetDeployment().Location;

    /// <summary>
    /// Find or inject a parameter for the location property.
    /// </summary>
    /// <param name="context">The provisioning context for this construct.</param>
    /// <param name="construct">The construct with an unset Location property.</param>
    /// <returns></returns>
    private BicepParameter GetOrCreateLocationParameter(
        ProvisioningContext context,
        ProvisioningConstruct construct)
    {
        // Get the default value for the location
        BicepValue<AzureLocation> location = GetDefaultLocation(context, construct);
        string expression = location.Compile().ToString();

        // Try to find an existing location param with the same value
        Infrastructure infra = construct.ParentInfrastructure ??
            throw new InvalidOperationException($"Construct {construct} must be added to an {nameof(Infrastructure)} instance before resolving properties.");
        IDictionary<string, BicepParameter> existing =
            infra.GetResources()
            .OfType<BicepParameter>()
            .Where(p => p.ResourceName.StartsWith("location"))
            .ToDictionary(p => p.ResourceName);
        foreach (BicepParameter p in existing.Values)
        {
            if (p.BicepType is TypeExpression type &&
                type.Type == typeof(string) &&
                p.Value.Compile().ToString() == expression)
            {
                return p;
            }
        }

        // Try to call the param location, but make it unique if that name is
        // already taken
        string name = "location";
        if (existing.ContainsKey(name))
        {
            bool increment = true;

            // Optionally specialize to the resource
            if (construct is NamedProvisioningConstruct resource)
            {
                name = $"{name}_{resource.ResourceName}";
                increment = existing.ContainsKey(name);
            }

            // Otherwise add the next available numeric suffix (i.e., location_2)
            if (increment)
            {
                for (int i = 2;; i++)
                {
                    string proposed = $"{name}_{i}";
                    if (!existing.ContainsKey(proposed))
                    {
                        name = proposed;
                        break;
                    }
                }
            }
        }

        // Create and add the param
        BicepParameter param =
            new(name, typeof(string))
            {
                Description = "The location for the resource(s) to be deployed.",
                Value = location
            };
        infra.Add(param); // TODO: Add up top
        return param;
    }
}
