// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Extensions.OpenAI;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// AgentServer create-response request options.
/// </summary>
/// <remarks>
/// This type extends the OpenAI response creation options with AgentServer-specific
/// request fields that are present in the Foundry protocol but not exposed by the
/// OpenAI .NET SDK.
/// </remarks>
public class CreateResponse : CreateResponseOptions
{
    private BinaryData? _input;
    private BinaryData? _conversation;

    /// <summary>
    /// Initializes a new instance of <see cref="CreateResponse"/>.
    /// </summary>
    public CreateResponse()
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="CreateResponse"/>.
    /// </summary>
    /// <param name="model">The model to use for response generation.</param>
    /// <param name="inputItems">The input items for the response.</param>
    public CreateResponse(string model, IEnumerable<ResponseItem> inputItems)
        : base(model, inputItems)
    {
    }

    /// <summary> Gets or sets the agent that should be associated with the response. </summary>
    public AgentReference? AgentReference { get; set; }

    /// <summary> Gets or sets the AgentServer session identifier for this request. </summary>
    public string? AgentSessionId { get; set; }

    /// <summary>Gets or sets the raw input payload for compatibility with generated-model tests.</summary>
    public BinaryData? Input
    {
        get => _input;
        set => _input = value;
    }

    /// <summary>Gets or sets the raw conversation payload for compatibility with generated-model tests.</summary>
    public BinaryData? Conversation
    {
        get => _conversation;
        set => _conversation = value;
    }

    /// <summary>Gets or sets whether streaming is enabled.</summary>
    public bool? Stream
    {
        get => StreamingEnabled;
        set => StreamingEnabled = value;
    }

    /// <summary>Gets or sets whether the response runs in background mode.</summary>
    public bool? Background
    {
        get => BackgroundModeEnabled;
        set => BackgroundModeEnabled = value;
    }

    /// <summary>Gets or sets whether the response should be stored.</summary>
    public bool? Store
    {
        get => StoredOutputEnabled;
        set => StoredOutputEnabled = value;
    }

    /// <summary>Gets or sets the maximum output token count.</summary>
    public int? MaxOutputTokens
    {
        get => MaxOutputTokenCount;
        set => MaxOutputTokenCount = value;
    }

    /// <summary>Gets or sets whether parallel tool calls are enabled.</summary>
    public bool? ParallelToolCalls
    {
        get => ParallelToolCallsEnabled;
        set => ParallelToolCallsEnabled = value;
    }

    /// <summary>Gets or sets truncation mode.</summary>
    public ResponseTruncationMode? Truncation
    {
        get => TruncationMode;
        set => TruncationMode = value;
    }

    /// <summary>Gets or sets reasoning options.</summary>
    public ResponseReasoningOptions? Reasoning
    {
        get => ReasoningOptions;
        set => ReasoningOptions = value;
    }

    /// <summary>Gets or sets compatibility function arguments.</summary>
    public BinaryData? FunctionArguments { get; set; }

    /// <summary>Gets the tool definitions for the response.</summary>
    public IList<ResponseTool> ToolDefinitions => Tools;
}
