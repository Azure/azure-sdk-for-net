// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest.ClientRuntime.Properties;

namespace Microsoft.Rest
{
    /// <summary>
    /// Token based credentials for use with a REST Service Client.
    /// </summary>
    public class TokenCredentials : ServiceClientCredentials
    {
        /// <summary>
        /// The bearer token type, as serialized in an http Authentication header.
        /// </summary>
        private const string BearerTokenType = "Bearer";

        /// <summary>
        /// Gets or sets secure token used to authenticate against Microsoft Azure API. 
        /// No anonymous requests are allowed.
        /// </summary>
        protected ITokenProvider TokenProvider { get; private set; }

        /// <summary>
        /// Gets Tenant ID
        /// </summary>
        public string TenantId { get; private set; }

        /// <summary>
        /// Gets UserInfo.DisplayableId
        /// </summary>
        public string CallerId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenCredentials"/>
        /// class with the given 'Bearer' token.
        /// </summary>
        /// <param name="token">Valid JSON Web Token (JWT).</param>
        public TokenCredentials(string token)
            : this(token, BearerTokenType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenCredentials"/>
        /// class with the given token and token type.
        /// </summary>
        /// <param name="token">Valid JSON Web Token (JWT).</param>
        /// <param name="tokenType">The token type of the given token.</param>
        public TokenCredentials(string token, string tokenType) 
            : this(new StringTokenProvider(token, tokenType))
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("token");
            }
            if (string.IsNullOrEmpty(tokenType))
            {
                throw new ArgumentNullException("tokenType");
            }
        }

        /// <summary>
        /// Create an access token credentials object, given an interface to a token source.
        /// </summary>
        /// <param name="tokenProvider">The source of tokens for these credentials.</param>
        public TokenCredentials(ITokenProvider tokenProvider)
        {
            if (tokenProvider == null)
            {
                throw new ArgumentNullException("tokenProvider");
            }

            this.TokenProvider = tokenProvider;
        }

        /// <summary>
        /// Create an access token credentials object, given an interface to a token source.
        /// </summary>
        /// <param name="tokenProvider">The source of tokens for these credentials.</param>
        /// <param name="tenantId">Tenant ID from AuthenticationResult</param>
        /// <param name="callerId">UserInfo.DisplayableId field from AuthenticationResult</param>
        public TokenCredentials(ITokenProvider tokenProvider, string tenantId, string callerId)
            : this(tokenProvider)
        {
            this.TenantId = tenantId;
            this.CallerId = callerId;
        }

        /// <summary>
        /// Apply the credentials to the HTTP request.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// Task that will complete when processing has completed.
        /// </returns>
        public async override Task ProcessHttpRequestAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (TokenProvider == null)
            {
                throw new InvalidOperationException(Resources.TokenProviderCannotBeNull);
            }

            request.Headers.Authorization = await TokenProvider.GetAuthenticationHeaderAsync(cancellationToken).ConfigureAwait(false);
            await base.ProcessHttpRequestAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}