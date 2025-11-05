// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.AI.Agents.Tests.Utilities;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.Agents.Tests;

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

        var client = GetTestClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests1";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentRecord agentRecord = await client.CreateAgentAsync(
            name: agentName,
            definition: agentDefinition, options: null);

        await client.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentRecord.Versions.Latest.Version);

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

        var client = GetTestClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests2";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentRecord agentRecord = await client.CreateAgentAsync(
            name: agentName,
            definition: agentDefinition, options: null  );

        await client.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentRecord.Versions.Latest.Version);

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

        var client = GetTestClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests3";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentRecord agentRecord = await client.CreateAgentAsync(
            name: agentName,
            definition: agentDefinition, options: null);

        await client.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentRecord.Versions.Latest.Version);

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

        var client = GetTestClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests4";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentRecord agentRecord = await client.CreateAgentAsync(
            name: agentName,
            definition: agentDefinition, options: null);

        PromptAgentDefinition updateAgentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful prompt agent."
        };

        AgentRecord updateAgentRecord = await client.UpdateAgentAsync(
            agentName: agentName,
            options: new AgentUpdateOptions(updateAgentDefinition));

        await client.DeleteAgentVersionAsync(agentName: agentName, agentVersion: updateAgentRecord.Versions.Latest.Version);
        await client.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentRecord.Versions.Latest.Version);

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

        var client = GetTestClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests5";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentRecord agentRecord = await client.CreateAgentAsync(
            name: agentName,
            definition: agentDefinition,
            options: null
        );

        PromptAgentDefinition updateAgentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful prompt agent."
        };

        AgentRecord updateAgentRecord = await client.UpdateAgentAsync(
            agentName: agentName,
            options: new AgentUpdateOptions(updateAgentDefinition));

        await client.DeleteAgentVersionAsync(agentName: agentName, agentVersion: updateAgentRecord.Versions.Latest.Version);
        await client.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentRecord.Versions.Latest.Version);

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

        var client = GetTestClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests6";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentVersion agentVersion = await client.CreateAgentVersionAsync(
            agentName: agentName,
            definition: agentDefinition,
            options: null
        );

        await client.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentVersion.Version);

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

        var client = GetTestClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agensTelemetryTests7";

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };

        AgentVersion agentVersion = await client.CreateAgentVersionAsync(
            agentName: agentName,
            definition: agentDefinition, options: null);

        await client.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentVersion.Version);

        // Force flush spans
        _exporter.ForceFlush();

        var createAgentVersionSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"create_agent {agentName}");
        Assert.That(createAgentVersionSpan, Is.Not.Null);
        CheckCreateAgentVersionTrace(createAgentVersionSpan, modelDeploymentName, agentName, "\"\"");
    }

    private static void ReinitializeOpenTelemetryScopeConfiguration()
    {
        Assembly assembly = typeof(AgentsClient).Assembly;
        Assert.That(assembly, Is.Not.Null);
        Type openTelemetryScopeType = assembly.GetType("Azure.AI.Agents.OpenTelemetryScope");
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
