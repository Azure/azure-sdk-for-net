// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Sse;

namespace Azure.AI.OpenAI;

public partial class OpenAIClient
{
    // CUSTOM CODE NOTE:
    //   This file is the central hub of .NET client customization for Azure OpenAI.

    private const string PublicOpenAIApiVersion = "1";
    private const string PublicOpenAIEndpoint = $"https://api.openai.com/v{PublicOpenAIApiVersion}";

    private bool _isConfiguredForAzureOpenAI = true;

    /// <summary>
    ///     Initializes a instance of OpenAIClient for use with an Azure OpenAI resource.
    /// </summary>
    ///  <param name="endpoint">
    ///     The URI for an Azure OpenAI resource as retrieved from, for example, Azure Portal.
    ///     This should include protocol and hostname. An example could be:
    ///     https://my-resource.openai.azure.com .
    /// </param>
    /// <param name="keyCredential"> A key credential used to authenticate to an Azure OpenAI resource. </param>
    /// <param name="options"> The options for configuring the client. </param>
    /// <remarks>
    ///     <see cref="OpenAIClient"/> objects initialized with this constructor can only be used with Azure OpenAI
    ///     resources. To use <see cref="OpenAIClient"/> with the non-Azure OpenAI inference endpoint, use a
    ///     constructor that accepts a non-Azure OpenAI API key, instead.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="endpoint"/> or <paramref name="keyCredential"/> is null.
    /// </exception>
    public OpenAIClient(Uri endpoint, AzureKeyCredential keyCredential, OpenAIClientOptions options)
    {
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        Argument.AssertNotNull(keyCredential, nameof(keyCredential));
        options ??= new OpenAIClientOptions();

        ClientDiagnostics = new ClientDiagnostics(options, true);
        _keyCredential = keyCredential;
        _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    /// <inheritdoc cref="OpenAIClient(Uri, AzureKeyCredential, OpenAIClientOptions)"/>
    public OpenAIClient(Uri endpoint, AzureKeyCredential keyCredential)
        : this(endpoint, keyCredential, new OpenAIClientOptions())
    {
    }

    /// <summary>
    ///     <inheritdoc
    ///         cref="OpenAIClient(Uri, AzureKeyCredential, OpenAIClientOptions)"
    ///         path="/summary"/>
    /// </summary>
    /// <param name="endpoint">
    ///     <inheritdoc
    ///         cref="OpenAIClient(Uri, AzureKeyCredential, OpenAIClientOptions)"
    ///         path="/param[@name='endpoint']"/>
    /// </param>
    /// <param name="options">
    ///     <inheritdoc
    ///         cref="OpenAIClient(Uri, AzureKeyCredential, OpenAIClientOptions)"
    ///         path="/param[@name='options']"/>
    /// </param>
    /// <param name="tokenCredential"> A token credential used to authenticate with an Azure OpenAI resource. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="endpoint"/> or <paramref name="tokenCredential"/> is null.
    /// </exception>
    public OpenAIClient(Uri endpoint, TokenCredential tokenCredential, OpenAIClientOptions options)
    {
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));
        options ??= new OpenAIClientOptions();

