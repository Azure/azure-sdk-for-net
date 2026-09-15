// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Creates asynchronous streaming results for established service responses.
/// </summary>
/// <remarks>
/// The supplied <see cref="PipelineResponse"/> must already be established and
/// have a non-null <see cref="PipelineResponse.ContentStream"/>. Factories do
/// not send a request or process response establishment errors.
/// </remarks>
[Experimental("SCME0005")]
public static class AsyncStreamingClientResult
{
    private const int DefaultJsonLineLengthLimit = 1024 * 1024 * 1024;

    /// <summary>
    /// Creates a result whose values are produced from the response content stream.
    /// </summary>
    /// <typeparam name="T">The type of values in the stream.</typeparam>
    /// <param name="response">An established response containing the stream.</param>
    /// <param name="producer">The function that reads values from the stream.
    /// The producer must observe cancellation or stream closure. Otherwise,
    /// <see cref="AsyncStreamingClientResult{T}.DisposeAsync"/> can wait indefinitely
    /// for an active read to complete.</param>
    /// <param name="operationCancellationToken">The cancellation token for the operation.</param>
    /// <returns>A one-shot asynchronous streaming result.</returns>
    public static AsyncStreamingClientResult<T> Create<T>(
        PipelineResponse response,
        Func<Stream, CancellationToken, IAsyncEnumerable<T>> producer,
        CancellationToken operationCancellationToken = default)
    {
        Argument.AssertNotNull(response, nameof(response));
        Argument.AssertNotNull(producer, nameof(producer));
        return new(response, producer, operationCancellationToken);
    }

    /// <summary>
    /// Creates a result that parses server-sent events.
    /// </summary>
    /// <typeparam name="T">The type of data in each event.</typeparam>
    /// <param name="response">An established response containing the stream.</param>
    /// <param name="itemParser">The parser for each event payload.</param>
    /// <param name="isTerminal">An optional predicate that receives each raw
    /// <c>SseItem&lt;BinaryData&gt;</c> and identifies the terminal event from
    /// its envelope and payload before
    /// <paramref name="itemParser"/> is invoked.
    /// The terminal event is not returned. If provided, reaching the end of the
    /// stream before a terminal event throws <see cref="InvalidDataException"/>.</param>
    /// <param name="operationCancellationToken">The cancellation token for the operation.</param>
    /// <returns>A one-shot asynchronous streaming result.</returns>
    public static AsyncStreamingClientResult<SseItem<T>> CreateSse<T>(
        PipelineResponse response,
        SseItemParser<T> itemParser,
        Func<SseItem<BinaryData>, bool>? isTerminal = null,
        CancellationToken operationCancellationToken = default)
    {
        Argument.AssertNotNull(itemParser, nameof(itemParser));
        return Create(
            response,
            (stream, cancellationToken) =>
                ParseSse(stream, itemParser, isTerminal, cancellationToken),
            operationCancellationToken);
    }

    /// <summary>
    /// Creates a result that parses raw server-sent events.
    /// </summary>
    /// <param name="response">An established response containing the stream.</param>
    /// <param name="isTerminal">An optional predicate identifying the terminal event.
    /// The terminal event is not returned. If provided, reaching the end of the
    /// stream before a terminal event throws <see cref="InvalidDataException"/>.</param>
    /// <param name="operationCancellationToken">The cancellation token for the operation.</param>
    /// <returns>A one-shot asynchronous streaming result.</returns>
    public static AsyncStreamingClientResult<SseItem<BinaryData>> CreateSse(
        PipelineResponse response,
        Func<SseItem<BinaryData>, bool>? isTerminal = null,
        CancellationToken operationCancellationToken = default)
    {
        return Create(
            response,
            (stream, cancellationToken) =>
                ParseRawSse(stream, isTerminal, cancellationToken),
            operationCancellationToken);
    }

    /// <summary>
    /// Creates a result that parses newline-delimited JSON values.
    /// </summary>
    /// <typeparam name="T">The type of parsed values.</typeparam>
    /// <param name="response">An established response containing the stream.</param>
    /// <param name="itemParser">The parser for each JSON line.</param>
    /// <param name="operationCancellationToken">The cancellation token for the operation.</param>
    /// <returns>A one-shot asynchronous streaming result.</returns>
    public static AsyncStreamingClientResult<T> CreateJsonLines<T>(
        PipelineResponse response,
        Func<BinaryData, T> itemParser,
        CancellationToken operationCancellationToken = default)
        => CreateJsonLines(
            response,
            itemParser,
            DefaultJsonLineLengthLimit,
            operationCancellationToken);

    internal static AsyncStreamingClientResult<T> CreateJsonLines<T>(
        PipelineResponse response,
        Func<BinaryData, T> itemParser,
        int maxLineLength,
        CancellationToken operationCancellationToken = default)
    {
        Argument.AssertNotNull(itemParser, nameof(itemParser));
        Argument.AssertInRange(
            maxLineLength,
            1,
            DefaultJsonLineLengthLimit,
            nameof(maxLineLength));
        return Create(
            response,
            (stream, cancellationToken) =>
                ParseJsonLines(
                    stream,
                    itemParser,
                    maxLineLength,
                    cancellationToken),
            operationCancellationToken);
    }

