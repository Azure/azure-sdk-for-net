// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Authenticates with the access token supplied at construction time.
    /// </summary>/
    public class StaticTokenCredential : TokenCredential
    {
        private readonly AccessToken _accessToken;
        private readonly CredentialPipeline _pipeline;

        /// <summary>
        /// Protected constructor for mocking.
        /// </summary>
        protected StaticTokenCredential()
        {
        }

        /// <summary>
        /// Creates an instance of the StaticTokenCredential.
        /// </summary>
        /// <param name="tokenString">tokenString The string of prefetched token.</param>
        public StaticTokenCredential(string tokenString)
            : this(tokenString, null)
        {
        }

        /// <summary>
        /// Creates an instance of the StaticTokenCredential.
        /// </summary>
        /// <param name="accessToken">accessToken The prefetched token.</param>
        public StaticTokenCredential(AccessToken accessToken)
           : this(accessToken, null)
        {
        }

        /// <summary>
        /// Creates an instance of the StaticTokenCredential.
        /// </summary>
        /// <param name="tokenString">tokenString The string of prefetched token.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public StaticTokenCredential(string tokenString, TokenCredentialOptions options)
            : this(new AccessToken(tokenString, DateTimeOffset.UtcNow.AddDays(1)), options, null)
        {
        }

        /// <summary>
        /// Creates an instance of the StaticTokenCredential.
        /// </summary>
        /// <param name="accessToken">accessToken The prefetched token.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public StaticTokenCredential(AccessToken accessToken, TokenCredentialOptions options)
            : this (accessToken, options, null)
        {
        }

        internal StaticTokenCredential(AccessToken accessToken, TokenCredentialOptions options, CredentialPipeline pipeline)
        {
            _accessToken = accessToken;
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client secret to authenticate. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("StaticTokenCredential.GetToken", requestContext);

            try
            {
                return new ValueTask<AccessToken>(scope.Succeeded(_accessToken));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client secret to authenticate. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("StaticTokenCredential.GetToken", requestContext);

            try
            {
                return scope.Succeeded(_accessToken);
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }
    }
}