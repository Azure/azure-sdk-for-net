// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using Azure.Core;
using Azure.Core.TestFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryRecordedTestSanitizer : RecordedTestSanitizer
    {
        public List<string> FormEncodedBodySanitizers { get; } = new List<string>();
        public List<string> JwtValues { get; } = new List<string>();

        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            DateParseHandling = DateParseHandling.None
        };

        public ContainerRegistryRecordedTestSanitizer()
            : base()
        {
            JsonPathSanitizers.Add("$..access_token");
            JsonPathSanitizers.Add("$..refresh_token");

            FormEncodedBodySanitizers.Add("access_token");
            FormEncodedBodySanitizers.Add("refresh_token");

            JwtValues.Add("$..refresh_token");
        }

        public override string SanitizeTextBody(string contentType, string body)
        {
            string jsonSanitizedBody = SanitizeJsonTextBody(contentType, body);

            if (FormEncodedBodySanitizers.Count == 0)
            {
                return jsonSanitizedBody;
            }

            try
            {
                if (contentType == "application/x-www-form-urlencoded")
                {
                    string urlEncodedSanitizedBody = string.Empty;

                    NameValueCollection queryParams = HttpUtility.ParseQueryString(jsonSanitizedBody);
                    for (int i = 0; i < queryParams.Keys.Count; i++)
                    {
                        string key = queryParams.Keys[i].ToString();
                        foreach (string paramToSanitize in FormEncodedBodySanitizers)
                        {
                            if (key == paramToSanitize)
                            {
                                queryParams[key] = SanitizeValue;
                            }
                        }
                    }

                    return queryParams.ToString();
                }

                return jsonSanitizedBody;
            }
            catch
            {
                return jsonSanitizedBody;
            }
        }

        private string SanitizeJsonTextBody(string contentType, string body)
        {
            if (JsonPathSanitizers.Count == 0)
                return body;
            try
            {
                JToken jsonO;
                // Prevent default behavior where JSON.NET will convert DateTimeOffset
                // into a DateTime.
                if (!LegacyConvertJsonDateTokens)
                {
                    jsonO = JsonConvert.DeserializeObject<JToken>(body, SerializerSettings);
                }
                else
                {
                    jsonO = JToken.Parse(body);
                }

                foreach (string jsonPath in JsonPathSanitizers)
                {
                    foreach (JToken token in jsonO.SelectTokens(jsonPath))
                    {
                        string value = token.ToString();
                        token.Replace(JToken.FromObject(JwtValues.Contains(jsonPath) ? SanitizeJwt(value) : SanitizeValue));
                    }
                }
                return JsonConvert.SerializeObject(jsonO, SerializerSettings);
            }
            catch
            {
                return body;
            }
        }

        private string SanitizeJwt(string value)
        {
            AcrRefreshToken token = new AcrRefreshToken(value);
            DateTimeOffset expiresOn = ContainerRegistryRefreshTokenCache.GetTokenExpiryTime(token);
            string encodedBody = Base64Url.EncodeString($"{{\"exp\":{expiresOn.ToUnixTimeSeconds()}}}");

            return $"{SanitizeValue}.{encodedBody}.{SanitizeValue}";
        }
    }
}
