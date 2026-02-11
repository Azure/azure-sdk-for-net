// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using OpenAI.Responses;
using System.ClientModel;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class PromptAgentSamples : ProjectsOpenAITestBase
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

        AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());

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
        AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        ProjectOpenAIClient openaiClient = projectClient.GetProjectOpenAIClient();
        #region Snippet:CreateAgent_Basic_Async
        PromptAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
        {
            Instructions = "You are a physics teacher with a sense of humor.",
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition)
        );
        #endregion
        #region Snippet:CreateResponseBasic_Async
        var agentReference = new AgentReference(name: agentVersion.Name);
        ProjectResponsesClient responseClient = openaiClient.GetProjectResponsesClientForAgent(agentReference);
        CreateResponseOptions responseOptions = new([ResponseItem.CreateUserMessageItem("Write Maxwell's equation in LaTeX format.")]);
        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:FollowUp_Basic_Async
        CreateResponseOptions followupOptions = new()
        {
            PreviousResponseId = response.Id,
            InputItems = { ResponseItem.CreateUserMessageItem("What was the previous question?") },
        };
        response = await responseClient.CreateResponseAsync(followupOptions);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:CleanUp_Basic_Async
        await projectClient.Agents.DeleteAgentAsync(agentName: "myAgent");
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
        AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        ProjectOpenAIClient openAIClient = projectClient.GetProjectOpenAIClient();
        PromptAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
        {
            Instructions = "You are a physics teacher with a sense of humor.",
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition)
        );
        var agentReference = new AgentReference(name: agentVersion.Name);
        CreateResponseOptions responseOptions = new([ResponseItem.CreateUserMessageItem("Write Maxwell's equation in LaTeX format.")]);
        ProjectResponsesClient responseClient = openAIClient.GetProjectResponsesClientForAgent(agentReference);
        ResponseResult response = responseClient.CreateResponse(responseOptions);
        Console.WriteLine(response.GetOutputText());
        responseOptions.InputItems.Clear();
        responseOptions.InputItems.Add(ResponseItem.CreateUserMessageItem("What was the previous question?"));
        responseOptions.PreviousResponseId = response.Id;
        response = responseClient.CreateResponse(responseOptions);
        Console.WriteLine(response.GetOutputText());
        projectClient.Agents.DeleteAgent(agentName: "myAgent");
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
        AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        ProjectOpenAIClient openAIClient = projectClient.GetProjectOpenAIClient();
        #region Snippet:ConversationClient
        CreateResponseOptions CreateResponseOptions = new();
        // Optionally, use a conversation to automatically maintain state between calls.
        ProjectConversation conversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync();
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(AGENT_NAME, conversation);
        #endregion
        List<ResponseItem> items = [ResponseItem.CreateUserMessageItem("Tell me a one-line story.")];
        ResponseResult response = await responseClient.CreateResponseAsync("Tell me a one-line story.");

        Console.WriteLine(response.GetOutputText());
        #region Snippet:DeleteConversationClient
        await openAIClient.GetConversationClient().DeleteConversationAsync(conversation.Id);
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
        AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        ProjectOpenAIClient openAIClient = projectClient.GetProjectOpenAIClient();

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
        #region Snippet:ExistingConversations
        ProjectConversationCreationOptions conversationOptions = new()
        {
            Items = { ResponseItem.CreateSystemMessageItem("Your preferred genre of story today is: horror.") },
            Metadata = { ["foo"] = "bar" },
        };
        ProjectConversation conversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync(conversationOptions);

        //
        // Add items to an existing conversation to supplement the interaction state
        //
        string EXISTING_CONVERSATION_ID = conversation.Id;

        _ = await projectClient.OpenAI.Conversations.CreateProjectConversationItemsAsync(
            EXISTING_CONVERSATION_ID,
            [ResponseItem.CreateSystemMessageItem(inputTextContent: "Story theme to use: department of licensing.")]);
        //
        // Use the agent and conversation in a response
        //
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(AGENT_NAME);
        CreateResponseOptions responseOptions = new()
        {
            AgentConversationId = EXISTING_CONVERSATION_ID,
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("Tell me a one-line story."),
            },
        };

        List<ResponseItem> items = [];
        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        #endregion
        Console.WriteLine(response.GetOutputText());
        await openAIClient.GetConversationClient().DeleteConversationAsync(conversation.Id);
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
        AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        #region Snippet:ErrorHandling
        try
        {
            AgentVersion agent = await projectClient.Agents.GetAgentVersionAsync(
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
