// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IdentityModel.Tokens.Jwt;
using Azure.Core;

namespace Azure.MixedReality.Authentication
{
    internal static class JwtHelper
    {
        private static readonly JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();

        /// <summary>
        /// Retrieves the token expiration.
        /// If the 'expiration' claim is not found, then System.DateTime.MinValue is returned.
        /// </summary>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns><see cref="DateTime"/>.</returns>
        public static JwtSecurityToken ParseJwt(string jwtToken)
        {
            Argument.AssertNotNullOrWhiteSpace(jwtToken, nameof(jwtToken));

            return jwtHandler.ReadJwtToken(jwtToken);
        }

        /// <summary>
        /// Retrieves the token expiration.
        /// If the 'expiration' claim is not found, then System.DateTime.MinValue is returned.
        /// </summary>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns><see cref="DateTime"/>.</returns>
        public static DateTime RetrieveTokenExpiration(string jwtToken)
        {
            JwtSecurityToken token = ParseJwt(jwtToken);

            return token.ValidTo;
        }
    }
}
