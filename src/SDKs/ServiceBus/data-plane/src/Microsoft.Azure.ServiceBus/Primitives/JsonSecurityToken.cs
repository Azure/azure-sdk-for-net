﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Collections.ObjectModel;
    using System.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;

    /// <summary>
    /// Extends SecurityToken for JWT specific properties
    /// </summary>
    public class JsonSecurityToken : SecurityToken
    {
        /// <summary>
        /// Creates a new instance of the <see cref="JsonSecurityToken"/> class.
        /// </summary>
        /// <param name="rawToken">Raw JSON Web Token string</param>
        /// <param name="audience">The audience</param>
        public JsonSecurityToken(string rawToken, string audience)
            : base(rawToken, GetExpirationDateTimeUtcFromToken(rawToken), audience, Constants.JsonWebTokenType)
        {
        }

        static DateTime GetExpirationDateTimeUtcFromToken(string token)
        {
            var jwtSecurityToken = new JwtSecurityToken(token);
            return jwtSecurityToken.ValidTo;
        }
    }
}