        ClientDiagnostics = new ClientDiagnostics(options, true);
        _tokenCredential = tokenCredential;
        _pipeline = HttpPipelineBuilder.Build(
            options,
            Array.Empty<HttpPipelinePolicy>(),
            new HttpPipelinePolicy[] {
                new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes)
            },
            new ResponseClassifier());
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    /// <inheritdoc cref="OpenAIClient(Uri, TokenCredential, OpenAIClientOptions)"/>
    public OpenAIClient(Uri endpoint, TokenCredential tokenCredential)
        : this(endpoint, tokenCredential, new OpenAIClientOptions())
    {
    }

    /// <summary>
    ///     Initializes a instance of OpenAIClient for use with the non-Azure OpenAI endpoint.
    /// </summary>
    /// <param name="openAIApiKey">
    ///     The API key to use when connecting to the non-Azure OpenAI endpoint.
    /// </param>
    /// <param name="options"> The options for configuring the client. </param>
    /// <remarks>
    ///     <see cref="OpenAIClient"/> objects initialized with this constructor can only be used with the
    ///     non-Azure OpenAI inference endpoint. To use <see cref="OpenAIClient"/> with an Azure OpenAI resource,
    ///     use a constructor that accepts a resource URI and Azure authentication credential, instead.
    /// </remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="openAIApiKey"/> is null. </exception>
    public OpenAIClient(string openAIApiKey, OpenAIClientOptions options)
        : this(new Uri(PublicOpenAIEndpoint), CreateDelegatedToken(openAIApiKey), options)
    {
        _isConfiguredForAzureOpenAI = false;
    }

    /// <inheritdoc cref="OpenAIClient(string, OpenAIClientOptions)"/>
    public OpenAIClient(string openAIApiKey)
        : this(new Uri(PublicOpenAIEndpoint), CreateDelegatedToken(openAIApiKey), new OpenAIClientOptions())
    {
        _isConfiguredForAzureOpenAI = false;
    }

    /// <summary> Return textual completions as configured for a given prompt. </summary>
    /// <param name="completionsOptions">
    ///     The options for this completions request.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="completionsOptions"/> or <paramref name="completionsOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="completionsOptions.DeploymentName"/> is an empty string.
    /// </exception>
    public virtual Response<Completions> GetCompletions(
        CompletionsOptions completionsOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));
        Argument.AssertNotNullOrEmpty(completionsOptions.DeploymentName, nameof(completionsOptions.DeploymentName));

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletions");
        scope.Start();

        completionsOptions.InternalShouldStreamResponse = null;

        RequestContent content = completionsOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);

        try
        {
            using HttpMessage message = CreatePostRequestMessage(completionsOptions, content, context);
            Response response = _pipeline.ProcessMessage(message, context, cancellationToken);
            return Response.FromValue(Completions.FromResponse(response), response);
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary> Return textual completions as configured for a given prompt. </summary>
    /// <param name="completionsOptions">
    ///     The options for this completions request.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="completionsOptions"/> or <paramref name="completionsOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="completionsOptions.DeploymentName"/> is an empty string.
    /// </exception>
    public virtual async Task<Response<Completions>> GetCompletionsAsync(
        CompletionsOptions completionsOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));
        Argument.AssertNotNullOrEmpty(completionsOptions.DeploymentName, nameof(completionsOptions.DeploymentName));

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletions");
        scope.Start();

        completionsOptions.InternalShouldStreamResponse = null;

        RequestContent content = completionsOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);

        try
        {
            using HttpMessage message = CreatePostRequestMessage(completionsOptions, content, context);
            Response response = await _pipeline.ProcessMessageAsync(message, context, cancellationToken)
                .ConfigureAwait(false);
            return Response.FromValue(Completions.FromResponse(response), response);
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary>
    ///     Begin a completions request and get an object that can stream response data as it becomes available.
    /// </summary>
    /// <param name="completionsOptions"> the chat completions options for this completions request. </param>
    /// <param name="cancellationToken">
    ///     a cancellation token that can be used to cancel the initial request or ongoing streaming operation.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="completionsOptions"/> or <paramref name="completionsOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="completionsOptions.DeploymentName"/> is an empty string.
    /// </exception>
    /// <returns>
    /// A response that, if the request was successful, may be asynchronously enumerated for
    /// <see cref="Completions"/> instances.
    /// </returns>
    [SuppressMessage("Usage", "AZC0015:Unexpected client method return type.")]
    public virtual StreamingResponse<Completions> GetCompletionsStreaming(
        CompletionsOptions completionsOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));
        Argument.AssertNotNullOrEmpty(completionsOptions.DeploymentName, nameof(completionsOptions.DeploymentName));

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletionsStreaming");
        scope.Start();

        completionsOptions.InternalShouldStreamResponse = true;

        RequestContent content = completionsOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);

        try
        {
            // Response value object takes IDisposable ownership of message
            HttpMessage message = CreatePostRequestMessage(completionsOptions, content, context);
            message.BufferResponse = false;
            Response baseResponse = _pipeline.ProcessMessage(message, context, cancellationToken);
            return StreamingResponse<Completions>.CreateFromResponse(
                baseResponse,
                (responseForEnumeration) => SseAsyncEnumerator<Completions>.EnumerateFromSseStream(
                    responseForEnumeration.ContentStream,
                    e => Completions.DeserializeCompletions(e),
                    cancellationToken));
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary>
    ///     Begin a completions request and get an object that can stream response data as it becomes available.
    /// </summary>
    /// <param name="completionsOptions"> the chat completions options for this completions request. </param>
    /// <param name="cancellationToken">
    ///     a cancellation token that can be used to cancel the initial request or ongoing streaming operation.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="completionsOptions"/> or <paramref name="completionsOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="completionsOptions.DeploymentName"/> is an empty string.
    /// </exception>
    /// <returns>
    /// A response that, if the request was successful, may be asynchronously enumerated for
    /// <see cref="Completions"/> instances.
    /// </returns>
    [SuppressMessage("Usage", "AZC0015:Unexpected client method return type.")]
    public virtual async Task<StreamingResponse<Completions>> GetCompletionsStreamingAsync(
        CompletionsOptions completionsOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));
        Argument.AssertNotNullOrEmpty(completionsOptions.DeploymentName, nameof(completionsOptions.DeploymentName));

        completionsOptions.InternalShouldStreamResponse = true;

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletionsStreaming");
        scope.Start();

        RequestContent content = completionsOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);

        try
        {
            // Response value object takes IDisposable ownership of message
            HttpMessage message = CreatePostRequestMessage(completionsOptions, content, context);
            message.BufferResponse = false;
            Response baseResponse = await _pipeline.ProcessMessageAsync(message, context, cancellationToken)
                .ConfigureAwait(false);
            return StreamingResponse<Completions>.CreateFromResponse(
                baseResponse,
                (responseForEnumeration) => SseAsyncEnumerator<Completions>.EnumerateFromSseStream(
                    responseForEnumeration.ContentStream,
                    e => Completions.DeserializeCompletions(e),
                    cancellationToken));
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary> Get chat completions for provided chat context messages. </summary>
    /// <param name="chatCompletionsOptions"> The options for this chat completions request. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="chatCompletionsOptions"/> or <paramref name="chatCompletionsOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="chatCompletionsOptions.DeploymentName"/> is an empty string.
    /// </exception>
    public virtual Response<ChatCompletions> GetChatCompletions(
        ChatCompletionsOptions chatCompletionsOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));
        Argument.AssertNotNullOrEmpty(chatCompletionsOptions.DeploymentName, nameof(chatCompletionsOptions.DeploymentName));

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletions");
        scope.Start();

        chatCompletionsOptions.InternalShouldStreamResponse = null;

        RequestContent content = chatCompletionsOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);

        try
        {
            using HttpMessage message = CreatePostRequestMessage(chatCompletionsOptions, content, context);
            Response response = _pipeline.ProcessMessage(message, context, cancellationToken);
            return Response.FromValue(ChatCompletions.FromResponse(response), response);
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary> Get chat completions for provided chat context messages. </summary>
    /// <param name="chatCompletionsOptions"> The options for this chat completions request. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="chatCompletionsOptions"/> or <paramref name="chatCompletionsOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="chatCompletionsOptions.DeploymentName"/> is an empty string.
    /// </exception>
    public virtual async Task<Response<ChatCompletions>> GetChatCompletionsAsync(
        ChatCompletionsOptions chatCompletionsOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));
        Argument.AssertNotNullOrEmpty(chatCompletionsOptions.DeploymentName, nameof(chatCompletionsOptions.DeploymentName));

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletions");
        scope.Start();

        chatCompletionsOptions.InternalShouldStreamResponse = null;

        RequestContent content = chatCompletionsOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);

        try
        {
            using HttpMessage message = CreatePostRequestMessage(chatCompletionsOptions, content, context);
            Response response = await _pipeline.ProcessMessageAsync(message, context, cancellationToken)
                .ConfigureAwait(false);
            return Response.FromValue(ChatCompletions.FromResponse(response), response);
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary>
    ///     Begin a chat completions request and get an object that can stream response data as it becomes
    ///     available.
    /// </summary>
    /// <param name="chatCompletionsOptions">
    ///     the chat completions options for this chat completions request.
    /// </param>
    /// <param name="cancellationToken">
    ///     a cancellation token that can be used to cancel the initial request or ongoing streaming operation.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="chatCompletionsOptions"/> or <paramref name="chatCompletionsOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="chatCompletionsOptions.DeploymentName"/> is an empty string.
    /// </exception>
    /// <returns> The response returned from the service. </returns>
    [SuppressMessage("Usage", "AZC0015:Unexpected client method return type.")]
    public virtual StreamingResponse<StreamingChatCompletionsUpdate> GetChatCompletionsStreaming(
        ChatCompletionsOptions chatCompletionsOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));
        Argument.AssertNotNullOrEmpty(chatCompletionsOptions.DeploymentName, nameof(chatCompletionsOptions.DeploymentName));

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletionsStreaming");
        scope.Start();

        chatCompletionsOptions.InternalShouldStreamResponse = true;

        RequestContent content = chatCompletionsOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);

        try
        {
            // Response value object takes IDisposable ownership of message
            HttpMessage message = CreatePostRequestMessage(chatCompletionsOptions, content, context);
            message.BufferResponse = false;
            Response baseResponse = _pipeline.ProcessMessage(message, context, cancellationToken);
            return StreamingResponse<StreamingChatCompletionsUpdate>.CreateFromResponse(
                baseResponse,
                (responseForEnumeration)
                    => SseAsyncEnumerator<StreamingChatCompletionsUpdate>.EnumerateFromSseStream(
                        responseForEnumeration.ContentStream,
                        StreamingChatCompletionsUpdate.DeserializeStreamingChatCompletionsUpdates,
                        cancellationToken));
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary>
    ///     Begin a chat completions request and get an object that can stream response data as it becomes
    ///     available.
    /// </summary>
    /// <param name="chatCompletionsOptions">
    ///     the chat completions options for this chat completions request.
    /// </param>
    /// <param name="cancellationToken">
    ///     a cancellation token that can be used to cancel the initial request or ongoing streaming operation.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="chatCompletionsOptions"/> or <paramref name="chatCompletionsOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="chatCompletionsOptions.DeploymentName"/> is an empty string.
    /// </exception>
    /// <returns>
    /// A response that, if the request was successful, may be asynchronously enumerated for
    /// <see cref="StreamingChatCompletionsUpdate"/> instances.
    /// </returns>
    [SuppressMessage("Usage", "AZC0015:Unexpected client method return type.")]
    public virtual async Task<StreamingResponse<StreamingChatCompletionsUpdate>> GetChatCompletionsStreamingAsync(
        ChatCompletionsOptions chatCompletionsOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));
        Argument.AssertNotNullOrEmpty(chatCompletionsOptions.DeploymentName, nameof(chatCompletionsOptions.DeploymentName));

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletionsStreaming");
        scope.Start();

        chatCompletionsOptions.InternalShouldStreamResponse = true;

        RequestContent content = chatCompletionsOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);

        try
        {
            // Response value object takes IDisposable ownership of message
            HttpMessage message = CreatePostRequestMessage(chatCompletionsOptions, content, context);
            message.BufferResponse = false;
            Response baseResponse = await _pipeline.ProcessMessageAsync(
                message,
                context,
                cancellationToken).ConfigureAwait(false);
            return StreamingResponse<StreamingChatCompletionsUpdate>.CreateFromResponse(
                baseResponse,
                (responseForEnumeration)
                    => SseAsyncEnumerator<StreamingChatCompletionsUpdate>.EnumerateFromSseStream(
                        responseForEnumeration.ContentStream,
                        StreamingChatCompletionsUpdate.DeserializeStreamingChatCompletionsUpdates,
                        cancellationToken));
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary> Return the computed embeddings for a given prompt. </summary>
    /// <param name="embeddingsOptions"> The options for this embeddings request. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="embeddingsOptions"/> or <paramref name="embeddingsOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="embeddingsOptions.DeploymentName"/> is an empty string.
    /// </exception>
    public virtual Response<Embeddings> GetEmbeddings(
        EmbeddingsOptions embeddingsOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(embeddingsOptions, nameof(embeddingsOptions));
        Argument.AssertNotNullOrEmpty(embeddingsOptions.DeploymentName, nameof(embeddingsOptions.DeploymentName));

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetEmbeddings");
        scope.Start();

        RequestContent content = embeddingsOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);

        try
        {
            HttpMessage message = CreatePostRequestMessage(embeddingsOptions, content, context);
            Response response = _pipeline.ProcessMessage(message, context, cancellationToken);
            return Response.FromValue(Embeddings.FromResponse(response), response);
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary> Return the computed embeddings for a given prompt. </summary>
    /// <param name="embeddingsOptions"> The options for this embeddings request. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="embeddingsOptions"/> or <paramref name="embeddingsOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="embeddingsOptions.DeploymentName"/> is an empty string.
    /// </exception>
    public virtual async Task<Response<Embeddings>> GetEmbeddingsAsync(
        EmbeddingsOptions embeddingsOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(embeddingsOptions, nameof(embeddingsOptions));
        Argument.AssertNotNullOrEmpty(embeddingsOptions.DeploymentName, nameof(embeddingsOptions.DeploymentName));

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetEmbeddings");
        scope.Start();

        RequestContent content = embeddingsOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);

        try
        {
            HttpMessage message = CreatePostRequestMessage(embeddingsOptions, content, context);
            Response response = await _pipeline.ProcessMessageAsync(message, context, cancellationToken)
                .ConfigureAwait(false);
            return Response.FromValue(Embeddings.FromResponse(response), response);
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary>
    ///     Get a set of generated images influenced by a provided textual prompt.
    /// </summary>
    /// <param name="imageGenerationOptions">
    ///     The configuration information for the image generation request that controls the content,
    ///     size, and other details about generated images.
    /// </param>
    /// <param name="cancellationToken">
    ///     An optional cancellation token that may be used to abort an ongoing request.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="imageGenerationOptions"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="imageGenerationOptions.DeploymentName"/> is null or empty when using Azure OpenAI.
    ///     Azure OpenAI image generation requires a valid dall-e-3 model deployment.
    /// </exception>
    /// <returns>
    ///     The response information for the image generations request.
    /// </returns>
    public virtual Response<ImageGenerations> GetImageGenerations(
        ImageGenerationOptions imageGenerationOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(imageGenerationOptions, nameof(imageGenerationOptions));
        if (_isConfiguredForAzureOpenAI)
        {
            Argument.AssertNotNullOrEmpty(imageGenerationOptions.DeploymentName, nameof(imageGenerationOptions.DeploymentName));
        }

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetImageGenerations");
        scope.Start();

        try
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            HttpMessage message = CreatePostRequestMessage(
                imageGenerationOptions.DeploymentName,
                "images/generations",
                content: imageGenerationOptions.ToRequestContent(),
                context);
            Response rawResponse = _pipeline.ProcessMessage(message, context, cancellationToken);
            return Response.FromValue(ImageGenerations.FromResponse(rawResponse), rawResponse);
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary>
    ///     Get a set of generated images influenced by a provided textual prompt.
    /// </summary>
    /// <param name="imageGenerationOptions">
    ///     The configuration information for the image generation request that controls the content,
    ///     size, and other details about generated images.
    /// </param>
    /// <param name="cancellationToken">
    ///     An optional cancellation token that may be used to abort an ongoing request.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="imageGenerationOptions"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="imageGenerationOptions.DeploymentName"/> is null or empty when using Azure OpenAI.
    ///     Azure OpenAI image generation requires a valid dall-e-3 model deployment.
    /// </exception>
    /// <returns>
    ///     The response information for the image generations request.
    /// </returns>
    public virtual async Task<Response<ImageGenerations>> GetImageGenerationsAsync(
        ImageGenerationOptions imageGenerationOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(imageGenerationOptions, nameof(imageGenerationOptions));
        if (_isConfiguredForAzureOpenAI)
        {
            Argument.AssertNotNullOrEmpty(imageGenerationOptions.DeploymentName, nameof(imageGenerationOptions.DeploymentName));
        }
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetImageGenerations");
        scope.Start();

        try
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            HttpMessage message = CreatePostRequestMessage(
                imageGenerationOptions.DeploymentName,
                "images/generations",
                content: imageGenerationOptions.ToRequestContent(),
                context);
            Response rawResponse = await _pipeline.ProcessMessageAsync(message, context, cancellationToken)
                .ConfigureAwait(false);
            return Response.FromValue(ImageGenerations.FromResponse(rawResponse), rawResponse);
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary> Transcribes audio into the input language. </summary>
    /// <param name="audioTranscriptionOptions">
    /// Transcription request.
    /// Requesting format 'json' will result on only the 'text' field being set.
    /// For more output data use 'verbose_json.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="audioTranscriptionOptions"/> or <paramref name="audioTranscriptionOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="audioTranscriptionOptions.DeploymentName"/> is an empty string.
    /// </exception>
    public virtual async Task<Response<AudioTranscription>> GetAudioTranscriptionAsync(
        AudioTranscriptionOptions audioTranscriptionOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(audioTranscriptionOptions, nameof(audioTranscriptionOptions));
        Argument.AssertNotNullOrEmpty(audioTranscriptionOptions.DeploymentName, nameof(audioTranscriptionOptions.DeploymentName));

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetAudioTranscription");
        scope.Start();

        RequestContent content = audioTranscriptionOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);
        Response rawResponse = default;

        try
        {
            using HttpMessage message = CreateGetAudioTranscriptionRequest(audioTranscriptionOptions, content, context);
            rawResponse = await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }

        return Response.FromValue(AudioTranscription.FromResponse(rawResponse), rawResponse);
    }

    /// <summary> Transcribes audio into the input language. </summary>
    /// <param name="audioTranscriptionOptions">
    /// Transcription request.
    /// Requesting format 'json' will result on only the 'text' field being set.
    /// For more output data use 'verbose_json.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="audioTranscriptionOptions"/> or <paramref name="audioTranscriptionOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="audioTranscriptionOptions.DeploymentName"/> is an empty string.
    /// </exception>
    public virtual Response<AudioTranscription> GetAudioTranscription(
        AudioTranscriptionOptions audioTranscriptionOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(audioTranscriptionOptions, nameof(audioTranscriptionOptions));
        Argument.AssertNotNullOrEmpty(audioTranscriptionOptions.DeploymentName, nameof(audioTranscriptionOptions.DeploymentName));

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetAudioTranscription");
        scope.Start();

        RequestContent content = audioTranscriptionOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);
        Response rawResponse = default;

        try
        {
            using HttpMessage message = CreateGetAudioTranscriptionRequest(audioTranscriptionOptions, content, context);
            rawResponse = _pipeline.ProcessMessage(message, context);
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }

        return Response.FromValue(AudioTranscription.FromResponse(rawResponse), rawResponse);
    }

    /// <summary> Transcribes and translates input audio into English text. </summary>
    /// <param name="audioTranslationOptions">
    /// Translation request.
    /// Requesting format 'json' will result on only the 'text' field being set.
    /// For more output data use 'verbose_json.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="audioTranslationOptions"/> or <paramref name="audioTranslationOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="audioTranslationOptions.DeploymentName"/> is an empty string.
    /// </exception>
    public virtual async Task<Response<AudioTranslation>> GetAudioTranslationAsync(
        AudioTranslationOptions audioTranslationOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(audioTranslationOptions, nameof(audioTranslationOptions));
        Argument.AssertNotNullOrEmpty(audioTranslationOptions.DeploymentName, nameof(audioTranslationOptions.DeploymentName));

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetAudioTranslation");
        scope.Start();

        RequestContent content = audioTranslationOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);
        Response rawResponse = default;

        try
        {
            using HttpMessage message = CreateGetAudioTranslationRequest(audioTranslationOptions, content, context);
            rawResponse = await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }

        return Response.FromValue(AudioTranslation.FromResponse(rawResponse), rawResponse);
    }

    /// <summary> Transcribes and translates input audio into English text. </summary>
    /// <param name="audioTranslationOptions">
    /// Translation request.
    /// Requesting format 'json' will result on only the 'text' field being set.
    /// For more output data use 'verbose_json.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="audioTranslationOptions"/> or <paramref name="audioTranslationOptions.DeploymentName"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="audioTranslationOptions.DeploymentName"/> is an empty string.
    /// </exception>
    public virtual Response<AudioTranslation> GetAudioTranslation(
        AudioTranslationOptions audioTranslationOptions,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(audioTranslationOptions, nameof(audioTranslationOptions));
        Argument.AssertNotNullOrEmpty(audioTranslationOptions.DeploymentName, nameof(audioTranslationOptions.DeploymentName));

        using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetAudioTranslation");
        scope.Start();

        RequestContent content = audioTranslationOptions.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);
        Response rawResponse = default;

        try
        {
            using HttpMessage message = CreateGetAudioTranslationRequest(audioTranslationOptions, content, context);
            rawResponse = _pipeline.ProcessMessage(message, context);
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }

        return Response.FromValue(AudioTranslation.FromResponse(rawResponse), rawResponse);
    }

    internal RequestUriBuilder GetUri(string deploymentOrModelName, string operationPath)
    {
        var uri = new RawRequestUriBuilder();
        uri.Reset(_endpoint);
        if (_isConfiguredForAzureOpenAI)
        {
            uri.AppendRaw("/openai", false);
            uri.AppendPath("/deployments/", false);
            uri.AppendPath(deploymentOrModelName, true);
            uri.AppendPath($"/{operationPath}", false);
            uri.AppendQuery("api-version", _apiVersion, true);
        }
        else
        {
            uri.AppendPath($"/{operationPath}", false);
        }
        return uri;
    }

    internal HttpMessage CreatePostRequestMessage(
        CompletionsOptions completionsOptions,
        RequestContent content,
        RequestContext context)
        => CreatePostRequestMessage(completionsOptions.DeploymentName, "completions", content, context);

    internal HttpMessage CreatePostRequestMessage(
        ChatCompletionsOptions chatCompletionsOptions,
        RequestContent content,
        RequestContext context)
    {
        string operationPath = chatCompletionsOptions.AzureExtensionsOptions != null
            ? "extensions/chat/completions"
            : "chat/completions";
        return CreatePostRequestMessage(chatCompletionsOptions.DeploymentName, operationPath, content, context);
    }

    internal HttpMessage CreatePostRequestMessage(
        EmbeddingsOptions embeddingsOptions,
        RequestContent content,
        RequestContext context)
        => CreatePostRequestMessage(embeddingsOptions.DeploymentName, "embeddings", content, context);

    internal HttpMessage CreatePostRequestMessage(
        string deploymentOrModelName,
        string operationPath,
        RequestContent content,
        RequestContext context)
    {
        HttpMessage message = _pipeline.CreateMessage(context, ResponseClassifier200);
        Request request = message.Request;
        request.Method = RequestMethod.Post;
        request.Uri = GetUri(deploymentOrModelName, operationPath);
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("Content-Type", "application/json");
        request.Content = content;
        return message;
    }

    private static TokenCredential CreateDelegatedToken(string token)
    {
        var accessToken = new AccessToken(token, DateTimeOffset.Now.AddDays(180));
        return DelegatedTokenCredential.Create((_, _) => accessToken);
    }

    internal HttpMessage CreateGetAudioTranscriptionRequest(
        AudioTranscriptionOptions audioTranscriptionOptions,
        RequestContent content,
        RequestContext context)
    {
        HttpMessage message = _pipeline.CreateMessage(context, ResponseClassifier200);
        Request request = message.Request;
        request.Method = RequestMethod.Post;
        request.Uri = GetUri(audioTranscriptionOptions.DeploymentName, "audio/transcriptions");
        request.Content = content;
        (content as MultipartFormDataContent).ApplyToRequest(request);
        return message;
    }

    internal HttpMessage CreateGetAudioTranslationRequest(
        AudioTranslationOptions audioTranslationOptions,
        RequestContent content,
        RequestContext context)
    {
        HttpMessage message = _pipeline.CreateMessage(context, ResponseClassifier200);
        Request request = message.Request;
        request.Method = RequestMethod.Post;
        request.Uri = GetUri(audioTranslationOptions.DeploymentName, "audio/translations");
        request.Content = content;
        (content as MultipartFormDataContent).ApplyToRequest(request);
        return message;
    }
}
