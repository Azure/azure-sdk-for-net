// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
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
        private readonly TimeSpan _networkTimeout;

        public ResponseBodyPolicy(TimeSpan networkTimeout)
        {
            _policy = new ResponseBufferingPolicy();
            _networkTimeout = networkTimeout;
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => await ProcessSyncOrAsync(message, pipeline, async: true).ConfigureAwait(false);

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => ProcessSyncOrAsync(message, pipeline, async: false).EnsureCompleted();

        private async ValueTask ProcessSyncOrAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            AzureCorePipelineProcessor processor = new(pipeline);

            // Get the network timeout for this particular invocation of the pipeline.
            // We either use the default that the policy was constructed with at
            // pipeline-creation time, or we get an override value from the message that
            // we use for the duration of this invocation only.
            message.NetworkTimeout ??= _networkTimeout;
            TimeSpan invocationNetworkTimeout = (TimeSpan)message.NetworkTimeout!;

            try
            {
                if (async)
                {
                    await _policy.ProcessAsync(message, processor, -1).ConfigureAwait(false);
                }
                else
                {
                    _policy.Process(message, processor, -1);
                }
            }
            catch (TaskCanceledException e)
            {
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
