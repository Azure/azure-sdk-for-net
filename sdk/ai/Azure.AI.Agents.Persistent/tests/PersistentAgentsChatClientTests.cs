// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private const string FILE_UPLOAD_CONSTRAINT = "The file is being uploaded as a multipart multipart/form-data, which cannot be recorded.";
        private const string FILE_NAME = "stock-prices.txt";
        private const string VCT_STORE_NAME = "cs_e2e_tests_chat_client_vct_store";

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
            WithResponseFormat,
            WithJsonSchemaResponseFormat
        }
        #endregion

        [SetUp]
        public async Task Setup()
        {
            using IDisposable _ = SetTestSwitch();
            PersistentAgentsClient client = GetClient();
            PersistentAgent agent = await client.Administration.CreateAgentAsync(
                model: "gpt-4o",
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
        [TestCase(ChatOptionsTestType.WithJsonSchemaResponseFormat)]
        public async Task TestGetStreamingResponseAsync(ChatOptionsTestType optionsType)
        {
            // This test will not record the sync version, however, CI/CD will still check
            // the existence of this file. Just copy assets for
            // TestGetStreamingResponseAsync(***)Async to TestGetStreamingResponseAsync(***)
            // in net\sdk\ai\Azure.AI.Agents.Persistent\tests\SessionRecords\PersistentAgentsChatClientTests
            // assets folder to make CI/CD pass.
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
            else if (optionsType == ChatOptionsTestType.WithJsonSchemaResponseFormat)
            {
                var schema = """
                {
                    "$schema": "http://json-schema.org/draft-07/schema#",
                    "type": "object",
                    "properties": {
                        "name": {
                            "type": "string",
                            "description": "The full name of the person."
                        },
                        "age": {
                            "type": "integer",
                            "description": "The age of the person in years."
                        },
                        "occupation": {
                            "type": "string",
                            "description": "The primary occupation or job title of the person."
                        }
                    },
                    "required": ["name", "age", "occupation"]
                }
                """;
                var jsonSchema = JsonSerializer.Deserialize<JsonElement>(schema, JsonSerializerOptions.Default);
                options = new ChatOptions
                {
                    ResponseFormat = ChatResponseFormatJson.ForJsonSchema(jsonSchema, "TestSchema", "Schema for testing purposes")
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
        public async Task TestFileSearchToolOutputs()
        {
            // This test will not record the sync version, however, CI/CD will still check
            // the existence of this file. Just copy assets for
            // TestGetStreamingResponseAsync(***)Async to TestGetStreamingResponseAsync(***)
            // in net\sdk\ai\Azure.AI.Agents.Persistent\tests\SessionRecords\PersistentAgentsChatClientTests
            // assets folder to make CI/CD pass.
            if (!IsAsync)
            {
                Assert.Inconclusive(STREAMING_CONSTRAINT);
            }

            if (Mode != RecordedTestMode.Live)
            {
                Assert.Inconclusive(FILE_UPLOAD_CONSTRAINT);
            }

            using IDisposable _ = SetTestSwitch();

            PersistentAgentsClient client = GetClient();

            var fileDataSource = await client.Files.UploadFileAsync(GetFile(), PersistentAgentFilePurpose.Agents);
            var vectorStoreSource = await client.VectorStores.CreateVectorStoreAsync(
                name: VCT_STORE_NAME,
                fileIds: [fileDataSource.Value.Id]
            );

            // Create the file search tool with the vector store.
            HostedFileSearchTool fileSearchTool = new() { Inputs = [new HostedVectorStoreContent(vectorStoreSource.Value.Id)] };
            ChatOptions chatOptions = new() { Tools = [fileSearchTool] };

            PersistentAgentsChatClient chatClient = new(client, _agentId, _threadId);

            List<ChatMessage> messages = [];
            messages.Add(new ChatMessage(ChatRole.User, [new TextContent("I provided to you a file with the stock prices for Microsoft, can you please see what were the value for Microsoft for it?")]));

            ChatResponse response = await chatClient.GetResponseAsync(messages, chatOptions);

            List<AIAnnotation> annotations = [];
            foreach (ChatMessage message in response.Messages)
            {
                foreach (AIContent content in message.Contents)
                {
                    if (content.Annotations is not null)
                    {
                        annotations.AddRange(content.Annotations);
                    }
                }
            }

            Assert.NotZero(annotations.Count);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Messages);
            Assert.GreaterOrEqual(response.Messages.Count, 1);
            Assert.AreEqual(ChatRole.Assistant, response.Messages[0].Role);
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
                model: "gpt-4o",
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
                model: "gpt-4o",
                name: AGENT_NAME,
                instructions: "Use the provided function to answer questions.",
                tools: [wordTool]
            );

            // Second tool is registered per request.
            ChatOptions chatOptions = new()
            {
                Tools = [AIFunctionFactory.Create((string city) => "It's 80 degrees and sunny.", "GetWeather", "Get the current weather for a specific city")],
                ToolMode = ChatToolMode.Auto,
                AllowMultipleToolCalls = true
            };

            PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

            PersistentAgentsChatClient chatClient = new(client, agent.Id, thread.Id);

            ChatResponse response = await chatClient.GetResponseAsync(new ChatMessage(ChatRole.User, "Get Mike's favourite word"), chatOptions);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Messages);
            Assert.GreaterOrEqual(response.Messages.Count, 1);
            Assert.AreEqual(ChatRole.Assistant, response.Messages[0].Role);

            List<string> functionNames = response.Messages[0].Contents
                .OfType<FunctionCallContent>()
                .Select(c => c.Name)
                .ToList();

            Assert.Contains("GetFavouriteWord", functionNames);
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
            var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
            PersistentAgentsAdministrationClientOptions opts = InstrumentClientOptions(new PersistentAgentsAdministrationClientOptions());
            PersistentAgentsAdministrationClient admClient;

            if (Mode == RecordedTestMode.Playback)
            {
                admClient = InstrumentClient(new PersistentAgentsAdministrationClient(projectEndpoint, new MockCredential(), opts));
                return new PersistentAgentsClient(admClient);
            }

            var cli = Environment.GetEnvironmentVariable("USE_CLI_CREDENTIAL");
            if (!string.IsNullOrEmpty(cli) && string.Compare(cli, "true", StringComparison.OrdinalIgnoreCase) == 0)
            {
                admClient = InstrumentClient(new PersistentAgentsAdministrationClient(projectEndpoint, new AzureCliCredential(), opts));
            }
            else
            {
                admClient = InstrumentClient(new PersistentAgentsAdministrationClient(projectEndpoint, new DefaultAzureCredential(), opts));
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
                if (agent.Name is not null && agent.Name.StartsWith(AGENT_NAME))
                    client.Administration.DeleteAgent(agent.Id);
            }

            // Remove thread
            Pageable<PersistentAgentThread> threads = client.Threads.GetThreads();
            foreach (PersistentAgentThread thread in threads)
            {
                if (thread.Id == _threadId)
                    client.Threads.DeleteThread(thread.Id);
            }

            // Remove all files
            IReadOnlyList<PersistentAgentFileInfo> files = client.Files.GetFiles().Value;
            foreach (PersistentAgentFileInfo af in files)
            {
                if (af.Filename.Equals(FILE_NAME) || af.Filename.Equals(FILE_NAME))
                    client.Files.DeleteFile(af.Id);
            }

            // Remove all vector stores
            List<PersistentAgentsVectorStore> stores = [.. client.VectorStores.GetVectorStores()];
            foreach (PersistentAgentsVectorStore store in stores)
            {
                if (store.Name == null || store.Name.Equals(VCT_STORE_NAME))
                    client.VectorStores.DeleteVectorStore(store.Id);
            }
        }
        #endregion

        private static string GetFile([CallerFilePath] string pth = "", string fileName = FILE_NAME)
        {
            var dirName = Path.GetDirectoryName(pth) ?? "";
            return Path.Combine(new string[] { dirName, "TestData", fileName });
        }
    }
}
