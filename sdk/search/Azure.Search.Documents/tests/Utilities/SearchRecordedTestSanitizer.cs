// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
