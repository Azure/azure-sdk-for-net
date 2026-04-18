// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
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
    private static HostedAgentDefinition GetAgentDefinition(string dockerImage)
    {
        HostedAgentDefinition agentDefinition = new(
            versions: [new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0")],
            cpu: "0.5",
            memory: "1Gi"
        )
        {
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
        var hostedAgentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var hostedAgentName = TestEnvironment.HOSTED_AGENT_NAME;
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage
        );
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
            agentName: hostedAgentName,
            options: creationOptions);
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            agentVersion = await agentsClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        if (agentVersion.Status != AgentVersionStatus.Active)
        {
            throw new InvalidOperationException($"Agent deployment failes, status: {agentVersion.Status}.");
        }
        Console.WriteLine($"Deployed hosted agent {agentVersion.Name}, version {agentVersion.Version}.");
        // Do not do this occasionally.
        await agentsClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
    }

    [Test]
    [SyncOnly]
    public void HostedAgentCreate()
    {
#if SNIPPET
        var hostedAgentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var hostedAgentName = TestEnvironment.HOSTED_AGENT_NAME;
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);

        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage
        );
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agentVersion = agentsClient.CreateAgentVersion(
            agentName: hostedAgentName,
            options: creationOptions);
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            agentVersion = agentsClient.GetAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        if (agentVersion.Status != AgentVersionStatus.Active)
        {
            throw new InvalidOperationException($"Agent deployment failes, status: {agentVersion.Status}.");
        }
        Console.WriteLine($"Deployed hosted agent {agentVersion.Name}, version {agentVersion.Version}.");
        // Do not do this occasionally.
        agentsClient.DeleteAgent(agentName: agentVersion.Name);
    }

    public Sample_HostedAgent(bool isAsync) : base(isAsync)
    { }
}
