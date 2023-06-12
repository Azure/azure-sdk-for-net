// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Identity
{
    internal static class TokenHelper
    {
        public static (string ClientId, string TenantId, string Upn, string ObjectId) ParseAccountInfoFromToken(string token)
        {
            Argument.AssertNotNullOrEmpty(token, nameof(token));
            var parts = token.Split('.');
            if (parts.Length != 3)
            {
                throw new ArgumentException("Invalid token", nameof(token));
            }

            (string ClientId, string TenantId, string Upn, string ObjectId) result = default;

            try
            {
                string convertedToken = parts[1].Replace('_', '/').Replace('-', '+');
                switch (parts[1].Length % 4)
                {
                    case 2:
                        convertedToken += "==";
                        break;
                    case 3:
                        convertedToken += "=";
                        break;
                }
                Utf8JsonReader reader = new Utf8JsonReader(Convert.FromBase64String(convertedToken));
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        switch (reader.GetString())
                        {
                            case "appid":
                                reader.Read();
                                result.ClientId = reader.GetString();
                                break;

                            case "tid":
                                reader.Read();
                                result.TenantId = reader.GetString();
                                break;

                            case "upn":
                                reader.Read();
                                result.Upn = reader.GetString();
                                break;

                            case "oid":
                                reader.Read();
                                result.ObjectId = reader.GetString();
                                break;
                            default:
                                reader.Read();
                                break;
                        }
                    }
                }
            }
            catch
            {
                AzureIdentityEventSource.Singleton.UnableToParseAccountDetailsFromToken();
            }

            return result;
        }
    }
}
