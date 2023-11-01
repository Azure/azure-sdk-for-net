// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.ClientModel.Internal;

public static class PipelineProtocolExtensions
{
    public static async ValueTask<MessageResponse> ProcessMessageAsync(this MessagePipeline pipeline, ClientMessage message, RequestOptions requestContext, CancellationToken cancellationToken = default)
    {
        await pipeline.SendAsync(message).ConfigureAwait(false);

        if (message.Response is null)
        {
            throw new InvalidOperationException("Failed to receive Result.");
        }

        if (!message.Response.IsError || requestContext?.ErrorBehavior == ErrorBehavior.NoThrow)
        {
            return message.Response;
        }

        throw new UnsuccessfulRequestException(message.Response);
    }

    public static MessageResponse ProcessMessage(this MessagePipeline pipeline, ClientMessage message, RequestOptions requestContext, CancellationToken cancellationToken = default)
    {
        pipeline.Send(message);

        if (message.Response is null)
        {
            throw new InvalidOperationException("Failed to receive Result.");
        }

        if (!message.Response.IsError || requestContext?.ErrorBehavior == ErrorBehavior.NoThrow)
        {
            return message.Response;
        }

        throw new UnsuccessfulRequestException(message.Response);
    }

    public static async ValueTask<NullableResult<bool>> ProcessHeadAsBoolMessageAsync(this MessagePipeline pipeline, ClientMessage message, RequestOptions requestContext)
    {
        MessageResponse response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
        switch (response.Status)
        {
            case >= 200 and < 300:
                return Result.FromValue(true, response);
            case >= 400 and < 500:
                return Result.FromValue(false, response);
            default:
                return new ErrorResult<bool>(response, new UnsuccessfulRequestException(response));
        }
    }

    public static NullableResult<bool> ProcessHeadAsBoolMessage(this MessagePipeline pipeline, ClientMessage message, RequestOptions requestContext)
    {
        MessageResponse response = pipeline.ProcessMessage(message, requestContext);
        switch (response.Status)
        {
            case >= 200 and < 300:
                return Result.FromValue(true, response);
            case >= 400 and < 500:
                return Result.FromValue(false, response);
            default:
                return new ErrorResult<bool>(response, new UnsuccessfulRequestException(response));
        }
    }

    internal class ErrorResult<T> : NullableResult<T>
    {
        private readonly MessageResponse _response;
        private readonly UnsuccessfulRequestException _exception;

        public ErrorResult(MessageResponse response, UnsuccessfulRequestException exception)
            : base(default, response)
        {
            _response = response;
            _exception = exception;
        }

        public override T Value { get => throw _exception; }

        public override bool HasValue => false;

        public override MessageResponse GetRawResponse() => _response;
    }
}
