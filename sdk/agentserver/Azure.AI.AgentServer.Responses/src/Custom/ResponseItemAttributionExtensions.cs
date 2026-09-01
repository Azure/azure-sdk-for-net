// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.Extensions.OpenAI;
using OpenAI.Responses;

#pragma warning disable SCME0001

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Read/write accessors for the Azure agent attribution fields carried on
/// <see cref="ResponseItem"/> (<c>response_id</c>, <c>agent_reference</c> and <c>created_by</c>).
/// </summary>
/// <remarks>
/// <para>
/// <c>Azure.AI.Extensions.OpenAI.ResponseItemExtensions</c> exposes <c>ResponseId</c> and
/// <c>AgentReference</c> as read-only, which suits clients that only consume items. This
/// package is the server side: it <em>produces</em> response items and therefore has to stamp
/// these fields on outgoing items, so it needs setters as well. <c>created_by</c> is not
/// modelled in Extensions at all.
/// </para>
/// <para>
/// These are implemented over the public <see cref="JsonPatch"/> surface, mirroring how
/// Extensions implements its own accessors. If Extensions later exposes settable equivalents,
/// this type should be deleted in favour of them.
/// </para>
/// </remarks>
[Experimental("AAIP002")]
public static class ResponseItemAttributionExtensions
{
    private static readonly ReadOnlyMemory<byte> ResponseIdPath = "$.response_id"u8.ToArray();
    private static readonly ReadOnlyMemory<byte> AgentReferencePath = "$.agent_reference"u8.ToArray();
    private static readonly ReadOnlyMemory<byte> CreatedByPath = "$.created_by"u8.ToArray();
    private static readonly ReadOnlyMemory<byte> AgentSessionIdPath = "$.agent_session_id"u8.ToArray();
    private static readonly ReadOnlyMemory<byte> CompletedAtPath = "$.completed_at"u8.ToArray();
    private static readonly ReadOnlyMemory<byte> ItemIdPath = "$.item_id"u8.ToArray();
    private static readonly ReadOnlyMemory<byte> OutputIndexPath = "$.output_index"u8.ToArray();
    private static readonly ReadOnlyMemory<byte> DeltaPath = "$.delta"u8.ToArray();
    private static readonly ReadOnlyMemory<byte> InputPath = "$.input"u8.ToArray();
    private static readonly ReadOnlyMemory<byte> StatusPath = "$.status"u8.ToArray();

    extension(ResponseItem item)
    {
        /// <summary> Gets or sets the ID of the response that the item belongs to. </summary>
        public string? ResponseId
        {
            get => GetString(ref item.Patch, ResponseIdPath.Span);
            set => SetOrClear(ref item.Patch, ResponseIdPath.Span, value);
        }

        /// <summary> Gets or sets the agent that created the item. </summary>
        public AgentReference? AgentReference
        {
            get => GetJsonModel<AgentReference>(ref item.Patch, AgentReferencePath.Span);
            set => SetOrClear(ref item.Patch, AgentReferencePath.Span, value);
        }

        /// <summary> Gets or sets the information about the creator of the item. </summary>
        public BinaryData? CreatedBy
        {
            get => GetBinaryData(ref item.Patch, CreatedByPath.Span);
            set => SetOrClear(ref item.Patch, CreatedByPath.Span, value);
        }
    }

    extension(ResponseResult response)
    {
        /// <summary> Gets or sets the agent session that produced the response. </summary>
        public string? AgentSessionId
        {
            get => GetString(ref response.Patch, AgentSessionIdPath.Span);
            set => SetOrClear(ref response.Patch, AgentSessionIdPath.Span, value);
        }

        /// <summary> Gets or sets the agent that produced the response. </summary>
        public AgentReference? AgentReference
        {
            get => GetJsonModel<AgentReference>(ref response.Patch, AgentReferencePath.Span);
            set => SetOrClear(ref response.Patch, AgentReferencePath.Span, value);
        }

        /// <summary> Gets or sets the time at which the response reached a terminal state. </summary>
        public DateTimeOffset? CompletedAt
        {
            get => GetUnixTime(ref response.Patch, CompletedAtPath.Span);
            set => SetOrClearUnixTime(ref response.Patch, CompletedAtPath.Span, value);
        }
    }

    extension(CreateResponseOptions options)
    {
        /// <summary> Gets or sets the agent session to run the response in. </summary>
        public string? AgentSessionId
        {
            get => GetString(ref options.Patch, AgentSessionIdPath.Span);
            set => SetOrClear(ref options.Patch, AgentSessionIdPath.Span, value);
        }

