// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using Azure.Core.Testing;

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

        public override void Sanitize(RecordSession session)
        {
            var secrets = new HashSet<string>();

            foreach (var variable in session.Variables)
            {
                if (SearchTestEnvironment.StorageAccountKeyVariableName.Equals(variable.Key, StringComparison.OrdinalIgnoreCase))
                {
                    // Assumes the secret content is destined to appear in JSON, for which certain common characters in account keys are escaped.
                    // See https://github.com/dotnet/runtime/blob/8640eed0/src/libraries/System.Text.Json/src/System/Text/Json/Writer/JsonWriterHelper.Escaping.cs
                    string encoded = JavaScriptEncoder.Default.Encode(variable.Value);
                    secrets.Add(encoded);

                    session.Variables[variable.Key] = SanitizeValue;
                }
            }

            foreach (var recordEntry in session.Entries)
            {
                SanitizeSecretsInJsonBody(secrets, recordEntry.Request);
                SanitizeSecretsInJsonBody(secrets, recordEntry.Response);
            }

            base.Sanitize(session);
        }

        internal void SanitizeSecretsInJsonBody(HashSet<string> secrets, RecordEntryMessage message)
        {
            if (secrets.Count > 0 &&
                message.TryGetBodyAsText(out var body) &&
                message.TryGetContentType(out var contentType) &&
                !string.IsNullOrEmpty(body) &&
                contentType != null &&
                contentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
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
    }
}
