// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Support
{
    // Suppress the generated ValidateResourceId to accept both TenantResource and SubscriptionResource
    [CodeGenSuppress("ValidateResourceId", typeof(Core.ResourceIdentifier))]
    public partial class TenantFileWorkspaceCollection
    {
        [System.Diagnostics.Conditional("DEBUG")]
        internal static void ValidateResourceId(Core.ResourceIdentifier id)
        {
            if (id.ResourceType != SubscriptionResource.ResourceType && id.ResourceType != TenantResource.ResourceType)
            {
                throw new System.ArgumentException(
                    string.Format("Invalid resource type {0} expected {1} or {2}", id.ResourceType, SubscriptionResource.ResourceType, TenantResource.ResourceType),
                    nameof(id));
            }
        }
    }
}
