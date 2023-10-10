// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.ServiceModel.Rest.Core.Pipeline;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Pipeline policy to buffer response content or add a timeout to response content managed by the client
    /// </summary>
    internal class ResponseBodyPolicy : HttpPipelinePolicy
    {
        private readonly ResponseBufferingPolicy _policy;

        public ResponseBodyPolicy()
        {
            _policy = new ResponseBufferingPolicy();
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => await ProcessSyncOrAsync(message, pipeline, async: true).ConfigureAwait(false);

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => ProcessSyncOrAsync(message, pipeline, async: false).EnsureCompleted();

        private async ValueTask ProcessSyncOrAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            AzureCorePipelineEnumerator executor = new(message, pipeline);

            try
            {
                if (!ResponseBufferingPolicy.TryGetNetworkTimeout(message, out TimeSpan networkTimeout))
                {
                    throw new InvalidOperationException("NetworkTimeout must be set on the ResponseBodyPolicy.");
                }

                if (async)
                {
                    await _policy.ProcessAsync(message, executor).ConfigureAwait(false);
                }
                else
                {
                    _policy.Process(message, executor);
                }

                if (!ResponseBufferingPolicy.TryGetBufferResponse(message, out bool bufferResponse))
                {
                    // We default to buffering the response if not set on message.
                    bufferResponse = true;
                }

                if (!bufferResponse && networkTimeout != Timeout.InfiniteTimeSpan)
                {
                    // TODO: tidy this up - there is a bug here if customer overrides default transport
                    Stream? responseContentStream = message.Response.ContentStream;
                    if (responseContentStream == null || responseContentStream.CanSeek)
                    {
                        return;
                    }

                    message.Response.ContentStream = new ReadTimeoutStream(responseContentStream, networkTimeout);
                }
            }
            catch (TaskCanceledException e)
            {
                // TODO: come back and clean this up.
                if (e.Message.Contains("The operation was cancelled because it exceeded the configured timeout"))
                {
                    string exceptionMessage = e.Message +
                        $"Network timeout can be adjusted in {nameof(ClientOptions)}.{nameof(ClientOptions.Retry)}.{nameof(RetryOptions.NetworkTimeout)}.";
#if NETCOREAPP2_1_OR_GREATER
                    throw new TaskCanceledException(exceptionMessage, e.InnerException, e.CancellationToken);
#else
                    throw new TaskCanceledException(exceptionMessage, e.InnerException);
#endif
                }
                else
                {
                    throw e;
                }
            }
        }

        /// <summary>Throws a cancellation exception if cancellation has been requested via <paramref name="originalToken"/> or <paramref name="timeoutToken"/>.</summary>
        /// <param name="originalToken">The customer provided token.</param>
        /// <param name="timeoutToken">The linked token that is cancelled on timeout provided token.</param>
        /// <param name="inner">The inner exception to use.</param>
        /// <param name="timeout">The timeout used for the operation.</param>
#pragma warning disable CA1068 // Cancellation token has to be the last parameter
        internal static void ThrowIfCancellationRequestedOrTimeout(CancellationToken originalToken, CancellationToken timeoutToken, Exception? inner, TimeSpan timeout)
#pragma warning restore CA1068
        {
            CancellationHelper.ThrowIfCancellationRequested(originalToken);

            if (timeoutToken.IsCancellationRequested)
            {
                throw CancellationHelper.CreateOperationCanceledException(
                    inner,
                    timeoutToken,
                    $"The operation was cancelled because it exceeded the configured timeout of {timeout:g}. " +
                    $"Network timeout can be adjusted in {nameof(ClientOptions)}.{nameof(ClientOptions.Retry)}.{nameof(RetryOptions.NetworkTimeout)}.");
            }
        }
    }
}
