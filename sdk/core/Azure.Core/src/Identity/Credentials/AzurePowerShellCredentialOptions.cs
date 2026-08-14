// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Azure.Identity
{
    /// <summary>
    /// Options for configuring the <see cref="AzurePowerShellCredential"/>.
    /// </summary>
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    [TypeForwardedFrom("Azure.Identity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8")]
    public class AzurePowerShellCredentialOptions : TokenCredentialOptions, ISupportsAdditionallyAllowedTenants, ISupportsTenantId
    {
        /// <summary>
        /// The ID of the tenant to which the credential will authenticate by default. If not specified, the credential will authenticate to any requested tenant, and will default to the tenant provided to the 'Connect-AzAccount' cmdlet.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Specifies tenants in addition to the specified <see cref="TenantId"/> for which the credential may acquire tokens.
        /// Add the wildcard value "*" to allow the credential to acquire tokens for any tenant the logged in account can access.
        /// If no value is specified for <see cref="TenantId"/>, this option will have no effect, and the credential will acquire tokens for any requested tenant.
        /// </summary>
        public IList<string> AdditionallyAllowedTenants { get; internal set; } = new List<string>();

        /// <summary>
        /// The Powershell process timeout.
        /// </summary>
        public TimeSpan? ProcessTimeout { get; set; } = TimeSpan.FromSeconds(10);
    }
#pragma warning restore AZC0034
}
