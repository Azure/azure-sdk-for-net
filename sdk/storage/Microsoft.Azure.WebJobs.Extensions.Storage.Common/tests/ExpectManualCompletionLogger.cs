// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public class ExpectManualCompletionLogger<TResult> : ILogger
    {
        private readonly string _categoryName;
        private readonly bool _signalOnFirst;
        private readonly TaskCompletionSource<TResult> _taskSource;
        private readonly HashSet<string> _ignoreFailureFunctions;

        public ExpectManualCompletionLogger(
            string categoryName,
            TaskCompletionSource<TResult> taskSource,
            bool signalOnFirst, // if true, signal after the first instance has run
            IEnumerable<string> ignoreFailureFunctions = null // whitelist expected failures
        )
        {
            _categoryName = categoryName;
            _signalOnFirst = signalOnFirst;
            _taskSource = taskSource;
            _ignoreFailureFunctions = ignoreFailureFunctions != null ?
                new HashSet<string>(ignoreFailureFunctions) : new HashSet<string>();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new NoopDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (_categoryName == LogCategories.Results)
            {
                IDictionary<string, object> payload = state as IDictionary<string, object>;
                if (payload != null)
                {
                    bool succeeded = (bool)payload[LogConstants.SucceededKey];
                    string functionName = payload[LogConstants.FullNameKey] as string;
                    if (!succeeded && functionName != null && !_ignoreFailureFunctions.Contains(functionName))
                    {
                        _taskSource.TrySetException(exception);
                    }
                }

                if (_signalOnFirst)
                {
                    _taskSource.TrySetResult(default(TResult));
                }
            }
        }

        private class NoopDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }

    public class ExpectManualCompletionLoggerProvider<TResult> : ILoggerProvider
    {
        private readonly bool _signalOnFirst;
        private readonly TaskCompletionSource<TResult> _taskSource;
        private readonly HashSet<string> _ignoreFailureFunctions;

        public ExpectManualCompletionLoggerProvider(
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

        public ILogger CreateLogger(string categoryName)
        {
            return new ExpectManualCompletionLogger<TResult>(categoryName, _taskSource, _signalOnFirst, _ignoreFailureFunctions);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
