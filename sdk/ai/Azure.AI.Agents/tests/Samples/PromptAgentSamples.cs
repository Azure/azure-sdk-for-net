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

namespace Azure.AI.Agents.Tests.Samples;

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

        AgentClient agentClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());

        AgentDefinition agentDefinition = new PromptAgentDefinition(MODEL_DEPLOYMENT)
        {
            Instructions = "You are a foo bar agent. In EVERY response you give, ALWAYS include both `foo` and `bar` strings somewhere in the response.",
        };

        AgentVersion newAgentVersion = await agentClient.CreateAgentVersionAsync(
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
        AgentClient agentClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        OpenAIClient openAIClient = agentClient.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);

        ResponseCreationOptions responseCreationOptions = new();
        responseCreationOptions.SetAgentReference(AGENT_NAME);

        // Optionally, use a conversation to automatically maintain state between calls.
        AgentConversation conversation = await agentClient.GetConversationClient().CreateConversationAsync();
        responseCreationOptions.SetConversationReference(conversation);

        List<ResponseItem> items = [ResponseItem.CreateUserMessageItem("Tell me a one-line story.")];
        OpenAIResponse response = await responseClient.CreateResponseAsync(items, responseCreationOptions);

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
        AgentClient agentClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        OpenAIClient openAIClient = agentClient.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);

        //
        // Create an agent version for a new prompt agent
        //

        AgentDefinition agentDefinition = new PromptAgentDefinition(MODEL_DEPLOYMENT)
        {
            Instructions = "You are a foo bar agent. In EVERY response you give, ALWAYS include both `foo` and `bar` strings somewhere in the response.",
        };
        AgentVersion newAgentVersion = await agentClient.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(agentDefinition));

        //
        // Create a conversation to maintain state between calls
        //

        AgentConversationCreationOptions conversationOptions = new()
        {
            Items = { ResponseItem.CreateSystemMessageItem("Your preferred genre of story today is: horror.") },
            Metadata = { ["foo"] = "bar" },
        };
        AgentConversation conversation = await agentClient.GetConversationClient().CreateConversationAsync(conversationOptions);

        //
        // Add items to an existing conversation to supplement the interaction state
        //
        string EXISTING_CONVERSATION_ID = conversation.Id;

        _ = await agentClient.GetConversationClient().CreateConversationItemsAsync(
            EXISTING_CONVERSATION_ID,
            [ResponseItem.CreateSystemMessageItem("Story theme to use: department of licensing.")]);

        //
        // Use the agent and conversation in a response
        //

        ResponseCreationOptions responseCreationOptions = new();
        responseCreationOptions.SetAgentReference(AGENT_NAME);
        responseCreationOptions.SetConversationReference(EXISTING_CONVERSATION_ID);

        List<ResponseItem> items = [ResponseItem.CreateUserMessageItem("Tell me a one-line story.")];
        OpenAIResponse response = await responseClient.CreateResponseAsync(items, responseCreationOptions);

        Console.WriteLine(response.GetOutputText());
        #endregion
    }

    public PromptAgentSamples(bool isAsync) : base(isAsync)
    { }
}
