// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Azure.Test.HttpRecorder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Track1TestRecordingSanitizer
{
    public class RecordedTestSanitizer
    {
        public const string SanitizeValue = "Sanitized";
        public static List<(string JsonPath, Func<JToken, JToken> Sanitizer)> JsonPathSanitizers = new List<(string JsonPath, Func<JToken, JToken> Sanitizer)>();// { get; }

        /// <summary>
        /// This is just a temporary workaround to avoid breaking tests that need to be re-recorded
        //  when updating the JsonPathSanitizer logic to avoid changing date formats when deserializing requests.
        //  this property will be removed in the future.
        /// </summary>
        public bool LegacyConvertJsonDateTokens { get; set; }

        private static readonly string[] s_sanitizeValueArray = { SanitizeValue };

        public RecordedTestSanitizer()
        {
            // Lazy sanitize fields in the request and response bodies
            //AddJsonPathSanitizer("$..primaryKey");
            //AddJsonPathSanitizer("$..secondaryKey");
            //AddJsonPathSanitizer("$..key1");
            //AddJsonPathSanitizer("$..key2");
            //AddJsonPathSanitizer("$..primaryConnectionString");
            //AddJsonPathSanitizer("$..secondaryConnectionString");
            //AddJsonPathSanitizer("$..connectionString");
            //AddJsonPathSanitizer("$..packageUrl");
            //AddJsonPathSanitizer("$..accessSAS");
            //AddJsonPathSanitizer("$..value");
            //AddJsonPathSanitizer("$..accessKey");
            //AddJsonPathSanitizer("$..validationKey");

            AddJsonPathSanitizer("$..storageAccountAccessKey");
            AddJsonPathSanitizer("$..storageKey");
            AddJsonPathSanitizer("$..value");
            AddJsonPathSanitizer("$..storageAccountPrimaryKey");
            AddJsonPathSanitizer("$..storageContainerSasKey");
        }

        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            DateParseHandling = DateParseHandling.None
        };

        public List<string> SanitizedHeaders { get; } = new List<string> { "Authorization" };

        public void AddJsonPathSanitizer(string jsonPath, Func<JToken, JToken> sanitizer = null)
        {
            JsonPathSanitizers.Add((jsonPath, sanitizer ?? (_ => JToken.FromObject(SanitizeValue))));
        }
    }
}
