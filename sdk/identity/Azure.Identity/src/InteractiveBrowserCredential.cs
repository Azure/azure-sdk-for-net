// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// A <see cref="TokenCredential"/> implementation which launches the system default browser to interactively authenticate a user, and obtain an access token.
    /// The browser will only be launched to authenticate the user once, then will silently acquire access tokens through the users refresh token as long as it's valid.
    /// </summary>
    public class InteractiveBrowserCredential : TokenCredential
    {
        internal string ClientId { get; }
        internal MsalPublicClient Client {get;}
        internal CredentialPipeline Pipeline { get; }
        internal bool DisableAutomaticAuthentication { get; }
        internal AuthenticationRecord Record { get; private set; }

        private const string AuthenticationRequiredMessage = "Interactive authentication is needed to acquire token. Call Authenticate to interactively authenticate.";
        private const string NoDefaultScopeMessage = "Authenticating in this environment requires specifying a TokenRequestContext.";

        /// <summary>
        /// Creates a new <see cref="InteractiveBrowserCredential"/> with the specified options, which will authenticate users.
        /// </summary>
        public InteractiveBrowserCredential()
            : this(null, Constants.DeveloperSignOnClientId, null, null)
        {
        }

        /// <summary>
        /// Creates a new <see cref="InteractiveBrowserCredential"/> with the specified options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="options">The client options for the newly created <see cref="InteractiveBrowserCredential"/>.</param>
        public InteractiveBrowserCredential(InteractiveBrowserCredentialOptions options)
            : this(options?.TenantId, options?.ClientId ?? Constants.DeveloperSignOnClientId, options, null)
        {
            DisableAutomaticAuthentication = options?.DisableAutomaticAuthentication ?? false;
            Record = options?.AuthenticationRecord;
        }

        /// <summary>
        /// Creates a new <see cref="InteractiveBrowserCredential"/> with the specified options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InteractiveBrowserCredential(string clientId)
            : this(null, clientId, null, null)
        {
        }

        /// <summary>
        /// Creates a new <see cref="InteractiveBrowserCredential"/> with the specified options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="tenantId">The tenant id of the application and the users to authenticate. Can be null in the case of multi-tenant applications.</param>
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
        /// TODO: need to link to info on how the application has to be created to authenticate users, for multiple applications
        /// <param name="options">The client options for the newly created <see cref="InteractiveBrowserCredential"/>.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InteractiveBrowserCredential(string tenantId, string clientId, TokenCredentialOptions options = default)
            : this(Validations.ValidateTenantId(tenantId, nameof(tenantId), allowNull:true), clientId, options, null, null)
        {
        }

        internal InteractiveBrowserCredential(string tenantId, string clientId, TokenCredentialOptions options, CredentialPipeline pipeline)
            : this(tenantId, clientId, options, pipeline, null)
        {
        }

        internal InteractiveBrowserCredential(string tenantId, string clientId, TokenCredentialOptions options, CredentialPipeline pipeline, MsalPublicClient client)
        {
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            Pipeline = pipeline ?? CredentialPipeline.GetInstance(options);

            var redirectUrl = (options as InteractiveBrowserCredentialOptions)?.RedirectUri?.AbsoluteUri ?? Constants.DefaultRedirectUrl;

            Client = client ?? new MsalPublicClient(Pipeline, tenantId, clientId, redirectUrl, options as ITokenCacheOptions);
        }

        /// <summary>
        /// Interactively authenticates a user via the default browser.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The result of the authentication request, containing the acquired <see cref="AccessToken"/>, and the <see cref="AuthenticationRecord"/> which can be used to silently authenticate the account.</returns>
        public virtual AuthenticationRecord Authenticate(CancellationToken cancellationToken = default)
        {
            // get the default scope for the authority, throw if no default scope exists
            string defaultScope = AzureAuthorityHosts.GetDefaultScope(Pipeline.AuthorityHost) ?? throw new CredentialUnavailableException(NoDefaultScopeMessage);

            return Authenticate(new TokenRequestContext(new[] { defaultScope }), cancellationToken);
        }

        /// <summary>
        /// Interactively authenticates a user via the default browser.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The result of the authentication request, containing the acquired <see cref="AccessToken"/>, and the <see cref="AuthenticationRecord"/> which can be used to silently authenticate the account.</returns>
        public virtual async Task<AuthenticationRecord> AuthenticateAsync(CancellationToken cancellationToken = default)
        {
            // get the default scope for the authority, throw if no default scope exists
            string defaultScope = AzureAuthorityHosts.GetDefaultScope(Pipeline.AuthorityHost) ?? throw new CredentialUnavailableException(NoDefaultScopeMessage);

            return await AuthenticateAsync(new TokenRequestContext(new string[] { defaultScope }), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Interactively authenticates a user via the default browser.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual AuthenticationRecord Authenticate(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return AuthenticateImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Interactively authenticates a user via the default browser.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual async Task<AuthenticationRecord> AuthenticateAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await AuthenticateImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the default browser is launched to authenticate the user. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the default browser is launched to authenticate the user. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
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
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope($"{nameof(InteractiveBrowserCredential)}.{nameof(Authenticate)}", requestContext);

            try
            {
                scope.Succeeded(await GetTokenViaBrowserLoginAsync(requestContext.Scopes, async, cancellationToken).ConfigureAwait(false));

                return Record;
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope($"{nameof(InteractiveBrowserCredential)}.{nameof(GetToken)}", requestContext);

            try
            {
                Exception inner = null;

                if (Record != null)
                {
                    try
                    {
                        AuthenticationResult result = await Client.AcquireTokenSilentAsync(requestContext.Scopes, Record, async, cancellationToken).ConfigureAwait(false);

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

                return scope.Succeeded(await GetTokenViaBrowserLoginAsync(requestContext.Scopes, async, cancellationToken).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async Task<AccessToken> GetTokenViaBrowserLoginAsync(string[] scopes, bool async, CancellationToken cancellationToken)
        {
            AuthenticationResult result = await Client.AcquireTokenInteractiveAsync(scopes, Prompt.SelectAccount, async, cancellationToken).ConfigureAwait(false);

            Record = new AuthenticationRecord(result, ClientId);

            return new AccessToken(result.AccessToken, result.ExpiresOn);
        }
    }
}
