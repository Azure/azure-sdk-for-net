// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Telemetry;

/// <summary>
/// Captures the parameters needed to create a telemetry scope for streaming operations.
/// This ensures values are captured at the time of the streaming call, not when enumeration begins.
/// </summary>
internal sealed class StreamingTelemetryContext
{
    private readonly Uri _endpoint;
    private readonly string _model;
    private readonly string _agentName;
    private readonly string _agentId;
    private readonly string _conversationId;
    private readonly IReadOnlyList<string> _inputTexts;
    private readonly IReadOnlyList<OpenTelemetryResponseScope.ToolCallOutputInfo> _toolOutputs;

    public StreamingTelemetryContext(
        Uri endpoint,
        string model,
        string agentName,
        string agentId,
        string conversationId,
        IReadOnlyList<string> inputTexts,
        IReadOnlyList<OpenTelemetryResponseScope.ToolCallOutputInfo> toolOutputs)
    {
        _endpoint = endpoint;
        _model = model;
        _agentName = agentName;
        _agentId = agentId;
        _conversationId = conversationId;
        _inputTexts = inputTexts;
        _toolOutputs = toolOutputs;
    }

    internal static StreamingTelemetryContext Create(CreateResponseOptions options, Uri endpoint, string defaultModelName)
    {
        OpenTelemetryResponseScope.ExtractOptionsContext(options, defaultModelName, out string agentName, out string agentId, out string model, out string conversationId, out var inputTexts, out var toolOutputs);
        return new StreamingTelemetryContext(endpoint, model, agentName, agentId, conversationId, inputTexts, toolOutputs);
    }

    public OpenTelemetryResponseScope CreateScope()
    {
        var scope = OpenTelemetryResponseScope.StartResponseGeneration(
            _endpoint,
            _model,
            _agentName,
            _agentId,
            _conversationId,
            _inputTexts);

        scope?.AddToolCallInputMessages(_toolOutputs);

        return scope;
    }
}
