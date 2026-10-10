// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.Core
{
    internal static class WebPubSubClientAccessTokenGenerator
    {
        private static readonly byte[] s_role = Encoding.UTF8.GetBytes("role");
        private static readonly byte[] s_group = Encoding.UTF8.GetBytes("webpubsub.group");

        public static string Generate(
            AzureKeyCredential credential,
            string audience,
            DateTimeOffset expiresAt,
            string userId = default,
            IEnumerable<string> roles = default,
            IEnumerable<string> groups = default)
        {
            using var jwt = new JwtBuilder(Encoding.UTF8.GetBytes(credential.Key));
            DateTimeOffset now = DateTimeOffset.UtcNow;

            if (userId != default)
            {
                jwt.AddClaim(JwtBuilder.Sub, userId);
            }
            if (roles != default && roles.Any())
            {
                jwt.AddClaim(s_role, roles);
            }
            if (groups != default && groups.Any())
            {
                jwt.AddClaim(s_group, groups);
            }
            jwt.AddClaim(JwtBuilder.Nbf, now);
            jwt.AddClaim(JwtBuilder.Exp, expiresAt);
            jwt.AddClaim(JwtBuilder.Iat, now);
            jwt.AddClaim(JwtBuilder.Aud, audience);

            return jwt.BuildString();
        }
    }
}