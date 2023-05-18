﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="DefaultAzureCredential"/> authentication flow and requests made to Azure Identity services.
    /// </summary>
    public class DefaultAzureCredentialOptions : TokenCredentialOptions, ISupportsDisableInstanceDiscovery, ISupportsAdditionallyAllowedTenants
    {
        private struct UpdateTracker<T>
        {
            private bool _updated;
            private T _value;

            public UpdateTracker(T initialValue)
            {
                _value = initialValue;
                _updated = false;
            }

            public T Value
            {
                get => _value;
                set
                {
                    _value = value;
                    _updated = true;
                }
            }

            public bool Updated => _updated;
        }

        private UpdateTracker<string> _tenantId = new UpdateTracker<string>(EnvironmentVariables.TenantId);
        private UpdateTracker<string> _interactiveBrowserTenantId = new UpdateTracker<string>(EnvironmentVariables.TenantId);
        private UpdateTracker<string> _sharedTokenCacheTenantId = new UpdateTracker<string>(EnvironmentVariables.TenantId);
        private UpdateTracker<string> _visualStudioTenantId = new UpdateTracker<string>(EnvironmentVariables.TenantId);
        private UpdateTracker<string> _visualStudioCodeTenantId = new UpdateTracker<string>(EnvironmentVariables.TenantId);

        /// <summary>
        /// The ID of the tenant to which the credential will authenticate by default. If not specified, the credential will authenticate to any requested tenant, and will default to the tenant to which the chosen authentication method was originally authenticated.
        /// </summary>
        public string TenantId
        {
            get => _tenantId.Value;
            set
            {
                if (_interactiveBrowserTenantId.Updated && value != _interactiveBrowserTenantId.Value)
                {
                    throw new InvalidOperationException("Applications should not set both TenantId and InteractiveBrowserTenantId. TenantId is preferred, and is functionally equivalent. InteractiveBrowserTenantId exists only to provide backwards compatibility.");
                }

                if (_sharedTokenCacheTenantId.Updated && value != _sharedTokenCacheTenantId.Value)
                {
                    throw new InvalidOperationException("Applications should not set both TenantId and SharedTokenCacheTenantId. TenantId is preferred, and is functionally equivalent. SharedTokenCacheTenantId exists only to provide backwards compatibility.");
                }

                if (_visualStudioTenantId.Updated && value != _visualStudioTenantId.Value)
                {
                    throw new InvalidOperationException("Applications should not set both TenantId and VisualStudioTenantId. TenantId is preferred, and is functionally equivalent. VisualStudioTenantId exists only to provide backwards compatibility.");
                }

                if (_visualStudioCodeTenantId.Updated && value != _visualStudioCodeTenantId.Value)
                {
                    throw new InvalidOperationException("Applications should not set both TenantId and VisualStudioCodeTenantId. TenantId is preferred, and is functionally equivalent. VisualStudioCodeTenantId exists only to provide backwards compatibility.");
                }
                _tenantId.Value = value;
                _interactiveBrowserTenantId.Value = value;
                _sharedTokenCacheTenantId.Value = value;
                _visualStudioCodeTenantId.Value = value;
                _visualStudioTenantId.Value = value;
            }
        }

        /// <summary>
        /// The tenant id of the user to authenticate, in the case the <see cref="DefaultAzureCredential"/> authenticates through, the
        /// <see cref="InteractiveBrowserCredential"/>. The default is null and will authenticate users to their default tenant.
        /// The value can also be set by setting the environment variable AZURE_TENANT_ID.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InteractiveBrowserTenantId
        {
            get => _interactiveBrowserTenantId.Value;
            set
            {
                if (_tenantId.Updated && value != _tenantId.Value)
                {
                    throw new InvalidOperationException("Applications should not set both TenantId and InteractiveBrowserTenantId. TenantId is preferred, and is functionally equivalent. InteractiveBrowserTenantId exists only to provide backwards compatibility.");
                }

                _interactiveBrowserTenantId.Value = value;
            }
        }

        /// <summary>
        /// Specifies the tenant id of the preferred authentication account, to be retrieved from the shared token cache for single sign on authentication with
        /// development tools, in the case multiple accounts are found in the shared token.
        /// </summary>
        /// <remarks>
        /// If multiple accounts are found in the shared token cache and no value is specified, or the specified value matches no accounts in
        /// the cache the SharedTokenCacheCredential will not be used for authentication.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SharedTokenCacheTenantId
        {
            get => _sharedTokenCacheTenantId.Value;
            set
            {
                if (_tenantId.Updated && value != _tenantId.Value)
                {
                    throw new InvalidOperationException("Applications should not set both TenantId and SharedTokenCacheTenantId. TenantId is preferred, and is functionally equivalent. SharedTokenCacheTenantId exists only to provide backwards compatibility.");
                }

                _sharedTokenCacheTenantId.Value = value;
            }
        }

        /// <summary>
        /// The tenant id of the user to authenticate, in the case the <see cref="DefaultAzureCredential"/> authenticates through, the
        /// <see cref="VisualStudioCredential"/>. The default is null and will authenticate users to their default tenant.
        /// The value can also be set by setting the environment variable AZURE_TENANT_ID.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string VisualStudioTenantId
        {
            get => _visualStudioTenantId.Value;
            set
            {
                if (_tenantId.Updated && value != _tenantId.Value)
                {
                    throw new InvalidOperationException("Applications should not set both TenantId and VisualStudioTenantId. TenantId is preferred, and is functionally equivalent. VisualStudioTenantId exists only to provide backwards compatibility.");
                }

                _visualStudioTenantId.Value = value;
            }
        }

        /// <summary>
        /// The tenant ID of the user to authenticate, in the case the <see cref="DefaultAzureCredential"/> authenticates through, the
        /// <see cref="VisualStudioCodeCredential"/>. The default is null and will authenticate users to their default tenant.
        /// The value can also be set by setting the environment variable AZURE_TENANT_ID.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string VisualStudioCodeTenantId
        {
            get => _visualStudioCodeTenantId.Value;
            set
            {
                if (_tenantId.Updated && value != _tenantId.Value)
                {
                    throw new InvalidOperationException("Applications should not set both TenantId and VisualStudioCodeTenantId. TenantId is preferred, and is functionally equivalent. VisualStudioCodeTenantId exists only to provide backwards compatibility.");
                }

                _visualStudioCodeTenantId.Value = value;
            }
        }

        /// <summary>
        /// Specifies tenants in addition to the specified <see cref="TenantId"/> for which the credential may acquire tokens.
        /// Add the wildcard value "*" to allow the credential to acquire tokens for any tenant the logged in account can access.
        /// If no value is specified for <see cref="TenantId"/>, this option will have no effect on that authentication method, and the credential will acquire tokens for any requested tenant when using that method.
        /// This value can also be set by setting the environment variable AZURE_ADDITIONALLY_ALLOWED_TENANTS.
        /// </summary>
        public IList<string> AdditionallyAllowedTenants { get; internal set; } = EnvironmentVariables.AdditionallyAllowedTenants;

        /// <summary>
        /// Specifies the preferred authentication account to be retrieved from the shared token cache for single sign on authentication with
        /// development tools. In the case multiple accounts are found in the shared token.
        /// </summary>
        /// <remarks>
        /// If multiple accounts are found in the shared token cache and no value is specified, or the specified value matches no accounts in
        /// the cache the SharedTokenCacheCredential will not be used for authentication.
        /// </remarks>
        public string SharedTokenCacheUsername { get; set; } = EnvironmentVariables.Username;

        /// <summary>
        /// Specifies the client id of the selected credential
        /// </summary>
        public string InteractiveBrowserCredentialClientId { get; set; }

        /// <summary>
        /// Specifies the client id of the application the workload identity will authenticate.
        /// </summary>
        public string WorkloadIdentityClientId { get; set; } = EnvironmentVariables.ClientId;

        /// <summary>
        /// Specifies the client id of a user assigned ManagedIdentity. If this value is configured, then <see cref="ManagedIdentityResourceId"/> should not be configured.
        /// </summary>
        public string ManagedIdentityClientId { get; set; } = EnvironmentVariables.ClientId;

        /// <summary>
        /// Specifies the resource id of a user assigned ManagedIdentity. If this value is configured, then <see cref="ManagedIdentityClientId"/> should not be configured.
        /// </summary>
        public ResourceIdentifier ManagedIdentityResourceId { get; set; }

        /// <summary>
        /// Specifies timeout for credentials invoked via sub-process. e.g. Visual Studio, Azure CLI, Azure Powershell.
        /// </summary>
        public TimeSpan? CredentialProcessTimeout { get; set; } = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Specifies whether the <see cref="EnvironmentCredential"/> will be excluded from the authentication flow. Setting to true disables reading
        /// authentication details from the process' environment variables.
        /// </summary>
        public bool ExcludeEnvironmentCredential { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="WorkloadIdentityCredential"/> will be excluded from the authentication flow. Setting to true disables reading
        /// authentication details from the process' environment variables.
        /// </summary>
        public bool ExcludeWorkloadIdentityCredential { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="ManagedIdentityCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// Setting to true disables authenticating with managed identity endpoints.
        /// </summary>
        public bool ExcludeManagedIdentityCredential { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="AzureDeveloperCliCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// </summary>
        public bool ExcludeAzureDeveloperCliCredential { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="SharedTokenCacheCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// Setting to true disables single sign on authentication with development tools which write to the shared token cache.
        /// The default is <c>true</c>.
        /// </summary>
        public bool ExcludeSharedTokenCacheCredential { get; set; } = true;

        /// <summary>
        /// Specifies whether the <see cref="InteractiveBrowserCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// Setting to true disables launching the default system browser to authenticate in development environments.
        /// The default is <c>true</c>.
        /// </summary>
        public bool ExcludeInteractiveBrowserCredential { get; set; } = true;

        /// <summary>
        /// Specifies whether the <see cref="AzureCliCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// </summary>
        public bool ExcludeAzureCliCredential { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="VisualStudioCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// </summary>
        public bool ExcludeVisualStudioCredential { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="VisualStudioCodeCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// The default is <c>true</c>.
        /// </summary>
        public bool ExcludeVisualStudioCodeCredential { get; set; } = true;

        /// <summary>
        /// Specifies whether the <see cref="AzurePowerShellCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// </summary>
        public bool ExcludeAzurePowerShellCredential { get; set; }

        /// <inheriteddoc/>
        public bool DisableInstanceDiscovery { get; set; }

        internal override T Clone<T>()
        {
            var clone = base.Clone<T>();

            if (clone is DefaultAzureCredentialOptions dacClone)
            {
                dacClone._tenantId = _tenantId;
                dacClone._interactiveBrowserTenantId = _interactiveBrowserTenantId;
                dacClone._sharedTokenCacheTenantId = _sharedTokenCacheTenantId;
                dacClone._visualStudioTenantId = _visualStudioTenantId;
                dacClone._visualStudioCodeTenantId = _visualStudioCodeTenantId;
                dacClone.SharedTokenCacheUsername = SharedTokenCacheUsername;
                dacClone.InteractiveBrowserCredentialClientId = InteractiveBrowserCredentialClientId;
                dacClone.WorkloadIdentityClientId = WorkloadIdentityClientId;
                dacClone.ManagedIdentityClientId = ManagedIdentityClientId;
                dacClone.ManagedIdentityResourceId = ManagedIdentityResourceId;
                dacClone.CredentialProcessTimeout = CredentialProcessTimeout;
                dacClone.ExcludeEnvironmentCredential = ExcludeEnvironmentCredential;
                dacClone.ExcludeWorkloadIdentityCredential = ExcludeWorkloadIdentityCredential;
                dacClone.ExcludeManagedIdentityCredential = ExcludeManagedIdentityCredential;
                dacClone.ExcludeAzureDeveloperCliCredential = ExcludeAzureDeveloperCliCredential;
                dacClone.ExcludeSharedTokenCacheCredential = ExcludeSharedTokenCacheCredential;
                dacClone.ExcludeInteractiveBrowserCredential = ExcludeInteractiveBrowserCredential;
                dacClone.ExcludeAzureCliCredential = ExcludeAzureCliCredential;
                dacClone.ExcludeVisualStudioCredential = ExcludeVisualStudioCredential;
                dacClone.ExcludeVisualStudioCodeCredential = ExcludeVisualStudioCodeCredential;
                dacClone.ExcludeAzurePowerShellCredential = ExcludeAzurePowerShellCredential;
            }

            return clone;
        }
    }
}
