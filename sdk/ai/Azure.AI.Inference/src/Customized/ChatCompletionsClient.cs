// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Sse;

namespace Azure.AI.Inference
{
    // CUSTOM CODE NOTE:
    //   Modified code for the ChatCompletionsClient

    /// <summary> The ChatCompletions service client. </summary>
    public partial class ChatCompletionsClient
    {
        /// <summary>
        /// Gets chat completions for the provided chat messages.
        /// Completions support a wide variety of tasks and generate text that continues from or "completes"
        /// provided prompt data. The method makes a REST API call to the `/chat/completions` route
        /// on the given endpoint.
        /// </summary>
        /// <param name="chatCompletionsOptions">
        /// The configuration information for a chat completions request.
        /// Completions support a wide variety of tasks and generate text that continues from or "completes"
        /// provided prompt data.
        /// </param>
        /// <param name="extraParams">
        /// Controls what happens if extra parameters are passed in the JSON request payload.
        /// This sets the HTTP request header `extra-parameters`.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="chatCompletionsOptions"/> is null. </exception>
        public virtual async Task<Response<ChatCompletions>> CompleteAsync(ChatCompletionsOptions chatCompletionsOptions, ExtraParameters? extraParams = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            // CUSTOM CODE NOTE:
            //   If AdditionalProperties are provided, the decision has been made to default extraParams to "PassThrough"
            if (chatCompletionsOptions.AdditionalProperties != null && chatCompletionsOptions.AdditionalProperties.Count > 0)
            {
                extraParams ??= ExtraParameters.PassThrough;
            }

            using RequestContent content = chatCompletionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await CompleteAsync(content, extraParams?.ToString(), context).ConfigureAwait(false);
            return Response.FromValue(ChatCompletions.FromResponse(response), response);
        }

        /// <summary>
        /// Gets chat completions for the provided chat messages.
        /// Completions support a wide variety of tasks and generate text that continues from or "completes"
        /// provided prompt data. The method makes a REST API call to the `/chat/completions` route
        /// on the given endpoint.
        /// </summary>
        /// <param name="chatCompletionsOptions">
        /// The configuration information for a chat completions request.
        /// Completions support a wide variety of tasks and generate text that continues from or "completes"
        /// provided prompt data.
        /// </param>
        /// <param name="extraParams">
        /// Controls what happens if extra parameters are passed in the JSON request payload.
        /// This sets the HTTP request header `extra-parameters`.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="chatCompletionsOptions"/> is null. </exception>
        public virtual Response<ChatCompletions> Complete(ChatCompletionsOptions chatCompletionsOptions, ExtraParameters? extraParams = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            // CUSTOM CODE NOTE:
            //   If AdditionalProperties are provided, the decision has been made to default extraParams to "PassThrough"
            if (chatCompletionsOptions.AdditionalProperties != null && chatCompletionsOptions.AdditionalProperties.Count > 0)
            {
                extraParams ??= ExtraParameters.PassThrough;
            }

            using RequestContent content = chatCompletionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Complete(content, extraParams?.ToString(), context);
            return Response.FromValue(ChatCompletions.FromResponse(response), response);
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
        public virtual async Task<StreamingResponse<StreamingChatCompletionsUpdate>> CompleteStreamingAsync(
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ChatCompletionsClient.CompleteStreaming");
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
        public virtual StreamingResponse<StreamingChatCompletionsUpdate> CompleteStreaming(
            ChatCompletionsOptions chatCompletionsOptions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ChatCompletionsClient.CompleteStreaming");
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

        internal HttpMessage CreatePostRequestMessage(
            ChatCompletionsOptions chatCompletionsOptions,
            RequestContent content,
            RequestContext context)
        {
            string operationPath = "/chat/completions";
            return CreatePostRequestMessage(operationPath, content, context);
        }

        internal HttpMessage CreatePostRequestMessage(
            string operationPath,
            RequestContent content,
            RequestContext context)
        {
            HttpMessage message = _pipeline.CreateMessage(context, ResponseClassifier200);
            Request request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath(operationPath, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }
    }
}
