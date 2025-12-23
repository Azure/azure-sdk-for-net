// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.AgentServer.Core.Tools.Operations;

internal interface IToolOperationsInvoker
{
    HttpMessage CreatePostMessage(string relativeUri, BinaryData content, CancellationToken cancellationToken);
    Response SendRequest(HttpMessage message, CancellationToken cancellationToken);
    Task<Response> SendRequestAsync(HttpMessage message, CancellationToken cancellationToken);
}

internal sealed class ToolOperationsInvoker : IToolOperationsInvoker
{
    private readonly HttpPipeline _pipeline;
    private readonly Uri _endpoint;

    public ToolOperationsInvoker(HttpPipeline pipeline, Uri endpoint)
    {
        _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
        _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
    }

    public HttpMessage CreatePostMessage(
        string relativeUri,
        BinaryData content,
        CancellationToken cancellationToken)
    {
        var message = _pipeline.CreateMessage(CreateRequestContext(cancellationToken));
        var request = message.Request;
        request.Method = RequestMethod.Post;
        request.Uri.Reset(new Uri(_endpoint, relativeUri));
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("Content-Type", "application/json");
        request.Content = RequestContent.Create(content);
        return message;
    }

    public Response SendRequest(HttpMessage message, CancellationToken cancellationToken)
    {
        _pipeline.Send(message, cancellationToken);
        if (message.Response.IsError)
        {
            throw new RequestFailedException(message.Response);
        }

        return message.Response;
    }

    public async Task<Response> SendRequestAsync(
        HttpMessage message,
        CancellationToken cancellationToken)
    {
        await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
        if (message.Response.IsError)
        {
            throw new RequestFailedException(message.Response);
        }

        return message.Response;
    }

    private static RequestContext? CreateRequestContext(CancellationToken cancellationToken)
    {
        return cancellationToken.CanBeCanceled
            ? new RequestContext { CancellationToken = cancellationToken }
            : null;
    }
}
