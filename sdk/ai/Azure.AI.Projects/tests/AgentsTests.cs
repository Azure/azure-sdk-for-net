// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Extensions.OpenAI;
using Azure.AI.Projects.Agents;
using Azure.AI.Projects.Memory;
using Azure.AI.Projects.Tests.Utils;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Containers;
using OpenAI.Files;
using OpenAI.Responses;
using OpenAI.VectorStores;

namespace Azure.AI.Projects.Tests;
#pragma warning disable OPENAICUA001
#pragma warning disable AAIP001

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
        ProjectsAgentDefinition emptyProjectsAgentDefinition = new DeclarativeAgentDefinition(TestEnvironment.FOUNDRY_MODEL_NAME);

        const string emptyPromptAgentName = "TestNoVersionAgentFromDotnetTests";
        try
        {
            await projectClient.AgentAdministrationClient.DeleteAgentAsync(emptyPromptAgentName);
        }
        catch (ClientResultException)
        {
            // We do not have the agent to begin with.
        }
        ProjectsAgentVersion newProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            emptyPromptAgentName,
            new ProjectsAgentVersionCreationOptions(emptyProjectsAgentDefinition)
            {
                Metadata = { ["delete_me"] = "please " },
            });
        Assert.That(newProjectsAgentVersion?.Id, Is.Not.Null.And.Not.Empty);

        ProjectsAgentRecord retrievedAgent = await projectClient.AgentAdministrationClient.GetAgentAsync(emptyPromptAgentName);
        Assert.That(retrievedAgent?.Id, Is.EqualTo(newProjectsAgentVersion.Name));

        await projectClient.AgentAdministrationClient.DeleteAgentAsync(newProjectsAgentVersion.Name);

        ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(AGENT_NAME, new ProjectsAgentVersionCreationOptions(emptyProjectsAgentDefinition));
        Assert.That(AGENT_NAME, Is.EqualTo(ProjectsAgentVersion.Name));
        ProjectsAgentVersion ProjectsAgentVersionObject_ = await projectClient.AgentAdministrationClient.GetAgentVersionAsync(agentName: ProjectsAgentVersion.Name, agentVersion: ProjectsAgentVersion.Version);
        Assert.That(AGENT_NAME, Is.EqualTo(ProjectsAgentVersionObject_.Name));
        Assert.That(ProjectsAgentVersion.Version, Is.EqualTo(ProjectsAgentVersionObject_.Version));
        Assert.That(ProjectsAgentVersion.Description, Is.Empty);
        Assert.That(ProjectsAgentVersion.Metadata, Is.Empty);
        // TODO: uncomment this code when the ADO work item 4740406
        // ProjectsAgentVersionObject_ = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(AGENT_NAME2, new DeclarativeAgentDefinition(MODEL_DEPLOYMENT));
        // List<string> agentNames = [.. (await projectClient.AgentAdministrationClient.GetAgentsAsync().ToEnumerableAsync()).Select((agv) => agv.Name).Where((name) => name.StartsWith(AGENT_NAME))];
        // AssertListEqual([AGENT_NAME, AGENT_NAME2], agentNames);
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: ProjectsAgentVersion.Name, agentVersion: ProjectsAgentVersion.Version);
        Assert.ThrowsAsync<ClientResultException>(async () => await projectClient.AgentAdministrationClient.GetAgentVersionAsync(ProjectsAgentVersion.Name, ProjectsAgentVersion.Version));
        // agentNames = [.. (await projectClient.AgentAdministrationClient.GetAgentsAsync().ToEnumerableAsync()).Select((agv) => agv.Name).Where((name) => name.StartsWith(AGENT_NAME))];
        // AssertListEqual([AGENT_NAME2], agentNames);
    }

    [RecordedTest]
    public async Task TestListAgentsAfterAndBefore()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        // In this test we are assuming that workspace has more then 10 agents.
        // If it is not the case create these agents.
        int agentLimit = 10;
        AsyncCollectionResult<ProjectsAgentRecord> agents = projectClient.AgentAdministrationClient.GetAgentsAsync(limit: agentLimit, order: "asc");

        List<string> ids = [.. (await agents.ToEnumerableAsync()).Select(x => x.Id)];
        if (ids.Count < agentLimit)
        {
            for (int i = ids.Count; i < agentLimit; i++)
            {
                ProjectsAgentDefinition definition = new DeclarativeAgentDefinition(TestEnvironment.FOUNDRY_MODEL_NAME);
                ProjectsAgentVersion agent = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync($"MyAgent{i}", new ProjectsAgentVersionCreationOptions(definition));
                ids.Add(agent.Id);
            }
        }
        // Test calling before.
        agents = projectClient.AgentAdministrationClient.GetAgentsAsync(before: ids[4], limit: 2, order: "asc");
        int idNum = 0;
        await foreach (ProjectsAgentRecord agent in agents)
        {
            Assert.That(ids[idNum], Is.EqualTo(agent.Id), $"The ID #{idNum} is incorrect.");
            idNum++;
        }
        Assert.That(idNum, Is.EqualTo(4));
        // Test calling after.
        agents = projectClient.AgentAdministrationClient.GetAgentsAsync(after: ids[idNum - 1], limit: 2, order: "asc");
        await foreach (ProjectsAgentRecord agent in agents)
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
        ProjectResponsesClient client = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForModel(TestEnvironment.FOUNDRY_MODEL_NAME);
        ResponseResult response = await client.CreateResponseAsync("What is steam reactor?");
        response = await WaitForRun(client, response);
        Assert.That(response.GetOutputText(), Is.Not.Null.Or.Empty);
    }

    [RecordedTest]
    public async Task TestResponsesStreaming()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        ProjectResponsesClient client = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForModel(TestEnvironment.FOUNDRY_MODEL_NAME);
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

        ProjectConversation firstConversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync();
        ProjectConversation secondConversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync(
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
        await foreach (ResponseItem item in projectClient.ProjectOpenAIClient.GetProjectConversationsClient().GetProjectConversationItemsAsync(firstConversation.Id))
        {
            responseItems.Add(item);
        }
        Assert.That(responseItems, Is.Empty);
        await foreach (ResponseItem item in projectClient.ProjectOpenAIClient.GetProjectConversationsClient().GetProjectConversationItemsAsync(secondConversation.Id))
        {
            responseItems.Add(item);
        }
        Assert.That(responseItems, Has.Count.EqualTo(1));
        Assert.That(responseItems[0], Is.InstanceOf<MessageResponseItem>());

        ReadOnlyCollection<ResponseItem> createdItems = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationItemsAsync(
                firstConversation.Id,
                [ResponseItem.CreateUserMessageItem("Hi there, world!")]);
        Assert.That(createdItems, Has.Count.EqualTo(1));
        responseItems.Clear();
        await foreach (ResponseItem item in projectClient.ProjectOpenAIClient.GetProjectConversationsClient().GetProjectConversationItemsAsync(firstConversation.Id))
        {
            responseItems.Add(item);
        }
        Assert.That(responseItems, Has.Count.EqualTo(1));
        Assert.That(responseItems[0], Is.InstanceOf<MessageResponseItem>());

        ProjectConversation updatedConversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().UpdateProjectConversationAsync(
            firstConversation.Id,
            new ProjectConversationUpdateOptions()
            {
                Metadata =
                {
                    ["new_test_value"] = "yes"
                }
            });
        Assert.That(updatedConversation.Metadata, Has.Count.EqualTo(1));

        ProjectConversation retrievedConversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().GetProjectConversationAsync(firstConversation.Id);
        Assert.That(retrievedConversation?.Id, Is.EqualTo(firstConversation.Id));
        Assert.That(retrievedConversation.Metadata, Has.Count.EqualTo(1));
    }

    [RecordedTest]
    public async Task TestConversationItemsOrderingWithMultipleMessages()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        // Create a conversation
        ProjectConversation conversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync();
        Assert.That(conversation?.Id, Does.StartWith("conv_"));

        // Create 40 messages for the conversation
        List<ResponseItem> messagesToAdd = new();
        for (int i = 1; i <= 40; i++)
        {
            messagesToAdd.Add(ResponseItem.CreateUserMessageItem($"Message {i}"));
        }

        // Trying to add all 40 at once should fail
        ClientResultException exceptionFromOperation = Assert.ThrowsAsync<ClientResultException>(async () => _ = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationItemsAsync(conversation.Id, messagesToAdd));
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

        ReadOnlyCollection<ResponseItem> createdItems = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationItemsAsync(
            conversation.Id,
            firstHalfMessages);
        Assert.That(createdItems, Has.Count.EqualTo(20));
        createdItems = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationItemsAsync(conversation.Id, secondHalfMessages);
        Assert.That(createdItems, Has.Count.EqualTo(20));

        // Test ascending order traversal
        List<AgentResponseItem> ascendingItems = [];
        await foreach (AgentResponseItem item in projectClient.ProjectOpenAIClient.GetProjectConversationsClient().GetProjectConversationItemsAsync(
            conversation.Id,
            limit: 5,
            order: "asc"))
        {
            ascendingItems.Add(item);
        }
        Assert.That(ascendingItems, Has.Count.EqualTo(40));

        // Test descending order traversal
        List<AgentResponseItem> descendingItems = [];
        await foreach (AgentResponseItem item in projectClient.ProjectOpenAIClient.GetProjectConversationsClient().GetProjectConversationItemsAsync(
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
        await foreach (AgentResponseItem item in projectClient.ProjectOpenAIClient.GetProjectConversationsClient().GetProjectConversationItemsAsync(conversation.Id))
        {
            allItems.Add(item);
        }
        Assert.That(allItems, Has.Count.EqualTo(40));
    }

    [RecordedTest]
    public async Task SimplePromptAgentWithConversation()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        ProjectsAgentDefinition ProjectsAgentDefinition = new DeclarativeAgentDefinition(TestEnvironment.FOUNDRY_MODEL_NAME)
        {
            Instructions = "You are a helpful agent that happens to always talk like a pirate. Arr!",
        };

        ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "TestPromptAgentFromDotnet",
            options: new(ProjectsAgentDefinition));
        ProjectConversation conversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync(
            new ProjectConversationCreationOptions()
            {
                Items = { ResponseItem.CreateSystemMessageItem("It's currently warm and sunny outside.") },
            });

        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: ProjectsAgentVersion.Name, version: ProjectsAgentVersion.Version), conversation);

        ResponseResult response = await responseClient.CreateResponseAsync("Please greet me and tell me what would be good to wear outside today.");

        Console.WriteLine($"Response from prompt agent: {response.GetOutputText()}");
    }

    [RecordedTest]
    [TestCase(true)]
    [TestCase(false)]
    public async Task SimplePromptAgentWithoutConversation(bool useDefaultEndpoint)
    {
        AIProjectClient projectClient = GetTestProjectClient(useDefaultEndpoint: useDefaultEndpoint);

        ProjectsAgentDefinition ProjectsAgentDefinition = new DeclarativeAgentDefinition(TestEnvironment.FOUNDRY_MODEL_NAME)
        {
            Instructions = "You are a helpful agent that happens to always talk like a pirate. Arr!",
        };

        ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "TestPromptAgentFromDotnet",
            options: new(ProjectsAgentDefinition));

        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: ProjectsAgentVersion.Name, version: ProjectsAgentVersion.Version));

        ResponseResult response = await responseClient.CreateResponseAsync("Please greet me and tell me what would be good to wear outside today.");
        Assert.That(response?.GetOutputText(), Is.Not.Null.And.Not.Empty);
    }

    [RecordedTest]
    public async Task TestConversationNoInput()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        ProjectsAgentDefinition ProjectsAgentDefinition = new DeclarativeAgentDefinition(TestEnvironment.FOUNDRY_MODEL_NAME)
        {
            Instructions = "You are a helpful agent that happens to always talk like a pirate. Arr!",
        };

        ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "TestPromptAgentFromDotnet",
            options: new(ProjectsAgentDefinition));
        ProjectConversation conversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync(
            new ProjectConversationCreationOptions()
            {
                Items = { ResponseItem.CreateUserMessageItem("Please greet me and tell me what would be good to wear outside today.") },
            });

        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: ProjectsAgentVersion.Name, version: ProjectsAgentVersion.Version), defaultConversationId: conversation.Id);

        ResponseResult response = await responseClient.CreateResponseAsync(new CreateResponseOptions());
        Assert.That(response.GetOutputText(), Is.Not.Null.And.Not.Empty);
    }

    [RecordedTest]
    public async Task TestConversationStructuralOutput()
    {
        BinaryData calendatSchema = BinaryData.FromObjectAsJson(
            new
            {
                additionalProperties = false,
                properties = new
                {
                    name = new
                    {
                        title = "Name",
                        type = "string"
                    },
                    date = new
                    {
                        description = "Date in YYYY-MM-DD format",
                        title = "Date",
                        type = "string"
                    },
                    participants = new
                    {
                        items = new { type = "string" },
                        title = "Participants",
                        type = "array"
                    }
                },
                required = new List<string> { "name", "date", "participants" },
                title = "CalendarEvent",
                type = "object",
            }
        );
        AIProjectClient projectClient = GetTestProjectClient();
        var textOptions = new ResponseTextOptions()
        {
            TextFormat = ResponseTextFormat.CreateJsonSchemaFormat(
                jsonSchemaFormatName: "Calendar",
                jsonSchema: calendatSchema
            )
        };
        DeclarativeAgentDefinition ProjectsAgentDefinition = new(model: TestEnvironment.FOUNDRY_MODEL_NAME)
        {
            Instructions = "You are a helpful assistant that extracts calendar event information from the input user messages," +
                           "and returns it in the desired structured output format.",
            TextOptions = textOptions
        };

        ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "TestPromptAgentFromDotnet",
            options: new(ProjectsAgentDefinition));
        ProjectConversation conversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync(
            new ProjectConversationCreationOptions()
            {
                Items = { ResponseItem.CreateUserMessageItem("Alice and Bob are going to a science fair this Friday, November 7, 2025.") },
            });

        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: ProjectsAgentVersion.Name, version: ProjectsAgentVersion.Version), defaultConversationId: conversation.Id);

        ResponseResult response = await responseClient.CreateResponseAsync(new CreateResponseOptions());
        string text = response.GetOutputText();
        Assert.That(text, Is.Not.Null.And.Not.Empty);
        // Validate the JSON
        JsonDocument doc = JsonDocument.Parse(text);
        bool hasName = false, hasDate = false, hasParticipants = false;
        foreach (JsonProperty prop in doc.RootElement.EnumerateObject())
        {
            if (prop.NameEquals("name"u8))
            {
                Assert.That(prop.Value.ValueKind, Is.EqualTo(JsonValueKind.String), $"Incorrect value type for name: {prop.Value.ValueKind.ToString()}");
                hasName = true;
            }
            else if (prop.NameEquals("date"u8))
            {
                Assert.That(prop.Value.ValueKind, Is.EqualTo(JsonValueKind.String), $"Incorrect value type for date: {prop.Value.ValueKind.ToString()}");
                hasDate = true;
            }
            else if (prop.NameEquals("participants"u8))
            {
                Assert.That(prop.Value.ValueKind, Is.EqualTo(JsonValueKind.Array), $"Incorrect value type for participants: {prop.Value.ValueKind.ToString()}");
                HashSet<string> values = [];
                foreach (JsonElement dataElement in prop.Value.EnumerateArray())
                {
                    Assert.That(dataElement.ValueKind, Is.EqualTo(JsonValueKind.String), $"Incorrect value type for partoicipants element: {dataElement.ValueKind.ToString()}");
                    values.Add(dataElement.GetString());
                }
                Assert.That(values, Is.EqualTo(new HashSet<string> { "Alice", "Bob" }), $"Wrong participants array in {text}");
                hasParticipants = true;
            }
        }
        Assert.That(hasName, Is.True, "No name field in output.");
        Assert.That(hasDate, Is.True, "No date field in output.");
        Assert.That(hasParticipants, Is.True, $"No participants array in the output {text}.");
    }

    [RecordedTest]
    public async Task ErrorsGiveGoodExceptionMessages()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        ClientResultException exception = null;
        try
        {
            _ = await projectClient.AgentAdministrationClient.GetAgentAsync("SomeAgentNameThatReallyDoesNotExistAndNeverShould3490");
        }
        catch (ClientResultException ex)
        {
            exception = ex;
        }

        Assert.That(exception?.Message, Does.Contain("exist"));
    }

    [RecordedTest]
    public async Task SimpleWorkflowAgent()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        ProjectsAgentDefinition workflowProjectsAgentDefinition = WorkflowAgentDefinition.FromYaml(s_HelloWorkflowYaml);

        ProjectsAgentVersion newProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            "TestWorkflowAgentFromDotnet234",
            new ProjectsAgentVersionCreationOptions(workflowProjectsAgentDefinition)
            {
                Description = "A test agent created from the .NET SDK automation suite",
                Metadata = { ["freely_deleteable"] = "true" },
            });

        ProjectConversation newConversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync();

        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: newProjectsAgentVersion.Name, version: newProjectsAgentVersion.Version), newConversation);

        ResponseResult response = await responseClient.CreateResponseAsync("Hello, agent!");

        Assert.That(response.Id, Does.StartWith("wfresp"));
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));

        Assert.That(response.OutputItems.Count, Is.GreaterThan(0));
        AgentResponseItem agentResponseItem = response.OutputItems[0].AsAgentResponseItem();
        Assert.That(agentResponseItem, Is.InstanceOf<AgentWorkflowPreviewActionResponseItem>());

        // This line will fix the failure:
        // System.InvalidOperationException : Cannot write a JSON property within an array or as the first JSON token. Current token type is 'EndObject'.
        response.Patch.Remove("$.output_text"u8);
        Console.WriteLine(ModelReaderWriter.Write(response).ToString());
    }

    [RecordedTest]
    public async Task SimpleWorkflowAgentStreaming()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        ProjectsAgentDefinition workflowProjectsAgentDefinition = WorkflowAgentDefinition.FromYaml(s_HelloWorkflowYaml);

        ProjectsAgentVersion newProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            "TestWorkflowAgentFromDotnet234",
            new ProjectsAgentVersionCreationOptions(workflowProjectsAgentDefinition)
            {
                Description = "A test agent created from the .NET SDK automation suite",
                Metadata = { ["freely_deleteable"] = "true" },
            });

        ProjectConversation newConversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync();

        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: newProjectsAgentVersion.Name, version: newProjectsAgentVersion.Version), newConversation);

        AgentWorkflowPreviewActionResponseItem streamedWorkflowActionItem = null;

        await foreach (StreamingResponseUpdate responseUpdate in responseClient.CreateResponseStreamingAsync("Hello, agent!"))
        {
            if (responseUpdate is StreamingResponseOutputItemDoneUpdate itemDoneUpdate)
            {
                if (itemDoneUpdate.Item.AsAgentResponseItem() is AgentWorkflowPreviewActionResponseItem workflowActionItem)
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
        MemoryStore store = await projectClient.MemoryStores.CreateMemoryStoreAsync("test-memory-store", new MemoryStoreDefaultDefinition(TestEnvironment.MEMORY_STORE_CHAT_MODEL_DEPLOYMENT_NAME, TestEnvironment.MEMORY_STORE_EMBEDDING_MODEL_DEPLOYMENT_NAME));
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
        Assert.That(delResult.IsDeleted, Is.True);
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
        MemoryStoreDefaultDefinition memoryDefinitions = new(TestEnvironment.MEMORY_STORE_CHAT_MODEL_DEPLOYMENT_NAME, TestEnvironment.MEMORY_STORE_EMBEDDING_MODEL_DEPLOYMENT_NAME);
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
        Assert.That(scopDelete.IsDeleted, Is.True);
        resp = await projectClient.MemoryStores.SearchMemoriesAsync(
            memoryStoreName: store.Name,
            options: opts
        );
        Assert.That(!resp.Memories.Any(), $"Unexpectedly found the result: {(resp.Memories.Any() ? resp.Memories.First().MemoryItem.Content : "")}");
    }

    [RecordedTest]
    [TestCase(ToolType.CodeInterpreter)]
    [TestCase(ToolType.CodeInterpreterGen)]
    [TestCase(ToolType.FileSearch)]
    [TestCase(ToolType.ImageGeneration)]
    [TestCase(ToolType.WebSearch)]
    [TestCase(ToolType.WebSearchPreview)]
    [TestCase(ToolType.WebSearchCustom)]
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
    [TestCase(ToolType.AzureFunction)]
    public async Task TestTool(ToolType toolType)
    {
        Dictionary<string, string> headers = [];
        if (toolType == ToolType.ImageGeneration)
        {
            headers["x-ms-oai-image-generation-deployment"] = TestEnvironment.IMAGE_GENERATION_DEPLOYMENT_NAME;
        }
        AIProjectClient projectClient = GetTestProjectClient(headers);
        ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(await GetAgentToolDefinition(toolType, projectClient)));
        ProjectOpenAIClient oaiClient = projectClient.GetProjectOpenAIClient();
        ProjectResponsesClient responseClient = oaiClient.GetProjectResponsesClientForAgent(ProjectsAgentVersion.Name);
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
        if (toolType == ToolType.AzureAISearch || toolType == ToolType.BingGrounding || toolType == ToolType.BingGroundingCustom || toolType == ToolType.Sharepoint || toolType == ToolType.MicrosoftFabric || toolType == ToolType.WebSearch || toolType == ToolType.WebSearchCustom || toolType == ToolType.WebSearchPreview)
        {
            bool isUriCitationFound = false;

            // Check Annotation.
            foreach (ResponseItem item in response.OutputItems)
            {
                isUriCitationFound |= ContainsAnnotation(item, toolType);
            }
            Assert.That(isUriCitationFound, Is.True, "The annotation of type UriCitationMessageAnnotation was not found.");
        }
        else if (toolType == ToolType.CodeInterpreterGen)
        {
            bool hasDownloadableFile = false;
            // Check Annotation.
            foreach (ResponseItem item in response.OutputItems)
            {
                hasDownloadableFile |= await ContainsDownloadableFileAnnotation(item, projectClient);
            }
            Assert.That(hasDownloadableFile, Is.True, "The annotation of type UriCitationMessageAnnotation was not found.");
        }
    }

    [RecordedTest]
    [TestCase(ToolType.FileSearch)]
    [TestCase(ToolType.CodeInterpreter)]
    [TestCase(ToolType.CodeInterpreterGen)]
    [TestCase(ToolType.Memory)]
    [TestCase(ToolType.WebSearch)]
    [TestCase(ToolType.WebSearchPreview)]
    [TestCase(ToolType.WebSearchCustom)]
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
    [TestCase(ToolType.AzureFunction)]
    public async Task TestToolStreaming(ToolType toolType)
    {
        AIProjectClient projectClient = GetTestProjectClient();
        ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(await GetAgentToolDefinition(toolType, projectClient)));
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: ProjectsAgentVersion.Name, version: ProjectsAgentVersion.Version));
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
                    if (toolType == ToolType.AzureAISearch || toolType == ToolType.BingGrounding || toolType == ToolType.BingGroundingCustom || toolType == ToolType.Sharepoint || toolType == ToolType.MicrosoftFabric || toolType == ToolType.WebSearch || toolType == ToolType.WebSearchCustom || toolType == ToolType.WebSearchPreview)
                    {
                        annotationMet |= ContainsAnnotation(itemDoneUpdate.Item, toolType);
                    }
                    if (toolType == ToolType.CodeInterpreter)
                    {
                        annotationMet |= await ContainsDownloadableFileAnnotation(itemDoneUpdate.Item, projectClient);
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
        ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            new ProjectsAgentVersionCreationOptions(
                new DeclarativeAgentDefinition(TestEnvironment.FOUNDRY_MODEL_NAME)
                {
                    Instructions = "Always greet the user by name when possible.",
                    Tools = { new FunctionTool("get_name_of_user", BinaryData.FromString("{}"), strictModeEnabled: false) }
                }));

        ResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: ProjectsAgentVersion.Name, version: ProjectsAgentVersion.Version));

        CreateResponseOptions options = new()
        {
            InputItems = { ResponseItem.CreateUserMessageItem("Hello!") },
        };
        ResponseResult response = await responseClient.CreateResponseAsync(options);
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
        ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(await GetAgentToolDefinition(toolType, projectClient))
        );
        ResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(ProjectsAgentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            Agent = new(name: ProjectsAgentVersion.Name, version: ProjectsAgentVersion.Version),
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
        ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(await GetAgentToolDefinition(toolType, projectClient))
        );
        ResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(ProjectsAgentVersion.Name);
        bool functionCalled = false;
        bool functionWasCalled = false;
        bool isStarted = false, isFinished = false, isStatusGood = false;
        bool updateFound = !ExpectedUpdateTypes.TryGetValue(toolType, out Type expectedUpdateType);

        CreateResponseOptions nextResponseOptions = new()
        {
            Agent = new(name: ProjectsAgentVersion.Name, version: ProjectsAgentVersion.Version),
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

    private static Uri UrlGetBase64Image(string name)
    {
        string imagePath = GetAgentTestFile(name);
        byte[] imageData = File.ReadAllBytes(imagePath);
        return new($"data:image/png;base64,{Convert.ToBase64String(imageData)}");
    }

    private static Dictionary<string, Uri> GetImagesBin()
    {
        return new() {
            { "browser_search", UrlGetBase64Image("cua_browser_search.png")},
            { "search_typed", UrlGetBase64Image("cua_search_typed.png")},
            { "search_results", UrlGetBase64Image("cua_search_results.png")},
        };
    }

    [Ignore("Blocked by ADO Items 4806071, 5028868 and 5028464.")]
    [RecordedTest]
    [TestCase(true)] //File upload mechanism is blocked by the Bug 4806071 (ADO)
    [TestCase(false)]
    public async Task TestComputerUse(bool useFileUpload)
    {
        TestTimeoutInSeconds = 120; // Increase timeout to 2 minutes for computer use operations

        AIProjectClient projectClient = GetTestProjectClient();
        // If the files are not in the foundry (used only for file upload),uncomment the code below and
        // set the serializedScreenshots value to COMPUTER_SCREENSHOTS environment variable;
        // comment out these lines and run the test again.
        // string serializedScreenshots = await UploadScreenshots(projectClient.ProjectOpenAIClient);
        // Console.WriteLine(serializedScreenshots);
        // End of file upload code.
        Dictionary<string, string> screenshots = useFileUpload ? JsonSerializer.Deserialize<Dictionary<string, string>>(TestEnvironment.COMPUTER_SCREENSHOTS) : [];
        Dictionary<string, Uri> screenshotsBin = useFileUpload ? [] : GetImagesBin();
        ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(await GetAgentToolDefinition(ToolType.ComputerUse, projectClient, model: TestEnvironment.COMPUTER_USE_DEPLOYMENT_NAME))
        );
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(
            ProjectsAgentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            TruncationMode = ResponseTruncationMode.Auto,
            InputItems =
            {
                ResponseItem.CreateUserMessageItem(
                [
                    ResponseContentPart.CreateInputTextPart(ToolPrompts[ToolType.ComputerUse]),
                    useFileUpload ? ResponseContentPart.CreateInputImagePart(imageFileId: screenshots["browser_search"], imageDetailLevel: ResponseImageDetailLevel.High) : ResponseContentPart.CreateInputImagePart(imageUri: screenshotsBin["browser_search"], imageDetailLevel: ResponseImageDetailLevel.High)
                ]),
            },
        };
        bool computerUseWasCalled = false;
        int limitIteration = 10;
        ResponseResult response;
        do
        {
            response = await responseClient.CreateResponseAsync(responseOptions);
            responseOptions.InputItems.Clear();
            responseOptions.PreviousResponseId = response.Id;
            foreach (ResponseItem responseItem in response.OutputItems)
            {
                if (responseItem is ComputerCallResponseItem computerCall)
                {
                    responseOptions.InputItems.Add(useFileUpload ? ProcessComputerUseCallTest(computerCall, screenshots) : ProcessComputerUseCallTest(computerCall, screenshotsBin));
                    computerUseWasCalled = true;
                }
            }
            limitIteration--;
        } while (responseOptions.InputItems.Count > 0 && limitIteration > 0);
        Assert.That(computerUseWasCalled, "The computer use tool was not called.");
        Assert.That(response.GetOutputText(), Is.Not.Null.And.Not.Empty);
    }

    //[RecordedTest]
    //[Ignore("Needs recording update for 2025-11-15-preview")]
    //public async Task TestAzureContainerApp()
    //{
    //    AIProjectClient projectClient = GetTestProjectClient();
    //    ProjectsAgentVersion containerProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    //        agentName: AGENT_NAME,
    //        options: new(new ContainerApplicationProjectsAgentDefinition(
    //            containerProtocolVersions: [new ProtocolVersionRecord(protocol: AgentCommunicationMethod.Responses, version: "1")],
    //            containerAppResourceId: TestEnvironment.CONTAINER_APP_RESOURCE_ID,
    //            ingressSubdomainSuffix: TestEnvironment.INGRESS_SUBDOMAIN_SUFFIX)));
    //    ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(AGENT_NAME);
    //    ProjectConversationsClient conversationClient = projectClient.ProjectOpenAIClient.GetProjectConversationsClient();
    //    ProjectConversationCreationOptions conversationOptions = new();
    //    conversationOptions.Items.Add(
    //        ResponseItem.CreateUserMessageItem("What is the size of France in square miles?")
    //    );
    //    ProjectConversation conversation = await conversationClient.CreateProjectConversationAsync(conversationOptions);
    //    CreateResponseOptions responseOptions = new()
    //    {
    //        Agent = containerProjectsAgentVersion,
    //        AgentConversationId = conversation.Id,
    //    };

    //    ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
    //    response = await WaitForRun(responseClient, response);
    //    Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    //    Assert.That(response.GetOutputText(), Is.Not.Null.And.Not.Empty);
    //}

    [RecordedTest]
    [TestCase(true)]
    [TestCase(false)]
    public async Task PerRequestToolsRejectedWithAgent(bool agentIsPresent)
    {
        AIProjectClient projectClient = GetTestProjectClient();
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClient();

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
            ProjectsAgentDefinition ProjectsAgentDefinition = new DeclarativeAgentDefinition(TestEnvironment.FOUNDRY_MODEL_NAME)
            {
                Instructions = "You are a helpful agent that happens to always talk like a pirate. Arr!",
            };

            ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
                agentName: "TestPromptAgentFromDotnet",
                options: new(ProjectsAgentDefinition));

            responseOptions.Agent = new(name: ProjectsAgentVersion.Name, version: ProjectsAgentVersion.Version);
        }
        else
        {
            responseOptions.Model = TestEnvironment.FOUNDRY_MODEL_NAME;
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

        ProjectsAgentDefinition ProjectsAgentDefinition = new DeclarativeAgentDefinition(TestEnvironment.FOUNDRY_MODEL_NAME)
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

        ProjectsAgentVersion newProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            "TestPiratePromptAgentWithToolsFromDotnetTests",
            new ProjectsAgentVersionCreationOptions(ProjectsAgentDefinition)
            {
                Metadata =
                {
                    ["can_delete_this"] = "true"
                }
            },
            cancellationToken: cts.Token);

        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: newProjectsAgentVersion.Name, version: newProjectsAgentVersion.Version));

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
            ProjectConversation conversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync(options: null, cts.Token);
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
        AIProjectClient client = CreateProxyFromClient(new AIProjectClient(new Uri(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT), TestEnvironment.Credential, options));

        RequestOptions protocolRequestOptions = new();
        protocolRequestOptions.AddHeader("User-Agent", "DotnetTestMyProtocolUserAgent");

        ClientResult protocolResult = await client.ProjectOpenAIClient.GetProjectResponsesClient().CreateResponseAsync(
            BinaryContent.Create(
                BinaryData.FromString($$"""
                    {
                      "model": "{{TestEnvironment.FOUNDRY_MODEL_NAME}}",
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
        Uri uriEndpoint = new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT);
        string[] pathParts = uriEndpoint.AbsolutePath.Split('/');
        string projectName = pathParts[pathParts.Length - 1];
        string accountId = uriEndpoint.Authority.Substring(0, uriEndpoint.Authority.IndexOf('.'));
        HostedAgentDefinition ProjectsAgentDefinition = new(
            versions: [new ProtocolVersionRecord(ProjectsAgentProtocol.ActivityProtocol, "v1")],
            cpu: "1",
            memory: "2Gi"
        )
        {
            Image = TestEnvironment.AGENT_DOCKER_IMAGE,
            EnvironmentVariables = {
                { "AZURE_OPENAI_ENDPOINT", $"https://{accountId}.cognitiveservices.azure.com/" },
                { "AZURE_OPENAI_CHAT_DEPLOYMENT_NAME", TestEnvironment.FOUNDRY_MODEL_NAME },
                // Optional variables, used for logging
                { "APPLICATIONINSIGHTS_CONNECTION_STRING", TestEnvironment.APPLICATIONINSIGHTS_CONNECTION_STRING },
                { "AGENT_PROJECT_RESOURCE_ID", TestEnvironment.FOUNDRY_PROJECT_ENDPOINT },
            }
        };
        ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: AGENT_NAME2,
            options: new(ProjectsAgentDefinition));
        Assert.That(ProjectsAgentVersion.Definition.GetType().ToString(), Does.Contain("Azure.AI.Projects.Agents.HostedAgentDefinition"));
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: ProjectsAgentVersion.Name, agentVersion: ProjectsAgentVersion.Version);
        Assert.ThrowsAsync<ClientResultException>(async () => await projectClient.AgentAdministrationClient.GetAgentVersionAsync(agentName: ProjectsAgentVersion.Name, agentVersion: ProjectsAgentVersion.Version));
    }

    [RecordedTest]
    public async Task TestHostedAgentEndpoint()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        Uri uriEndpoint = new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT);
        HostedAgentDefinition agentDefinition = new(
            versions: [new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0")],
            cpu: "0.5",
            memory: "1Gi"
        )
        {
            Image = TestEnvironment.AGENT_DOCKER_IMAGE,
        };
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: HOSTED_AGENT,
            options: creationOptions);
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Active)
        {
            await Delay();
            agentVersion = await projectClient.AgentAdministrationClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        Assert.That(agentVersion.Status, Is.EqualTo(AgentVersionStatus.Active));
        AgentEndpoint config = new()
        {
            VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 100)]),
            Protocols = { AgentEndpointProtocol.Responses }
        };
        PatchAgentOptions patchOptions = new()
        {
            AgentEndpoint = config,
        };
        ProjectsAgentRecord patchedRecord = await projectClient.AgentAdministrationClient.PatchAgentObjectAsync(
            agentName: agentVersion.Name,
            patchAgentOptions: patchOptions);
        ProjectOpenAIClientOptions responsesOptions = CreateTestProjectOpenAIClientOptions(
            apiVersion: "v1"
        );
        responsesOptions.AgentName = agentVersion.Name;
        ProjectOpenAIClient openAIClient = CreateProxyFromClient(new ProjectOpenAIClient(uriEndpoint, GetTestTokenProvider(), responsesOptions));
        ProjectResponsesClient responseClient = openAIClient.GetProjectResponsesClient();
        ResponseResult response = await responseClient.CreateResponseAsync("Hello, tell me a joke.");
        Assert.That(response.GetOutputText(), Is.Not.Empty);
    }

    [RecordedTest]
    [TestCase(ToolType.None)]
    [TestCase(ToolType.FileSearch)]
    public async Task StructuredInputsWorkWithTools(ToolType toolType)
    {
        AIProjectClient projectClient = GetTestProjectClient();

        DeclarativeAgentDefinition ProjectsAgentDefinition = new(TestEnvironment.FOUNDRY_MODEL_NAME)
        {
            Instructions = "You are a helpful agent that uses tools to answer questions.",
        };

        if (toolType == ToolType.FileSearch)
        {
            ProjectsAgentDefinition.Tools.Add(ResponseTool.CreateFileSearchTool(vectorStoreIds: ["{{PerRequestVectorStoreId}}"]));
            ProjectsAgentDefinition.StructuredInputs["PerRequestVectorStoreId"] = new StructuredInputDefinition()
            {
                IsRequired = true,
            };
            OpenAIFile uploadedFile = await projectClient.ProjectOpenAIClient.GetProjectFilesClient().UploadFileAsync(
                file: BinaryData.FromString("Travis's favorite food is pizza."),
                filename: "test_favorite_foods.txt",
                purpose: FileUploadPurpose.Assistants);
            VectorStore vectorStore = await projectClient.ProjectOpenAIClient.GetProjectVectorStoresClient().CreateVectorStoreAsync(
                options: new VectorStoreCreationOptions()
                {
                    Name = VECTOR_STORE,
                    FileIds = { uploadedFile.Id },
                });

            ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
                    agentName: AGENT_NAME,
                    options: new ProjectsAgentVersionCreationOptions(ProjectsAgentDefinition));

            CreateResponseOptions createResponsOptions = new()
            {
                Agent = new(name: ProjectsAgentVersion.Name, version: ProjectsAgentVersion.Version),
                InputItems = { ResponseItem.CreateUserMessageItem("Based on searchable files, what's Travis's favorite food?") },
            };
            createResponsOptions.Patch.Set("$.structured_inputs[\"PerRequestVectorStoreId\"]"u8, BinaryData.FromString(@$"""{vectorStore.Id}"""));
            ResponseResult response = await projectClient.ProjectOpenAIClient.GetProjectResponsesClient().CreateResponseAsync(
                options: createResponsOptions);

            Assert.That(response.OutputItems?.Any(item => item is FileSearchCallResponseItem) == true);
            Assert.That(response.GetOutputText().ToLowerInvariant(), Does.Contain("pizza"));
        }
        else if (toolType == ToolType.None)
        {
            ProjectsAgentDefinition.Instructions = "You are a friendly agent. The name of the user talking to you is {{user_name}}.";
            ProjectsAgentDefinition.StructuredInputs.Add(
                key: "user_name",
                value: new StructuredInputDefinition()
                {
                    DefaultValue = BinaryData.FromObjectAsJson(JsonValue.Create("Ishmael")),
                });
            ProjectsAgentVersion ProjectsAgentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
                agentName: AGENT_NAME,
                options: new ProjectsAgentVersionCreationOptions(ProjectsAgentDefinition));

            CreateResponseOptions createResponsOptions = new()
            {
                Agent = new(name: ProjectsAgentVersion.Name, version: ProjectsAgentVersion.Version),
                InputItems = { ResponseItem.CreateUserMessageItem("What's my name?") },
            };
            createResponsOptions.Patch.Set("$.structured_inputs[\"user_name\"]"u8, BinaryData.FromObjectAsJson(JsonValue.Create("Travis")));

            ResponseResult response = await projectClient.ProjectOpenAIClient.GetProjectResponsesClient().CreateResponseAsync(
                options: createResponsOptions);

            Assert.That(response.GetOutputText().ToLowerInvariant(), Does.Contain("travis"));

            response = await projectClient.ProjectOpenAIClient.GetProjectResponsesClient().CreateResponseAsync(
                options: new CreateResponseOptions()
                {
                    Agent = new(name: ProjectsAgentVersion.Name, version: ProjectsAgentVersion.Version),
                    InputItems = { ResponseItem.CreateUserMessageItem("What's my name?") },
                });
            Assert.That(response.GetOutputText().ToLowerInvariant(), Does.Contain("ishmael"));
            Assert.That(response.GetOutputText().ToLowerInvariant(), Does.Not.Contain("travis"));
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    private bool ContainsAnnotation(ResponseItem item, ToolType type)
    {
        StringBuilder sbAnnotations = new();
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
                        if (ExpectedAnnotationTitle.TryGetValue(type, out string expectedTitle))
                        {
                            if (uriAnnotation.Title.ToLower().Contains(expectedTitle.ToLower()))
                            {
                                isUriCitationFound = true;
                                break;
                            }
                            else
                            {
                                sbAnnotations.Append($"[{uriAnnotation.Title}]({uriAnnotation.Uri})\n");
                                // The next check is disabled, because of an ADO issue 4836442.
                                // Assert.That(uriAnnotation.Uri, Does.Contain("www.microsoft.com"), $"Wrong citation title {uriAnnotation.Uri}, should be \"www.microsoft.com\"");
                            }
                        }
                        else
                        {
                            isUriCitationFound = true;
                            break;
                        }
                    }
                    else
                    {
                        Assert.Fail($"Found unexpected annotation {annotation}");
                    }
                }
                if (isUriCitationFound)
                {
                    break;
                }
            }
        }
        if (!isUriCitationFound && sbAnnotations.Length > 0)
        {
            Assert.Fail($"Found wrong citations:\n{sbAnnotations}");
        }
        return isUriCitationFound;
    }

    private static async Task<bool> ContainsDownloadableFileAnnotation(ResponseItem item, AIProjectClient projectClient)
    {
        ContainerClient containerClient = projectClient.ProjectOpenAIClient.GetContainerClient();
        ContainerFileCitationMessageAnnotation containerAnnotation = null;
        if (item is MessageResponseItem messageItem)
        {
            foreach (ResponseContentPart content in messageItem.Content)
            {
                foreach (ResponseMessageAnnotation annotation in content.OutputTextAnnotations)
                {
                    if (annotation is ContainerFileCitationMessageAnnotation cntrAnnotation)
                    {
                        containerAnnotation = cntrAnnotation;
                    }
                }
            }
        }
        if (containerAnnotation is null)
        {
            return false;
        }
        BinaryData fileData = await containerClient.DownloadContainerFileAsync(containerId: containerAnnotation.ContainerId, fileId: containerAnnotation.FileId);
        return !fileData.IsEmpty;
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
