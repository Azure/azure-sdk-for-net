// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationAnalysisClientLiveTests : ConversationAnalysisTestBase<ConversationAnalysisClient>
    {
        public ConversationAnalysisClientLiveTests(bool isAsync, ConversationAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }
    }
}
