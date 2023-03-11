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
        /// <summary> Return the completion for a given prompt. </summary>
        /// <param name="deploymentId"> Deployment id (also known as model name) to use for operations </param>
        /// <param name="prompt"> Input string prompt to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Completions>> GetCompletionsAsync(string deploymentId, string prompt, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
            Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));

            CompletionsOptions completionsOptions = new CompletionsOptions();
            completionsOptions.Prompt.Add(prompt);
            return await GetCompletionsAsync(deploymentId, completionsOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return the completions for a given prompt. </summary>
        /// <param name="deploymentId"> Deployment id (also known as model name) to use for operations </param>
        /// <param name="prompt"> Input string prompt to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Completions> GetCompletions(string deploymentId, string prompt, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
            Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));

            CompletionsOptions completionsOptions = new CompletionsOptions();
            completionsOptions.Prompt.Add(prompt);
            return GetCompletions(deploymentId, completionsOptions, cancellationToken);
        }

        public virtual Response<StreamingCompletions> GetCompletionsStreaming(
            string deploymentId,
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                "OpenAIClient.GetCompletionsStreaming");
            scope.Start();

            RequestContext context = FromCancellationToken(cancellationToken);

            RequestContent nonStreamingContent = completionsOptions.ToRequestContent();
            RequestContent streamingContent = GetStreamingEnabledRequestContent(nonStreamingContent);

            try
            {
                HttpMessage message = CreateGetCompletionsRequest(deploymentId, streamingContent, context);
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

        public virtual async Task<Response<StreamingCompletions>> GetCompletionsStreamingAsync(
            string deploymentId,
            CompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                "OpenAIClient.GetCompletionsStreaming");
            scope.Start();

            RequestContext context = FromCancellationToken(cancellationToken);

            RequestContent nonStreamingContent = completionsOptions.ToRequestContent();
            RequestContent streamingContent = GetStreamingEnabledRequestContent(nonStreamingContent);

            try
            {
                HttpMessage message = CreateGetCompletionsRequest(deploymentId, streamingContent, context);
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

        /// <summary> Return the chat completions for provided chat messages. </summary>
        /// <param name="deploymentId"> deployment id of the deployed model. </param>
        /// <param name="chatCompletionsOptions"> Post body schema to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentId"/> or <paramref name="chatCompletionsOptions"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<ChatCompletions>> GetChatCompletionsAsync(
            string deploymentId,
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetChatCompletionsAsync(
                deploymentId,
                chatCompletionsOptions.ToRequestContent(),
                context).ConfigureAwait(false);
            return Response.FromValue(ChatCompletions.FromResponse(response), response);
        }

        /// <summary> Return the completions for a given prompt. </summary>
        /// <param name="deploymentId"> deployment id of the deployed model. </param>
        /// <param name="chatCompletionsOptions"> Post body schema to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentId"/> or <paramref name="chatCompletionsOptions"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<Completions> GetChatCompletions(
            string deploymentId,
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetChatCompletions(deploymentId, chatCompletionsOptions.ToRequestContent(), context);
            return Response.FromValue(Completions.FromResponse(response), response);
        }

        /// <summary> Return the completions for a given prompt. </summary>
        /// <param name="deploymentId"> deployment id of the deployed model. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        public virtual async Task<Response> GetChatCompletionsAsync(
            string deploymentId,
            RequestContent content,
            RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletions");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCompletionsRequest(deploymentId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return the completions for a given prompt. </summary>
        /// <param name="deploymentId"> deployment id of the deployed model. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        public virtual Response GetChatCompletions(string deploymentId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletions");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetChatCompletionsRequest(deploymentId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<StreamingChatCompletions> GetChatCompletionsStreaming(
            string deploymentId,
            ChatCompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                "OpenAIClient.GetChatCompletionsStreaming");
            scope.Start();

            RequestContext context = FromCancellationToken(cancellationToken);

            RequestContent nonStreamingContent = completionsOptions.ToRequestContent();
            RequestContent streamingContent = GetStreamingEnabledRequestContent(nonStreamingContent);

            try
            {
                HttpMessage message = CreateGetCompletionsRequest(deploymentId, streamingContent, context);
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

        public virtual async Task<Response<StreamingChatCompletions>> GetChatCompletionsStreamingAsync(
            string deploymentId,
            ChatCompletionsOptions completionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                "OpenAIClient.GetChatCompletionsStreaming");
            scope.Start();

            RequestContext context = FromCancellationToken(cancellationToken);

            RequestContent nonStreamingContent = completionsOptions.ToRequestContent();
            RequestContent streamingContent = GetStreamingEnabledRequestContent(nonStreamingContent);

            try
            {
                HttpMessage message = CreateGetChatCompletionsRequest(deploymentId, streamingContent, context);
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

        internal HttpMessage CreateGetChatCompletionsRequest(
            string deploymentId,
            RequestContent content,
            RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/openai", false);
            uri.AppendPath("/deployments/", false);
            uri.AppendPath(deploymentId, true);
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
    }
}
