// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI.Tests.Utilities;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.Projects.OpenAI.Tests;

public partial class ResponsesTelemetryTests : ProjectsOpenAITestBase
{
    private const string TraceContentsEnvironmentVariable = "OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT";
    private const string EnableOpenTelemetryEnvironmentVariable = "AZURE_EXPERIMENTAL_ENABLE_GENAI_TRACING";

    private MemoryTraceExporter _exporter;
    private TracerProvider _tracerProvider;
    private string _enableTelemetryOrig;
    private string _traceContentOrig;

    public ResponsesTelemetryTests(bool isAsync) : base(isAsync)
    {
    }

    [SetUp]
    public void Setup()
    {
        _exporter = new MemoryTraceExporter();
        _enableTelemetryOrig = Environment.GetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable);
        _traceContentOrig = Environment.GetEnvironmentVariable(TraceContentsEnvironmentVariable);

        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);

        _tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("*")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("ResponsesTelemetryTest"))
            .AddProcessor(new SimpleActivityExportProcessor(_exporter))
            .Build();
    }

    [TearDown]
    public new void Cleanup()
    {
        _tracerProvider.Dispose();
        _exporter.Clear();
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, _enableTelemetryOrig, EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, _traceContentOrig, EnvironmentVariableTarget.Process);
    }

    [RecordedTest]
    public async Task TestResponseWithTracingContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);

        ResponseResult response = await client.CreateResponseAsync("What is 2+2?");
        response = await WaitForRun(client, response);

        _exporter.ForceFlush();

        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span, Is.Not.Null, $"Expected span 'chat {modelDeploymentName}'");

        GenAiTraceVerifier.ValidateSpanAttributes(span, GetExpectedChatAttributes(modelDeploymentName), allowUnexpected: false);

        string inputMessages = span.GetTagItem("gen_ai.input.messages") as string;
        Assert.That(inputMessages, Does.Contain("\"content\":\"What is 2+2?\""));
        Assert.That(inputMessages, Does.Contain("\"role\":\"user\""));

        string outputMessages = span.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages, Does.Contain("\"role\":\"assistant\""));
        Assert.That(outputMessages, Does.Contain("\"content\":"));
        Assert.That(outputMessages, Does.Contain("4").Or.Contains("four"));
    }

    [RecordedTest]
    public async Task TestResponseWithTracingContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);

        ResponseResult response = await client.CreateResponseAsync("What is 2+2?");
        response = await WaitForRun(client, response);

        _exporter.ForceFlush();

        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span, Is.Not.Null, $"Expected span 'chat {modelDeploymentName}'");

        GenAiTraceVerifier.ValidateSpanAttributes(span, GetExpectedChatAttributes(modelDeploymentName), allowUnexpected: false);

        string inputMessages = span.GetTagItem("gen_ai.input.messages") as string;
        Assert.That(inputMessages, Does.Not.Contain("What is 2+2?"));
        Assert.That(inputMessages, Does.Contain("\"type\":\"text\""));
        Assert.That(inputMessages, Does.Contain("\"role\":\"user\""));

        string outputMessages = span.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages, Does.Not.Contain("\"content\":"));
        Assert.That(outputMessages, Does.Not.Contain("4").And.Not.Contain("four"));
        Assert.That(outputMessages, Does.Contain("\"role\":\"assistant\""));
    }

    [RecordedTest]
    public async Task TestResponseWithTracingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);

        ResponseResult response = await client.CreateResponseAsync("What is 2+2?");
        response = await WaitForRun(client, response);

        _exporter.ForceFlush();

        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span, Is.Null, "No spans should be emitted when telemetry is disabled");
    }

    [RecordedTest]
    public async Task TestResponseWithAgentSpanNaming()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant."
        };
        var agentName = "responseTelemetryTestAgent";
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName,
            new AgentVersionCreationOptions(agentDefinition));

        try
        {
            #pragma warning disable OPENAI001
            CreateResponseOptions options = new()
            {
                Agent = new AgentReference(agentVersion.Name, agentVersion.Version),
                InputItems = { ResponseItem.CreateUserMessageItem("Hello agent!") },
            };
            #pragma warning restore OPENAI001

            ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClient();
            ResponseResult response = await client.CreateResponseAsync(options);
            response = await WaitForRun(client, response);

            _exporter.ForceFlush();

            var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"invoke_agent {agentName}");
            Assert.That(span, Is.Not.Null, $"Expected span 'invoke_agent {agentName}'");

                GenAiTraceVerifier.ValidateSpanAttributes(span, GetExpectedAgentAttributes(agentName, agentVersion.Version), allowUnexpected: false);
        }
        finally
        {
            await projectClient.Agents.DeleteAgentAsync(agentName: agentName);
        }
    }

    #region Helpers

    private static Dictionary<string, object> GetCommonExpectedAttributes() => new()
    {
        { "gen_ai.provider.name", "microsoft.foundry" },
        { "server.address", "*" },
        { "az.namespace", "Microsoft.CognitiveServices" },
        { "gen_ai.response.model", "*" },
        { "gen_ai.response.id", "*" },
        { "gen_ai.usage.input_tokens", "+" },
        { "gen_ai.usage.output_tokens", "+" },
        { "gen_ai.input.messages", "*" },
        { "gen_ai.output.messages", "*" },
    };

    private static Dictionary<string, object> GetExpectedChatAttributes(string modelDeploymentName)
    {
        var attrs = GetCommonExpectedAttributes();
        attrs["gen_ai.operation.name"] = "chat";
        attrs["gen_ai.request.model"] = modelDeploymentName;
        return attrs;
    }

    private static Dictionary<string, object> GetExpectedAgentAttributes(string agentName, object agentVersionNumber)
    {
        var attrs = GetCommonExpectedAttributes();
        attrs["gen_ai.operation.name"] = "invoke_agent";
        attrs["gen_ai.agent.name"] = agentName;
        attrs["gen_ai.agent.id"] = $"{agentName}:{agentVersionNumber}";
        return attrs;
    }

    private static void ReinitializeResponseScopeConfiguration()
    {
        Assembly assembly = typeof(ProjectResponsesClient).Assembly;
        Assert.That(assembly, Is.Not.Null);
        System.Type scopeType = assembly.GetType("Azure.AI.Projects.OpenAI.Telemetry.OpenTelemetryResponseScope");
        Assert.That(scopeType, Is.Not.Null, "OpenTelemetryResponseScope type not found");
        MethodInfo method = scopeType.GetMethod("ReinitializeConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
        Assert.That(method, Is.Not.Null, "ReinitializeConfiguration method not found");
        method.Invoke(null, null);
    }

    #endregion
}
