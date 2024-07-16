// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationsClientSamples : ConversationAnalysisTestBase<ConversationsClient>
    {
        public ConversationsClientSamples(bool isAsync, ConversationsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }
    }
}
