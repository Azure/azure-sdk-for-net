// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

#pragma warning disable AAIP001
namespace Azure.AI.Projects.Agents.Tests;

/// <summary>
/// Recorded tests covering the voice-agent-specific version lifecycle through
/// <see cref="AgentAdministrationClient"/> (create/get/list/update/delete) -- the generic version and
/// disable/enable mechanics are already exercised for other agent kinds in <see cref="AgentsTests"/>,
/// so this focuses on what's specific to a <see cref="VoiceAgentDefinition"/>: that it round-trips
/// as its own strongly-typed subclass (the equivalent of Python's `definition.kind == "voice"`
/// check) across multiple versions. Mirrors azure-ai-projects' (Python) test_voice_agent_crud.py.
/// </summary>
public class VoiceAgentCrudTests : AgentsTestBase
{
    public VoiceAgentCrudTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task TestVoiceAgentVersionLifecycle()
    {
        AgentAdministrationClient agentsClient = GetTestClient();

        VoiceAgentDefinition v1Definition = new()
        {
            ModelType = VoiceModelType.SelfDeployed,
            Model = TestEnvironment.FOUNDRY_MODEL_NAME,
            Instructions = "Respond briefly and helpfully.",
        };
        v1Definition.OutputModalities.Add(VoiceOutputModality.Text);
        ClientResult<ProjectsAgentVersion> createV1Result = await agentsClient.CreateAgentVersionAsync(VOICE_CRUD_AGENT_NAME, new ProjectsAgentVersionCreationOptions(v1Definition));
        ProjectsAgentVersion v1 = createV1Result;
        Console.WriteLine($"[REST] CREATE version v1 -> {(int)createV1Result.GetRawResponse().Status}");

        Assert.That(v1.Definition, Is.InstanceOf<VoiceAgentDefinition>(), "The created version's definition must round-trip as VoiceAgentDefinition.");
        Assert.That(((VoiceAgentDefinition)v1.Definition).Instructions, Is.EqualTo("Respond briefly and helpfully."));

        VoiceAgentDefinition v2Definition = new()
        {
            ModelType = VoiceModelType.SelfDeployed,
            Model = TestEnvironment.FOUNDRY_MODEL_NAME,
            Instructions = "Respond in a single short sentence, always.",
        };
        v2Definition.OutputModalities.Add(VoiceOutputModality.Text);
        ClientResult<ProjectsAgentVersion> createV2Result = await agentsClient.CreateAgentVersionAsync(VOICE_CRUD_AGENT_NAME, new ProjectsAgentVersionCreationOptions(v2Definition));
        ProjectsAgentVersion v2 = createV2Result;
        Console.WriteLine($"[REST] CREATE version v2 (update) -> {(int)createV2Result.GetRawResponse().Status}");

        Assert.That(v2.Definition, Is.InstanceOf<VoiceAgentDefinition>());
        Assert.That(((VoiceAgentDefinition)v2.Definition).Instructions, Is.EqualTo("Respond in a single short sentence, always."));
        Assert.That(v2.Version, Is.Not.EqualTo(v1.Version));

        List<ProjectsAgentVersion> versions = await agentsClient.GetAgentVersionsAsync(agentName: VOICE_CRUD_AGENT_NAME).ToListAsync();
        Console.WriteLine($"[REST] LIST versions -> {versions.Count} version(s)");
        Assert.That(versions.Select(v => v.Version), Does.Contain(v1.Version).And.Contain(v2.Version),
            "Both created versions must be present when listing the agent's versions.");

        ProjectsAgentVersion listedV2 = versions.Single(v => v.Version == v2.Version);
        Assert.That(listedV2.Definition, Is.InstanceOf<VoiceAgentDefinition>());
        Assert.That(((VoiceAgentDefinition)listedV2.Definition).Instructions, Is.EqualTo("Respond in a single short sentence, always."),
            "The updated instructions from v2 must have persisted.");

        ClientResult<ProjectsAgentRecord> getResult = await agentsClient.GetAgentAsync(VOICE_CRUD_AGENT_NAME);
        ProjectsAgentRecord agent = getResult;
        Console.WriteLine($"[REST] GET agent -> {(int)getResult.GetRawResponse().Status}");
        Assert.That(agent.Name, Is.EqualTo(VOICE_CRUD_AGENT_NAME));

        ClientResult deleteV1Result = await agentsClient.DeleteAgentVersionAsync(agentName: VOICE_CRUD_AGENT_NAME, agentVersion: v1.Version);
        Console.WriteLine($"[REST] DELETE version v1 -> {(int)deleteV1Result.GetRawResponse().Status}");
        versions = await agentsClient.GetAgentVersionsAsync(agentName: VOICE_CRUD_AGENT_NAME).ToListAsync();
        Assert.That(versions.Select(v => v.Version), Does.Not.Contain(v1.Version).And.Contain(v2.Version),
            "Only v1 should be removed after deleting its version.");

        ClientResult deleteAgentResult = await agentsClient.DeleteAgentAsync(agentName: VOICE_CRUD_AGENT_NAME);
        Console.WriteLine($"[REST] DELETE agent -> {(int)deleteAgentResult.GetRawResponse().Status}");

        ClientResultException getDeletedException = Assert.ThrowsAsync<ClientResultException>(
            () => agentsClient.GetAgentAsync(VOICE_CRUD_AGENT_NAME));
        Console.WriteLine($"[REST] GET deleted agent -> {getDeletedException.Status}");
        Assert.That(getDeletedException.Status, Is.EqualTo(404), "The agent must no longer be retrievable after being deleted.");
    }
}
