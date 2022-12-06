// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples : ConversationAnalysisTestBase<ConversationAnalysisClient>
    {
        public ConversationAnalysisClientSamples(bool isAsync, ConversationsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        protected ConversationAuthoringClient ProjectsClient { get; private set; }

        public override async Task StartTestRecordingAsync()
        {
            await base.StartTestRecordingAsync();

            ProjectsClient = CreateClient<ConversationAuthoringClient>(
                TestEnvironment.Endpoint,
                new AzureKeyCredential(TestEnvironment.ApiKey),
                InstrumentClientOptions(
                    new ConversationsClientOptions(ServiceVersion)
                    {
                        Retry =
                        {
                            MaxRetries = 10,
                        },
                    }));
        }
    }
}