    /// <summary>
    /// Creates a result that parses raw newline-delimited JSON values.
    /// </summary>
    /// <param name="response">An established response containing the stream.</param>
    /// <param name="operationCancellationToken">The cancellation token for the operation.</param>
    /// <returns>A one-shot asynchronous streaming result.</returns>
    public static AsyncStreamingClientResult<BinaryData> CreateJsonLines(
        PipelineResponse response,
        CancellationToken operationCancellationToken = default)
        => CreateJsonLines(response, static data => data, operationCancellationToken);

    private static async IAsyncEnumerable<SseItem<T>> ParseSse<T>(
        Stream stream,
        SseItemParser<T> itemParser,
        Func<SseItem<BinaryData>, bool>? isTerminal,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (isTerminal is null)
        {
            SseParser<T> parser = SseParser.Create(stream, itemParser);
            await foreach (SseItem<T> item in
                parser.EnumerateAsync(cancellationToken).ConfigureAwait(false))
            {
                yield return item;
            }
            yield break;
        }

        await foreach (SseItem<BinaryData> item in
            ParseRawSse(stream, isTerminal, cancellationToken)
                .ConfigureAwait(false))
        {
            T data = itemParser(item.EventType, item.Data.ToMemory().Span);
            yield return new SseItem<T>(data, item.EventType)
            {
                EventId = item.EventId,
                ReconnectionInterval = item.ReconnectionInterval
            };
        }
    }

    private static async IAsyncEnumerable<SseItem<BinaryData>> ParseRawSse(
        Stream stream,
        Func<SseItem<BinaryData>, bool>? isTerminal,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        SseParser<BinaryData> parser = SseParser.Create(
            stream,
            static (_, data) => BinaryData.FromBytes(data.ToArray()));
        await foreach (SseItem<BinaryData> item in
            parser.EnumerateAsync(cancellationToken).ConfigureAwait(false))
        {
            if (isTerminal?.Invoke(item) == true)
            {
                yield break;
            }

            yield return item;
        }

        if (isTerminal is not null)
        {
            throw new InvalidDataException(
                "The server-sent event stream ended before the terminal event was received.");
        }
    }

    private static async IAsyncEnumerable<T> ParseJsonLines<T>(
        Stream stream,
        Func<BinaryData, T> itemParser,
        int maxLineLength,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        byte[] buffer = new byte[4096];
        using MemoryStream line = new();
        bool isFirstLine = true;

        while (true)
        {
            int bytesRead = await stream.ReadAsync(
                buffer,
                0,
                buffer.Length,
                cancellationToken).ConfigureAwait(false);

            if (bytesRead == 0)
            {
                if (TryGetJsonLine(
                    line,
                    isFirstLine,
                    out BinaryData? data))
                {
                    yield return itemParser(data!);
                }
                yield break;
            }

            int segmentStart = 0;
            for (int i = 0; i < bytesRead; i++)
            {
                if (buffer[i] != (byte)'\n')
                {
                    continue;
                }

                AppendJsonLineBytes(
                    line,
                    buffer,
                    segmentStart,
                    i - segmentStart,
                    maxLineLength);
                if (TryGetJsonLine(
                    line,
                    isFirstLine,
                    out BinaryData? data))
                {
                    yield return itemParser(data!);
                }
                isFirstLine = false;
                line.SetLength(0);
                segmentStart = i + 1;
            }

            AppendJsonLineBytes(
                line,
                buffer,
                segmentStart,
                bytesRead - segmentStart,
                maxLineLength);
        }
    }

    private static void AppendJsonLineBytes(
        MemoryStream line,
        byte[] buffer,
        int offset,
        int count,
        int maxLineLength)
    {
        if (line.Length + count > maxLineLength)
        {
            throw new InvalidDataException(
                $"A JSON line exceeded the maximum length of {maxLineLength} bytes.");
        }

        line.Write(buffer, offset, count);
    }

    private static bool TryGetJsonLine(
        MemoryStream line,
        bool isFirstLine,
        out BinaryData? data)
    {
        if (!line.TryGetBuffer(out ArraySegment<byte> bytes))
        {
            throw new InvalidOperationException(
                "The JSON line buffer could not be accessed.");
        }

        int offset = bytes.Offset;
        int count = bytes.Count;
        byte[] buffer = bytes.Array!;
        if (isFirstLine &&
            count >= 3 &&
            buffer[offset] == 0xEF &&
            buffer[offset + 1] == 0xBB &&
            buffer[offset + 2] == 0xBF)
        {
            offset += 3;
            count -= 3;
        }

        if (count > 0 && buffer[offset + count - 1] == (byte)'\r')
        {
            count--;
        }

        bool isWhitespace = true;
        for (int i = 0; i < count; i++)
        {
            byte value = buffer[offset + i];
            if (value != (byte)' ' && (value < (byte)'\t' || value > (byte)'\r'))
            {
                isWhitespace = false;
                break;
            }
        }

        if (isWhitespace)
        {
            data = null;
            return false;
        }

        byte[] payload = new byte[count];
        Buffer.BlockCopy(buffer, offset, payload, 0, count);
        data = BinaryData.FromBytes(payload);
        return true;
    }
}
