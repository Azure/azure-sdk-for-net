// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Core
{
    internal class RetriableContext
    {
        public Stopwatch Stopwatch { get; }
        public TimeSpan TimeSpan { get; }
        public CancellationToken CancellationToken { get; }
        private ServiceBusRetryPolicy RetryPolicy { get; }
        private string EntityName { get; }
        private AmqpConnectionScope Scope { get; }

        public RetriableContext(
            AmqpConnectionScope scope,
            Stopwatch stopwatch,
            ServiceBusRetryPolicy retryPolicy,
            string entityName,
            CancellationToken cancellationToken)
        {
            Scope = scope;
            Stopwatch = stopwatch;
            RetryPolicy = retryPolicy;
            TimeSpan = retryPolicy.CalculateTryTimeout(0);
            CancellationToken = cancellationToken;
            EntityName = entityName;
        }

        public async Task<T> RunOperation<T>(Func<Task<T>> operation)
        {
            var failedAttemptCount = 0;

            var stopWatch = Stopwatch.StartNew();
            try
            {
                TimeSpan tryTimeout = RetryPolicy.CalculateTryTimeout(0);

                while (!CancellationToken.IsCancellationRequested)
                {

                    try
                    {
                        return await operation().ConfigureAwait(false);
                    }

                    catch (Exception ex)
                    {
                        Exception activeEx = ex.TranslateServiceException(EntityName);

                        // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                        // Otherwise, mark the exception as active and break out of the loop.

                        ++failedAttemptCount;
                        TimeSpan? retryDelay = RetryPolicy.CalculateRetryDelay(ex, failedAttemptCount);
                        if (retryDelay.HasValue && !Scope.IsDisposed && !CancellationToken.IsCancellationRequested)
                        {
                            //EventHubsEventSource.Log.GetPropertiesError(EventHubName, activeEx.Message);
                            await Task.Delay(retryDelay.Value, CancellationToken).ConfigureAwait(false);

                            tryTimeout = RetryPolicy.CalculateTryTimeout(failedAttemptCount);
                            stopWatch.Reset();
                        }
                        else if (ex is AmqpException)
                        {
                            throw activeEx;
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                // If no value has been returned nor exception thrown by this point,
                // then cancellation has been requested.
                throw new TaskCanceledException();
            }
            catch (Exception exception)
            {
                throw exception;
                //TODO through correct exception throw AmqpExceptionHelper.GetClientException(exception);
            }
            finally
            {
                stopWatch.Stop();
                //TODO log correct completion event ServiceBusEventSource.Log.PeekMessagesComplete(EntityName);
            }
        }

    }
}
