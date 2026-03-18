// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests.Samples;
# pragma warning disable AAIP001

#region Snippet:Sample_Agents_ExperimentalHeader
internal class FeaturePolicy(string feature) : PipelinePolicy
{
    private const string _FEATURE_HEADER = "Foundry-Features";

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_FEATURE_HEADER, feature);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_FEATURE_HEADER, feature);
        await ProcessNextAsync(message, pipeline, currentIndex);
    }
}
#endregion
public class Sample_HostedAgent : SamplesBase
{
    #region Snippet:Sample_Agents_ImageBasedHostedAgentDefinition_HostedAgent
    private static  HostedAgentDefinition GetAgentDefinition(string dockerImage, string modelDeploymentName, string accountId, string applicationInsightConnectionString, string projectEndpoint)
    {
        HostedAgentDefinition agentDefinition = new(
            versions: [new ProtocolVersionRecord(AgentProtocol.ActivityProtocol, "v1")],
            cpu: "1",
            memory: "2Gi"
        )
        {
            EnvironmentVariables = {
                { "AZURE_OPENAI_ENDPOINT", $"https://{accountId}.cognitiveservices.azure.com/" },
                { "AZURE_OPENAI_CHAT_DEPLOYMENT_NAME", modelDeploymentName },
                // Optional variables, used for logging
                { "APPLICATIONINSIGHTS_CONNECTION_STRING", applicationInsightConnectionString },
                { "AGENT_PROJECT_RESOURCE_ID", projectEndpoint },
            },
            Image = dockerImage,
        };
        return agentDefinition;
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task HostedAgentCreateAsync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var applicationInsightConnectionString = System.Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var applicationInsightConnectionString = TestEnvironment.APPLICATIONINSIGHTS_CONNECTION_STRING;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        string[] pathParts = uriEndpoint.AbsolutePath.Split('/');
        string projectName = pathParts[pathParts.Length - 1];
        string accountId = uriEndpoint.Authority.Substring(0, uriEndpoint.Authority.IndexOf('.'));
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);

        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage,
            modelDeploymentName: modelDeploymentName,
            accountId: accountId,
            applicationInsightConnectionString: projectName,
            projectEndpoint: projectEndpoint
        );
        AgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
            agentName: "myHostedAgent",
            options: new(agentDefinition));
        await agentsClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
    }

    [Test]
    [SyncOnly]
    public void HostedAgentCreate()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var applicationInsightConnectionString = System.Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var applicationInsightConnectionString = TestEnvironment.APPLICATIONINSIGHTS_CONNECTION_STRING;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        string[] pathParts = uriEndpoint.AbsolutePath.Split('/');
        string projectName = pathParts[pathParts.Length - 1];
        string accountId = uriEndpoint.Authority.Substring(0, uriEndpoint.Authority.IndexOf('.'));
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);

        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage,
            modelDeploymentName: modelDeploymentName,
            accountId: accountId,
            applicationInsightConnectionString: projectName,
            projectEndpoint: projectEndpoint
        );
        AgentVersion agentVersion = agentsClient.CreateAgentVersion(
            agentName: "myHostedAgent",
            options: new(agentDefinition));
        agentsClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
    }

    public Sample_HostedAgent(bool isAsync) : base(isAsync)
    { }
}
