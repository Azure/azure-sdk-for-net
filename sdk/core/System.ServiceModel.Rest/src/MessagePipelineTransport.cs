// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using System.ServiceModel.Rest.Core;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public class MessagePipelineTransport : PipelineTransport<PipelineMessage>, IDisposable
{
    private HttpClient _transport;

    /// <summary>
    /// TBD.
    /// </summary>
    public MessagePipelineTransport()
    {
        // TODO:
        //   - SSL settings?
        //   - Proxy settings?
        //   - Cookies?

        HttpClientHandler handler = new HttpClientHandler()
        {
            AllowAutoRedirect = false
        };

        _transport = new HttpClient()
        {
            // TODO: Timeouts are handled by the pipeline
            Timeout = Timeout.InfiniteTimeSpan,
        };
    }

    public override PipelineMessage CreateMessage(RequestOptions options, ResponseErrorClassifier classifier)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public override void Process(PipelineMessage message)
    {
        throw new NotImplementedException();
    }

    public override ValueTask ProcessAsync(PipelineMessage message)
    {
        throw new NotImplementedException();
    }

    ///// <summary>
    ///// TBD.
    ///// </summary>
    ///// <param name="options"></param>
    ///// <param name="classifier"></param>
    ///// <returns></returns>
    //public override PipelineMessage CreateMessage(RequestOptions options, ResponseErrorClassifier classifier)
    //{
    //    Request request = _transport.CreateRequest();
    //    HttpMessage message = new HttpMessage(request, classifier);
    //    message.CancellationToken = options.CancellationToken;
    //    return message;
    //}

    ///// <summary>
    ///// TBD.
    ///// </summary>
    //public void Dispose() => _transport.Dispose();

    ///// <summary>
    ///// TBD.
    ///// </summary>
    ///// <param name="message"></param>
    //public override void Process(PipelineMessage message)
    //{
    //    HttpMessage adapted = ToHttpMessage(message);
    //    _transport.Process(adapted);
    //    message.PipelineResponse = FromHttpMessage(adapted);
    //}

    ///// <summary>
    ///// TBD>
    ///// </summary>
    ///// <param name="message"></param>
    ///// <returns></returns>
    //public async override ValueTask ProcessAsync(PipelineMessage message)
    //{
    //    HttpMessage adapted = ToHttpMessage(message);
    //    await _transport.ProcessAsync(adapted).ConfigureAwait(false);
    //    message.PipelineResponse = await FromHttpMessageAsync(adapted).ConfigureAwait(false);
    //}

    //private static HttpMessage ToHttpMessage(PipelineMessage message)
    //{
    //    var tam = message as HttpMessage;
    //    if (tam == null)
    //        throw new Exception("this message is not mine");

    //    var rq = tam.PipelineRequest as Request;
    //    if (rq == null)
    //        throw new InvalidOperationException("not my request");

    //    var m = new HttpMessage(rq, new ResponseClassifier());
    //    m.BufferResponse = true;
    //    return m;
    //}
    //private static PipelineResponse FromHttpMessage(HttpMessage message)
    //{
    //    Response response = message.Response;
    //    if (response.ContentStream != null)
    //    {
    //        using var liveStream = response.ContentStream;
    //        var buffer = new MemoryStream();
    //        liveStream.CopyTo(buffer);
    //        buffer.Position = 0;
    //        response.ContentStream = buffer;
    //    }
    //    return response;
    //}

    //private static async Task<PipelineResponse> FromHttpMessageAsync(HttpMessage message)
    //{
    //    Response response = message.Response;
    //    if (response.ContentStream != null)
    //    {
    //        using var liveStream = response.ContentStream;
    //        var buffer = new MemoryStream();
    //        await liveStream.CopyToAsync(buffer).ConfigureAwait(false);
    //        buffer.Position = 0;
    //        response.ContentStream = buffer;
    //    }
    //    return response;
    //}
}
