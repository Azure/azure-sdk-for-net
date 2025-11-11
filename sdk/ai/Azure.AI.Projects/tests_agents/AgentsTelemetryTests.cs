// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.AI.Projects.Tests.Utilities;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.Projects.Tests;

public partial class AgentsTelemetryTests : AgentsTestBase
{
    public const string TraceContentsEnvironmentVariable = "OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT";
    public const string EnableOpenTelemetryEnvironmentVariable = "AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE";
    private MemoryTraceExporter _exporter;
    private TracerProvider _tracerProvider;
    private GenAiTraceVerifier _traceVerifier;
    private bool _contentRecordingEnabledInitialValue = false;
    private bool _tracesEnabledInitialValue = false;

    public AgentsTelemetryTests(bool isAsync) : base(isAsync)
    {
    }

    [SetUp]
    public void Setup()
    {
        _exporter = new MemoryTraceExporter();
        _traceVerifier = new GenAiTraceVerifier();

        _tracesEnabledInitialValue = string.Equals(
            Environment.GetEnvironmentVariable(TraceContentsEnvironmentVariable),
            "true",
            StringComparison.OrdinalIgnoreCase);

        _contentRecordingEnabledInitialValue = string.Equals(
            Environment.GetEnvironmentVariable(TraceContentsEnvironmentVariable),
            "true",
            StringComparison.OrdinalIgnoreCase);

        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);

