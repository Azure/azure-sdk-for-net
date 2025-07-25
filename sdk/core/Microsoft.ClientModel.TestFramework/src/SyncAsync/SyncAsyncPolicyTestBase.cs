// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
[TestFixture(true)]
[TestFixture(false)]
public class SyncAsyncPolicyTestBase : SyncAsyncTestBase
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="isAsync"></param>
    public SyncAsyncPolicyTestBase(bool isAsync) : base(isAsync)
    {
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="pipeline"></param>
    /// <param name="requestAction"></param>
    /// <param name="bufferResponse"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected Task<PipelineResponse> SendRequestAsync(ClientPipeline pipeline, Action<PipelineRequest> requestAction, bool bufferResponse = true, CancellationToken cancellationToken = default)
    {
        return SendRequestAsync(pipeline, message => requestAction(message.Request), bufferResponse, cancellationToken);
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="pipeline"></param>
    /// <param name="messageAction"></param>
    /// <param name="bufferResponse"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected async Task<PipelineResponse> SendRequestAsync(ClientPipeline pipeline, Action<PipelineMessage> messageAction, bool bufferResponse = true, CancellationToken cancellationToken = default)
    {
        PipelineMessage message = await SendMessageRequestAsync(pipeline, messageAction, bufferResponse, cancellationToken: cancellationToken).ConfigureAwait(false);
        return message.Response!;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="pipeline"></param>
    /// <param name="messageAction"></param>
    /// <param name="bufferResponse"></param>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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
    /// TODO
    /// </summary>
    /// <param name="transport"></param>
    /// <param name="messageAction"></param>
    /// <param name="policy"></param>
    /// <param name="responseClassifier"></param>
    /// <param name="bufferResponse"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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
    /// TODO.
    /// </summary>
    /// <param name="transport"></param>
    /// <param name="requestAction"></param>
    /// <param name="policy"></param>
    /// <param name="responseClassifier"></param>
    /// <param name="bufferResponse"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected Task<PipelineResponse> SendRequestAsync(HttpClientPipelineTransport transport, Action<PipelineRequest> requestAction, PipelinePolicy policy, PipelineMessageClassifier? responseClassifier = null, bool bufferResponse = true, CancellationToken cancellationToken = default)
    {
        return SendRequestAsync(transport, message => requestAction(message.Request), policy, responseClassifier, bufferResponse, cancellationToken);
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="transport"></param>
    /// <param name="policy"></param>
    /// <param name="responseClassifier"></param>
    /// <param name="bufferResponse"></param>
    /// <param name="uri"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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
    /// TODO.
    /// </summary>
    /// <param name="pipeline"></param>
    /// <param name="message"></param>
    /// <param name="responseClassifier"></param>
    /// <param name="bufferResponse"></param>
    /// <param name="uri"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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