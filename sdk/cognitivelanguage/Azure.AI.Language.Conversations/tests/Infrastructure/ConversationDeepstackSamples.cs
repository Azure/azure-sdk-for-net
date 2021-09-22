// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationDeepstackSamples : ConversationAnalysisTestBase<ConversationAnalysisClient>
    {
        public ConversationDeepstackSamples(bool isAsync, ConversationAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }
    }
}
