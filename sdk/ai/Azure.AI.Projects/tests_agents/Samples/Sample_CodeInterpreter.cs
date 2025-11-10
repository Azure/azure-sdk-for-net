// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using Azure.AI.Projects.OpenAI;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.Tests.Samples;

public class Sample_CodeInterpreter : AgentsTestBase
{
    [Test]
    [AsyncOnly]
    public async Task CodeInterpreterAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_CodeInterpreter
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateAgent_CodeInterpreter_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a personal math tutor. When asked a math question, write and run code using the python tool to answer the question.",
            Tools = {
                ResponseTool.CreateCodeInterpreterTool(
                    new CodeInterpreterToolContainer(
                        CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])
                    )
                ),
            }
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_CodeInterpreter_Async
        OpenAIResponseClient responseClient = projectClient.OpenAI.GetOpenAIResponseClient(modelDeploymentName);
        ResponseCreationOptions responseOptions = new();
        responseOptions.Agent = agentVersion;

        ResponseItem request = ResponseItem.CreateUserMessageItem("I need to solve the equation sin(x) + x^2 = 42");
        OpenAIResponse response = await responseClient.CreateResponseAsync(
            [request],
            responseOptions);
        #endregion

        #region Snippet:Sample_WaitForResponse_CodeInterpreter_Async
        List<ResponseItem> updateItems = [request];
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            response = await responseClient.GetResponseAsync(responseId: response.Id);
        }
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_CodeInterpreter_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void CodeInterpreterSync()
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

        #region Snippet:Sample_CreateAgent_CodeInterpreter_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent that can help fetch data from files you know about.",
            Tools = {
                ResponseTool.CreateCodeInterpreterTool(
                    new CodeInterpreterToolContainer(
                        CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration(
                            fileIds: []
                        )
                    )
                ),
            }
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_CodeInterpreter_Sync
        OpenAIResponseClient responseClient = projectClient.OpenAI.GetOpenAIResponseClient(modelDeploymentName);
        ResponseCreationOptions responseOptions = new();
        responseOptions.Agent = agentVersion;

        ResponseItem request = ResponseItem.CreateUserMessageItem("I need to solve the equation sin(x) + x^2 = 42");
        OpenAIResponse response = responseClient.CreateResponse(
            [request],
            responseOptions);
        #endregion

        #region Snippet:Sample_WaitForResponse_CodeInterpreter_Sync
        List<ResponseItem> updateItems = [request];
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            response = responseClient.GetResponse(responseId: response.Id);
        }
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_CodeInterpreter_Sync
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_CodeInterpreter(bool isAsync) : base(isAsync)
    { }
}
