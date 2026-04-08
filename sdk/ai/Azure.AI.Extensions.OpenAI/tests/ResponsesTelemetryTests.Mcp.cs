// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
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
    private const string McpAgentName = "mcp-telemetry-agent";
    private const string McpPrompt = "Please summarize the Azure REST API specifications Readme";
    private const string McpServerLabel = "api-specs";

    #region MCP Helpers

    /// <summary>
    /// Creates an agent with an MCP tool and returns the agent version.
    /// </summary>
    private async Task<ProjectsAgentVersion> CreateMcpAgentAsync(AIProjectClient projectClient, string agentName)
    {
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
            Tools = { ResponseTool.CreateMcpTool(
                serverLabel: McpServerLabel,
                serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
                toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval
            )) }
        };

        return await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName,
            new ProjectsAgentVersionCreationOptions(agentDefinition));
    }

    /// <summary>
    /// Runs the MCP non-streaming flow: sends the initial request, approves MCP tool calls,
    /// and returns the final completed response.
    /// </summary>
    private async Task<ResponseResult> RunMcpNonStreamingAsync(ProjectResponsesClient client)
    {
        CreateResponseOptions nextResponseOptions = new()
        {
            InputItems = { ResponseItem.CreateUserMessageItem(McpPrompt) },
        };
        ResponseResult latestResponse = null;

        while (nextResponseOptions is not null)
        {
            latestResponse = await client.CreateResponseAsync(nextResponseOptions);
            latestResponse = await WaitForRun(client, latestResponse);
            nextResponseOptions = null;

            foreach (ResponseItem responseItem in latestResponse.OutputItems)
            {
                if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
                {
                    nextResponseOptions = new CreateResponseOptions()
                    {
                        PreviousResponseId = latestResponse.Id,
                    };
                    if (string.Equals(mcpToolCall.ServerLabel, McpServerLabel))
                    {
                        nextResponseOptions.InputItems.Add(
                            ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
                    }
                    else
                    {
                        nextResponseOptions.InputItems.Add(
                            ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: false));
                    }
                }
            }
        }

        Assert.That(latestResponse, Is.Not.Null, "MCP flow should produce a final response");
        return latestResponse;
    }

    /// <summary>
    /// Runs the MCP streaming flow: sends the initial request via streaming, approves
    /// MCP tool calls, and sends the approval via streaming. Returns the final completed response.
    /// </summary>
    private async Task<ResponseResult> RunMcpStreamingAsync(ProjectResponsesClient client)
    {
        CreateResponseOptions nextResponseOptions = new()
        {
            InputItems = { ResponseItem.CreateUserMessageItem(McpPrompt) },
        };
        ResponseResult latestResponse = null;

        while (nextResponseOptions is not null)
        {
            nextResponseOptions.StreamingEnabled = true;
            ResponseResult completedResponse = null;

            await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync(nextResponseOptions))
            {
                if (update is StreamingResponseCompletedUpdate completed)
                {
                    completedResponse = completed.Response;
                }
            }

            Assert.That(completedResponse, Is.Not.Null, "Streaming should produce a completed response");
            latestResponse = completedResponse;
            nextResponseOptions = null;

            foreach (ResponseItem responseItem in latestResponse.OutputItems)
            {
                if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
                {
                    nextResponseOptions = new CreateResponseOptions()
                    {
                        PreviousResponseId = latestResponse.Id,
                    };
                    if (string.Equals(mcpToolCall.ServerLabel, McpServerLabel))
                    {
                        nextResponseOptions.InputItems.Add(
                            ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
                    }
                    else
                    {
                        nextResponseOptions.InputItems.Add(
                            ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: false));
                    }
                }
            }
        }

        Assert.That(latestResponse, Is.Not.Null, "MCP streaming flow should produce a final response");
        return latestResponse;
    }

    /// <summary>
    /// Validates the spans produced by an MCP tool invocation.
    /// MCP produces multiple spans: the initial request (with approval requests) and the
    /// approval response (with the completed mcp_call and assistant text).
    /// </summary>
    private void ValidateMcpSpans(
        string agentName,
        object agentVersion,
        bool contentRecordingEnabled)
    {
        _exporter.ForceFlush();

        var spans = _exporter.GetExportedActivities()
            .Where(s => s.DisplayName == $"invoke_agent {agentName}")
            .ToList();
        Assert.That(spans.Count, Is.GreaterThanOrEqualTo(2),
            $"Expected at least 2 'invoke_agent {agentName}' spans (initial + approval), got {spans.Count}");

        var expectedAttributes = GetExpectedAgentAttributes(agentName, agentVersion);

        // --- Validate initial request span (first span) ---
        var initialSpan = spans[0];
        GenAiTraceVerifier.ValidateSpanAttributes(initialSpan, expectedAttributes, allowUnexpected: false);

        string initialInput = initialSpan.GetTagItem("gen_ai.input.messages") as string;
        Assert.That(initialInput, Does.Contain("\"role\":\"user\""));
        if (contentRecordingEnabled)
        {
            Assert.That(initialInput, Does.Contain(McpPrompt));
        }
        else
        {
            Assert.That(initialInput, Does.Not.Contain(McpPrompt));
            Assert.That(initialInput, Does.Contain("\"type\":\"text\""));
        }

        string initialOutput = initialSpan.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(initialOutput, Does.Contain("\"role\":\"assistant\""));
        Assert.That(initialOutput, Does.Contain("\"type\":\"tool_call\""));

        // The initial response should contain MCP tool types (mcp_list_tools and/or mcp_approval_request)
        Assert.That(initialOutput, Does.Contain("\"type\":\"mcp_"));

        if (contentRecordingEnabled)
        {
            Assert.That(initialOutput, Does.Contain("\"server_label\":\"" + McpServerLabel + "\""));
        }

        // --- Validate final (approval response) span (last span) ---
        // The approval span never has gen_ai.input.messages because the input is
        // mcp_approval_response (not a user text message).
        var finalSpan = spans[spans.Count - 1];
        var approvalExpectedAttributes = new Dictionary<string, object>(expectedAttributes);
        approvalExpectedAttributes.Remove("gen_ai.input.messages");
        GenAiTraceVerifier.ValidateSpanAttributes(finalSpan, approvalExpectedAttributes, allowUnexpected: false);

        string finalOutput = finalSpan.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(finalOutput, Does.Contain("\"role\":\"assistant\""));
        Assert.That(finalOutput, Does.Contain("\"type\":\"tool_call\""));
        Assert.That(finalOutput, Does.Contain("\"type\":\"mcp_call\""));
        Assert.That(finalOutput, Does.Contain("\"finish_reason\":\"completed\""));

        if (contentRecordingEnabled)
        {
            Assert.That(finalOutput, Does.Contain("\"status\":\"completed\""));
            Assert.That(finalOutput, Does.Contain("\"server_label\":\"" + McpServerLabel + "\""));

            // Should also contain the assistant text response content
            Assert.That(finalOutput, Does.Contain("\"type\":\"text\",\"content\":"));
        }
        else
        {
            // Content should be redacted
            Assert.That(finalOutput, Does.Not.Contain("\"type\":\"text\",\"content\":"));
        }
    }

    /// <summary>
    /// Shared implementation for all MCP telemetry test variants.
    /// </summary>
    private async Task RunMcpTelemetryTestAsync(bool contentRecordingEnabled, bool streaming)
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, contentRecordingEnabled ? "true" : "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var agentName = $"{McpAgentName}-{(streaming ? "stream" : "nonstream")}-{(contentRecordingEnabled ? "on" : "off")}";
        ProjectsAgentVersion agentVersion = await CreateMcpAgentAsync(projectClient, agentName);

        try
        {
            AgentReference agentRef = new(agentVersion.Name, agentVersion.Version);
            ProjectResponsesClient client = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentRef);

            if (streaming)
            {
                await RunMcpStreamingAsync(client);
            }
            else
            {
                await RunMcpNonStreamingAsync(client);
            }

            ValidateMcpSpans(agentName, agentVersion.Version, contentRecordingEnabled);
        }
        finally
        {
            await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentName: agentName);
        }
    }

    #endregion

    #region MCP Non-streaming tests

    [RecordedTest]
    public async Task TestMcpWithContentRecordingEnabled()
    {
        await RunMcpTelemetryTestAsync(contentRecordingEnabled: true, streaming: false);
    }

    [RecordedTest]
    public async Task TestMcpWithContentRecordingDisabled()
    {
        await RunMcpTelemetryTestAsync(contentRecordingEnabled: false, streaming: false);
    }

    #endregion

    #region MCP Streaming tests

    [RecordedTest]
    public async Task TestMcpStreamingWithContentRecordingEnabled()
    {
        await RunMcpTelemetryTestAsync(contentRecordingEnabled: true, streaming: true);
    }

    [RecordedTest]
    public async Task TestMcpStreamingWithContentRecordingDisabled()
    {
        await RunMcpTelemetryTestAsync(contentRecordingEnabled: false, streaming: true);
    }

    #endregion
}
