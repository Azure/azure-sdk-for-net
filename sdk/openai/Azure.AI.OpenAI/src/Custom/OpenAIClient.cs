// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.OpenAI
{
    /// <summary> Azure OpenAI APIs for completions and search. </summary>
    public partial class OpenAIClient
    {
        private const int DefaultMaxCompletionsTokens = 100;
        private const string PublicOpenAIApiVersion = "1";
        private const string PublicOpenAIEndpoint = $"https://api.openai.com/v{PublicOpenAIApiVersion}";

        /// <summary>
        ///     Gets or sets the model or deployment name used by default when not provided to a request method.
        /// </summary>
        /// <remarks>
        ///     When using an <see cref="OpenAIClient"/> to connect to Azure OpenAI,
        ///     <see cref="DefaultDeploymentOrModelName"/> should match an Azure deployment name that may differ
        ///     from the name of the model in that deployment.
        ///     When using an <see cref="OpenAIClient"/> to connect to the non-Azure OpenAI endpoint,
        ///     <see cref="DefaultDeploymentOrModelName"/> should instead match the name of the model intended for use.
        /// </remarks>
        public string DefaultDeploymentOrModelName { get; set; }

        /// <remarks>
        ///     This key is used to connect to the non-Azure OpenAI endpoint.
        ///     For Azure OpenAI resources as created and maintained in Azure Portal, use a constructor that
        ///     provides an Azure resource endpoint and credential, instead.
        /// </remarks>
        private string PublicOpenAIApiKey { get; }

        /// <summary> Initializes a instance of OpenAIClient using the public OpenAI endpoint. </summary>
        /// <param name="openAIApiKey">
        ///     The API key to use when connecting to the non-Azure OpenAI endpoint.
        ///     For Azure OpenAI resources as created and maintained in Azure Portal, use a constructor that
        ///     provides an Azure resource endpoint and credential, instead.
        /// </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="openAIApiKey"/> is null. </exception>
        public OpenAIClient(string openAIApiKey, OpenAIClientOptions options)
            : this(new Uri(PublicOpenAIEndpoint), CreateDelegatedToken(openAIApiKey), options)
        {
            PublicOpenAIApiKey = openAIApiKey;
        }

        /// <inheritdoc cref="OpenAIClient(string, OpenAIClientOptions)"/>
        public OpenAIClient(string openAIApiKey)
            : this(new Uri(PublicOpenAIEndpoint), CreateDelegatedToken(openAIApiKey), new OpenAIClientOptions())
        {
            PublicOpenAIApiKey = openAIApiKey;
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
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            if (!string.IsNullOrEmpty(PublicOpenAIApiKey))
            {
                completionsOptions.NonAzureModel = deploymentOrModelName;
            }

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletions");
            scope.Start();

            RequestContent content = completionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreateGetCompletionsRequest(deploymentOrModelName, content, context);
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
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
            => GetCompletions(DefaultDeploymentOrModelName, completionsOptions, cancellationToken);

        /// <inheritdoc cref="GetCompletions(string, CompletionsOptions, CancellationToken)"/>
        public virtual Response<Completions> GetCompletions(
            string deploymentOrModelName,
            string prompt,
            CancellationToken cancellationToken = default)
            => GetCompletions(deploymentOrModelName, GetDefaultCompletionsOptions(prompt), cancellationToken);

        /// <inheritdoc cref="GetCompletions(string, CompletionsOptions, CancellationToken)"/>
        public virtual Response<Completions> GetCompletions(
            string prompt,
            CancellationToken cancellationToken = default)
            => GetCompletions(DefaultDeploymentOrModelName, GetDefaultCompletionsOptions(prompt), cancellationToken);

        /// <inheritdoc cref="GetCompletions(string, CompletionsOptions, CancellationToken)"/>
        public virtual async Task<Response<Completions>> GetCompletionsAsync(
            string deploymentOrModelName,
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            if (!string.IsNullOrEmpty(PublicOpenAIApiKey))
            {
                completionsOptions.NonAzureModel = deploymentOrModelName;
            }

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletions");
            scope.Start();

            RequestContent content = completionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreateGetCompletionsRequest(deploymentOrModelName, content, context);
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
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
            => GetCompletionsAsync(DefaultDeploymentOrModelName, completionsOptions, cancellationToken);

        /// <inheritdoc cref="GetCompletions(string, CompletionsOptions, CancellationToken)"/>
        public virtual Task<Response<Completions>> GetCompletionsAsync(
            string deploymentOrModelName,
            string prompt,
            CancellationToken cancellationToken = default)
            => GetCompletionsAsync(deploymentOrModelName, GetDefaultCompletionsOptions(prompt), cancellationToken);

        /// <inheritdoc cref="GetCompletions(string, CompletionsOptions, CancellationToken)"/>
        public virtual Task<Response<Completions>> GetCompletionsAsync(
            string prompt,
            CancellationToken cancellationToken = default)
            => GetCompletionsAsync(DefaultDeploymentOrModelName, GetDefaultCompletionsOptions(prompt), cancellationToken);

        /// <summary>
        ///     Begin a completions request and get an object that can stream response data as it becomes available.
        /// </summary>
        /// <param name="deploymentOrModelName">
        ///     <inheritdoc
        ///         cref="GetCompletions(CompletionsOptions, CancellationToken)"
        ///         path="/param[@name='deploymentOrModelName']" />
        /// </param>
        /// <param name="completionsOptions"> the chat completions options for this completions request. </param>
        /// <param name="cancellationToken">
        ///     a cancellation token that can be used to cancel the initial request or ongoing streaming operation.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="completionsOptions"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns>
        /// A response that, if the request was successful, includes a <see cref="StreamingCompletions"/> instance.
        /// </returns>
        public virtual Response<StreamingCompletions> GetCompletionsStreaming(
            string deploymentOrModelName,
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            if (!string.IsNullOrEmpty(PublicOpenAIApiKey))
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
                HttpMessage message = CreateGetCompletionsRequest(deploymentOrModelName, streamingContent, context);
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
        public virtual Response<StreamingCompletions> GetCompletionsStreaming(
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
            => GetCompletionsStreaming(DefaultDeploymentOrModelName, completionsOptions, cancellationToken);

        /// <inheritdoc cref="GetCompletionsStreaming(string, CompletionsOptions, CancellationToken)"/>
        public virtual async Task<Response<StreamingCompletions>> GetCompletionsStreamingAsync(
            string deploymentOrModelName,
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            if (!string.IsNullOrEmpty(PublicOpenAIApiKey))
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
                HttpMessage message = CreateGetCompletionsRequest(deploymentOrModelName, streamingContent, context);
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

        /// <inheritdoc cref="GetCompletionsStreaming(string, CompletionsOptions, CancellationToken)"/>
        public virtual Task<Response<StreamingCompletions>> GetCompletionsStreamingAsync(
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
            => GetCompletionsStreamingAsync(DefaultDeploymentOrModelName, completionsOptions, cancellationToken);

        /// <summary> Get chat completions for provided chat context messages. </summary>
        /// <param name="deploymentOrModelName">
        /// <inheritdoc
        ///     cref="GetCompletions(string, CompletionsOptions, CancellationToken)"
        ///     path="/param[@name='deploymentOrModelName']"/>
        /// </param>
        /// <param name="chatCompletionsOptions"> The options for this chat completions request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="chatCompletionsOptions"/> is null. </exception>
        public virtual Response<ChatCompletions> GetChatCompletions(
            string deploymentOrModelName,
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            if (!string.IsNullOrEmpty(PublicOpenAIApiKey))
            {
                chatCompletionsOptions.NonAzureModel = deploymentOrModelName;
            }

            using var scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletions");
            scope.Start();

            RequestContent content = chatCompletionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreateGetChatCompletionsRequest(deploymentOrModelName, content, context);
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
        public virtual Response<ChatCompletions> GetChatCompletions(
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
            => GetChatCompletions(DefaultDeploymentOrModelName, chatCompletionsOptions, cancellationToken);

        /// <inheritdoc cref="GetChatCompletions(string, ChatCompletionsOptions, CancellationToken)"/>
        public virtual async Task<Response<ChatCompletions>> GetChatCompletionsAsync(
            string deploymentOrModelName,
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            if (!string.IsNullOrEmpty(PublicOpenAIApiKey))
            {
                chatCompletionsOptions.NonAzureModel = deploymentOrModelName;
            }

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletions");
            scope.Start();

            RequestContent content = chatCompletionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreateGetChatCompletionsRequest(deploymentOrModelName, content, context);
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

        /// <inheritdoc cref="GetChatCompletions(string, ChatCompletionsOptions, CancellationToken)"/>
        public virtual Task<Response<ChatCompletions>> GetChatCompletionsAsync(
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
            => GetChatCompletionsAsync(DefaultDeploymentOrModelName, chatCompletionsOptions, cancellationToken);

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
        /// <exception cref="ArgumentNullException"> <paramref name="chatCompletionsOptions"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response<StreamingChatCompletions> GetChatCompletionsStreaming(
            string deploymentOrModelName,
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            if (!string.IsNullOrEmpty(PublicOpenAIApiKey))
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
                HttpMessage message = CreateGetChatCompletionsRequest(deploymentOrModelName, streamingContent, context);
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
        public virtual Response<StreamingChatCompletions> GetChatCompletionsStreaming(
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
            => GetChatCompletionsStreaming(DefaultDeploymentOrModelName, chatCompletionsOptions, cancellationToken);

        /// <inheritdoc cref="GetChatCompletionsStreaming(string, ChatCompletionsOptions, CancellationToken)"/>
        public virtual async Task<Response<StreamingChatCompletions>> GetChatCompletionsStreamingAsync(
            string deploymentOrModelName,
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            if (!string.IsNullOrEmpty(PublicOpenAIApiKey))
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
                HttpMessage message = CreateGetChatCompletionsRequest(deploymentOrModelName, streamingContent, context);
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

        /// <inheritdoc cref="GetChatCompletionsStreaming(string, ChatCompletionsOptions, CancellationToken)"/>
        public virtual Task<Response<StreamingChatCompletions>> GetChatCompletionsStreamingAsync(
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
            => GetChatCompletionsStreamingAsync(DefaultDeploymentOrModelName, chatCompletionsOptions, cancellationToken);

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

            if (!string.IsNullOrEmpty(PublicOpenAIApiKey))
            {
                embeddingsOptions.NonAzureModel = deploymentOrModelName;
            }

            RequestContent content = embeddingsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                HttpMessage message = CreateGetEmbeddingsRequest(deploymentOrModelName, content, context);
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
        public virtual Response<Embeddings> GetEmbeddings(
            EmbeddingsOptions embeddingsOptions,
            CancellationToken cancellationToken = default)
            => GetEmbeddings(DefaultDeploymentOrModelName, embeddingsOptions, cancellationToken);

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

            if (!string.IsNullOrEmpty(PublicOpenAIApiKey))
            {
                embeddingsOptions.NonAzureModel = deploymentOrModelName;
            }

            RequestContent content = embeddingsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                HttpMessage message = CreateGetEmbeddingsRequest(deploymentOrModelName, content, context);
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

        /// <inheritdoc cref="GetEmbeddings(string, EmbeddingsOptions, CancellationToken)"/>
        public virtual Task<Response<Embeddings>> GetEmbeddingsAsync(
            EmbeddingsOptions embeddingsOptions,
            CancellationToken cancellationToken = default)
            => GetEmbeddingsAsync(DefaultDeploymentOrModelName, embeddingsOptions, cancellationToken);

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
            if (string.IsNullOrEmpty(PublicOpenAIApiKey))
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

        internal HttpMessage CreateGetCompletionsRequest(
            string deploymentOrModelName,
            RequestContent content,
            RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri = GetUri(deploymentOrModelName, "completions");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetChatCompletionsRequest(
            string deploymentOrModelName,
            RequestContent content,
            RequestContext context)
        {
            HttpMessage message = _pipeline.CreateMessage(context, ResponseClassifier200);
            Request request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri = GetUri(deploymentOrModelName, "chat/completions");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetEmbeddingsRequest(
            string deploymentOrModelName,
            RequestContent content,
            RequestContext context)
        {
            HttpMessage message = _pipeline.CreateMessage(context, ResponseClassifier200);
            Request request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri = GetUri(deploymentOrModelName, "embeddings");
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
