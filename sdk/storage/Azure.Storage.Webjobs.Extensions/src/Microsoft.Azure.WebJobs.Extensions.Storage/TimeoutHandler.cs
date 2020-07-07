// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage
{
    internal static class TimeoutHandler
    {
        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(3);

        public static async Task<T> ExecuteWithTimeout<T>(string operationName, string clientRequestId,
            IWebJobsExceptionHandler exceptionHandler, ILogger logger, CancellationToken cancellationToken, Func<Task<T>> operation)
        {
            using (var cts = new CancellationTokenSource())
            {
                Stopwatch sw = Stopwatch.StartNew();

                Task timeoutTask = Task.Delay(DefaultTimeout, cts.Token);
                Task<T> operationTask = operation();

                Task completedTask = await Task.WhenAny(timeoutTask, operationTask);

                if (Equals(timeoutTask, completedTask))
                {
                    ExceptionDispatchInfo exceptionDispatchInfo;
                    try
                    {
                        throw new TimeoutException($"The operation '{operationName}' with id '{clientRequestId}' did not complete in '{DefaultTimeout}'.");
                    }
                    catch (TimeoutException ex)
                    {
                        exceptionDispatchInfo = ExceptionDispatchInfo.Capture(ex);
                    }

                    await exceptionHandler.OnUnhandledExceptionAsync(exceptionDispatchInfo);

                    return default(T);
                }

                // Cancel the Delay.
                cts.Cancel();

                try
                {
                    // Determine if this was a deadlock. If so, log it and rethrow. Use the passed-in cancellationToken
                    // to detemrine of this operation was canceled explicitly or was due to an internal network timeout.

                    return await operationTask;
                }
                catch (StorageException ex) when (ex.InnerException is OperationCanceledException && !cancellationToken.IsCancellationRequested) // network timeout
                {
                    Logger.StorageTimeout(logger, operationName, clientRequestId, sw.ElapsedMilliseconds);
                    throw;
                }
            }
        }

        private static class Logger
        {
            private static readonly Action<ILogger, string, string, long, Exception> _storageDeadlock =
                LoggerMessage.Define<string, string, long>(Microsoft.Extensions.Logging.LogLevel.Debug, new EventId(600, nameof(StorageTimeout)),
                    "The operation '{operationName}' with id '{clientRequestId}' was canceled due to a network timeout after '{elapsed}' ms.");

            internal static void StorageTimeout(ILogger logger, string operationName, string clientRequestId, long elapsedMilliseconds)
            {
                _storageDeadlock(logger, operationName, clientRequestId, elapsedMilliseconds, null);
            }
        }
    }
}
