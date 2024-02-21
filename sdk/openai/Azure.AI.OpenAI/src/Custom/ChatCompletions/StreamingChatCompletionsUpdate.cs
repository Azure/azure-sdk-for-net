// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.OpenAI;

// CUSTOM CODE NOTE:
//   This entirely custom class provides a merged representation of streaming chat completions server-sent events.

/// <summary>
/// Represents an incremental update to a streamed Chat Completions response.
/// </summary>
public partial class StreamingChatCompletionsUpdate
{
    /// <summary>
    /// Gets a unique identifier associated with this streamed Chat Completions response.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Corresponds to $.id in the underlying REST schema.
    /// </para>
    /// When using Azure OpenAI, note that the values of <see cref="Id"/> and <see cref="Created"/> may not be
    /// populated until the first <see cref="StreamingChatCompletionsUpdate"/> containing role, content, or
    /// function information.
    /// </remarks>
    public string Id { get; }

    /// <summary>
    /// Gets the first timestamp associated with generation activity for this completions response,
    /// represented as seconds since the beginning of the Unix epoch of 00:00 on 1 Jan 1970.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Corresponds to $.created in the underlying REST schema.
    /// </para>
    /// When using Azure OpenAI, note that the values of <see cref="Id"/> and <see cref="Created"/> may not be
    /// populated until the first <see cref="StreamingChatCompletionsUpdate"/> containing role, content, or
    /// function information.
    /// </remarks>
    public DateTimeOffset Created { get; }

    /// <summary>
    /// Gets the <see cref="ChatRole"/> associated with this update.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Corresponds to e.g. $.choices[0].delta.role in the underlying REST schema.
    /// </para>
    /// <see cref="ChatRole"/> assignment typically occurs in a single update across a streamed Chat Completions
    /// choice and the value should be considered to be persist for all subsequent updates without a
    /// <see cref="ChatRole"/> that bear the same <see cref="ChoiceIndex"/>.
    /// </remarks>
    public ChatRole? Role { get; }

    /// <summary>
    /// Gets the content fragment associated with this update.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Corresponds to e.g. $.choices[0].delta.content in the underlying REST schema.
    /// </para>
    /// Each update contains only a small number of tokens. When presenting or reconstituting a full, streamed
    /// response, all <see cref="ContentUpdate"/> values for the same <see cref="ChoiceIndex"/> should be
    /// combined.
    /// </remarks>
    public string ContentUpdate { get; }

    /// <summary>
    /// Gets the name of a function to be called.
    /// </summary>
    /// <remarks>
    /// Corresponds to e.g. $.choices[0].delta.function_call.name in the underlying REST schema.
    /// </remarks>
    public string FunctionName { get; }

    /// <summary>
    /// Gets a function arguments fragment associated with this update.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Corresponds to e.g. $.choices[0].delta.function_call.arguments in the underlying REST schema.
    /// </para>
    ///
    /// <para>
    /// Each update contains only a small number of tokens. When presenting or reconstituting a full, streamed
    /// arguments body, all <see cref="FunctionArgumentsUpdate"/> values for the same <see cref="ChoiceIndex"/>
    /// should be combined.
    /// </para>
    ///
    /// <para>
    /// As is the case for non-streaming <see cref="FunctionCall.Arguments"/>, the content provided for function
    /// arguments is not guaranteed to be well-formed JSON or to contain expected data. Callers should validate
    /// function arguments before using them.
    /// </para>
    /// </remarks>
    public string FunctionArgumentsUpdate { get; }

    /// <summary>
    /// An incremental update payload for a tool call that is part of this response.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Corresponds to e.g. $.choices[0].delta.tool_calls[0].index in the REST API schema.
    /// </para>
    /// <para>
    /// To differentiate between parallel streaming tool calls within a single streaming choice, use the value of the
    /// <see cref="StreamingToolCallUpdate.ToolCallIndex"/> property.
    /// </para>
    /// <para>
    /// Please note <see cref="StreamingToolCallUpdate"/> is the base class. According to the scenario, a derived class
    /// of the base class might need to be assigned here, or this property needs to be casted to one of the possible
    /// derived classes.
    /// The available derived classes include: <see cref="StreamingFunctionToolCallUpdate"/>.
    /// </para>
    /// </remarks>
    public StreamingToolCallUpdate ToolCallUpdate { get; }

    /// <summary>
    /// Gets an optional name associated with the role of the streamed Chat Completion, typically as previously
    /// specified in a system message.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Corresponds to e.g. $.choices[0].delta.name in the underlying REST schema.
    /// </para>
    /// </remarks>
    public string AuthorName { get; }

    /// <summary>
    /// Gets the <see cref="CompletionsFinishReason"/> associated with this update.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Corresponds to e.g. $.choices[0].finish_reason in the underlying REST schema.
    /// </para>
    /// <para>
    /// <see cref="FinishReason"/> assignment typically appears in the final streamed update message associated
    /// with a choice.
    /// </para>
    /// </remarks>
    public CompletionsFinishReason? FinishReason { get; }

    /// <summary>
    /// Gets the choice index associated with this streamed update.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Corresponds to e.g. $.choices[0].index in the underlying REST schema.
    /// </para>
    /// <para>
    /// Unless a value greater than one was provided to <see cref="ChatCompletionsOptions.ChoiceCount"/> ('n' in
    /// REST), only one choice will be generated. In that case, this value will always be 0 and may not need to be
    /// considered.
    /// </para>
    /// <para>
    /// When providing a value greater than one to <see cref="ChatCompletionsOptions.ChoiceCount"/>, this index
    /// identifies which logical response the payload is associated with. In the event that a single underlying
    /// server-sent event contains multiple choices, multiple instances of
    /// <see cref="StreamingChatCompletionsUpdate"/> will be created.
    /// </para>
    /// </remarks>
    public int? ChoiceIndex { get; }

    /// <inheritdoc cref="ChatCompletions.SystemFingerprint"/>
    public string SystemFingerprint { get; }

    /// <summary>
    /// Gets additional data associated with this update that is specific to use with Azure OpenAI and that
    /// service's extended capabilities.
    /// </summary>
    public AzureChatExtensionsMessageContext AzureExtensionsContext { get; }

    internal StreamingChatCompletionsUpdate(
        string id,
        DateTimeOffset created,
        string systemFingerprint = null,
        int? choiceIndex = null,
        ChatRole? role = null,
        string authorName = null,
        string contentUpdate = null,
        CompletionsFinishReason? finishReason = null,
        string functionName = null,
        string functionArgumentsUpdate = null,
        StreamingToolCallUpdate toolCallUpdate = null,
        AzureChatExtensionsMessageContext azureExtensionsContext = null)
    {
        Id = id;
        Created = created;
        SystemFingerprint = systemFingerprint;
        ChoiceIndex = choiceIndex;
        Role = role;
        AuthorName = authorName;
        ContentUpdate = contentUpdate;
        FinishReason = finishReason;
        FunctionName = functionName;
        FunctionArgumentsUpdate = functionArgumentsUpdate;
        ToolCallUpdate = toolCallUpdate;
        AzureExtensionsContext = azureExtensionsContext;
    }
}
