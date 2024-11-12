// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    public class TestLogger : ILogger
    {
        private readonly Action<LogMessage> _logAction;
        private IList<LogMessage> _logMessages = new List<LogMessage>();

        // protect against changes to logMessages while enumerating
        private object _syncLock = new object();

        public TestLogger(string category, Action<LogMessage> logAction = null)
        {
            Category = category;
            _logAction = logAction;
        }

        public string Category { get; private set; }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IList<LogMessage> GetLogMessages()
        {
            lock (_syncLock)
            {
                return _logMessages.ToList();
            }
        }

        public void ClearLogMessages()
        {
            lock (_syncLock)
            {
                _logMessages.Clear();
            }
        }

        public virtual void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var logMessage = new LogMessage
            {
                Level = logLevel,
                EventId = eventId,
                State = state as IEnumerable<KeyValuePair<string, object>>,
                Exception = exception,
                FormattedMessage = formatter(state, exception),
                Category = Category,
                Timestamp = DateTime.UtcNow
            };

            lock (_syncLock)
            {
                _logMessages.Add(logMessage);
            }

            _logAction?.Invoke(logMessage);
        }

        public override string ToString()
        {
            return Category;
        }
    }
}
