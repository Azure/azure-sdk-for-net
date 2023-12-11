// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace Azure.AI.OpenAI;

/// <summary>
/// Represents an incremental update to a streamed tool call that is part of a streamed chat completions choice.
/// </summary>
/// <remarks>
/// <para>
/// To differentiate between parallel streaming tool calls within a single streaming choice, use the value of the
/// <see cref="ToolCallIndex"/> property.
/// </para>
/// <para>
/// Please note <see cref="StreamingToolCallUpdate"/> is the base class. According to the scenario, a derived class
/// of the base class might need to be assigned here, or this property needs to be casted to one of the possible
/// derived classes.
/// The available derived classes include: <see cref="StreamingFunctionToolCallUpdate"/>.
/// </para>
/// </remarks>
public abstract partial class StreamingToolCallUpdate
{
    /// <summary>
    /// Gets the ID associated with with the streaming tool call.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This value appears once for each streamed tool call, typically on the first update message for each
    /// <see cref="ToolCallIndex"/>. Callers should retain the value when it arrives to accumulate the comlete tool
    /// call information.
    /// </para>
    /// <para>
    /// Tool call IDs must be provided in <see cref="ChatRequestToolMessage"/> instances that respond to tool calls.
    /// </para>
    /// </remarks>
    public string Id { get; }

    /// <summary>
    /// Gets the tool call index associated with this <see cref="StreamingToolCallUpdate"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This value appears on every streaming tool call update. When multiple tool calls occur within the same
    /// streaming chat choice, this index specifies which tool call that this update contains new information for.
    /// </para>
    /// </remarks>
    public int ToolCallIndex { get; }

    internal string Type { get; }

    internal StreamingToolCallUpdate(string type, string id, int toolCallIndex)
    {
        Type = type;
        Id = id;
        ToolCallIndex = toolCallIndex;
    }

    internal abstract void WriteDerivedDetails(Utf8JsonWriter writer);
}
