// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Layer 3 convenience extensions for <see cref="ResponseObject"/>.
/// </summary>
public partial class ResponseObject : ResponseResult
{
    /// <summary> Gets or sets metadata using the former AgentServer representation. </summary>
    public new IDictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();

    /// <summary> Gets or sets tool choice using the former AgentServer binary representation. </summary>
    public new BinaryData? ToolChoice { get; set; }

    /// <summary> Gets or sets instructions using the former AgentServer binary representation. </summary>
    public new BinaryData? Instructions { get; set; }

    /// <summary> Gets or sets the completion timestamp. </summary>
    public DateTimeOffset? CompletedAt { get; set; }

    /// <summary> Gets the response output items. </summary>
    public IList<OutputItem> Output => OutputItems;

    /// <summary> Gets or sets incomplete details using the former AgentServer property name. </summary>
    public ResponseIncompleteDetails? IncompleteDetails
    {
        get => IncompleteStatusDetails;
        set => IncompleteStatusDetails = value;
    }

    /// <summary> Gets or sets whether the response runs in background mode. </summary>
    public bool? Background
    {
        get => BackgroundModeEnabled;
        set => BackgroundModeEnabled = value;
    }

    /// <summary>Gets or sets the maximum output token count.</summary>
    public int? MaxOutputTokens
    {
        get => MaxOutputTokenCount;
        set => MaxOutputTokenCount = value;
    }

    /// <summary>Gets or sets whether parallel tool calls are enabled.</summary>
    public bool ParallelToolCalls
    {
        get => ParallelToolCallsEnabled;
        set => ParallelToolCallsEnabled = value;
    }

    /// <summary> Gets or sets the agent reference stamped by AgentServer. </summary>
    public AgentReference? AgentReference { get; set; }

    /// <summary> Gets or sets the AgentServer session identifier. </summary>
    public string? AgentSessionId { get; set; }

    /// <summary> Gets or sets the conversation echo field. </summary>
    public ConversationParam? Conversation { get; set; }

    /// <summary>
    /// Creates a new <see cref="ResponseObject"/> with minimal required fields.
    /// </summary>
    /// <param name="id">The unique response identifier (e.g. "resp_abc123").</param>
    /// <param name="model">The model that generated this response (e.g. "gpt-4o").</param>
    /// <remarks>
    /// Defaults: <c>CreatedAt</c> = <see cref="DateTimeOffset.UtcNow"/>,
    /// empty <c>Output</c>, <c>ParallelToolCalls</c> = false, nullable fields = null.
    /// Use property setters to customize after construction.
    /// </remarks>
    public ResponseObject(string id, string model)
    {
        Id = id;
        Model = model;
        Object = "response";
        CreatedAt = DateTimeOffset.UtcNow;
        ParallelToolCallsEnabled = false;
    }
}
