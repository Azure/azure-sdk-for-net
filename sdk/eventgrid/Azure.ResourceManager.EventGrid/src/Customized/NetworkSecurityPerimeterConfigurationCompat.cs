// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Helper for the NSP config customizations: resolves parent scopes and splits the composite
// resource id ".../networkSecurityPerimeterConfigurations/{perimeterGuid}.{associationName}" so the
// customizations can call the generated single-segment-id REST operations and rebuild main's GA
// (perimeterGuid, associationName) surface. See eventgrid-nsp-customization-analysis.md.

#nullable disable

using System;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventGrid
{
    internal static class NetworkSecurityPerimeterConfigurationCompat
    {
        public static ResourceGroupResource GetResourceGroup(ArmClient client, ResourceIdentifier resourceId)
        {
            return client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(resourceId.SubscriptionId, resourceId.ResourceGroupName));
        }

        public static (string PerimeterGuid, string AssociationName) SplitAssociationName(ResourceIdentifier resourceId)
        {
            int separatorIndex = resourceId.Name.IndexOf('.');
            if (separatorIndex <= 0 || separatorIndex == resourceId.Name.Length - 1)
            {
                throw new InvalidOperationException($"The resource identifier '{resourceId}' does not contain the expected '{{perimeterGuid}}.{{associationName}}' segment.");
            }

            return (resourceId.Name.Substring(0, separatorIndex), resourceId.Name.Substring(separatorIndex + 1));
        }
    }
}
