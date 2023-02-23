// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.Listeners
{
    public class ServiceBusTargetScalerTests
    {
        private ILoggerFactory _loggerFactory;
        private TestLoggerProvider _loggerProvider;

        [SetUp]
        public void Setup()
        {
            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);
        }

        [TestCase(100, false, true, null, 6)]
        [TestCase(100, true, true, null, 4)]
        [TestCase(100, false, true, 19, 6)]
        [TestCase(100, false, false, null, 3)]
        public void ServiceBusTargetScaler_Returns_Expected(int messageCount, bool isSessionEnabled, bool singleDispatch, int? concurrency,int expected)
        {
            ServiceBusOptions options = new ServiceBusOptions
            {
                MaxConcurrentCalls = 19,
                MaxConcurrentSessions = 29,
                MaxMessageBatchSize = 39
            };

            TargetScalerContext context = new TargetScalerContext
            {
                InstanceConcurrency = concurrency
            };

            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);

            ServiceBusTargetScaler targetScaler = new ServiceBusTargetScaler(
                "functionId",
                "entityPath",
                ServiceBusEntityType.Queue,
                null,
                null,
                options,
                isSessionEnabled,
                singleDispatch,
                _loggerFactory
                );
            TargetScalerResult result = targetScaler.GetScaleResultInternal(context, messageCount);

            Assert.AreEqual(result.TargetWorkerCount, expected);
        }
    }
}
