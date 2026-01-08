// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Identity
{
    /// <summary>
    /// Options for configuring the <see cref="VisualStudioCredential"/>.
    /// </summary>
    public class VisualStudioCredentialOptions : TokenCredentialOptions, ISupportsAdditionallyAllowedTenants, ISupportsTenantId
    {
        private string _tenantId;

        /// <summary>
        /// The tenant ID the credential will be authenticated to by default. If not specified, the credential will authenticate to any requested tenant, and will default to the tenant the user originally authenticated to via the Visual Studio Azure Service Account dialog.
        /// </summary>
        public string TenantId
        {
            get { return _tenantId; }
            set { _tenantId = Validations.ValidateTenantId(value, allowNull: true); }
        }

        /// <summary>
        /// Specifies tenants in addition to the specified <see cref="TenantId"/> for which the credential may acquire tokens.
        /// Add the wildcard value "*" to allow the credential to acquire tokens for any tenant the logged in account can access.
        /// If no value is specified for <see cref="TenantId"/>, this option will have no effect, and the credential will acquire tokens for any requested tenant.
        /// </summary>
        public IList<string> AdditionallyAllowedTenants { get; internal set; } = new List<string>();

        /// <summary>
        /// The VisualStudio process timeout.
        /// </summary>
        public TimeSpan? ProcessTimeout { get; set; }
    }
}
