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
        /// <param name="allowMultiTenantAuthentication"> If <c>true</c>, the tenantId in the <see cref="TokenRequestContext"/> will be preferred, if present.</param>
        /// <returns></returns>
        public static string Resolve(string explicitTenantId, TokenRequestContext context, bool allowMultiTenantAuthentication)
        {
            return allowMultiTenantAuthentication switch
            {
                false => explicitTenantId ?? context.TenantId,
                _ => context.TenantId ?? explicitTenantId
            };
        }
    }
}
