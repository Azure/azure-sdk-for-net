// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel.Tests;

public class TestLoggingProvider : ILoggerProvider
{
    public LogLevel LogLevel { get; set; }

    public ILogger CreateLogger(string categoryName)
    {
        return new TestLogger(categoryName, LogLevel);
    }

    public void Dispose()
    {
    }
}
