// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Core.Pipeline;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Internal;

public static class PipelineProtocolExtensions
{
    public static async ValueTask<PipelineResponse> ProcessMessageAsync(this Pipeline<PipelineMessage, InvocationOptions> pipeline, PipelineMessage message, InvocationOptions requestContext, CancellationToken cancellationToken = default)
    {
        await pipeline.SendAsync(message, requestContext).ConfigureAwait(false);

        if (message.Response is null)
        {
            throw new InvalidOperationException("Failed to receive Result.");
        }

        if (!message.Response.IsError || requestContext?.ErrorBehavior == ErrorBehavior.NoThrow)
        {
            return message.Response;
        }

        throw new MessageFailedException(message.Response);
    }

    public static PipelineResponse ProcessMessage(this Pipeline<PipelineMessage, InvocationOptions> pipeline, PipelineMessage message, InvocationOptions requestContext, CancellationToken cancellationToken = default)
    {
        pipeline.Send(message, requestContext);

        if (message.Response is null)
        {
            throw new InvalidOperationException("Failed to receive Result.");
        }

        if (!message.Response.IsError || requestContext?.ErrorBehavior == ErrorBehavior.NoThrow)
        {
            return message.Response;
        }

        throw new MessageFailedException(message.Response);
    }

    public static async ValueTask<NullableResult<bool>> ProcessHeadAsBoolMessageAsync(this Pipeline<PipelineMessage, InvocationOptions> pipeline, PipelineMessage message, TelemetrySource clientDiagnostics, InvocationOptions requestContext)
    {
        PipelineResponse response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
        switch (response.Status)
        {
            case >= 200 and < 300:
                return Result.FromValue(true, response);
            case >= 400 and < 500:
                return Result.FromValue(false, response);
            default:
                return new ErrorResult<bool>(response, new MessageFailedException(response));
        }
    }

    public static NullableResult<bool> ProcessHeadAsBoolMessage(this Pipeline<PipelineMessage, InvocationOptions> pipeline, PipelineMessage message, TelemetrySource clientDiagnostics, InvocationOptions requestContext)
    {
        PipelineResponse response = pipeline.ProcessMessage(message, requestContext);
        switch (response.Status)
        {
            case >= 200 and < 300:
                return Result.FromValue(true, response);
            case >= 400 and < 500:
                return Result.FromValue(false, response);
            default:
                return new ErrorResult<bool>(response, new MessageFailedException(response));
        }
    }

    internal class ErrorResult<T> : NullableResult<T>
    {
        private readonly PipelineResponse _response;
        private readonly MessageFailedException _exception;

        public ErrorResult(PipelineResponse response, MessageFailedException exception)
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
