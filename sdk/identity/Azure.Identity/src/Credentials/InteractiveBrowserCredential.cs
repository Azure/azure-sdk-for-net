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
    /// A <see cref="TokenCredential"/> implementation which launches the system default browser to interactively authenticate a user, and obtain an access token.
    /// The browser will only be launched to authenticate the user once, then will silently acquire access tokens through the users refresh token as long as it's valid.
    /// </summary>
    public class InteractiveBrowserCredential : TokenCredential
#if PREVIEW_FEATURE_FLAG
    , ISupportsProofOfPossession
#endif
    {
        internal string TenantId { get; }
        internal string[] AdditionallyAllowedTenantIds { get; }
        internal string ClientId { get; }
        internal string LoginHint { get; }
        internal BrowserCustomizationOptions BrowserCustomization { get; }
        internal MsalPublicClient Client { get; }
        internal CredentialPipeline Pipeline { get; }
        internal bool DisableAutomaticAuthentication { get; }
        internal AuthenticationRecord Record { get; private set; }
        internal string DefaultScope { get; }
        internal TenantIdResolverBase TenantIdResolver { get; }
        internal bool UseOperatingSystemAccount { get; }

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
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InteractiveBrowserCredential(string clientId)
            : this(null, clientId, null, null)
        { }

        /// <summary>
        /// Creates a new <see cref="InteractiveBrowserCredential"/> with the specified options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="tenantId">The tenant id of the application and the users to authenticate. Can be null in the case of multi-tenant applications.</param>
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
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
            UseOperatingSystemAccount = (options as IMsalPublicClientInitializerOptions)?.UseOperatingSystemAccount ?? false;
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
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the
        /// default browser is launched to authenticate the user. Acquired tokens are cached by the credential instance. Token lifetime and
        /// refreshing is handled automatically. Where possible, reuse credential instances to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, PopTokenRequestContext.FromTokenRequestContext(requestContext), cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the
        /// default browser is launched to authenticate the user. Acquired tokens are cached by the credential instance. Token lifetime and
        /// refreshing is handled automatically. Where possible, reuse credential instances to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, PopTokenRequestContext.FromTokenRequestContext(requestContext), cancellationToken).ConfigureAwait(false);
        }

#if PREVIEW_FEATURE_FLAG
        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the
        /// default browser is launched to authenticate the user. Acquired tokens are cached by the credential instance. Token lifetime and
        /// refreshing is handled automatically. Where possible, reuse credential instances to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public AccessToken GetToken(PopTokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the
        /// default browser is launched to authenticate the user. Acquired tokens are cached by the credential instance. Token lifetime and
        /// refreshing is handled automatically. Where possible, reuse credential instances to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public async ValueTask<AccessToken> GetTokenAsync(PopTokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }
#endif

        private async Task<AuthenticationRecord> AuthenticateImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope($"{nameof(InteractiveBrowserCredential)}.{nameof(Authenticate)}", requestContext);

            try
            {
                scope.Succeeded(await GetTokenViaBrowserLoginAsync(PopTokenRequestContext.FromTokenRequestContext(requestContext), async, cancellationToken).ConfigureAwait(false));

                return Record;
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, PopTokenRequestContext requestContext, CancellationToken cancellationToken)
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
                            .AcquireTokenSilentAsync(requestContext.Scopes, requestContext.Claims, PublicClientApplication.OperatingSystemAccount, tenantId, requestContext.IsCaeEnabled, async, cancellationToken)
                            .ConfigureAwait(false);
                        }
                        else
                        {
                            result = await Client
                                .AcquireTokenSilentAsync(requestContext.Scopes, requestContext.Claims, Record, tenantId, requestContext.IsCaeEnabled, async, cancellationToken)
                                .ConfigureAwait(false);
                        }

                        return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
                    }
                    catch (MsalUiRequiredException e)
                    {
                        inner = e;
                    }
                }

                if (DisableAutomaticAuthentication)
                {
                    throw new AuthenticationRequiredException(AuthenticationRequiredMessage, requestContext.ToTokenRequestContext(), inner);
                }

                return scope.Succeeded(await GetTokenViaBrowserLoginAsync(requestContext, async, cancellationToken).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async Task<AccessToken> GetTokenViaBrowserLoginAsync(PopTokenRequestContext context, bool async, CancellationToken cancellationToken)
        {
            Prompt prompt = LoginHint switch
            {
                null => Prompt.SelectAccount,
                _ => Prompt.NoPrompt
            };

            var tenantId = TenantIdResolver.Resolve(TenantId ?? Record?.TenantId, context, AdditionallyAllowedTenantIds);
            AuthenticationResult result = await Client
                .AcquireTokenInteractiveAsync(context.Scopes, context.Claims, prompt, LoginHint, tenantId, context.IsCaeEnabled, BrowserCustomization, context, async, cancellationToken)
                .ConfigureAwait(false);

            Record = new AuthenticationRecord(result, ClientId);
            return new AccessToken(result.AccessToken, result.ExpiresOn);
        }
    }
}
