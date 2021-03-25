// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.DocumentTranslation.Tests
{
    public class DocumentTranslationRecordedTestSanitizer : RecordedTestSanitizer
    {
        public DocumentTranslationRecordedTestSanitizer()
            : base()
        {
            SanitizedHeaders.Add(Constants.AuthorizationHeader);
        }
    }
}
