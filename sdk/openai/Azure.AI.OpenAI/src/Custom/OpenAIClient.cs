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
    // Data plane generated client.
    /// <summary> Azure OpenAI APIs for completions and search. </summary>
    public partial class OpenAIClient
    {
        private const string publicOpenAIVersion = "1";
        private const string publicOpenAIEndpoint = $"https://api.openai.com/v{publicOpenAIVersion}";

        /// <summary> Gets the deployment or model name used for all operations on this client. </summary>
        /// <remarks>
        ///     When using an <see cref="OpenAIClient"/> to connect to Azure OpenAI, <see cref="DeploymentId"/>
        ///     should match an Azure deployment name that may differ from the name of the model in that deployment.
        ///     When using an <see cref="OpenAIClient"/> to connect to the non-Azure OpenAI endpoint,
        ///     <see cref="DeploymentId"/> should instead match the name of the model intended for use.
        /// </remarks>
        private string DeploymentId { get; }

        /// <remarks>
        ///     This key is used to connect to a non-Azure OpenAI resource created directly with OpenAI.
        ///     For Azure OpenAI resources as created and maintained in Azure Portal, use a constructor that
        ///     provides an Azure resource endpoint and credential, instead.
        /// </remarks>
        private string PublicOpenAIToken { get; }

        /// <summary> Initializes a instance of OpenAIClient using the public OpenAI endpoint. </summary>
        /// <param name="openAIAuthToken ">
        ///     String token to generate a token credential.
        ///     This string is used to connect to a non-Azure OpenAI resource created directly with OpenAI.
        ///     For Azure OpenAI resources as created and maintained in Azure Portal, use a constructor that
        ///     provides an Azure resource endpoint and credential, instead.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="openAIAuthToken"/> is null. </exception>
        public OpenAIClient(string openAIAuthToken) : this(openAIAuthToken, new OpenAIClientOptions())
        {
        }

        /// <summary> Initializes a instance of OpenAIClient using the public OpenAI endpoint. </summary>
        /// <param name="openAIAuthToken ">
        ///     String token to generate a token credential.
        ///     This string is used to connect to a non-Azure OpenAI resource created directly with OpenAI.
        ///     For Azure OpenAI resources as created and maintained in Azure Portal, use a constructor that
        ///     provides an Azure resource endpoint and credential, instead.
        /// </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="openAIAuthToken"/> is null. </exception>
        public OpenAIClient(string openAIAuthToken, OpenAIClientOptions options)
            : this(new Uri(publicOpenAIEndpoint), string.Empty, CreateDelegatedToken(openAIAuthToken), options)
        {
            PublicOpenAIToken = openAIAuthToken;
        }

        /// <summary> Initializes a new instance of OpenAIClient. </summary>
        /// <param name="endpoint">
        ///     Supported Cognitive Services endpoints (protocol and hostname, for example:
        ///     https://westus.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="deploymentId">
        ///     The deployment id for all operations (completions and embeddings) initiated using this client
        ///     instance.
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="endpoint"/> or <paramref name="credential"/> or <paramref name="deploymentId"/> is null.
        /// </exception>
        public OpenAIClient(Uri endpoint, string deploymentId, AzureKeyCredential credential)
            : this(endpoint, deploymentId, credential, new OpenAIClientOptions())
        {
        }

        /// <summary> Initializes a new instance of OpenAIClient. </summary>
        /// <param name="endpoint">
        ///     Supported Cognitive Services endpoints (protocol and hostname, for example:
        ///     https://westus.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="deploymentId">
        ///     The deployment id for all operations (completions and embeddings) initiated using this client
        ///     instance.
        /// </param>
        /// <param name="credential">
        ///     A credential used to authenticate to an Azure Service.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="endpoint"/> or <paramref name="credential"/> or <paramref name="deploymentId"/> is
        ///     null.
        /// </exception>
        public OpenAIClient(Uri endpoint, string deploymentId, TokenCredential credential)
            : this(endpoint, deploymentId, credential, new OpenAIClientOptions())
        {
        }

        /// <summary> Initializes a new instance of OpenAIClient. </summary>
        /// <param name="endpoint">
        ///     Supported Cognitive Services endpoints (protocol and hostname, for example:
        ///     https://westus.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="deploymentId">
        ///     The deployment id for all operations (completions and embeddings) initiated using this client
        ///     instance.
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="endpoint"/> or <paramref name="credential"/> or <paramref name="deploymentId"/>
        ///     is null.
        /// </exception>
        public OpenAIClient(
            Uri endpoint,
            string deploymentId,
            AzureKeyCredential credential,
            OpenAIClientOptions options)
            : this(endpoint, credential, options)
        {
            Argument.AssertNotNull(deploymentId, nameof(deploymentId));
            DeploymentId = deploymentId;
        }

        /// <summary> Initializes a new instance of OpenAIClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="deploymentId">
        ///     The deployment id for all operations (completions and embeddings) initiated using this client
        ///     instance.
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="endpoint"/> or <paramref name="credential"/>
        ///     or <paramref name="deploymentId"/> is null.
        /// </exception>
        public OpenAIClient(
            Uri endpoint,
            string deploymentId,
            TokenCredential credential,
            OpenAIClientOptions options)
            : this(endpoint, credential, options)
        {
            Argument.AssertNotNull(deploymentId, nameof(deploymentId));
            DeploymentId = deploymentId;
        }

        /// <summary> Return the completion for a given prompt. </summary>
        /// <param name="prompt"> Input string prompt to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="prompt"/> is null. </exception>
        public virtual async Task<Response<Completions>> GetCompletionsAsync(
            string prompt,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));

            CompletionsOptions completionsOptions = new CompletionsOptions();
            completionsOptions.Prompt.Add(prompt);
            return await GetCompletionsAsync(completionsOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return the completions for a given prompt. </summary>
        /// <param name="completionsOptions">
        ///     Post body schema to create a prompt completion from a deployment.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="completionsOptions"/> is null. </exception>
        public virtual async Task<Response<Completions>> GetCompletionsAsync(
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetCompletionsAsync(
                completionsOptions.ToRequestContent(),
                context).ConfigureAwait(false);
            return Response.FromValue(Completions.FromResponse(response), response);
        }

        /// <summary> Return the completions for a given prompt. </summary>
        /// <param name="prompt"> Input string prompt to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="prompt"/> is null. </exception>
        public virtual Response<Completions> GetCompletions(
            string prompt,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));
            CompletionsOptions completionsOptions = new CompletionsOptions();
            completionsOptions.Prompt.Add(prompt);
            return GetCompletions(completionsOptions, cancellationToken);
        }

        /// <summary> Return the embeddings for a given prompt. </summary>
        /// <param name="embeddingsOptions"> Schema to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="embeddingsOptions"/> is null. </exception>
        public virtual async Task<Response<Embeddings>> GetEmbeddingsAsync(
            EmbeddingsOptions embeddingsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(embeddingsOptions, nameof(embeddingsOptions));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetEmbeddingsAsync(
                embeddingsOptions.ToRequestContent(),
                context).ConfigureAwait(false);
            return Response.FromValue(Embeddings.FromResponse(response), response);
        }

        /// <summary> Return the embeddings for a given prompt. </summary>
        /// <param name="embeddingsOptions"> Schema to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="embeddingsOptions"/> is null. </exception>
        public virtual Response<Embeddings> GetEmbeddings(
            EmbeddingsOptions embeddingsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(embeddingsOptions, nameof(embeddingsOptions));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetEmbeddings(embeddingsOptions.ToRequestContent(), context);
            return Response.FromValue(Embeddings.FromResponse(response), response);
        }

        /// <summary> Return the embeddings for a given prompt. </summary>
        /// <param name="content">
        ///     The content to send as the body of the request. Details of the request body schema are in the
        ///     Remarks section below.
        /// </param>
        /// <param name="context">
        ///     The request context, which can override default behaviors of the client pipeline on a per-call
        ///     basis.
        /// </param>
        /// <exception cref="RequestFailedException">
        ///     Service returned a non-success status code.
        /// </exception>
        /// <returns>
        ///     The response returned from the service. Details of the response body schema are in the Remarks
        ///     section below.
        /// </returns>
        /// <include
        ///     file="../Generated/Docs/OpenAIClient.xml"
        ///     path="doc/members/member[@name='GetEmbeddingsAsync(String,RequestContent,RequestContext)']/*" />
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response> GetEmbeddingsAsync(
            RequestContent content,
            RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("OpenAIClient.GetEmbeddings");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetEmbeddingsRequest(DeploymentId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return the embeddings for a given prompt. </summary>
        /// <param name="content">
        ///     The content to send as the body of the request. Details of the request body schema are in the
        ///     Remarks section below.
        /// </param>
        /// <param name="context">
        ///     The request context, which can override default behaviors of the client pipeline on a per-call
        ///     basis.
        /// </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include
        ///     file="../Generated/Docs/OpenAIClient.xml"
        ///     path="doc/members/member[@name='GetEmbeddings(String,RequestContent,RequestContext)']/*" />
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response GetEmbeddings(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetEmbeddings");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetEmbeddingsRequest(DeploymentId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return the completions for a given prompt. </summary>
        /// <param name="completionsOptions">
        ///     The options for this completions request.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="completionsOptions"/> is null. </exception>
        public virtual Response<Completions> GetCompletions(
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetCompletions(completionsOptions.ToRequestContent(), context);
            return Response.FromValue(Completions.FromResponse(response), response);
        }

        /// <summary> Return the completions for a given prompt. </summary>
        /// <param name="content">
        ///     The content to send as the body of the request. Details of the request body schema are in the
        ///     Remarks section below.
        /// </param>
        /// <param name="context">
        ///     The request context, which can override default behaviors of the client pipeline on a per-call
        ///     basis.
        /// </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns>
        ///     The response returned from the service. Details of the response body schema are in the Remarks
        ///     section below.
        /// </returns>
        /// <include
        ///     file="../Generated/Docs/OpenAIClient.xml"
        ///     path="doc/members/member[@name='GetCompletionsAsync(String,RequestContent,RequestContext)']/*" />
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response> GetCompletionsAsync(
            RequestContent content,
            RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletions");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCompletionsRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return the completions for a given prompt. </summary>
        /// <param name="content">
        ///     The content to send as the body of the request. Details of the request body schema are in the
        ///     Remarks section below.
        /// </param>
        /// <param name="context">
        ///     The request context, which can override default behaviors of the client pipeline on a per-call
        ///     basis.
        /// </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns>
        ///     The response returned from the service. Details of the response body schema are in the Remarks
        ///     section below.
        /// </returns>
        /// <include
        ///     file="../Generated/Docs/OpenAIClient.xml"
        ///     path="doc/members/member[@name='GetCompletions(String,RequestContent,RequestContext)']/*" />
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response GetCompletions(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletions");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCompletionsRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
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
        /// <exception cref="ArgumentNullException"> <paramref name="completionsOptions"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns>
        /// A response that, if the request was successful, includes a <see cref="StreamingCompletions"/> instance.
        /// </returns>
        public virtual Response<StreamingCompletions> GetCompletionsStreaming(
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletionsStreaming");
            scope.Start();

            RequestContext context = FromCancellationToken(cancellationToken);

            RequestContent nonStreamingContent = completionsOptions.ToRequestContent();
            RequestContent streamingContent = GetStreamingEnabledRequestContent(nonStreamingContent);

            try
            {
                HttpMessage message = CreateGetCompletionsRequest(streamingContent, context);
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

        /// <summary>
        ///     Begin a completions request and get an object that can stream response data as it becomes available.
        /// </summary>
        /// <param name="completionsOptions"> the chat completions options for this completions request. </param>
        /// <param name="cancellationToken">
        ///     a cancellation token that can be used to cancel the initial request or ongoing streaming operation.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="completionsOptions"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns>
        /// A response that, if the request was successful, wraps a <see cref="StreamingCompletions"/> instance.
        /// </returns>
        public virtual async Task<Response<StreamingCompletions>> GetCompletionsStreamingAsync(
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletionsStreaming");
            scope.Start();

            RequestContext context = FromCancellationToken(cancellationToken);

            RequestContent nonStreamingContent = completionsOptions.ToRequestContent();
            RequestContent streamingContent = GetStreamingEnabledRequestContent(nonStreamingContent);

            try
            {
                HttpMessage message = CreateGetCompletionsRequest(streamingContent, context);
                message.BufferResponse = false;
                Response baseResponse = await _pipeline.ProcessMessageAsync(
                    message,
                    context,
                    cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new StreamingCompletions(baseResponse), baseResponse);
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
        /// <exception cref="ArgumentNullException"> <paramref name="chatCompletionsOptions"/> is null. </exception>
        public virtual async Task<Response<ChatCompletions>> GetChatCompletionsAsync(
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetChatCompletionsAsync(
                chatCompletionsOptions.ToRequestContent(),
                context).ConfigureAwait(false);
            return Response.FromValue(ChatCompletions.FromResponse(response), response);
        }

        /// <summary> Get chat completions for provided chat context messages. </summary>
        /// <param name="chatCompletionsOptions"> The options for this chat completions request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="chatCompletionsOptions"/> is null. </exception>
        public virtual Response<Completions> GetChatCompletions(
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetChatCompletions(chatCompletionsOptions.ToRequestContent(), context);
            return Response.FromValue(Completions.FromResponse(response), response);
        }

        /// <summary> Get chat completions for provided chat context messages. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context">
        ///     The request context, which can override default behaviors of the client pipeline on a per-call
        ///     basis.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetChatCompletionsAsync(
            RequestContent content,
            RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletions");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCompletionsRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get chat completions for provided chat context messages. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context">
        ///     The request context, which can override default behaviors of the client pipeline on a per-call
        ///     basis.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetChatCompletions(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletions");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetChatCompletionsRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
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
        /// <param name="completionsOptions">
        ///     the chat completions options for this chat completions request.
        /// </param>
        /// <param name="cancellationToken">
        ///     a cancellation token that can be used to cancel the initial request or ongoing streaming operation.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="completionsOptions"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response<StreamingChatCompletions> GetChatCompletionsStreaming(
            ChatCompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletionsStreaming");
            scope.Start();

            RequestContext context = FromCancellationToken(cancellationToken);

            RequestContent nonStreamingContent = completionsOptions.ToRequestContent();
            RequestContent streamingContent = GetStreamingEnabledRequestContent(nonStreamingContent);

            try
            {
                HttpMessage message = CreateGetCompletionsRequest(streamingContent, context);
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

        /// <summary>
        ///     Begin a chat completions request and return an object that can stream response data as it becomes
        ///     available.
        /// </summary>
        /// <param name="completionsOptions">
        ///     the chat completions options for this chat completions request.
        /// </param>
        /// <param name="cancellationToken">
        ///     a cancellation token that can be used to cancel the initial request or ongoing streaming operation.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="completionsOptions"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response<StreamingChatCompletions>> GetChatCompletionsStreamingAsync(
            ChatCompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletionsStreaming");
            scope.Start();

            RequestContext context = FromCancellationToken(cancellationToken);

            RequestContent nonStreamingContent = completionsOptions.ToRequestContent();
            RequestContent streamingContent = GetStreamingEnabledRequestContent(nonStreamingContent);

            try
            {
                HttpMessage message = CreateGetChatCompletionsRequest(streamingContent, context);
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

        internal HttpMessage CreateGetChatCompletionsRequest(RequestContent content, RequestContext context)
        {
            HttpMessage message = _pipeline.CreateMessage(context, ResponseClassifier200);
            Request request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/openai", false);
            uri.AppendPath("/deployments/", false);
            uri.AppendPath(DeploymentId, true);
            uri.AppendPath("/chat/completions", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static RequestContent GetStreamingEnabledRequestContent(RequestContent originalRequestContent)
        {
            // Dump the original request content to a temporary stream and seek to start
            using Stream originalRequestContentStream = new MemoryStream();
            originalRequestContent.WriteTo(originalRequestContentStream, new CancellationToken());
            originalRequestContentStream.Position = 0;

            JsonDocument originalJson = JsonDocument.Parse(originalRequestContentStream);
            JsonElement originalJsonRoot = originalJson.RootElement;

            Utf8JsonRequestContent augmentedContent = new Utf8JsonRequestContent();
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

        internal HttpMessage CreateGetCompletionsRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            if (!string.IsNullOrEmpty(DeploymentId))
            {
                uri.AppendRaw("/openai", false);
                uri.AppendPath("/deployments/", false);
                uri.AppendPath(DeploymentId, true);
                uri.AppendPath("/completions", false);
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            else
            {
                uri.AppendPath("/completions", false);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetEmbeddingsRequest(
            string deploymentId,
            RequestContent content,
            RequestContext context)
        {
            HttpMessage message = _pipeline.CreateMessage(context, ResponseClassifier200);
            Request request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            if (!string.IsNullOrEmpty(deploymentId))
            {
                uri.AppendRaw("/openai", false);
                uri.AppendPath("/deployments/", false);
                uri.AppendPath(deploymentId, true);
                uri.AppendPath("/embeddings", false);
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            else
            {
                uri.AppendPath("/embeddings", false);
            }
            request.Uri = uri;
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
    }
}
