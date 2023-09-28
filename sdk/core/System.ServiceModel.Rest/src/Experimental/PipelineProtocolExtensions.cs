// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Core.Pipeline;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Experimental.Core.Pipeline
{
    public static class PipelineProtocolExtensions
    {
        public static async ValueTask<PipelineResponse> ProcessMessageAsync(this Pipeline<PipelineMessage> pipeline, PipelineMessage message, RequestOptions? requestContext, CancellationToken cancellationToken = default)
        {
            await pipeline.SendAsync(message).ConfigureAwait(false);

            if (message.Response is null)
            {
                throw new InvalidOperationException("Failed to receive Result.");
            }

            if (!message.Response.IsError || requestContext?.ResultErrorOptions == ResultErrorOptions.NoThrow)
            {
                return message.Response;
            }

            throw new RequestErrorException(message.Response);
        }

        public static PipelineResponse ProcessMessage(this Pipeline<PipelineMessage> pipeline, PipelineMessage message, RequestOptions? requestContext, CancellationToken cancellationToken = default)
        {
            pipeline.Send(message);

            if (message.Response is null)
            {
                throw new InvalidOperationException("Failed to receive Result.");
            }

            if (!message.Response.IsError || requestContext?.ResultErrorOptions == ResultErrorOptions.NoThrow)
            {
                return message.Response;
            }

            throw new RequestErrorException(message.Response);
        }

        public static async ValueTask<NullableResult<bool>> ProcessHeadAsBoolMessageAsync(this Pipeline<PipelineMessage> pipeline, PipelineMessage message, TelemetrySource clientDiagnostics, RequestOptions? requestContext)
        {
            PipelineResponse response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
            switch (response.Status)
            {
                case >= 200 and < 300:
                    return Result.FromValue(true, response);
                case >= 400 and < 500:
                    return Result.FromValue(false, response);
                default:
                    return new ErrorResult<bool>(response, new RequestErrorException(response));
            }
        }

        public static NullableResult<bool> ProcessHeadAsBoolMessage(this Pipeline<PipelineMessage> pipeline, PipelineMessage message, TelemetrySource clientDiagnostics, RequestOptions? requestContext)
        {
            PipelineResponse response = pipeline.ProcessMessage(message, requestContext);
            switch (response.Status)
            {
                case >= 200 and < 300:
                    return Result.FromValue(true, response);
                case >= 400 and < 500:
                    return Result.FromValue(false, response);
                default:
                    return new ErrorResult<bool>(response, new RequestErrorException(response));
            }
        }

        internal class ErrorResult<T> : NullableResult<T>
        {
            private readonly PipelineResponse _response;
            private readonly RequestErrorException _exception;

            public ErrorResult(PipelineResponse response, RequestErrorException exception)
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
}
