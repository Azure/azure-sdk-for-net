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
public class Utf16HttpTransport
    : PipelineTransport<Utf16HttpMessage>, IDisposable
{
    private HttpClientTransport _transport;

    /// <summary>
    /// TBD.
    /// </summary>
    public static Utf16HttpTransport Default { get; } = new Utf16HttpTransport();

    /// <summary>
    /// TBD.
    /// </summary>
    private Utf16HttpTransport()
        => _transport = new HttpClientTransport();

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="verb"></param>
    /// <param name="uri"></param>
    /// <returns></returns>
    public override Utf16HttpMessage CreateMessage(string verb, Uri uri)
    {
        Request request = _transport.CreateRequest();
        request.Uri.Reset(uri);
        request.Method = VerbToMethod(verb);
        var message = new MessagePipelineMessage(request);
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
    public override void Process(Utf16HttpMessage message)
    {
        HttpMessage adapted = ToHttpMessage(message);
        _transport.Process(adapted);
        message.Response = FromHttpMessage(adapted);
    }

    /// <summary>
    /// TBD>
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async override ValueTask ProcessAsync(Utf16HttpMessage message)
    {
        HttpMessage adapted = ToHttpMessage(message);
        await _transport.ProcessAsync(adapted).ConfigureAwait(false);
        message.Response = await FromHttpMessageAsync(adapted).ConfigureAwait(false);
    }

    private static HttpMessage ToHttpMessage(Utf16HttpMessage message)
    {
        var tam = message as MessagePipelineMessage;
        if (tam == null) throw new Exception("this message is not mine");

        var rq = tam.Request as Request;
        if (rq == null) throw new InvalidOperationException("not my request");

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

    private static RequestMethod VerbToMethod(string verb)
    {
        switch (verb)
        {
            case "GET": return RequestMethod.Get;
            case "POST":return RequestMethod.Post;
            case "PUT":return RequestMethod.Put;
            case "HEAD":return RequestMethod.Head;
            case "DELETE":return RequestMethod.Delete;
            case "PATCH": return RequestMethod.Patch;
            default:
                throw new ArgumentOutOfRangeException(nameof(verb));
        }
    }
}

internal class MessagePipelineMessage : Utf16HttpMessage
{
    private Request _request;
    public MessagePipelineMessage(Request request) : base(request)
        => _request = request;
}
