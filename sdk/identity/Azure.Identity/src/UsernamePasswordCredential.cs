// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    ///  Enables authentication to Azure Active Directory using a user's  username and password. If the user has MFA enabled this
    ///  credential will fail to get a token throwing an <see cref="AuthenticationFailedException"/>. Also, this credential requires a high degree of
    ///  trust and is not recommended outside of prototyping when more secure credentials can be used.
    /// </summary>
    public class UsernamePasswordCredential : TokenCredential
    {
        private IPublicClientApplication _pubApp = null;
        private HttpPipeline _pipeline = null;
        private IdentityClientOptions _options;
        private string _username = null;
        private SecureString _password;


        /// <summary>
        /// Protected constructor for mocking
        /// </summary>
        protected UsernamePasswordCredential()
        {

        }

        /// <summary>
        /// Creates an instance of the UsernamePasswordCredential with the details needed to authenticate against Azure Active Directory with a simple username
        /// and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password">The user account's user name, UPN.</param>
        /// <param name="clientId">The client (application) ID of an App Registration in the tenant.</param>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) ID or name.</param>
        public UsernamePasswordCredential(string username, SecureString password, string clientId, string tenantId)
            : this(username, password, clientId, tenantId, null)
        {

        }

        /// <summary>
        /// Creates an instance of the UsernamePasswordCredential with the details needed to authenticate against Azure Active Directory with a simple username
        /// and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password">The user account's user name, UPN.</param>
        /// <param name="clientId">The client (application) ID of an App Registration in the tenant.</param>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) ID or name.</param>
        /// <param name="options">The client options for the newly created UsernamePasswordCredential</param>
        public UsernamePasswordCredential(string username, SecureString password, string clientId, string tenantId, IdentityClientOptions options)
        {
            _username = username ?? throw new ArgumentNullException(nameof(username));

            _password = password ?? throw new ArgumentNullException(nameof(password));

            _options = options ?? new IdentityClientOptions();

            _pipeline = HttpPipelineBuilder.Build(_options, bufferResponse: true);

            _pubApp = PublicClientApplicationBuilder.Create(clientId).WithHttpClientFactory(new HttpPipelineClientFactory(_pipeline)).WithTenantId(tenantId).Build();
        }

        /// <summary>
        /// Obtains a token for a user account, authenticating them using the given username and password.  Note: This will fail with
        /// an <see cref="AuthenticationFailedException"/> if the specified user acound has MFA enabled.
        /// </summary>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            return GetTokenAsync(scopes, cancellationToken).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Obtains a token for a user account, authenticating them using the given username and password.  Note: This will fail with
        /// an <see cref="AuthenticationFailedException"/> if the specified user acound has MFA enabled.
        /// </summary>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Identity.UsernamePasswordCredential.GetToken");

            scope.Start();

            try
            {
                AuthenticationResult result = await _pubApp.AcquireTokenByUsernamePassword(scopes, _username, _password).ExecuteAsync(cancellationToken).ConfigureAwait(false);

                return new AccessToken(result.AccessToken, result.ExpiresOn);
            }
            catch (Exception e)
            {
                scope.Failed(e);

                throw;
            }
        }
    }
}
