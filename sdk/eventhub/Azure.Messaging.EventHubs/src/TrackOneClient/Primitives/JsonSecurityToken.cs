﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
