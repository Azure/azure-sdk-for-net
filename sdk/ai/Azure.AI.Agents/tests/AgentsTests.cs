// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Agents.Tests;

public class AgentsTests : AgentsTestBase
{
    public AgentsTests(bool isAsync) : base(isAsync)
    {
        // TestDiagnostics = false;
    }

    [RecordedTest]
    public async Task TestAgentCRUD()
    {
        AgentsClient client = GetTestClient();
        AgentDefinition emptyAgentDefinition = new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME);

        const string emptyPromptAgentName = "TestNoVersionAgentFromDotnetTests";
        try
        {
            AgentDeletionResult initialDeletionResult = await client.DeleteAgentAsync(emptyPromptAgentName);
            Assert.That(initialDeletionResult, Is.Not.Null);
        }
        catch (ClientResultException){
            // We do not have the agent to begin with.
        }
        AgentRecord agent = await client.CreateAgentAsync(
            emptyPromptAgentName,
            emptyAgentDefinition,
            new AgentCreationOptions()
            {
                Metadata = { ["delete_me"] = "please " },
            });
        Assert.That(agent?.Id, Is.Not.Null.And.Not.Empty);

        AgentRecord retrievedAgent = await client.GetAgentAsync(emptyPromptAgentName);
        Assert.That(retrievedAgent?.Id, Is.EqualTo(agent.Id));

        AgentRecord updatedAgent = await client.UpdateAgentAsync(agent.Name, new AgentUpdateOptions(emptyAgentDefinition)
        {
            Metadata = { ["updated"] = "yes" },
        });
        Assert.That(updatedAgent?.Versions.Latest, Is.Not.EqualTo(agent.Versions.Latest));

        AgentDeletionResult deletionResult = await client.DeleteAgentAsync(agent.Name);
        Assert.That(deletionResult.Deleted, Is.True);

