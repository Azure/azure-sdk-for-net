﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="WorkloadIdentityCredential"/>.
    /// </summary>
    public class WorkloadIdentityCredentialOptions : TokenCredentialOptions, ISupportsDisableInstanceDiscovery, ISupportsAdditionallyAllowedTenants
    {
        /// <summary>
        /// The tenant ID of the service principal. Defaults to the value of the environment variable AZURE_TENANT_ID.
        /// </summary>
        public string TenantId { get; set; } = EnvironmentVariables.TenantId;

        /// <summary>
        /// The client (application) ID of the service principal. Defaults to the value of the environment variable AZURE_CLIENT_ID.
        /// </summary>
        public string ClientId { get; set; } = EnvironmentVariables.ClientId;

        /// <summary>
        /// The path to a file containing the workload identity token. Defaults to the value of the environment variable AZURE_FEDERATED_TOKEN_FILE.
        /// </summary>
        public string TokenFilePath { get; set; } = EnvironmentVariables.AzureFederatedTokenFile;

        /// <inheritdoc />
        public bool DisableInstanceDiscovery { get; set; }

        /// <summary>
        /// Specifies tenants in addition to the specified <see cref="TenantId"/> for which the credential may acquire tokens.
        /// Add the wildcard value "*" to allow the credential to acquire tokens for any tenant the logged in account can access.
        /// If no value is specified for <see cref="TenantId"/>, this option will have no effect, and the credential will acquire tokens for any requested tenant.
        /// Defaults to the value of the environment variable AZURE_ADDITIONALLY_ALLOWED_TENANTS.
        /// </summary>
        public IList<string> AdditionallyAllowedTenants { get; internal set; } = EnvironmentVariables.AdditionallyAllowedTenants;

        internal CredentialPipeline Pipeline { get; set; }

        internal MsalConfidentialClient MsalClient { get; set; }
    }
}
