// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.ChatProtocol;

internal static class StreamReaderExtensions
{
    internal static bool TryReadLine(this StreamReader reader, out string line)
    {
        line = reader.ReadLine();
        return line != null;
    }

    internal static async Task<string?> ReadLineAsync(this StreamReader reader, CancellationToken cancellationToken = default)
    {
        return await reader.ReadLineAsync()
            .ContinueWith(t => t.Result, cancellationToken)
            .ConfigureAwait(false);
    }
}

public partial class ChatProtocolClient
{
    private static async IAsyncEnumerable<ChatCompletionChunk> GetStreamingEnumerableAsync(Response response, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using (response)
        {
            using StreamReader reader = new(response.ContentStream);
            string? line;
            while ((line = await reader.ReadLineAsync(cancellationToken).ConfigureAwait(false)) != null)
            {
                using JsonDocument json = JsonDocument.Parse(line);
                ChatCompletionChunk item = ChatCompletionChunk.DeserializeChatCompletionChunk(json.RootElement);
                yield return item;
            }
        }
    }

    private static IEnumerable<ChatCompletionChunk> GetStreamingEnumerable(Response response)
    {
        using (response)
        {
            using StreamReader reader = new(response.ContentStream);
            while (reader.TryReadLine(out var line))
            {
                using JsonDocument json = JsonDocument.Parse(line);
                ChatCompletionChunk item = ChatCompletionChunk.DeserializeChatCompletionChunk(json.RootElement);
                yield return item;
            }
        }
    }

    /// <summary> Creates a new streaming chat completion.</summary>
    /// <param name="streamingChatCompletionOptions"> The configuration for a streaming chat completion request. </param>
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

    /// <summary> Creates a new streaming chat completion.</summary>
    /// <param name="streamingChatCompletionOptions"> The configuration for a streaming chat completion request. </param>
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

    /// <summary> Creates a new chat completion. </summary>
    /// <param name="chatCompletionOptions"> The configuration for a chat completion request. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="chatCompletionOptions"/> is null. </exception>
    public virtual async Task<Response<ChatCompletion>> CreateAsync(ChatCompletionOptions chatCompletionOptions, CancellationToken cancellationToken = default)
    {
        // https://github.com/Azure/autorest.csharp/issues/3880
        Argument.AssertNotNull(chatCompletionOptions, nameof(chatCompletionOptions));

        RequestContext context = FromCancellationToken(cancellationToken);
        using RequestContent content = chatCompletionOptions.ToRequestContent();
        Response response = await CreateAsync(content, context).ConfigureAwait(false);
        return Response.FromValue(ChatCompletion.FromResponse(response), response);
    }

    /// <summary> Creates a new chat completion. </summary>
    /// <param name="chatCompletionOptions"> The configuration for a chat completion request. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="chatCompletionOptions"/> is null. </exception>
    public virtual Response<ChatCompletion> Create(ChatCompletionOptions chatCompletionOptions, CancellationToken cancellationToken = default)
    {
        // https://github.com/Azure/autorest.csharp/issues/3880
        Argument.AssertNotNull(chatCompletionOptions, nameof(chatCompletionOptions));

        RequestContext context = FromCancellationToken(cancellationToken);
        using RequestContent content = chatCompletionOptions.ToRequestContent();
        Response response = Create(content, context);
        return Response.FromValue(ChatCompletion.FromResponse(response), response);
    }
}
