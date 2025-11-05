// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Agents.Tests.Samples;

[Ignore("Samples represented as tests only for validation of compilation.")]
public class SingleFileCompilationInputs : AgentsTestBase
{
    public SingleFileCompilationInputs(bool isAsync) : base(isAsync)
    { }

    public async Task PromptAgentCreate()
    {
        #region Snippet:SingleFileSamples_PromptAgentCreate
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
        string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");

        AgentsClient agentsClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());

        AgentDefinition agentDefinition = new PromptAgentDefinition(MODEL_DEPLOYMENT)
        {
            Instructions = "You are a foo bar agent. In EVERY response you give, ALWAYS include both `foo` and `bar` strings somewhere in the response.",
        };

        AgentVersion newAgentVersion = await agentsClient.CreateAgentVersionAsync(AGENT_NAME, agentDefinition);
        Console.WriteLine($"Created new agent version: {newAgentVersion.Name}");
        #endregion
    }

    public async Task PromptAgentRun()
    {
        #region Snippet:SingleFileSamples_PromptAgentRun
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
        string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");

        AgentsClient agentsClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);

        ResponseCreationOptions responseCreationOptions = new();
        responseCreationOptions.SetAgentReference(AGENT_NAME);

        // Optionally, use a conversation to automatically maintain state between calls.
        AgentConversation conversation = await agentsClient.GetConversationClient().CreateConversationAsync();
        responseCreationOptions.SetConversationReference(conversation);

        List<ResponseItem> items = [ResponseItem.CreateUserMessageItem("Tell me a one-line story.")];
        OpenAIResponse response = await responseClient.CreateResponseAsync(items, responseCreationOptions);

        Console.WriteLine(response.GetOutputText());
        #endregion
    }
    public async Task PromptAgentRunStreaming()
    {
        #region Snippet:SingleFileSamples_PromptAgentRunStreaming
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
        string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");

        AgentsClient agentsClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);

        ResponseCreationOptions responseCreationOptions = new();
        responseCreationOptions.SetAgentReference(AGENT_NAME);

        // Optionally, use a conversation to automatically maintain state between calls.
        AgentConversation conversation = await agentsClient.GetConversationClient().CreateConversationAsync();
        responseCreationOptions.SetConversationReference(conversation);

        List<ResponseItem> items = [ResponseItem.CreateUserMessageItem("Tell me a one-line story.")];

        await foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreamingAsync(items, responseCreationOptions))
        {
            if (update is StreamingResponseOutputItemAddedUpdate itemAddedUpdate
                && itemAddedUpdate.Item is MessageResponseItem addedMessageItem)
            {
                Console.Write($"[{addedMessageItem.Role}]: ");
            }
            else if (update is StreamingResponseOutputTextDeltaUpdate textDeltaUpdate)
            {
                Console.Write(textDeltaUpdate.Delta);
            }
            else if (update is StreamingResponseOutputTextDoneUpdate)
            {
                Console.WriteLine();
            }
        }
        #endregion
    }

    public async Task PromptAgentEndToEnd()
    {
        #region Snippet:SingleFileSamples_PromptAgentEndToEnd
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
        string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");

        AgentsClient agentsClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);

        //
        // Create an agent version for a new prompt agent
        //

        AgentDefinition agentDefinition = new PromptAgentDefinition(MODEL_DEPLOYMENT)
        {
            Instructions = "You are a foo bar agent. In EVERY response you give, ALWAYS include both `foo` and `bar` strings somewhere in the response.",
        };
        AgentVersion newAgentVersion = await agentsClient.CreateAgentVersionAsync(AGENT_NAME, agentDefinition);

        //
        // Create a conversation to maintain state between calls
        //

        AgentConversationCreationOptions conversationOptions = new()
        {
            Items = { ResponseItem.CreateSystemMessageItem("Your preferred genre of story today is: horror.") },
            Metadata = { ["foo"] = "bar" },
        };
        AgentConversation conversation = await agentsClient.GetConversationClient().CreateConversationAsync(conversationOptions);

        //
        // Add items to an existing conversation to supplement the interaction state
        //
        string EXISTING_CONVERSATION_ID = conversation.Id;

        _ = await agentsClient.GetConversationClient().CreateConversationItemsAsync(
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

    public async Task PromptAgentWithToolsCreate()
    {
        #region Snippet:SingleFileSamples_PromptAgentWithToolsCreate
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
        string AGENT_NAME = "TestPiratePromptAgentWithToolsFromDotnetSamples";

        AgentsClient client = new(
            new Uri(RAW_PROJECT_ENDPOINT),
            new AzureCliCredential());

        AgentDefinition agentDefinition = new PromptAgentDefinition(MODEL_DEPLOYMENT)
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

        AgentVersion newAgentVersion = await client.CreateAgentVersionAsync(
            AGENT_NAME,
            agentDefinition,
            new AgentVersionCreationOptions()
            {
                Metadata =
                {
            ["can_delete_this"] = "true"
                }
            });

        Console.WriteLine($"Created new agent version: {newAgentVersion.Name}");
        #endregion
    }

    public async Task PromptAgentWithToolsRun()
    {
        #region Snippet:SingleFileSamples_PromptAgentWithToolsRun
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
        string AGENT_NAME = "TestPiratePromptAgentWithToolsFromDotnetSamples";

        AgentsClient agentsClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);

        ResponseCreationOptions responseCreationOptions = new();
        responseCreationOptions.SetAgentReference(AGENT_NAME);

        // Optionally, use a conversation to automatically maintain state between calls.
        bool useConversation = true;

        if (useConversation)
        {
            AgentConversation conversation = await agentsClient.GetConversationClient().CreateConversationAsync();
            responseCreationOptions.SetConversationReference(conversation);
        }

        string userInput = "Hello, agent! Greet me by name.";
        Console.WriteLine($" >>> [User]: {userInput}");
        OpenAIResponse response = await responseClient.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem(userInput)],
            responseCreationOptions);

        if (response.OutputItems.Count > 0 && response.OutputItems.Last() is FunctionCallResponseItem functionCall)
        {
            Console.WriteLine($" <<< [Function Called]: {functionCall.FunctionName} (call id: {functionCall.CallId})");
            if (!useConversation)
            {
                Console.WriteLine($" | Setting previous_response_id (no conversation use): {response.Id}");
                responseCreationOptions.PreviousResponseId = response.Id;
            }
            Console.WriteLine($" >>> [Function Output (reply)]: Ishmael");
            response = await responseClient.CreateResponseAsync(
                [ResponseItem.CreateFunctionCallOutputItem(functionCall.CallId, "Ishmael")],
                responseCreationOptions);
        }

        Console.WriteLine($" <<< [Output]: {response.GetOutputText()}");
        #endregion
    }

    public async Task ContainerAgentCreate()
    {
        #region Snippet:SingleFileSamples_ContainerAgentCreate
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");
        string AGENT_IMAGE_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_IMAGE_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_IMAGE_NAME'");

        AgentsClient agentsClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());

        AgentDefinition agentDefinition = new ImageBasedHostedAgentDefinition(
            containerProtocolVersions: [new(AgentCommunicationMethod.Responses, "v1")],
            cpu: "1",
            memory: "2Gi",
            image: AGENT_IMAGE_NAME);

        AgentVersion newAgentVersion = await agentsClient.CreateAgentVersionAsync(AGENT_NAME, agentDefinition);
        Console.WriteLine($"Created new agent version: {newAgentVersion.Name}");
        #endregion
    }

    public async Task WorkflowAgentCreate()
    {
        #region Snippet:SingleFileSamples_WorkflowAgentCreate
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");

        AgentsClient agentsClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());

        AgentDefinition agentDefinition = WorkflowAgentDefinition.FromYaml("""
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
            """);

        AgentVersion newAgentVersion = await agentsClient.CreateAgentVersionAsync(AGENT_NAME, agentDefinition);
        Console.WriteLine($"Created new agent version: {newAgentVersion.Name}");
        #endregion
    }

    public async Task WorkflowAgentRunStreaming()
    {
        #region Snippet:SingleFileSamples_WorkflowAgentRunStreaming
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
        string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");

        AgentsClient agentsClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);

        ResponseCreationOptions responseCreationOptions = new();
        responseCreationOptions.SetAgentReference(AGENT_NAME);

        // Optionally, use a conversation to automatically maintain state between calls.
        AgentConversation conversation = await agentsClient.GetConversationClient().CreateConversationAsync();
        responseCreationOptions.SetConversationReference(conversation);

        List<ResponseItem> items = [ResponseItem.CreateUserMessageItem("Let's go!")];

        await foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreamingAsync(items, responseCreationOptions))
        {
            if (update is StreamingResponseOutputItemAddedUpdate itemAddedUpdate
                && itemAddedUpdate.Item.AsAgentResponseItem() is AgentWorkflowActionResponseItem newWorkflowActionItem)
            {
                Console.WriteLine($"WORKFLOW ITEM ADDED: {newWorkflowActionItem.ActionId} (previous: {newWorkflowActionItem.PreviousActionId}) -- {newWorkflowActionItem.Status}");
            }
            else if (update is StreamingResponseOutputItemDoneUpdate itemDoneUpdate
                && itemDoneUpdate.Item.AsAgentResponseItem() is AgentWorkflowActionResponseItem finishedWorkflowActionItem)
            {
                Console.WriteLine($"WORKFLOW ITEM DONE: {finishedWorkflowActionItem.ActionId} (previous: {finishedWorkflowActionItem.PreviousActionId}) -- {finishedWorkflowActionItem.Status}");
            }
            else if (update is StreamingResponseOutputTextDeltaUpdate textDeltaUpdate)
            {
                Console.Write(textDeltaUpdate.Delta);
            }
            else if (update is StreamingResponseOutputTextDoneUpdate)
            {
                Console.WriteLine();
            }
        }
        #endregion
    }
}
