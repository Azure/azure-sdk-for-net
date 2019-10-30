// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Identity.Client;
using System;
using System.Security;
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
        private readonly MsalPublicClient _client = null;
        private readonly CredentialPipeline _pipeline = null;
        private readonly string _username = null;
        private readonly SecureString _password;


        /// <summary>
        /// Protected constructor for mocking
        /// </summary>
        protected UsernamePasswordCredential()
        {

        }

        /// <summary>
        /// Creates an instance of the <see cref="UsernamePasswordCredential"/> with the details needed to authenticate against Azure Active Directory with a simple username
        /// and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password">The user account's username, also known as UPN.</param>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) ID or name.</param>
        /// <param name="clientId">The client (application) ID of an App Registration in the tenant.</param>
        public UsernamePasswordCredential(string username, string password, string tenantId, string clientId)
            : this(username, password, clientId, tenantId, (TokenCredentialOptions)null)
        {

        }

        /// <summary>
        /// Creates an instance of the <see cref="UsernamePasswordCredential"/> with the details needed to authenticate against Azure Active Directory with a simple username
        /// and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password">The user account's user name, UPN.</param>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) ID or name.</param>
        /// <param name="clientId">The client (application) ID of an App Registration in the tenant.</param>
        /// <param name="options">The client options for the newly created UsernamePasswordCredential</param>
        public UsernamePasswordCredential(string username, string password, string tenantId, string clientId, TokenCredentialOptions options)
            : this(username, password, tenantId, clientId, CredentialPipeline.GetInstance(options))
        {
        }

        internal UsernamePasswordCredential(string username, string password, string tenantId, string clientId, CredentialPipeline pipeline)
            : this(username, password, pipeline, pipeline.CreateMsalPublicClient(clientId, tenantId))
        {
        }

        internal UsernamePasswordCredential(string username, string password, CredentialPipeline pipeline, MsalPublicClient client)
        {
            _username = username ?? throw new ArgumentNullException(nameof(username));

            _password = (password != null) ? password.ToSecureString() : throw new ArgumentNullException(nameof(password));

            _pipeline = pipeline;

            _client = client;
        }

        /// <summary>
        /// Obtains a token for a user account, authenticating them using the given username and password.  Note: This will fail with
        /// an <see cref="AuthenticationFailedException"/> if the specified user account has MFA enabled. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenAsync(requestContext, cancellationToken).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Obtains a token for a user account, authenticating them using the given username and password.  Note: This will fail with
        /// an <see cref="AuthenticationFailedException"/> if the specified user account has MFA enabled. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.UsernamePasswordCredential.GetToken", requestContext);

            try
            {
                AuthenticationResult result = await _client.AcquireTokenByUsernamePasswordAsync(requestContext.Scopes, _username, _password, cancellationToken).ConfigureAwait(false);

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (Exception e)
            {
                throw scope.Failed(e);
            }
        }
    }
}