        /// <summary> Gets or sets the agent that should serve the response. </summary>
        public AgentReference? AgentReference
        {
            get => GetJsonModel<AgentReference>(ref options.Patch, AgentReferencePath.Span);
            set => SetOrClear(ref options.Patch, AgentReferencePath.Span, value);
        }
    }

    extension(StreamingResponseUpdate update)
    {
        /// <summary> Gets or sets the <c>item_id</c> carried by updates that do not model it directly. </summary>
        public string? ItemId
        {
            get => GetString(ref update.Patch, ItemIdPath.Span);
            set => SetOrClear(ref update.Patch, ItemIdPath.Span, value);
        }

        /// <summary> Gets or sets the <c>output_index</c> carried by updates that do not model it directly. </summary>
        public int OutputIndex
        {
            get => GetInt32(ref update.Patch, OutputIndexPath.Span) ?? 0;
            set => update.Patch.Set(OutputIndexPath.Span, value);
        }

        /// <summary> Gets or sets the <c>delta</c> carried by updates that do not model it directly. </summary>
        public string? Delta
        {
            get => GetString(ref update.Patch, DeltaPath.Span);
            set => SetOrClear(ref update.Patch, DeltaPath.Span, value);
        }

        /// <summary> Gets or sets the <c>input</c> carried by updates that do not model it directly. </summary>
        public string? Input
        {
            get => GetString(ref update.Patch, InputPath.Span);
            set => SetOrClear(ref update.Patch, InputPath.Span, value);
        }
    }

    extension(McpToolCallItem mcpCall)
    {
        /// <summary> Gets or sets the call status, which OpenAI does not model on this item. </summary>
        public string? Status
        {
            get => GetString(ref mcpCall.Patch, StatusPath.Span);
            set => SetOrClear(ref mcpCall.Patch, StatusPath.Span, value);
        }
    }

    private static int? GetInt32(ref JsonPatch patch, ReadOnlySpan<byte> path)
        => patch.IsRemoved(path) || !patch.TryGetJson(path, out ReadOnlyMemory<byte> json) || json.IsEmpty
            ? null
            : patch.GetInt32(path);

    private static DateTimeOffset? GetUnixTime(ref JsonPatch patch, ReadOnlySpan<byte> path)
    {
        var seconds = GetInt64(ref patch, path);
        return seconds is null ? null : DateTimeOffset.FromUnixTimeSeconds(seconds.Value);
    }

    private static long? GetInt64(ref JsonPatch patch, ReadOnlySpan<byte> path)
        => patch.IsRemoved(path) || !patch.TryGetJson(path, out ReadOnlyMemory<byte> json) || json.IsEmpty
            ? null
            : patch.GetInt64(path);

    private static void SetOrClearUnixTime(ref JsonPatch patch, ReadOnlySpan<byte> path, DateTimeOffset? value)
    {
        if (value is null)
        {
            patch.Remove(path);
        }
        else
        {
            patch.Set(path, value.Value.ToUnixTimeSeconds());
        }
    }

    private static string? GetString(ref JsonPatch patch, ReadOnlySpan<byte> path)
        => patch.IsRemoved(path) || !patch.TryGetJson(path, out ReadOnlyMemory<byte> json) || json.IsEmpty
            ? null
            : patch.GetString(path);

    private static BinaryData? GetBinaryData(ref JsonPatch patch, ReadOnlySpan<byte> path)
        => patch.IsRemoved(path) || !patch.TryGetJson(path, out ReadOnlyMemory<byte> json) || json.IsEmpty
            ? null
            : BinaryData.FromBytes(json);

    private static T? GetJsonModel<T>(ref JsonPatch patch, ReadOnlySpan<byte> path)
        where T : class, IJsonModel<T>
    {
        if (patch.IsRemoved(path) || !patch.TryGetJson(path, out ReadOnlyMemory<byte> json) || json.IsEmpty)
        {
            return null;
        }

        return ModelReaderWriter.Read<T>(
            BinaryData.FromBytes(json),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default);
    }

    private static void SetOrClear(ref JsonPatch patch, ReadOnlySpan<byte> path, string? value)
    {
        if (value is null)
        {
            patch.Remove(path);
        }
        else
        {
            patch.Set(path, value);
        }
    }

    private static void SetOrClear(ref JsonPatch patch, ReadOnlySpan<byte> path, BinaryData? value)
    {
        if (value is null)
        {
            patch.Remove(path);
        }
        else
        {
            patch.Set(path, value.ToMemory().Span);
        }
    }

    private static void SetOrClear<T>(ref JsonPatch patch, ReadOnlySpan<byte> path, T? value)
        where T : class, IJsonModel<T>
    {
        if (value is null)
        {
            patch.Remove(path);
        }
        else
        {
            patch.Set(
                path,
                ModelReaderWriter.Write(value, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default).ToMemory().Span);
        }
    }
}
