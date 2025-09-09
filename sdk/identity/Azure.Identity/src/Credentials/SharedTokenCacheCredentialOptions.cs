// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.ComponentModel;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="SharedTokenCacheCredential"/> authentication.
    /// </summary>
    [Obsolete("SharedTokenCacheCredential is deprecated. Consider using other dev tool credentials, such as VisualStudioCredential.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SharedTokenCacheCredentialOptions : TokenCredentialOptions, ISupportsTokenCachePersistenceOptions, ISupportsDisableInstanceDiscovery, ISupportsTenantId
    {
        private string _tenantId;
        private TokenCachePersistenceOptions _tokenCachePersistenceOptions;

        internal static readonly TokenCachePersistenceOptions s_defaulTokenCachetPersistenceOptions = new TokenCachePersistenceOptions();

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
        /// Specifies the <see cref="TokenCachePersistenceOptions"/> to be used by the credential. Value cannot be null.
        /// </summary>
        public TokenCachePersistenceOptions TokenCachePersistenceOptions
        {
            get { return _tokenCachePersistenceOptions; }
            set
            {
                Argument.AssertNotNull(value, nameof(value));

                _tokenCachePersistenceOptions = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SharedTokenCacheCredentialOptions"/>.
        /// </summary>
        public SharedTokenCacheCredentialOptions()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="SharedTokenCacheCredentialOptions"/>.
        /// </summary>
        /// <param name="tokenCacheOptions">The <see cref="TokenCachePersistenceOptions"/> that will apply to the token cache used by this credential.</param>
        public SharedTokenCacheCredentialOptions(TokenCachePersistenceOptions tokenCacheOptions)
        {
            // if no tokenCacheOptions were specified we should use the default shared token cache
            TokenCachePersistenceOptions = tokenCacheOptions ?? s_defaulTokenCachetPersistenceOptions;
        }

        /// <inheritdoc/>
        public bool DisableInstanceDiscovery { get; set; }
    }
}
