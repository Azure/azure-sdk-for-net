// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_Sharepoint : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task SharepointAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_Sharepoint
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var sharepointConnectionName = System.Environment.GetEnvironmentVariable("SHAREPOINT_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var sharepointConnectionName = TestEnvironment.SHAREPOINT_CONNECTION_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #endregion
        #region Snippet:Sample_CreateAgent_Sharepoint_Async
        AIProjectConnection sharepointConnection = await projectClient.Connections.GetConnectionAsync(sharepointConnectionName);
        SharePointGroundingToolOptions sharepointToolOption = new()
        {
            ProjectConnections = { new ToolProjectConnection(projectConnectionId: sharepointConnection.Id) }
        };
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = { new SharepointPreviewTool(sharepointToolOption), }
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_Sharepoint_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("What is Contoso whistleblower policy") },
        };
        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        #endregion

        #region Snippet:Sample_WaitForResponse_Sharepoint
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine($"{response.GetOutputText()}{GetFormattedAnnotation(response)}");
        #endregion

        #region Snippet:Sample_Cleanup_Sharepoint_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void Sharepoint()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var sharepointConnectionName = System.Environment.GetEnvironmentVariable("SHAREPOINT_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var sharepointConnectionName = TestEnvironment.SHAREPOINT_CONNECTION_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgent_Sharepoint_Sync
        AIProjectConnection sharepointConnection = projectClient.Connections.GetConnection(sharepointConnectionName);
        SharePointGroundingToolOptions sharepointToolOption = new()
        {
            ProjectConnections = { new ToolProjectConnection(projectConnectionId: sharepointConnection.Id) }
        };
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = { new SharepointPreviewTool(sharepointToolOption), }
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_Sharepoint_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("What is Contoso whistleblower policy"),
            },
        };
        ResponseResult response = responseClient.CreateResponse(responseOptions);
        #endregion

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine($"{response.GetOutputText()}{GetFormattedAnnotation(response)}");

        #region Snippet:Sample_Cleanup_Sharepoint_Sync
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    #region Snippet:Sample_FormatReference_Sharepoint
    private static string GetFormattedAnnotation(ResponseResult response)
    {
        foreach (ResponseItem item in response.OutputItems)
        {
            if (item is MessageResponseItem messageItem)
            {
                foreach (ResponseContentPart content in messageItem.Content)
                {
                    foreach (ResponseMessageAnnotation annotation in content.OutputTextAnnotations)
                    {
                        if (annotation is UriCitationMessageAnnotation uriAnnotation)
                        {
                            return $" [{uriAnnotation.Title}]({uriAnnotation.Uri})";
                        }
                    }
                }
            }
        }
        return "";
    }
    #endregion
    public Sample_Sharepoint(bool isAsync) : base(isAsync)
    { }
}
