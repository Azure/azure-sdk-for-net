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
    public class InteractiveBrowserCredential : TokenCredential
    {
        private readonly IPublicClientApplication _pubApp = null;
        private IAccount _account = null;
        private readonly AzureCredentialOptions _options;
        private readonly string _clientId;

        /// <summary>
        /// Creates a new InteractiveBrowserCredential with the specifeid options, which will authenticate users.
        /// </summary>
        public InteractiveBrowserCredential()
            : this(Constants.DeveloperSignOnClientId, null, null)
        {

        }

        /// <summary>
        /// Creates a new InteractiveBrowserCredential with the specifeid options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
        /// <param name="tenantId">The tenant id of the application and the users to authentiacte</param>
        /// TODO: need to link to info on how the application has to be created to authenticate users, for multiple applications
        /// <param name="options">The client options for the newly created DeviceCodeCredential</param>
        public InteractiveBrowserCredential(string clientId, string tenantId = default, AzureCredentialOptions options = default)
        {
            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            _options = options ??= new AzureCredentialOptions();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(_options);

            var pubAppBuilder = PublicClientApplicationBuilder.Create(_clientId).WithHttpClientFactory(new HttpPipelineClientFactory(pipeline)).WithRedirectUri("http://localhost");

            if (!string.IsNullOrEmpty(tenantId))
            {
                pubAppBuilder = pubAppBuilder.WithTenantId(tenantId);
            }

            _pubApp = pubAppBuilder.Build();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the default browser is launched to authenticate the user.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenAsync(requestContext, cancellationToken).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the default browser is launched to authenticate the user.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async Task<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            if (_account != null)
            {
                try
                {
                    AuthenticationResult result = await _pubApp.AcquireTokenSilent(requestContext.Scopes, _account).ExecuteAsync(cancellationToken).ConfigureAwait(false);

                    return new AccessToken(result.AccessToken, result.ExpiresOn);
                }
                catch (MsalUiRequiredException)
                {
                    return await GetTokenViaBrowserLoginAsync(requestContext.Scopes, cancellationToken).ConfigureAwait(false);
                }
            }
            else
            {
                return await GetTokenViaBrowserLoginAsync(requestContext.Scopes, cancellationToken).ConfigureAwait(false);
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
