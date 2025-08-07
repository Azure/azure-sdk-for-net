// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Identity
{
    internal abstract class TenantIdResolverBase
    {
        public static readonly string[] AllTenants = new string[] { "*" };
        public static TenantIdResolver Default => new TenantIdResolver();
        public abstract string Resolve(string explicitTenantId, TokenRequestContext context, string[] additionallyAllowedTenantIds);
        public abstract string[] ResolveAddionallyAllowedTenantIds(IList<string> additionallyAllowedTenants);
    }
}
