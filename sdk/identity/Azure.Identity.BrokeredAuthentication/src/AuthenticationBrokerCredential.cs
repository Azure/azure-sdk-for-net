// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity.BrokeredAuthentication
{
    /// <summary>
    /// A <see cref="TokenCredential"/> implementation which launches the system authentication broker to authenticate. If no system broker is available the credential will fallback to the system browser to authenticate the user.
    /// </summary>
    public class AuthenticationBrokerCredential : TokenCredential
    {
        internal string TenantId { get; }
        internal string ClientId { get; }
        internal string LoginHint { get; }
        internal Uri RedirectUri { get; }
        internal MsalPublicClient Client { get; }
        internal CredentialPipeline Pipeline { get; }
        internal bool DisableAutomaticAuthentication { get; }
        internal AuthenticationRecord Record { get; private set; }

        private const string AuthenticationRequiredMessage = "Interactive authentication is needed to acquire token. Call Authenticate to interactively authenticate.";
        private const string NoDefaultScopeMessage = "Authenticating in this environment requires specifying a TokenRequestContext.";

        /// <summary>
        /// Creates a new <see cref="AuthenticationBrokerCredential"/> with the specified options, which will authenticate users via the system authentication broker.
        /// </summary>
        public AuthenticationBrokerCredential()
            : this(null)
        { }

        /// <summary>
        /// Creates a new <see cref="AuthenticationBrokerCredential"/> with the specified options, which will authenticate users via the system authentication broker.
        /// </summary>
        /// <param name="options">The client options for the newly created <see cref="AuthenticationBrokerCredential"/>.</param>
        public AuthenticationBrokerCredential(AuthenticationBrokerCredentialOptions options)
        {
            options = options ?? new AuthenticationBrokerCredentialOptions();
            ClientId = options.ClientId ?? Constants.DeveloperSignOnClientId;
            TenantId = options.TenantId;
            LoginHint = options.LoginHint;
            RedirectUri = options.RedirectUri;
            DisableAutomaticAuthentication = options.DisableAutomaticAuthentication;
            Record = options.AuthenticationRecord;
            Pipeline = options.CredentialPipeline;

            var redirectUrl = RedirectUri?.AbsoluteUri ?? Constants.DefaultRedirectUrl;

            Client = options.Client ?? new MsalPublicClient(Pipeline, TenantId, ClientId, redirectUrl, options as ITokenCacheOptions, false, true);
        }

        /// <summary>
        /// Interactively authenticates a user via the system authentication broker. If no system broker is available the credential will fallback to the system browser to authenticate the user.
        /// The resulting <see cref="AuthenticationRecord"/> will automatically be used in subsequent calls to <see cref="GetToken"/>.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual AuthenticationRecord Authenticate(CancellationToken cancellationToken = default)
        {
            // get the default scope for the authority, throw if no default scope exists
            string defaultScope = ScopeUtilities.GetDefaultScope(Pipeline.AuthorityHost) ?? throw new CredentialUnavailableException(NoDefaultScopeMessage);

            return Authenticate(new TokenRequestContext(new[] { defaultScope }), cancellationToken);
        }

        /// <summary>
        /// Interactively authenticates a user via the system authentication broker. If no system broker is available the credential will fallback to the system browser to authenticate the user.
        /// The resulting <see cref="AuthenticationRecord"/> will automatically be used in subsequent calls to <see cref="GetToken"/>.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual async Task<AuthenticationRecord> AuthenticateAsync(CancellationToken cancellationToken = default)
        {
            // get the default scope for the authority, throw if no default scope exists
            string defaultScope = ScopeUtilities.GetDefaultScope(Pipeline.AuthorityHost) ?? throw new CredentialUnavailableException(NoDefaultScopeMessage);

            return await AuthenticateAsync(new TokenRequestContext(new string[] { defaultScope }), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Interactively authenticates a user via the system authentication broker. If no system broker is available the credential will fallback to the system browser to authenticate the user.
        /// The resulting <see cref="AuthenticationRecord"/> will automatically be used in subsequent calls to <see cref="GetToken"/>.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual AuthenticationRecord Authenticate(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return AuthenticateImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Interactively authenticates a user via the system authentication broker. If no system broker is available the credential will fallback to the system browser to authenticate the user.
        /// The resulting <see cref="AuthenticationRecord"/> will automatically be used in subsequent calls to <see cref="GetToken"/>.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual async Task<AuthenticationRecord> AuthenticateAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await AuthenticateImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the system authentication broker is launched to authenticate the user. If no system broker is available the credential will fallback to the system browser to authenticate the user.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the system authentication broker is launched to authenticate the user. If no system broker is available the credential will fallback to the system browser to authenticate the user.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async Task<AuthenticationRecord> AuthenticateImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope($"{nameof(AuthenticationBrokerCredential)}.{nameof(Authenticate)}", requestContext);

            try
            {
                scope.Succeeded(await GetTokenViaBrowserLoginAsync(requestContext, async, cancellationToken).ConfigureAwait(false));

                return Record;
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope($"{nameof(AuthenticationBrokerCredential)}.{nameof(GetToken)}", requestContext);

            try
            {
                Exception inner = null;

                if (Record != null)
                {
                    try
                    {
                        var tenantId = TenantIdResolver.Resolve(TenantId ?? Record.TenantId, requestContext);
                        AuthenticationResult result = await Client
                            .AcquireTokenSilentAsync(requestContext.Scopes, requestContext.Claims, Record, tenantId, async, cancellationToken)
                            .ConfigureAwait(false);

                        return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
                    }
                    catch (MsalUiRequiredException e)
                    {
                        inner = e;
                    }
                }

                if (DisableAutomaticAuthentication)
                {
                    throw new AuthenticationRequiredException(AuthenticationRequiredMessage, requestContext, inner);
                }

                return scope.Succeeded(await GetTokenViaBrowserLoginAsync(requestContext, async, cancellationToken).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async Task<AccessToken> GetTokenViaBrowserLoginAsync(TokenRequestContext context, bool async, CancellationToken cancellationToken)
        {
            Prompt prompt = LoginHint switch
            {
                null => Prompt.SelectAccount,
                _ => Prompt.NoPrompt
            };

            var tenantId = TenantIdResolver.Resolve(TenantId ?? Record?.TenantId, context);
            AuthenticationResult result = await Client
                .AcquireTokenInteractiveAsync(context.Scopes, context.Claims, prompt, LoginHint, tenantId, async, cancellationToken)
                .ConfigureAwait(false);

            Record = IdentityModelFactory.AuthenticationRecord(result.Account.Username, result.Account.Environment, result.Account.HomeAccountId.Identifier, result.TenantId, ClientId);
            return new AccessToken(result.AccessToken, result.ExpiresOn);
        }
    }
}
