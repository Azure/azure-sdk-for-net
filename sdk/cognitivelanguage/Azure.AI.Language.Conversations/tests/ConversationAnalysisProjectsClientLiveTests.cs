// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationAnalysisProjectsClientLiveTests : ConversationAnalysisTestBase<ConversationAnalysisProjectsClient>
    {
        public ConversationAnalysisProjectsClientLiveTests(bool isAsync, ConversationAnalysisClientOptions.ServiceVersion serviceVersion)
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
    }
}
