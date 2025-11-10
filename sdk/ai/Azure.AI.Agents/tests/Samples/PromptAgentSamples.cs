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
using System.ClientModel;

namespace Azure.AI.Agents.Tests.Samples;

public class PromptAgentSamples : AgentsTestBase
{
    [Test]
    public async Task CreateAPromptAgent()
    {
        IgnoreSampleMayBe();
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
    [AsyncOnly]
    public async Task RunAPromptAgentNoConversationAsync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
#else
        string RAW_PROJECT_ENDPOINT = TestEnvironment.PROJECT_ENDPOINT;
        string MODEL_DEPLOYMENT = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentClient agentClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        OpenAIClient openAIClient = agentClient.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);
        #region Snippet:CreateAgent_Basic_Async
        PromptAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
        {
            Instructions = "You are a physics teacher with a sense of humor.",
        };
        AgentVersion agentVersion = await agentClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition)
        );
        #endregion
        #region Snippet:CreateResponseBasic_Async
        var agentReference = new AgentReference(name: agentVersion.Name);
        ResponseCreationOptions responseCreationOptions = new();
        responseCreationOptions.SetAgentReference(agentReference);
        OpenAIResponse response = await responseClient.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("Write Maxwell's eqution in LaTeX format.")],
            responseCreationOptions);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:FollowUp_Basic_Async
        responseCreationOptions.PreviousResponseId = response.Id;
        response = await responseClient.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("What was the previous question?")],
            responseCreationOptions);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:CleanUp_Basic_Async
        await agentClient.DeleteAgentAsync(agentName: "myAgent");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void RunAPromptAgentNoConversationSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
#else
        string RAW_PROJECT_ENDPOINT = TestEnvironment.PROJECT_ENDPOINT;
        string MODEL_DEPLOYMENT = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentClient agentClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        OpenAIClient openAIClient = agentClient.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);
        #region Snippet:CreateAgent_Basic_Sync
        PromptAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
        {
            Instructions = "You are a physics teacher with a sense of humor.",
        };
        AgentVersion agentVersion = agentClient.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition)
        );
        #endregion
        var agentReference = new AgentReference(name: agentVersion.Name);
        ResponseCreationOptions responseCreationOptions = new();
        responseCreationOptions.SetAgentReference(agentReference);
        OpenAIResponse response = responseClient.CreateResponse(
            [ResponseItem.CreateUserMessageItem("Write Maxwell's eqution in LaTeX format.")],
            responseCreationOptions);
        Console.WriteLine(response.GetOutputText());
        responseCreationOptions.PreviousResponseId = response.Id;
        response = responseClient.CreateResponse(
            [ResponseItem.CreateUserMessageItem("What was the previous question?")],
            responseCreationOptions);
        Console.WriteLine(response.GetOutputText());
        agentClient.DeleteAgent(agentName: "myAgent");
    }

    [Test]
    public async Task RunAPromptAgent()
    {
        IgnoreSampleMayBe();
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
        #region Snippet:ConversationClient
        ResponseCreationOptions responseCreationOptions = new();
        responseCreationOptions.SetAgentReference(AGENT_NAME);

        // Optionally, use a conversation to automatically maintain state between calls.
        AgentConversation conversation = await agentClient.GetConversationClient().CreateConversationAsync();
        responseCreationOptions.SetConversationReference(conversation);
        #endregion
        List<ResponseItem> items = [ResponseItem.CreateUserMessageItem("Tell me a one-line story.")];
        OpenAIResponse response = await responseClient.CreateResponseAsync(items, responseCreationOptions);

        Console.WriteLine(response.GetOutputText());
        #region Snippet:DeleteConversationClient
        await agentClient.GetConversationClient().DeleteConversationAsync(conversation.Id);
        #endregion
    }

    [Test]
    public async Task FullPromptAgentEndToEnd()
    {
        IgnoreSampleMayBe();
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
        #region Snippet:ExistingConversations
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
        #endregion
        Console.WriteLine(response.GetOutputText());
        await agentClient.GetConversationClient().DeleteConversationAsync(conversation.Id);
    }

    [Test]
    public async Task AgentError()
    {
        IgnoreSampleMayBe();
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
        #region Snippet:ErrorHandling
        try
        {
            AgentVersion agent = await agentClient.GetAgentVersionAsync(
                agentName: "agent_which_dies_not_exist", agentVersion: "1");
        }
        catch (ClientResultException e) when (e.Status == 404)
        {
            Console.WriteLine($"Exception status code: {e.Status}");
            Console.WriteLine($"Exception message: {e.Message}");
        }
        #endregion
    }
    public PromptAgentSamples(bool isAsync) : base(isAsync)
    { }
}
