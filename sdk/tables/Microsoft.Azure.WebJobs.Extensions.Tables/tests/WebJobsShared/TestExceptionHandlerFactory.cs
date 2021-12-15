// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    public class TestExceptionHandlerFactory : IWebJobsExceptionHandlerFactory
    {
        private TestExceptionHandler _handler = new TestExceptionHandler();
        public IWebJobsExceptionHandler Create(IHost jobHost) => _handler;
    }
}