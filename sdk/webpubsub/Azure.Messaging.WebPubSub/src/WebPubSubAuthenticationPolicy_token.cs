// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure.Core.Pipeline;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.CompilerServices;

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

            //public static string GenerateAccessToken(byte[] key, string audience, string userId, TimeSpan expiresAfter)
            //{
            //    var expiresAt = DateTime.UtcNow.Add(expiresAfter);

            //    Claim[] claims = null;
            //    if (userId != null)
            //    {
            //        claims = new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) };
            //    }

            //    var securityKey = new SymmetricSecurityKey(key);
            //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //    var token = JwtTokenHandler.CreateJwtSecurityToken(
            //        issuer: null,
            //        audience: audience,
            //        subject: claims == null ? null : new ClaimsIdentity(claims),
            //        expires: expiresAt,
            //        signingCredentials: credentials);

            //    return JwtTokenHandler.WriteToken(token);
            //}

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
                    issuedAt: null,
                    signingCredentials: credentials);
                return JwtTokenHandler.WriteToken(token);
            }

            private sealed class UniqueKey
            {
                public string Key { get; }
                public UniqueKey()
                {
                    Key = Guid.NewGuid().ToString("N");
                }
            }
        }
    }
}
