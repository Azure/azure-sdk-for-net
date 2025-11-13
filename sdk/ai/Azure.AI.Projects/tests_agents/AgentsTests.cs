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
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Microsoft.ClientModel.TestFramework;
using Microsoft.Extensions.Options;
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
    // [Ignore("Does not work on service side: see ADO work item 4740406.")]
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
                AgentVersion agent = await projectClient.Agents.CreateAgentVersionAsync($"MyAgent_{i}", new AgentVersionCreationOptions(definition));
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
    public async Task TestConversationCRUD()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        AgentConversation firstConversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync();
        AgentConversation secondConversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync(
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
        await foreach (ResponseItem item in projectClient.OpenAI.Conversations.GetAgentConversationItemsAsync(firstConversation.Id))
        {
            responseItems.Add(item);
        }
        Assert.That(responseItems, Is.Empty);
        await foreach (ResponseItem item in projectClient.OpenAI.Conversations.GetAgentConversationItemsAsync(secondConversation.Id))
        {
            responseItems.Add(item);
        }
        Assert.That(responseItems, Has.Count.EqualTo(1));
        Assert.That(responseItems[0], Is.InstanceOf<MessageResponseItem>());

        ReadOnlyCollection<ResponseItem> createdItems = await projectClient.OpenAI.Conversations.CreateAgentConversationItemsAsync(
                firstConversation.Id,
                [ResponseItem.CreateUserMessageItem("Hi there, world!")]);
        Assert.That(createdItems, Has.Count.EqualTo(1));
        responseItems.Clear();
        await foreach (ResponseItem item in projectClient.OpenAI.Conversations.GetAgentConversationItemsAsync(firstConversation.Id))
        {
            responseItems.Add(item);
        }
        Assert.That(responseItems, Has.Count.EqualTo(1));
        Assert.That(responseItems[0], Is.InstanceOf<MessageResponseItem>());

        AgentConversation updatedConversation = await projectClient.OpenAI.Conversations.UpdateAgentConversationAsync(
            firstConversation.Id,
            new ProjectConversationUpdateOptions()
            {
                Metadata =
                {
                    ["new_test_value"] = "yes"
                }
            });
        Assert.That(updatedConversation.Metadata, Has.Count.EqualTo(1));

        AgentConversation retrievedConversation = await projectClient.OpenAI.Conversations.GetAgentConversationAsync(firstConversation.Id);
        Assert.That(retrievedConversation?.Id, Is.EqualTo(firstConversation.Id));
        Assert.That(retrievedConversation.Metadata, Has.Count.EqualTo(1));
    }

    [RecordedTest]
    public async Task TestConversationItemsOrderingWithMultipleMessages()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        // Create a conversation
        AgentConversation conversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync();
        Assert.That(conversation?.Id, Does.StartWith("conv_"));

        // Create 40 messages for the conversation
        List<ResponseItem> messagesToAdd = new();
        for (int i = 1; i <= 40; i++)
        {
            messagesToAdd.Add(ResponseItem.CreateUserMessageItem($"Message {i}"));
        }

        // Trying to add all 40 at once should fail
        ClientResultException exceptionFromOperation = Assert.ThrowsAsync<ClientResultException>(async () => _ = await projectClient.OpenAI.Conversations.CreateAgentConversationItemsAsync(conversation.Id, messagesToAdd));
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

        ReadOnlyCollection<ResponseItem> createdItems = await projectClient.OpenAI.Conversations.CreateAgentConversationItemsAsync(
            conversation.Id,
            firstHalfMessages);
        Assert.That(createdItems, Has.Count.EqualTo(20));
        createdItems = await projectClient.OpenAI.Conversations.CreateAgentConversationItemsAsync(conversation.Id, secondHalfMessages);
        Assert.That(createdItems, Has.Count.EqualTo(20));

        // Test ascending order traversal
        List<AgentResponseItem> ascendingItems = [];
        await foreach (AgentResponseItem item in projectClient.OpenAI.Conversations.GetAgentConversationItemsAsync(
            conversation.Id,
            limit: 5,
            order: "asc"))
        {
            ascendingItems.Add(item);
        }
        Assert.That(ascendingItems, Has.Count.EqualTo(40));

        // Test descending order traversal
        List<AgentResponseItem> descendingItems = [];
        await foreach (AgentResponseItem item in projectClient.OpenAI.Conversations.GetAgentConversationItemsAsync(
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
        await foreach (AgentResponseItem item in projectClient.OpenAI.Conversations.GetAgentConversationItemsAsync(conversation.Id))
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
        AgentConversation conversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync(
            new ProjectConversationCreationOptions()
            {
                Items = { ResponseItem.CreateSystemMessageItem("It's currently warm and sunny outside.") },
            });

        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion, conversation);

        OpenAIResponse response = await responseClient.CreateResponseAsync("Please greet me and tell me what would be good to wear outside today.");

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

        OpenAIResponse response = await responseClient.CreateResponseAsync("Please greet me and tell me what would be good to wear outside today.");
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
        OpenAIResponseClient responseClient = projectClient.OpenAI.Responses;

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

        ResponseItem item = ResponseItem.CreateUserMessageItem("What's my name?");

        ResponseCreationOptions responseOptions = new()
        {
            Agent = agent,
        };

        OpenAIResponse response = await responseClient.CreateResponseAsync([item], responseOptions);
        Assert.That(response.GetOutputText(), Does.Contain("Ishmael"));

        responseOptions = new()
        {
            Agent = agent,
            StructuredInputs =
            {
                ["user_name"] = BinaryData.FromString(@"""Mr. Jingles"""),
            },
        };

        response = await responseClient.CreateResponseAsync([item], responseOptions);
        Assert.That(response.GetOutputText(), Does.Contain("Mr. Jingles"));

        responseOptions.StructuredInputs["user_name"] = BinaryData.FromString(@"""Le Flufferkins""");
        response = await responseClient.CreateResponseAsync([item], responseOptions);
        Assert.That(response.GetOutputText(), Does.Contain("Le Flufferkins"));

        responseOptions.StructuredInputs.Remove("user_name");
        response = await responseClient.CreateResponseAsync([item], responseOptions);
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

        AgentConversation newConversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync();

        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(newAgentVersion, newConversation);

        OpenAIResponse response = await responseClient.CreateResponseAsync("Hello, agent!");

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

        AgentConversation newConversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync();

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
    [Ignore("The working V2 endpoint does not have the embeddings model yet.")]
    public async Task TestMemoryStoreCRUD()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        // Create
        MemoryStore store = await projectClient.MemoryStores.CreateMemoryStoreAsync("test-memory-store", new MemoryStoreDefaultDefinition(TestEnvironment.MODELDEPLOYMENTNAME, TestEnvironment.EMBEDDINGMODELDEPLOYMENTNAME));
        //Read
        MemoryStore result = await projectClient.MemoryStores.GetMemoryStoreAsync(store.Id);
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
        string newName = "New name";
        result = await projectClient.MemoryStores.UpdateMemoryStoreAsync(
            name: newName,
            description: newDescription
        );
        Assert.That(newDescription, Is.EqualTo(result.Description));
        Assert.That(newName, Is.EqualTo(result.Name));
        result = await projectClient.MemoryStores.GetMemoryStoreAsync(store.Id);
        Assert.That(newDescription, Is.EqualTo(result.Description));
        Assert.That(newName, Is.EqualTo(result.Name));
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
    [Ignore("The working V2 endpoint does not have the embeddings model yet.")]
    [TestCase(true)]
    [TestCase(false)]
    public async Task TestMemorySearch(bool useConversation)
    {
        AIProjectClient projectClient = GetTestProjectClient();
        MemoryStore store = await projectClient.MemoryStores.CreateMemoryStoreAsync("test-memory-store", new MemoryStoreDefaultDefinition(TestEnvironment.MODELDEPLOYMENTNAME, TestEnvironment.EMBEDDINGMODELDEPLOYMENTNAME));
        // Create an empty scope and make sure we cannot find anything.
        string scope = "Test scope";
        await projectClient.MemoryStores.UpdateMemoriesAsync("test-memory-store", new MemoryUpdateOptions(scope));
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
        Assert.That(!resp.Memories.Any(), $"Unexpectedly found the result: {resp.Memories[0].MemoryItem.Content}");
        // Populate the scope and make sure, we can get the result.
        ResponseItem userItem = ResponseItem.CreateUserMessageItem("What is your favorite animal?");
        ResponseItem agentItem = ResponseItem.CreateAssistantMessageItem("My favorite animal is Plagiarus praepotens.");

        MemoryUpdateResult updateResult = await projectClient.MemoryStores.UpdateMemoriesAsync(
            store.Name,
            new MemoryUpdateOptions(scope)
            {
                Items = { userItem, agentItem }
            });
        resp = await projectClient.MemoryStores.SearchMemoriesAsync(
            memoryStoreName: store.Name,
            options: new MemorySearchOptions(scope)
        );
        Assert.That(resp.Memories.Count, Is.EqualTo(1), $"The number of found items is {resp.Memories.Count}, while expected 1.");
        Assert.That(resp.Memories[0].MemoryItem.Content.ToLower(), Does.Contain("plagiarus"));
    }

    [RecordedTest]
    [TestCase(ToolType.CodeInterpreter)]
    [TestCase(ToolType.FileSearch)]
    [TestCase(ToolType.ImageGeneration)]
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
            options: new(await GetAgentToolDefinition(toolType, projectClient.OpenAI)));
        ProjectOpenAIClient oaiClient = projectClient.GetProjectOpenAIClient();
        ProjectResponsesClient responseClient = oaiClient.GetProjectResponsesClientForAgent(agentVersion.Name);
        ResponseItem request = ResponseItem.CreateUserMessageItem(ToolPrompts[toolType]);
        OpenAIResponse response = await responseClient.CreateResponseAsync([request]);
        response = await WaitForRun(responseClient, response);
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
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
                Assert.That(response.GetOutputText(), Does.Contain(expectedResponse), $"The output: \"{response.GetOutputText()}\" does not contain {expectedResponse}");
            }
        }
    }

    [RecordedTest]
    [TestCase(ToolType.FileSearch)]
    public async Task TestToolStreaming(ToolType toolType)
    {
        AIProjectClient projectClient = GetTestProjectClient();
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(await GetAgentToolDefinition(toolType, projectClient.OpenAI)));
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion);
        ResponseItem request = ResponseItem.CreateUserMessageItem(ToolPrompts[toolType]);
        bool isStarted = false;
        bool isFinished = false;
        bool annotationMet = false;
        bool isStatusGood = false;
        //Type expectedUpdateType = null;
        bool updateFound = !ExpectedUpdateTypes.TryGetValue(toolType, out Type expectedUpdateType);
        await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync([request]))
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
                    Assert.That(textDoneUpdate.Text, Does.Contain(expectedResponse), $"The output: \"{textDoneUpdate.Text}\" does not contain {expectedResponse}");
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
            }
            if (expectedUpdateType is not null)
            {
                updateFound |= streamResponse.GetType() == expectedUpdateType;
            }
        }
        Assert.That(annotationMet, Is.True);
        Assert.That(isStarted, Is.True, "The stream did not started.");
        Assert.That(isFinished, Is.True, "The stream did not finished.");
        Assert.That(isStatusGood, Is.True, "No StreamingResponseCompletedUpdate were met.");
    }

    [RecordedTest]
    public async Task TestFunctions()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(await GetAgentToolDefinition(ToolType.FunctionCall, projectClient.OpenAI))
        );
        OpenAIResponseClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        ResponseCreationOptions responseOptions = new()
        {
            Agent = agentVersion,
        };
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
            { "browser_search", (await fileClient.UploadFileAsync(GetTestFile("cua_browser_search.png"), FileUploadPurpose.Assistants)).Value.Id },
            { "search_typed", (await fileClient.UploadFileAsync(GetTestFile("cua_search_typed.png"), FileUploadPurpose.Assistants)).Value.Id },
            { "search_results", (await fileClient.UploadFileAsync(GetTestFile("cua_search_results.png"), FileUploadPurpose.Assistants)).Value.Id },
        };
        return JsonSerializer.Serialize(screenshots);
    }

    private static BinaryData UrlGetBase64Image(string name)
    {
        string imagePath = GetTestFile(name);
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
    // [TestCase(true)] File upload mecahnism is blocked by the Bug 4806071 (ADO)
    [TestCase(false)]
    public async Task TestComputerUse(bool useFileUpload)
    {
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
            options: new(await GetAgentToolDefinition(ToolType.ComputerUse, projectClient.OpenAI, model: TestEnvironment.COMPUTER_USE_DEPLOYMENT_NAME))
        );
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(
            agentVersion.Name);
        ResponseCreationOptions responseOptions = new();
        responseOptions.TruncationMode = ResponseTruncationMode.Auto;
        ResponseItem request = ResponseItem.CreateUserMessageItem(
            [
                ResponseContentPart.CreateInputTextPart(ToolPrompts[ToolType.ComputerUse]),
                useFileUpload ? ResponseContentPart.CreateInputImagePart(imageFileId: screenshots["browser_search"], imageDetailLevel: ResponseImageDetailLevel.High) : ResponseContentPart.CreateInputImagePart(imageBytes: screenshotsBin["browser_search"], imageBytesMediaType: "image/png", imageDetailLevel: ResponseImageDetailLevel.High)
            ]
        );
        List<ResponseItem> inputItems = [request];
        bool computerUseCalled;
        bool computerUseWasCalled = false;
        int limitIteration = 10;
        OpenAIResponse response;
        do
        {
            response = await responseClient.CreateResponseAsync(
                inputItems: inputItems,
                options: responseOptions);
            response = await WaitForRun(responseClient, response);
            inputItems.Clear();
            responseOptions.PreviousResponseId = response.Id;
            computerUseCalled = false;
            foreach (ResponseItem responseItem in response.OutputItems)
            {
                inputItems.Add(responseItem);
                if (responseItem is ComputerCallResponseItem computerCall)
                {
                    inputItems.Add(useFileUpload ? ProcessComputerUseCallTest(computerCall, screenshots) : ProcessComputerUseCallTest(computerCall, screenshotsBin));
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
        AgentConversation conversation = await conversationClient.CreateAgentConversationAsync(conversationOptions);
        ResponseCreationOptions responseOptions = new()
        {
            Agent = containerAgentVersion,
            AgentConversationId = conversation.Id,
        };

        OpenAIResponse response = await responseClient.CreateResponseAsync([], responseOptions);
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
        OpenAIResponseClient responseClient = projectClient.OpenAI.Responses;

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

            AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
                agentName: "TestPromptAgentFromDotnet",
                options: new(agentDefinition));

            responseOptions.Agent = agentVersion;
        }
        else
        {
            responseOptions.Model = TestEnvironment.MODELDEPLOYMENTNAME;
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

        ResponseCreationOptions responseCreationOptions = new();

        string userInput = "Hello, agent! Greet me by name.";
        List<ResponseItem> inputItems = [ResponseItem.CreateUserMessageItem(userInput)];

        // Using a conversation: here, a new conversation is created for this interaction.
        if (persistenceMode == TestItemPersistenceMode.UsingConversations)
        {
            AgentConversation conversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync(options: null, cts.Token);
            responseCreationOptions.AgentConversationId = conversation;
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
