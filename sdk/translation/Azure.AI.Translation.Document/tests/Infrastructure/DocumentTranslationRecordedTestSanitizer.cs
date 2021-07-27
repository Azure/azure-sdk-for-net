// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Translation.Document.Tests
{
    public class DocumentTranslationRecordedTestSanitizer : RecordedTestSanitizer
    {
        public DocumentTranslationRecordedTestSanitizer()
            : base()
        {
            AddJsonPathSanitizer("$..sourceUrl");
            AddJsonPathSanitizer("$..targetUrl");
            SanitizedHeaders.Add(Constants.AuthorizationHeader);
        }
    }
}
