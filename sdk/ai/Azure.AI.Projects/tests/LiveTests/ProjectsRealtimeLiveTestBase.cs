// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.LiveTests;

/// <summary>
/// Base class for Voice Agent realtime streaming live tests. These tests exercise
/// <see cref="ProjectsRealtimeSessionClient"/> against the real Foundry service; the realtime
/// protocol cannot be meaningfully recorded/played back over HTTP, so every test here only runs
/// with CLIENTMODEL_TEST_MODE=Live.
/// </summary>
[NonParallelizable]
[LiveOnly]
public class ProjectsRealtimeLiveTestBase : AgentsTestBase
{
    private readonly List<(string Name, string Version)> _createdAgentVersions = [];

    public ProjectsRealtimeLiveTestBase(bool isAsync) : base(isAsync)
    {
    }

    protected void TrackCreatedVoiceAgent(string name, ProjectsAgentVersion version)
        => _createdAgentVersions.Add((name, version.Version));

    [TearDown]
    public override async Task Cleanup()
    {
        if (_createdAgentVersions.Count == 0)
        {
            return;
        }

        AgentAdministrationClient agentsClient = GetLiveClient().AgentAdministrationClient;
        foreach ((string name, string version) in _createdAgentVersions)
        {
            await agentsClient.DeleteAgentVersionAsync(name, version);
        }
        _createdAgentVersions.Clear();
    }
}
