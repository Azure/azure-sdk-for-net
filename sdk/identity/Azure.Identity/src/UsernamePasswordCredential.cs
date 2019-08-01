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
    /// 
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
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="clientId"></param>
        /// <param name="tenantId"></param>
        public UsernamePasswordCredential(string username, SecureString password, string clientId, string tenantId)
            : this(username, password, clientId, tenantId, null)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="clientId"></param>
        /// <param name="tenantId"></param>
        /// <param name="options"></param>
        public UsernamePasswordCredential(string username, SecureString password, string clientId, string tenantId, IdentityClientOptions options)
        {
            _username = username ?? throw new ArgumentNullException(nameof(username));

            _password = password ?? throw new ArgumentNullException(nameof(password));

            _options = options ?? new IdentityClientOptions();

            _pipeline = HttpPipelineBuilder.Build(_options, bufferResponse: true);

            _pubApp = PublicClientApplicationBuilder.Create(clientId).WithHttpClientFactory(new HttpPipelineClientFactory(_pipeline)).WithTenantId(tenantId).Build();
        }

        /// <summary>
        /// Obtains a token for a user account, authenticating them using the given username and password.  Note: This will fail to 
        /// retrieve a token for users with MFA enabled.
        /// </summary>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Identity.UsernamePasswordCredential.GetToken");

            scope.Start();

            try
            {
                AuthenticationResult result = _pubApp.AcquireTokenByUsernamePassword(scopes, _username, _password).ExecuteAsync(cancellationToken).GetAwaiter().GetResult();

                return new AccessToken(result.AccessToken, result.ExpiresOn);
            }
            catch (Exception e)
            {
                scope.Failed(e);

                throw;
            }
        }

        /// <summary>
        /// Obtains a token for a user account, authenticating them using the given username and password.  Note: This will fail to 
        /// retrieve a token for users with MFA enabled.
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
