// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.ServiceModel.Rest.Core;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public class MessagePipelineTransport : PipelineTransport<PipelineMessage>, IDisposable
{
    private HttpClientTransport _transport;

    /// <summary>
    /// TBD.
    /// </summary>
    public MessagePipelineTransport()
        => _transport = new HttpClientTransport();

    ///// <summary>
    ///// TBD.
    ///// </summary>
    ///// <param name="verb"></param>
    ///// <param name="uri"></param>
    ///// <returns></returns>
    //public override PipelineMessage CreateMessage(string verb, Uri uri)
    //{
    //    Request request = _transport.CreateRequest();
    //    request.Uri.Reset(uri);
    //    request.Method = VerbToMethod(verb);
    //    var message = new MessagePipelineMessage(request);
    //    return message;
    //}

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="classifier"></param>
    /// <returns></returns>
    public override PipelineMessage CreateMessage(RequestOptions options, ResponseErrorClassifier classifier)
    {
        Request request = _transport.CreateRequest();
        HttpMessage message = new HttpMessage(request, (ResponseClassifier)classifier);
        message.CancellationToken = options.CancellationToken;
        return message;
    }

    /// <summary>
    /// TBD.
    /// </summary>
    public void Dispose() => _transport.Dispose();

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    public override void Process(PipelineMessage message)
    {
        HttpMessage adapted = ToHttpMessage(message);
        _transport.Process(adapted);
        message.PipelineResponse = FromHttpMessage(adapted);
    }

    /// <summary>
    /// TBD>
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async override ValueTask ProcessAsync(PipelineMessage message)
    {
        HttpMessage adapted = ToHttpMessage(message);
        await _transport.ProcessAsync(adapted).ConfigureAwait(false);
        message.PipelineResponse = await FromHttpMessageAsync(adapted).ConfigureAwait(false);
    }

    private static HttpMessage ToHttpMessage(PipelineMessage message)
    {
        var tam = message as HttpMessage;
        if (tam == null)
            throw new Exception("this message is not mine");

        var rq = tam.PipelineRequest as Request;
        if (rq == null)
            throw new InvalidOperationException("not my request");

        var m = new HttpMessage(rq, new ResponseClassifier());
        m.BufferResponse = true;
        return m;
    }
    private static PipelineResponse FromHttpMessage(HttpMessage message)
    {
        Response response = message.Response;
        if (response.ContentStream != null)
        {
            using var liveStream = response.ContentStream;
            var buffer = new MemoryStream();
            liveStream.CopyTo(buffer);
            buffer.Position = 0;
            response.ContentStream = buffer;
        }
        return response;
    }
    private static async Task<PipelineResponse> FromHttpMessageAsync(HttpMessage message)
    {
        Response response = message.Response;
        if (response.ContentStream != null)
        {
            using var liveStream = response.ContentStream;
            var buffer = new MemoryStream();
            await liveStream.CopyToAsync(buffer).ConfigureAwait(false);
            buffer.Position = 0;
            response.ContentStream = buffer;
        }
        return response;
    }
}
