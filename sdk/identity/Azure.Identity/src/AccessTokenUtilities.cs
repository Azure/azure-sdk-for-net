// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal static class AccessTokenUtilities
    {
        public static async Task<AccessToken> DeserializeAsync(bool async, Stream content, CancellationToken cancellationToken)
        {
            if (async)
            {
                using (JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellationToken).ConfigureAwait(false))
                {
                    return Deserialize(json.RootElement);
                }
            }
            else
            {
                using (JsonDocument json = JsonDocument.Parse(content))
                {
                    return Deserialize(json.RootElement);
                }
            }
        }

        private static AccessToken Deserialize(JsonElement json)
        {
            string accessToken = null;

            DateTimeOffset expiresOn = DateTimeOffset.MaxValue;

            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case "access_token":
                    case "accessToken":
                        accessToken = prop.Value.GetString();
                        break;

                    case "expires_in":
                    case "expiresIn":
                        expiresOn = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(prop.Value.GetInt64());
                        break;

                    case "expires_on":
                        if (expiresOn == DateTimeOffset.MaxValue)
                        {
                            expiresOn = prop.Value.GetDateTimeOffset();
                        }
                        break;
                    case "expiresOn":
                        if (expiresOn == DateTimeOffset.MaxValue)
                        {
                            var expiresOnStr = prop.Value.GetString();

                            expiresOn = DateTimeOffset.ParseExact(expiresOnStr, "yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                        }
                        break;
                }
            }

            return new AccessToken(accessToken, expiresOn);
        }
    }
}
