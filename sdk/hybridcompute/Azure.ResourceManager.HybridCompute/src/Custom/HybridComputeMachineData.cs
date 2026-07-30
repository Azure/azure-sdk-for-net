// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HybridCompute
{
    // Backward-compat justification: keep the conversion helpers that let regeneration preserve the GA
    // HybridComputeMachineData.Identity type by mapping between the service wire Identity model and ManagedServiceIdentity.
    public partial class HybridComputeMachineData
    {
        internal static Models.Identity ToIdentity(ManagedServiceIdentity identity)
        {
            if (identity is null)
            {
                return null;
            }

            Models.ResourceIdentityType? identityType = identity.ManagedServiceIdentityType == ManagedServiceIdentityType.SystemAssigned
                ? Models.ResourceIdentityType.SystemAssigned
                : default(Models.ResourceIdentityType?);
            return new Models.Identity(identity.PrincipalId?.ToString(), identity.TenantId?.ToString(), identityType, additionalBinaryDataProperties: null);
        }

        internal static ManagedServiceIdentity ToManagedServiceIdentity(Models.Identity identity)
        {
            if (identity is null)
            {
                return null;
            }

            Guid? principalId = Guid.TryParse(identity.PrincipalId, out Guid parsedPrincipalId) ? parsedPrincipalId : default(Guid?);
            Guid? tenantId = Guid.TryParse(identity.TenantId, out Guid parsedTenantId) ? parsedTenantId : default(Guid?);
            ManagedServiceIdentityType identityType = identity.Type == Models.ResourceIdentityType.SystemAssigned
                ? ManagedServiceIdentityType.SystemAssigned
                : default;
            return ResourceManagerModelFactory.ManagedServiceIdentity(principalId, tenantId, identityType);
        }
    }
}
