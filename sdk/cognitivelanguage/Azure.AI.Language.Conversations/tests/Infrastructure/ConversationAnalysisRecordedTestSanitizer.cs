// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Language.Conversations.Tests
{
    internal class ConversationAnalysisRecordedTestSanitizer : RecordedTestSanitizer
    {
        public ConversationAnalysisRecordedTestSanitizer()
        {
            SanitizedHeaders.Add(ConversationAnalysisClient.AuthorizationHeader);
        }
    }
}
