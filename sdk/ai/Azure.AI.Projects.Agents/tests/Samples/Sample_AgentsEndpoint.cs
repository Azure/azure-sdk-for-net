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

namespace Azure.AI.Projects.Agents.Tests.Samples;

public class Sample_AgentsEndpoint : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task AgentsEndpointAsync()
    {
        #region Snippet:Sample_CreateClient_AgentsEndpoint
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
        options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview,AgentEndpoints=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        #endregion

        #region Snippet:Sample_GetAgentAndCreateSession_AgentsEndpoint_Async
        ProjectsAgentVersion agentVersion = await agentsClient.GetAgentVersionAsync(
            agentName: hostedAgentName,
            agentVersion: hostedAgentVersion);
        string status = agentVersion.GetStatus();
        if (!string.Equals(status, "active"))
        {
            throw new InvalidOperationException($"The Agent {agentVersion.Name}, v. {agentVersion.Version} has \"{status}\".");
        }
        Console.WriteLine($"Retrieved agent {agentVersion.Name}, v. {agentVersion.Version}");
        //AgentSession session;
        //string sessionKey = Guid.NewGuid().ToString("N");
        //string sessionId = Guid.NewGuid().ToString("N");
        //try
        //{
        //    session = await agentsClient.CreateSessionAsync(
        //        agentName: agentVersion.Name,
        //        agentSessionId: sessionId,
        //        isolationKey: sessionKey,
        //        versionIndicator: new VersionRefIndicator(agentVersion.Version)
        //    );
        //}
        //catch (ClientResultException ex)
        //{
        //    if (ex.Status == 424)
        //    {
        //        // Known issue see VSO Item 5188431.
        //        session = await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: sessionId);
        //    }
        //    else
        //    {
        //        throw;
        //    }
        //}
        //while (session.Status != AgentSessionStatus.Failed && session.Status != AgentSessionStatus.Active)
        //{
        //    await Task.Delay(TimeSpan.FromMilliseconds(500));
        //    session = await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId);
        //}
        //if (!string.Equals(session.Status, "active"))
        //{
        //    throw new InvalidOperationException($"The session {session.AgentSessionId} is in \"{session.Status}\" state.");
        //}
        //Console.WriteLine($"Created session {session.AgentSessionId}.");
        #endregion

        #region Snippet:Sample_CreateEndpoint_AgentsEndpoint_Async
        AgentEndpoint config = new()
        {
            VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 100)]),
            Protocols = {AgentEndpointProtocol.Responses}
        };
        //ProjectsAgentVersion patchedVersion = await agentsClient.PatchAgentObjectAsync(
        //    agentName: hostedAgentName,
        //    BinaryContent.Create(BinaryData.Empty));
        //Console.WriteLine($"Agent created (id: {result.Id}, name: {result.Name})");
        #endregion
    }

    public Sample_AgentsEndpoint(bool isAsync) : base(isAsync)
    { }
}
