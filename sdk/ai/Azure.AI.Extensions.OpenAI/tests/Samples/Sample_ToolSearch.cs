// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

public class Sample_ToolSearch : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task ToolSearchAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_ToolSearch
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateAgent_ToolSearch_Async
        ToolSearchTool searchTool = new()
        {
            Execution = ToolSearchExecutionType.Server
        };
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = {
                searchTool,
                ResponseTool.CreateCodeInterpreterTool(
                    new CodeInterpreterToolContainer(
                        CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])
                    )
                ),
            }
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_ToolSearch_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            //ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("List all available tools.") },
        };
        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        #endregion

        #region Snippet:Sample_WaitForResponse_ToolSearch
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        foreach (ResponseItem item in response.OutputItems)
        {
            if (item.AsAgentResponseItem() is OutputItemToolSearchOutput outputToolSearch)
            {
                Console.WriteLine($"The tool search return status: {outputToolSearch.Status}. Tools returned:");
                foreach (ResponsesTool tool in outputToolSearch.Tools)
                {
                    Console.WriteLine($"    {tool.GetType()}");
                }
            }
        }
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_ToolSearch_Async
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_ToolSearch(bool isAsync) : base(isAsync)
    { }
}
