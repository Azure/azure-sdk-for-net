// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Constructs OpenAI response models that expose no accessible constructor.
/// </summary>
/// <remarks>
/// Several <c>OpenAI.Responses</c> models (notably <see cref="OpenAI.Responses.ResponseError"/> and
/// <see cref="ResponseIncompleteStatusDetails"/>) declare every constructor <c>internal</c>
/// and every property get-only, because the OpenAI library only ever materializes them
/// while reading a service response. This server implementation has to produce them, so
/// they are round-tripped through the public model-reader instead.
/// </remarks>
[Experimental("AAIP002")]
internal static class OpenAIModelFactory
{
    /// <summary>
    /// Reads an <see cref="OpenAI.Responses.ResponseToolChoice"/> from its wire form.
    /// </summary>
    /// <param name="json">The serialized tool choice.</param>
    /// <returns>The deserialized tool choice.</returns>
    public static OpenAI.Responses.ResponseToolChoice? ReadToolChoice(BinaryData json)
    {
        // The source-generated model context does not emit a builder for this type, so the
        // reflection-based overload is the only one that can materialize it. The package is
        // not trim/AOT-annotated, so the analyzer's AOT concern does not apply here.
#pragma warning disable AZC0150
        return ModelReaderWriter.Read<OpenAI.Responses.ResponseToolChoice>(json);
#pragma warning restore AZC0150
    }

    /// <summary>Creates a <see cref="OpenAI.Responses.ResponseError"/> with the supplied code and message.</summary>
    /// <param name="code">The error code written to <c>code</c>.</param>
    /// <param name="message">The human readable error message.</param>
    /// <param name="param">The offending request parameter, when known.</param>
    /// <param name="kind">The error category written to <c>type</c>.</param>
    /// <returns>A populated <see cref="OpenAI.Responses.ResponseError"/>.</returns>
    public static OpenAI.Responses.ResponseError CreateError(string? code, string? message, string? param = null, string? kind = null)
        => Read<OpenAI.Responses.ResponseError>(writer =>
        {
            writer.WriteStartObject();
            writer.WriteString("code"u8, code ?? ResponseErrorCode.ServerError.ToString());
            writer.WriteString("message"u8, message ?? string.Empty);
            if (param is not null)
            {
                writer.WriteString("param"u8, param);
            }

            if (kind is not null)
            {
                writer.WriteString("type"u8, kind);
            }

            writer.WriteEndObject();
        });

    /// <summary>Creates a <see cref="ResponseIncompleteStatusDetails"/> with the supplied reason.</summary>
    /// <param name="reason">The reason the response is incomplete.</param>
    /// <returns>A populated <see cref="ResponseIncompleteStatusDetails"/>.</returns>
    public static ResponseIncompleteStatusDetails CreateIncompleteDetails(string? reason)
        => Read<ResponseIncompleteStatusDetails>(writer =>
        {
            writer.WriteStartObject();
            if (reason is not null)
            {
                writer.WriteString("reason"u8, reason);
            }

            writer.WriteEndObject();
        });

    /// <summary>
    /// Creates a <see cref="StreamingResponseUpdate"/> for an event kind that the OpenAI library
    /// models only as the shared base type.
    /// </summary>
    /// <param name="type">The <c>type</c> discriminator of the SSE event.</param>
    /// <param name="sequenceNumber">The value of <c>sequence_number</c>.</param>
    /// <param name="writeAdditionalProperties">Writes the event-specific properties.</param>
    /// <returns>A populated <see cref="StreamingResponseUpdate"/>.</returns>
    /// <remarks>
    /// A handful of event kinds (the audio events and the custom-tool-call input events) have no
    /// dedicated <c>Streaming*Update</c> subclass. They cannot be subclassed here either, because
    /// <see cref="StreamingResponseUpdate"/>'s only constructor is <c>private protected</c>. The
    /// event is therefore materialized from its wire form; the properties remain reachable through
    /// <c>Patch</c>.
    /// </remarks>
    public static StreamingResponseUpdate CreateStreamingUpdate(
        string type,
        int sequenceNumber,
        Action<Utf8JsonWriter>? writeAdditionalProperties = null)
        => Read<StreamingResponseUpdate>(writer =>
        {
            writer.WriteStartObject();
            writer.WriteString("type"u8, type);
            writer.WriteNumber("sequence_number"u8, sequenceNumber);
            writeAdditionalProperties?.Invoke(writer);
            writer.WriteEndObject();
        });

    private static T Read<T>(Action<Utf8JsonWriter> write)
        where T : class, IJsonModel<T>
    {
        using var stream = new System.IO.MemoryStream();
        using (var writer = new Utf8JsonWriter(stream))
        {
            write(writer);
        }

        return ModelReaderWriter.Read<T>(
            BinaryData.FromBytes(stream.ToArray()),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;
    }
}
