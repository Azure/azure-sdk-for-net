// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
[TestFixture(true)]
[TestFixture(false)]
public class SyncAsyncPolicyTestBase : SyncAsyncTestBase
{
    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="isAsync"></param>
    public SyncAsyncPolicyTestBase(bool isAsync) : base(isAsync)
    {
    }

    //protected Task<PipelineResponse> SendRequestAsync(HttpPipeline pipeline, Action<Request> requestAction, bool bufferResponse = true, CancellationToken cancellationToken = default)
    //{
    //    return SendRequestAsync(pipeline, message => requestAction(message.Request), bufferResponse, cancellationToken);
    //}

    //protected async Task<Response> SendRequestAsync(HttpPipeline pipeline, Action<HttpMessage> messageAction, bool bufferResponse = true, CancellationToken cancellationToken = default)
    //{
    //    return (await SendMessageRequestAsync(pipeline, messageAction, bufferResponse, cancellationToken: cancellationToken)).Response;
    //}

    //protected async Task<HttpMessage> SendMessageRequestAsync(HttpPipeline pipeline, Action<HttpMessage> messageAction, bool bufferResponse = true, HttpMessage message = default, CancellationToken cancellationToken = default)
    //{
    //    message ??= pipeline.CreateMessage();
    //    message.BufferResponse = bufferResponse;
    //    messageAction(message);

    //    if (IsAsync)
    //    {
    //        await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
    //    }
    //    else
    //    {
    //        pipeline.Send(message, cancellationToken);
    //    }

    //    return message;
    //}

    //protected async Task<Response> SendRequestAsync(HttpPipelineTransport transport, Action<HttpMessage> messageAction, HttpPipelinePolicy policy, ResponseClassifier responseClassifier = null, bool bufferResponse = true, CancellationToken cancellationToken = default)
    //{
    //    await Task.Yield();

    //    var pipeline = new HttpPipeline(transport, new[] { policy }, responseClassifier);
    //    return await SendRequestAsync(pipeline, messageAction, bufferResponse, cancellationToken);
    //}

    //protected Task<Response> SendRequestAsync(HttpPipelineTransport transport, Action<Request> requestAction, HttpPipelinePolicy policy, ResponseClassifier responseClassifier = null, bool bufferResponse = true, CancellationToken cancellationToken = default)
    //{
    //    return SendRequestAsync(transport, message => requestAction(message.Request), policy, responseClassifier, bufferResponse, cancellationToken);
    //}

    //protected async Task<Response> SendGetRequest(HttpPipelineTransport transport, HttpPipelinePolicy policy, ResponseClassifier responseClassifier = null, bool bufferResponse = true, Uri uri = null, CancellationToken cancellationToken = default)
    //{
    //    return await SendRequestAsync(transport, message =>
    //    {
    //        message.Request.Method = RequestMethod.Get;
    //        message.Request.Uri.Reset(uri ?? new Uri("http://example.com"));
    //    }, policy, responseClassifier, bufferResponse, cancellationToken);
    //}

    //protected async Task<HttpMessage> SendMessageGetRequest(HttpPipeline pipeline, HttpMessage message, ResponseClassifier responseClassifier = null, bool bufferResponse = true, Uri uri = null, CancellationToken cancellationToken = default)
    //{
    //    await Task.Yield();

    //    return await SendMessageRequestAsync(pipeline, message =>
    //        {
    //            message.Request.Method = RequestMethod.Get;
    //            message.Request.Uri.Reset(uri ?? new Uri("http://example.com"));
    //        },
    //        bufferResponse,
    //        message,
    //        cancellationToken);
    //}
}
