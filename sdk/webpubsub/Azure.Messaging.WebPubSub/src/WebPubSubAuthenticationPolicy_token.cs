// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using Azure.Core.Pipeline;
using Microsoft.IdentityModel.Tokens;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// Web PubSub Authentication Policy.
    /// </summary>
    internal partial class WebPubSubAuthenticationPolicy : HttpPipelineSynchronousPolicy
    {
        private const int MaxTokenLength = 4096;

        /// <summary>
        /// Generates client bearwer token.
        /// </summary>
        /// <param name="audience"></param>
        /// <param name="claims"></param>
        /// <param name="key"></param>
        /// <param name="expireAfter"></param>
        /// <param name="hmacSha512">SHA512 if true, otherwise SHA256</param>
        /// <returns></returns>
        public static string GenerateAccessToken(
            string audience,
            IEnumerable<Claim> claims,
            AzureKeyCredential key,
            TimeSpan expireAfter = default,
            bool hmacSha512 = false)
        {
            if (expireAfter == default) expireAfter = TimeSpan.FromMinutes(10);

            var jwtToken = JwtUtils.GenerateJwtBearer(
                audience: audience,
                claims: claims,
                expiresAfter: expireAfter,
                key: key,
                hmacSha512: hmacSha512
            );

            Debug.Assert(jwtToken.Length <= MaxTokenLength);

            return jwtToken;
        }

        private static class JwtUtils
        {
            private static readonly JwtSecurityTokenHandler JwtTokenHandler = new JwtSecurityTokenHandler();
            private static readonly ConditionalWeakTable<AzureKeyCredential, UniqueKey> KeyForCredential = new ConditionalWeakTable<AzureKeyCredential, UniqueKey>();

            public static string GenerateJwtBearer(
                string audience,
                IEnumerable<Claim> claims,
                TimeSpan expiresAfter,
                AzureKeyCredential key,
                string issuer = null,
                bool hmacSha512 = false)
            {
                var expiresAt = DateTime.UtcNow.Add(expiresAfter);

                var subject = claims == null ? null : new ClaimsIdentity(claims);
                SigningCredentials credentials = null;
                if (key != null)
                {
                    // Refer: https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/releases/tag/5.5.0
                    // From version 5.5.0, SignatureProvider caching is turned On by default, assign KeyId to enable correct cache for same SigningKey
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key.Key))
                    {
                        KeyId = KeyForCredential.GetOrCreateValue(key).Key
                    };

                    var algorithm = hmacSha512 ? SecurityAlgorithms.HmacSha512 : SecurityAlgorithms.HmacSha256;
                    credentials = new SigningCredentials(securityKey, algorithm);
                }

                var token = JwtTokenHandler.CreateJwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    subject: subject,
                    notBefore: null,
                    expires: expiresAt,
                    issuedAt: DateTime.UtcNow,
                    signingCredentials: credentials);

                try
                {
                    return JwtTokenHandler.WriteToken(token);
                }
                catch (Exception e)
                {
                    // this is so we don't leak implementation details.
                    throw new InvalidOperationException("Token generation failed.", e);
                }
            }

            private sealed class UniqueKey
            {
                public string Key { get; } = Guid.NewGuid().ToString("N");
            }
        }
    }
}
