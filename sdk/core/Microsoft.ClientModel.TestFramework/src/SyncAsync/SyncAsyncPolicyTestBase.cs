// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Base class for testing pipeline policies in both synchronous and asynchronous scenarios.
/// </summary>
[TestFixture(true)]
[TestFixture(false)]
public class SyncAsyncPolicyTestBase : SyncAsyncTestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SyncAsyncPolicyTestBase"/> class.
    /// </summary>
    /// <param name="isAsync">Whether to use asynchronous pipeline operations.</param>
    public SyncAsyncPolicyTestBase(bool isAsync) : base(isAsync)
    {
    }

    /// <summary>
    /// Sends an HTTP request through the specified pipeline using a request configuration action.
    /// </summary>
    /// <param name="pipeline">The client pipeline to send the request through.</param>
    /// <param name="requestAction">Action to configure the pipeline request.</param>
    /// <param name="bufferResponse">Whether to buffer the response content in memory.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The pipeline response.</returns>
    protected Task<PipelineResponse> SendRequestAsync(ClientPipeline pipeline, Action<PipelineRequest> requestAction, bool bufferResponse = true, CancellationToken cancellationToken = default)
    {
        return SendRequestAsync(pipeline, message => requestAction(message.Request), bufferResponse, cancellationToken);
    }

    /// <summary>
    /// Sends an HTTP request through the specified pipeline using a message configuration action.
    /// </summary>
    /// <param name="pipeline">The client pipeline to send the request through.</param>
    /// <param name="messageAction">Action to configure the pipeline message.</param>
    /// <param name="bufferResponse">Whether to buffer the response content in memory.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The pipeline response.</returns>
    protected async Task<PipelineResponse> SendRequestAsync(ClientPipeline pipeline, Action<PipelineMessage> messageAction, bool bufferResponse = true, CancellationToken cancellationToken = default)
    {
        PipelineMessage message = await SendMessageRequestAsync(pipeline, messageAction, bufferResponse, cancellationToken: cancellationToken).ConfigureAwait(false);
        return message.Response!;
    }

    /// <summary>
    /// Sends an HTTP request through the pipeline and returns the complete message with response.
    /// </summary>
    /// <param name="pipeline">The client pipeline to send the request through.</param>
    /// <param name="messageAction">Action to configure the pipeline message.</param>
    /// <param name="bufferResponse">Whether to buffer the response content in memory.</param>
    /// <param name="message">Optional existing message to use, or null to create a new one.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The pipeline message containing both request and response.</returns>
    protected async Task<PipelineMessage> SendMessageRequestAsync(ClientPipeline pipeline, Action<PipelineMessage> messageAction, bool bufferResponse = true, PipelineMessage? message = default, CancellationToken cancellationToken = default)
    {
        message ??= pipeline.CreateMessage();
        message.BufferResponse = bufferResponse;
        message.Apply(new RequestOptions() { CancellationToken = cancellationToken });
        messageAction(message);

        if (IsAsync)
        {
            await pipeline.SendAsync(message).ConfigureAwait(false);
        }
        else
        {
            pipeline.Send(message);
        }

        return message;
    }

    /// <summary>
    /// Sends an HTTP request through a transport with a custom policy applied.
    /// </summary>
    /// <param name="transport">The HTTP transport to use.</param>
    /// <param name="messageAction">Action to configure the pipeline message.</param>
    /// <param name="policy">The pipeline policy to apply.</param>
    /// <param name="responseClassifier">Optional classifier for response handling.</param>
    /// <param name="bufferResponse">Whether to buffer the response content in memory.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The pipeline response.</returns>
    protected async Task<PipelineResponse> SendRequestAsync(HttpClientPipelineTransport transport, Action<PipelineMessage> messageAction, PipelinePolicy policy, PipelineMessageClassifier? responseClassifier = null, bool bufferResponse = true, CancellationToken cancellationToken = default)
    {
        await Task.Yield();

        ClientPipelineOptions options = new ClientPipelineOptions
        {
            Transport = transport,
            // TODO - RetryPolicy =
        };
        var pipeline = ClientPipeline.Create(options);
        return await SendRequestAsync(pipeline, messageAction, bufferResponse, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends an HTTP request through a transport with a custom policy applied using a request configuration action.
    /// </summary>
    /// <param name="transport">The HTTP transport to use.</param>
    /// <param name="requestAction">Action to configure the pipeline request.</param>
    /// <param name="policy">The pipeline policy to apply.</param>
    /// <param name="responseClassifier">Optional classifier for response handling.</param>
    /// <param name="bufferResponse">Whether to buffer the response content in memory.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The pipeline response.</returns>
    protected Task<PipelineResponse> SendRequestAsync(HttpClientPipelineTransport transport, Action<PipelineRequest> requestAction, PipelinePolicy policy, PipelineMessageClassifier? responseClassifier = null, bool bufferResponse = true, CancellationToken cancellationToken = default)
    {
        return SendRequestAsync(transport, message => requestAction(message.Request), policy, responseClassifier, bufferResponse, cancellationToken);
    }

    /// <summary>
    /// Sends a GET request through a transport with a custom policy applied.
    /// </summary>
    /// <param name="transport">The HTTP transport to use.</param>
    /// <param name="policy">The pipeline policy to apply.</param>
    /// <param name="responseClassifier">Optional classifier for response handling.</param>
    /// <param name="bufferResponse">Whether to buffer the response content in memory.</param>
    /// <param name="uri">The URI to send the GET request to, or null to use http://example.com.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The pipeline response.</returns>
    protected async Task<PipelineResponse> SendGetRequest(HttpClientPipelineTransport transport, PipelinePolicy policy, PipelineMessageClassifier? responseClassifier = null, bool bufferResponse = true, Uri? uri = null, CancellationToken cancellationToken = default)
    {
        var response = await SendRequestAsync(transport, message =>
        {
            message.Request.Method = "GET";
            message.Request.Uri = uri ?? new Uri("http://example.com");
        }, policy, responseClassifier, bufferResponse, cancellationToken).ConfigureAwait(false);

        return response;
    }

    /// <summary>
    /// Sends a GET request through a pipeline and returns the complete message with response.
    /// </summary>
    /// <param name="pipeline">The client pipeline to send the request through.</param>
    /// <param name="message">The pipeline message to use for the request.</param>
    /// <param name="responseClassifier">Optional classifier for response handling.</param>
    /// <param name="bufferResponse">Whether to buffer the response content in memory.</param>
    /// <param name="uri">The URI to send the GET request to, or null to use http://example.com.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The pipeline message containing both request and response.</returns>
    protected async Task<PipelineMessage> SendMessageGetRequest(ClientPipeline pipeline, PipelineMessage message, PipelineMessageClassifier? responseClassifier = null, bool bufferResponse = true, Uri? uri = null, CancellationToken cancellationToken = default)
    {
        await Task.Yield();

        var response = await SendMessageRequestAsync(pipeline, message =>
        {
            message.Request.Method = "GET";
            message.Request.Uri = uri ?? new Uri("http://example.com");
        },
            bufferResponse,
            message,
            cancellationToken).ConfigureAwait(false);
        return response;
    }
}