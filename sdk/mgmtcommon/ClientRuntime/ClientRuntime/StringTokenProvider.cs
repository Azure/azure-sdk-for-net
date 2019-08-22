// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Rest
{
    /// <summary>
    /// A simple token provider that always provides a static access token.
    /// </summary>
    public sealed class StringTokenProvider : ITokenProvider
    {
        private string _accessToken;
        private string _type;

        /// <summary>
        /// Create a token provider for the given token type that returns the given 
        /// access token.
        /// </summary>
        /// <param name="accessToken">The access token to return.</param>
        /// <param name="tokenType">The token type of the given access token.</param>
        public StringTokenProvider(string accessToken, string tokenType)
        {
            _accessToken = accessToken;
            _type = tokenType;
        }

        /// <summary>
        /// Gets the token type of this access token.
        /// </summary>
        public string TokenType
        {
            get { return _type; }
        }

        /// <summary>
        /// Returns the static access token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for this action.  
        /// This will not be used since the returned token is static.</param>
        /// <returns>The access token.</returns>
        public Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new AuthenticationHeaderValue(_type, _accessToken));
        }
    }
}
