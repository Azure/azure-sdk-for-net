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

        public ContainerRegistryRecordedTestSanitizer()
        {
            DateTimeOffset expiresOn = DateTimeOffset.UtcNow + TimeSpan.FromDays(365 * 30); // Never expire in software years
            string encodedBody = Base64Url.EncodeString($"{{\"exp\":{expiresOn.ToUnixTimeSeconds()}}}");

            var jwtSanitizedValue = $"{SanitizeValue}.{encodedBody}.{SanitizeValue}";

            AddJsonPathSanitizer("$..refresh_token", _ => JToken.FromObject(jwtSanitizedValue));

            FormEncodedBodySanitizers.Add("access_token");
            FormEncodedBodySanitizers.Add("refresh_token");
        }

        public override string SanitizeTextBody(string contentType, string body)
        {
            string jsonSanitizedBody = base.SanitizeTextBody(contentType, body);
            try
            {
                if (contentType == "application/x-www-form-urlencoded")
                {
                    NameValueCollection queryParams = HttpUtility.ParseQueryString(jsonSanitizedBody);
                    for (int i = 0; i < queryParams.Keys.Count; i++)
                    {
                        string key = queryParams.Keys[i];
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
    }
}
