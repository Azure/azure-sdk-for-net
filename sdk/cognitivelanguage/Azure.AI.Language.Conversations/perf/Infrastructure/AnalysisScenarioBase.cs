// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;

namespace Azure.AI.Language.Conversations.Perf.Infrastructure
{
    public abstract class AnalysisScenarioBase<T> : Test.Perf.PerfTest<T> where T : PerfOptions
    {
        protected AnalysisScenarioBase(T options) : base(options)
        {
            var credential = new AzureKeyCredential(TestEnvironment.ApiKey);

            Client = new(
                TestEnvironment.Endpoint,
                credential,
                ConfigureClientOptions(new ConversationsClientOptions()));
        }

        protected PerfTestEnvironment TestEnvironment { get; } = PerfTestEnvironment.Instance;

        protected ConversationAnalysisClient Client { get; }
    }
}
