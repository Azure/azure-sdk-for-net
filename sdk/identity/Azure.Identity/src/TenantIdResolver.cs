// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Identity
{
    internal static class TenantIdResolver
    {
        /// <summary>
        /// Resolves the tenantId based on the supplied configuration values.
        /// </summary>
        /// <param name="explicitTenantId">The tenantId passed to the ctor of the Credential.</param>
        /// <param name="context">The <see cref="TokenRequestContext"/>.</param>
        /// <returns>The tenantId to be used for authorization.</returns>
        public static string Resolve(string explicitTenantId, TokenRequestContext context)
        {
            bool disableMultiTenantAuth = IdentityCompatSwitches.DisableTenantDiscovery;

            if (context.TenantId != explicitTenantId && context.TenantId != null && explicitTenantId != null)
            {
                if (disableMultiTenantAuth || explicitTenantId == Constants.AdfsTenantId)
                {
                    AzureIdentityEventSource.Singleton.TenantIdDiscoveredAndNotUsed(explicitTenantId, context.TenantId);
                }
                else
                {
                    AzureIdentityEventSource.Singleton.TenantIdDiscoveredAndUsed(explicitTenantId, context.TenantId);
                }
            }

            return disableMultiTenantAuth switch
            {
                true => explicitTenantId,
                false when explicitTenantId == Constants.AdfsTenantId => explicitTenantId,
                _ => context.TenantId ?? explicitTenantId
            };
        }
    }
}
