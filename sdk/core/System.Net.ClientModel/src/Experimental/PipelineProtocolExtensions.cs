// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.ClientModel.Internal;

public static class PipelineProtocolExtensions
{
    public static async ValueTask<PipelineResponse> ProcessMessageAsync(this MessagePipeline pipeline, PipelineMessage message, RequestOptions requestContext, CancellationToken cancellationToken = default)
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

        throw new PipelineRequestException(message.Response);
    }

    public static PipelineResponse ProcessMessage(this MessagePipeline pipeline, PipelineMessage message, RequestOptions requestContext, CancellationToken cancellationToken = default)
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

        throw new PipelineRequestException(message.Response);
    }

    public static async ValueTask<NullableResult<bool>> ProcessHeadAsBoolMessageAsync(this MessagePipeline pipeline, PipelineMessage message, TelemetrySource clientDiagnostics, RequestOptions requestContext)
    {
        PipelineResponse response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
        switch (response.Status)
        {
            case >= 200 and < 300:
                return Result.FromValue(true, response);
            case >= 400 and < 500:
                return Result.FromValue(false, response);
            default:
                return new ErrorResult<bool>(response, new PipelineRequestException(response));
        }
    }

    public static NullableResult<bool> ProcessHeadAsBoolMessage(this MessagePipeline pipeline, PipelineMessage message, TelemetrySource clientDiagnostics, RequestOptions requestContext)
    {
        PipelineResponse response = pipeline.ProcessMessage(message, requestContext);
        switch (response.Status)
        {
            case >= 200 and < 300:
                return Result.FromValue(true, response);
            case >= 400 and < 500:
                return Result.FromValue(false, response);
            default:
                return new ErrorResult<bool>(response, new PipelineRequestException(response));
        }
    }

    internal class ErrorResult<T> : NullableResult<T>
    {
        private readonly PipelineResponse _response;
        private readonly PipelineRequestException _exception;

        public ErrorResult(PipelineResponse response, PipelineRequestException exception)
            : base(default, response)
        {
            _response = response;
            _exception = exception;
        }

        public override T Value { get => throw _exception; }

        public override bool HasValue => false;

        public override PipelineResponse GetRawResponse() => _response;
    }
}
