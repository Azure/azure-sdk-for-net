// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication
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
            const string TokenPartsIncorrect = "Token does not have the correct number of parts.";
            const string TokenPayloadIncorrect = "Token payload is not formatted correctly.";
            const string TokenDeserializationFailed = "Failed to deserialize the token payload.";

            var tokenParts = token.Split('.');
            if (tokenParts.Length != 3)
                throw new FormatException(TokenPartsIncorrect);

            try
            {
                var payloadJson = Base64Url.DecodeString(tokenParts[1]);
                return JsonSerializer.Deserialize<JwtPayload>(payloadJson) ?? throw new FormatException(TokenDeserializationFailed);
            }
            catch (JsonException ex)
            {
                throw new FormatException(TokenPayloadIncorrect, ex);
            }
            catch (ArgumentException ex)
            {
                throw new FormatException(TokenPayloadIncorrect, ex);
            }
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
