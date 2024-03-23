// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="InteractiveBrowserCredential"/>.
    /// </summary>
    public class InteractiveBrowserCredentialOptions : TokenCredentialOptions, ISupportsTokenCachePersistenceOptions, ISupportsDisableInstanceDiscovery, ISupportsAdditionallyAllowedTenants
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
        /// The client ID of the application used to authenticate the user. If not specified the user will be authenticated with an Azure development application.
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
    }
}
