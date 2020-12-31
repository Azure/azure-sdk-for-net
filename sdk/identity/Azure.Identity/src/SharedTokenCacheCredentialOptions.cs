﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="SharedTokenCacheCredential"/> authentication.
    /// </summary>
    public class SharedTokenCacheCredentialOptions : TokenCredentialOptions, ITokenCacheOptions
    {
        private string _tenantId;

        /// <summary>
        /// The client id of the application registration used to authenticate users in the cache.
        /// </summary>
        public string ClientId { get; set; } = Constants.DeveloperSignOnClientId;

        /// <summary>
        /// Specifies the preferred authentication account username, or UPN, to be retrieved from the shared token cache for single sign on authentication with
        /// development tools, in the case multiple accounts are found in the shared token.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Specifies the tenant id of the preferred authentication account, to be retrieved from the shared token cache for single sign on authentication with
        /// development tools, in the case multiple accounts are found in the shared token.
        /// </summary>
        public string TenantId
        {
            get { return _tenantId; }
            set { _tenantId = Validations.ValidateTenantId(value, allowNull: true); }
        }

        /// <summary>
        /// When set to true the <see cref="SharedTokenCacheCredential"/> can be used to authenticate to tenants other than the home tenant, requiring <see cref="Username"/> and <see cref="TenantId"/> also to be specified as well.
        /// </summary>
        public bool EnableGuestTenantAuthentication { get; set; }

        /// <summary>
        /// The <see cref="Identity.AuthenticationRecord"/> captured from a previous authentication with an interactive credential, such as the <see cref="InteractiveBrowserCredential"/> or <see cref="DeviceCodeCredential"/>.
        /// </summary>
        public AuthenticationRecord AuthenticationRecord { get; set; }

        /// <summary>
        /// Specifies the <see cref="TokenCache"/> to be used by the credential.
        /// </summary>
        public TokenCache TokenCache { get; }

        /// <summary>
        /// SharedTokenCacheCredentialOptions
        /// </summary>
        public SharedTokenCacheCredentialOptions()
            :this(null)
        { }

        /// <summary>
        /// SharedTokenCacheCredentialOptions
        /// </summary>
        /// <param name="tokenCache"></param>
        public SharedTokenCacheCredentialOptions(TokenCache tokenCache)
        {
            TokenCache = tokenCache ?? new PersistentTokenCache();
        }
    }
}
