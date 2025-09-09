// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="InteractiveBrowserCredential"/>.
    /// </summary>
    public class InteractiveBrowserCredentialOptions : TokenCredentialOptions, ISupportsTokenCachePersistenceOptions, ISupportsDisableInstanceDiscovery, ISupportsAdditionallyAllowedTenants, ISupportsTenantId
    {
        private string _tenantId;

        /// <summary>
        /// Prevents the <see cref="InteractiveBrowserCredential"/> from automatically prompting the user. If automatic authentication is disabled a AuthenticationRequiredException will be thrown from <see cref="InteractiveBrowserCredential.GetToken(Core.TokenRequestContext, CancellationToken)"/> and <see cref="InteractiveBrowserCredential.GetTokenAsync(Core.TokenRequestContext, CancellationToken)"/> in the case that
        /// user interaction is necessary. The application is responsible for handling this exception, and calling <see cref="InteractiveBrowserCredential.Authenticate(CancellationToken)"/> or <see cref="InteractiveBrowserCredential.AuthenticateAsync(CancellationToken)"/> to authenticate the user interactively.
        /// </summary>
        public bool DisableAutomaticAuthentication { get; set; }

        /// <summary>
        /// The tenant ID the user will be authenticated to. If not specified the user will be authenticated to the home tenant.
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
        /// The client ID of the application used to authenticate the user. It is recommended that developers register their applications and assign appropriate roles. For more information, visit <see href="https://aka.ms/azsdk/identity/AppRegistrationAndRoleAssignment"/>.
        /// If not specified, users will authenticate to an Azure development application, which is not recommended for production scenarios.
        /// </summary>
        public string ClientId { get; set; } = Constants.DeveloperSignOnClientId;

        /// <summary>
        /// Specifies the <see cref="TokenCachePersistenceOptions"/> to be used by the credential. If not options are specified, the token cache will not be persisted to disk.
        /// </summary>
        public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }

        /// <summary>
        /// Uri where the STS will call back the application with the security token. This parameter is not required if the caller is not using a custom <see cref="ClientId"/>. In
        /// the case that the caller is using their own <see cref="ClientId"/> the value must match the redirect url specified when creating the application registration.
        /// </summary>
        public Uri RedirectUri { get; set; }

        /// <summary>
        /// The <see cref="Identity.AuthenticationRecord"/> captured from a previous authentication.
        /// </summary>
        public AuthenticationRecord AuthenticationRecord { get; set; }

        /// <summary>
        /// Avoids the account prompt and pre-populates the username of the account to login.
        /// </summary>
        public string LoginHint { get; set; }

        /// <inheritdoc/>
        public bool DisableInstanceDiscovery { get; set; }

        /// <summary>
        /// The options for customizing the browser for interactive authentication.
        /// </summary>
        public BrowserCustomizationOptions BrowserCustomization { get; set; }

        internal override T Clone<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>()
        {
            var clone = base.Clone<T>();
            if (clone is InteractiveBrowserCredentialOptions ibcoClone)
            {
                ibcoClone.DisableAutomaticAuthentication = DisableAutomaticAuthentication;
                ibcoClone.TenantId = _tenantId;
                ibcoClone.AdditionallyAllowedTenants = AdditionallyAllowedTenants;
                ibcoClone.ClientId = ClientId;
                ibcoClone.TokenCachePersistenceOptions = TokenCachePersistenceOptions?.Clone();
                ibcoClone.RedirectUri = RedirectUri;
                ibcoClone.AuthenticationRecord = AuthenticationRecord;
                ibcoClone.LoginHint = LoginHint;
                ibcoClone.DisableInstanceDiscovery = DisableInstanceDiscovery;
                if (BrowserCustomization != null)
                {
                    ibcoClone.BrowserCustomization = new BrowserCustomizationOptions
                    {
                        ErrorMessage = BrowserCustomization.ErrorMessage,
                        SuccessMessage = BrowserCustomization.SuccessMessage,
                        UseEmbeddedWebView = BrowserCustomization.UseEmbeddedWebView ?? false
                    };
                }
            }
            return clone;
        }
    }
}
