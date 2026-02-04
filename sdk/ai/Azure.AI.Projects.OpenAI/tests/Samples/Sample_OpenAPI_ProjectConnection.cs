// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_OpenAPIProjectConnection : ProjectsOpenAITestBase
{
    #region Snippet:Sample_GetFile_OpenAPIProjectConnection
    private static string GetFile([CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine(dirName, "Assets", "tripadvisor_openapi.json");
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task OpenAPIProjectConnectionAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateProjectClient_OpenAPIProjectConnection
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #endregion
        #region Snippet:Sample_CreateAgent_OpenAPIProjectConnection_Async
        string filePath = GetFile();
        AIProjectConnection tripadvisorConnection = await projectClient.Connections.GetConnectionAsync("tripadvisor");
        OpenAPIFunctionDefinition toolDefinition = new(
            name: "tripadvisor",
            spec: BinaryData.FromBytes(BinaryData.FromBytes(File.ReadAllBytes(filePath))),
            auth:  new OpenAPIProjectConnectionAuthenticationDetails(new OpenAPIProjectConnectionSecurityScheme(
                projectConnectionId: tripadvisorConnection.Id
            ))
        );
        toolDefinition.Description = "Trip Advisor API to get travel information.";
        OpenAPITool openapiTool = new(toolDefinition);

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = {openapiTool}
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_OpenAPIProjectConnection_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("Recommend me 5 top hotels in paris, France."),
            }
        };
        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_OpenAPIProjectConnection_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void OpenAPIProjectConnection()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgent_OpenAPIProjectConnection_Sync
        string filePath = GetFile();
        AIProjectConnection tripadvisorConnection = projectClient.Connections.GetConnection("tripadvisor");
        OpenAPIFunctionDefinition toolDefinition = new(
            name: "tripadvisor",
            spec: BinaryData.FromBytes(BinaryData.FromBytes(File.ReadAllBytes(filePath))),
            auth: new OpenAPIProjectConnectionAuthenticationDetails(new OpenAPIProjectConnectionSecurityScheme(
                projectConnectionId: tripadvisorConnection.Id
            ))
        );
        toolDefinition.Description = "Trip Advisor API to get travel information.";
        OpenAPITool openapiTool = new(toolDefinition);

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = { openapiTool }
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_OpenAPIProjectConnection_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("Recommend me 5 top hotels in paris, France."),
            },
        };
        ResponseResult response = responseClient.CreateResponse(responseOptions);
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_OpenAPIProjectConnection_Sync
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_OpenAPIProjectConnection(bool isAsync) : base(isAsync)
    { }
}
