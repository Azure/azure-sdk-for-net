// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Helpers
{
    public class XunitLoggerProvider : ILoggerProvider
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly string _callerMethodName;

        public XunitLoggerProvider(ITestOutputHelper testOutputHelper, string callerMethodName)
        {
            _testOutputHelper = testOutputHelper;
            _callerMethodName = callerMethodName;
        }

        public ILogger CreateLogger(string categoryName)
            => new XunitLogger(_testOutputHelper, categoryName, _callerMethodName);

        public void Dispose()
        { }
    }
}
