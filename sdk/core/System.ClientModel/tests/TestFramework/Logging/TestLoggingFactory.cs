// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;
using System;

namespace ClientModel.Tests;

public class TestLoggingFactory : ILoggerFactory
{
    private readonly TestLogger _logger;

    public TestLoggingFactory(TestLogger logger)
    {
        _logger = logger;
    }

    public LogLevel LogLevel { get; set; }

    public void AddProvider(ILoggerProvider provider)
    {
        throw new NotImplementedException();
    }

    public ILogger CreateLogger(string categoryName)
    {
        _logger.Name = categoryName;
        return _logger;
    }

    public void Dispose()
    {
    }
}
