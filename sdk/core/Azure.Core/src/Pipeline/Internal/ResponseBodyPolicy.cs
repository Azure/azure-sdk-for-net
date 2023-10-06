// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        public ResponseBodyPolicy(TimeSpan networkTimeout)
        {
            _policy = new ResponseBufferingPolicy(networkTimeout);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            // TODO: this is super inefficient so we come back to this
            AzureCorePipelineExecutor executor = new AzureCorePipelineExecutor(message, pipeline);

            try
            {
                await _policy.ProcessAsync(message, executor).ConfigureAwait(false);
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
            // TODO: this is super inefficient so we come back to this
            AzureCorePipelineExecutor executor = new AzureCorePipelineExecutor(message, pipeline);

            try
            {
                _policy.Process(message, executor);
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

#pragma warning disable SA1402 // File may only contain a single type
    internal class AzureCorePipelineExecutor : PipelineEnumerator
#pragma warning restore SA1402 // File may only contain a single type
    {
        private readonly HttpMessage _message;
        private ReadOnlyMemory<HttpPipelinePolicy> _policies;

        public AzureCorePipelineExecutor(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> policies)
        {
            _policies = policies;
            _message = message;
        }
        public override bool ProcessNext()
        {
            _policies.Span[0].Process(_message, _policies.Slice(1));
            return true;
        }

        public async override ValueTask<bool> ProcessNextAsync()
        {
            await _policies.Span[0].ProcessAsync(_message, _policies.Slice(1)).ConfigureAwait(false);
            return true;
        }
    }
}
