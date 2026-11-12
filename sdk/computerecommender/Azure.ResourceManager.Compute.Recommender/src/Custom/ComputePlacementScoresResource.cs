// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.Recommender
{
    // TODO: Remove this workaround when https://github.com/Azure/azure-sdk-for-net/issues/64742 is fixed.
    [CodeGenSuppress("ValidateResourceId", typeof(ResourceIdentifier))]
    public partial class ComputePlacementScoresResource
    {
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            Argument.AssertNotNull(id, nameof(id));
            if (id.ResourceType != ResourceType || id.SubscriptionId is null ||
                !string.Equals(id.ToString(), CreateResourceIdentifier(id.SubscriptionId, new AzureLocation(id.Parent.Name)).ToString(), StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"Invalid resource ID {id}; expected a regular placement scores resource.", nameof(id));
            }
        }
    }
}
