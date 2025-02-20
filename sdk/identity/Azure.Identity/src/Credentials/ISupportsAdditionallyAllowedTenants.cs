// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Identity
{
    internal interface ISupportsAdditionallyAllowedTenants
    {
        /// <summary>
        /// Specifies tenants in addition to the configured tenant for which the credential may acquire tokens.
        /// Add the wildcard value "*" to allow the credential to acquire tokens for any tenant the logged in account can access.
        /// If no specific tenant was configured this option will have no effect, and the credential will acquire tokens for any requested tenant.
        /// </summary>
        public IList<string> AdditionallyAllowedTenants { get; }
    }
}
