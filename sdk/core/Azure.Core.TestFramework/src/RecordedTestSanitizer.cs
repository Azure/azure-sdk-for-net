// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Azure.Core.TestFramework
{
    public class RecordedTestSanitizer
    {
        public const string SanitizeValue = "Sanitized";
        public List<string> JsonPathSanitizers { get; } = new List<string>();

        private static readonly string[] s_sanitizeValueArray = { SanitizeValue };

        private static readonly string[] s_sanitizedHeaders = { "Authorization" };

        public virtual string SanitizeUri(string uri)
        {
            return uri;
        }

        public virtual void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            foreach (var header in s_sanitizedHeaders)
            {
                if (headers.ContainsKey(header))
                {
                    headers[header] = s_sanitizeValueArray;
                }
            }
        }

        public virtual string SanitizeTextBody(string contentType, string body)
        {
            if (JsonPathSanitizers.Count == 0)
                return body;
            try
            {
                var jsonO = JObject.Parse(body);
                foreach (string jsonPath in JsonPathSanitizers)
                {
                    foreach (JToken token in jsonO.SelectTokens(jsonPath))
                    {
                        token.Replace(JToken.FromObject(SanitizeValue));
                    }
                }
                return JsonConvert.SerializeObject(jsonO);
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

            SanitizeBody(entry.Response);
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
