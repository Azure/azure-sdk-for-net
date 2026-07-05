// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

public class Sample_StructuredOutput : ProjectsOpenAITestBase
{
    #region Snippet:Sample_Schema_StructuredOutput
    private static readonly BinaryData s_calendarSchema = BinaryData.FromObjectAsJson(
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
    #endregion

    [Test]
    [AsyncOnly]
    public async Task ConversationStructulatlOutputAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateClient_StructuredOutput
#if SNIPPET
        string RAW_FOUNDRY_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'FOUNDRY_MODEL_NAME'");
#else
        string RAW_FOUNDRY_PROJECT_ENDPOINT = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string MODEL_DEPLOYMENT = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(RAW_FOUNDRY_PROJECT_ENDPOINT), new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateAgent_StructuredOutput_Async
        var textOptions = new ResponseTextOptions()
        {
            TextFormat = ResponseTextFormat.CreateJsonSchemaFormat(
                jsonSchemaFormatName: "Calendar",
                jsonSchema: s_calendarSchema
            )
        };
        DeclarativeAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
        {
            Instructions = "You are a helpful assistant that extracts calendar event information from the input user messages," +
                           "and returns it in the desired structured output format.",
            TextOptions = textOptions
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition)
        );
        #endregion
        #region Snippet:Sample_CreateResponse_StructuredOutput_Async
        ProjectConversationCreationOptions options = new()
        {
            Items = { ResponseItem.CreateUserMessageItem("Alice and Bob are going to a science fair this Friday, November 7, 2025.") }
        };
        ProjectConversation conversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync(options);
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: agentVersion.Name, version: agentVersion.Version), defaultConversationId: conversation.Id);
        ResponseResult response = await responseClient.CreateResponseAsync(options: new());
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_CleanUp_StructuredOutput_Async
        await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().DeleteConversationAsync(conversation.Id);
        await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentName: "myAgent");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void ConversationStructulatlOutput()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        string RAW_FOUNDRY_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'FOUNDRY_PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'FOUNDRY_MODEL_NAME'");
#else
        string RAW_FOUNDRY_PROJECT_ENDPOINT = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string MODEL_DEPLOYMENT = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(RAW_FOUNDRY_PROJECT_ENDPOINT), new DefaultAzureCredential());
        #region Snippet:Sample_CreateAgent_StructuredOutput_Sync
        var textOptions = new ResponseTextOptions()
        {
            TextFormat = ResponseTextFormat.CreateJsonSchemaFormat(
                jsonSchemaFormatName: "Calendar",
                jsonSchema: s_calendarSchema
            )
        };
        DeclarativeAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
        {
            Instructions = "You are a helpful assistant that extracts calendar event information from the input user messages," +
                           "and returns it in the desired structured output format.",
            TextOptions = textOptions
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition)
        );
        #endregion
        #region Snippet:Sample_CreateResponse_StructuredOutput_Sync
        ProjectConversationCreationOptions options = new()
        {
            Items = { ResponseItem.CreateUserMessageItem("Alice and Bob are going to a science fair this Friday, November 7, 2025.") }
        };
        ProjectConversation conversation = projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversation(options);
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: agentVersion.Name, version: agentVersion.Version), defaultConversationId: conversation.Id);
        ResponseResult response = responseClient.CreateResponse(options: new());
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_CleanUp_StructuredOutput_Sync
        projectClient.ProjectOpenAIClient.GetProjectConversationsClient().DeleteConversation(conversation.Id);
        projectClient.AgentAdministrationClient.DeleteAgent(agentName: "myAgent");
        #endregion
    }

    public Sample_StructuredOutput(bool isAsync) : base(isAsync)
    {
    }
}
