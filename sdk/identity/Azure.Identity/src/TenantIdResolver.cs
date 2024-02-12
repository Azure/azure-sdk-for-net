// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Identity
{
    internal class TenantIdResolver : TenantIdResolverBase
    {
        /// <summary>
        /// Resolves the tenantId based on the supplied configuration values.
        /// </summary>
        /// <param name="explicitTenantId">The tenantId passed to the ctor of the Credential.</param>
        /// <param name="context">The <see cref="TokenRequestContext"/>.</param>
        /// <param name="additionallyAllowedTenantIds">Additional tenants the credential is configured to acquire tokens for.</param>
        /// <returns>The tenantId to be used for authorization.</returns>
        public override string Resolve(string explicitTenantId, TokenRequestContext context, string[] additionallyAllowedTenantIds)
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

            string resolvedTenantId = disableMultiTenantAuth switch
            {
                true => explicitTenantId,
                false when explicitTenantId == Constants.AdfsTenantId => explicitTenantId,
                _ => context.TenantId ?? explicitTenantId
            };

            if (explicitTenantId != null && resolvedTenantId != explicitTenantId && additionallyAllowedTenantIds != AllTenants && Array.BinarySearch(additionallyAllowedTenantIds, resolvedTenantId, StringComparer.OrdinalIgnoreCase) < 0)
            {
                throw new AuthenticationFailedException($"The current credential is not configured to acquire tokens for tenant {resolvedTenantId}. To enable acquiring tokens for this tenant add it to the AdditionallyAllowedTenants on the credential options, or add \"*\" to AdditionallyAllowedTenants to allow acquiring tokens for any tenant. See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/multitenant/troubleshoot");
            }

            return resolvedTenantId;
        }

        public override string[] ResolveAddionallyAllowedTenantIds(IList<string> additionallyAllowedTenants)
        {
            if (additionallyAllowedTenants == null || additionallyAllowedTenants.Count == 0)
            {
                return Array.Empty<string>();
            }

            if (additionallyAllowedTenants.Contains("*"))
            {
                return AllTenants;
            }

            return additionallyAllowedTenants.OrderBy(s => s).ToArray();
        }
    }
}
