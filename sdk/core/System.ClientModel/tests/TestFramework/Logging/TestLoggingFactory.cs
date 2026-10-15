// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ClientModel.Tests;

public class TestLoggingFactory : ILoggerFactory
{
    private readonly ConcurrentDictionary<string, TestLogger> _loggers;

    public TestLoggingFactory(LogLevel level)
    {
        _loggers = new();
        LogLevel = level;
    }

    public LogLevel LogLevel { get; }

    public void AddProvider(ILoggerProvider provider)
    {
        throw new NotImplementedException();
    }

    public ILogger CreateLogger(string categoryName)
    {
        return _loggers.GetOrAdd(categoryName, name => new TestLogger(LogLevel, name));
    }

    public TestLogger GetLogger(string categoryName)
    {
        return _loggers[categoryName];
    }

    public void Dispose()
    {
        _loggers.Clear();
    }
}
