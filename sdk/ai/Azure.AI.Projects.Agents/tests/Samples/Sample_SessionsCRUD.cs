// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Azure.AI.Projects.Agents.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_SessionsCRUD : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task SessionsCRUDAsync()
    {
        #region Snippet:Sample_CreateClient_SessionsCRUD
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var hostedAgentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        var hostedAgentVersion = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_VERSION");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var hostedAgentName = TestEnvironment.HOSTED_AGENT_NAME;
        var hostedAgentVersion = TestEnvironment.HOSTED_AGENT_VERSION;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        #endregion
        #region Snippet:Sample_CreateAgent_SessionsCRUD_Async
        ProjectsAgentVersion agentVersion = await agentsClient.GetAgentVersionAsync(
            agentName: hostedAgentName,
            agentVersion: hostedAgentVersion);
        #endregion
        #region Snippet:Sample_CreateSessions_SessionsCRUD_Async
        string sessionKey1 = Guid.NewGuid().ToString();
        string sessionKey2 = Guid.NewGuid().ToString();
        string sessionId1 = Guid.NewGuid().ToString();
        string sessionId2 = Guid.NewGuid().ToString();
        ProjectAgentSession session1 = await agentsClient.CreateSessionAsync(
            agentName: agentVersion.Name,
            agentSessionId: sessionId1,
            isolationKey: sessionKey1,
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        Console.WriteLine($"Created session with ID {session1.AgentSessionId}");
        ProjectAgentSession session2 = await agentsClient.CreateSessionAsync(
            agentName: agentVersion.Name,
            agentSessionId: sessionId2,
            isolationKey: sessionKey2,
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        Console.WriteLine($"Created session with ID {session2.AgentSessionId}");
        while (session1.Status != AgentSessionStatus.Failed && session1.Status != AgentSessionStatus.Active)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            session1 = await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session1.AgentSessionId);
        }
        while (session2.Status != AgentSessionStatus.Failed && session2.Status != AgentSessionStatus.Active)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            session2 = await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
        }
        #endregion
        #region Snippet:Sample_Get_SessionsCRUD_Async
        ProjectAgentSession session = await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
        Console.WriteLine($"Retrieved session with ID {session.AgentSessionId}");
        #endregion
        #region Snippet:Sample_List_SessionsCRUD_Async
        List<ProjectAgentSession> sessions = await agentsClient.GetSessionsAsync(agentName: agentVersion.Name).ToListAsync();
        Console.WriteLine($"Found {sessions.Count} sessions.");
        foreach (ProjectAgentSession item in sessions)
        {
            Console.WriteLine($"    - Id: {item.AgentSessionId}, last accessed: {item.LastAccessedAt}.");
        }
        #endregion
        #region Snippet:Sample_Delete_SessionsCRUD_Async
        await agentsClient.DeleteSessionAsync(agentName: agentVersion.Name, sessionId: session1.AgentSessionId, isolationKey: sessionKey1);
        await agentsClient.DeleteSessionAsync(agentName: agentVersion.Name, sessionId: session2.AgentSessionId, isolationKey: sessionKey2);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void SessionsCRUDSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var hostedAgentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        var hostedAgentVersion = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_VERSION");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var hostedAgentName = TestEnvironment.HOSTED_AGENT_NAME;
        var hostedAgentVersion = TestEnvironment.HOSTED_AGENT_VERSION;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview,AgentEndpoints=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        #region Snippet:Sample_CreateAgent_SessionsCRUD_Sync
        ProjectsAgentVersion agentVersion = agentsClient.GetAgentVersion(
            agentName: hostedAgentName,
            agentVersion: hostedAgentVersion);
        #endregion
        #region Snippet:Sample_CreateSessions_SessionsCRUD_Sync
        string sessionKey1 = "sample-isolation-key";
        string sessionKey2 = "sample-isolation-key2";
        string sessionId1 = Guid.NewGuid().ToString();
        string sessionId2 = Guid.NewGuid().ToString();
        ProjectAgentSession session1 = agentsClient.CreateSession(
            agentName: agentVersion.Name,
            agentSessionId: sessionId1,
            isolationKey: sessionKey1,
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        Console.WriteLine($"Created session with ID {session1.AgentSessionId}");
        ProjectAgentSession session2 = agentsClient.CreateSession(
            agentName: agentVersion.Name,
            agentSessionId: sessionId2,
            isolationKey: sessionKey2,
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        Console.WriteLine($"Created session with ID {session2.AgentSessionId}");

        while (session1.Status != AgentSessionStatus.Failed && session1.Status != AgentSessionStatus.Active)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            session1 = agentsClient.GetSession(agentName: agentVersion.Name, sessionId: session1.AgentSessionId);
        }
        while (session2.Status != AgentSessionStatus.Failed && session2.Status != AgentSessionStatus.Active)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            session2 = agentsClient.GetSession(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
        }
        #endregion
        #region Snippet:Sample_Get_SessionsCRUD_Sync
        ProjectAgentSession session = agentsClient.GetSession(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
        Console.WriteLine($"Retrieved session with ID {session.AgentSessionId}");
        #endregion
        #region Snippet:Sample_List_SessionsCRUD_Sync
        List<ProjectAgentSession> sessions = [..agentsClient.GetSessions(agentName: agentVersion.Name)];
        Console.WriteLine($"Found {sessions.Count} sessions.");
        foreach (ProjectAgentSession item in sessions)
        {
            Console.WriteLine($"    - Id: {item.AgentSessionId}, last accessed: {item.LastAccessedAt}.");
        }
        #endregion
        #region Snippet:Sample_Delete_SessionsCRUD_Sync
        agentsClient.DeleteSession(agentName: agentVersion.Name, sessionId: session1.AgentSessionId, isolationKey: sessionKey1);
        agentsClient.DeleteSession(agentName: agentVersion.Name, sessionId: session2.AgentSessionId, isolationKey: sessionKey2);
        #endregion
    }

    public Sample_SessionsCRUD(bool isAsync) : base(isAsync)
    { }
}
