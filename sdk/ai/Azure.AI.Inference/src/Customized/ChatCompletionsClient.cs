// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Inference.Telemetry;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Sse;

namespace Azure.AI.Inference
{
    // CUSTOM CODE NOTE:
    //   Modified code for the ChatCompletionsClient

    /// <summary> The ChatCompletions service client. </summary>

    [SuppressMessage("Azure Analysis", "AZC0007", Justification = "Analyzer is incorrectly flagging valid overloads.")]
    [CodeGenSuppress("Complete", typeof(ChatCompletionsOptions), typeof(ExtraParameters?), typeof(CancellationToken))]
    [CodeGenSuppress("CompleteAsync", typeof(ChatCompletionsOptions), typeof(ExtraParameters?), typeof(CancellationToken))]
    public partial class ChatCompletionsClient
    {
        /// <summary> Initializes a new instance of ChatCompletionsClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ChatCompletionsClient(Uri endpoint, AzureKeyCredential credential, AzureAIInferenceClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AzureAIInferenceClientOptions();
            credential.Deconstruct(out var key);
            options.AddPolicy(new AddApiKeyHeaderPolicy(key), HttpPipelinePosition.PerCall);

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="chatCompletionsOptions"/> is null. </exception>
        public virtual async Task<Response<ChatCompletions>> CompleteAsync(ChatCompletionsOptions chatCompletionsOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));
            ExtraParameters? extraParams = null;

            // CUSTOM CODE NOTE:
            //   If AdditionalProperties are provided, the decision has been made to default extraParams to "PassThrough"
            if (chatCompletionsOptions.AdditionalProperties != null && chatCompletionsOptions.AdditionalProperties.Count > 0)
            {
                extraParams ??= ExtraParameters.PassThrough;
            }

            using RequestContent content = chatCompletionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            using OpenTelemetryScope otelScope = OpenTelemetryScope.Start(chatCompletionsOptions, _endpoint);
            Response response = null;
            ChatCompletions chatCompletions = null;
            try
            {
                response = await CompleteAsync(content, extraParams?.ToString(), context).ConfigureAwait(false);
                chatCompletions = ChatCompletions.FromResponse(response);
                otelScope?.RecordResponse(chatCompletions);
            }
            catch (Exception ex)
            {
                otelScope?.RecordError(ex);
                throw;
            }
            return Response.FromValue(chatCompletions, response);
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="chatCompletionsOptions"/> is null. </exception>
        public virtual Response<ChatCompletions> Complete(ChatCompletionsOptions chatCompletionsOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));
            ExtraParameters? extraParams = null;

            // CUSTOM CODE NOTE:
            //   If AdditionalProperties are provided, the decision has been made to default extraParams to "PassThrough"
            if (chatCompletionsOptions.AdditionalProperties != null && chatCompletionsOptions.AdditionalProperties.Count > 0)
            {
                extraParams ??= ExtraParameters.PassThrough;
            }

            using RequestContent content = chatCompletionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            using OpenTelemetryScope otelScope = OpenTelemetryScope.Start(chatCompletionsOptions, _endpoint);
            Response response = null;
            ChatCompletions chatCompletions = null;
            try
            {
                response = Complete(content, extraParams?.ToString(), context);
                chatCompletions = ChatCompletions.FromResponse(response);
                otelScope?.RecordResponse(chatCompletions);
            }
            catch (Exception ex) {
                otelScope?.RecordError(ex);
                throw;
            }
            return Response.FromValue(chatCompletions, response);
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

            chatCompletionsOptions.InternalShouldStreamResponse = true;

            RequestContent content = chatCompletionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            OpenTelemetryScope otelScope = OpenTelemetryScope.Start(chatCompletionsOptions, _endpoint);
            Response baseResponse = null;
            try
            {
                // Response value object takes IDisposable ownership of message and scope.
                HttpMessage message = CreatePostRequestMessage(chatCompletionsOptions, content, context);
                message.BufferResponse = false;
                baseResponse = await _pipeline.ProcessMessageAsync(
                    message,
                    context,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                otelScope?.RecordError(e);
                otelScope?.Dispose();
                throw;
            }
            return StreamingResponse<StreamingChatCompletionsUpdate>.CreateFromResponse(
                baseResponse,
                (responseForEnumeration)
                    => SseAsyncEnumerator<StreamingChatCompletionsUpdate>.EnumerateFromSseStream(
                        responseForEnumeration.ContentStream,
                        StreamingChatCompletionsUpdate.DeserializeStreamingChatCompletionsUpdates,
                        otelScope,
                        cancellationToken
                        ));
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

            chatCompletionsOptions.InternalShouldStreamResponse = true;

            RequestContent content = chatCompletionsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            OpenTelemetryScope otelScope = OpenTelemetryScope.Start(chatCompletionsOptions, _endpoint);
            Response baseResponse;
            try
            {
                // Response value object takes IDisposable ownership of message and scope.
                HttpMessage message = CreatePostRequestMessage(chatCompletionsOptions, content, context);
                message.BufferResponse = false;
                baseResponse = _pipeline.ProcessMessage(message, context, cancellationToken);
            }
            catch (Exception e)
            {
                otelScope?.RecordError(e);
                otelScope?.Dispose();
                throw;
            }
            return StreamingResponse<StreamingChatCompletionsUpdate>.CreateFromResponse(
                baseResponse,
                (responseForEnumeration)
                    => SseAsyncEnumerator<StreamingChatCompletionsUpdate>.EnumerateFromSseStream(
                        responseForEnumeration.ContentStream,
                        StreamingChatCompletionsUpdate.DeserializeStreamingChatCompletionsUpdates,
                        otelScope,
                        cancellationToken
                        ));
        }

        /// <summary>
        /// [Protocol Method] Gets chat completions for the provided chat messages.
        /// Completions support a wide variety of tasks and generate text that continues from or "completes"
        /// provided prompt data. The method makes a REST API call to the `/chat/completions` route
        /// on the given endpoint.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CompleteAsync(ChatCompletionsOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="extraParams"> The <see cref="string"/> to use. Allowed values: "error" | "drop" | "pass-through". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<Response> CompleteAsync(RequestContent content, string extraParams = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ChatCompletionsClient.Complete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCompleteRequest(content, extraParams, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets chat completions for the provided chat messages.
        /// Completions support a wide variety of tasks and generate text that continues from or "completes"
        /// provided prompt data. The method makes a REST API call to the `/chat/completions` route
        /// on the given endpoint.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Complete(ChatCompletionsOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="extraParams"> The <see cref="string"/> to use. Allowed values: "error" | "drop" | "pass-through". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual Response Complete(RequestContent content, string extraParams = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ChatCompletionsClient.Complete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCompleteRequest(content, extraParams, context);
                return _pipeline.ProcessMessage(message, context);
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

        private class AddApiKeyHeaderPolicy : HttpPipelinePolicy
        {
            public string Token { get; }

            public AddApiKeyHeaderPolicy(string token)
            {
                Token = token;
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                // Add your desired header name and value
                message.Request.Headers.Add("api-key", Token);

                ProcessNext(message, pipeline);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                // Add your desired header name and value
                message.Request.Headers.Add("api-key", Token);

                return ProcessNextAsync(message, pipeline);
            }
        }
    }
}
