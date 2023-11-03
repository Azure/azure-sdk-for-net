// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

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

[CodeGenSuppress("CreateStreamingAsync", typeof(string), typeof(StreamingChatCompletionOptions), typeof(CancellationToken))]
[CodeGenSuppress("CreateStreaming", typeof(string), typeof(StreamingChatCompletionOptions), typeof(CancellationToken))]
[CodeGenSuppress("CreateAsync", typeof(string), typeof(ChatCompletionOptions), typeof(CancellationToken))]
[CodeGenSuppress("Create", typeof(string), typeof(ChatCompletionOptions), typeof(CancellationToken))]
public partial class ChatProtocolClient
{
    private readonly string _chatRoute;

    /// <summary> Initializes a new instance of ChatProtocolClient. </summary>
    /// <param name="endpoint"> The Uri to use. </param>
    /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
    /// <param name="options"> The options for configuring the client. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
    public ChatProtocolClient(Uri endpoint, AzureKeyCredential credential, ChatProtocolClientOptions options)
    {
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        Argument.AssertNotNull(credential, nameof(credential));
        options ??= new ChatProtocolClientOptions();

        ClientDiagnostics = new ClientDiagnostics(options, true);
        _keyCredential = credential;
        _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, options.APIKeyHeader ?? AuthorizationHeader) }, new ResponseClassifier());
        _endpoint = endpoint;
        _apiVersion = options.Version;
        _chatRoute = options.ChatRoute;
    }

    /// <summary> Initializes a new instance of ChatProtocolClient. </summary>
    /// <param name="endpoint"> The Uri to use. </param>
    /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
    /// <param name="options"> The options for configuring the client. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
    public ChatProtocolClient(Uri endpoint, TokenCredential credential, ChatProtocolClientOptions options)
    {
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        Argument.AssertNotNull(credential, nameof(credential));
        options ??= new ChatProtocolClientOptions();

        ClientDiagnostics = new ClientDiagnostics(options, true);
        _tokenCredential = credential;
        _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, options.AuthorizationScopes ?? AuthorizationScopes) }, new ResponseClassifier());
        _endpoint = endpoint;
        _apiVersion = options.Version;
        _chatRoute = options.ChatRoute;
    }

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
        Response response = await CreateStreamingAsync(_chatRoute, streamingChatCompletionOptions.ToRequestContent(), context).ConfigureAwait(false);
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
        Response response = CreateStreaming(_chatRoute, streamingChatCompletionOptions.ToRequestContent(), context);
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
        Response response = await CreateAsync(_chatRoute, content, context).ConfigureAwait(false);
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
        Response response = Create(_chatRoute, content, context);
        return Response.FromValue(ChatCompletion.FromResponse(response), response);
    }
}
