// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.ChatProtocol;

public partial class ChatProtocolClient
{
    private static async IAsyncEnumerable<ChatCompletionChunk> GetStreamingEnumerableAsync(Response response)
    {
        using SseReader reader = new(response.ContentStream);
        while (true)
        {
            SseLine? sseEvent = await reader.TryReadSingleFieldEventAsync().ConfigureAwait(false);
            if (sseEvent == null)
            {
                break;
            }

            ReadOnlyMemory<char> name = sseEvent.Value.FieldName;

            if (!name.Span.SequenceEqual("data".AsSpan()))
            {
                throw new InvalidDataException();
            }

            ReadOnlyMemory<char> value = sseEvent.Value.FieldValue;
            if (value.Span.SequenceEqual("[DONE]".AsSpan()))
            {
                break;
            }

            using JsonDocument sseMessageJson = JsonDocument.Parse(sseEvent.Value.FieldValue);
            ChatCompletionChunk item = ChatCompletionChunk.DeserializeChatCompletionChunk(sseMessageJson.RootElement);
            yield return item;
        }
    }

    private static IEnumerable<ChatCompletionChunk> GetStreamingEnumerable(Response response)
    {
        using SseReader reader = new(response.ContentStream);
        while (true)
        {
            SseLine? sseEvent = reader.TryReadSingleFieldEvent();
            if (sseEvent == null)
            {
                break;
            }

            ReadOnlyMemory<char> name = sseEvent.Value.FieldName;
            if (!name.Span.SequenceEqual("data".AsSpan()))
            {
                throw new InvalidDataException();
            }

            ReadOnlyMemory<char> value = sseEvent.Value.FieldValue;
            if (value.Span.SequenceEqual("[DONE]".AsSpan()))
            {
                break;
            }

            using JsonDocument sseMessageJson = JsonDocument.Parse(sseEvent.Value.FieldValue);
            ChatCompletionChunk item = ChatCompletionChunk.DeserializeChatCompletionChunk(sseMessageJson.RootElement);
            yield return item;
        }
    }

    /// <summary> placeholder. </summary>
    /// <param name="streamingChatCompletionOptions"> placeholder. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="streamingChatCompletionOptions"/> is null. </exception>
    public virtual async Task<Response<IAsyncEnumerable<ChatCompletionChunk>>> CreateStreamingAsync(StreamingChatCompletionOptions streamingChatCompletionOptions, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(streamingChatCompletionOptions, nameof(streamingChatCompletionOptions));

        RequestContext context = FromCancellationToken(cancellationToken);
        Response response = await CreateStreamingAsync(streamingChatCompletionOptions.ToRequestContent(), context).ConfigureAwait(false);
        IAsyncEnumerable<ChatCompletionChunk> value = GetStreamingEnumerableAsync(response);
        // IAsyncEnumerable<ChatCompletionChunk> value = new SSEStream<ChatCompletionChunk>(response, ChatCompletionChunk.DeserializeChatCompletionChunk);
        return Response.FromValue(value, response);
    }

    /// <summary> placeholder. </summary>
    /// <param name="streamingChatCompletionOptions"> placeholder. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="streamingChatCompletionOptions"/> is null. </exception>
    public virtual Response<IEnumerable<ChatCompletionChunk>> CreateStreaming(StreamingChatCompletionOptions streamingChatCompletionOptions, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(streamingChatCompletionOptions, nameof(streamingChatCompletionOptions));

        RequestContext context = FromCancellationToken(cancellationToken);
        Response response = CreateStreaming(streamingChatCompletionOptions.ToRequestContent(), context);
        IEnumerable<ChatCompletionChunk> value = GetStreamingEnumerable(response);
        return Response.FromValue(value, response);
    }
}
