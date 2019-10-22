// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// A <see cref="TokenCredential"/> implementation which launches the system default browser to interactively authenticate a user, and obtain an access token.
    /// The browser will only be launched to authenticate the user once, then will silently aquire access tokens through the users refresh token as long as it's valid.
    /// </summary>
    public class InteractiveBrowserCredential : TokenCredential, IExtendedTokenCredential
    {
        private readonly IPublicClientApplication _pubApp = null;
        private readonly CredentialPipeline _pipeline;
        private IAccount _account = null;

        /// <summary>
        /// Creates a new InteractiveBrowserCredential with the specifeid options, which will authenticate users.
        /// </summary>
        public InteractiveBrowserCredential()
            : this(Constants.DeveloperSignOnClientId, null, CredentialPipeline.GetInstance(null))
        {

        }

        /// <summary>
        /// Creates a new InteractiveBrowserCredential with the specifeid options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
        public InteractiveBrowserCredential(string clientId)
            : this(null, clientId, CredentialPipeline.GetInstance(null))
        {

        }

        /// <summary>
        /// Creates a new InteractiveBrowserCredential with the specifeid options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="tenantId">The tenant id of the application and the users to authenticate. Can be null in the case of multi-tenant applications.</param>
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
        /// TODO: need to link to info on how the application has to be created to authenticate users, for multiple applications
        /// <param name="options">The client options for the newly created DeviceCodeCredential</param>
        public InteractiveBrowserCredential(string tenantId, string clientId, TokenCredentialOptions options = default)
            : this(tenantId, clientId, CredentialPipeline.GetInstance(options))
        {
        }

        internal InteractiveBrowserCredential(string tenantId, string clientId, CredentialPipeline pipeline)
        {
            if (clientId is null) throw new ArgumentNullException(nameof(clientId));

            _pipeline = pipeline;

            _pubApp = _pipeline.CreateMsalPublicClient(clientId, tenantId, "http://localhost");
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the default browser is launched to authenticate the user.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(requestContext, cancellationToken).GetAwaiter().GetResult().GetTokenOrThrow();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the default browser is launched to authenticate the user.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async Task<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return (await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false)).GetTokenOrThrow();
        }

        ExtendedAccessToken IExtendedTokenCredential.GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenImplAsync(requestContext, cancellationToken).GetAwaiter().GetResult();
        }

        async Task<ExtendedAccessToken> IExtendedTokenCredential.GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async Task<ExtendedAccessToken> GetTokenImplAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.InteractiveBrowserCredential.GetToken", requestContext);
            try
            {
                if (_account != null)
                {
                    try
                    {
                        AuthenticationResult result = await _pubApp.AcquireTokenSilent(requestContext.Scopes, _account).ExecuteAsync(cancellationToken).ConfigureAwait(false);

                        return new ExtendedAccessToken(new AccessToken(result.AccessToken, result.ExpiresOn));
                    }
                    catch (MsalUiRequiredException)
                    {
                        AccessToken token = await GetTokenViaBrowserLoginAsync(requestContext.Scopes, cancellationToken).ConfigureAwait(false);

                        return new ExtendedAccessToken(token);
                    }
                }
                else
                {
                    AccessToken token = await GetTokenViaBrowserLoginAsync(requestContext.Scopes, cancellationToken).ConfigureAwait(false);

                    return new ExtendedAccessToken(token);
                }
            }
            catch (Exception e)
            {
                return new ExtendedAccessToken(scope.Failed(e));
            }
        }

        private async Task<AccessToken> GetTokenViaBrowserLoginAsync(string[] scopes, CancellationToken cancellationToken)
        {
            AuthenticationResult result = await _pubApp.AcquireTokenInteractive(scopes).WithPrompt(Prompt.SelectAccount).ExecuteAsync(cancellationToken).ConfigureAwait(false);

            _account = result.Account;

            return new AccessToken(result.AccessToken, result.ExpiresOn);
        }
    }
}
