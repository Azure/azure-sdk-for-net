// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    internal class QuestionAnsweringRecordedTestSanitizer : RecordedTestSanitizer
    {
        public QuestionAnsweringRecordedTestSanitizer()
        {
            SanitizedHeaders.Add(QuestionAnsweringClient.AuthorizationHeader);
        }
    }
}
