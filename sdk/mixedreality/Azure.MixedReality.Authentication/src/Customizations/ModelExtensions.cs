// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.MixedReality.Authentication
{
    internal static class ModelExtensions
    {
        /// <summary>
        /// Converts an <see cref="StsTokenResponseMessage"/> to an <see cref="AccessToken"/>.
        /// </summary>
        /// <param name="stsTokenResponseMessage">The STS token response message.</param>
        /// <returns><see cref="AccessToken"/>.</returns>
        public static AccessToken ToAccessToken(this StsTokenResponseMessage stsTokenResponseMessage)
        {
            DateTimeOffset tokenExpiration = JwtHelper.RetrieveTokenExpiration(stsTokenResponseMessage.AccessToken);
            return new AccessToken(stsTokenResponseMessage.AccessToken, tokenExpiration);
        }
    }
}
