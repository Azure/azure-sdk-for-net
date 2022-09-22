// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class RetryPolicyWrapper : HttpPipelinePolicy
    {
        private readonly RetryPolicy _policy;

        public RetryPolicyWrapper(RetryPolicy policy)
        {
            _policy = policy;
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            List<Exception>? exceptions = null;
            while (true)
            {
                var before = Stopwatch.GetTimestamp();
                try
                {
                    if (async)
                    {
                        await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                    }
                    else
                    {
                        ProcessNext(message, pipeline);
                    }

                    // This request didn't result in an exception, so reset the LastException property
                    // in case it was set on a previous attempt.
                    message.RetryContext.LastException = null;
                }
                catch (Exception ex)
                {
                    if (exceptions == null)
                    {
                        exceptions = new List<Exception>();
                    }

                    exceptions.Add(ex);

                    message.RetryContext.LastException = ex;
                }

                var after = Stopwatch.GetTimestamp();
                double elapsed = (after - before) / (double)Stopwatch.Frequency;

                bool shouldRetry = async ? await _policy.ShouldRetryAsync(message).ConfigureAwait(false) : _policy.ShouldRetry(message);
                if (shouldRetry)
                {
                    TimeSpan delay = async ? await _policy.CalculateNextDelayAsync(message).ConfigureAwait(false) : _policy.CalculateNextDelay(message);
                    if (delay > TimeSpan.Zero)
                    {
                        if (async)
                        {
                            await WaitAsync(delay, message.CancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            Wait(delay, message.CancellationToken);
                        }
                    }
                }
                else if (message.RetryContext.LastException != null)
                {
                    // Rethrow a singular exception
                    if (exceptions!.Count == 1)
                    {
                        ExceptionDispatchInfo.Capture(message.RetryContext.LastException).Throw();
                    }

                    throw new AggregateException(
                        $"Retry failed after {message.RetryContext.AttemptNumber} tries. Retry settings can be adjusted in {nameof(ClientOptions)}.{nameof(ClientOptions.Retry)}.",
                        exceptions);
                }
                else
                {
                    // We are not retrying and the last attempt didn't result in an exception.
                    return;
                }

                if (message.HasResponse)
                {
                    // Dispose the content stream to free up a connection if the request has any
                    message.Response.ContentStream?.Dispose();
                }

                message.RetryContext.AttemptNumber++;
                AzureCoreEventSource.Singleton.RequestRetrying(message.Request.ClientRequestId, message.RetryContext.AttemptNumber,
                    elapsed);
            }
        }

        internal virtual async Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
        {
            await Task.Delay(time, cancellationToken).ConfigureAwait(false);
        }

        internal virtual void Wait(TimeSpan time, CancellationToken cancellationToken)
        {
            cancellationToken.WaitHandle.WaitOne(time);
        }
    }
}