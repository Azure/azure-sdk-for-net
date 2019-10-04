// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IdentityModel.Tokens.Jwt;

namespace TrackOne
{
    /// <summary>
    /// Extends SecurityToken for JWT specific properties
    /// </summary>
    internal class JsonSecurityToken : SecurityToken
    {
        /// <summary>
        /// Creates a new instance of the <see cref="JsonSecurityToken"/> class.
        /// </summary>
        /// <param name="rawToken">Raw JSON Web Token string</param>
        /// <param name="audience">The audience</param>
        public JsonSecurityToken(string rawToken, string audience)
            : base(rawToken, GetExpirationDateTimeUtcFromToken(rawToken), audience, ClientConstants.JsonWebTokenType)
        {
        }

        private static DateTime GetExpirationDateTimeUtcFromToken(string token)
        {
            var jwtSecurityToken = new JwtSecurityToken(token);
            return jwtSecurityToken.ValidTo;
        }
    }
}
