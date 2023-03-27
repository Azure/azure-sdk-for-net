// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Specialized;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.OpenAI
{
    /// <summary> Azure OpenAI APIs for completions and search. </summary>
    [CodeGenSuppress("GetCompletions", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetCompletionsAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetEmbeddings", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetEmbeddingsAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetCompletionsRequest", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetEmbeddingsRequest", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    public partial class OpenAIClient
    {
        private const int DefaultMaxCompletionsTokens = 100;
        private const string PublicOpenAIApiVersion = "1";
        private const string PublicOpenAIEndpoint = $"https://api.openai.com/v{PublicOpenAIApiVersion}";

        private readonly string _nonAzureOpenAIApiKey;

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
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
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
            _nonAzureOpenAIApiKey = openAIApiKey;
        }

        /// <inheritdoc cref="OpenAIClient(string, OpenAIClientOptions)"/>
        public OpenAIClient(string openAIApiKey)
            : this(new Uri(PublicOpenAIEndpoint), CreateDelegatedToken(openAIApiKey), new OpenAIClientOptions())
        {
            _nonAzureOpenAIApiKey = openAIApiKey;
        }

        /// <summary> Return textual completions as configured for a given prompt. </summary>
        /// <param name="deploymentOrModelName">
        ///     Specifies either the model deployment name (when using Azure OpenAI) or model name (when using
        ///     non-Azure OpenAI) to use for this request.
        /// </param>
        /// <param name="completionsOptions">
        ///     The options for this completions request.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="deploymentOrModelName"/> or <paramref name="completionsOptions"/> is null.
        /// </exception>
        public virtual Response<Completions> GetCompletions(
            string deploymentOrModelName,
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deploymentOrModelName, nameof(deploymentOrModelName));
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            if (!string.IsNullOrEmpty(_nonAzureOpenAIApiKey))
            {
                completionsOptions.NonAzureModel = deploymentOrModelName;
            }

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletions");
            scope.Start();

            RequestContent content = completionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreatePostRequestMessage(deploymentOrModelName, "completions", content, context);
                Response response = _pipeline.ProcessMessage(message, context, cancellationToken);
                return Response.FromValue(Completions.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc cref="GetCompletions(string, CompletionsOptions, CancellationToken)"/>
        public virtual Response<Completions> GetCompletions(
            string deploymentOrModelName,
            string prompt,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(prompt, nameof(prompt));
            CompletionsOptions simpleOptions = GetDefaultCompletionsOptions(prompt);
            return GetCompletions(deploymentOrModelName, simpleOptions, cancellationToken);
        }

        /// <inheritdoc cref="GetCompletions(string, CompletionsOptions, CancellationToken)"/>
        public virtual async Task<Response<Completions>> GetCompletionsAsync(
            string deploymentOrModelName,
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deploymentOrModelName, nameof(deploymentOrModelName));
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            if (!string.IsNullOrEmpty(_nonAzureOpenAIApiKey))
            {
                completionsOptions.NonAzureModel = deploymentOrModelName;
            }

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletions");
            scope.Start();

            RequestContent content = completionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreatePostRequestMessage(deploymentOrModelName, "completions", content, context);
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

        /// <inheritdoc cref="GetCompletions(string, CompletionsOptions, CancellationToken)"/>
        public virtual Task<Response<Completions>> GetCompletionsAsync(
            string deploymentOrModelName,
            string prompt,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(prompt, nameof(prompt));
            CompletionsOptions simpleOptions = GetDefaultCompletionsOptions(prompt);
            return GetCompletionsAsync(deploymentOrModelName, simpleOptions, cancellationToken);
        }

        /// <summary>
        ///     Begin a completions request and get an object that can stream response data as it becomes available.
        /// </summary>
        /// <param name="deploymentOrModelName">
        ///     <inheritdoc
        ///         cref="GetCompletions(string, CompletionsOptions, CancellationToken)"
        ///         path="/param[@name='deploymentOrModelName']" />
        /// </param>
        /// <param name="completionsOptions"> the chat completions options for this completions request. </param>
        /// <param name="cancellationToken">
        ///     a cancellation token that can be used to cancel the initial request or ongoing streaming operation.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="deploymentOrModelName"/> or <paramref name="completionsOptions"/> is null.
        /// </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns>
        /// A response that, if the request was successful, includes a <see cref="StreamingCompletions"/> instance.
        /// </returns>
        public virtual Response<StreamingCompletions> GetCompletionsStreaming(
            string deploymentOrModelName,
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deploymentOrModelName, nameof(deploymentOrModelName));
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            if (!string.IsNullOrEmpty(_nonAzureOpenAIApiKey))
            {
                completionsOptions.NonAzureModel = deploymentOrModelName;
            }

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletionsStreaming");
            scope.Start();

            RequestContent nonStreamingContent = completionsOptions.ToRequestContent();
            RequestContent streamingContent = GetStreamingEnabledRequestContent(nonStreamingContent);
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                // Response value object takes IDisposable ownership of message
                HttpMessage message = CreatePostRequestMessage(
                    deploymentOrModelName,
                    "completions",
                    streamingContent,
                    context);
                message.BufferResponse = false;
                Response baseResponse = _pipeline.ProcessMessage(message, context, cancellationToken);
                return Response.FromValue(new StreamingCompletions(baseResponse), baseResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc cref="GetCompletionsStreaming(string, CompletionsOptions, CancellationToken)"/>
        public virtual async Task<Response<StreamingCompletions>> GetCompletionsStreamingAsync(
            string deploymentOrModelName,
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deploymentOrModelName, nameof(deploymentOrModelName));
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            if (!string.IsNullOrEmpty(_nonAzureOpenAIApiKey))
            {
                completionsOptions.NonAzureModel = deploymentOrModelName;
            }

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletionsStreaming");
            scope.Start();

            RequestContext context = FromCancellationToken(cancellationToken);

            RequestContent nonStreamingContent = completionsOptions.ToRequestContent();
            RequestContent streamingContent = GetStreamingEnabledRequestContent(nonStreamingContent);

            try
            {
                // Response value object takes IDisposable ownership of message
                HttpMessage message = CreatePostRequestMessage(
                    deploymentOrModelName,
                    "completions",
                    streamingContent,
                    context);
                message.BufferResponse = false;
                Response baseResponse = await _pipeline.ProcessMessageAsync(message, context, cancellationToken)
                    .ConfigureAwait(false);
                return Response.FromValue(new StreamingCompletions(baseResponse), baseResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get chat completions for provided chat context messages. </summary>
        /// <param name="deploymentOrModelName">
        /// <inheritdoc
        ///     cref="GetCompletions(string, CompletionsOptions, CancellationToken)"
        ///     path="/param[@name='deploymentOrModelName']"/>
        /// </param>
        /// <param name="chatCompletionsOptions"> The options for this chat completions request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="deploymentOrModelName"/> or <paramref name="chatCompletionsOptions"/> is null.
        /// </exception>
        public virtual Response<ChatCompletions> GetChatCompletions(
            string deploymentOrModelName,
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deploymentOrModelName, nameof(deploymentOrModelName));
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            if (!string.IsNullOrEmpty(_nonAzureOpenAIApiKey))
            {
                chatCompletionsOptions.NonAzureModel = deploymentOrModelName;
            }

            using var scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletions");
            scope.Start();

            RequestContent content = chatCompletionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreatePostRequestMessage(
                    deploymentOrModelName,
                    "chat/completions",
                    content,
                    context);
                Response response = _pipeline.ProcessMessage(message, context, cancellationToken);
                return Response.FromValue(ChatCompletions.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc cref="GetChatCompletions(string, ChatCompletionsOptions, CancellationToken)"/>
        public virtual async Task<Response<ChatCompletions>> GetChatCompletionsAsync(
            string deploymentOrModelName,
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deploymentOrModelName, nameof(deploymentOrModelName));
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            if (!string.IsNullOrEmpty(_nonAzureOpenAIApiKey))
            {
                chatCompletionsOptions.NonAzureModel = deploymentOrModelName;
            }

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletions");
            scope.Start();

            RequestContent content = chatCompletionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreatePostRequestMessage(
                    deploymentOrModelName,
                    "chat/completions",
                    content,
                    context);
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
        /// <param name="deploymentOrModelName">
        ///     <inheritdoc
        ///         cref="GetCompletions(string, CompletionsOptions, CancellationToken)"
        ///         path="/param[@name='deploymentOrModelName']"/>
        /// </param>
        /// <param name="chatCompletionsOptions">
        ///     the chat completions options for this chat completions request.
        /// </param>
        /// <param name="cancellationToken">
        ///     a cancellation token that can be used to cancel the initial request or ongoing streaming operation.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="deploymentOrModelName"/> or <paramref name="chatCompletionsOptions"/> is null.
        /// </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response<StreamingChatCompletions> GetChatCompletionsStreaming(
            string deploymentOrModelName,
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deploymentOrModelName, nameof(deploymentOrModelName));
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            if (!string.IsNullOrEmpty(_nonAzureOpenAIApiKey))
            {
                chatCompletionsOptions.NonAzureModel = deploymentOrModelName;
            }

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletionsStreaming");
            scope.Start();

            RequestContent nonStreamingContent = chatCompletionsOptions.ToRequestContent();
            RequestContent streamingContent = GetStreamingEnabledRequestContent(nonStreamingContent);
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                // Response value object takes IDisposable ownership of message
                HttpMessage message = CreatePostRequestMessage(
                    deploymentOrModelName,
                    "chat/completions",
                    streamingContent,
                    context);
                message.BufferResponse = false;
                Response baseResponse = _pipeline.ProcessMessage(message, context, cancellationToken);
                return Response.FromValue(new StreamingChatCompletions(baseResponse), baseResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc cref="GetChatCompletionsStreaming(string, ChatCompletionsOptions, CancellationToken)"/>
        public virtual async Task<Response<StreamingChatCompletions>> GetChatCompletionsStreamingAsync(
            string deploymentOrModelName,
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deploymentOrModelName, nameof(deploymentOrModelName));
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            if (!string.IsNullOrEmpty(_nonAzureOpenAIApiKey))
            {
                chatCompletionsOptions.NonAzureModel = deploymentOrModelName;
            }

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletionsStreaming");
            scope.Start();

            RequestContext context = FromCancellationToken(cancellationToken);

            RequestContent nonStreamingContent = chatCompletionsOptions.ToRequestContent();
            RequestContent streamingContent = GetStreamingEnabledRequestContent(nonStreamingContent);

            try
            {
                // Response value object takes IDisposable ownership of message
                HttpMessage message = CreatePostRequestMessage(
                    deploymentOrModelName,
                    "chat/completions",
                    streamingContent,
                    context);
                message.BufferResponse = false;
                Response baseResponse = await _pipeline.ProcessMessageAsync(
                    message,
                    context,
                    cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new StreamingChatCompletions(baseResponse), baseResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return the computed embeddings for a given prompt. </summary>
        /// <param name="deploymentOrModelName">
        ///     <inheritdoc
        ///         cref="GetCompletions(string, CompletionsOptions, CancellationToken)"
        ///         path="/param[@name='deploymentOrModelName']"/>
        /// </param>
        /// <param name="embeddingsOptions"> The options for this embeddings request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="deploymentOrModelName"/> or <paramref name="embeddingsOptions"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="deploymentOrModelName"/> is an empty string and was expected to be non-empty.
        /// </exception>
        public virtual Response<Embeddings> GetEmbeddings(
            string deploymentOrModelName,
            EmbeddingsOptions embeddingsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentOrModelName, nameof(deploymentOrModelName));
            Argument.AssertNotNull(embeddingsOptions, nameof(embeddingsOptions));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetEmbeddings");
            scope.Start();

            if (!string.IsNullOrEmpty(_nonAzureOpenAIApiKey))
            {
                embeddingsOptions.NonAzureModel = deploymentOrModelName;
            }

            RequestContent content = embeddingsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                HttpMessage message = CreatePostRequestMessage(deploymentOrModelName, "embeddings", content, context);
                Response response = _pipeline.ProcessMessage(message, context, cancellationToken);
                return Response.FromValue(Embeddings.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc cref="GetEmbeddings(string, EmbeddingsOptions, CancellationToken)"/>
        public virtual async Task<Response<Embeddings>> GetEmbeddingsAsync(
            string deploymentOrModelName,
            EmbeddingsOptions embeddingsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentOrModelName, nameof(deploymentOrModelName));
            Argument.AssertNotNull(embeddingsOptions, nameof(embeddingsOptions));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetEmbeddings");
            scope.Start();

            if (!string.IsNullOrEmpty(_nonAzureOpenAIApiKey))
            {
                embeddingsOptions.NonAzureModel = deploymentOrModelName;
            }

            RequestContent content = embeddingsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                HttpMessage message = CreatePostRequestMessage(deploymentOrModelName, "embeddings", content, context);
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

        private static RequestContent GetStreamingEnabledRequestContent(RequestContent originalRequestContent)
        {
            // Dump the original request content to a temporary stream and seek to start
            using Stream originalRequestContentStream = new MemoryStream();
            originalRequestContent.WriteTo(originalRequestContentStream, new CancellationToken());
            originalRequestContentStream.Position = 0;

            JsonDocument originalJson = JsonDocument.Parse(originalRequestContentStream);
            JsonElement originalJsonRoot = originalJson.RootElement;

            var augmentedContent = new Utf8JsonRequestContent();
            augmentedContent.JsonWriter.WriteStartObject();

            // Copy the original JSON content back into the new copy
            foreach (JsonProperty jsonThing in originalJsonRoot.EnumerateObject())
            {
                augmentedContent.JsonWriter.WritePropertyName(jsonThing.Name);
                jsonThing.Value.WriteTo(augmentedContent.JsonWriter);
            }

            // ...Add the *one thing* we wanted to add
            augmentedContent.JsonWriter.WritePropertyName("stream");
            augmentedContent.JsonWriter.WriteBooleanValue(true);

            augmentedContent.JsonWriter.WriteEndObject();

            return augmentedContent;
        }

        internal RequestUriBuilder GetUri(string deploymentOrModelName, string operationPath)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            if (string.IsNullOrEmpty(_nonAzureOpenAIApiKey))
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
            AccessToken accessToken = new AccessToken(token, DateTimeOffset.Now.AddDays(180));
            return DelegatedTokenCredential.Create((_, _) => accessToken);
        }

        private static CompletionsOptions GetDefaultCompletionsOptions(string prompt)
        {
            return new CompletionsOptions()
            {
                Prompts =
                {
                    prompt,
                },
                MaxTokens = DefaultMaxCompletionsTokens,
            };
        }
    }
}
