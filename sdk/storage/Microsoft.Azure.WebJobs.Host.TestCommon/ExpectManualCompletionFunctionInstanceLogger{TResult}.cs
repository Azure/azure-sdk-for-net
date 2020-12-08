// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Azure.WebJobs.Host.Protocols;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests.TestDoubles
{
    // Hook IFunctionInstanceLogger to capture a notification when a function instance has completed.
    // This can catch failure notifications (including binding falilures)
    public class ExpectManualCompletionFunctionInstanceLogger<TResult> : IFunctionInstanceLogger
    {
        private readonly bool _signalOnFirst;
        private readonly TaskCompletionSource<TResult> _taskSource;
        private readonly HashSet<string> _ignoreFailureFunctions;

        public ExpectManualCompletionFunctionInstanceLogger(
            TaskCompletionSource<TResult> taskSource,
            bool signalOnFirst, // if true, signal after the first instance has run
            IEnumerable<string> ignoreFailureFunctions = null // whitelist expected failures
            )
        {
            _signalOnFirst = signalOnFirst;
            _taskSource = taskSource;
            _ignoreFailureFunctions = ignoreFailureFunctions != null ?
                new HashSet<string>(ignoreFailureFunctions) : new HashSet<string>();
        }

        Task<string> IFunctionInstanceLogger.LogFunctionStartedAsync(FunctionStartedMessage message, CancellationToken cancellationToken)
        {
            return Task.FromResult(String.Empty);
        }

        Task IFunctionInstanceLogger.LogFunctionCompletedAsync(FunctionCompletedMessage message, CancellationToken cancellationToken)
        {
            if (message != null && message.Failure != null && message.Function != null &&
                !_ignoreFailureFunctions.Contains(message.Function.FullName))
            {
                _taskSource.TrySetException(message.Failure.Exception);
            }

            if (_signalOnFirst)
            {
                _taskSource.TrySetResult(default(TResult));
            }

            return Task.CompletedTask;
        }

        public Task DeleteLogFunctionStartedAsync(string startedMessageId, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
