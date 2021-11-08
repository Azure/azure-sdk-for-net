// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Experimental
{
    internal static class HttpPipelineExtensions
    {
        public static async ValueTask<Response> ProcessMessageAsync(this HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, RequestContext? requestContext, CancellationToken cancellationToken = default)
        {
            ErrorOptions errorOptions = ErrorOptions.Default;
            CancellationToken operationCancellationToken = CancellationToken.None;

            if (requestContext != null)
            {
                errorOptions = requestContext.ErrorOptions;
                operationCancellationToken = MergeCancellationTokens(requestContext, cancellationToken);
            }

            await pipeline.SendAsync(message, operationCancellationToken).ConfigureAwait(false);

            if (errorOptions == ErrorOptions.NoThrow || !message.ResponseClassifier.IsErrorResponse(message))
            {
                return message.Response;
            }

            throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
        }

        public static Response ProcessMessage(this HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, RequestContext? requestContext, CancellationToken cancellationToken = default)
        {
            ErrorOptions errorOptions = ErrorOptions.Default;
            CancellationToken operationCancellationToken = CancellationToken.None;

            if (requestContext != null)
            {
                errorOptions = requestContext.ErrorOptions;
                operationCancellationToken = MergeCancellationTokens(requestContext, cancellationToken);
            }

            pipeline.Send(message, operationCancellationToken);

            if (errorOptions == ErrorOptions.NoThrow || !message.ResponseClassifier.IsErrorResponse(message))
            {
                return message.Response;
            }

            throw clientDiagnostics.CreateRequestFailedException(message.Response);
        }

        private static CancellationToken MergeCancellationTokens(RequestContext context, CancellationToken cancellationToken)
        {
            if (context.CancellationToken.CanBeCanceled && cancellationToken.CanBeCanceled)
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(context.CancellationToken, cancellationToken);
                return cts.Token;
            }

            if (cancellationToken.CanBeCanceled)
            {
                return cancellationToken;
            }

            return context.CancellationToken;
        }
    }
}
