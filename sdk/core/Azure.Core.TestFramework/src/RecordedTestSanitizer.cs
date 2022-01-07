// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Azure.Core.TestFramework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Azure.Core.TestFramework
{
    public class RecordedTestSanitizer
    {
        public const string SanitizeValue = "Sanitized";
        internal List<(string JsonPath, Func<JToken, JToken> Sanitizer)> JsonPathSanitizers { get; } = new();

        public List<BodyKeySanitizer> BodyKeySanitizers { get; } = new();

        public List<BodyRegexSanitizer> BodyRegexSanitizers { get; } = new();
        public List<UriRegexSanitizer> UriRegexSanitizers { get; } = new();

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
            AddJsonPathSanitizer("$..primaryKey");
            AddJsonPathSanitizer("$..secondaryKey");
            AddJsonPathSanitizer("$..primaryConnectionString");
            AddJsonPathSanitizer("$..secondaryConnectionString");
            AddJsonPathSanitizer("$..connectionString");
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

        public void ReplaceHostInUri(string replacementHostName)
        {
            UriRegexSanitizers.Add(
                new UriRegexSanitizer(@"https://(?<host>[^/]+)/", replacementHostName)
                {
                    GroupForReplace = "host"
                });
        }

        public virtual string SanitizeUri(string uri)
        {
            return uri;
        }

        public virtual void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            foreach (var header in SanitizedHeaders)
            {
                if (headers.ContainsKey(header))
                {
                    headers[header] = s_sanitizeValueArray;
                }
            }
        }

        public virtual string SanitizeTextBody(string contentType, string body)
        {
            bool modified = false;

            if (string.IsNullOrWhiteSpace(body))
                return body;

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

                foreach (var (jsonPath, sanitizer) in JsonPathSanitizers)
                {
                    foreach (JToken token in jsonO.SelectTokens(jsonPath))
                    {
                        token.Replace(sanitizer(token));
                        modified = true;
                    }
                }

                if (modified || LegacyConvertJsonDateTokens)
                {
                    return JsonConvert.SerializeObject(jsonO, SerializerSettings);
                }
                else
                {
                    return body;
                }
            }
            catch
            {
                return body;
            }
        }

        public virtual byte[] SanitizeBody(string contentType, byte[] body)
        {
            return body;
        }

        public virtual string SanitizeVariable(string variableName, string environmentVariableValue) => environmentVariableValue;

        public virtual void SanitizeBody(RecordEntryMessage message)
        {
            if (message.Body != null)
            {
                message.TryGetContentType(out string contentType);

                if (message.TryGetBodyAsText(out string text))
                {
                    message.Body = Encoding.UTF8.GetBytes(SanitizeTextBody(contentType, text));
                }
                else
                {
                    message.Body = SanitizeBody(contentType, message.Body);
                }

                UpdateSanitizedContentLength(message.Headers, message.Body?.Length ?? 0);
            }
        }

        public virtual void Sanitize(RecordEntry entry)
        {
            entry.RequestUri = SanitizeUri(entry.RequestUri);

            SanitizeHeaders(entry.Request.Headers);

            SanitizeBody(entry.Request);

            SanitizeHeaders(entry.Response.Headers);

            if (entry.RequestMethod != RequestMethod.Head)
            {
                SanitizeBody(entry.Response);
            }
        }

        public virtual void Sanitize(RecordSession session)
        {
            foreach (RecordEntry entry in session.Entries)
            {
                Sanitize(entry);
            }

            foreach (KeyValuePair<string, string> variable in session.Variables.ToArray())
            {
                session.Variables[variable.Key] = SanitizeVariable(variable.Key, variable.Value);
            }
        }

        /// <summary>
        /// Optionally update the Content-Length header if we've sanitized it
        /// and the new value is a different length from the original
        /// Content-Length header.  We don't add a Content-Length header if it
        /// wasn't already present.
        /// </summary>
        /// <param name="headers">The Request or Response headers</param>
        /// <param name="sanitizedLength">The sanitized Content-Length</param>
        protected static void UpdateSanitizedContentLength(IDictionary<string, string[]> headers, int sanitizedLength)
        {
            // Only update Content-Length if already present.
            if (headers.ContainsKey("Content-Length"))
            {
                headers["Content-Length"] = new string[] { sanitizedLength.ToString(CultureInfo.InvariantCulture) };
            }
        }
    }
}
