// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class AgentClientTests : RecordedTestBase<AIProjectsTestEnvironment>
    {
        private const string AGENT_NAME = "cs_e2e_tests_client";
        private const string AGENT_NAME2 = "cs_e2e_tests_client2";
        private const string VCT_STORE_NAME = "cs_e2e_tests_vct_store";
        private const string FILE_NAME = "product_info_1.md";
        private const string FILE_NAME2 = "test_file.txt";
        private const string TEMP_DIR = "cs_e2e_temp_dir";

        private const string FILE_UPLOAD_CONSTRAINT = "The file is being uploaded as a multipart multipart/form-data, which cannot be recorded.";
        private const string STREAMING_CONSTRAINT = "The test framework does not support iteration of stream in Sync mode.";

        public AgentClientTests(bool isAsync) : base(isAsync) {
            TestDiagnostics = false;
        }

        #region enumerations
        public enum ArgumentType
        {
            Metadata,
            Bytes,
            Stream
        }

        public enum VecrorStoreTestType
        {
            JustVectorStore,
            Batch,
            File
        }
        #endregion

        [RecordedTest]
        [TestCase(ArgumentType.Metadata)]
        [TestCase(ArgumentType.Bytes)]
        [TestCase(ArgumentType.Stream)]
        public async Task TestCreateAgent(ArgumentType argType)
        {
            AgentsClient client = GetClient();
            string id;
            string name;
            if (argType == ArgumentType.Metadata)
            {
                Response<Agent> agentResponse = await client.CreateAgentAsync(
                model: "gpt-4",
                name: AGENT_NAME,
                instructions: "You are helpful assistant."
                );
                id = agentResponse.Value.Id;
                name = agentResponse.Value.Name;
            }
            else
            {
                object objParams = new {
                    model = "gpt-4",
                    name = AGENT_NAME,
                    instructions = "You are helpful assistant"
                };
                RequestContent content = argType == ArgumentType.Bytes?RequestContent.Create(GetBytes(objParams)): RequestContent.Create(GetStream(objParams));
                Response agentResponse = await client.CreateAgentAsync(content);
                id = GetFieldFromJson(agentResponse.Content, "id");
                name = GetFieldFromJson(agentResponse.Content, "name");
            }
            Assert.AreNotEqual(default, id);
            Assert.AreEqual(name, AGENT_NAME);
            Response<bool> delResponse = await client.DeleteAgentAsync(id);
            Assert.IsTrue(delResponse.Value);
        }

        [RecordedTest]
        [TestCase(ArgumentType.Metadata)]
        [TestCase(ArgumentType.Bytes)]
        [TestCase(ArgumentType.Stream)]
        public async Task TestUpdateAgent(ArgumentType argType)
        {
            AgentsClient client = GetClient();
            Agent agent = await GetAgent(client);
            string name = default;
            if (argType == ArgumentType.Metadata)
            {
                Response<Agent> agentResponse = await client.UpdateAgentAsync(
                assistantId: agent.Id,
                model: "gpt-4",
                name: AGENT_NAME2,
                instructions: "You are helpful assistant."
                );
                name = agentResponse.Value.Name;
            }
            else
            {
                object objParams = new
                {
                    model = "gpt-4",
                    name = AGENT_NAME2,
                    instructions = "You are helpful assistant"
                };
                RequestContent content = argType == ArgumentType.Bytes ? RequestContent.Create(GetBytes(objParams)) : RequestContent.Create(GetStream(objParams));
                Response agentResponse = await client.UpdateAgentAsync(agent.Id, content);
                name = GetFieldFromJson(agentResponse.Content, "name");
            }
            Assert.AreEqual(AGENT_NAME2, name);
        }

        [RecordedTest]
        public async Task TestListAgent()
        {
            AgentsClient client = GetClient();
            // Note: if the numer  of arent will be bigger then 100 this test will fail.
            HashSet<string> ids = new();
            int initialAgentCount = await CountElementsAndRemoveIds(client, ids);
            Agent agent1 = await GetAgent(client, AGENT_NAME);
            ids = [agent1.Id];
            int count = await CountElementsAndRemoveIds(client, ids);
            Assert.AreEqual(0, ids.Count);
            Assert.AreEqual(initialAgentCount + 1, count);

            Agent agent2 = await GetAgent(client, AGENT_NAME2);
            ids.Add(agent1.Id);
            ids.Add(agent2.Id);
            count = await CountElementsAndRemoveIds(client, ids);
            Assert.AreEqual(0, ids.Count);
            Assert.AreEqual(initialAgentCount + 2, count);

            DeleteAndAssert(client, agent1);
            ids.Add(agent1.Id);
            ids.Add(agent2.Id);
            count = await CountElementsAndRemoveIds(client, ids);
            Assert.AreEqual(1, ids.Count);
            Assert.False(ids.Contains(agent2.Id));
            Assert.AreEqual(initialAgentCount + 1, count);
            DeleteAndAssert(client, agent2);
        }

        [RecordedTest]
        [TestCase(ArgumentType.Metadata)]
        [TestCase(ArgumentType.Bytes)]
        [TestCase(ArgumentType.Stream)]
        public async Task TestCreateThread(ArgumentType argType)
        {
            AgentsClient client = GetClient();
            Agent agent = await GetAgent(client);

            string thread_id;
            IReadOnlyDictionary<string, string> metadata;
            if (argType == ArgumentType.Metadata)
            {
                Response<AgentThread> threadResponse = await client.CreateThreadAsync(
                    metadata: new Dictionary<string, string> {
                        {"key1", "value1"},
                        {"key2", "value2"}
                    });
                thread_id = threadResponse.Value.Id;
                metadata = threadResponse.Value.Metadata;
            }
            else
            {
                object data = new
                {
                    metadata = new
                    {
                        key1="value1",
                        key2="value2"
                    }
                };
                RequestContent content = argType == ArgumentType.Bytes ? RequestContent.Create(GetBytes(data)) : RequestContent.Create(GetStream(data));
                Response rawThreadResponse = await client.CreateThreadAsync(content);
                thread_id = GetFieldFromJson(rawThreadResponse.Content, "id");
                Response<AgentThread> threadResponse = await client.GetThreadAsync(thread_id);
                metadata = threadResponse.Value.Metadata;
            }
            Assert.AreNotEqual(default, thread_id);
            Assert.AreEqual(2, metadata.Count);

            // Test delete thread
            Response<bool> delResponse = await client.DeleteThreadAsync(thread_id);
            Assert.True(delResponse);
        }

        [RecordedTest]
        [TestCase(ArgumentType.Metadata)]
        [TestCase(ArgumentType.Bytes)]
        [TestCase(ArgumentType.Stream)]
        public async Task TestUpdateThread(ArgumentType argType)
        {
            AgentsClient client = GetClient();
            AgentThread thread = await GetThread(client);
            Assert.AreEqual(0, thread.Metadata.Count);

            if (argType == ArgumentType.Metadata)
            {
                //"metadata": {"key1": "value1", "key2": "value2"},
                await client.UpdateThreadAsync(
                    thread.Id,
                    metadata: new Dictionary<string, string> {
                        {"key1", "value1"},
                        {"key2", "value2"}
                    });
            }
            else
            {
                object data = new
                {
                    metadata = new
                    {
                        key1 = "value1",
                        key2 = "value2"
                    }
                };
                RequestContent content = argType == ArgumentType.Bytes ? RequestContent.Create(GetBytes(data)) : RequestContent.Create(GetStream(data));
                await client.UpdateThreadAsync(thread.Id, content);
            }

            // Test get thread
            Response<AgentThread> getThreadResponse = await client.GetThreadAsync(thread.Id);
            thread = getThreadResponse.Value;
            Assert.AreNotEqual(default, thread.Id);
            Assert.AreEqual(2, thread.Metadata.Count);

            // Test delete thread
            Response<bool> delResponse = await client.DeleteThreadAsync(thread.Id);
            Assert.True(delResponse);
        }

        [RecordedTest]
        [TestCase(ArgumentType.Metadata)]
        [TestCase(ArgumentType.Bytes)]
        [TestCase(ArgumentType.Stream)]
        public async Task TestCreateMessage(ArgumentType argType)
        {
            AgentsClient client = GetClient();
            AgentThread thread = await GetThread(client);
            ThreadMessage tmTest;
            string message = "Hello, tell me a joke";
            if (argType == ArgumentType.Metadata)
            {
                Response<ThreadMessage> msg = await client.CreateMessageAsync(thread.Id, MessageRole.User, message);
                tmTest = msg.Value;
            }
            else
            {
                object data = new
                {
                    role = "user",
                    content = message
                };
                RequestContent content = argType == ArgumentType.Bytes ? RequestContent.Create(GetBytes(data)) : RequestContent.Create(GetStream(data));
                Response rawMsg = await client.CreateMessageAsync(thread.Id, content);
                Response<ThreadMessage> msg = await client.GetMessageAsync(thread.Id, GetFieldFromJson(rawMsg.Content, "id"));
                tmTest = msg.Value;
            }
            Assert.AreEqual(1, tmTest.ContentItems.Count);
            Assert.IsTrue(tmTest.ContentItems[0] is MessageTextContent text);
            Assert.AreEqual(message, ((MessageTextContent)tmTest.ContentItems[0]).Text);
        }

        [RecordedTest]
        [TestCase(ArgumentType.Metadata)]
        [TestCase(ArgumentType.Bytes)]
        [TestCase(ArgumentType.Stream)]
        public async Task TestUpdateMessage(ArgumentType argType)
        {
            AgentsClient client = GetClient();
            AgentThread thread = await GetThread(client);
            ThreadMessage tmTest;
            Response<ThreadMessage> oldMsgResp = await client.CreateMessageAsync(
                thread.Id,
                MessageRole.User,
                "Hello, tell me a joke");
            Assert.AreEqual(0, oldMsgResp.Value.Metadata.Count);
            if (argType == ArgumentType.Metadata)
            {
                Response<ThreadMessage> msg = await client.UpdateMessageAsync(thread.Id, oldMsgResp.Value.Id, metadata: new Dictionary<string, string> {
                        {"key1", "value1"},
                        {"key2", "value2"}
                });
                tmTest = msg.Value;
            }
            else
            {
                object data = new
                {
                    metadata = new
                    {
                        key1 = "value1",
                        key2 = "value2"
                    }
                };
                RequestContent content = argType == ArgumentType.Bytes ? RequestContent.Create(GetBytes(data)) : RequestContent.Create(GetStream(data));
                Response rawMsg = await client.UpdateMessageAsync(thread.Id, oldMsgResp.Value.Id, content);
                Response<ThreadMessage> msg = await client.GetMessageAsync(thread.Id, GetFieldFromJson(rawMsg.Content, "id"));
                tmTest = msg.Value;
            }
            Assert.AreEqual(2, tmTest.Metadata.Count);
        }

        [RecordedTest]
        public async Task TestListMessage()
        {
            AgentsClient client = GetClient();
            AgentThread thread = await GetThread(client);
            Response<PageableList<ThreadMessage>> msgResp = await client.GetMessagesAsync(thread.Id);
            Assert.AreEqual(0, msgResp.Value.Data.Count);

            HashSet<string> ids = new();
            ThreadMessage msg1 = await client.CreateMessageAsync(thread.Id, MessageRole.User, "foo");
            ids.Add(msg1.Id);
            msgResp = await client.GetMessagesAsync(thread.Id);
            foreach (ThreadMessage msg in msgResp.Value)
            {
                ids.Remove(msg.Id);
            }
            Assert.AreEqual(0, ids.Count);
            Assert.AreEqual(1, msgResp.Value.Data.Count);

            ThreadMessage msg2 = await client.CreateMessageAsync(thread.Id, MessageRole.User, "bar");
            ids.Add(msg1.Id);
            ids.Add(msg2.Id);
            msgResp = await client.GetMessagesAsync(thread.Id);
            foreach (ThreadMessage msg in msgResp.Value)
            {
                ids.Remove(msg.Id);
            }
            Assert.AreEqual(0, ids.Count);
            Assert.AreEqual(2, msgResp.Value.Data.Count);
        }

        [RecordedTest]
        [TestCase(ArgumentType.Metadata)]
        [TestCase(ArgumentType.Bytes)]
        [TestCase(ArgumentType.Stream)]
        public async Task TestCreateRun(ArgumentType argType)
        {
            AgentsClient client = GetClient();
            Agent agent = await GetAgent(client);
            AgentThread thread = await GetThread(client);
            await client.CreateMessageAsync(thread.Id, MessageRole.User, "Hello, tell me a joke");
            ThreadRun result;
            if (argType == ArgumentType.Metadata)
            {
                Response<ThreadRun> runResp = await client.CreateRunAsync(thread.Id, agent.Id);
                result = runResp.Value;
            }
            else
            {
                object data = new
                {
                    assistant_id = agent.Id
                };
                RequestContent content = argType == ArgumentType.Bytes ? RequestContent.Create(GetBytes(data)) : RequestContent.Create(GetStream(data));
                Response rawRun = await client.CreateRunAsync(thread.Id, content);
                Response<ThreadRun> resResp = await client.GetRunAsync(thread.Id, GetFieldFromJson(rawRun.Content, "id"));
                result = resResp.Value;
            }
            Assert.AreEqual(agent.Id, result.AssistantId);
            Assert.AreEqual(thread.Id, result.ThreadId);
            //  Check run status
            result = await WaitForRun(client, result);
            Response<PageableList<ThreadMessage>> msgResp = await client.GetMessagesAsync(thread.Id);
            Assert.AreEqual(2, msgResp.Value.Data.Count);
            Assert.AreEqual(MessageRole.Agent, msgResp.Value.Data[0].Role);
            Assert.AreEqual(MessageRole.User, msgResp.Value.Data[1].Role);
            // Get Run steps
            PageableList<RunStep> steps = await client.GetRunStepsAsync(result);
            Assert.GreaterOrEqual(steps.Data.Count, 1);
            RunStep step = await client.GetRunStepAsync(result.ThreadId, result.Id, steps.Data[0].Id);
            Assert.AreEqual(steps.Data[0].Id, step.Id);
        }

        [RecordedTest]
        [TestCase(ArgumentType.Metadata)]
        [TestCase(ArgumentType.Bytes)]
        [TestCase(ArgumentType.Stream)]
        public async Task TestCreateThreadAndRun(ArgumentType argType)
        {
            AgentsClient client = GetClient();
            Agent agent = await GetAgent(client);
            ThreadRun result;
            var threadOp = new AgentThreadCreationOptions();
            threadOp.Messages.Add(new ThreadMessageOptions(
                role: MessageRole.User,
                content: "Hello, tell me a joke"
            ));
            if (argType == ArgumentType.Metadata)
            {
                result = await client.CreateThreadAndRunAsync(
                    assistantId: agent.Id,
                    thread: threadOp,
                    metadata: new Dictionary<string, string> {
                            { "key1", "value1"},
                            { "key2", "value2"}
                        }
                );
            }
            else
            {
                object data = new
                {
                    assistant_id = agent.Id,
                    thread = new {
                        messages = new object[]
                        {
                            new {
                                role = MessageRole.User.ToString(),
                                content = "Hello, tell me a joke",
                            }
                        }
                    },
                    metadata = new
                    {
                        key1 = "value1",
                        key2 = "value2"
                    }
                };
                RequestContent content = argType == ArgumentType.Bytes ? RequestContent.Create(GetBytes(data)) : RequestContent.Create(GetStream(data));
                Response rawRun = await client.CreateThreadAndRunAsync(content);
                result = await client.GetRunAsync(
                    GetFieldFromJson(rawRun.Content, "thread_id"),
                    GetFieldFromJson(rawRun.Content, "id"));
            }
            Assert.AreEqual(agent.Id, result.AssistantId);
            //  Check run status
            result = await WaitForRun(client, result);
            Response<PageableList<ThreadMessage>> msgResp = await client.GetMessagesAsync(result.ThreadId);
            Assert.AreEqual(2, msgResp.Value.Data.Count);
            Assert.AreEqual(MessageRole.Agent, msgResp.Value.Data[0].Role);
            Assert.AreEqual(MessageRole.User, msgResp.Value.Data[1].Role);
        }

        [RecordedTest]
        [TestCase(ArgumentType.Metadata)]
        [TestCase(ArgumentType.Bytes)]
        [TestCase(ArgumentType.Stream)]
        public async Task TestUpdateRun(ArgumentType argType)
        {
            AgentsClient client = GetClient();
            Agent agent = await GetAgent(client);
            AgentThread thread = await GetThread(client);
            await client.CreateMessageAsync(thread.Id, MessageRole.User, "Hello, tell me a joke");
            ThreadRun  runResp = await client.CreateRunAsync(thread.Id, agent.Id);
            runResp = await WaitForRun(client, runResp);
            Assert.AreEqual(0, runResp.Metadata.Count);
            if (argType == ArgumentType.Metadata)
            {
                runResp = await client.UpdateRunAsync(
                    threadId: thread.Id,
                    runId: runResp.Id,
                    metadata: new Dictionary<string, string> {
                            { "key1", "value1"},
                            { "key2", "value2"}
                        }
                    );
            }
            else
            {
                object data = new
                {
                    metadata = new
                    {
                        key1 = "value1",
                        key2 = "value2"
                    }
                };
                RequestContent content = argType == ArgumentType.Bytes ? RequestContent.Create(GetBytes(data)) : RequestContent.Create(GetStream(data));
                Response rawRun = await client.UpdateRunAsync(thread.Id, runResp.Id, content);
                runResp = await client.GetRunAsync(thread.Id, GetFieldFromJson(rawRun.Content, "id"));
            }
            Assert.AreEqual(2, runResp.Metadata.Count);
        }

        [RecordedTest]
        public async Task ListDeleteRuns()
        {
            AgentsClient client = GetClient();
            Agent agent = await GetAgent(client);
            AgentThread thread = await GetThread(client);
            await client.CreateMessageAsync(thread.Id, MessageRole.User, "Hello, tell me a joke");
            ThreadRun runResp1 = await client.CreateRunAsync(thread.Id, agent.Id);
            runResp1 = await WaitForRun(client, runResp1);
            ThreadRun runResp2 = await client.CreateRunAsync(thread.Id, agent.Id);
            runResp2 = await WaitForRun(client, runResp2);
            PageableList<ThreadRun> runsResp = await client.GetRunsAsync(thread.Id, limit: 1);
            Assert.AreEqual(1, runsResp.Count());
            runsResp = await client.GetRunsAsync(thread.Id);
            Assert.AreEqual(2, runsResp.Count());
            HashSet<string> ids = [runResp1.Id, runResp2.Id];
            foreach (ThreadRun rn in runsResp)
            {
                ids.Remove(rn.Id);
            }
            Assert.AreEqual(0, ids.Count);
        }

        [RecordedTest]
        [TestCase(ArgumentType.Metadata, true, false)]
        [TestCase(ArgumentType.Bytes, true, false)]
        [TestCase(ArgumentType.Stream, false, false)]
        [TestCase(ArgumentType.Metadata, true, true)]
        [TestCase(ArgumentType.Metadata, false, true)]
        public async Task TestSubmitToolOutputs(ArgumentType argType, bool parallelToolCalls, bool CreateThreadAndRun)
        {
            AgentsClient client = GetClient();
            FunctionToolDefinition getFavouriteNameTool = new(
                name: "getFavouriteWord",
                description: "Gets the favourite word of the person.",
                parameters: BinaryData.FromObjectAsJson(
                    new
                    {
                        Type = "object",
                        Properties = new
                        {
                            Name = new
                            {
                                Type = "string",
                                Description = "The name of the person.",
                            },
                        },
                        Required = new[] { "name" },
                    },
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
            Agent agent = await client.CreateAgentAsync(
                model: "gpt-4",
                name: AGENT_NAME,
                instructions: "Use the provided functions to help answer questions.",
                tools: new List<ToolDefinition> { getFavouriteNameTool }
            );
            ThreadRun toolRun;
            if (CreateThreadAndRun)
            {
                var threadOp = new AgentThreadCreationOptions();
                threadOp.Messages.Add(new ThreadMessageOptions(
                    role: MessageRole.User,
                    content: "Tell me the favourite word of Mike?"
                ));
                toolRun = await client.CreateThreadAndRunAsync(
                    assistantId: agent.Id,
                    thread: threadOp,
                    parallelToolCalls: parallelToolCalls
                );
            }
            else
            {
                AgentThread thread = await GetThread(client);
                await client.CreateMessageAsync(thread.Id, MessageRole.User, "Tell me the favourite word of Mike?");
                toolRun = await client.CreateRunAsync(
                    threadId: thread.Id,
                    assistantId: agent.Id,
                    parallelToolCalls: parallelToolCalls
                );
            }
            bool functionCalled = false;
            do
            {
                await Task.Delay(TimeSpan.FromMilliseconds(500));
                toolRun = await client.GetRunAsync(toolRun.ThreadId, toolRun.Id);
                if (toolRun.Status == RunStatus.RequiresAction && toolRun.RequiredAction is SubmitToolOutputsAction submitToolOutputsAction)
                {
                    List<ToolOutput> toolOutputs = new();
                    Assert.AreEqual(1, submitToolOutputsAction.ToolCalls.Count);
                    functionCalled = true;
                    if (submitToolOutputsAction.ToolCalls[0] is RequiredFunctionToolCall functionToolCall)
                    {
                        using JsonDocument argumentsJson = JsonDocument.Parse(functionToolCall.Arguments);
                        string nameArgument = argumentsJson.RootElement.GetProperty("name").GetString();
                        Assert.AreEqual(0, string.Compare(nameArgument, "mike", true));
                        toolOutputs.Add(new ToolOutput(submitToolOutputsAction.ToolCalls[0], "bar"));
                    }
                    else
                    {
                        Assert.Fail("The toolCall is of a wrong type.");
                    }
                    if (argType == ArgumentType.Metadata)
                    {
                        toolRun = await client.SubmitToolOutputsToRunAsync(toolRun, toolOutputs);
                    }
                    else
                    {
                        object objToolOutput = new
                        {
                            tool_outputs = new object[] {
                                new {
                                    tool_call_id = toolOutputs[0].ToolCallId,
                                    output = toolOutputs[0].Output
                                }
                            }
                        };
                        RequestContent content = argType == ArgumentType.Bytes ? RequestContent.Create(GetBytes(objToolOutput)) : RequestContent.Create(GetStream(objToolOutput));
                        await client.SubmitToolOutputsToRunAsync(toolRun.ThreadId, toolRun.Id, content);
                        toolRun = await client.GetRunAsync(toolRun.ThreadId, toolRun.Id);
                    }
                }
            }
            while (toolRun.Status == RunStatus.Queued
                || toolRun.Status == RunStatus.InProgress
                || toolRun.Status == RunStatus.RequiresAction);
            Assert.True(functionCalled);
            Assert.AreEqual(toolRun.Status, RunStatus.Completed);
            PageableList<ThreadMessage> messages = await client.GetMessagesAsync(toolRun.ThreadId, toolRun.Id);
            Assert.Greater(messages.Data.Count, 1);
            Assert.AreEqual(parallelToolCalls, toolRun.ParallelToolCalls);
        }

        [RecordedTest]
        [TestCase(VecrorStoreTestType.JustVectorStore, true, false)]
        [TestCase(VecrorStoreTestType.Batch, true, false)]
        [TestCase(VecrorStoreTestType.File, true, false)]
        [TestCase(VecrorStoreTestType.JustVectorStore, false, false)]
        [TestCase(VecrorStoreTestType.Batch, false, false)]
        [TestCase(VecrorStoreTestType.File, false, false)]
        [TestCase(VecrorStoreTestType.JustVectorStore, true, true)]
        [TestCase(VecrorStoreTestType.Batch, true, true)]
        [TestCase(VecrorStoreTestType.File, true, true)]
        [TestCase(VecrorStoreTestType.JustVectorStore, false, true)]
        [TestCase(VecrorStoreTestType.Batch, false, true)]
        [TestCase(VecrorStoreTestType.File, false, true)]
        public async Task TestCreateVectorStore(VecrorStoreTestType testType, bool useFileSource, bool useStreaming)
        {
            if (useFileSource && Mode != RecordedTestMode.Live)
                Assert.Inconclusive(FILE_UPLOAD_CONSTRAINT);
            if (useStreaming && !IsAsync)
                Assert.Inconclusive(STREAMING_CONSTRAINT);
            AgentsClient client = GetClient();
            VectorStore vectorStore;

            AgentFile fileDataSource = null;
            VectorStoreDataSource vectorStoreDataSource = null;
            VectorStoreConfiguration vectorStoreConf = null;
            List<string> fileIds = null;
            if (useFileSource)
            {
                fileDataSource = await client.UploadFileAsync(GetFile(), AgentFilePurpose.Agents);
                fileIds = [ fileDataSource.Id ];
            }
            else
            {
                vectorStoreDataSource = new VectorStoreDataSource(
                    assetIdentifier: TestEnvironment.AZURE_BLOB_URI,
                    assetType: VectorStoreDataSourceAssetType.UriAsset
                );
                vectorStoreConf = new VectorStoreConfiguration(
                    dataSources: [ vectorStoreDataSource ]
                );
            }
            if (testType == VecrorStoreTestType.JustVectorStore)
            {
                vectorStore = await client.CreateVectorStoreAsync(
                    name: VCT_STORE_NAME,
                    storeConfiguration: vectorStoreConf,
                    fileIds: fileIds
                );
            }
            else
            {
                vectorStore = await client.CreateVectorStoreAsync(
                    name: VCT_STORE_NAME
                );
                if (testType == VecrorStoreTestType.Batch)
                {
                    await client.CreateVectorStoreFileBatchAsync(
                        vectorStoreId: vectorStore.Id,
                        dataSources: vectorStoreConf?.DataSources,
                        fileIds: fileIds
                        );
                }
                else
                {
                    await client.CreateVectorStoreFileAsync(
                        vectorStoreId: vectorStore.Id,
                        dataSource: vectorStoreConf?.DataSources[0],
                        fileId: fileDataSource?.Id
                        );
                }
            }
            // Test file search
            FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
            fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);
            Agent agent = await client.CreateAgentAsync(
                model: "gpt-4",
                name: "SDK Test Agent - Retrieval",
                instructions: "You are a helpful agent that can help fetch data from files you know about.",
                tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
                toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
            var threadOp = new AgentThreadCreationOptions();
            threadOp.Messages.Add(new ThreadMessageOptions(
                role: MessageRole.User,
                content: "What does the attachment say?"
            ));
            ThreadRun fileSearchRun = default;
            if (useStreaming)
            {
                AgentThread thread = await client.CreateThreadAsync(messages: [new ThreadMessageOptions(
                    role: MessageRole.User,
                    content: "What does the attachment say?"
                )]);
                await foreach (StreamingUpdate streamingUpdate in client.CreateRunStreamingAsync(thread.Id, agent.Id))
                {
                    if (streamingUpdate is RunUpdate runUpdate)
                        fileSearchRun = runUpdate.Value;
                }
                Assert.AreEqual(RunStatus.Completed, fileSearchRun.Status, fileSearchRun.LastError?.ToString());
            }
            else
            {
                fileSearchRun = await client.CreateThreadAndRunAsync(
                    assistantId: agent.Id,
                    thread: threadOp
                );
                fileSearchRun = await WaitForRun(client, fileSearchRun);
            }
            Assert.IsNotNull(fileSearchRun);
            PageableList<ThreadMessage> messages = await client.GetMessagesAsync(fileSearchRun.ThreadId, fileSearchRun.Id);
            Assert.Greater(messages.Data.Count, 1);
            // Check list, get and delete operations.
            VectorStore getVct = await client.GetVectorStoreAsync(vectorStore.Id);
            Assert.AreEqual(vectorStore.Id, getVct.Id);
            AgentPageableListOfVectorStore stores = await client.GetVectorStoresAsync(limit: 100);
            getVct = null;
            foreach (VectorStore store in stores.Data)
            {
                if (store.Id == vectorStore.Id)
                {
                    getVct = store;
                    break;
                }
            }
            Assert.NotNull(getVct);
            VectorStoreDeletionStatus removed = await client.DeleteVectorStoreAsync(vectorStore.Id);
            Assert.True(removed.Deleted);
            stores = await client.GetVectorStoresAsync(limit: 100);
            getVct = null;
            foreach (VectorStore store in stores.Data)
            {
                if (store.Id == vectorStore.Id)
                {
                    getVct = store;
                    break;
                }
            }
            Assert.IsNull(getVct);
        }

        [RecordedTest]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public async Task TestCreateWithMessageAttachment(bool useFileSource, bool attachmentOnThread)
        {
            if (useFileSource && Mode != RecordedTestMode.Live)
                Assert.Inconclusive(FILE_UPLOAD_CONSTRAINT);
            AgentsClient client = GetClient();

            MessageAttachment attachment;
            List<ToolDefinition> tools = [
                new FileSearchToolDefinition(),
                new CodeInterpreterToolDefinition()
            ];
            string fileId = default;
            if (useFileSource)
            {
                AgentFile fileDataSource = await client.UploadFileAsync(GetFile(), AgentFilePurpose.Agents);
                fileId = fileDataSource.Id;
                attachment = new MessageAttachment(fileDataSource.Id, tools);
            }
            else
            {
                VectorStoreDataSource vectorStoreDataSource = new(
                    assetIdentifier: TestEnvironment.AZURE_BLOB_URI,
                    assetType: VectorStoreDataSourceAssetType.UriAsset
                );
                attachment = new MessageAttachment(vectorStoreDataSource, tools);
            }
            // Test file search
            Agent agent = await client.CreateAgentAsync(
                model: "gpt-4",
                name: "SDK Test Agent - Retrieval",
                instructions: "You are a helpful agent that can help fetch data from files you know about."
                );
            AgentThread thread;
            List<ThreadMessageOptions> opts = null;
            if (attachmentOnThread)
            {
                ThreadMessageOptions messageOp = new(
                    role: MessageRole.User,
                    content: "What does the attachment say?"
                );
                opts = [messageOp];
                thread = await client.CreateThreadAsync(messages: opts);
            }
            else
            {
                thread = await client.CreateThreadAsync();
                await client.CreateMessageAsync(
                    threadId: thread.Id,
                    role: MessageRole.User,
                    content: "What does the attachment say?",
                    attachments: [attachment]
                );
            }
            ThreadRun fileSearchRun = await client.CreateRunAsync(thread, agent);
            fileSearchRun = await WaitForRun(client, fileSearchRun);
            PageableList<ThreadMessage> messages = await client.GetMessagesAsync(fileSearchRun.ThreadId, fileSearchRun.Id);
            Assert.Greater(messages.Data.Count, 1);
        }

        [RecordedTest]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public async Task TestFileSearchWithCodeInterpreter(bool useFileSource, bool useThreads)
        {
            if (useFileSource && Mode != RecordedTestMode.Live)
                Assert.Inconclusive(FILE_UPLOAD_CONSTRAINT);
            AgentsClient client = GetClient();
            CodeInterpreterToolResource toolRes = new();
            if (useFileSource)
            {
                AgentFile fileDataSource = await client.UploadFileAsync(GetFile(), AgentFilePurpose.Agents);
                toolRes.FileIds.Add(fileDataSource.Id);
            }
            else
            {
                VectorStoreDataSource vectorStoreDataSource = new(
                    assetIdentifier: TestEnvironment.AZURE_BLOB_URI,
                    assetType: VectorStoreDataSourceAssetType.UriAsset
                );
                toolRes.DataSources.Add(vectorStoreDataSource);
            }
            ToolResources resources = new()
            {
                CodeInterpreter = toolRes
            };
            Agent agent = await client.CreateAgentAsync(
                model: "gpt-4",
                name: AGENT_NAME,
                instructions: "You are a helpful agent that can help fetch data from files you know about.",
                tools: [ new CodeInterpreterToolDefinition() ],
                toolResources: useThreads ? null : resources
            );
            AgentThread thread = await client.CreateThreadAsync(
                toolResources: useThreads ? resources : null
            );
            ThreadMessage message = await client.CreateMessageAsync(
                threadId: thread.Id,
                role: MessageRole.User,
                content: "What Contoso Galaxy Innovations produces?"
            );
            ThreadRun fileSearchRun = await client.CreateRunAsync(thread, agent);

            long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            fileSearchRun = await WaitForRun(client, fileSearchRun);
            Console.WriteLine((milliseconds - DateTimeOffset.Now.ToUnixTimeMilliseconds()) / 1000);
            PageableList<ThreadMessage> messages = await client.GetMessagesAsync(fileSearchRun.ThreadId, fileSearchRun.Id);
            Assert.Greater(messages.Data.Count, 1);
        }

        [RecordedTest]
        public async Task TestCreateVectorStoreOnline()
        {
            AgentsClient client = GetClient();
            VectorStoreDataSource vectorStoreDataSource = new(
                assetIdentifier: TestEnvironment.AZURE_BLOB_URI,
                assetType: VectorStoreDataSourceAssetType.UriAsset
            );
            FileSearchToolResource fileSearch = new();
            fileSearch.VectorStores.Add(new VectorStoreConfigurations(
                    storeName: VCT_STORE_NAME,
                    new VectorStoreConfiguration([vectorStoreDataSource])
                )
            );
            ToolResources tools = new()
            {
                FileSearch=fileSearch
            };
            Agent agent = await client.CreateAgentAsync(
                model: "gpt-4",
                name: AGENT_NAME,
                instructions: "You are a helpful agent that can help fetch data from files you know about.",
                tools: [new FileSearchToolDefinition()],
                toolResources: tools
            );
            AgentThread thread = await client.CreateThreadAsync();
            ThreadMessage message = await client.CreateMessageAsync(
                threadId: thread.Id,
                role: MessageRole.User,
                content: "What does the attachment say?"
            );
            ThreadRun fileSearchRun = await client.CreateRunAsync(thread, agent);

            fileSearchRun = await WaitForRun(client, fileSearchRun);
            PageableList<ThreadMessage> messages = await client.GetMessagesAsync(fileSearchRun.ThreadId, fileSearchRun.Id);
            Assert.Greater(messages.Data.Count, 1);
        }

        [RecordedTest]
        // TODO: Implement include in streaming scenario, see task 3801146.
        // [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public async Task TestIncludeFileSearchContent(bool useStream, bool includeContent)
        {
            if (useStream && !IsAsync)
                Assert.Inconclusive(STREAMING_CONSTRAINT);
            AgentsClient client = GetClient();
            VectorStoreDataSource vectorStoreDataSource = new(
                    assetIdentifier: TestEnvironment.AZURE_BLOB_URI,
                    assetType: VectorStoreDataSourceAssetType.UriAsset
                );
            VectorStoreConfiguration vectorStoreConf = new(
                dataSources: [vectorStoreDataSource]
            );
            VectorStore vctStore = await client.CreateVectorStoreAsync(
                name: VCT_STORE_NAME,
                storeConfiguration: vectorStoreConf
            );
            FileSearchToolResource fileSearch = new();
            fileSearch.VectorStoreIds.Add(vctStore.Id);

            ToolResources tools = new()
            {
                FileSearch = fileSearch
            };
            Agent agent = await client.CreateAgentAsync(
                model: "gpt-4",
                name: AGENT_NAME,
                instructions: "Hello, you are helpful assistant and can search information from uploaded files",
                tools: [new FileSearchToolDefinition()],
                toolResources: tools
            );
            AgentThread thread = await client.CreateThreadAsync();
            ThreadMessage message = await client.CreateMessageAsync(
                threadId: thread.Id,
                role: MessageRole.User,
                content: "What Contoso Galaxy Innovations produces?"
            );
            List<RunAdditionalFieldList> include = includeContent ? [RunAdditionalFieldList.FileSearchContents] : null;
            ThreadRun fileSearchRun = null;
            if (useStream)
            {
                // TODO: Implement include in streaming scenario, see task 3801146.
                await foreach (StreamingUpdate streamingUpdate in client.CreateRunStreamingAsync(thread.Id, agent.Id))
                {
                    if (streamingUpdate is RunUpdate runUpdate)
                        fileSearchRun = runUpdate.Value;
                }
                Assert.IsNotNull(fileSearchRun);
            }
            else
            {
                fileSearchRun = await client.CreateRunAsync(thread.Id, agent.Id, include: include);

                fileSearchRun = await WaitForRun(client, fileSearchRun);
                PageableList<ThreadMessage> messages = await client.GetMessagesAsync(fileSearchRun.ThreadId, fileSearchRun.Id);
                Assert.AreEqual(RunStatus.Completed, fileSearchRun.Status);
                Assert.Greater(messages.Data.Count, 1);
            }
            // TODO: Implement include in streaming scenario, see task 3801146.
            PageableList<RunStep> steps = await client.GetRunStepsAsync(
                threadId: fileSearchRun.ThreadId,
                runId: fileSearchRun.Id
            //    include: include
            );
            Assert.GreaterOrEqual(steps.Data.Count, 1);
            RunStep step = await client.GetRunStepAsync(fileSearchRun.ThreadId, fileSearchRun.Id, steps.Data[1].Id, include: include);

            Assert.That(step.StepDetails is RunStepToolCallDetails);
            RunStepToolCallDetails toolCallDetails = step.StepDetails as RunStepToolCallDetails;
            Assert.That(toolCallDetails.ToolCalls[0] is RunStepFileSearchToolCall);
            RunStepFileSearchToolCall fileSearchCall = toolCallDetails.ToolCalls[0] as RunStepFileSearchToolCall;
            Assert.Greater(fileSearchCall.FileSearch.Results.Count, 0);
            if (includeContent)
            {
                Assert.Greater(fileSearchCall.FileSearch.Results[0].Content.Count, 0);
                Assert.AreEqual(FileSearchToolCallContentType.Text, fileSearchCall.FileSearch.Results[0].Content[0].Type);
                Assert.False(string.IsNullOrEmpty(fileSearchCall.FileSearch.Results[0].Content[0].Text));
            }
            else
            {
                Assert.AreEqual(0, fileSearchCall.FileSearch.Results[0].Content.Count);
            }
        }

        [RecordedTest]
        public async Task TestAzureFunctionCall()
        {
            // Note: This test was recorded in westus region as for now
            // 2025-02-05 it is not supported in test region (East US 2)
            AzureFunctionToolDefinition azureFnTool = new(
                name: "foo",
                description: "Get answers from the foo bot.",
                inputBinding: new AzureFunctionBinding(
                    new AzureFunctionStorageQueue(
                        queueName: "azure-function-foo-input",
                        storageServiceEndpoint: TestEnvironment.STORAGE_QUEUE_URI
                    )
                ),
                outputBinding: new AzureFunctionBinding(
                    new AzureFunctionStorageQueue(
                        queueName: "azure-function-tool-output",
                        storageServiceEndpoint: TestEnvironment.STORAGE_QUEUE_URI
                    )
                ),
                parameters: BinaryData.FromObjectAsJson(
                        new
                        {
                            Type = "object",
                            Properties = new
                            {
                                query = new
                                {
                                    Type = "string",
                                    Description = "The question to ask.",
                                },
                                outputqueueuri = new
                                {
                                    Type = "string",
                                    Description = "The full output queue uri."
                                }
                            },
                        },
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
                )
            );
            AgentsClient client = GetClient();
            Agent agent = await client.CreateAgentAsync(
                model: "gpt-4",
                name: AGENT_NAME,
                instructions: "You are a helpful support agent. Use the provided function any "
                + "time the prompt contains the string 'What would foo say?'. When you invoke "
                + "the function, ALWAYS specify the output queue uri parameter as "
                + $"'{TestEnvironment.STORAGE_QUEUE_URI}/azure-function-tool-output'. Always responds with "
                + "\"Foo says\" and then the response from the tool.",
                tools: new List<ToolDefinition> { azureFnTool }
            );
            AgentThread thread = await client.CreateThreadAsync();
            ThreadMessage message = await client.CreateMessageAsync(
                thread.Id,
                MessageRole.User,
                "What is the most prevalent element in the universe? What would foo say?");
            ThreadRun run = await client.CreateRunAsync(thread, agent);
            await WaitForRun(client, run);
            PageableList<ThreadMessage> afterRunMessages = await client.GetMessagesAsync(thread.Id);

            Assert.Greater(afterRunMessages.Count(), 1);
            bool foundResponse = false;
            foreach (ThreadMessage msg in afterRunMessages)
            {
                foreach (MessageContent contentItem in msg.ContentItems)
                {
                    if (contentItem is MessageTextContent textItem)
                    {
                        if (textItem.Text.ToLower().Contains("bar"))
                        {
                            foundResponse = true;
                            break;
                        }
                    }
                }
            }
            Assert.True(foundResponse);
        }

        [RecordedTest]
        public async Task TestClientWithThreadMessages()
        {
            AgentsClient client = GetClient();
            Agent agent = await GetAgent(
                client,
                instruction: "You are a personal electronics tutor. Write and run code to answer questions.");

            List<ThreadMessageOptions> messages = [
                new(role: MessageRole.Agent, content: "E=mc^2"),
                new(role: MessageRole.Agent, content: "What is the impedance formula?")
            ];
            AgentThread thread = await client.CreateThreadAsync(messages: messages);
            ThreadRun run = await client.CreateRunAsync(thread, agent);
            run = await WaitForRun(client, run);
            Assert.AreEqual(RunStatus.Completed, run.Status);
            PageableList<ThreadMessage> afterRunMessages = await client.GetMessagesAsync(thread.Id);
            Assert.Greater(afterRunMessages.Count(), 1);
        }

        [Ignore(FILE_UPLOAD_CONSTRAINT)]
        [RecordedTest]
        public async Task TestGenerateImageFile()
        {
            string tempDir = CreateTempDirMayBe();
            FileInfo file = new(Path.Combine(tempDir, FILE_NAME2));
            using (FileStream stream = file.OpenWrite())
            {
                string content = "This is a test file";
                stream.Write(Encoding.UTF8.GetBytes(content), 0, content.Length);
            };

            AgentsClient client = GetClient();
            AgentFile fileDataSource = await client.UploadFileAsync(file.FullName, AgentFilePurpose.Agents);

            CodeInterpreterToolResource cdResource = new();
            cdResource.FileIds.Add(fileDataSource.Id);
            ToolResources toolRes = new();
            toolRes.CodeInterpreter = cdResource;

            Agent agent = await client.CreateAgentAsync(
                model: "gpt-4",
                name: AGENT_NAME,
                instructions: "You are helpful assistant",
                tools: [new CodeInterpreterToolDefinition()],
                toolResources: toolRes
            );

            AgentThread thread = await client.CreateThreadAsync();
            await client.CreateMessageAsync(
                threadId: thread.Id,
                role: MessageRole.User,
                content: "Create an image file same as the text file and give me file id?"
            );
            ThreadRun run = await client.CreateRunAsync(thread, agent);
            run = await WaitForRun(client, run);
            PageableList<ThreadMessage> messages = await client.GetMessagesAsync(run.ThreadId, run.Id);
            bool foundId = false;
            foreach (ThreadMessage msg in messages)
            {
                foreach (MessageContent cont in msg.ContentItems)
                {
                    if (cont is MessageTextContent textCont)
                    {
                        foreach (MessageTextAnnotation annotation in textCont.Annotations)
                        {
                            if (annotation is MessageTextFilePathAnnotation pathAnnotation)
                            {
                                Assert.NotNull(pathAnnotation.FileId);
                                foundId = true;
                            }
                        }
                    }
                }
            }
            Assert.True(foundId);
        }

        #region Helpers

        private static string CreateTempDirMayBe()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), TEMP_DIR);
            if (!Directory.Exists(tempDir))
            {
                var info = Directory.CreateDirectory(tempDir);
                Assert.True(info.Exists, "Unable to create temp directory.");
            }
            return tempDir;
        }

        private AgentsClient GetClient()
        {
            var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
            // If we are in the Playback, do not ask for authentication.
            if (Mode == RecordedTestMode.Playback)
            {
                return InstrumentClient(new AgentsClient(connectionString, new MockCredential(), InstrumentClientOptions(new AIProjectClientOptions())));
            }
            // For local testing if you are using non default account
            // add USE_CLI_CREDENTIAL into the .runsettings and set it to true,
            // also provide the PATH variable.
            // This path should allow launching az command.
            var cli = System.Environment.GetEnvironmentVariable("USE_CLI_CREDENTIAL");
            if (!string.IsNullOrEmpty(cli) && string.Compare(cli, "true", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return InstrumentClient(new AgentsClient(connectionString, new AzureCliCredential(), InstrumentClientOptions(new AIProjectClientOptions())));
            }
            else
            {
                return InstrumentClient(new AgentsClient(connectionString, new DefaultAzureCredential(), InstrumentClientOptions(new AIProjectClientOptions())));
            }
        }

        private static async void DeleteAndAssert(AgentsClient client, Agent agent)
        {
            Response<bool> resp = await client.DeleteAgentAsync(agent.Id);
            Assert.IsTrue(resp.Value);
        }

        private static async Task<Agent> GetAgent(AgentsClient client, string agentName=AGENT_NAME, string instruction= "You are helpful assistant.")
        {
            return await client.CreateAgentAsync(
                model: "gpt-4",
                name: agentName,
                instructions: instruction
            );
        }

        private static async Task<AgentThread> GetThread(AgentsClient client, Dictionary<string, string> metadata=null)
        {
            Agent agent = await GetAgent(client);
            return await client.CreateThreadAsync(metadata: metadata);
        }

        private static byte[] GetBytes(object value)
        {
            return Encoding.ASCII.GetBytes(JsonSerializer.Serialize(value));
        }

        private static MemoryStream GetStream(object value)
        {
            MemoryStream stream = new();
            stream.Write(GetBytes(value), 0, GetBytes(value).Length);
            stream.Position = 0;
            return stream;
        }

        private static string GetFieldFromJson(BinaryData json, string field)
        {
            JsonDocument document = JsonDocument.Parse(json);
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                if (property.NameEquals(field))
                {
                    return property.Value.GetString();
                }
            }
            return default;
        }

        private async Task<ThreadRun> WaitForRun(AgentsClient client, ThreadRun run)
        {
            double delay = 500;
            if (Mode == RecordedTestMode.Playback)
            {
                // No need to wait during playback.
                delay = 1;
            }
            do
            {
                await Task.Delay(TimeSpan.FromMilliseconds(delay));
                run = await client.GetRunAsync(run.ThreadId, run.Id);
            }
            while (run.Status == RunStatus.Queued
                || run.Status == RunStatus.InProgress
                || run.Status == RunStatus.RequiresAction);
            Assert.AreEqual(RunStatus.Completed, run.Status, message: run.LastError?.ToString());
            return run;
        }

        private static string GetFile([CallerFilePath] string pth = "")
        {
            var dirName = Path.GetDirectoryName(pth) ?? "";
            return Path.Combine(new string[] { dirName, "TestData", FILE_NAME });
        }

        private static async Task<int> CountElementsAndRemoveIds(AgentsClient client, HashSet<string> ids)
        {
            PageableList<Agent> agentsResp;
            int count = 0;
            string lastId = null;
            do
            {
                agentsResp = await client.GetAgentsAsync(limit: 100, after: lastId);
                foreach (Agent agent in agentsResp)
                    ids.Remove(agent.Id);
                count += agentsResp.Count();
                lastId = agentsResp.LastId;
            }
            while (agentsResp.HasMore);
            return count;
        }
        #endregion
        #region Cleanup
        [TearDown]
        public void Cleanup()
        {
            // Remve temporary directory
            DirectoryInfo tempDir = new(Path.Combine(Path.GetTempPath(), TEMP_DIR));
            if (tempDir.Exists)
            {
                tempDir.Delete(true);
            }
            if (Mode == RecordedTestMode.Playback)
                return;
            AgentsClient client;
            var cli = System.Environment.GetEnvironmentVariable("USE_CLI_CREDENTIAL");
            if (!string.IsNullOrEmpty(cli) && string.Compare(cli, "true", StringComparison.OrdinalIgnoreCase) == 0)
            {
                client = new AgentsClient(TestEnvironment.AzureAICONNECTIONSTRING, new AzureCliCredential());
            }
            else
            {
                client = new AgentsClient(TestEnvironment.AzureAICONNECTIONSTRING, new DefaultAzureCredential());
            }

            // Remove all files
            IReadOnlyList<AgentFile> files = client.GetFiles().Value;
            foreach (AgentFile af in files)
            {
                if (af.Filename.Equals(FILE_NAME) || af.Filename.Equals(FILE_NAME2))
                    client.DeleteFile(af.Id);
            }

            // Remove all vector stores
            AgentPageableListOfVectorStore stores = client.GetVectorStores();
            foreach (VectorStore store in stores.Data)
            {
                if (store.Name == null || store.Name.Equals(VCT_STORE_NAME))
                    client.DeleteVectorStore(store.Id);
            }

            // Remove all agents
            PageableList<Agent> agents = client.GetAgents();
            foreach (Agent agent in agents)
            {
                if (agent.Name.StartsWith(AGENT_NAME))
                    client.DeleteAgent(agent.Id);
            }
        }
        #endregion
    }
}
