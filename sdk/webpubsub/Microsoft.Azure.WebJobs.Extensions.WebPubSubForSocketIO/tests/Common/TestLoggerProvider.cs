// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    public class TestLoggerProvider : ILoggerProvider
    {
        private readonly LoggerFilterOptions _filter;
        private readonly Action<LogMessage> _logAction;
        private Dictionary<string, TestLogger> _loggerCache { get; } = new Dictionary<string, TestLogger>();

        public TestLoggerProvider(Action<LogMessage> logAction = null)
        {
            _filter = new LoggerFilterOptions();
            _logAction = logAction;
        }

        public IList<TestLogger> CreatedLoggers => _loggerCache.Values.ToList();

        public ILogger CreateLogger(string categoryName)
        {
            if (!_loggerCache.TryGetValue(categoryName, out TestLogger logger))
            {
                logger = new TestLogger(categoryName, _logAction);
                _loggerCache.Add(categoryName, logger);
            }

            return logger;
        }

        public IEnumerable<LogMessage> GetAllLogMessages() => CreatedLoggers.SelectMany(l => l.GetLogMessages()).OrderBy(p => p.Timestamp);

        public string GetLogString() => string.Join(Environment.NewLine, GetAllLogMessages());

        public void ClearAllLogMessages()
        {
            foreach (TestLogger logger in CreatedLoggers)
            {
                logger.ClearLogMessages();
            }
        }

        public void Dispose()
        {
        }
    }
}
