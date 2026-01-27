// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_MemorySearchTool : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task MemorySearchToolAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_MemoryTool
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var embeddingDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var embeddingDeploymentName = TestEnvironment.EMBEDDINGMODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateAgent_MemoryTool_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateConversation_MemoryTool_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        ResponseItem request = ResponseItem.CreateUserMessageItem("Hello, tell me a joke.");
        ResponseResult response = await responseClient.CreateResponseAsync([request]);
        #endregion
        try
        {
            await projectClient.MemoryStores.DeleteMemoryStoreAsync("jokeMemory");
        }
        catch
        {
            // Nothing here.
        }
        #region Snippet:Sample_WriteOutput_MemoryTool_Async
        string scope = "Joke";
        MemoryUpdateOptions memoryOptions = new(scope);
        memoryOptions.Items.Add(request);
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        // We cannot use the output items as an input so we will need to
        // create a new user item.
        memoryOptions.Items.Add(ResponseItem.CreateUserMessageItem($"Agent answered: {response.GetOutputText()}"));
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:CreateMemoryStore_MemoryTool_Async
        MemoryStoreDefaultDefinition memoryStoreDefinition = new(
            chatModel: modelDeploymentName,
            embeddingModel: embeddingDeploymentName
        );
        memoryStoreDefinition.Options = new(userProfileEnabled: true, chatSummaryEnabled: true);
        MemoryStore memoryStore = await projectClient.MemoryStores.CreateMemoryStoreAsync(
            name: "jokeMemory",
            definition: memoryStoreDefinition,
            description: "Memory store for conversation."
        );
        MemoryUpdateResult updateResult = await projectClient.MemoryStores.WaitForMemoriesUpdateAsync(memoryStoreName: memoryStore.Name, options: memoryOptions, pollingInterval: 500);
        if (updateResult.Status == MemoryStoreUpdateStatus.Failed)
        {
            throw new InvalidOperationException(updateResult.ErrorDetails);
        }
        #endregion
        #region Snippet:Sample_CheckMemorySearch_Async
        MemorySearchOptions searchOptions = new(scope)
        {
            Items = { ResponseItem.CreateUserMessageItem("What was the joke?") },
        };
        MemoryStoreSearchResponse resp = await projectClient.MemoryStores.SearchMemoriesAsync(
            memoryStoreName: memoryStore.Name,
            options: searchOptions
        );
        Console.WriteLine("==The output from memory tool.==");
        foreach (Azure.AI.Projects.MemorySearchItem item in resp.Memories)
        {
            Console.WriteLine(item.MemoryItem.Content);
        }
        Console.WriteLine("==End of memory tool output.==");
        #endregion
        #region Snippet:Sample_CreateAgentWithTool_MemoryTool_Async
        agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent capable to access memorized conversation.",
        };
        agentDefinition.Tools.Add(new MemorySearchPreviewTool(memoryStoreName: memoryStore.Name, scope: scope));
        AgentVersion agentVersion2 = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent2",
            options: new(agentDefinition));
        #endregion

        #region Snippet:Sample_AnotherConversation_MemoryTool_Async
        responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion2.Name);

        response = await responseClient.CreateResponseAsync(
            "Please explain me the meaning of the joke from the previous conversation.");
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_MemoryTool_Async
        await projectClient.MemoryStores.DeleteMemoryStoreAsync(name: memoryStore.Name);
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void MemorySearchTool()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var embeddingDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var embeddingDeploymentName = TestEnvironment.EMBEDDINGMODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        #region Snippet:Sample_CreateAgent_MemoryTool_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        try
        {
            projectClient.MemoryStores.DeleteMemoryStore("jokeMemory");
        }
        catch
        {
            // Nothing here.
        }
        #region Snippet:Sample_CreateConversation_MemoryTool_Sync

        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

        ResponseItem request = ResponseItem.CreateUserMessageItem("Hello, tell me a joke.");
        ResponseResult response = responseClient.CreateResponse([request]);
        #endregion

        #region Snippet:Sample_WriteOutput_MemoryTool_Sync
        string scope = "Joke";
        MemoryUpdateOptions memoryOptions = new(scope);
        memoryOptions.Items.Add(request);
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        // We cannot use the output items as an input so we will need to
        // create a new user item.
        memoryOptions.Items.Add(ResponseItem.CreateUserMessageItem($"Agent answered: {response.GetOutputText()}"));
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:CreateMemoryStore_MemoryTool_Sync
        MemoryStoreDefaultDefinition memoryStoreDefinition = new(
            chatModel: modelDeploymentName,
            embeddingModel: embeddingDeploymentName
        );
        memoryStoreDefinition.Options = new(userProfileEnabled: true, chatSummaryEnabled: true);
        MemoryStore memoryStore = projectClient.MemoryStores.CreateMemoryStore(
            name: "jokeMemory",
            definition: memoryStoreDefinition,
            description: "Memory store for conversation."
        );
        MemoryUpdateResult updateResult = projectClient.MemoryStores.WaitForMemoriesUpdate(memoryStoreName: memoryStore.Name, options: memoryOptions, pollingInterval: 500);
        if (updateResult.Status == MemoryStoreUpdateStatus.Failed)
        {
            throw new InvalidOperationException(updateResult.ErrorDetails);
        }
        #endregion
        #region Snippet:Sample_CheckMemorySearch_Sync
        MemorySearchOptions searchOptions = new(scope)
        {
            Items = { ResponseItem.CreateUserMessageItem("What was the joke?") },
        };
        MemoryStoreSearchResponse resp = projectClient.MemoryStores.SearchMemories(
            memoryStoreName: memoryStore.Name,
            options: searchOptions
        );
        Console.WriteLine("==The output from memory search tool.==");
        foreach (Azure.AI.Projects.MemorySearchItem item in resp.Memories)
        {
            Console.WriteLine(item.MemoryItem.Content);
        }
        Console.WriteLine("==End of memory search tool output.==");
        #endregion
        #region Snippet:Sample_CreateAgentWithTool_MemoryTool_Sync
        agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent capable to access memorized conversation.",
        };
        agentDefinition.Tools.Add(new MemorySearchPreviewTool(memoryStoreName: memoryStore.Name, scope: scope));
        AgentVersion agentVersion2 = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent2",
            options: new(agentDefinition));
        #endregion

        #region Snippet:Sample_AnotherConversation_MemoryTool_Sync
        responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion2.Name);

        response = responseClient.CreateResponse(
            [ResponseItem.CreateUserMessageItem("Please explain me the meaning of the joke from the previous conversation.")]);
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_MemoryTool_Sync
        projectClient.MemoryStores.DeleteMemoryStore(name: memoryStore.Name);
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
        #endregion
    }

    public Sample_MemorySearchTool(bool isAsync) : base(isAsync)
    { }
}
