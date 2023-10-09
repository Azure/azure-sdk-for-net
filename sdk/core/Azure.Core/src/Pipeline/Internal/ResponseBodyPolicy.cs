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
        private readonly TimeSpan _networkTimeout;

        public ResponseBodyPolicy(TimeSpan networkTimeout)
        {
            _policy = new ResponseBufferingPolicy(networkTimeout);
            _networkTimeout = networkTimeout;
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            AzureCorePipelineEnumerator executor = new AzureCorePipelineEnumerator(message, pipeline);

            try
            {
                // TODO: idea: if invocation options was an interface, message could just implement
                // it instead of using an adapter everywhere?  It would bake in the options, though.

                // TODO: Could we hide the options in the executor somehow?  How would that work?

                HttpPipelineInvocationOptions options = new HttpPipelineInvocationOptions(message);

                TimeSpan networkTimeout = _networkTimeout;
                if (options.NetworkTimeout is TimeSpan networkTimeoutOverride)
                {
                    networkTimeout = networkTimeoutOverride;
                }

                await _policy.ProcessAsync(message, options, executor).ConfigureAwait(false);

                if (!options.BufferResponse && networkTimeout != Timeout.InfiniteTimeSpan)
                {
                    // TODO: tidy this up
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

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            AzureCorePipelineEnumerator executor = new AzureCorePipelineEnumerator(message, pipeline);

            try
            {
                HttpPipelineInvocationOptions options = new HttpPipelineInvocationOptions(message);

                TimeSpan networkTimeout = _networkTimeout;
                if (options.NetworkTimeout is TimeSpan networkTimeoutOverride)
                {
                    networkTimeout = networkTimeoutOverride;
                }

                _policy.Process(message, options, executor);

                if (!options.BufferResponse && networkTimeout != Timeout.InfiniteTimeSpan)
                {
                    // TODO: tidy this up
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
