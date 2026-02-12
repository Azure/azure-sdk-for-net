// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.AI.Projects.Tests.Utils;
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
    public const string UseMessageEventsEnvironmentVariable = "AZURE_EXPERIMENTAL_TRACING_GEN_AI_USE_MESSAGE_EVENTS";
    private MemoryTraceExporter _exporter;
    private TracerProvider _tracerProvider;
    private bool _contentRecordingEnabledInitialValue = false;
    private bool _tracesEnabledInitialValue = false;
    private string _useMessageEventsInitialValue;

    public AgentsTelemetryTests(bool isAsync) : base(isAsync)
    {
    }

    [SetUp]
    public void Setup()
    {
        _exporter = new MemoryTraceExporter();

        _tracesEnabledInitialValue = string.Equals(
            Environment.GetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable),
            "true",
            StringComparison.OrdinalIgnoreCase);

        _contentRecordingEnabledInitialValue = string.Equals(
            Environment.GetEnvironmentVariable(TraceContentsEnvironmentVariable),
            "true",
            StringComparison.OrdinalIgnoreCase);

        _useMessageEventsInitialValue = Environment.GetEnvironmentVariable(UseMessageEventsEnvironmentVariable);

        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);

        _tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("*")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingTest"))
            .AddProcessor(new SimpleActivityExportProcessor(_exporter))
            .Build();
    }

    [TearDown]
    public async new Task Cleanup()
    {
        await base.Cleanup();
        _tracerProvider.Dispose();
        _exporter.Clear();
        Environment.SetEnvironmentVariable(
            TraceContentsEnvironmentVariable,
            _contentRecordingEnabledInitialValue.ToString(),
            EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(
            EnableOpenTelemetryEnvironmentVariable,
            _tracesEnabledInitialValue.ToString(),
            EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(
            UseMessageEventsEnvironmentVariable,
            _useMessageEventsInitialValue,
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
        var agentName = "agentsTelemetryTests1";

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
        var agentName = "agentsTelemetryTests2";

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
        CheckCreateAgentTrace(createAgentSpan, modelDeploymentName, agentName, "[{\"type\":\"text\",\"content\":\"You are a prompt agent.\"}]");
    }

    [RecordedTest]
    public async Task TestAgentCreateWithTracingContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agentsTelemetryTests3";

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
        CheckCreateAgentTrace(createAgentSpan, modelDeploymentName, agentName, "[{\"type\":\"text\"}]");
    }

    [RecordedTest]
    public async Task TestAgentUpdateWithTracingContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agentsTelemetryTests4";

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

        // Get the version from the response
        AgentRecord updatedAgent = ModelReaderWriter.Read<AgentRecord>(protocolUpdateResult.GetRawResponse().Content);
        string versionNumber = updatedAgent.Versions.Latest.Version;

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

        CheckCreateAgentTrace(updateAgentSpan, modelDeploymentName, agentName, "[{\"type\":\"text\",\"content\":\"You are a helpful prompt agent.\"}]", versionNumber);
    }

    [RecordedTest]
    public async Task TestAgentUpdateWithTracingContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agentsTelemetryTests5";

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

        CheckCreateAgentTrace(updateAgentSpan, modelDeploymentName, agentName, "[{\"type\":\"text\"}]");
    }

    [RecordedTest]
    public async Task TestAgentVersionCreateWithTracingContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agentsTelemetryTests6";

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
        CheckCreateAgentVersionTrace(createAgentVersionSpan, modelDeploymentName, agentName, "[{\"type\":\"text\",\"content\":\"You are a prompt agent.\"}]");
    }

    [RecordedTest]
    public async Task TestAgentVersionCreateWithTracingContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agentsTelemetryTests7";

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
        CheckCreateAgentVersionTrace(createAgentVersionSpan, modelDeploymentName, agentName, "[{\"type\":\"text\"}]");
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
    private void CheckCreateAgentTrace(
        Activity createAgentSpan,
        string modelName,
        string agentName,
        string content,
        string agentVersion = "1",
        string agentType = "prompt",
        float? temperature = null,
        float? topP = null,
        string reasoningEffort = null,
        string reasoningSummary = null,
        bool useMessageEvents = false)
    {
        Assert.That(createAgentSpan, Is.Not.Null);
        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.provider.name", "microsoft.foundry" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelName },
            { "gen_ai.agent.name", agentName },
            { "gen_ai.agent.version", agentVersion },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.agent.type", agentType }
        };

        if (!useMessageEvents)
        {
            expectedCreateAgentAttributes["gen_ai.system_instructions"] = content;
        }

        if (temperature.HasValue)
        {
            expectedCreateAgentAttributes["gen_ai.request.temperature"] = temperature.Value;
        }

        if (topP.HasValue)
        {
            expectedCreateAgentAttributes["gen_ai.request.top_p"] = topP.Value;
        }

        if (!string.IsNullOrEmpty(reasoningEffort))
        {
            expectedCreateAgentAttributes["gen_ai.request.reasoning.effort"] = reasoningEffort;
        }

        if (!string.IsNullOrEmpty(reasoningSummary))
        {
            expectedCreateAgentAttributes["gen_ai.request.reasoning.summary"] = reasoningSummary;
        }

        // Validate expected attributes are present
        GenAiTraceVerifier.ValidateSpanAttributes(createAgentSpan, expectedCreateAgentAttributes);

        // Validate no unexpected attributes are present
        var actualAttributes = new HashSet<string>();
        foreach (KeyValuePair<string, object> tag in createAgentSpan.EnumerateTagObjects())
        {
            actualAttributes.Add(tag.Key);
        }

        var expectedKeys = new HashSet<string>(expectedCreateAgentAttributes.Keys);
        var unexpectedAttributes = actualAttributes.Except(expectedKeys).ToList();
        Assert.That(unexpectedAttributes, Is.Empty,
            $"Found unexpected attributes in create_agent span: {string.Join(", ", unexpectedAttributes)}");

        if (useMessageEvents)
        {
            // Event-based: instructions should be emitted as an event
            var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
            {
                ("gen_ai.system_instructions", new Dictionary<string, object>
                {
                    { "gen_ai.provider.name", "microsoft.foundry" },
                    { "gen_ai.event.content", content }
                })
            };
            GenAiTraceVerifier.ValidateSpanEvents(createAgentSpan, expectedCreateAgentEvents);
        }
        else
        {
            // Attribute-based: no events expected for system instructions
            var events = createAgentSpan.Events.ToList();
            Assert.That(events.Count, Is.EqualTo(0),
                $"Expected no events in attribute-based mode, but found {events.Count}");
        }
    }

    private void CheckCreateAgentVersionTrace(
        Activity createAgentSpan,
        string modelName,
        string agentName,
        string content,
        string agentType = "prompt",
        float? temperature = null,
        float? topP = null,
        string reasoningEffort = null,
        string reasoningSummary = null,
        bool useMessageEvents = false)
    {
        Assert.That(createAgentSpan, Is.Not.Null);
        var expectedCreateAgentAttributes = new Dictionary<string, object>
        {
            { "gen_ai.provider.name", "microsoft.foundry" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelName },
            { "gen_ai.agent.name", agentName },
            { "gen_ai.agent.version", "1" },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.agent.type", agentType }
        };

        if (!useMessageEvents)
        {
            expectedCreateAgentAttributes["gen_ai.system_instructions"] = content;
        }

        if (temperature.HasValue)
        {
            expectedCreateAgentAttributes["gen_ai.request.temperature"] = temperature.Value;
        }

        if (topP.HasValue)
        {
            expectedCreateAgentAttributes["gen_ai.request.top_p"] = topP.Value;
        }

        if (!string.IsNullOrEmpty(reasoningEffort))
        {
            expectedCreateAgentAttributes["gen_ai.request.reasoning.effort"] = reasoningEffort;
        }

        if (!string.IsNullOrEmpty(reasoningSummary))
        {
            expectedCreateAgentAttributes["gen_ai.request.reasoning.summary"] = reasoningSummary;
        }

        // Validate expected attributes are present
        GenAiTraceVerifier.ValidateSpanAttributes(createAgentSpan, expectedCreateAgentAttributes);

        // Validate no unexpected attributes are present
        var actualAttributes = new HashSet<string>();
        foreach (KeyValuePair<string, object> tag in createAgentSpan.EnumerateTagObjects())
        {
            actualAttributes.Add(tag.Key);
        }

        var expectedKeys = new HashSet<string>(expectedCreateAgentAttributes.Keys);
        var unexpectedAttributes = actualAttributes.Except(expectedKeys).ToList();
        Assert.That(unexpectedAttributes, Is.Empty,
            $"Found unexpected attributes in create_agent span: {string.Join(", ", unexpectedAttributes)}");

        if (useMessageEvents)
        {
            // Event-based: instructions should be emitted as an event
            var expectedCreateAgentEvents = new List<(string, Dictionary<string, object>)>
            {
                ("gen_ai.system_instructions", new Dictionary<string, object>
                {
                    { "gen_ai.provider.name", "microsoft.foundry" },
                    { "gen_ai.event.content", content }
                })
            };
            GenAiTraceVerifier.ValidateSpanEvents(createAgentSpan, expectedCreateAgentEvents);
        }
        else
        {
            // Attribute-based: no events expected for system instructions
            var events = createAgentSpan.Events.ToList();
            Assert.That(events.Count, Is.EqualTo(0),
                $"Expected no events in attribute-based mode, but found {events.Count}");
        }
    }

    [RecordedTest]
    public async Task TestAgentCreateWithMessageEventsContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(UseMessageEventsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agentsTelemetryTestsEvents1";

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
        CheckCreateAgentTrace(createAgentSpan, modelDeploymentName, agentName, "[{\"type\":\"text\",\"content\":\"You are a prompt agent.\"}]", useMessageEvents: true);
    }

    [RecordedTest]
    public async Task TestAgentCreateWithMessageEventsContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(UseMessageEventsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agentsTelemetryTestsEvents2";

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
        CheckCreateAgentTrace(createAgentSpan, modelDeploymentName, agentName, "[{\"type\":\"text\"}]", useMessageEvents: true);
    }

    [RecordedTest]
    public async Task TestAgentVersionCreateWithMessageEventsContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(UseMessageEventsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agentsTelemetryTestsEvents3";

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
        CheckCreateAgentVersionTrace(createAgentVersionSpan, modelDeploymentName, agentName, "[{\"type\":\"text\",\"content\":\"You are a prompt agent.\"}]", useMessageEvents: true);
    }

    [RecordedTest]
    public async Task TestAgentVersionCreateWithMessageEventsContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(UseMessageEventsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = GetModelDeploymentName();
        var agentName = "agentsTelemetryTestsEvents4";

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
        CheckCreateAgentVersionTrace(createAgentVersionSpan, modelDeploymentName, agentName, "[{\"type\":\"text\"}]", useMessageEvents: true);
    }

    [RecordedTest]
    public async Task TestWorkflowAgentCreationWithTracingContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var agentName = "test-workflow-agent";

        string workflowYaml = @"
