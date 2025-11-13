// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;
using Azure.AI.Projects.OpenAI;

namespace Azure.AI.Projects.Tests.Samples;

[Ignore("Samples represented as tests only for validation of compilation.")]
public class PromptAgentSamples : AgentsTestBase
{
    [Test]
    public async Task CreateAPromptAgent()
    {
        #region Snippet:CreateAPromptAgent
#if SNIPPET
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
        string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");
#else
        string RAW_PROJECT_ENDPOINT = TestEnvironment.PROJECT_ENDPOINT;
        string MODEL_DEPLOYMENT = TestEnvironment.MODELDEPLOYMENTNAME;
        string AGENT_NAME = TestEnvironment.AGENT_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new DefaultAzureCredential());

        AgentDefinition agentDefinition = new PromptAgentDefinition(MODEL_DEPLOYMENT)
        {
            Instructions = "You are a foo bar agent. In EVERY response you give, ALWAYS include both `foo` and `bar` strings somewhere in the response.",
        };

        AgentVersion newAgentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(agentDefinition));
        Console.WriteLine($"Created new agent version: {newAgentVersion.Name}");
        #endregion
    }

    [Test]
    public async Task RunAPromptAgent()
    {
        #region Snippet:RunAPromptAgent
#if SNIPPET
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
        string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");
#else
        string RAW_PROJECT_ENDPOINT = TestEnvironment.PROJECT_ENDPOINT;
        string MODEL_DEPLOYMENT = TestEnvironment.MODELDEPLOYMENTNAME;
        string AGENT_NAME = TestEnvironment.AGENT_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new DefaultAzureCredential());

        // Optionally, use a conversation to automatically maintain state between calls.
        AgentConversation conversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync();

        OpenAIResponseClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(AGENT_NAME, conversation);
        OpenAIResponse response = await responseClient.CreateResponseAsync("Tell me a one-line story.");

        Console.WriteLine(response.GetOutputText());
        #endregion
    }

    [Test]
    public async Task FullPromptAgentEndToEnd()
    {
        #region Snippet:FullPromptAgentEndToEnd
#if SNIPPET
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
        string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");
#else
        string RAW_PROJECT_ENDPOINT = TestEnvironment.PROJECT_ENDPOINT;
        string MODEL_DEPLOYMENT = TestEnvironment.MODELDEPLOYMENTNAME;
        string AGENT_NAME = TestEnvironment.AGENT_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new DefaultAzureCredential());

        //
        // Create an agent version for a new prompt agent
        //

        AgentDefinition agentDefinition = new PromptAgentDefinition(MODEL_DEPLOYMENT)
        {
            Instructions = "You are a foo bar agent. In EVERY response you give, ALWAYS include both `foo` and `bar` strings somewhere in the response.",
        };
        AgentVersion newAgentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(agentDefinition));

        //
        // Create a conversation to maintain state between calls
        //

        ProjectConversationCreationOptions conversationOptions = new()
        {
            Items = { ResponseItem.CreateSystemMessageItem("Your preferred genre of story today is: horror.") },
            Metadata = { ["foo"] = "bar" },
        };
        AgentConversation conversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync(conversationOptions);

        //
        // Add items to an existing conversation to supplement the interaction state
        //
        string EXISTING_CONVERSATION_ID = conversation.Id;

        _ = await projectClient.OpenAI.Conversations.CreateAgentConversationItemsAsync(
            EXISTING_CONVERSATION_ID,
            [ResponseItem.CreateSystemMessageItem("Story theme to use: department of licensing.")]);

        //
        // Use the agent and conversation in a response
        //

        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(AGENT_NAME);

        ResponseCreationOptions responseCreationOptions = new()
        {
            AgentConversationId = EXISTING_CONVERSATION_ID,
        };

        List<ResponseItem> items = [ResponseItem.CreateUserMessageItem("Tell me a one-line story.")];
        OpenAIResponse response = await responseClient.CreateResponseAsync(items, responseCreationOptions);

        Console.WriteLine(response.GetOutputText());
        #endregion
    }

    public PromptAgentSamples(bool isAsync) : base(isAsync)
    { }
}
