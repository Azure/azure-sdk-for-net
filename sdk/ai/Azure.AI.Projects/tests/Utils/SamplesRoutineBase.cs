// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Samples;

[NonParallelizable]
[LiveOnly]
public class SamplesRoutineBase : ProjectsClientTestBase
{
    protected readonly string SAMPLE_AGEN_PREFIX = "myHostedForRoutines";
    protected readonly string SAMPLE_ROUTINE_NAME_PREFIX = "sample-routine";

    public SamplesRoutineBase(bool isAsync) : base(isAsync)
    { }

    [TearDown]
    public async virtual Task Cleanup()
    {
        if (Mode == RecordedTestMode.Playback)
            return;
        Uri connectionString = new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT);
        AIProjectClient projectClient = new(connectionString, TestEnvironment.Credential);
        // Remove Routnes
        List<string> routines = await projectClient.Routines.GetRoutinesAsync().Where(x => x.Name.StartsWith(SAMPLE_ROUTINE_NAME_PREFIX)).Select(x => x.Name).ToListAsync();
        foreach (string routineName in routines)
        {
            await projectClient.Routines.DeleteRoutineAsync(routineName);
        }
        // Remove Agents.
        List<string> hostedAgents = await projectClient.AgentAdministrationClient.GetAgentsAsync().Select((x) => x.Name).Where((x) => x.StartsWith(SAMPLE_AGEN_PREFIX)).ToListAsync();
        foreach (string hostedAgent in hostedAgents)
        {
            try
            {
                projectClient.AgentAdministrationClient.DeleteAgent(hostedAgent, force: true);
            }
            catch { }
        }
    }
}
