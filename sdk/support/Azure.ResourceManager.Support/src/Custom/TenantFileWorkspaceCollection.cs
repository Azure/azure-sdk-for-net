// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Support
{
    /*
     * Custom code reason:
     *
     * ValidateResourceId override (dual-scope support):
     * In the TypeSpec spec (FileWorkspaceDetails.tsp), FileWorkspaceDetails is marked @subscriptionResource,
     * so the generator places it under SubscriptionResource scope and the generated ValidateResourceId only
     * accepts SubscriptionResource.ResourceType. However, in the old Swagger API, TenantFileWorkspaceCollection
     * was accessible from BOTH SubscriptionResource and TenantResource via GetTenantFileWorkspaces() extension
     * methods. To maintain backward compatibility, the custom MockableSupportTenantResource.GetTenantFileWorkspaces()
     * passes TenantResource.Id to this collection, which would fail the generated validation. The custom
     * ValidateResourceId accepts both SubscriptionResource.ResourceType and TenantResource.ResourceType.
     */
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