kind: workflow
trigger:
  kind: OnConversationStart
  id: test_workflow
  actions:
    - kind: SetVariable
      id: set_variable
      variable: Local.TestVar
      value: ""test""
";

        AgentDefinition workflowDefinition = WorkflowAgentDefinition.FromYaml(workflowYaml);

        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: agentName,
            options: new AgentVersionCreationOptions(workflowDefinition));

        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentVersion.Version);

        // Force flush spans
        _exporter.ForceFlush();

        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"create_agent {agentName}");
        Assert.That(createAgentSpan, Is.Not.Null);

        // Verify attributes
        var expectedAttributes = new Dictionary<string, object>
        {
            { "gen_ai.provider.name", "microsoft.foundry" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.agent.name", agentName },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.agent.version", "1" },
            { "gen_ai.agent.type", "workflow" }
        };

        GenAiTraceVerifier.ValidateSpanAttributes(createAgentSpan, expectedAttributes);

        // Verify no unexpected attributes
        var actualAttributes = new HashSet<string>();
        foreach (KeyValuePair<string, object> tag in createAgentSpan.EnumerateTagObjects())
        {
            actualAttributes.Add(tag.Key);
        }

        var expectedKeys = new HashSet<string>(expectedAttributes.Keys);
        var unexpectedAttributes = actualAttributes.Except(expectedKeys).ToList();
        Assert.That(unexpectedAttributes, Is.Empty,
            $"Found unexpected attributes in create_agent span: {string.Join(", ", unexpectedAttributes)}");

        // Verify workflow event with content
        var events = createAgentSpan.Events.ToList();
        Assert.That(events.Count, Is.EqualTo(1));
        var workflowEvent = events[0];
        Assert.That(workflowEvent.Name, Is.EqualTo("gen_ai.agent.workflow"));

        var eventContent = workflowEvent.Tags.FirstOrDefault(t => t.Key == "gen_ai.event.content").Value as string;
        Assert.That(eventContent, Is.Not.Null);

        // Parse and verify content structure
        var contentArray = System.Text.Json.JsonDocument.Parse(eventContent).RootElement;
        Assert.That(contentArray.ValueKind, Is.EqualTo(System.Text.Json.JsonValueKind.Array));
        Assert.That(contentArray.GetArrayLength(), Is.EqualTo(1));

        var contentItem = contentArray[0];
        Assert.That(contentItem.GetProperty("type").GetString(), Is.EqualTo("workflow"));
        Assert.That(contentItem.TryGetProperty("content", out var content), Is.True);
        var workflowContent = content.GetString();
        Assert.That(workflowContent, Does.Contain("kind: workflow"));
    }

    [RecordedTest]
    public async Task TestWorkflowAgentCreationWithTracingContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeOpenTelemetryScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var agentName = "test-workflow-agent";

        string workflowYaml = @"
