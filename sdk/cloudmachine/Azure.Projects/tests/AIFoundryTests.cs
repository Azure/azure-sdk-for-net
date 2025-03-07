// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Inference;
using Azure.AI.Projects;
using Azure.Projects.AIFoundry;
using Azure.Projects.OpenAI;
using Azure.Core.TestFramework;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using NUnit.Framework;
using OpenAI.Chat;
using OpenAI.Embeddings;
using Azure.AI.OpenAI;

namespace Azure.Projects.Tests;

public partial class AIFoundryTests : SamplesBase<AzureProjectsTestEnvironment>
{
    [Test]
    public void AIFoundryScenariosTests()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        AIFoundryClient client = new AIFoundryClient(connectionString);

        // Azure AI Project clients
        AgentsClient agents = client.GetAgentsClient();
        AI.Projects.EvaluationsClient evaluations = client.GetEvaluationsClient();

        // Azure Inference Clients using connections API
        ChatCompletionsClient chatClient = client.GetChatCompletionsClient();
        EmbeddingsClient embeddingsClient = client.GetEmbeddingsClient();

        // Azure OpenAI Clients using connections API
        ChatClient openAIChatClient = client.GetOpenAIChatClient("gpt-4o-mini");
        EmbeddingClient openAIEmbeddingsClient = client.GetOpenAIEmbeddingClient("text-embedding-ada-002");

        // Azure AI Search Clients using connections API
        SearchClient searchClient = client.GetSearchClient("index");
        SearchIndexClient indexClient = client.GetSearchIndexClient();
        SearchIndexerClient indexerClient = client.GetSearchIndexerClient();
    }

    [Test]
    public void AIFoundryAgents()
    {
        var connectionString = Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        AIFoundryClient client = new AIFoundryClient(connectionString);
        var agentsClient = client.GetAgentsClient();

        //// Step 2: Create a agent
        Response<Agent> agentResponse = agentsClient.CreateAgent(
            model: "gpt-4-1106-preview",
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions.",
            tools: new List<ToolDefinition> { new CodeInterpreterToolDefinition() });
        Agent agent = agentResponse.Value;

        //// Step 2: Create a thread
        Response<AgentThread> threadResponse = agentsClient.CreateThread();
        AgentThread thread = threadResponse.Value;

        // Step 3: Add a message to a thread
        Response<ThreadMessage> messageResponse = agentsClient.CreateMessage(
            thread.Id,
            MessageRole.User,
            "I need to solve the equation `3x + 11 = 14`. Can you help me?");
        ThreadMessage message = messageResponse.Value;

        // Step 4: Run the agent
        Response<ThreadRun> runResponse = agentsClient.CreateRun(thread.Id, agent.Id);

        do
        {
            Task.Delay(TimeSpan.FromMilliseconds(500));
            runResponse = agentsClient.GetRun(thread.Id, runResponse.Value.Id);
        }
        while (runResponse.Value.Status == RunStatus.Queued
            || runResponse.Value.Status == RunStatus.InProgress);

        //// Step 5: Print the messages
        // Note: messages iterate from newest to oldest, with the messages[0] being the most recent
        foreach (ThreadMessage threadMessage in agentsClient.GetMessages(thread.Id).Value.Data)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    Console.Write(textItem.Text);
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
    }

    [Test]
    public void AIFoundryInferenceChatCompletion()
    {
        var connectionString = Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        AIFoundryClient client = new AIFoundryClient(connectionString);
        var chatClient = client.GetChatCompletionsClient();

        var requestOptions = new ChatCompletionsOptions()
        {
            Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
            Model = "Meta-Llama-3-1-70B-Instruct-byyz"
        };

        Response<ChatCompletions> response = chatClient.Complete(requestOptions);
        Console.WriteLine(response.Value.Content);
    }

    [Test]
    public void AIFoundryAzureOpenAIChatCompletion()
    {
        var connectionString = Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        AIFoundryClient client = new AIFoundryClient(connectionString);
        ChatClient chatClient = client.GetOpenAIChatClient("gpt-4o-mini");

        ChatCompletion completion = chatClient.CompleteChat(
            [
                new SystemChatMessage("You are a helpful assistant."),
                new UserChatMessage("List all the colors of the rainbow"),
            ]);

        Console.WriteLine($"{completion.Role}: {completion.Content[0].Text}");
    }

    [Test]
    public void AIFoundryScenariosTestsUsingCMClient()
    {
        ProjectInfrastructure infra = new();

        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        infra.AddFeature(new AIProjectFeature(connectionString));

        ProjectClient client = new();

        // Azure AI Project clients
        AgentsClient agents = client.GetAgentsClient();
        AI.Projects.EvaluationsClient evaluations = client.GetEvaluationsClient();

        // Azure Inference Clients using connections API
        ChatCompletionsClient chatClient = client.GetChatCompletionsClient();
        EmbeddingsClient embeddingsClient = client.GetEmbeddingsClient();

        // Azure OpenAI Clients using connections API
        ChatClient openAIChatClient = client.GetOpenAIChatClient("gpt-4o-mini");
        EmbeddingClient openAIEmbeddingsClient = client.GetOpenAIEmbeddingClient("text-embedding-ada-002");

        // Azure AI Search Clients using connections API
        SearchClient searchClient = client.GetSearchClient("index");
        SearchIndexClient indexClient = client.GetSearchIndexClient();
        SearchIndexerClient indexerClient = client.GetSearchIndexerClient();
    }
}