        AgentVersion agentVersion = await client.CreateAgentVersionAsync(AGENT_NAME, emptyAgentDefinition, options: null);
        Assert.That(AGENT_NAME, Is.EqualTo(agentVersion.Name));
        AgentVersion agentVersionObject_ = await client.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Assert.That(AGENT_NAME, Is.EqualTo(agentVersionObject_.Name));
        Assert.That(agentVersion.Version, Is.EqualTo(agentVersionObject_.Version));
        Assert.That(agentVersion.Description, Is.Empty);
        Assert.That(agentVersion.Metadata, Is.Empty);
        updatedAgent = await client.UpdateAgentAsync(
            AGENT_NAME,
            new AgentUpdateOptions(emptyAgentDefinition)
            {
                Description = "this is a description!",
                Metadata =
                {
                    ["foo"] = "bar"
                }
            });
        Assert.That(updatedAgent.Versions.Latest.Version, Is.Not.EqualTo(agentVersion.Version));
        Assert.That(updatedAgent.Versions.Latest.Description, Is.Not.Null.And.Not.Empty);
        Assert.That(updatedAgent.Versions.Latest.Metadata, Has.Count.EqualTo(1));
        Assert.That(updatedAgent.Versions.Latest.Metadata["foo"], Is.EqualTo("bar"));
        // TODO: uncomment this code when the ADO work item 4740406
        // agentVersionObject_ = await client.CreateAgentVersionAsync(AGENT_NAME2, new PromptAgentDefinition(MODEL_DEPLOYMENT));
        // List<string> agentNames = [.. (await client.GetAgentsAsync().ToEnumerableAsync()).Select((agv) => agv.Name).Where((name) => name.StartsWith(AGENT_NAME))];
        // AssertListEqual([AGENT_NAME, AGENT_NAME2], agentNames);
        DeleteAgentVersionResponse respone = await client.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Assert.That(respone.Deleted, Is.True);
        // agentNames = [.. (await client.GetAgentsAsync().ToEnumerableAsync()).Select((agv) => agv.Name).Where((name) => name.StartsWith(AGENT_NAME))];
        // AssertListEqual([AGENT_NAME2], agentNames);
    }

    [RecordedTest]
    // [Ignore("Does not work on service side: see ADO work item 4740406.")]
    public async Task TestListAgentsAfterAndBefore()
    {
        AgentsClient client = GetTestClient();
        // In this test we are assuming that workspace has more then 10 agents.
        // If it is not the case create these agents.
        int agentLimit = 10;
        AsyncCollectionResult<AgentRecord> agents = client.GetAgentsAsync(limit: agentLimit, order: "asc");

        List<string> ids = [.. (await agents.ToEnumerableAsync()).Select(x => x.Id)];
        if (ids.Count < agentLimit)
        {
            for (int i = ids.Count; i < agentLimit; i++)
            {
                AgentDefinition definition = new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME);
                AgentRecord agent = await client.CreateAgentAsync(name: $"MyAgent_{i}", definition: definition, options: null);
                ids.Add(agent.Id);
            }
        }
        // Test calling before.
        agents = client.GetAgentsAsync(before: ids[4], limit: 2, order: "asc");
        int idNum = 0;
        await foreach (AgentRecord agent in agents)
        {
            Assert.That(ids[idNum], Is.EqualTo(agent.Id), $"The ID #{idNum} is incorrect.");
            idNum++;
        }
        Assert.That(idNum, Is.EqualTo(2));
        // Test calling after.
        agents = client.GetAgentsAsync(after: ids[idNum - 1], limit: 2, order: "asc");
        await foreach (AgentRecord agent in agents)
        {
            Assert.That(ids[idNum], Is.EqualTo(agent.Id), $"The ID #{idNum} is incorrect.");
            idNum++;
            agentLimit--;
            if (agentLimit <= 0)
                break;
        }
    }

    [RecordedTest]
    public async Task TestConversationCRUD()
    {
        AgentsClient client = GetTestClient();

        AgentConversation firstConversation = await client.GetConversationClient().CreateConversationAsync();
        AgentConversation secondConversation = await client.GetConversationClient().CreateConversationAsync(
            new AgentConversationCreationOptions()
            {
                Items =
                {
                    ResponseItem.CreateUserMessageItem("Hello, world!"),
                    //AgentResponseItem.CreateStructuredOutputsItem(
                    //    new Dictionary<string, BinaryData>()
                    //    {
                    //        ["foo"] = BinaryData.FromString(@"{""value"": ""bar""}"),
                    //    }),
                },
                Metadata =
                {
                    ["test_metadata"] = "yes",
                },
            });

        Assert.That(firstConversation?.Id, Does.StartWith("conv_"));
        Assert.That(secondConversation?.Id, Does.StartWith("conv_"));
        Assert.That(firstConversation.Id, Is.Not.EqualTo(secondConversation.Id));

        Assert.That(firstConversation.Metadata, Is.Empty);
        Assert.That(secondConversation.Metadata, Has.Count.EqualTo(1));
        string secondConversationFooMetadataValue = secondConversation.Metadata?.TryGetValue("test_metadata", out string testValue) == true ? testValue : null;
        Assert.That(secondConversationFooMetadataValue, Is.EqualTo("yes"));

        List<ResponseItem> responseItems = [];
        await foreach (ResponseItem item in client.GetConversationClient().GetConversationItemsAsync(firstConversation.Id))
        {
            responseItems.Add(item);
        }
        Assert.That(responseItems, Is.Empty);
        await foreach (ResponseItem item in client.GetConversationClient().GetConversationItemsAsync(secondConversation.Id))
        {
            responseItems.Add(item);
        }
        Assert.That(responseItems, Has.Count.EqualTo(1));
        Assert.That(responseItems[0], Is.InstanceOf<MessageResponseItem>());

        ReadOnlyCollection<ResponseItem> createdItems = await client.GetConversationClient().CreateConversationItemsAsync(
                firstConversation.Id,
                [ResponseItem.CreateUserMessageItem("Hi there, world!")]);
        Assert.That(createdItems, Has.Count.EqualTo(1));
        responseItems.Clear();
        await foreach (ResponseItem item in client.GetConversationClient().GetConversationItemsAsync(firstConversation.Id))
        {
            responseItems.Add(item);
        }
        Assert.That(responseItems, Has.Count.EqualTo(1));
        Assert.That(responseItems[0], Is.InstanceOf<MessageResponseItem>());

        AgentConversation updatedConversation = await client.GetConversationClient().UpdateConversationAsync(
            firstConversation.Id,
            new AgentConversationUpdateOptions()
            {
                Metadata =
                {
                    ["new_test_value"] = "yes"
                }
            });
        Assert.That(updatedConversation.Metadata, Has.Count.EqualTo(1));

        AgentConversation retrievedConversation = await client.GetConversationClient().GetConversationAsync(firstConversation.Id);
        Assert.That(retrievedConversation?.Id, Is.EqualTo(firstConversation.Id));
        Assert.That(retrievedConversation.Metadata, Has.Count.EqualTo(1));
    }

    [RecordedTest]
    public async Task TestConversationItemsOrderingWithMultipleMessages()
    {
        AgentsClient client = GetTestClient();

        // Create a conversation
        AgentConversation conversation = await client.GetConversationClient().CreateConversationAsync();
        Assert.That(conversation?.Id, Does.StartWith("conv_"));

        // Create 40 messages for the conversation
        List<ResponseItem> messagesToAdd = new();
        for (int i = 1; i <= 40; i++)
        {
            messagesToAdd.Add(ResponseItem.CreateUserMessageItem($"Message {i}"));
        }

        // Trying to add all 40 at once should fail
        ClientResultException exceptionFromOperation = Assert.ThrowsAsync<ClientResultException>(async () => _ = await client.GetConversationClient().CreateConversationItemsAsync(conversation.Id, messagesToAdd));
        Assert.That(exceptionFromOperation.GetRawResponse().Content.ToString(), Does.Contain("20 items"));

        List<ResponseItem> firstHalfMessages = [];
        for (int i = 0; i < 20; i++)
        {
            firstHalfMessages.Add(messagesToAdd[i]);
        }
        List<ResponseItem> secondHalfMessages = [];
        for (int i = 20; i < messagesToAdd.Count; i++)
        {
            secondHalfMessages.Add(messagesToAdd[i]);
        }

        ReadOnlyCollection<ResponseItem> createdItems = await client.GetConversationClient().CreateConversationItemsAsync(
            conversation.Id,
            firstHalfMessages);
        Assert.That(createdItems, Has.Count.EqualTo(20));
        createdItems = await client.GetConversationClient().CreateConversationItemsAsync(conversation.Id, secondHalfMessages);
        Assert.That(createdItems, Has.Count.EqualTo(20));

        // Test ascending order traversal
        List<AgentResponseItem> ascendingItems = [];
        await foreach (AgentResponseItem item in client.GetConversationClient().GetConversationItemsAsync(
            conversation.Id,
            limit: 5,
            order: AgentsListOrder.Asc))
        {
            ascendingItems.Add(item);
        }
        Assert.That(ascendingItems, Has.Count.EqualTo(40));

        // Test descending order traversal
        List<AgentResponseItem> descendingItems = [];
        await foreach (AgentResponseItem item in client.GetConversationClient().GetConversationItemsAsync(
            conversation.Id,
            limit: 5,
            order: AgentsListOrder.Desc))
        {
            descendingItems.Add(item);
        }
        Assert.That(descendingItems, Has.Count.EqualTo(40));

        // Verify that ascending and descending lists contain the same items but in reverse order
        descendingItems.Reverse();
        Assert.That(ascendingItems.Count, Is.EqualTo(descendingItems.Count));
        for (int i = 0; i < ascendingItems.Count; i++)
        {
            Assert.That(ascendingItems[i].Id, Is.EqualTo(descendingItems[i].Id),
                $"Item at position {i} should be the same in both orderings");
        }

        // Verify that we can collect all items consistently
        List<AgentResponseItem> allItems = [];
        await foreach (AgentResponseItem item in client.GetConversationClient().GetConversationItemsAsync(conversation.Id))
        {
            allItems.Add(item);
        }
        Assert.That(allItems, Has.Count.EqualTo(40));
    }

    [RecordedTest]
    [Ignore("Operation not working yet")]
    public async Task TestAgentContainerCRUD()
    {
        AgentsClient client = GetTestClient();

        await foreach (AgentContainerOperation agentContainerOperation in client.GetAgentContainerOperationsAsync("fake-agent-name"))
        {
            Assert.Fail("Shouldn't have found any container operations for a fake agent!");
        }
    }

    [RecordedTest]
    public async Task SimplePromptAgentWithConversation()
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        AgentDefinition agentDefinition = new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME)
        {
            Instructions = "You are a helpful agent that happens to always talk like a pirate. Arr!",
        };

        AgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
            agentName: "TestPromptAgentFromDotnet",
            definition: agentDefinition,
            options: null
        );
        AgentConversation conversation = await agentsClient.GetConversationClient().CreateConversationAsync(
            new AgentConversationCreationOptions()
            {
                Items = { ResponseItem.CreateSystemMessageItem("It's currently warm and sunny outside.") },
            });

        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(agentVersion);
        responseOptions.SetConversationReference(conversation);

        OpenAIResponse response = await responseClient.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("Please greet me and tell me what would be good to wear outside today.")],
            responseOptions);

        Console.WriteLine($"Response from prompt agent: {response.GetOutputText()}");
    }

    [RecordedTest]
    public async Task SimplePromptAgentWithoutConversation()
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        AgentDefinition agentDefinition = new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME)
        {
            Instructions = "You are a helpful agent that happens to always talk like a pirate. Arr!",
        };

        AgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
            agentName: "TestPromptAgentFromDotnet",
            definition: agentDefinition,
            options: null
        );

        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(agentVersion);

        OpenAIResponse response = await responseClient.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("Please greet me and tell me what would be good to wear outside today.")],
            responseOptions);
        Assert.That(response?.GetOutputText(), Is.Not.Null.And.Not.Empty);
    }

    [RecordedTest]
    public async Task ErrorsGiveGoodExceptionMessages()
    {
        AgentsClient client = GetTestClient();

        ClientResultException exception = null;
        try
        {
            _ = await client.GetAgentAsync("SomeAgentNameThatReallyDoesNotExistAndNeverShould3490");
        }
        catch (ClientResultException ex)
        {
            exception = ex;
        }

        Assert.That(exception?.Message, Does.Contain("exist"));
    }

    [Test]
    public async Task StructuredInputsWork()
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        AgentVersion agent = await agentsClient.CreateAgentVersionAsync(
            "TestPromptAgentFromDotnetTests2343",
            new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME)
            {
                Instructions = "You are a friendly agent. The name of the user talking to you is {{user_name}}.",
                StructuredInputs =
                {
                    ["user_name"] = new StructuredInputDefinition()
                    {
                        DefaultValue = BinaryData.FromObjectAsJson(JsonValue.Create("Ishmael")),
                    }
                }
            },
            new AgentVersionCreationOptions()
            {
                Metadata =
                {
                    ["test_delete_me"] = "true",
                }
            });

        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(agent);

        ResponseItem item = ResponseItem.CreateUserMessageItem("What's my name?");

        OpenAIResponse response = await responseClient.CreateResponseAsync([item], responseOptions);
        Assert.That(response.GetOutputText(), Does.Contain("Ishmael"));

        responseOptions.AddStructuredInput("user_name", "Mr. Jingles");
        response = await responseClient.CreateResponseAsync([item], responseOptions);
        Assert.That(response.GetOutputText(), Does.Contain("Mr. Jingles"));

        responseOptions.SetStructuredInputs(BinaryData.FromString("""
            {
              "user_name": "Le Flufferkins"
            }
            """));
        response = await responseClient.CreateResponseAsync([item], responseOptions);
        Assert.That(response.GetOutputText(), Does.Contain("Le Flufferkins"));
    }

    [Test]
    public async Task SimpleWorkflowAgent()
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        AgentDefinition workflowAgentDefinition = WorkflowAgentDefinition.FromYaml(s_HelloWorkflowYaml);

        string agentName = null;
        string agentVersion = null;

        AgentVersion newAgentVersion = await agentsClient.CreateAgentVersionAsync(
            "TestWorkflowAgentFromDotnet234",
            workflowAgentDefinition,
            new AgentVersionCreationOptions()
            {
                Description = "A test agent created from the .NET SDK automation suite",
                Metadata = { ["freely_deleteable"] = "true" },
            });
        agentName = newAgentVersion.Name;
        agentVersion = newAgentVersion.Version;

        AgentConversation newConversation = await agentsClient.GetConversationClient().CreateConversationAsync();

        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(agentName, agentVersion);
        responseOptions.SetConversationReference(newConversation.Id);

        OpenAIResponse response = await responseClient.CreateResponseAsync(
            inputItems: [ResponseItem.CreateUserMessageItem("Hello, agent!")], responseOptions);

        Assert.That(response.Id, Does.StartWith("wfresp"));
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));

        Assert.That(response.OutputItems.Count, Is.GreaterThan(0));
        AgentResponseItem agentResponseItem = response.OutputItems[0].AsAgentResponseItem();
        Assert.That(agentResponseItem, Is.InstanceOf<AgentWorkflowActionResponseItem>());

        // This line will fix the failure:
        // System.InvalidOperationException : Cannot write a JSON property within an array or as the first JSON token. Current token type is 'EndObject'.
        response.Patch.Remove("$.output_text"u8);
        Console.WriteLine(ModelReaderWriter.Write(response).ToString());
    }

    [Test]
    public async Task SimpleWorkflowAgentStreaming()
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        AgentDefinition workflowAgentDefinition = WorkflowAgentDefinition.FromYaml(s_HelloWorkflowYaml);

        string agentName = null;
        string agentVersion = null;

        AgentVersion newAgentVersion = await agentsClient.CreateAgentVersionAsync(
            "TestWorkflowAgentFromDotnet234",
            workflowAgentDefinition,
            new AgentVersionCreationOptions()
            {
                Description = "A test agent created from the .NET SDK automation suite",
                Metadata = { ["freely_deleteable"] = "true" },
            });
        agentName = newAgentVersion.Name;
        agentVersion = newAgentVersion.Version;

        AgentConversation newConversation = await agentsClient.GetConversationClient().CreateConversationAsync();

        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(agentName, agentVersion);
        responseOptions.SetConversationReference(newConversation.Id);

        AgentWorkflowActionResponseItem streamedWorkflowActionItem = null;

        await foreach (StreamingResponseUpdate responseUpdate
            in responseClient.CreateResponseStreamingAsync([ResponseItem.CreateUserMessageItem("Hello, agent!")], responseOptions))
        {
            if (responseUpdate is StreamingResponseOutputItemDoneUpdate itemDoneUpdate)
            {
                if (itemDoneUpdate.Item.AsAgentResponseItem() is AgentWorkflowActionResponseItem workflowActionItem)
                {
                    streamedWorkflowActionItem = workflowActionItem;
                }
            }
            // This line is commented because of failure:
            // System.InvalidOperationException : Cannot write a JSON property within an array or as the first JSON token. Current token type is 'EndObject'.
            //Console.WriteLine($"{responseUpdate} : {ModelReaderWriter.Write(responseUpdate).ToString()}");
        }

        Assert.That(streamedWorkflowActionItem?.ActionId, Is.Not.Null.And.Not.Empty);
    }

    [RecordedTest]
    [Ignore("The working V2 endpoint does not have the embeddings model yet.")]
    public async Task TestMemoryStoreCRUD()
    {
        AgentsClient client = GetTestClient();
        // Create
        MemoryStoreObject store = await CreateMemoryStore(client);
        MemoryStoreClient memoryClient = client.GetMemoryStoreClient();
        //Read
        MemoryStoreObject result = await memoryClient.GetMemoryStoreAsync(store.Id);
        Assert.That(store.Id, Is.EqualTo(result.Id));
        Assert.That(store.Description, Is.EqualTo(result.Description));
        Assert.That(store.Name, Is.EqualTo(result.Name));
        // List
        Assert.That(
            (await memoryClient.GetMemoryStoresAsync().ToEnumerableAsync())
            .Select(x => x.Id)
            .Any(x => x == store.Id),
            $"The {store.Id} was not found in the list of memory stores."
        );
        // Update
        string newDescription = "Some other description.";
        string newName = "New name";
        result = await memoryClient.UpdateMemoryStoreAsync(
            name: newName,
            description: newDescription
        );
        Assert.That(newDescription, Is.EqualTo(result.Description));
        Assert.That(newName, Is.EqualTo(result.Name));
        result = await memoryClient.GetMemoryStoreAsync(store.Id);
        Assert.That(newDescription, Is.EqualTo(result.Description));
        Assert.That(newName, Is.EqualTo(result.Name));
        // Delete
        DeleteMemoryStoreResponse delResult = await memoryClient.DeleteMemoryStoreAsync(name: store.Name);
        Assert.That(delResult.Deleted, Is.True);
        Assert.That(
            (await memoryClient.GetMemoryStoresAsync().ToEnumerableAsync())
                .Select(x => x.Id)
                .Any(x => x == store.Id),
            Is.False,
            $"The {store.Id} was unexpectedly found in the list of memory stores after being deleted."
        );
    }

    [RecordedTest]
    [Ignore("The working V2 endpoint does not have the embeddings model yet.")]
    [TestCase(true)]
    [TestCase(false)]
    public async Task TestMemorySearch(bool useConversation)
    {
        AgentsClient client = GetTestClient();
        MemoryStoreObject store = await CreateMemoryStore(client);
        MemoryStoreClient memoryClient = client.GetMemoryStoreClient();
        // Create an empty scope and make sure we cannot find anything.
        string scope = "Test scope";
        memoryClient.UpdateMemories(store.Id, scope, items: []);
        MemorySearchOptions opts = new()
        {
            MaxMemories = 1,
            Items = { ResponseItem.CreateUserMessageItem("Name your favorite animal") },
        };
        MemoryStoreSearchResponse resp = await memoryClient.SearchMemoriesAsync(
            memoryStoreId: store.Id,
            scope: scope,
            options: opts
        );
        Assert.That(!resp.Memories.Any(), $"Unexpectedly found the result: {resp.Memories[0].MemoryItem.Content}");
        // Populate the scope and make sure, we can get the result.
        ResponseItem userItem = ResponseItem.CreateUserMessageItem("What is your favorite animal?");
        ResponseItem agentItem = ResponseItem.CreateAssistantMessageItem("My favorite animal is Plagiarus praepotens.");

        MemoryUpdateResult updateResult = null;

        if (useConversation)
        {
            AgentConversationCreationOptions conversationOptions = new()
            {
                Items = { userItem, agentItem },
            };
            AgentConversation conv = await CreateConversation(client, opts: conversationOptions);
            updateResult = await memoryClient.UpdateMemoriesAsync(store.Id, scope, conv.Id);
        }
        else
        {
            updateResult = await memoryClient.UpdateMemoriesAsync(store.Id, scope, [userItem, agentItem]);
        }
        resp = await memoryClient.SearchMemoriesAsync(
            memoryStoreId: store.Id,
            scope: scope
        );
        Assert.That(resp.Memories.Count, Is.EqualTo(1), $"The number of found items is {resp.Memories.Count}, while expected 1.");
        Assert.That(resp.Memories[0].MemoryItem.Content.ToLower(), Does.Contain("plagiarus"));
    }

    [RecordedTest]
    [TestCase(ToolType.CodeInterpreter)]
    [TestCase(ToolType.FileSearch)]
    public async Task TestTool(ToolType toolType)
    {
        AgentsClient client = GetTestClient();
        OpenAIClient openAIClient = client.GetOpenAIClient(TestOpenAIClientOptions);
        AgentVersion agentVersion = await client.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            definition: await GetAgentToolDefinition(toolType, openAIClient),
            options: null
        );
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(
            TestEnvironment.MODELDEPLOYMENTNAME);
        AgentReference agentReference = new(name: agentVersion.Name)
        {
            Version = agentVersion.Version,
        };
        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(agentReference);
        ResponseItem request = ResponseItem.CreateUserMessageItem(ToolPrompts[toolType]);
        OpenAIResponse response = await responseClient.CreateResponseAsync(
            [request],
            responseOptions);
        response = await WaitForRun(responseClient, response);
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Assert.That(response.GetOutputText(), Is.Not.Null.And.Not.Empty);
        if (ExpectedOutput.TryGetValue(toolType, out string expectedResponse))
        {
            Assert.That(response.GetOutputText(), Does.Contain(expectedResponse), $"The output: \"{response.GetOutputText()}\" does not contain {expectedResponse}");
        }
    }

    [RecordedTest]
    public async Task TestFunctions()
    {
        AgentsClient client = GetTestClient();
        OpenAIClient openAIClient = client.GetOpenAIClient(TestOpenAIClientOptions);
        AgentVersion agentVersion = await client.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            definition: await GetAgentToolDefinition(ToolType.FunctionCall, openAIClient),
            options: null
        );
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(
            TestEnvironment.MODELDEPLOYMENTNAME);
        AgentReference agentReference = new(name: agentVersion.Name)
        {
            Version = agentVersion.Version,
        };
        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(agentReference);
        ResponseItem request = ResponseItem.CreateUserMessageItem(ToolPrompts[ToolType.FunctionCall]);
        List<ResponseItem> inputItems = [request];
        bool funcionCalled;
        bool functionWasCalled = false;
        OpenAIResponse response;
        do
        {
            response = await responseClient.CreateResponseAsync(
                inputItems: inputItems,
                options: responseOptions);
            response = await WaitForRun(responseClient, response);
            funcionCalled = false;
            foreach (ResponseItem responseItem in response.OutputItems)
            {
                inputItems.Add(responseItem);
                if (responseItem is FunctionCallResponseItem functionToolCall)
                {
                    Assert.That(functionToolCall.FunctionName, Is.EqualTo("GetCityNicknameForTest"));
                    using JsonDocument argumentsJson = JsonDocument.Parse(functionToolCall.FunctionArguments);
                    string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                    inputItems.Add(ResponseItem.CreateFunctionCallOutputItem(
                        callId: functionToolCall.CallId,
                        functionOutput: GetCityNicknameForTest(locationArgument)
                    ));
                    funcionCalled = true;
                    functionWasCalled = true;
                }
            }
        } while (funcionCalled);
        Assert.That(functionWasCalled, "The function was not called.");
        Assert.That(response.GetOutputText(), Is.Not.Null.And.Not.Empty);
        Assert.That(response.GetOutputText().ToLower, Does.Contain(ExpectedOutput[ToolType.FunctionCall]), $"The output: \"{response.GetOutputText()}\" does not contain {ExpectedOutput[ToolType.FunctionCall]}");
    }

    [RecordedTest]
    [Ignore("Needs recording update for 2025-11-15-preview")]
    public async Task TestAzureContainerApp()
    {
        AgentsClient client = GetTestClient();
        AgentVersion containerAgentVersion = await client.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            definition: new ContainerAppAgentDefinition(
                containerProtocolVersions: [new ProtocolVersionRecord(protocol: AgentCommunicationMethod.Responses, version: "1")],
                containerAppResourceId: TestEnvironment.CONTAINER_APP_RESOURCE_ID,
                ingressSubdomainSuffix: TestEnvironment.INGRESS_SUBDOMAIN_SUFFIX),
            options: null
        );
        OpenAIClient openAIClient = client.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(
            TestEnvironment.MODELDEPLOYMENTNAME);
        AgentConversationCreationOptions conversationOptions = new();
        conversationOptions.Items.Add(
            ResponseItem.CreateUserMessageItem("What is the size of France in square miles?")
        );
        AgentConversation conversation = await CreateConversation(client, conversationOptions);
        AgentReference agentReference = new(name: containerAgentVersion.Name)
        {
            Version = containerAgentVersion.Version,
        };

        OpenAIResponse response = await responseClient.CreateResponseAsync(
            agentRef: agentReference,
            conversation: conversation
        );
        response = await WaitForRun(responseClient, response);
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Assert.That(response.GetOutputText(), Is.Not.Null.And.Not.Empty);
    }

    [RecordedTest]
    [TestCase(true)]
    [TestCase(false)]
    public async Task PerRequestToolsRejectedWithAgent(bool agentIsPresent)
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        ResponseCreationOptions responseOptions = new()
        {
            Tools =
            {
                ResponseTool.CreateFunctionTool(
                    functionName: "get_user_name",
                    functionParameters: BinaryData.FromString("{}"),
                    strictModeEnabled: false,
                    functionDescription: "Gets the user's name, as used for friendly address."
                )
            }
        };

        if (agentIsPresent)
        {
            AgentDefinition agentDefinition = new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME)
            {
                Instructions = "You are a helpful agent that happens to always talk like a pirate. Arr!",
            };

            AgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
                agentName: "TestPromptAgentFromDotnet",
                definition: agentDefinition,
                options: null
            );

            responseOptions.SetAgentReference(agentVersion);
        }

        List<ResponseItem> inputItems = [ResponseItem.CreateUserMessageItem("Hello, model!")];

        if (agentIsPresent)
        {
            ClientResultException expectedException = Assert.ThrowsAsync<ClientResultException>(async () => await responseClient.CreateResponseAsync(inputItems, responseOptions));
            Assert.That(expectedException.Message?.ToLower(), Does.Contain("agent is specified"));
        }
        else
        {
            Assert.DoesNotThrowAsync(async () => await responseClient.CreateResponseAsync(inputItems, responseOptions));
        }
    }

    public enum TestItemPersistenceMode
    {
        UsingConversations,
        UsingPreviousResponseId,
        UsingLocalItemsOnly
    }

    [RecordedTest]
    [TestCase(TestItemPersistenceMode.UsingConversations)]
    [TestCase(TestItemPersistenceMode.UsingPreviousResponseId)]
    [TestCase(TestItemPersistenceMode.UsingLocalItemsOnly)]
    public async Task TestFunctionToolMultiturnWithPersistence(TestItemPersistenceMode persistenceMode)
    {
        AgentsClient agentsClient = GetTestClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient(TestOpenAIClientOptions);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(TestEnvironment.MODELDEPLOYMENTNAME);

        CancellationTokenSource cts = new(TimeSpan.FromSeconds(60));

        AgentDefinition agentDefinition = new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME)
        {
            Instructions = "You are a helpful agent that happens to always talk like a pirate.",
            Tools =
            {
                ResponseTool.CreateFunctionTool(
                    functionName: "get_user_name",
                    functionParameters: BinaryData.FromString("{}"),
                    strictModeEnabled: false,
                    functionDescription: "Gets the user's name, as used for friendly address."
                )
            }
        };

        AgentVersion newAgentVersion = await agentsClient.CreateAgentVersionAsync(
            "TestPiratePromptAgentWithToolsFromDotnetTests",
            agentDefinition,
            new AgentVersionCreationOptions()
            {
                Metadata =
                {
                    ["can_delete_this"] = "true"
                }
            },
            cts.Token);

        ResponseCreationOptions responseCreationOptions = new();
        responseCreationOptions.SetAgentReference(newAgentVersion);

        string userInput = "Hello, agent! Greet me by name.";
        List<ResponseItem> inputItems = [ResponseItem.CreateUserMessageItem(userInput)];

        // Using a conversation: here, a new conversation is created for this interaction.
        if (persistenceMode == TestItemPersistenceMode.UsingConversations)
        {
            AgentConversation conversation = await agentsClient.GetConversationClient().CreateConversationAsync(options: null, cts.Token);
            responseCreationOptions.SetConversationReference(conversation);
        }
        else if (persistenceMode == TestItemPersistenceMode.UsingPreviousResponseId)
        {
            // Managed between calls
        }
        else if (persistenceMode == TestItemPersistenceMode.UsingLocalItemsOnly)
        {
            responseCreationOptions.StoredOutputEnabled = false;
        }

        OpenAIResponse response = await responseClient.CreateResponseAsync(inputItems, responseCreationOptions, cts.Token);

        Assert.That(response.OutputItems.Count, Is.GreaterThan(0));

        FunctionCallResponseItem functionCallItem = response.OutputItems.Last() as FunctionCallResponseItem;
        Assert.That(functionCallItem?.FunctionName, Is.EqualTo("get_user_name"));

        // When accumulating locally, retain the original input and add output items to the local list for
        // the next call.
        if (persistenceMode == TestItemPersistenceMode.UsingLocalItemsOnly)
        {
            inputItems.AddRange(response.OutputItems);
        }
        else
        {
            inputItems.Clear();
        }

        if (persistenceMode == TestItemPersistenceMode.UsingPreviousResponseId)
        {
            responseCreationOptions.PreviousResponseId = response.Id;
        }

        string replyToFunctionCall = "Ishmael";
        inputItems.Add(ResponseItem.CreateFunctionCallOutputItem(functionCallItem.CallId, replyToFunctionCall));
        response = await responseClient.CreateResponseAsync(inputItems, responseCreationOptions, cts.Token);

        Assert.That(response.GetOutputText().ToLower(), Does.Contain(replyToFunctionCall.ToLower()));
    }

    private static readonly string s_HelloWorkflowYaml = """
        kind: workflow
        trigger:
          kind: OnConversationStart
          id: my_workflow
          actions:
            - kind: SendActivity
              id: sendActivity_welcome
              activity: hello world
            - kind: EndConversation
              id: end_conversation
        """;
}
