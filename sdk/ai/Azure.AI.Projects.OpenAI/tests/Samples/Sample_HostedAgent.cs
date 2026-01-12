// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_HostedAgent : ProjectsOpenAITestBase
{
    #region Snippet:Sample_ImageBasedHostedAgentDefinition_HostedAgent
    private static  ImageBasedHostedAgentDefinition GetAgentDefinition(string dockerImage, string modelDeploymentName, string accountId, string applicationInsightConnectionString, string projectEndpoint)
    {
        ImageBasedHostedAgentDefinition agentDefinition = new(
            containerProtocolVersions: [new ProtocolVersionRecord(AgentCommunicationMethod.ActivityProtocol, "v1")],
            cpu: "1",
            memory: "2Gi",
            image: dockerImage
        )
        {
            EnvironmentVariables = {
                { "AZURE_OPENAI_ENDPOINT", $"https://{accountId}.cognitiveservices.azure.com/" },
                { "AZURE_OPENAI_CHAT_DEPLOYMENT_NAME", modelDeploymentName },
                // Optional variables, used for logging
                { "APPLICATIONINSIGHTS_CONNECTION_STRING", applicationInsightConnectionString },
                { "AGENT_PROJECT_RESOURCE_ID", projectEndpoint },
            }
        };
        return agentDefinition;
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task HostedAgentCreateAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_HostedAgent
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var applicationInsightConnectionString = System.Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var applicationInsightConnectionString = TestEnvironment.APPLICATIONINSIGHTS_CONNECTION_STRING;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        string[] pathParts = uriEndpoint.AbsolutePath.Split('/');
        string projectName = pathParts[pathParts.Length - 1];
        string accountId = uriEndpoint.Authority.Substring(0, uriEndpoint.Authority.IndexOf('.'));
        AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateAgent_HostedAgent_Async
        ImageBasedHostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage,
            modelDeploymentName: modelDeploymentName,
            accountId: accountId,
            applicationInsightConnectionString: projectName,
            projectEndpoint: projectEndpoint
        );
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myHostedAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:WriteDeploymentInstructions_HostedAgent
        Console.WriteLine("The agent has been created, to start it please run the next commands in the terminal:");
        Console.WriteLine("az login");
        Console.WriteLine($"az cognitiveservices agent start --account-name {accountId} --project-name {projectName} --name {agentVersion.Name} --agent-version {agentVersion.Version}");
        Console.WriteLine("Wait while the Agent will arrive to the \"Running\" state in the Microsoft Foundry portal and use GetAgentVersion call to use it.");
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task HostedAgentUseAsync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var applicationInsightConnectionString = System.Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var applicationInsightConnectionString = TestEnvironment.APPLICATIONINSIGHTS_CONNECTION_STRING;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        string[] pathParts = uriEndpoint.AbsolutePath.Split('/');
        string projectName = pathParts[pathParts.Length - 1];
        string accountId = uriEndpoint.Authority.Substring(0, uriEndpoint.Authority.IndexOf('.'));
        AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_GetAgent_HostedAgent_Async
        AgentVersion agentVersion = await projectClient.Agents.GetAgentVersionAsync(
            agentName: "myHostedAgent", agentVersion: "1");
        #endregion
        #region Snippet:Sample_CreateResponse_HostedAgent_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        ResponseResult response = await responseClient.CreateResponseAsync("Describe the of Contoso VR glasses release process.");
        #endregion

        #region Snippet:Sample_WaitForResponse_HostedAgent
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:WriteUnDeploymentInstructions_HostedAgent
        Console.WriteLine("The agent cannot be removed, before the active deployment associated with it is deleted.");
        Console.WriteLine("Please run the next command in the terminal to delete the deployment.");
        Console.WriteLine($"az cognitiveservices agent delete-deployment --account-name {accountId} --project-name {projectName} --name {agentVersion.Name} --agent-version {agentVersion.Version}");
        Console.WriteLine($"az cognitiveservices agent delete --account-name {accountId} --project-name {projectName} --name {agentVersion.Name}");
        Console.WriteLine("Monitor the Agent deletion on Microsoft Foundry portal.");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void HostedAgentCreate()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var applicationInsightConnectionString = System.Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var applicationInsightConnectionString = TestEnvironment.APPLICATIONINSIGHTS_CONNECTION_STRING;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        string[] pathParts = uriEndpoint.AbsolutePath.Split('/');
        string projectName = pathParts[pathParts.Length - 1];
        string accountId = uriEndpoint.Authority.Substring(0, uriEndpoint.Authority.IndexOf('.'));
        AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgent_HostedAgent_Sync
        ImageBasedHostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage,
            modelDeploymentName: modelDeploymentName,
            accountId: accountId,
            applicationInsightConnectionString: projectName,
            projectEndpoint: projectEndpoint
        );
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myHostedAgent",
            options: new(agentDefinition));
        #endregion
        Console.WriteLine("The agent has been created, to start it please run the next commands in the terminal:");
        Console.WriteLine("az login");
        Console.WriteLine($"az cognitiveservices agent start --account-name {accountId} --project-name {projectName} --name {agentVersion.Name} --agent-version {agentVersion.Version}");
        Console.WriteLine("Wait while the Agent will arrive to the \"Running\" state in the Microsoft Foundry portal and use GetAgentVersion call to use it.");
    }

    [Test]
    [SyncOnly]
    public void HostedAgentUse()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var applicationInsightConnectionString = System.Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var applicationInsightConnectionString = TestEnvironment.APPLICATIONINSIGHTS_CONNECTION_STRING;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        string[] pathParts = uriEndpoint.AbsolutePath.Split('/');
        string projectName = pathParts[pathParts.Length - 1];
        string accountId = uriEndpoint.Authority.Substring(0, uriEndpoint.Authority.IndexOf('.'));
        AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_GetAgent_HostedAgent_Sync
        AgentVersion agentVersion = projectClient.Agents.GetAgentVersion(
            agentName: "myHostedAgent", agentVersion: "1");
        #endregion
        #region Snippet:Sample_CreateResponse_HostedAgent_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        ResponseResult response = responseClient.CreateResponse("Describe the of Contoso VR glasses release process.");
        #endregion

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        Console.WriteLine("The agent cannot be removed, before the active deployment associated with it is deleted.");
        Console.WriteLine("Please run the next command in the terminal to delete the deployment.");
        Console.WriteLine($"az cognitiveservices agent delete-deployment --account-name {accountId} --project-name {projectName} --name {agentVersion.Name} --agent-version {agentVersion.Version}");
        Console.WriteLine($"az cognitiveservices agent delete --account-name {accountId} --project-name {projectName} --name {agentVersion.Name}");
        Console.WriteLine("Monitor the Agent deletion on Microsoft Foundry portal.");
    }

    public Sample_HostedAgent(bool isAsync) : base(isAsync)
    { }
}
