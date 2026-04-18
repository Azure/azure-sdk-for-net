// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

# pragma warning disable AAIP001
namespace Azure.AI.Projects.Agents.Tests.Samples;

public class Sample_HostedAgentLogStreaming : SamplesBase
{
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

    [Test]
    [AsyncOnly]
    public async Task HostedAgentLogsAsync()
    {
#if SNIPPET
        var hostedAgentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var hostedAgentName = TestEnvironment.HOSTED_AGENT_NAME;
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
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
        Console.WriteLine($"Deployed hosted agent {agentVersion.Name}, version {agentVersion.Version}.");
        #region Snippet:Sample_Agents_StreamLogs_HostedAgentLogStreaming
        ProjectAgentSession session = await agentsClient.CreateSessionAsync(
            agentName: agentVersion.Name,
            isolationKey: "key_1",
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        SessionLogEvent logEvent = await agentsClient.GetSessionLogStreamAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version, sessionId: session.AgentSessionId);
        Console.WriteLine(logEvent.Data);
        #endregion
        // Do not do this occasionally.
        await agentsClient.DeleteAgentAsync(agentName: agentVersion.Name);
    }

    [Test]
    [SyncOnly]
    public void HostedAgentLogsSync()
    {
#if SNIPPET
        var hostedAgentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var hostedAgentName = TestEnvironment.HOSTED_AGENT_NAME;
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
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
        Console.WriteLine($"Deployed hosted agent {agentVersion.Name}, version {agentVersion.Version}.");
        ProjectAgentSession session = agentsClient.CreateSession(
            agentName: agentVersion.Name,
            isolationKey: "key_1",
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        SessionLogEvent logEvent = agentsClient.GetSessionLogStream(agentName: agentVersion.Name, agentVersion: agentVersion.Version, sessionId: session.AgentSessionId);
        Console.WriteLine(logEvent.Data);
        // Do not do this occasionally.
        agentsClient.DeleteAgent(agentName: agentVersion.Name);
    }

    public Sample_HostedAgentLogStreaming(bool isAsync) : base(isAsync)
    { }
}
