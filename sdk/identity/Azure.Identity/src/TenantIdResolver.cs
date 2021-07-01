// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Identity
{
    internal static class TenantIdResolver
    {
        internal const string tenantIdMismatch = "The TenantId received from a challenge did not match the configured TenantId and AllowMultiTenantAuthentication is false.";
        /// <summary>
        /// Resolves the tenantId based on the supplied configuration values.
        /// </summary>
        /// <param name="explicitTenantId">The tenantId passed to the ctor of the Credential.</param>
        /// <param name="context">The <see cref="TokenRequestContext"/>.</param>
        /// <param name="allowMultiTenantAuthentication"> If <c>true</c>, the tenantId in the <see cref="TokenRequestContext"/> will be preferred, if present.</param>
        /// <returns></returns>
        public static string Resolve(string explicitTenantId, TokenRequestContext context, bool allowMultiTenantAuthentication)
        {
            return allowMultiTenantAuthentication switch
            {
                false when context.TenantId != null && explicitTenantId != context.TenantId && !IdentityCompatSwitches.EnableLegacyTenantSelection => throw new AuthenticationFailedException(tenantIdMismatch),
                false => explicitTenantId ?? context.TenantId,
                _ => context.TenantId ?? explicitTenantId
            };
        }
    }
}
