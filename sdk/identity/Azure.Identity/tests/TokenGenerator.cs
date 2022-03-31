// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Identity.Tests
{
    internal static class TokenGenerator
    {
        private const long epochTotalSeconds = 62135596800;
        private static string header = "{\"typ\":\"JWT\",\"alg\":\"RS256\",\"x5t\":\"asdf\",\"kid\":\"fghj\"}";
        private static string fakeSignature = "FakeTokenSignature";
        public static readonly char[] padding = { '=' };

        public static string GenerateToken(string tenantId, string clientId, string objectId, string upn, DateTime expireTime)
        {
            var expires = (expireTime.AddSeconds(-epochTotalSeconds) - DateTime.MinValue).TotalSeconds;
            var issued = (DateTime.UtcNow.AddSeconds(-epochTotalSeconds) - DateTime.MinValue).TotalSeconds;
            var payload = $"{{\"aud\":\"https://storage.azure.com\",\"iss\":\"https://sts.windows.net/{tenantId}/\",\"iat\":{issued},\"nbf\":{issued},\"exp\":{expires},\"_claim_names\":{{\"groups\":\"src1\"}},\"_claim_sources\":{{\"src1\":{{\"endpoint\":\"https://graph.windows.net/{tenantId}/users/{objectId}/getMemberObjects\"}}}},\"acr\":\"1\",\"aio\":\"someaio\",\"amr\":[\"rsa\",\"mfa\"],\"appid\":\"{clientId}\",\"appidacr\":\"0\",\"deviceid\":\"{Guid.NewGuid()}\",\"oid\":\"{objectId}\",\"scp\":\"user_impersonation\",\"sub\":\"somesub\",\"tid\":\"{tenantId}\",\"unique_name\":\"{upn}\",\"upn\":\"{upn}\",\"uti\":\"someuti\",\"ver\":\"1.0\"}}";

            return string.Join(".", new[]
{
                Convert.ToBase64String(Encoding.UTF8.GetBytes(header)).TrimEnd(padding).Replace('+', '-').Replace('/', '_'),
                Convert.ToBase64String(Encoding.UTF8.GetBytes(payload)).TrimEnd(padding).Replace('+', '-').Replace('/', '_'),
                fakeSignature
            });
        }
    }
}
