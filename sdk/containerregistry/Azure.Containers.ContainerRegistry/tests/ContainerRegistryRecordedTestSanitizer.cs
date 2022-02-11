// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
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

            BodyKeySanitizers.Add(new BodyKeySanitizer(jwtSanitizedValue)
            {
                JsonPath = "$..refresh_token"
            });
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"access_token=(?<group>.*?)(?=&|$)", SanitizeValue)
            {
                GroupForReplace = "group"
            });
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"refresh_token=(?<group>.*?)(?=&|$)", SanitizeValue)
            {
                GroupForReplace = "group"
            });
        }
    }
}
