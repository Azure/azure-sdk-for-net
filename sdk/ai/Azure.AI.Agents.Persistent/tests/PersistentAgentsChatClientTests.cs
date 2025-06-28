// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.Extensions.AI;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests
{
    public class PersistentAgentsChatClientTests : RecordedTestBase<AIAgentsTestEnvironment>
    {
        private const string AGENT_NAME = "cs_e2e_tests_chat_client";
        private const string STREAMING_CONSTRAINT = "The test framework does not support iteration of stream in Sync mode.";

        private string _agentId;
        private string _threadId;

        public PersistentAgentsChatClientTests(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        #region Enumerations
        public enum ChatOptionsTestType
        {
            Default,
            WithTools,
            WithResponseFormat
        }
        #endregion

        [SetUp]
        public async Task Setup()
        {
            using IDisposable _ = SetTestSwitch();
            PersistentAgentsClient client = GetClient();
            PersistentAgent agent = await client.Administration.CreateAgentAsync(
                model: "gpt-4.1",
                name: AGENT_NAME,
                instructions: "You are a helpful chat agent."
            );

            _agentId = agent.Id;

            PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

            _threadId = thread.Id;
        }

        [RecordedTest]
        public async Task TestGetResponseAsync()
        {
            using IDisposable _ = SetTestSwitch();
            PersistentAgentsClient client = GetClient();
            PersistentAgentsChatClient chatClient = new(client, _agentId, _threadId);

            List<ChatMessage> messages = [];
            messages.Add(new ChatMessage(ChatRole.User, [new TextContent("Hello, tell me a joke")]));

            ChatResponse response = await chatClient.GetResponseAsync(messages);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Messages);
            Assert.GreaterOrEqual(response.Messages.Count, 1);
            Assert.AreEqual(ChatRole.Assistant, response.Messages[0].Role);
            Assert.IsNotNull(response.ConversationId);
        }

        [RecordedTest]
        [TestCase(ChatOptionsTestType.Default)]
        [TestCase(ChatOptionsTestType.WithTools)]
        [TestCase(ChatOptionsTestType.WithResponseFormat)]
        public async Task TestGetStreamingResponseAsync(ChatOptionsTestType optionsType)
        {
            if (!IsAsync)
            {
                Assert.Inconclusive(STREAMING_CONSTRAINT);
            }

            using IDisposable _ = SetTestSwitch();
            PersistentAgentsClient client = GetClient();
            PersistentAgentsChatClient chatClient = new(client, _agentId, _threadId);

            ChatOptions options = null;
            if (optionsType == ChatOptionsTestType.WithTools)
            {
                options = new ChatOptions
                {
                    Tools = [AIFunctionFactory.Create(() => "It's 80 degrees and sunny.", "GetWeather")],
                    ToolMode = ChatToolMode.Auto
                };
            }
            else if (optionsType == ChatOptionsTestType.WithResponseFormat)
            {
                options = new ChatOptions
                {
                    ResponseFormat = ChatResponseFormat.Json
                };
            }

            List<ChatMessage> messages = [new ChatMessage(ChatRole.User, [new TextContent("What's the weather like? Respond in JSON.")])];
            bool receivedUpdate = false;

            await foreach (ChatResponseUpdate update in chatClient.GetStreamingResponseAsync(messages, options))
            {
                Assert.IsNotNull(update);
                Assert.IsNotNull(update.ConversationId);
                if (update.Contents.Any(c => (optionsType == ChatOptionsTestType.WithTools && c is FunctionCallContent) || c is TextContent))
                {
                    receivedUpdate = true;
                }
            }

            Assert.IsTrue(receivedUpdate, "No valid streaming update received.");
        }

        [RecordedTest]
        public async Task TestSubmitToolOutputs()
        {
            using IDisposable _ = SetTestSwitch();
            PersistentAgentsClient client = GetClient();
            FunctionToolDefinition tool = new(
                name: "GetFavouriteWord",
                description: "Gets the favourite word of a person.",
                parameters: BinaryData.FromObjectAsJson(new
                {
                    Type = "object",
                    Properties = new { Name = new { Type = "string", Description = "Person's name" } },
                    Required = new[] { "name" }
                }, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
            );

            PersistentAgent agent = await client.Administration.CreateAgentAsync(
                model: "gpt-4.1",
                name: AGENT_NAME,
                instructions: "Use the provided function to answer questions.",
                tools: [tool]
            );

            PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

            PersistentAgentsChatClient chatClient = new(client, agent.Id, thread.Id);

            await client.Messages.CreateMessageAsync(thread.Id, MessageRole.User, "What's Mike's favourite word?");

            ThreadRun run = await client.Runs.CreateRunAsync(thread.Id, agent.Id);
            do
            {
                await Task.Delay(500);
                run = await client.Runs.GetRunAsync(thread.Id, run.Id);
            } while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

            if (run.Status == RunStatus.RequiresAction && run.RequiredAction is SubmitToolOutputsAction action)
            {
                List<ChatMessage> messages = [];
                foreach (RequiredToolCall toolCall in action.ToolCalls)
                {
                    if (toolCall is RequiredFunctionToolCall functionCall)
                    {
                        string[] callIds = [run.Id, functionCall.Id];
                        messages.Add(new ChatMessage(ChatRole.Tool, [new FunctionResultContent(JsonSerializer.Serialize(callIds), "bar")]));
                    }
                }

                ChatResponse response = await chatClient.GetResponseAsync(messages, new ChatOptions { ConversationId = thread.Id });
                Assert.IsNotNull(response);
                Assert.GreaterOrEqual(response.Messages.Count, 1);
                Assert.IsTrue(response.Messages[0].Contents.Any(c => c is TextContent tc && tc.Text.Contains("bar")));
            }
            else
            {
                Assert.Fail("Run did not require tool action.");
            }
        }

        [RecordedTest]
        public async Task TestChatOptionsTools()
        {
            using IDisposable _ = SetTestSwitch();
            PersistentAgentsClient client = GetClient();

            FunctionToolDefinition wordTool = new(
                name: "GetFavouriteWord",
                description: "Gets the favourite word of a person.",
                parameters: BinaryData.FromObjectAsJson(new
                {
                    Type = "object",
                    Properties = new { Name = new { Type = "string", Description = "Person's name" } },
                    Required = new[] { "name" }
                }, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
            );

            // First tool is registered on agent level.
            PersistentAgent agent = await client.Administration.CreateAgentAsync(
                model: "gpt-4.1",
                name: AGENT_NAME,
                instructions: "Use the provided function to answer questions.",
                tools: [wordTool]
            );

            // Second tool is registered per request.
            ChatOptions chatOptions = new()
            {
                Tools = [AIFunctionFactory.Create(() => "It's 80 degrees and sunny.", "GetWeather")],
                ToolMode = ChatToolMode.Auto
            };

            PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

            PersistentAgentsChatClient chatClient = new(client, agent.Id, thread.Id);

            List<ChatMessage> messages = [];
            messages.Add(new ChatMessage(ChatRole.User, [new TextContent("What's Mike's favourite word and current weather in Seattle?")]));

            ChatResponse response = await chatClient.GetResponseAsync(messages, chatOptions);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Messages);
            Assert.GreaterOrEqual(response.Messages.Count, 1);
            Assert.AreEqual(ChatRole.Assistant, response.Messages[0].Role);

            List<string> functionNames = [.. response.Messages[0].Contents
                .OfType<FunctionCallContent>()
                .Select(c => c.Name)];

            Assert.Contains("GetFavouriteWord", functionNames);
            Assert.Contains("GetWeather", functionNames);
        }

        [RecordedTest]
        public void TestGetService()
        {
            using IDisposable _ = SetTestSwitch();
            PersistentAgentsClient client = GetClient();
            PersistentAgentsChatClient chatClient = new(client, _agentId, _threadId);

            Assert.IsNotNull(chatClient.GetService(typeof(ChatClientMetadata)));
            Assert.IsNotNull(chatClient.GetService(typeof(PersistentAgentsClient)));
            Assert.IsNotNull(chatClient.GetService(typeof(PersistentAgentsChatClient)));
            Assert.IsNull(chatClient.GetService(typeof(string)));
            Assert.Throws<ArgumentNullException>(() => chatClient.GetService(null));
        }

        #region Helpers
        private class CompositeDisposable : IDisposable
        {
            private readonly List<IDisposable> _disposables = [];

            public CompositeDisposable(params IDisposable[] disposables)
            {
                for (int i = 0; i < disposables.Length; i++)
                {
                    _disposables.Add(disposables[i]);
                }
            }

            public void Dispose()
            {
                foreach (IDisposable d in _disposables)
                {
                    d?.Dispose();
                }
            }
        }

        private static CompositeDisposable SetTestSwitch()
        {
            return new CompositeDisposable(
                new TestAppContextSwitch(new()
                {
                    { PersistentAgentsConstants.UseOldConnectionString, true.ToString() }
                }));
        }

        private PersistentAgentsClient GetClient()
        {
            var connectionString = TestEnvironment.PROJECT_CONNECTION_STRING;
            PersistentAgentsAdministrationClientOptions opts = InstrumentClientOptions(new PersistentAgentsAdministrationClientOptions());
            PersistentAgentsAdministrationClient admClient;

            if (Mode == RecordedTestMode.Playback)
            {
                admClient = InstrumentClient(new PersistentAgentsAdministrationClient(connectionString, new MockCredential(), opts));
                return new PersistentAgentsClient(admClient);
            }

            var cli = Environment.GetEnvironmentVariable("USE_CLI_CREDENTIAL");
            if (!string.IsNullOrEmpty(cli) && string.Compare(cli, "true", StringComparison.OrdinalIgnoreCase) == 0)
            {
                admClient = InstrumentClient(new PersistentAgentsAdministrationClient(connectionString, new AzureCliCredential(), opts));
            }
            else
            {
                admClient = InstrumentClient(new PersistentAgentsAdministrationClient(connectionString, new DefaultAzureCredential(), opts));
            }

            return new PersistentAgentsClient(admClient);
        }

        #endregion

        #region Cleanup
        [TearDown]
        public void Cleanup()
        {
            DirectoryInfo tempDir = new(Path.Combine(Path.GetTempPath(), "cs_e2e_temp_dir"));
            if (tempDir.Exists)
            {
                tempDir.Delete(true);
            }

            if (Mode == RecordedTestMode.Playback)
                return;

            PersistentAgentsClient client;
            var cli = Environment.GetEnvironmentVariable("USE_CLI_CREDENTIAL");
            if (!string.IsNullOrEmpty(cli) && string.Compare(cli, "true", StringComparison.OrdinalIgnoreCase) == 0)
            {
                client = new PersistentAgentsClient(TestEnvironment.PROJECT_ENDPOINT, new AzureCliCredential());
            }
            else
            {
                client = new PersistentAgentsClient(TestEnvironment.PROJECT_ENDPOINT, new DefaultAzureCredential());
            }

            // Remove agent
            Pageable<PersistentAgent> agents = client.Administration.GetAgents();
            foreach (PersistentAgent agent in agents)
            {
                if (agent.Name.StartsWith(AGENT_NAME))
                    client.Administration.DeleteAgent(agent.Id);
            }

            // Remove thread
            Pageable<PersistentAgentThread> threads = client.Threads.GetThreads();
            foreach (PersistentAgentThread thread in threads)
            {
                if (thread.Id == _threadId)
                    client.Threads.DeleteThread(thread.Id);
            }
        }
        #endregion
    }
}
