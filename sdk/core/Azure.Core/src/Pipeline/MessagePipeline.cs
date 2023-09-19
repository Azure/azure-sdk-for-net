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
        _pipeline = HttpPipelineBuilder.Build(options);
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
        _pipeline.CreateRequest();
        HttpMessage message = _pipeline.CreateMessage();
        message.Request.Uri.Reset(uri);
        message.Request.Method = RequestMethod.Post; // TODO: don't hardcode
        return new MessageAdapter(message);
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Send(PipelineMessage message)
    {
        HttpMessage? m = message as HttpMessage;
        if (m == null)
        {
            m = new MessageAdapter(message);
        }
        _pipeline.Send(m, m.CancellationToken);
        var response = m.Response;
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

    public override int Status => throw new NotImplementedException();

    public override Stream? ContentStream {
        get => _response.ContentStream;
        set => _response.ContentStream = value;
    }

    public override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
        => _response.TryGetHeader(name, out value);
}
