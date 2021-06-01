// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public class TestExceptionHandler : IWebJobsExceptionHandler
    {
        public Task OnTimeoutExceptionAsync(ExceptionDispatchInfo exceptionInfo, TimeSpan timeoutGracePeriod)
        {
            Assert.True(false, $"Timeout exception in test exception handler: {exceptionInfo.SourceException}");
            return Task.CompletedTask;
        }

        public Task OnUnhandledExceptionAsync(ExceptionDispatchInfo exceptionInfo)
        {
            Assert.True(false, $"Error in test exception handler: {exceptionInfo.SourceException}");
            return Task.CompletedTask;
        }
    }

    public class TestExceptionHandlerFactory : IWebJobsExceptionHandlerFactory
    {
        private TestExceptionHandler _handler = new TestExceptionHandler();

        public IWebJobsExceptionHandler Create(IHost jobHost) => _handler;
    }
}
