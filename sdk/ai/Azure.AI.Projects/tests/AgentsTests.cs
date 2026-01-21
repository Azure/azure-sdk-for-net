// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Microsoft.ClientModel.TestFramework;
using Azure.AI.Projects.Tests.Utils;
using NUnit.Framework;
using OpenAI;
using OpenAI.Files;
using OpenAI.Responses;

namespace Azure.AI.Projects.Tests;
#pragma warning disable OPENAICUA001

public class AgentsTests : AgentsTestBase
{
    public AgentsTests(bool isAsync) : base(isAsync)
    {
        // TestDiagnostics = false;
    }

    [RecordedTest]
    public async Task TestAgentCRUD()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        AgentDefinition emptyAgentDefinition = new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME);

        const string emptyPromptAgentName = "TestNoVersionAgentFromDotnetTests";
        try
        {
            await projectClient.Agents.DeleteAgentAsync(emptyPromptAgentName);
        }
        catch (ClientResultException){
            // We do not have the agent to begin with.
        }
        AgentVersion newAgentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            emptyPromptAgentName,
            new AgentVersionCreationOptions(emptyAgentDefinition)
            {
                Metadata = { ["delete_me"] = "please " },
            });
        Assert.That(newAgentVersion?.Id, Is.Not.Null.And.Not.Empty);

        AgentRecord retrievedAgent = await projectClient.Agents.GetAgentAsync(emptyPromptAgentName);
        Assert.That(retrievedAgent?.Id, Is.EqualTo(newAgentVersion.Name));

        await projectClient.Agents.DeleteAgentAsync(newAgentVersion.Name);

        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(AGENT_NAME, new AgentVersionCreationOptions(emptyAgentDefinition));
        Assert.That(AGENT_NAME, Is.EqualTo(agentVersion.Name));
        AgentVersion agentVersionObject_ = await projectClient.Agents.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Assert.That(AGENT_NAME, Is.EqualTo(agentVersionObject_.Name));
        Assert.That(agentVersion.Version, Is.EqualTo(agentVersionObject_.Version));
        Assert.That(agentVersion.Description, Is.Empty);
        Assert.That(agentVersion.Metadata, Is.Empty);
        // TODO: uncomment this code when the ADO work item 4740406
        // agentVersionObject_ = await projectClient.Agents.CreateAgentVersionAsync(AGENT_NAME2, new PromptAgentDefinition(MODEL_DEPLOYMENT));
        // List<string> agentNames = [.. (await projectClient.Agents.GetAgentsAsync().ToEnumerableAsync()).Select((agv) => agv.Name).Where((name) => name.StartsWith(AGENT_NAME))];
        // AssertListEqual([AGENT_NAME, AGENT_NAME2], agentNames);
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Assert.ThrowsAsync<ClientResultException>(async () => await projectClient.Agents.GetAgentVersionAsync(agentVersion.Name, agentVersion.Version));
        // agentNames = [.. (await projectClient.Agents.GetAgentsAsync().ToEnumerableAsync()).Select((agv) => agv.Name).Where((name) => name.StartsWith(AGENT_NAME))];
        // AssertListEqual([AGENT_NAME2], agentNames);
    }

    [RecordedTest]
    public async Task TestListAgentsAfterAndBefore()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        // In this test we are assuming that workspace has more then 10 agents.
        // If it is not the case create these agents.
        int agentLimit = 10;
        AsyncCollectionResult<AgentRecord> agents = projectClient.Agents.GetAgentsAsync(limit: agentLimit, order: "asc");

        List<string> ids = [.. (await agents.ToEnumerableAsync()).Select(x => x.Id)];
        if (ids.Count < agentLimit)
        {
            for (int i = ids.Count; i < agentLimit; i++)
            {
                AgentDefinition definition = new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME);
                AgentVersion agent = await projectClient.Agents.CreateAgentVersionAsync($"MyAgent{i}", new AgentVersionCreationOptions(definition));
                ids.Add(agent.Id);
            }
        }
        // Test calling before.
        agents = projectClient.Agents.GetAgentsAsync(before: ids[4], limit: 2, order: "asc");
        int idNum = 0;
        await foreach (AgentRecord agent in agents)
        {
            Assert.That(ids[idNum], Is.EqualTo(agent.Id), $"The ID #{idNum} is incorrect.");
            idNum++;
        }
        Assert.That(idNum, Is.EqualTo(2));
        // Test calling after.
        agents = projectClient.Agents.GetAgentsAsync(after: ids[idNum - 1], limit: 2, order: "asc");
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
    public async Task TestResponses()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForModel(TestEnvironment.MODELDEPLOYMENTNAME);
        ResponseResult response = await client.CreateResponseAsync("What is steam reactor?");
        response = await WaitForRun(client, response);
        Assert.That(response.GetOutputText(), Is.Not.Null.Or.Empty);
    }

    [RecordedTest]
    public async Task TestResponsesStreaming()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForModel(TestEnvironment.MODELDEPLOYMENTNAME);
        bool isCreated = false;
        bool textReceived = false;
        await foreach (StreamingResponseUpdate streamResponse in client.CreateResponseStreamingAsync("What is steam reactor?"))
        {
            if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
            {
                isCreated = true;
            }
            else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
            {
                textReceived |= !string.IsNullOrEmpty(textDoneUpdate.Text);
            }
            else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
            {
                Assert.Fail($"The stream has failed with the error: {errorUpdate.Message}");
            }
        }
        Assert.That(isCreated, Is.True, "The run was not created.");
        Assert.That(textReceived, Is.True, "The text response was not received.");
    }

    [RecordedTest]
    public async Task TestConversationCRUD()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        ProjectConversation firstConversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync();
        ProjectConversation secondConversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync(
            new ProjectConversationCreationOptions()
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
        await foreach (ResponseItem item in projectClient.OpenAI.Conversations.GetProjectConversationItemsAsync(firstConversation.Id))
        {
            responseItems.Add(item);
        }
        Assert.That(responseItems, Is.Empty);
        await foreach (ResponseItem item in projectClient.OpenAI.Conversations.GetProjectConversationItemsAsync(secondConversation.Id))
        {
            responseItems.Add(item);
        }
        Assert.That(responseItems, Has.Count.EqualTo(1));
        Assert.That(responseItems[0], Is.InstanceOf<MessageResponseItem>());

        ReadOnlyCollection<ResponseItem> createdItems = await projectClient.OpenAI.Conversations.CreateProjectConversationItemsAsync(
                firstConversation.Id,
                [ResponseItem.CreateUserMessageItem("Hi there, world!")]);
        Assert.That(createdItems, Has.Count.EqualTo(1));
        responseItems.Clear();
        await foreach (ResponseItem item in projectClient.OpenAI.Conversations.GetProjectConversationItemsAsync(firstConversation.Id))
        {
            responseItems.Add(item);
        }
        Assert.That(responseItems, Has.Count.EqualTo(1));
        Assert.That(responseItems[0], Is.InstanceOf<MessageResponseItem>());

        ProjectConversation updatedConversation = await projectClient.OpenAI.Conversations.UpdateProjectConversationAsync(
            firstConversation.Id,
            new ProjectConversationUpdateOptions()
            {
                Metadata =
                {
                    ["new_test_value"] = "yes"
                }
            });
        Assert.That(updatedConversation.Metadata, Has.Count.EqualTo(1));

        ProjectConversation retrievedConversation = await projectClient.OpenAI.Conversations.GetProjectConversationAsync(firstConversation.Id);
        Assert.That(retrievedConversation?.Id, Is.EqualTo(firstConversation.Id));
        Assert.That(retrievedConversation.Metadata, Has.Count.EqualTo(1));
    }

    [RecordedTest]
    public async Task TestConversationItemsOrderingWithMultipleMessages()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        // Create a conversation
        ProjectConversation conversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync();
        Assert.That(conversation?.Id, Does.StartWith("conv_"));

        // Create 40 messages for the conversation
        List<ResponseItem> messagesToAdd = new();
        for (int i = 1; i <= 40; i++)
        {
            messagesToAdd.Add(ResponseItem.CreateUserMessageItem($"Message {i}"));
        }

        // Trying to add all 40 at once should fail
        ClientResultException exceptionFromOperation = Assert.ThrowsAsync<ClientResultException>(async () => _ = await projectClient.OpenAI.Conversations.CreateProjectConversationItemsAsync(conversation.Id, messagesToAdd));
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

        ReadOnlyCollection<ResponseItem> createdItems = await projectClient.OpenAI.Conversations.CreateProjectConversationItemsAsync(
            conversation.Id,
            firstHalfMessages);
        Assert.That(createdItems, Has.Count.EqualTo(20));
        createdItems = await projectClient.OpenAI.Conversations.CreateProjectConversationItemsAsync(conversation.Id, secondHalfMessages);
        Assert.That(createdItems, Has.Count.EqualTo(20));

        // Test ascending order traversal
        List<AgentResponseItem> ascendingItems = [];
        await foreach (AgentResponseItem item in projectClient.OpenAI.Conversations.GetProjectConversationItemsAsync(
            conversation.Id,
            limit: 5,
            order: "asc"))
        {
            ascendingItems.Add(item);
        }
        Assert.That(ascendingItems, Has.Count.EqualTo(40));

        // Test descending order traversal
        List<AgentResponseItem> descendingItems = [];
        await foreach (AgentResponseItem item in projectClient.OpenAI.Conversations.GetProjectConversationItemsAsync(
            conversation.Id,
            limit: 5,
            order: "desc"))
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
        await foreach (AgentResponseItem item in projectClient.OpenAI.Conversations.GetProjectConversationItemsAsync(conversation.Id))
        {
            allItems.Add(item);
        }
        Assert.That(allItems, Has.Count.EqualTo(40));
    }

    [RecordedTest]
    public async Task SimplePromptAgentWithConversation()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        AgentDefinition agentDefinition = new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME)
        {
            Instructions = "You are a helpful agent that happens to always talk like a pirate. Arr!",
        };

        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "TestPromptAgentFromDotnet",
            options: new(agentDefinition));
        ProjectConversation conversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync(
            new ProjectConversationCreationOptions()
            {
                Items = { ResponseItem.CreateSystemMessageItem("It's currently warm and sunny outside.") },
            });

        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion, conversation);

        ResponseResult response = await responseClient.CreateResponseAsync("Please greet me and tell me what would be good to wear outside today.");

        Console.WriteLine($"Response from prompt agent: {response.GetOutputText()}");
    }

    [RecordedTest]
    public async Task SimplePromptAgentWithoutConversation()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        AgentDefinition agentDefinition = new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME)
        {
            Instructions = "You are a helpful agent that happens to always talk like a pirate. Arr!",
        };

        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "TestPromptAgentFromDotnet",
            options: new(agentDefinition));

        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion);

        ResponseResult response = await responseClient.CreateResponseAsync("Please greet me and tell me what would be good to wear outside today.");
        Assert.That(response?.GetOutputText(), Is.Not.Null.And.Not.Empty);
    }

    [RecordedTest]
    public async Task ErrorsGiveGoodExceptionMessages()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        ClientResultException exception = null;
        try
        {
            _ = await projectClient.Agents.GetAgentAsync("SomeAgentNameThatReallyDoesNotExistAndNeverShould3490");
        }
        catch (ClientResultException ex)
        {
            exception = ex;
        }

        Assert.That(exception?.Message, Does.Contain("exist"));
    }

    [RecordedTest]
    public async Task StructuredInputsWork()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        ResponsesClient responseClient = projectClient.OpenAI.Responses;

        AgentVersion agent = await projectClient.Agents.CreateAgentVersionAsync(
            "TestPromptAgentFromDotnetTests2343",
            new AgentVersionCreationOptions(
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
                })
            {
                Metadata =
                {
                    ["test_delete_me"] = "true",
                }
            });

        CreateResponseOptions responseOptions = new()
        {
            Agent = agent,
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("What's my name?")
            }
        };

        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        Assert.That(response.GetOutputText(), Does.Contain("Ishmael"));

        responseOptions = new()
        {
            Agent = agent,
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("What's my name?")
            },
            StructuredInputs =
            {
                ["user_name"] = BinaryData.FromString(@"""Mr. Jingles"""),
            },
        };

        response = await responseClient.CreateResponseAsync(responseOptions);
        Assert.That(response.GetOutputText(), Does.Contain("Mr. Jingles"));

        responseOptions.StructuredInputs["user_name"] = BinaryData.FromString(@"""Le Flufferkins""");
        response = await responseClient.CreateResponseAsync(responseOptions);
        Assert.That(response.GetOutputText(), Does.Contain("Le Flufferkins"));

        responseOptions.StructuredInputs.Remove("user_name");
        response = await responseClient.CreateResponseAsync(responseOptions);
        Assert.That(response.GetOutputText(), Does.Contain("Ishmael"));
    }

    [RecordedTest]
    public async Task SimpleWorkflowAgent()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        AgentDefinition workflowAgentDefinition = WorkflowAgentDefinition.FromYaml(s_HelloWorkflowYaml);

        AgentVersion newAgentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            "TestWorkflowAgentFromDotnet234",
            new AgentVersionCreationOptions(workflowAgentDefinition)
            {
                Description = "A test agent created from the .NET SDK automation suite",
                Metadata = { ["freely_deleteable"] = "true" },
            });

        ProjectConversation newConversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync();

        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(newAgentVersion, newConversation);

        ResponseResult response = await responseClient.CreateResponseAsync("Hello, agent!");

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

    [RecordedTest]
    public async Task SimpleWorkflowAgentStreaming()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        AgentDefinition workflowAgentDefinition = WorkflowAgentDefinition.FromYaml(s_HelloWorkflowYaml);

        AgentVersion newAgentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            "TestWorkflowAgentFromDotnet234",
            new AgentVersionCreationOptions(workflowAgentDefinition)
            {
                Description = "A test agent created from the .NET SDK automation suite",
                Metadata = { ["freely_deleteable"] = "true" },
            });

        ProjectConversation newConversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync();

        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(newAgentVersion, newConversation);

        AgentWorkflowActionResponseItem streamedWorkflowActionItem = null;

        await foreach (StreamingResponseUpdate responseUpdate in responseClient.CreateResponseStreamingAsync("Hello, agent!"))
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
    public async Task TestMemoryStoreCRUD()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        try
        {
            var _ = await projectClient.MemoryStores.DeleteMemoryStoreAsync(name: "test-memory-store");
        }
        catch { }
        // Create
        MemoryStore store = await projectClient.MemoryStores.CreateMemoryStoreAsync("test-memory-store", new MemoryStoreDefaultDefinition(TestEnvironment.MODELDEPLOYMENTNAME, TestEnvironment.EMBEDDINGMODELDEPLOYMENTNAME));
        // Read
        MemoryStore result = await projectClient.MemoryStores.GetMemoryStoreAsync(store.Name);
        Assert.That(store.Id, Is.EqualTo(result.Id));
        Assert.That(store.Description, Is.EqualTo(result.Description));
        Assert.That(store.Name, Is.EqualTo(result.Name));
        // List
        Assert.That(
            (await projectClient.MemoryStores.GetMemoryStoresAsync().ToEnumerableAsync())
            .Select(x => x.Id)
            .Any(x => x == store.Id),
            $"The {store.Id} was not found in the list of memory stores."
        );
        // Update
        string newDescription = "Some other description.";
        result = await projectClient.MemoryStores.UpdateMemoryStoreAsync(
            name: store.Name,
            description: newDescription
        );
        Assert.That(newDescription, Is.EqualTo(result.Description));
        result = await projectClient.MemoryStores.GetMemoryStoreAsync(store.Name);
        Assert.That(newDescription, Is.EqualTo(result.Description));
        // Delete
        DeleteMemoryStoreResponse delResult = await projectClient.MemoryStores.DeleteMemoryStoreAsync(name: store.Name);
        Assert.That(delResult.Deleted, Is.True);
        Assert.That(
            (await projectClient.MemoryStores.GetMemoryStoresAsync().ToEnumerableAsync())
                .Select(x => x.Id)
                .Any(x => x == store.Id),
            Is.False,
            $"The {store.Id} was unexpectedly found in the list of memory stores after being deleted."
        );
    }

    [RecordedTest]
    public async Task TestMemorySearch()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        try
        {
            await projectClient.MemoryStores.DeleteMemoryStoreAsync(name: "test-memory-store");
        }
        catch { }
        MemoryStoreDefaultDefinition memoryDefinitions = new(TestEnvironment.MODELDEPLOYMENTNAME, TestEnvironment.EMBEDDINGMODELDEPLOYMENTNAME);
        memoryDefinitions.Options = new(true, true);
        MemoryStore store = await projectClient.MemoryStores.CreateMemoryStoreAsync(name: "test-memory-store", definition: memoryDefinitions, description: "Test memory store.");
        // Create an empty scope and make sure we cannot find anything.
        string scope = MEMORY_STORE_SCOPE;
        MemorySearchOptions opts = new(scope)
        {
            Items = { ResponseItem.CreateUserMessageItem("Name your favorite animal") },
            ResultOptions = new MemorySearchResultOptions()
            {
                MaxMemories = 1,
            }
        };
        MemoryStoreSearchResponse resp = await projectClient.MemoryStores.SearchMemoriesAsync(
            memoryStoreName: store.Name,
            options: opts
        );
        Assert.That(!resp.Memories.Any(), $"Unexpectedly found the result: {(resp.Memories.Any() ? resp.Memories.First().MemoryItem.Content : "")}");
        // Populate the scope and make sure, we can get the result.
        ResponseItem userItem = ResponseItem.CreateUserMessageItem("My favorite animal is Plagiarus praepotens.");
        int pollingInterval = Mode != RecordedTestMode.Playback ? 500 : 0;
        MemoryUpdateResult updateResult = await projectClient.MemoryStores.WaitForMemoriesUpdateAsync(
            memoryStoreName: store.Name,
            options: new MemoryUpdateOptions(scope)
            {
                Items = { userItem },
                UpdateDelay = 0,
            },
            pollingInterval: pollingInterval);
        Assert.That(updateResult.Status == MemoryStoreUpdateStatus.Completed, $"Unexpected status {updateResult.Status}");
        Assert.That(updateResult.Details.MemoryOperations.Count, Is.GreaterThan(0));
        // Test that the attempt to create invalid item in memory store fails.
        ResponseItem assistantItem = ResponseItem.CreateAssistantMessageItem("Should not be here.");
        string error = default;
        try
        {
            await projectClient.MemoryStores.WaitForMemoriesUpdateAsync(
                memoryStoreName: store.Name,
                options: new MemoryUpdateOptions(scope)
                {
                    Items = { assistantItem },
                    UpdateDelay = 0,
                },
                pollingInterval: pollingInterval);
        }
        catch (InvalidOperationException e)
        {
            error = e.Message;
        }
        Assert.That(error, Is.EqualTo("Only system, user and developer messages are allowed to be used as memories."));
        resp = await projectClient.MemoryStores.SearchMemoriesAsync(
            memoryStoreName: store.Name,
            options: opts
        );
        Assert.That(resp.Memories.Count, Is.EqualTo(1), $"The number of found items is {resp.Memories.Count}, while expected 1.");
        Assert.That(resp.Memories[0].MemoryItem.Content.ToLower(), Does.Contain("plagiarus"));
        MemoryStoreDeleteScopeResponse scopDelete = await projectClient.MemoryStores.DeleteScopeAsync(name: "test-memory-store", scope: MEMORY_STORE_SCOPE);
        Assert.That(scopDelete.Name, Is.EqualTo("test-memory-store"));
        Assert.That(scopDelete.Deleted, Is.True);
        resp = await projectClient.MemoryStores.SearchMemoriesAsync(
            memoryStoreName: store.Name,
            options: opts
        );
        Assert.That(!resp.Memories.Any(), $"Unexpectedly found the result: {(resp.Memories.Any() ? resp.Memories.First().MemoryItem.Content : "")}");
    }

    [RecordedTest]
    [TestCase(ToolType.CodeInterpreter)]
    [TestCase(ToolType.FileSearch)]
    [TestCase(ToolType.ImageGeneration)]
    [TestCase(ToolType.WebSearch)]
    [TestCase(ToolType.Memory)]
    [TestCase(ToolType.AzureAISearch)]
    [TestCase(ToolType.BingGrounding)]
    [TestCase(ToolType.BingGroundingCustom)]
    [TestCase(ToolType.OpenAPI)]
    [TestCase(ToolType.OpenAPIConnection)]
    [TestCase(ToolType.Sharepoint)]
    [TestCase(ToolType.BrowserAutomation)]
    [TestCase(ToolType.MicrosoftFabric)]
    [TestCase(ToolType.A2A)]
    [TestCase(ToolType.A2ASpecialConnection)]
    public async Task TestTool(ToolType toolType)
    {
        Dictionary<string, string> headers = [];
        if (toolType == ToolType.ImageGeneration)
        {
            headers["x-ms-oai-image-generation-deployment"] = TestEnvironment.IMAGE_GENERATION_DEPLOYMENT_NAME;
        }
        AIProjectClient projectClient = GetTestProjectClient(headers);
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(await GetAgentToolDefinition(toolType, projectClient)));
        ProjectOpenAIClient oaiClient = projectClient.GetProjectOpenAIClient();
        ProjectResponsesClient responseClient = oaiClient.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems =
            {
                ResponseItem.CreateUserMessageItem(ToolPrompts[toolType]),
            },
        };
        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        response = await WaitForRun(responseClient, response);
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        if (ExpectedItems.TryGetValue(toolType, out string type))
        {
            bool isTypeMet = false;
            foreach (ResponseItem item in response.OutputItems)
            {
                isTypeMet = string.Equals(GetModelType(item), type);
                if (isTypeMet)
                {
                    break;
                }
            }
            Assert.That(isTypeMet, Is.True, $"The item of type {type} was not found.");
        }
        if (toolType == ToolType.ImageGeneration)
        {
            // If Tool type is Image generation, we need to check image output.
            bool hasImageOutput = false;
            foreach (ResponseItem item in response.OutputItems)
            {
                if (item is ImageGenerationCallResponseItem imageItem)
                {
                    hasImageOutput |= imageItem.ImageResultBytes.Length > 0;
                }
            }
            Assert.That(hasImageOutput);
        }
        else
        {
            Assert.That(response.GetOutputText(), Is.Not.Null.And.Not.Empty);
            if (ExpectedOutput.TryGetValue(toolType, out string expectedResponse))
            {
                Assert.That(Regex.Match(response.GetOutputText().ToLower(), expectedResponse.ToLower()).Success, Is.True, $"The output: \"{response.GetOutputText()}\" does not contain {expectedResponse}");
            }
        }
        if (toolType == ToolType.AzureAISearch | toolType == ToolType.BingGrounding | toolType == ToolType.BingGroundingCustom | toolType == ToolType.Sharepoint)
        {
            bool isUriCitationFound = false;

            // Check Annotation for Azure AI Search tool.
            foreach (ResponseItem item in response.OutputItems)
            {
                isUriCitationFound |= ContainsAnnotation(item, toolType);
            }
            Assert.That(isUriCitationFound, Is.True, "The annotation of type UriCitationMessageAnnotation was not found.");
        }
    }

    [RecordedTest]
    [TestCase(ToolType.FileSearch)]
    [TestCase(ToolType.CodeInterpreter)]
    [TestCase(ToolType.Memory)]
    [TestCase(ToolType.AzureAISearch)]
    [TestCase(ToolType.BingGrounding)]
    [TestCase(ToolType.BingGroundingCustom)]
    [TestCase(ToolType.OpenAPI)]
    [TestCase(ToolType.OpenAPIConnection)]
    [TestCase(ToolType.Sharepoint)]
    [TestCase(ToolType.BrowserAutomation)]
    [TestCase(ToolType.MicrosoftFabric)]
    [TestCase(ToolType.A2A)]
    [TestCase(ToolType.A2ASpecialConnection)]
    public async Task TestToolStreaming(ToolType toolType)
    {
        AIProjectClient projectClient = GetTestProjectClient();
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(await GetAgentToolDefinition(toolType, projectClient)));
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion);
        ResponseItem request = ResponseItem.CreateUserMessageItem(ToolPrompts[toolType]);
        bool isStarted = false;
        bool isFinished = false;
        bool annotationMet = false;
        bool isStatusGood = false;
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems =
            {
                ResponseItem.CreateUserMessageItem(ToolPrompts[toolType]),
            },
            StreamingEnabled = true,
        };
        bool updateFound = !ExpectedUpdateTypes.TryGetValue(toolType, out Type expectedUpdateType);
        await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync(responseOptions))
        {
            if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
            {
                isStarted = true;
            }
            else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
            {
                isFinished = true;
                Assert.That(textDoneUpdate.Text, Is.Not.Null.And.Not.Empty);
                if (ExpectedOutput.TryGetValue(toolType, out string expectedResponse))
                {
                    Assert.That(Regex.Match(textDoneUpdate.Text.ToLower(), expectedResponse.ToLower()).Success, Is.True, $"The output: \"{textDoneUpdate.Text}\" does not contain {expectedResponse}");
                }
            }
            else if (streamResponse is StreamingResponseOutputItemDoneUpdate itemDoneUpdate)
            {
                if (ExpectedAnnotations.TryGetValue(toolType, out Type annotationType))
                {
                    if (itemDoneUpdate.Item is MessageResponseItem messageItem)
                    {
                        foreach (ResponseContentPart part in messageItem.Content)
                        {
                            foreach (ResponseMessageAnnotation annotation in part.OutputTextAnnotations)
                            {
                                annotationMet |= annotation.GetType() == annotationType;
                            }
                        }
                    }
                    if (toolType == ToolType.AzureAISearch | toolType == ToolType.BingGrounding | toolType == ToolType.BingGroundingCustom | toolType == ToolType.Sharepoint)
                    {
                        annotationMet = ContainsAnnotation(itemDoneUpdate.Item, toolType);
                    }
                }
                else
                {
                    annotationMet = true;
                }
            }
            else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
            {
                Assert.Fail($"The stream has failed: {errorUpdate.Message}");
            }
            else if (streamResponse is StreamingResponseCompletedUpdate streamResponseCompletedUpdate)
            {
                Assert.That(streamResponseCompletedUpdate.Response.Status, Is.EqualTo(ResponseStatus.Completed));
                isStatusGood = true;
                if (ExpectedItems.TryGetValue(toolType, out string type))
                {
                    bool isTypeMet = false;
                    foreach (ResponseItem item in streamResponseCompletedUpdate.Response.OutputItems)
                    {
                        isTypeMet = string.Equals(GetModelType(item), type);
                        if (isTypeMet)
                        {
                            break;
                        }
                    }
                    Assert.That(isTypeMet, Is.True, $"The item of type {type} was not found.");
                }
            }
            if (expectedUpdateType is not null)
            {
                updateFound |= streamResponse.GetType() == expectedUpdateType;
            }
        }
        Assert.That(annotationMet, Is.True);
        Assert.That(updateFound, Is.True, $"The update of type {expectedUpdateType} was not found.");
        Assert.That(isStarted, Is.True, "The stream did not started.");
        Assert.That(isFinished, Is.True, "The stream did not finished.");
        Assert.That(isStatusGood, Is.True, "No StreamingResponseCompletedUpdate were met.");
    }

    [RecordedTest]
    public async Task TestToolChoiceWorks()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            new AgentVersionCreationOptions(
                new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME)
                {
                    Instructions = "Always greet the user by name when possible.",
                    Tools = { new FunctionTool("get_name_of_user", BinaryData.FromString("{}"), strictModeEnabled: false) }
                }));

        ResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion);

        ResponseResult response = await responseClient.CreateResponseAsync("Hello!");
        Assert.That(response.OutputItems.Any(outputItem => outputItem is FunctionCallResponseItem), Is.True);

        response = await responseClient.CreateResponseAsync(
            new CreateResponseOptions()
            {
                ToolChoice = ResponseToolChoice.CreateNoneChoice(),
                InputItems =
                {
                    ResponseItem.CreateUserMessageItem("Hello!"),
                },
            });
        Assert.That(response.OutputItems.Any(outputItem => outputItem is FunctionCallResponseItem), Is.False);
    }

    [RecordedTest]
    [TestCase(ToolType.FunctionCall)]
    [TestCase(ToolType.MCP)]
    [TestCase(ToolType.MCPConnection)]
    public async Task TestInterativeTools(ToolType toolType)
    {
        AIProjectClient projectClient = GetTestProjectClient();
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(await GetAgentToolDefinition(toolType, projectClient))
        );
        ResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            Agent = agentVersion,
            InputItems =
            {
                ResponseItem.CreateUserMessageItem(ToolPrompts[toolType]),
            },
        };
        bool funcionCalled;
        bool functionWasCalled = false;
        string previousResponse = default;
        ResponseResult response;
        do
        {
            responseOptions.PreviousResponseId = previousResponse;
            response = await responseClient.CreateResponseAsync(responseOptions);
            response = await WaitForRun(responseClient, response);
            responseOptions.InputItems.Clear();
            previousResponse = response.Id;
            funcionCalled = false;
            foreach (ResponseItem responseItem in response.OutputItems)
            {
                if (toolType == ToolType.FunctionCall && responseItem is FunctionCallResponseItem functionToolCall)
                {
                    //inputItems.Add(responseItem);
                    Assert.That(functionToolCall.FunctionName, Is.EqualTo("GetCityNicknameForTest"));
                    using JsonDocument argumentsJson = JsonDocument.Parse(functionToolCall.FunctionArguments);
                    string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                    responseOptions.InputItems.Add(ResponseItem.CreateFunctionCallOutputItem(
                        callId: functionToolCall.CallId,
                        functionOutput: GetCityNicknameForTest(locationArgument)
                    ));
                    funcionCalled = true;
                    functionWasCalled = true;
                }
                else if ((toolType == ToolType.MCP || toolType == ToolType.MCPConnection) && responseItem is McpToolCallApprovalRequestItem mcpToolCall)
                {
                    Assert.That(mcpToolCall.ServerLabel, Is.EqualTo("api-specs"));
                    responseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
                    funcionCalled = true;
                    functionWasCalled = true;
                }
            }
        } while (funcionCalled);
        Assert.That(functionWasCalled, "The function was not called.");
        Assert.That(response.GetOutputText(), Is.Not.Null.And.Not.Empty);
        if (ExpectedOutput.TryGetValue(toolType, out string expected))
        {
            Assert.That(response.GetOutputText().ToLower, Does.Contain(expected), $"The output: \"{response.GetOutputText()}\" does not contain {expected}");
        }
    }

    [RecordedTest]
    [TestCase(ToolType.FunctionCall)]
    [TestCase(ToolType.MCP)]
    [TestCase(ToolType.MCPConnection)]
    public async Task TestInterativeToolsStreaming(ToolType toolType)
    {
        AIProjectClient projectClient = GetTestProjectClient();
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(await GetAgentToolDefinition(toolType, projectClient))
        );
        ResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        bool functionCalled = false;
        bool functionWasCalled = false;
        bool isStarted = false, isFinished=false, isStatusGood=false;
        bool updateFound = !ExpectedUpdateTypes.TryGetValue(toolType, out Type expectedUpdateType);

        CreateResponseOptions nextResponseOptions = new()
        {
            Agent = agentVersion,
            InputItems =
            {
                ResponseItem.CreateUserMessageItem(ToolPrompts[toolType]),
            },
            StreamingEnabled = true,
        };
        ResponseResult latestResponse = null;

        do
        {
            await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync(nextResponseOptions))
            {
                if (streamResponse is StreamingResponseCreatedUpdate createdUpdate)
                {
                    isStarted = true;
                }
                else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
                {
                    isFinished = true;
                    Assert.That(textDoneUpdate.Text, Is.Not.Null.And.Not.Empty);
                    if (ExpectedOutput.TryGetValue(toolType, out string expectedResponse))
                    {
                        Assert.That(Regex.Match(textDoneUpdate.Text.ToLower(), expectedResponse.ToLower()).Success, Is.True, $"The output: \"{textDoneUpdate.Text}\" does not contain {expectedResponse}");
                    }
                }
                else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
                {
                    Assert.Fail($"The stream has failed: {errorUpdate.Message}\n{ModelReaderWriter.Write(errorUpdate)}");
                }
                else if (streamResponse is StreamingResponseCompletedUpdate streamResponseCompletedUpdate)
                {
                    Assert.That(streamResponseCompletedUpdate.Response.Status, Is.EqualTo(ResponseStatus.Completed));

                    functionCalled = false;
                    isStatusGood = true;

                    nextResponseOptions.PreviousResponseId = streamResponseCompletedUpdate.Response.Id;
                    nextResponseOptions.InputItems.Clear();

                    foreach (ResponseItem responseItem in streamResponseCompletedUpdate.Response.OutputItems)
                    {
                        if (toolType == ToolType.FunctionCall && responseItem is FunctionCallResponseItem functionToolCall)
                        {
                            Assert.That(functionToolCall.FunctionName, Is.EqualTo("GetCityNicknameForTest"));
                            using JsonDocument argumentsJson = JsonDocument.Parse(functionToolCall.FunctionArguments);
                            string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                            nextResponseOptions.InputItems.Add(ResponseItem.CreateFunctionCallOutputItem(
                                callId: functionToolCall.CallId,
                                functionOutput: GetCityNicknameForTest(locationArgument)
                            ));
                            functionCalled = true;
                            functionWasCalled = true;
                        }
                        else if ((toolType == ToolType.MCP || toolType == ToolType.MCPConnection) && responseItem is McpToolCallApprovalRequestItem mcpToolCall)
                        {
                            Assert.That(mcpToolCall.ServerLabel, Is.EqualTo("api-specs"));
                            nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
                            functionCalled = true;
                            functionWasCalled = true;
                        }
                        latestResponse = streamResponseCompletedUpdate.Response;
                    }
                }
                if (expectedUpdateType is not null)
                {
                    updateFound |= streamResponse.GetType() == expectedUpdateType;
                }
            }
        } while (functionCalled);
        Assert.That(updateFound, Is.True, $"The update of type {expectedUpdateType} was not found.");
        Assert.That(isStarted, Is.True, "The stream did not started.");
        Assert.That(isFinished, Is.True, "The stream did not finished.");
        Assert.That(isStatusGood, Is.True, "No StreamingResponseCompletedUpdate were met.");
        Assert.That(functionWasCalled, "The function was not called.");
    }

    private static ComputerCallOutputResponseItem ProcessComputerUseCallTest<T>(ComputerCallResponseItem item, IReadOnlyDictionary<string, T> screenshots)
    {
        T currentScreenshot = item.Action.Kind switch
        {
            ComputerCallActionKind.Type => screenshots["search_typed"],
            ComputerCallActionKind.KeyPress => (item.Action.KeyPressKeyCodes.Contains("Return") || item.Action.KeyPressKeyCodes.Contains("ENTER")) ? screenshots["search_results"] : screenshots["browser_search"],
            ComputerCallActionKind.Click => screenshots["search_results"],
            _ => screenshots["browser_search"]
        };
        if (currentScreenshot is string currentScreenshotStr)
        {
            if (currentScreenshotStr.StartsWith("data:image"))
            {
                return ResponseItem.CreateComputerCallOutputItem(callId: item.CallId, output: ComputerCallOutput.CreateScreenshotOutput(screenshotImageUri: new Uri(currentScreenshotStr)));
            }
            return ResponseItem.CreateComputerCallOutputItem(callId: item.CallId, output: ComputerCallOutput.CreateScreenshotOutput(screenshotImageFileId: currentScreenshotStr));
        }
        if (currentScreenshot is BinaryData currentScreenshotBin)
        {
            return ResponseItem.CreateComputerCallOutputItem(callId: item.CallId, output: ComputerCallOutput.CreateScreenshotOutput(screenshotImageBytes: currentScreenshotBin, screenshotImageBytesMediaType: "image/png"));
        }
        throw new InvalidDataException("screenshots must be a Dictionary<string, string>, Dictionary<string, BinaryData>");
    }

    private static async Task<string> UploadScreenshots(OpenAIClient openAIClient)
    {
        OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
        Dictionary<string, string> screenshots = new() {
            { "browser_search", (await fileClient.UploadFileAsync(GetAgentTestFile("cua_browser_search.png"), FileUploadPurpose.Assistants)).Value.Id },
            { "search_typed", (await fileClient.UploadFileAsync(GetAgentTestFile("cua_search_typed.png"), FileUploadPurpose.Assistants)).Value.Id },
            { "search_results", (await fileClient.UploadFileAsync(GetAgentTestFile("cua_search_results.png"), FileUploadPurpose.Assistants)).Value.Id },
        };
        return JsonSerializer.Serialize(screenshots);
    }

    private static BinaryData UrlGetBase64Image(string name)
    {
        string imagePath = GetAgentTestFile(name);
        return new BinaryData(File.ReadAllBytes(imagePath));
    }

    private static Dictionary<string, BinaryData> GetImagesBin()
    {
        return new() {
            { "browser_search", UrlGetBase64Image("cua_browser_search.png")},
            { "search_typed", UrlGetBase64Image("cua_search_typed.png")},
            { "search_results", UrlGetBase64Image("cua_search_results.png")},
        };
    }

    [RecordedTest]
    // [TestCase(true)] File upload mechanism is blocked by the Bug 4806071 (ADO)
    [TestCase(false)]
    public async Task TestComputerUse(bool useFileUpload)
    {
        TestTimeoutInSeconds = 120; // Increase timeout to 2 minutes for computer use operations

        AIProjectClient projectClient = GetTestProjectClient();
        // If the files are not in the foundry (used only for file upload),uncomment the code below and
        // set the serializedScreenshots value to COMPUTER_SCREENSHOTS environment variable;
        // comment out these lines and run the test again.
        // string serializedScreenshots = await UploadScreenshots(openAIClient);
        // Console.WriteLine(serializedScreenshots);
        // End of file upload code.
        Dictionary<string, string> screenshots = useFileUpload ? JsonSerializer.Deserialize<Dictionary<string, string>>(TestEnvironment.COMPUTER_SCREENSHOTS) : [];
        Dictionary<string, BinaryData> screenshotsBin = useFileUpload ? [] : GetImagesBin();
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(await GetAgentToolDefinition(ToolType.ComputerUse, projectClient, model: TestEnvironment.COMPUTER_USE_DEPLOYMENT_NAME))
        );
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(
            agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            TruncationMode = ResponseTruncationMode.Auto,
            InputItems =
            {
                ResponseItem.CreateUserMessageItem(
                [
                    ResponseContentPart.CreateInputTextPart(ToolPrompts[ToolType.ComputerUse]),
                    useFileUpload ? ResponseContentPart.CreateInputImagePart(imageFileId: screenshots["browser_search"], imageDetailLevel: ResponseImageDetailLevel.High) : ResponseContentPart.CreateInputImagePart(imageBytes: screenshotsBin["browser_search"], imageBytesMediaType: "image/png", imageDetailLevel: ResponseImageDetailLevel.High)
                ]),
            },
        };
        bool computerUseCalled;
        bool computerUseWasCalled = false;
        int limitIteration = 10;
        ResponseResult response;
        do
        {
            response = await responseClient.CreateResponseAsync(responseOptions);
            response = await WaitForRun(responseClient, response);
            responseOptions.InputItems.Clear();
            responseOptions.PreviousResponseId = response.Id;
            computerUseCalled = false;
            foreach (ResponseItem responseItem in response.OutputItems)
            {
                responseOptions.InputItems.Add(responseItem);
                if (responseItem is ComputerCallResponseItem computerCall)
                {
                    responseOptions.InputItems.Add(useFileUpload ? ProcessComputerUseCallTest(computerCall, screenshots) : ProcessComputerUseCallTest(computerCall, screenshotsBin));
                    computerUseCalled = true;
                    computerUseWasCalled = true;
                }
            }
            limitIteration--;
        } while (computerUseCalled && limitIteration > 0);
        Assert.That(computerUseWasCalled, "The computer use tool was not called.");
        Assert.That(response.GetOutputText(), Is.Not.Null.And.Not.Empty);
    }

    [RecordedTest]
    [Ignore("Needs recording update for 2025-11-15-preview")]
    public async Task TestAzureContainerApp()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        AgentVersion containerAgentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(new ContainerApplicationAgentDefinition(
                containerProtocolVersions: [new ProtocolVersionRecord(protocol: AgentCommunicationMethod.Responses, version: "1")],
                containerAppResourceId: TestEnvironment.CONTAINER_APP_RESOURCE_ID,
                ingressSubdomainSuffix: TestEnvironment.INGRESS_SUBDOMAIN_SUFFIX)));
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(AGENT_NAME);
        ProjectConversationsClient conversationClient = projectClient.OpenAI.GetProjectConversationsClient();
        ProjectConversationCreationOptions conversationOptions = new();
        conversationOptions.Items.Add(
            ResponseItem.CreateUserMessageItem("What is the size of France in square miles?")
        );
        ProjectConversation conversation = await conversationClient.CreateProjectConversationAsync(conversationOptions);
        CreateResponseOptions responseOptions = new()
        {
            Agent = containerAgentVersion,
            AgentConversationId = conversation.Id,
        };

        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        response = await WaitForRun(responseClient, response);
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Assert.That(response.GetOutputText(), Is.Not.Null.And.Not.Empty);
    }

    [RecordedTest]
    [TestCase(true)]
    [TestCase(false)]
    public async Task PerRequestToolsRejectedWithAgent(bool agentIsPresent)
    {
        AIProjectClient projectClient = GetTestProjectClient();
        ResponsesClient responseClient = projectClient.OpenAI.Responses;

        CreateResponseOptions responseOptions = new()
        {
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("Hello, model!"),
            },
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

            AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
                agentName: "TestPromptAgentFromDotnet",
                options: new(agentDefinition));

            responseOptions.Agent = agentVersion;
        }
        else
        {
            responseOptions.Model = TestEnvironment.MODELDEPLOYMENTNAME;
        }

        if (agentIsPresent)
        {
            ClientResultException expectedException = Assert.ThrowsAsync<ClientResultException>(async () => await responseClient.CreateResponseAsync(responseOptions));
            Assert.That(expectedException.Message?.ToLower(), Does.Contain("agent is specified"));
        }
        else
        {
            Assert.DoesNotThrowAsync(async () => await responseClient.CreateResponseAsync(responseOptions));
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
        AIProjectClient projectClient = GetTestProjectClient();

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

        AgentVersion newAgentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            "TestPiratePromptAgentWithToolsFromDotnetTests",
            new AgentVersionCreationOptions(agentDefinition)
            {
                Metadata =
                {
                    ["can_delete_this"] = "true"
                }
            },
            cts.Token);

        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(newAgentVersion);

        CreateResponseOptions responseOptions = new()
        {
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("Hello, agent! Greet me by name."),
            },
        };

        // Using a conversation: here, a new conversation is created for this interaction.
        if (persistenceMode == TestItemPersistenceMode.UsingConversations)
        {
            ProjectConversation conversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync(options: null, cts.Token);
            responseOptions.AgentConversationId = conversation;
        }
        else if (persistenceMode == TestItemPersistenceMode.UsingPreviousResponseId)
        {
            // Managed between calls
        }
        else if (persistenceMode == TestItemPersistenceMode.UsingLocalItemsOnly)
        {
            responseOptions.StoredOutputEnabled = false;
        }

        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions, cts.Token);

        Assert.That(response.OutputItems.Count, Is.GreaterThan(0));

        FunctionCallResponseItem functionCallItem = response.OutputItems.Last() as FunctionCallResponseItem;
        Assert.That(functionCallItem?.FunctionName, Is.EqualTo("get_user_name"));

        // When accumulating locally, retain the original input and add output items to the local list for
        // the next call.
        if (persistenceMode == TestItemPersistenceMode.UsingLocalItemsOnly)
        {
            foreach (ResponseItem outputItem in response.OutputItems)
            {
                responseOptions.InputItems.Add(outputItem);
            }
        }
        else
        {
            responseOptions.InputItems.Clear();
        }

        if (persistenceMode == TestItemPersistenceMode.UsingPreviousResponseId)
        {
            responseOptions.PreviousResponseId = response.Id;
        }

        string replyToFunctionCall = "Ishmael";
        responseOptions.InputItems.Add(ResponseItem.CreateFunctionCallOutputItem(functionCallItem.CallId, replyToFunctionCall));
        response = await responseClient.CreateResponseAsync(responseOptions, cts.Token);

        Assert.That(response.GetOutputText().ToLower(), Does.Contain(replyToFunctionCall.ToLower()));
    }

    [RecordedTest]
    public async Task CanOverrideUserAgentViaProtocolResponses()
    {
        AIProjectClientOptions options = CreateTestProjectClientOptions();

        string userAgentValue = null;
        options.AddPolicy(
            new TestPipelinePolicy(message =>
            {
                if (message.Request.Headers.TryGetValue("User-Agent", out userAgentValue))
                { }
            }),
            PipelinePosition.BeforeTransport);
        AIProjectClient client = CreateProxyFromClient(new AIProjectClient(new Uri(TestEnvironment.PROJECT_ENDPOINT), TestEnvironment.Credential, options));

        RequestOptions protocolRequestOptions = new();
        protocolRequestOptions.AddHeader("User-Agent", "DotnetTestMyProtocolUserAgent");

        ClientResult protocolResult = await client.OpenAI.Responses.CreateResponseAsync(
            BinaryContent.Create(
                BinaryData.FromString($$"""
                    {
                      "model": "{{TestEnvironment.MODELDEPLOYMENTNAME}}",
                      "input": [{"type":"message","role":"user","content":"hello, model!"}]
                    }
                    """)),
            protocolRequestOptions);

        Assert.That(userAgentValue, Is.EqualTo("DotnetTestMyProtocolUserAgent"));
    }

    [RecordedTest]
    public async Task TestHostedAgentCreation()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        Uri uriEndpoint = new(TestEnvironment.PROJECT_ENDPOINT);
        string[] pathParts = uriEndpoint.AbsolutePath.Split('/');
        string projectName = pathParts[pathParts.Length - 1];
        string accountId = uriEndpoint.Authority.Substring(0, uriEndpoint.Authority.IndexOf('.'));
        ImageBasedHostedAgentDefinition agentDefinition = new(
            containerProtocolVersions: [new ProtocolVersionRecord(AgentCommunicationMethod.ActivityProtocol, "v1")],
            cpu: "1",
            memory: "2Gi",
            image: TestEnvironment.AGENT_DOCKER_IMAGE
        )
        {
            EnvironmentVariables = {
                { "AZURE_OPENAI_ENDPOINT", $"https://{accountId}.cognitiveservices.azure.com/" },
                { "AZURE_OPENAI_CHAT_DEPLOYMENT_NAME", TestEnvironment.MODELDEPLOYMENTNAME },
                // Optional variables, used for logging
                { "APPLICATIONINSIGHTS_CONNECTION_STRING", TestEnvironment.APPLICATIONINSIGHTS_CONNECTION_STRING },
                { "AGENT_PROJECT_RESOURCE_ID", TestEnvironment.PROJECT_ENDPOINT },
            }
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: AGENT_NAME2,
            options: new(agentDefinition));
        Assert.That(agentVersion.Definition.GetType().ToString(), Does.Contain("UnknownHostedAgentDefinition"));
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Assert.ThrowsAsync<ClientResultException>(async () => await projectClient.Agents.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version));
    }
    private bool ContainsAnnotation(ResponseItem item, ToolType type)
    {
        bool isUriCitationFound = false;
        if (item is MessageResponseItem messageItem)
        {
            foreach (ResponseContentPart content in messageItem.Content)
            {
                foreach (ResponseMessageAnnotation annotation in content.OutputTextAnnotations)
                {
                    if (annotation is UriCitationMessageAnnotation uriAnnotation)
                    {
                        isUriCitationFound = true;
                        Assert.That(uriAnnotation.Title, Does.Contain(ExpectedAnnotationTitle[type]), $"Wrong citation title {uriAnnotation.Title}, should be \"product_info_7.md\"");
                        // The next check is disabled, because of an ADO issue 4836442.
                        // Assert.That(uriAnnotation.Uri, Does.Contain("www.microsoft.com"), $"Wrong citation title {uriAnnotation.Uri}, should be \"www.microsoft.com\"");
                    }
                    else
                    {
                        Assert.Fail($"Found unexpected annotation {annotation}");
                    }
                }
            }
        }
        return isUriCitationFound;
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
