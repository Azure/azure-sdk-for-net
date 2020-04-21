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

        /// <summary>
        /// Secret values to sanitize from body.
        /// </summary>
        private readonly HashSet<string> _secrets = new HashSet<string>();

        /// <summary>
        /// Redact sensitive body content.
        /// </summary>
        /// <param name="contentType">The Content-Type of the body content.</param>
        /// <param name="body">The body content.</param>
        /// <returns>The sanitized body content.</returns>
        public override string SanitizeTextBody(string contentType, string body)
        {
            if (_secrets.Count > 0 &&
                !string.IsNullOrEmpty(body) &&
                contentType != null &&
                contentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
            {
                StringBuilder sanitized = new StringBuilder(body);
                foreach (string secret in _secrets)
                {
                    sanitized.Replace(secret, SanitizeValue);
                }

                return sanitized.ToString();
            }

            return base.SanitizeTextBody(contentType, body);
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
        /// Redact sensitive variables.
        /// </summary>
        /// <param name="variableName">The name of the variable.</param>
        /// <param name="environmentVariableValue">The value of the variable.</param>
        /// <returns>The sanitized variable value.</returns>
        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            if (SearchTestEnvironment.StorageAccountKeyVariableName.Equals(variableName, StringComparison.OrdinalIgnoreCase))
            {
                // Assumes the secret content is destined to appear in JSON, for which certain common characters in account keys are escaped.
                // See https://github.com/dotnet/runtime/blob/8640eed0/src/libraries/System.Text.Json/src/System/Text/Json/Writer/JsonWriterHelper.Escaping.cs
                string encoded = JavaScriptEncoder.Default.Encode(environmentVariableValue);
                _secrets.Add(encoded);

                return SanitizeValue;
            }

            return base.SanitizeVariable(variableName, environmentVariableValue);
        }
    }
}
