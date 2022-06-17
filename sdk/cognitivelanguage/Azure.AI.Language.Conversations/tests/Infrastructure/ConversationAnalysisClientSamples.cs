// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples : ConversationAnalysisTestBase<ConversationAnalysisClient>
    {
        public ConversationAnalysisClientSamples(bool isAsync, ConversationAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        protected ConversationAnalysisProjectsClient ProjectsClient { get; private set; }

        public async override Task StartTestRecordingAsync()
        {
            await base.StartTestRecordingAsync();

            ProjectsClient = CreateClient<ConversationAnalysisProjectsClient>(
                TestEnvironment.Endpoint,
                new AzureKeyCredential(TestEnvironment.ApiKey),
                InstrumentClientOptions(
                    new ConversationAnalysisClientOptions(ServiceVersion)));
        }
    }
}
