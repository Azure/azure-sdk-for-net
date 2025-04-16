// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Inference;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class ExtensionTests : RecordedTestBase<AIProjectsTestEnvironment>
    {
        public ExtensionTests(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase("aiprojectssdktestingaiserviceswus")]
        public async Task TestGetChatCompletionsClient(string connectionName)
        {
            AIProjectClient client = GetClient();
            ChatCompletionsClient chatClient = GetChatClient(client, connectionName);

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
                Model = connectionName != null ? "gpt-4" : "Cohere-command-r-plus"
            };
            Response<ChatCompletions> response = await chatClient.CompleteAsync(requestOptions);
            Assert.That(response.Value.Content.Length > 0);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase("aiprojectssdktestingaiserviceswus")]
        public async Task TestGetEmbeddingsClient(string connectionName)
        {
            AIProjectClient client = GetClient();
            EmbeddingsClient embeddingsClient = GetEmbeddingClient(client, connectionName);

            List<string> input = [ "first phrase", "second phrase", "third phrase" ];
            var requestOptions = new EmbeddingsOptions(input)
            {
                Model = connectionName != null ? "text-embedding-3-small" : "Cohere-embed-v3-english"
            };

            Response<EmbeddingsResult> response = await embeddingsClient.EmbedAsync(requestOptions);
            foreach (EmbeddingItem item in response.Value.Data)
            {
                List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
                Assert.That(embedding.Count > 0);
            }
        }

        #region Helpers
        private AIProjectClient GetClient()
        {
            var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
            // If we are in the Playback, do not ask for authentication.
            if (Mode == RecordedTestMode.Playback)
            {
                return InstrumentClient(new AIProjectClient(connectionString, new MockCredential(), InstrumentClientOptions(new AIProjectClientOptions())));
            }
            // For local testing if you are using non default account
            // add USE_CLI_CREDENTIAL into the .runsettings and set it to true,
            // also provide the PATH variable.
            // This path should allow launching az command.
            var cli = System.Environment.GetEnvironmentVariable("USE_CLI_CREDENTIAL");
            if (!string.IsNullOrEmpty(cli) && string.Compare(cli, "true", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return InstrumentClient(new AIProjectClient(connectionString, new AzureCliCredential(), InstrumentClientOptions(new AIProjectClientOptions())));
            }
            else
            {
                return InstrumentClient(new AIProjectClient(connectionString, new DefaultAzureCredential(), InstrumentClientOptions(new AIProjectClientOptions())));
            }
        }

        private ChatCompletionsClient GetChatClient(AIProjectClient client, string connectionName)
        {
            return InstrumentClient(client.GetChatCompletionsClient(
                connectionName: connectionName,
                options: InstrumentClientOptions(new AzureAIInferenceClientOptions())));
        }

        private EmbeddingsClient GetEmbeddingClient(AIProjectClient client, string connectionName)
        {
            return InstrumentClient(client.GetEmbeddingsClient(
                connectionName: connectionName,
                options: InstrumentClientOptions(new AzureAIInferenceClientOptions())));
        }
        #endregion
    }
}
