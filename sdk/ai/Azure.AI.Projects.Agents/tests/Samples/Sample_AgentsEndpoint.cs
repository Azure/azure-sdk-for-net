// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using NUnit.Framework;

#pragma warning disable AAIP001
namespace Azure.AI.Projects.Agents.Tests.Samples;

public class Sample_AgentsEndpoint : SamplesBase
{
    private static void DeleteSkillMaybe(ProjectAgentSkills client, string name)
    {
        try
        {
            client.DeleteSkill(name);
        }
        catch { }
    }

    [Test]
    [AsyncOnly]
    public async Task AgentsEndpointAsync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var hostedAgentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        var containerImage = System.Environment.GetEnvironmentVariable("FOUNDRY_AGENT_CONTAINER_IMAGE");
        var hostedAgentVersion = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_VERSION");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var hostedAgentName = TestEnvironment.HOSTED_AGENT_NAME;
        var containerImage = TestEnvironment.FOUNDRY_AGENT_CONTAINER_IMAGE;
        var hostedAgentVersion = TestEnvironment.HOSTED_AGENT_VERSION;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview,AgentEndpoints=V1Preview,Skills=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        ProjectAgentSkills skillsClient = agentsClient.GetAgentSkills();
        DeleteSkillMaybe(skillsClient, "simpleSkill");

        #region Snippet:Sample_GetAgentAndCreateSession_AgentsEndpoint_Async
        ProjectsAgentVersion agentVersion = await agentsClient.GetAgentVersionAsync(
            agentName: hostedAgentName,
            agentVersion: hostedAgentVersion);
        Console.WriteLine($"Retrieved agent {agentVersion.Name}, v. {agentVersion.Version}");
        #endregion

        #region Snippet:Sample_CreateSkill_AgentsEndpoint_Async
        AgentsSkill simpleSkill = await skillsClient.CreateSkillAsync(name: "simpleSkill", description: "Calculates the sum of two numbers.", instructions: """
            To calculate the sum  run
            bash:
            echo $((<first> + <second>))
            powershell:
            (<first> + <second>)
            Replace <first> and <second> by the actual summation arguments.
            """);
        #endregion

        #region Snippet:Sample_CreateEndpoint_AgentsEndpoint_Async
        AgentEndpoint config = new()
        {
            VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 100)]),
            Protocols = {AgentEndpointProtocol.Responses}
        };
        AgentCard card = new(version: "1", [new AgentCardSkill(id: simpleSkill.SkillId, name: SKILL)]);
        PatchAgentOptions patchOptions = new()
        {
            AgentEndpoint = config,
            AgentCard = card
        };
        ProjectsAgentRecord patchedRecord = await agentsClient.PatchAgentObjectAsync(
            agentName: hostedAgentName,
            patchAgentOptions: patchOptions);
        Console.WriteLine($"The Agent {patchedRecord.Name} was patched.");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AgentsEndpointSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var hostedAgentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        var containerImage = System.Environment.GetEnvironmentVariable("FOUNDRY_AGENT_CONTAINER_IMAGE");
        var hostedAgentVersion = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_VERSION");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var hostedAgentName = TestEnvironment.HOSTED_AGENT_NAME;
        var containerImage = TestEnvironment.FOUNDRY_AGENT_CONTAINER_IMAGE;
        var hostedAgentVersion = TestEnvironment.HOSTED_AGENT_VERSION;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview,AgentEndpoints=V1Preview,Skills=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        ProjectAgentSkills skillsClient = agentsClient.GetAgentSkills();
        DeleteSkillMaybe(skillsClient, "simpleSkill");

        ProjectsAgentVersion agentVersion = agentsClient.GetAgentVersion(
            agentName: hostedAgentName,
            agentVersion: hostedAgentVersion);
        Console.WriteLine($"Retrieved agent {agentVersion.Name}, v. {agentVersion.Version}");

        AgentsSkill simpleSkill = skillsClient.CreateSkill(name: "simpleSkill", description: "Calculates the sum of two numbers.", instructions: """
            To calculate the sum  run
            bash:
            echo $((<first> + <second>))
            powershell:
            (<first> + <second>)
            Replace <first> and <second> by the actual summation arguments.
            """);

        AgentEndpoint config = new()
        {
            VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 100)]),
            Protocols = { AgentEndpointProtocol.Responses }
        };
        AgentCard card = new(version: "1", [new AgentCardSkill(id: simpleSkill.SkillId, name: SKILL)]);
        PatchAgentOptions patchOptions = new()
        {
            AgentEndpoint = config,
            AgentCard = card
        };
        ProjectsAgentRecord patchedRecord = agentsClient.PatchAgentObject(
            agentName: hostedAgentName,
            patchAgentOptions: patchOptions);
        Console.WriteLine($"The Agent {patchedRecord.Name} was patched.");
    }

    public Sample_AgentsEndpoint(bool isAsync) : base(isAsync)
    { }
}
