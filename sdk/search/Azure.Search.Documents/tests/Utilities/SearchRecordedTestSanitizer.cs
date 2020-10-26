// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using Azure.Core.TestFramework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Redact sensitive information from the test recordings.
    /// </summary>
    public class SearchRecordedTestSanitizer : RecordedTestSanitizer
    {
        /// <summary>
        /// Name of the API Key Header.
        /// </summary>
        private const string ApiKeyHeaderName = "api-key";

        /// <summary>
        /// Sanitizes all headers, variables, and body content of a <see cref="RecordSession"/>.
        /// </summary>
        /// <param name="session">The <see cref="RecordSession"/> to sanitize.</param>
        public override void Sanitize(RecordSession session)
        {
            HashSet<string> secrets = new HashSet<string>();

            foreach (KeyValuePair<string, string> variable in session.Variables.ToArray())
            {
                session.Variables[variable.Key] = SanitizeVariable(secrets, variable.Key, variable.Value);
            }

            foreach (RecordEntry entry in session.Entries)
            {
                if (secrets.Count > 0)
                {
                    SanitizeBody(secrets, entry.Request);
                    SanitizeBody(secrets, entry.Response);
                }
            }

            base.Sanitize(session);
        }

        /// <summary>
        /// Redact sensitive headers.
        /// </summary>
        /// <param name="headers">The recording headers.</param>
        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            if (headers.ContainsKey(ApiKeyHeaderName))
            {
                headers[ApiKeyHeaderName] = new string[] { SanitizeValue };
            }

            base.SanitizeHeaders(headers);
        }

        /// <summary>
        /// Redact sensitive body content.
        /// </summary>
        /// <param name="secrets">Any secrets found in <see cref="SanitizeVariable(ISet{string}, string, string)"/>.</param>
        /// <param name="message">The <see cref="RecordEntryMessage"/> to sanitize.</param>
        private static void SanitizeBody(ISet<string> secrets, RecordEntryMessage message)
        {
            if (message.Body != null &&
                message.TryGetContentType(out string contentType) &&
                contentType != null &&
                contentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase) &&
                message.TryGetBodyAsText(out string body) &&
                !string.IsNullOrEmpty(body))
            {
                StringBuilder sanitized = new StringBuilder(body);
                foreach (string secret in secrets)
                {
                    sanitized.Replace(secret, SanitizeValue);
                }

                message.Body = Encoding.UTF8.GetBytes(sanitized.ToString());
            }
        }

        /// <summary>
        /// Redact sensitive variables.
        /// </summary>
        /// <param name="secrets"><see cref="ISet{T}"/> to add any found secrets.</param>
        /// <param name="name">The name of the variable.</param>
        /// <param name="value">The value of the variable.</param>
        /// <returns>The sanitized variable value.</returns>
        private static string SanitizeVariable(ISet<string> secrets, string name, string value)
        {
            if (SearchTestEnvironment.StorageAccountKeyVariableName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                // Assumes the secret content is destined to appear in JSON, for which certain common characters in account keys are escaped.
                // See https://github.com/dotnet/runtime/blob/8640eed0/src/libraries/System.Text.Json/src/System/Text/Json/Writer/JsonWriterHelper.Escaping.cs
                string encoded = JavaScriptEncoder.Default.Encode(value);
                secrets.Add(encoded);

                return SanitizeValue;
            }

            if (SearchTestEnvironment.CognitiveKeyVariableName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                secrets.Add(value);

                return SanitizeValue;
            }

            if (SearchTestEnvironment.SearchAdminKeyVariableName.Equals(name, StringComparison.OrdinalIgnoreCase) ||
                SearchTestEnvironment.SearchQueryKeyVariableName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                // No need to scan the body since they values should be found only in the header.
                return SanitizeValue;
            }

            return value;
        }
    }
}
