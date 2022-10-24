// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationAuthoringClientLiveTests : ConversationAnalysisTestBase<ConversationAuthoringClient>
    {
        public ConversationAuthoringClientLiveTests(bool isAsync, ConversationsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task GetSupportedMultilingualPrebuiltEntities()
        {
            // Make sure our redefinition of the multilingual parameter as a boolean works correctly.
            AsyncPageable<BinaryData> response = Client.GetSupportedPrebuiltEntitiesAsync(multilingual: true);
            Assert.That(await response.ToEnumerableAsync(), Has.Count.AtLeast(1));
        }

        [RecordedTest]
        public async Task GetSupportedLanguageSpecificPrebuiltEntities()
        {
            // Make sure our redefinition of the multilingual parameter as a boolean works correctly.
            AsyncPageable<BinaryData> response = Client.GetSupportedPrebuiltEntitiesAsync(language: "es", multilingual: false);
            Assert.That(await response.ToEnumerableAsync(), Has.Count.AtLeast(1));
        }

        [RecordedTest]
        public async Task GetProjects()
        {
            // Make sure pageables still work after removing explicit parameters (Azure/azure-sdk-for-net#29331).
            AsyncPageable<BinaryData> response = Client.GetProjectsAsync();
            Assert.That(await response.ToEnumerableAsync(), Has.Count.AtLeast(1));
        }

        [RecordedTest]
        public async Task GetTrainedModels()
        {
            // Make sure pageables still work after removing explicit parameters (Azure/azure-sdk-for-net#29331).
            AsyncPageable<BinaryData> response = Client.GetTrainedModelsAsync(TestEnvironment.ProjectName);
            Assert.That(await response.ToEnumerableAsync(), Has.Count.AtLeast(1));
        }

        [RecordedTest]
        public async Task SupportsAadAuthentication()
        {
            ConversationAuthoringClient client = CreateClient<ConversationAuthoringClient>(
                TestEnvironment.Endpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(
                    new ConversationsClientOptions(ServiceVersion)));

            AsyncPageable<BinaryData> response = client.GetProjectsAsync();
            Assert.That(await response.ToEnumerableAsync(), Has.Count.AtLeast(1));
        }
    }
}
