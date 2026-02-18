// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

# region Snippet:Sample_AzureFunctionTool_AzureFunction
public class Sample_AzureFunction : ProjectsOpenAITestBase
{
    private static AzureFunctionTool GetFunctionTool(string storageQueueUri)
    {
        AzureFunctionDefinitionFunction functionDefinition = new(
            name: "foo",
            parameters: BinaryData.FromObjectAsJson(
                new
                {
                    Type = "object",
                    Properties = new
                    {
                        query = new
                        {
                            Type = "string",
                            Description = "The question to ask.",
                        }
                    }
                },
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
            )
        )
        {
            Description = "Get answers from the foo bot.",
        };
        return new AzureFunctionTool(
            new AzureFunctionDefinition(
                function: functionDefinition,
                inputBinding: new AzureFunctionBinding(
                    new AzureFunctionStorageQueue(queueServiceEndpoint: storageQueueUri, queueName: "azure-function-foo-input")),
                outputBinding: new AzureFunctionBinding(
                    new AzureFunctionStorageQueue(queueServiceEndpoint: storageQueueUri, queueName: "azure-function-tool-output"))
                )
            );
    }
    #endregion
    [Test]
    [AsyncOnly]
    public async Task AzureFunctionAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_AzureFunction
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var storageQueueUri = System.Environment.GetEnvironmentVariable("STORAGE_QUEUE_URI");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var storageQueueUri = TestEnvironment.STORAGE_QUEUE_URI;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateAgent_AzureFunction_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful support agent. Use the provided function any "
                + "time the prompt contains the string 'What would foo say?'. When you invoke "
                + "the function, ALWAYS specify the output queue uri parameter as "
                + $"'{storageQueueUri}/azure-function-tool-output'. Always responds with "
                + "\"Foo says\" and then the response from the tool.",
            Tools = { GetFunctionTool(storageQueueUri) },
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_AzureFunction_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("What is the most prevalent element in the universe? What would foo say?") },
        };
        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        #endregion

        #region Snippet:Sample_GetResponse_AzureFunction
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_AzureFunction_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AzureFunction()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var storageQueueUri = System.Environment.GetEnvironmentVariable("STORAGE_QUEUE_URI");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var storageQueueUri = TestEnvironment.STORAGE_QUEUE_URI;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_CreateAgent_AzureFunction_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful support agent. Use the provided function any "
                + "time the prompt contains the string 'What would foo say?'. When you invoke "
                + "the function, ALWAYS specify the output queue uri parameter as "
                + $"'{storageQueueUri}/azure-function-tool-output'. Always responds with "
                + "\"Foo says\" and then the response from the tool.",
            Tools = { GetFunctionTool(storageQueueUri) },
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_AzureFunction_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("What is the most prevalent element in the universe? What would foo say?") },
        };
        ResponseResult response = responseClient.CreateResponse(responseOptions);
        #endregion
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #region Snippet:Sample_Cleanup_AzureFunction_Sync
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_AzureFunction(bool isAsync) : base(isAsync)
    { }
}
