// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

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
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #endregion
        #region Snippet:Sample_CreateAgent_OpenAPI_Async
        string filePath = GetFile();
        OpenApiFunctionDefinition toolDefinition = new(
            name: "get_weather",
            specificationBytes: BinaryData.FromBytes(File.ReadAllBytes(filePath)),
            authentication: new OpenAPIAnonymousAuthenticationDetails()
        );
        toolDefinition.Description = "Retrieve weather information for a location.";
        OpenAPITool openapiTool = new(toolDefinition);

        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = { openapiTool }
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_OpenAPI_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
        ResponseResult response = await responseClient.CreateResponseAsync(
                userInputText: "Use the OpenAPI tool to print out, what is the weather in Seattle, WA today."
            );
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_OpenAPI_Async
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void OpenAPI()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_CreateAgent_OpenAPI_Sync
        string filePath = GetFile();
        OpenApiFunctionDefinition toolDefinition = new(
            name: "get_weather",
            specificationBytes: BinaryData.FromBytes(File.ReadAllBytes(filePath)),
            authentication: new OpenAPIAnonymousAuthenticationDetails()
        );
        toolDefinition.Description = "Retrieve weather information for a location.";
        OpenAPITool openapiTool = new(toolDefinition);

        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = { openapiTool }
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_OpenAPI_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
        ResponseResult response = responseClient.CreateResponse(
                userInputText: "Use the OpenAPI tool to print out, what is the weather in Seattle, WA today."
            );
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_OpenAPI_Sync
        projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_OpenAPI(bool isAsync) : base(isAsync)
    { }
}
