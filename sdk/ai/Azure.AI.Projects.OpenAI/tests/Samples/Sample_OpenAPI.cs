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

public class Sample_OpenAPI : ProjectsOpenAITestBase
{
    #region Snippet:Sample_GetFile_OpenAPI
    private static string GetFile([CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine(dirName, "Assets", "weather_openapi.json");
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task OpenAPIAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateProjectClient_OpenAPI
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #endregion
        #region Snippet:Sample_CreateAgent_OpenAPI_Async
        string filePath = GetFile();
        OpenAPIFunctionDefinition toolDefinition = new(
            name: "get_weather",
            spec: BinaryData.FromBytes(BinaryData.FromBytes(File.ReadAllBytes(filePath))),
            auth: new OpenAPIAnonymousAuthenticationDetails()
        );
        toolDefinition.Description = "Retrieve weather information for a location.";
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
        #region Snippet:Sample_CreateResponse_OpenAPI_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        ResponseResult response = await responseClient.CreateResponseAsync(
                userInputText: "Use the OpenAPI tool to print out, what is the weather in Seattle, WA today."
            );
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_OpenAPI_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void OpenAPI()
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
        #region Snippet:Sample_CreateAgent_OpenAPI_Sync
        string filePath = GetFile();
        OpenAPIFunctionDefinition toolDefinition = new(
            name: "get_weather",
            spec: BinaryData.FromBytes(BinaryData.FromBytes(File.ReadAllBytes(filePath))),
            auth: new OpenAPIAnonymousAuthenticationDetails()
        );
        toolDefinition.Description = "Retrieve weather information for a location.";
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
        #region Snippet:Sample_CreateResponse_OpenAPI_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        ResponseResult response = responseClient.CreateResponse(
                userInputText: "Use the OpenAPI tool to print out, what is the weather in Seattle, WA today."
            );
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_OpenAPI_Sync
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_OpenAPI(bool isAsync) : base(isAsync)
    { }
}
