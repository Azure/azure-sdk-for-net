// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Redact sensitive information from the test recordings.
    /// </summary>
    public class SearchRecordedTestSanitizer : RecordedTestSanitizer
    {
        public SearchRecordedTestSanitizer()
        {
            AddJsonPathSanitizer("$..applicationSecret");
            SanitizedHeaders.Add("api-key");
        }
    }
}
