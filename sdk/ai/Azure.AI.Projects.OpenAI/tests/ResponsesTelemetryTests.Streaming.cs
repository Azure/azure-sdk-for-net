// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI.Tests.Utilities;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests;

public partial class ResponsesTelemetryTests
{
    [RecordedTest]
    public async Task TestResponseStreamingWithTelemetry()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);

        CreateResponseOptions options = new()
        {
            InputItems = { ResponseItem.CreateUserMessageItem("Count from 1 to 5") },
            StreamingEnabled = true
        };

        var deltaTexts = new List<string>();
        await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync(options))
        {
            if (update is StreamingResponseOutputTextDeltaUpdate textDelta)
            {
                deltaTexts.Add(textDelta.Delta);
            }
        }

        Assert.That(deltaTexts.Count, Is.GreaterThan(0), "Should have received text deltas");

        _exporter.ForceFlush();

        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span, Is.Not.Null, $"Expected span 'chat {modelDeploymentName}'");

        var expectedAttributes = new Dictionary<string, object>
        {
            { "gen_ai.provider.name", "microsoft.foundry" },
            { "gen_ai.operation.name", "chat" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelDeploymentName },
            { "gen_ai.response.model", "*" },
            { "gen_ai.response.id", "*" },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" },
            { "gen_ai.input.messages", "*" },
            { "gen_ai.output.messages", "*" },
        };
        GenAiTraceVerifier.ValidateSpanAttributes(span, expectedAttributes, allowUnexpected: false);

        string outputMessages = span.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages, Does.Contain("\"role\":\"assistant\""));
        Assert.That(outputMessages, Does.Contain("\"content\":"));
        Assert.That(outputMessages, Does.Contain("3").Or.Contains("three"));
        Assert.That(outputMessages, Does.Contain("\"finish_reason\":\"completed\""));
    }

    [RecordedTest]
    public async Task TestResponseStreamingWithContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);

        var deltaTexts = new List<string>();
        await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync("What is 2+2?"))
        {
            if (update is StreamingResponseOutputTextDeltaUpdate textDelta)
            {
                deltaTexts.Add(textDelta.Delta);
            }
        }

        Assert.That(deltaTexts.Count, Is.GreaterThan(0), "Should have received text deltas");

        _exporter.ForceFlush();

        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span, Is.Not.Null, $"Expected span 'chat {modelDeploymentName}'");

        var expectedAttributes = new Dictionary<string, object>
        {
            { "gen_ai.provider.name", "microsoft.foundry" },
            { "gen_ai.operation.name", "chat" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelDeploymentName },
            { "gen_ai.response.model", "*" },
            { "gen_ai.response.id", "*" },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" },
            { "gen_ai.input.messages", "*" },
            { "gen_ai.output.messages", "*" },
        };
        GenAiTraceVerifier.ValidateSpanAttributes(span, expectedAttributes, allowUnexpected: false);

        string inputMessages = span.GetTagItem("gen_ai.input.messages") as string;
        Assert.That(inputMessages, Does.Not.Contain("What is 2+2?"));
        Assert.That(inputMessages, Does.Contain("\"role\":\"user\""));

        string outputMessages = span.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages, Does.Not.Contain("\"content\":"));
        Assert.That(outputMessages, Does.Not.Contain("4").And.Not.Contain("four"));
        Assert.That(outputMessages, Does.Contain("\"role\":\"assistant\""));
    }

    [RecordedTest]
    public async Task TestResponseStreamingWithTelemetryDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);

        var deltaTexts = new List<string>();
        await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync("What is 2+2?"))
        {
            if (update is StreamingResponseOutputTextDeltaUpdate textDelta)
            {
                deltaTexts.Add(textDelta.Delta);
            }
        }

        Assert.That(deltaTexts.Count, Is.GreaterThan(0), "Should have received text deltas");

        _exporter.ForceFlush();

        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span, Is.Null, "No spans should be emitted when telemetry is disabled");
    }

    [RecordedTest]
    public async Task TestResponseStreamingWithAgentSpanNaming()
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
        var agentName = "responseStreamingTelemetryAgent";
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName,
            new AgentVersionCreationOptions(agentDefinition));

        try
        {
            var agentRef = new AgentReference(agentVersion.Name, agentVersion.Version);
            ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentRef);

            var deltaTexts = new List<string>();
            await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync("Hello agent!"))
            {
                if (update is StreamingResponseOutputTextDeltaUpdate textDelta)
                {
                    deltaTexts.Add(textDelta.Delta);
                }
            }

            Assert.That(deltaTexts.Count, Is.GreaterThan(0), "Should have received text deltas");

            _exporter.ForceFlush();

            var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"invoke_agent {agentName}");
            Assert.That(span, Is.Not.Null, $"Expected span 'invoke_agent {agentName}'");

                var expectedAttributes = new Dictionary<string, object>
            {
                { "gen_ai.provider.name", "microsoft.foundry" },
                { "gen_ai.operation.name", "invoke_agent" },
                { "server.address", "*" },
                { "az.namespace", "Microsoft.CognitiveServices" },
                { "gen_ai.agent.name", agentName },
                { "gen_ai.agent.id", $"{agentName}:{agentVersion.Version}" },
                { "gen_ai.response.model", "*" },
                { "gen_ai.response.id", "*" },
                { "gen_ai.usage.input_tokens", "+" },
                { "gen_ai.usage.output_tokens", "+" },
                { "gen_ai.input.messages", "*" },
                { "gen_ai.output.messages", "*" },
            };
            GenAiTraceVerifier.ValidateSpanAttributes(span, expectedAttributes, allowUnexpected: false);

            string inputMessages = span.GetTagItem("gen_ai.input.messages") as string;
            Assert.That(inputMessages, Does.Contain("\"content\":\"Hello agent!\""));

            string outputMessages = span.GetTagItem("gen_ai.output.messages") as string;
            Assert.That(outputMessages, Does.Contain("\"role\":\"assistant\""));
            Assert.That(outputMessages, Does.Contain("\"finish_reason\":\"completed\""));
        }
        finally
        {
            await projectClient.Agents.DeleteAgentAsync(agentName: agentName);
        }
    }
}
