// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


namespace Azure.Core
{
    /// <summary>
    /// Contains the details of an authentication token request
    /// </summary>
    public readonly struct TokenRequest
    {
        /// <summary>
        /// Creates a new TokenRequest with the specified scopes
        /// </summary>
        /// <param name="scopes">The scopes required for the token</param>
        public TokenRequest(string[] scopes)
        {
            Scopes = scopes;
        }

        /// <summary>
        /// The scopes required for the token
        /// </summary>
        public string[] Scopes { get; }
    }
}
