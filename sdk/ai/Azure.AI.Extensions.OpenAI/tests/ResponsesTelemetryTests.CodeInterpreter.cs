// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;

public partial class ResponsesTelemetryTests
{
    private const string CodeInterpreterAgentName = "codeinterpreter-telemetry-agent";
    private const string CodeInterpreterPrompt = "I need to solve the equation sin(x) + x^2 = 42";

    #region Helpers

    /// <summary>
    /// Creates an agent with a code interpreter tool and returns the agent version.
    /// </summary>
    private async Task<ProjectsAgentVersion> CreateCodeInterpreterAgentAsync(AIProjectClient projectClient, string agentName)
    {
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a personal math tutor. When asked a math question, write and run code using the python tool to answer the question.",
            Tools =
            {
                ResponseTool.CreateCodeInterpreterTool(
                    new CodeInterpreterToolContainer(
                        CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])
                    )
                ),
            }
        };

        return await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName,
            new ProjectsAgentVersionCreationOptions(agentDefinition));
    }

    /// <summary>
    /// Runs the code interpreter non-streaming flow and returns the completed response.
    /// </summary>
    private async Task<ResponseResult> RunCodeInterpreterNonStreamingAsync(ProjectResponsesClient client)
    {
        ResponseResult response = await client.CreateResponseAsync(CodeInterpreterPrompt);
        return await WaitForRun(client, response);
    }

    /// <summary>
    /// Runs the code interpreter streaming flow and returns the completed response.
    /// </summary>
    private async Task<ResponseResult> RunCodeInterpreterStreamingAsync(ProjectResponsesClient client)
    {
        ResponseResult completedResponse = null;
        await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync(CodeInterpreterPrompt))
        {
            if (update is StreamingResponseCompletedUpdate completed)
            {
                completedResponse = completed.Response;
            }
        }
        Assert.That(completedResponse, Is.Not.Null, "Streaming should produce a completed response");
        return completedResponse;
    }

    /// <summary>
    /// Validates the span for a code interpreter invocation.
    /// </summary>
    private void ValidateCodeInterpreterSpan(
        string agentName,
        object agentVersion,
        bool contentRecordingEnabled)
    {
        _exporter.ForceFlush();

        var span = _exporter.GetExportedActivities()
            .FirstOrDefault(s => s.DisplayName == $"invoke_agent {agentName}");
        Assert.That(span, Is.Not.Null, $"Expected span 'invoke_agent {agentName}'");

        GenAiTraceVerifier.ValidateSpanAttributes(
            span,
            GetExpectedAgentAttributes(agentName, agentVersion),
            allowUnexpected: false);

        string inputMessages = span.GetTagItem("gen_ai.input.messages") as string;
        Assert.That(inputMessages, Does.Contain("\"role\":\"user\""));
        if (contentRecordingEnabled)
        {
            // User prompt text should appear in the input
            Assert.That(inputMessages, Does.Contain("\"content\":\"" + CodeInterpreterPrompt + "\""));
        }
        else
        {
            // User prompt text must be absent; only the structural type hint remains
            Assert.That(inputMessages, Does.Not.Contain(CodeInterpreterPrompt));
            Assert.That(inputMessages, Does.Contain("\"type\":\"text\""));
        }

        string outputMessages = span.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages, Does.Contain("\"role\":\"assistant\""));

        // Code interpreter should produce a tool_call with code_interpreter_call type
        Assert.That(outputMessages, Does.Contain("\"type\":\"tool_call\""));
        Assert.That(outputMessages, Does.Contain("\"type\":\"code_interpreter_call\""));
        // The tool call id is always present (safe, non-PII metadata)
        Assert.That(outputMessages, Does.Contain("\"id\":"));

        if (contentRecordingEnabled)
        {
            // --- Tool call details ---
            // The generated Python code and completion status should be present
            Assert.That(outputMessages, Does.Contain("\"code\":"));
            Assert.That(outputMessages, Does.Contain("\"status\":\"completed\""));

            // --- Assistant text response ---
            // The assistant's final text message should contain actual content with the math result.
            // The equation sin(x)+x^2=42 has solutions near x≈6.47 and x≈-6.50, so the answer
            // will reference at least one of these values.
            Assert.That(outputMessages, Does.Contain("\"type\":\"text\",\"content\":"));
            Assert.That(outputMessages, Does.Contain("6.4").Or.Contains("6.5"));
            Assert.That(outputMessages, Does.Contain("\"finish_reason\":\"completed\""));
        }
        else
        {
            // --- Tool call details ---
            // Code and status must be absent when content recording is off
            Assert.That(outputMessages, Does.Not.Contain("\"code\":"));
            Assert.That(outputMessages, Does.Not.Contain("\"status\":"));

            // --- Assistant text response ---
            // The text part should have no content field and no actual response text
            Assert.That(outputMessages, Does.Not.Contain("\"type\":\"text\",\"content\":"));
            Assert.That(outputMessages, Does.Not.Contain("6.4"));
            Assert.That(outputMessages, Does.Not.Contain("6.5"));
            // But finish_reason is always emitted (non-PII metadata)
            Assert.That(outputMessages, Does.Contain("\"finish_reason\":\"completed\""));
        }
    }

    /// <summary>
    /// Shared implementation for all code interpreter telemetry test variants.
    /// </summary>
    private async Task RunCodeInterpreterTelemetryTestAsync(bool contentRecordingEnabled, bool streaming)
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, contentRecordingEnabled ? "true" : "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var agentName = $"{CodeInterpreterAgentName}-{(streaming ? "stream" : "nonstream")}-{(contentRecordingEnabled ? "on" : "off")}";
        ProjectsAgentVersion agentVersion = await CreateCodeInterpreterAgentAsync(projectClient, agentName);

        try
        {
            AgentReference agentRef = new(agentVersion.Name, agentVersion.Version);
            ProjectResponsesClient client = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentRef);

            if (streaming)
            {
                await RunCodeInterpreterStreamingAsync(client);
            }
            else
            {
                await RunCodeInterpreterNonStreamingAsync(client);
            }

            ValidateCodeInterpreterSpan(agentName, agentVersion.Version, contentRecordingEnabled);
        }
        finally
        {
            await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentName: agentName);
        }
    }

    #endregion

    #region Non-streaming tests

    [RecordedTest]
    public async Task TestCodeInterpreterWithContentRecordingEnabled()
    {
        await RunCodeInterpreterTelemetryTestAsync(contentRecordingEnabled: true, streaming: false);
    }

    [RecordedTest]
    public async Task TestCodeInterpreterWithContentRecordingDisabled()
    {
        await RunCodeInterpreterTelemetryTestAsync(contentRecordingEnabled: false, streaming: false);
    }

    #endregion

    #region Streaming tests

    [RecordedTest]
    public async Task TestCodeInterpreterStreamingWithContentRecordingEnabled()
    {
        await RunCodeInterpreterTelemetryTestAsync(contentRecordingEnabled: true, streaming: true);
    }

    [RecordedTest]
    public async Task TestCodeInterpreterStreamingWithContentRecordingDisabled()
    {
        await RunCodeInterpreterTelemetryTestAsync(contentRecordingEnabled: false, streaming: true);
    }

    #endregion
}
