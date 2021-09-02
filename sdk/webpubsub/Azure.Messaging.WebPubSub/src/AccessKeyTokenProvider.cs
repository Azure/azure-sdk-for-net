// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// Hub endpoint with local auth methods.
    /// </summary>
    internal class AccessKeyTokenProvider : ITokenProvider
    {
        private static readonly byte[] s_role = Encoding.UTF8.GetBytes("role");

        public string AccessKey { get; }

        public Uri Endpoint { get; }

        public byte[] KeyBytes { get; private set; } = Array.Empty<byte>();

        public AccessKeyTokenProvider(Uri endpoint, AzureKeyCredential credential)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            Endpoint = endpoint;
            AccessKey = credential.Key;
            KeyBytes = Encoding.UTF8.GetBytes(credential.Key);
        }

        public AccessToken GetServerToken(string audience)
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            DateTimeOffset expiresAt = now + TimeSpan.FromMinutes(5);

            var builder = new JwtBuilder(KeyBytes);
            builder.AddClaim(JwtBuilder.Nbf, now);
            builder.AddClaim(JwtBuilder.Exp, expiresAt);
            builder.AddClaim(JwtBuilder.Iat, now);
            builder.AddClaim(JwtBuilder.Aud, audience);
            int jwtLength = builder.End();

            var token = NS2Bridge.CreateString(jwtLength, builder, (destination, builder) =>
            {
                builder.TryBuildTo(destination, out _);
            });
            return new AccessToken(token, expiresAt);
        }

        public Task<AccessToken> GetServerTokenAsync(string audience, CancellationToken token)
        {
            return Task.FromResult(GetServerToken(audience));
        }

        public Task<AccessToken> GetClientTokenAsync(string audience,
                                                     string userId,
                                                     string[] roles,
                                                     DateTimeOffset expiresAt,
                                                     CancellationToken ctoken = default)
        {
            AccessToken token = GetClientToken(audience, userId, roles, expiresAt);
            return Task.FromResult(token);
        }

        public AccessToken GetClientToken(string audience, string userId, string[] roles, DateTimeOffset expiresAt)
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;

            var builder = new JwtBuilder(KeyBytes);
            if (userId != default)
            {
                builder.AddClaim(JwtBuilder.Sub, userId);
            }
            if (roles != default && roles.Length > 0)
            {
                builder.AddClaim(s_role, roles);
            }
            builder.AddClaim(JwtBuilder.Nbf, now);
            builder.AddClaim(JwtBuilder.Exp, expiresAt);
            builder.AddClaim(JwtBuilder.Iat, now);
            builder.AddClaim(JwtBuilder.Aud, audience);
            int jwtLength = builder.End();

            var token = NS2Bridge.CreateString(jwtLength, builder, (destination, builder) =>
            {
                builder.TryBuildTo(destination, out var _);
            });
            return new AccessToken(token, expiresAt);
        }
    }
}
