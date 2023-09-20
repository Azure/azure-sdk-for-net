// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Core;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Shared.Pipeline
{
    public static class PipelineProtocolExtensions
    {
        public static async ValueTask<Result> ProcessMessageAsync(this HttpPipeline pipeline, RestMessage message, PipelineOptions? requestContext, CancellationToken cancellationToken = default)
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

            if (!message.Result.IsError || statusOption == ResultErrorOptions.NoThrow)
            {
                return message.Result;
            }

            throw new RequestErrorException(message.Result);
        }

        public static Result ProcessMessage(this HttpPipeline pipeline, RestMessage message, PipelineOptions? requestContext, CancellationToken cancellationToken = default)
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

            if (!message.Result.IsError || statusOption == ResultErrorOptions.NoThrow)
            {
                return message.Result;
            }

            throw new RequestErrorException(message.Result);
        }

        public static async ValueTask<Result<bool>> ProcessHeadAsBoolMessageAsync(this HttpPipeline pipeline, RestMessage message, TelemetrySource clientDiagnostics, PipelineOptions? requestContext)
        {
            var response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
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

        public static Result<bool> ProcessHeadAsBoolMessage(this HttpPipeline pipeline, RestMessage message, TelemetrySource clientDiagnostics, PipelineOptions? requestContext)
        {
            var response = pipeline.ProcessMessage(message, requestContext);
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

        private static (CancellationToken CancellationToken, ResultErrorOptions ErrorOptions) ApplyRequestContext(PipelineOptions? requestContext)
        {
            if (requestContext == null)
            {
                return (CancellationToken.None, ResultErrorOptions.Default);
            }

            return (requestContext.CancellationToken, requestContext.ErrorOptions);
        }

        internal class ErrorResult<T> : Result<T>
        {
            private readonly Result _response;
            private readonly RequestErrorException _exception;

            public ErrorResult(Result response, RequestErrorException exception)
            {
                _response = response;
                _exception = exception;
            }

            public override T Value { get => throw _exception; }

            public override Result GetRawResult() => _response;
        }
    }
}