        _tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("*")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingTest"))
            .AddProcessor(new SimpleActivityExportProcessor(_exporter))
            .Build();
    }

    [TearDown]
    public new void Cleanup()
    {
        base.Cleanup();
        _tracerProvider.Dispose();
        _exporter.Clear();
        Environment.SetEnvironmentVariable(
            TraceContentsEnvironmentVariable,
            _contentRecordingEnabledInitialValue.ToString(),
            EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(
            TraceContentsEnvironmentVariable,
            _tracesEnabledInitialValue.ToString(),
            EnvironmentVariableTarget.Process);
    }

    private string GetModelDeploymentName()
    {
        //string modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        //return modelDeploymentName;
        return TestEnvironment.MODELDEPLOYMENTNAME;
    }

    [RecordedTest]
    public async Task TestAgentCreateWithTracingActivitySourceDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests1";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName,
            new AgentVersionCreationOptions(agentDefinition));

        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentVersion.Version);

        // Force flush spans
        _exporter.ForceFlush();

        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"create_agent {agentName}");
        Assert.That(createAgentSpan, Is.Null);
    }

    [RecordedTest]
    public async Task TestAgentCreateWithTracingContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests2";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: agentName,
            options: new(agentDefinition));

        await projectClient.Agents.DeleteAgentAsync(agentName: agentName);

        // Force flush spans
        _exporter.ForceFlush();

        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"create_agent {agentName}");
        Assert.That(createAgentSpan, Is.Not.Null);
        CheckCreateAgentTrace(createAgentSpan, modelDeploymentName, agentName, "{\"content\":\"You are a prompt agent.\"}");
    }

    [RecordedTest]
    public async Task TestAgentCreateWithTracingContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests3";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: agentName,
            options: new(agentDefinition));

        await projectClient.Agents.DeleteAgentAsync(agentName: agentName);

        // Force flush spans
        _exporter.ForceFlush();

        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"create_agent {agentName}");
        Assert.That(createAgentSpan, Is.Not.Null);
        CheckCreateAgentTrace(createAgentSpan, modelDeploymentName, agentName, "\"\"");
    }

    [RecordedTest]
    public async Task TestAgentUpdateWithTracingContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests4";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: agentName,
            options: new(agentDefinition));

        PromptAgentDefinition updateAgentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful prompt agent."
        };

        ClientResult protocolUpdateResult = await projectClient.Agents.UpdateAgentAsync(
            agentName: agentName,
            content: BinaryContent.Create(BinaryData.FromString($$"""
                {
                  "definition": {
                    "kind": "prompt",
                    "model": "{{updateAgentDefinition.Model}}",
                    "instructions": "{{updateAgentDefinition.Instructions}}"
                  }
                }
                """)));

        await projectClient.Agents.DeleteAgentAsync(agentName: agentName);

        // Force flush spans
        _exporter.ForceFlush();

        var agentSpans = _exporter.GetExportedActivities()
            .Where(s => s.DisplayName == $"create_agent {agentName}")
            .ToList();

        // Validate you have the expected number of spans
        Assert.That(agentSpans.Count, Is.EqualTo(2), $"Expected exactly 2 spans for create_agent {agentName}, but found {agentSpans.Count}");

        var createAgentSpan = agentSpans[0];
        var updateAgentSpan = agentSpans[1];

        Assert.That(createAgentSpan, Is.Not.Null);
        Assert.That(updateAgentSpan, Is.Not.Null);

        CheckCreateAgentTrace(updateAgentSpan, modelDeploymentName, agentName, "{\"content\":\"You are a helpful prompt agent.\"}");
    }

    [RecordedTest]
    public async Task TestAgentUpdateWithTracingContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests5";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: agentName,
            options: new(agentDefinition));

        PromptAgentDefinition updateAgentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful prompt agent."
        };

        ClientResult protocolUpdateResult = await projectClient.Agents.UpdateAgentAsync(
            agentName: agentName,
            content: BinaryContent.Create(BinaryData.FromString($$"""
                {
                  "definition": {
                    "kind": "prompt",
                    "model": "{{agentDefinition.Model}}",
                    "instructions": "{{agentDefinition.Instructions}}"
                  }
                }
                """)));

        await projectClient.Agents.DeleteAgentAsync(agentName: agentName);

        // Force flush spans
        _exporter.ForceFlush();

        var agentSpans = _exporter.GetExportedActivities()
            .Where(s => s.DisplayName == $"create_agent {agentName}")
            .ToList();

        // Validate you have the expected number of spans
        Assert.That(agentSpans.Count, Is.EqualTo(2), $"Expected exactly 2 spans for create_agent {agentName}, but found {agentSpans.Count}");

        var createAgentSpan = agentSpans[0];
        var updateAgentSpan = agentSpans[1];

        Assert.That(createAgentSpan, Is.Not.Null);
        Assert.That(updateAgentSpan, Is.Not.Null);

        CheckCreateAgentTrace(updateAgentSpan, modelDeploymentName, agentName, "\"\"");
    }

    [RecordedTest]
    public async Task TestAgentVersionCreateWithTracingContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests6";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: agentName,
            options: new AgentVersionCreationOptions(agentDefinition));

        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentVersion.Version);

        // Force flush spans
        _exporter.ForceFlush();

        var createAgentVersionSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"create_agent {agentName}");
        Assert.That(createAgentVersionSpan, Is.Not.Null);
        CheckCreateAgentVersionTrace(createAgentVersionSpan, modelDeploymentName, agentName, "{\"content\":\"You are a prompt agent.\"}");
    }

    [RecordedTest]
    public async Task TestAgentVersionCreateWithTracingContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests7";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: agentName,
            options: new(agentDefinition));

        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentVersion.Version);

        // Force flush spans
        _exporter.ForceFlush();

        var createAgentVersionSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"create_agent {agentName}");
        Assert.That(createAgentVersionSpan, Is.Not.Null);
        CheckCreateAgentVersionTrace(createAgentVersionSpan, modelDeploymentName, agentName, "\"\"");
    }

    private static void ReinitializeOpenTelemetryScopeConfiguration()
    {
        Assembly assembly = typeof(AIProjectAgentsOperations).Assembly;
        Assert.That(assembly, Is.Not.Null);
        Type openTelemetryScopeType = assembly.GetType("Azure.AI.Projects.Telemetry.OpenTelemetryScope");
        Assert.That(openTelemetryScopeType, Is.Not.Null);
        MethodInfo reinitializeConfigurationMethod = openTelemetryScopeType.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        Assert.That(reinitializeConfigurationMethod, Is.Not.Null);
        reinitializeConfigurationMethod.Invoke(null, null);
    }

    #region Helpers
    private void CheckCreateAgentTrace(Activity createAgentSpan, string modelName, string agentName, string content)
    {
        Assert.That(createAgentSpan, Is.Not.Null);
        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelName },
            { "gen_ai.agent.name", agentName },
            { "gen_ai.agent.id", "*" }
        };
        Assert.That(_traceVerifier.CheckSpanAttributes(createAgentSpan, expectedCreateAgentAttributes), Is.True);
        var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.system.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.event.content", content }
            })
        };
        Assert.That(_traceVerifier.CheckSpanEvents(createAgentSpan, expectedCreateAgentEvents), Is.True);
    }

    private void CheckCreateAgentVersionTrace(Activity createAgentSpan, string modelName, string agentName, string content)
    {
        Assert.That(createAgentSpan, Is.Not.Null);
        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.system", "az.ai.agents" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelName },
            { "gen_ai.agent.name", agentName },
            { "gen_ai.agent.version", "1" },
            { "gen_ai.agent.id", "*" }
        };
        Assert.That(_traceVerifier.CheckSpanAttributes(createAgentSpan, expectedCreateAgentAttributes), Is.True);
        var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
        {
            ("gen_ai.system.message", new Dictionary<string, object>
            {
                { "gen_ai.system", "az.ai.agents" },
                { "gen_ai.event.content", content }
            })
        };
        Assert.That(_traceVerifier.CheckSpanEvents(createAgentSpan, expectedCreateAgentEvents), Is.True);
    }

    private async Task WaitMayBe(int timeout = 1000)
    {
        if (Mode != RecordedTestMode.Playback)
            await Task.Delay(timeout);
    }
    #endregion
}