kind: workflow
trigger:
  kind: OnConversationStart
  id: test_workflow
  actions:
    - kind: SetVariable
      id: set_variable
      variable: Local.TestVar
      value: ""test""
";

        AgentDefinition workflowDefinition = WorkflowAgentDefinition.FromYaml(workflowYaml);

        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: agentName,
            options: new AgentVersionCreationOptions(workflowDefinition));

        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentVersion.Version);

        // Force flush spans
        _exporter.ForceFlush();

        var createAgentSpan = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"create_agent {agentName}");
        Assert.That(createAgentSpan, Is.Not.Null);

        // Verify attributes
        var expectedAttributes = new Dictionary<string, object>
        {
            { "gen_ai.provider.name", "microsoft.foundry" },
            { "gen_ai.operation.name", "create_agent" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.agent.name", agentName },
            { "gen_ai.agent.id", "*" },
            { "gen_ai.agent.version", "1" },
            { "gen_ai.agent.type", "workflow" }
        };

        GenAiTraceVerifier.ValidateSpanAttributes(createAgentSpan, expectedAttributes);

        // Verify no unexpected attributes
        var actualAttributes = new HashSet<string>();
        foreach (KeyValuePair<string, object> tag in createAgentSpan.EnumerateTagObjects())
        {
            actualAttributes.Add(tag.Key);
        }

        var expectedKeys = new HashSet<string>(expectedAttributes.Keys);
        var unexpectedAttributes = actualAttributes.Except(expectedKeys).ToList();
        Assert.That(unexpectedAttributes, Is.Empty,
            $"Found unexpected attributes in create_agent span: {string.Join(", ", unexpectedAttributes)}");

        // Verify workflow event without content (empty array)
        var events = createAgentSpan.Events.ToList();
        Assert.That(events.Count, Is.EqualTo(1));
        var workflowEvent = events[0];
        Assert.That(workflowEvent.Name, Is.EqualTo("gen_ai.agent.workflow"));

        var eventContent = workflowEvent.Tags.FirstOrDefault(t => t.Key == "gen_ai.event.content").Value as string;
        Assert.That(eventContent, Is.Not.Null);

        // Parse and verify content is empty array
        var contentArray = System.Text.Json.JsonDocument.Parse(eventContent).RootElement;
        Assert.That(contentArray.ValueKind, Is.EqualTo(System.Text.Json.JsonValueKind.Array));
        Assert.That(contentArray.GetArrayLength(), Is.EqualTo(0));
    }

    private async Task WaitMayBe(int timeout = 1000)
    {
        if (Mode != RecordedTestMode.Playback)
            await Task.Delay(timeout);
    }
    #endregion
}
