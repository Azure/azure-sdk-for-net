// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Azure.Identity
{
    /// <summary>
    /// Options for configuring the <see cref="VisualStudioCodeCredential"/>.
    /// </summary>
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    [TypeForwardedFrom("Azure.Identity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8")]
    public class VisualStudioCodeCredentialOptions : TokenCredentialOptions, ISupportsAdditionallyAllowedTenants, ISupportsTenantId
    {
        private string _tenantId;

        /// <summary>
        /// The tenant ID the user will be authenticated to. If not specified, the user will be authenticated to any requested tenant, and by default to the tenant the user originally authenticated to via the Visual Studio Code Azure Account extension.
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
    }
#pragma warning restore AZC0034
}
