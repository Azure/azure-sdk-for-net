// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.Identity
{
    internal class JwtTokenParser
    {
        public static AccessToken CreateAccessToken(string token)
        {
            JwtPayload payload = DecodeJwtPayload(token);
            return new AccessToken(token, payload.ExpiresOn);
        }

        internal static JwtPayload DecodeJwtPayload(string token)
        {
            const string TokenNotFormattedCorrectly = "Token is not formatted correctly.";

            var tokenParts = token.Split('.');
            if (tokenParts.Length < 2)
                throw new FormatException(TokenNotFormattedCorrectly);

            try
            {
                return JsonSerializer.Deserialize<JwtPayload>(ConvertFromBase64Url(tokenParts[1]));
            }
            catch (JsonException ex)
            {
                throw new FormatException(TokenNotFormattedCorrectly, ex);
            }
        }

        private static string ConvertFromBase64Url(string base64Url)
        {
            var base64String = new StringBuilder(base64Url)
                .Replace('-', '+')
                .Replace('_', '-')
                .Append(new string('=', (4 - (base64Url.Length % 4)) % 4))
                .ToString();

            return Encoding.UTF8.GetString(Convert.FromBase64String(base64String));
        }

        internal class JwtPayload
        {
            [JsonPropertyName("exp")]
            public long ExpiresOnRaw { get; set; }

            [JsonPropertyName("acsScope")]
            public string ScopesRaw { get; set; } = "";

            public DateTimeOffset ExpiresOn => DateTimeOffset.FromUnixTimeSeconds(ExpiresOnRaw);
            public string[] Scopes => ScopesRaw.Split(',');
        }
    }
}
