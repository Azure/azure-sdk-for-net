// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

#nullable enable

namespace Azure.AI.Agents.Persistent;

internal static class HttpPipelineExtensions
{
    public static async ValueTask<Response> ProcessMessageAsync(this HttpPipeline pipeline, HttpMessage message, RequestContext? requestContext, CancellationToken cancellationToken = default)
    {
        var (userCt, statusOption) = ApplyRequestContext(requestContext);
        if (!userCt.CanBeCanceled || !cancellationToken.CanBeCanceled)
        {
            await pipeline.SendAsync(message, cancellationToken.CanBeCanceled ? cancellationToken : userCt).ConfigureAwait(false);
        }
        else
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(userCt, cancellationToken);
            await pipeline.SendAsync(message, cts.Token).ConfigureAwait(false);
        }

        if (message.Response.IsError && (requestContext?.ErrorOptions & ErrorOptions.NoThrow) != ErrorOptions.NoThrow)
        {
            throw new RequestFailedException(message.Response);
        }

        return message.BufferResponse ?
               message.Response :
               message.ExtractResponse();
    }

    public static Response ProcessMessage(this HttpPipeline pipeline, HttpMessage message, RequestContext? requestContext, CancellationToken cancellationToken = default)
    {
        var (userCt, statusOption) = ApplyRequestContext(requestContext);
        if (!userCt.CanBeCanceled || !cancellationToken.CanBeCanceled)
        {
            pipeline.Send(message, cancellationToken.CanBeCanceled ? cancellationToken : userCt);
        }
        else
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(userCt, cancellationToken);
            pipeline.Send(message, cts.Token);
        }

        if (message.Response.IsError && (requestContext?.ErrorOptions & ErrorOptions.NoThrow) != ErrorOptions.NoThrow)
        {
            throw new RequestFailedException(message.Response);
        }

        return message.BufferResponse ?
               message.Response :
               message.ExtractResponse();
    }

    public static async ValueTask<Response<bool>> ProcessHeadAsBoolMessageAsync(this HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, RequestContext? requestContext)
    {
        var response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
        switch (response.Status)
        {
            case >= 200 and < 300:
                return Response.FromValue(true, response);
            case >= 400 and < 500:
                return Response.FromValue(false, response);
            default:
                return new ErrorResponse<bool>(response, new RequestFailedException(response));
        }
    }

    public static Response<bool> ProcessHeadAsBoolMessage(this HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, RequestContext? requestContext)
    {
        var response = pipeline.ProcessMessage(message, requestContext);
        switch (response.Status)
        {
            case >= 200 and < 300:
                return Response.FromValue(true, response);
            case >= 400 and < 500:
                return Response.FromValue(false, response);
            default:
                return new ErrorResponse<bool>(response, new RequestFailedException(response));
        }
    }

    private static (CancellationToken CancellationToken, ErrorOptions ErrorOptions) ApplyRequestContext(RequestContext? requestContext)
    {
        if (requestContext == null)
        {
            return (CancellationToken.None, ErrorOptions.Default);
        }

        return (requestContext.CancellationToken, requestContext.ErrorOptions);
    }

    internal class ErrorResponse<T> : Response<T>
    {
        private readonly Response _response;
        private readonly RequestFailedException _exception;

        public ErrorResponse(Response response, RequestFailedException exception)
        {
            _response = response;
            _exception = exception;
        }

        public override T Value { get => throw _exception; }

        public override Response GetRawResponse() => _response;
    }
}
