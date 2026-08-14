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
    private const string WebSearchAgentName = "websearch-telemetry-agent";
    private const string WebSearchPrompt = "What is the latest news about Azure AI today?";

    #region Web Search Helpers

    /// <summary>
    /// Creates an agent with a web search tool and returns the agent version.
    /// </summary>
    private async Task<ProjectsAgentVersion> CreateWebSearchAgentAsync(AIProjectClient projectClient, string agentName)
    {
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that can search the web.",
            Tools = { ResponseTool.CreateWebSearchTool() }
        };

        return await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName,
            new ProjectsAgentVersionCreationOptions(agentDefinition));
    }

    /// <summary>
    /// Runs the web search non-streaming flow and returns the completed response.
    /// </summary>
    private async Task<ResponseResult> RunWebSearchNonStreamingAsync(ProjectResponsesClient client)
    {
        ResponseResult response = await client.CreateResponseAsync(WebSearchPrompt);
        return await WaitForRun(client, response);
    }

    /// <summary>
    /// Runs the web search streaming flow and returns the completed response.
    /// </summary>
    private async Task<ResponseResult> RunWebSearchStreamingAsync(ProjectResponsesClient client)
    {
        ResponseResult completedResponse = null;
        await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync(WebSearchPrompt))
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
    /// Validates the span for a web search invocation.
    /// </summary>
    private void ValidateWebSearchSpan(
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

        // --- Input messages ---
        string inputMessages = span.GetTagItem("gen_ai.input.messages") as string;
        Assert.That(inputMessages, Does.Contain("\"role\":\"user\""));
        if (contentRecordingEnabled)
        {
            Assert.That(inputMessages, Does.Contain("\"content\":\"" + WebSearchPrompt + "\""));
        }
        else
        {
            Assert.That(inputMessages, Does.Not.Contain(WebSearchPrompt));
            Assert.That(inputMessages, Does.Contain("\"type\":\"text\""));
        }

        // --- Output messages ---
        string outputMessages = span.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages, Does.Contain("\"role\":\"assistant\""));

        // Web search should produce a tool_call with web_search_call type
        Assert.That(outputMessages, Does.Contain("\"type\":\"tool_call\""));
        Assert.That(outputMessages, Does.Contain("\"type\":\"web_search_call\""));
        // The tool call id is always present (safe, non-PII metadata)
        Assert.That(outputMessages, Does.Contain("\"id\":"));

        if (contentRecordingEnabled)
        {
            // --- Tool call details ---
            // Web search action and status should be present
            Assert.That(outputMessages, Does.Contain("\"action\":"));
            Assert.That(outputMessages, Does.Contain("\"status\":\"completed\""));

            // --- Assistant text response ---
            // The response content is unpredictable for news queries, but the text part should exist
            Assert.That(outputMessages, Does.Contain("\"type\":\"text\",\"content\":"));
            Assert.That(outputMessages, Does.Contain("\"finish_reason\":\"completed\""));
        }
        else
        {
            // --- Tool call details ---
            // Action and status must be absent when content recording is off
            Assert.That(outputMessages, Does.Not.Contain("\"action\":"));
            Assert.That(outputMessages, Does.Not.Contain("\"status\":"));

            // --- Assistant text response ---
            // The text part should have no content field
            Assert.That(outputMessages, Does.Not.Contain("\"type\":\"text\",\"content\":"));
            // But finish_reason is always emitted (non-PII metadata)
            Assert.That(outputMessages, Does.Contain("\"finish_reason\":\"completed\""));
        }
    }

    /// <summary>
    /// Shared implementation for all web search telemetry test variants.
    /// </summary>
    private async Task RunWebSearchTelemetryTestAsync(bool contentRecordingEnabled, bool streaming)
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, contentRecordingEnabled ? "true" : "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var agentName = $"{WebSearchAgentName}-{(streaming ? "stream" : "nonstream")}-{(contentRecordingEnabled ? "on" : "off")}";
        ProjectsAgentVersion agentVersion = await CreateWebSearchAgentAsync(projectClient, agentName);

        try
        {
            AgentReference agentRef = new(agentVersion.Name, agentVersion.Version);
            ProjectResponsesClient client = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentRef);

            if (streaming)
            {
                await RunWebSearchStreamingAsync(client);
            }
            else
            {
                await RunWebSearchNonStreamingAsync(client);
            }

            ValidateWebSearchSpan(agentName, agentVersion.Version, contentRecordingEnabled);
        }
        finally
        {
            await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentName: agentName);
        }
    }

    #endregion

    #region Web Search Non-streaming tests

    [RecordedTest]
    public async Task TestWebSearchWithContentRecordingEnabled()
    {
        await RunWebSearchTelemetryTestAsync(contentRecordingEnabled: true, streaming: false);
    }

    [RecordedTest]
    public async Task TestWebSearchWithContentRecordingDisabled()
    {
        await RunWebSearchTelemetryTestAsync(contentRecordingEnabled: false, streaming: false);
    }

    #endregion

    #region Web Search Streaming tests

    [RecordedTest]
    public async Task TestWebSearchStreamingWithContentRecordingEnabled()
    {
        await RunWebSearchTelemetryTestAsync(contentRecordingEnabled: true, streaming: true);
    }

    [RecordedTest]
    public async Task TestWebSearchStreamingWithContentRecordingDisabled()
    {
        await RunWebSearchTelemetryTestAsync(contentRecordingEnabled: false, streaming: true);
    }

    #endregion
}
