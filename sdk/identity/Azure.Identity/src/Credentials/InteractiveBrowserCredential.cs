// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// A <see cref="TokenCredential"/> implementation which launches the system default browser to interactively authenticate a user and obtain an access token.
    /// The browser will only be launched to authenticate the user once, then will silently acquire access tokens through the user's refresh token as long as it's valid.
    /// For usage instructions, see <see href="https://aka.ms/azsdk/net/identity/interactivebrowsercredential/usage">Interactive browser authentication</see>.
    /// </summary>
    /// <remarks>Implements the <see href="https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow">OAuth 2.0 authorization code flow</see>.</remarks>
    public class InteractiveBrowserCredential : TokenCredential
    {
        internal string TenantId { get; }
        internal string[] AdditionallyAllowedTenantIds { get; }
        internal string ClientId { get; }
        internal string LoginHint { get; }
        internal BrowserCustomizationOptions BrowserCustomization { get; }
        internal MsalPublicClient Client { get; }
        internal CredentialPipeline Pipeline { get; }
        internal bool DisableAutomaticAuthentication { get; }
        internal AuthenticationRecord Record { get; set; }
        internal string DefaultScope { get; }
        internal TenantIdResolverBase TenantIdResolver { get; }
        internal bool UseOperatingSystemAccount { get; }
        internal bool IsChainedCredential { get; set; }

        private const string AuthenticationRequiredMessage = "Interactive authentication is needed to acquire token. Call Authenticate to interactively authenticate.";
        private const string NoDefaultScopeMessage = "Authenticating in this environment requires specifying a TokenRequestContext.";

        /// <summary>
        /// Creates a new <see cref="InteractiveBrowserCredential"/> with the specified options, which will authenticate users.
        /// </summary>
        public InteractiveBrowserCredential()
            : this(null, Constants.DeveloperSignOnClientId, null, null)
        { }

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
        /// <param name="clientId">The client id of the application to which the users will authenticate. It is recommended that developers register their applications and assign appropriate roles. For more information, visit <see href="https://aka.ms/azsdk/identity/AppRegistrationAndRoleAssignment"/>. If not specified, users will authenticate to an Azure development application, which is not recommended for production scenarios.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InteractiveBrowserCredential(string clientId)
            : this(null, clientId, null, null)
        { }

        /// <summary>
        /// Creates a new <see cref="InteractiveBrowserCredential"/> with the specified options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="tenantId">The tenant id of the application and the users to authenticate. Can be null in the case of multi-tenant applications.</param>
        /// <param name="clientId">The client id of the application to which the users will authenticate. It is recommended that developers register their applications and assign appropriate roles. For more information, visit <see href="https://aka.ms/azsdk/identity/AppRegistrationAndRoleAssignment"/>. If not specified, users will authenticate to an Azure development application, which is not recommended for production scenarios.</param>
        /// TODO: need to link to info on how the application has to be created to authenticate users, for multiple applications
        /// <param name="options">The client options for the newly created <see cref="InteractiveBrowserCredential"/>.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InteractiveBrowserCredential(string tenantId, string clientId, TokenCredentialOptions options = default)
            : this(Validations.ValidateTenantId(tenantId, nameof(tenantId), allowNull: true), clientId, options, null, null)
        {
            Argument.AssertNotNull(clientId, nameof(clientId));
        }

        internal InteractiveBrowserCredential(string tenantId, string clientId, TokenCredentialOptions options, CredentialPipeline pipeline)
            : this(tenantId, clientId, options, pipeline, null)
        {
            Argument.AssertNotNull(clientId, nameof(clientId));
        }

        internal InteractiveBrowserCredential(string tenantId, string clientId, TokenCredentialOptions options, CredentialPipeline pipeline, MsalPublicClient client)
        {
            ClientId = clientId;
            TenantId = tenantId;
            Pipeline = pipeline ?? CredentialPipeline.GetInstance(options);
            LoginHint = (options as InteractiveBrowserCredentialOptions)?.LoginHint;
            var redirectUrl = (options as InteractiveBrowserCredentialOptions)?.RedirectUri?.AbsoluteUri ?? Constants.DefaultRedirectUrl;
            DefaultScope = AzureAuthorityHosts.GetDefaultScope(options?.AuthorityHost ?? AzureAuthorityHosts.GetDefault());
            Client = client ?? new MsalPublicClient(Pipeline, tenantId, clientId, redirectUrl, options);
            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
            Record = (options as InteractiveBrowserCredentialOptions)?.AuthenticationRecord;
            BrowserCustomization = (options as InteractiveBrowserCredentialOptions)?.BrowserCustomization;
            UseOperatingSystemAccount = (options as IMsalPublicClientInitializerOptions)?.UseDefaultBrokerAccount ?? false;
            IsChainedCredential = options?.IsChainedCredential ?? false;
        }

        /// <summary>
        /// Interactively authenticates a user via the default browser.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The result of the authentication request, containing the acquired <see cref="AccessToken"/>, and the <see cref="AuthenticationRecord"/> which can be used to silently authenticate the account.</returns>
        public virtual AuthenticationRecord Authenticate(CancellationToken cancellationToken = default)
        {
            // throw if no default scope exists
            if (DefaultScope == null)
            {
                throw new CredentialUnavailableException(NoDefaultScopeMessage);
            }
            return Authenticate(new TokenRequestContext(new[] { DefaultScope }), cancellationToken);
        }

        /// <summary>
        /// Interactively authenticates a user via the default browser. The resulting <see cref="AuthenticationRecord"/> will automatically be used in subsequent calls to <see cref="GetTokenAsync(TokenRequestContext, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The result of the authentication request, containing the acquired <see cref="AccessToken"/>, and the <see cref="AuthenticationRecord"/> which can be used to silently authenticate the account.</returns>
        public virtual async Task<AuthenticationRecord> AuthenticateAsync(CancellationToken cancellationToken = default)
        {
            // throw if no default scope exists
            if (DefaultScope == null)
            {
                throw new CredentialUnavailableException(NoDefaultScopeMessage);
            }
            return await AuthenticateAsync(new TokenRequestContext(new string[] { DefaultScope }), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Interactively authenticates a user via the default browser. The resulting <see cref="AuthenticationRecord"/> will automatically be used in subsequent calls to <see cref="GetToken(TokenRequestContext, CancellationToken)"/>.
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
        /// Silently obtains an <see cref="AccessToken"/> for a user account if the user has already authenticated. Otherwise, the default browser is launched
        /// to authenticate the user. Acquired tokens are <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see> by the
        /// credential instance. Token lifetime and refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Silently obtains an <see cref="AccessToken"/> for a user account if the user has already authenticated. Otherwise, the default browser is launched
        /// to authenticate the user. Acquired tokens are <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see> by the
        /// credential instance. Token lifetime and refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async Task<AuthenticationRecord> AuthenticateImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope($"{nameof(InteractiveBrowserCredential)}.{nameof(Authenticate)}", requestContext);

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
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope($"{nameof(InteractiveBrowserCredential)}.{nameof(GetToken)}", requestContext);

            try
            {
                Exception inner = null;

                var tenantId = TenantIdResolver.Resolve(TenantId ?? Record?.TenantId, requestContext, AdditionallyAllowedTenantIds);
                if (Record is not null || UseOperatingSystemAccount)
                {
                    try
                    {
                        AuthenticationResult result;
                        if (Record is null)
                        {
                            result = await Client
                                .AcquireTokenSilentAsync(
                                    requestContext.Scopes,
                                    requestContext.Claims,
                                    PublicClientApplication.OperatingSystemAccount,
                                    tenantId,
                                    requestContext.IsCaeEnabled,
                                    requestContext,
                                    async,
                                    cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            result = await Client
                                .AcquireTokenSilentAsync(
                                    requestContext.Scopes,
                                    requestContext.Claims,
                                    Record,
                                    tenantId,
                                    requestContext.IsCaeEnabled,
                                    requestContext,
                                    async,
                                    cancellationToken)
                                .ConfigureAwait(false);
                        }

                        return scope.Succeeded(result.ToAccessToken());
                    }
                    catch (MsalUiRequiredException e)
                    {
                        if ((UseOperatingSystemAccount && IsChainedCredential) || (Record is not null && IsChainedCredential))
                        {
                            throw;
                        }
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
                throw scope.FailWrapAndThrow(e, null, IsChainedCredential);
            }
        }

        private async Task<AccessToken> GetTokenViaBrowserLoginAsync(TokenRequestContext context, bool async, CancellationToken cancellationToken)
        {
            Prompt prompt = LoginHint switch
            {
                null => Prompt.SelectAccount,
                _ => Prompt.NoPrompt
            };

            var tenantId = TenantIdResolver.Resolve(TenantId ?? Record?.TenantId, context, AdditionallyAllowedTenantIds);
            AuthenticationResult result = await Client
                .AcquireTokenInteractiveAsync(
                    context.Scopes,
                    context.Claims,
                    prompt,
                    LoginHint,
                    tenantId,
                    context.IsCaeEnabled,
                    BrowserCustomization,
                    context,
                    async,
                    cancellationToken)
                .ConfigureAwait(false);

            Record = new AuthenticationRecord(result, ClientId);
            return result.ToAccessToken();
        }
    }
}
