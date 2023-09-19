// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.ServiceModel.Rest.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public class MessagePipeline // base of HttpPipelinePolicy
{
    private HttpPipeline _pipeline;

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="options"></param>
    public MessagePipeline(RequestOptions options)
    {
        _pipeline = HttpPipelineBuilder.Build(new ClientOptionsAdapter(options));
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="verb"></param>
    /// <param name="uri"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public PipelineMessage CreateMessage(string verb, Uri uri)
    {
        HttpMessage message = _pipeline.CreateMessage();
        message.Request.Uri.Reset(uri);
        switch (verb)
        {
            case "GET":
                message.Request.Method = RequestMethod.Get;
                break;
            case "POST":
                message.Request.Method = RequestMethod.Post;
                break;
            case "PUT":
                message.Request.Method = RequestMethod.Put;
                break;
            case "HEAD":
                message.Request.Method = RequestMethod.Head;
                break;
            case "DELETE":
                message.Request.Method = RequestMethod.Delete;
                break;
            case "PATCH":
                message.Request.Method = RequestMethod.Patch;
                break;
            default: throw new ArgumentOutOfRangeException(nameof(verb));
        }

        return new HttpMessageToPipelineMessageAdapter(message);
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Send(PipelineMessage message)
    {
        HttpMessage messageToSend;
        var m = message as HttpMessageToPipelineMessageAdapter;
        if (m == null)
        {
            messageToSend = new PipelineMessageToHttpMessageAdapter(message);
        }
        else
        {
            messageToSend = m._message;
        }
        _pipeline.Send(messageToSend, messageToSend.CancellationToken);
        var response = messageToSend.Response;
        message.Result = new PipelineResult(response);
    }
}

internal class PipelineResult : Result
{
    private Response _response;

    public PipelineResult(Response response)
    {
        _response = response;
    }

    public override int Status => _response.Status;

    public override Stream? ContentStream {
        get => _response.ContentStream;
        set => _response.ContentStream = value;
    }

    public override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
        => _response.TryGetHeader(name, out value);
}
