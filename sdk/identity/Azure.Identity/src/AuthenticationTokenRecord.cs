// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// AuthenticationTokenRecord
    /// </summary>
    public class AuthenticationTokenRecord : AuthenticationRecord
    {
        internal AuthenticationTokenRecord() { }

        internal AuthenticationTokenRecord(AuthenticationResult authResult, string clientId)
            :base(authResult, clientId)
        {
            AccessToken = new AccessToken(authResult.AccessToken, authResult.ExpiresOn);
        }

        /// <summary>
        /// Access token
        /// </summary>
        public AccessToken AccessToken { get; set; }
    }
}
