// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

public class Sample_WebSearch : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task WebSearchAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_WebSearch
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #endregion
        #region Snippet:Sample_CreateAgent_WebSearch_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that can search the web",
            Tools = { ResponseTool.CreateWebSearchTool(userLocation: WebSearchToolLocation.CreateApproximateLocation(country: "GB", city: "London", region: "London")), }
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_WebSearch_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

        ResponseResult response = await responseClient.CreateResponseAsync("Show me the latest London Underground service updates");
        #endregion

        #region Snippet:Sample_WaitForResponse_WebSearch
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine($"{response.GetOutputText()} {GetFormattedAnnotation(response)}");
        #endregion

        #region Snippet:Sample_Cleanup_WebSearch_Async
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void WebSearchSync()
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

        #region Snippet:Sample_CreateAgent_WebSearch_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that can search the web",
            Tools = { ResponseTool.CreateWebSearchTool(userLocation: WebSearchToolLocation.CreateApproximateLocation(country: "GB", city: "London", region: "London")), }
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_WebSearch_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

        ResponseResult response = responseClient.CreateResponse("Show me the latest London Underground service updates");
        #endregion

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine($"{response.GetOutputText()} {GetFormattedAnnotation(response)}");

        #region Snippet:Sample_Cleanup_WebSearch_Sync
        projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    #region Snippet:Sample_FormatReference_WebSearch
    private static string GetFormattedAnnotation(ResponseResult results)
    {
        StringBuilder references = new();
        foreach (ResponseItem item in results.OutputItems)
        {
            if (item is MessageResponseItem messageItem)
            {
                foreach (ResponseContentPart content in messageItem.Content)
                {
                    foreach (ResponseMessageAnnotation annotation in content.OutputTextAnnotations)
                    {
                        if (annotation is UriCitationMessageAnnotation uriAnnotation)
                        {
                            references.Append($"[{uriAnnotation.Title}]({uriAnnotation.Uri}),");
                        }
                    }
                }
            }
        }
        if (references.Length > 0)
        {
            // Remove the last comma.
            references.Remove(references.Length - 1, 1);
        }
        return references.ToString();
    }
    #endregion

    public Sample_WebSearch(bool isAsync) : base(isAsync)
    { }
}
