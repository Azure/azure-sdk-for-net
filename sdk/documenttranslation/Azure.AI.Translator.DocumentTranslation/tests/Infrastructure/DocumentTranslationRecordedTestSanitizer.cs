// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Translator.DocumentTranslation.Tests
{
    public class DocumentTranslationRecordedTestSanitizer : RecordedTestSanitizer
    {
        public DocumentTranslationRecordedTestSanitizer()
            : base()
        {
            JsonPathSanitizers.Add("$..sourceUrl");
            JsonPathSanitizers.Add("$..targetUrl");
            SanitizedHeaders.Add(Constants.AuthorizationHeader);
        }
    }
}
