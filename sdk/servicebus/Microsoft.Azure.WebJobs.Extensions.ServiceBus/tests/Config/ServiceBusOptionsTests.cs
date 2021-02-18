﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus.Config;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Config
{
    [NonParallelizable]
    public class ServiceBusOptionsTests
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

        [Test]
        public void Constructor_SetsExpectedDefaults()
        {
            ServiceBusOptions config = new ServiceBusOptions();
            Assert.AreEqual(16 * Utility.GetProcessorCount(), config.MaxConcurrentCalls);
            Assert.AreEqual(0, config.PrefetchCount);
        }

        [Test]
        public void PrefetchCount_GetSet()
        {
            ServiceBusOptions config = new ServiceBusOptions();
            Assert.AreEqual(0, config.PrefetchCount);
            config.PrefetchCount = 100;
            Assert.AreEqual(100, config.PrefetchCount);
        }

        [Test]
        public void LogExceptionReceivedEvent_NonTransientEvent_LoggedAsError()
        {
            var ex = new ServiceBusException(isTransient: false, message: "message");
            Assert.False(ex.IsTransient);
            ProcessErrorEventArgs e = new ProcessErrorEventArgs(ex, ServiceBusErrorSource.Abandon, "TestEndpoint", "TestEntity", CancellationToken.None);
            ServiceBusExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            var expectedMessage = $"Message processing error (Action=Abandon, EntityPath=TestEntity, Endpoint=TestEndpoint)";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual(LogLevel.Error, logMessage.Level);
            Assert.AreSame(ex, logMessage.Exception);
            Assert.AreEqual(expectedMessage, logMessage.FormattedMessage);
        }

        [Test]
        public void LogExceptionReceivedEvent_TransientEvent_LoggedAsInformation()
        {
            var ex = new ServiceBusException(message: "message", isTransient: true);
            Assert.True(ex.IsTransient);
            ProcessErrorEventArgs e = new ProcessErrorEventArgs(ex, ServiceBusErrorSource.Receive, "TestEndpoint", "TestEntity", CancellationToken.None);
            ServiceBusExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            var expectedMessage = $"Message processing error (Action=Receive, EntityPath=TestEntity, Endpoint=TestEndpoint)";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual(LogLevel.Information, logMessage.Level);
            Assert.AreSame(ex, logMessage.Exception);
            Assert.AreEqual(expectedMessage, logMessage.FormattedMessage);
        }

        [Test]
        public void LogExceptionReceivedEvent_NonMessagingException_LoggedAsError()
        {
            var ex = new MissingMethodException("What method??");
            ProcessErrorEventArgs e = new ProcessErrorEventArgs(ex, ServiceBusErrorSource.Complete, "TestEndpoint", "TestEntity", CancellationToken.None);
            ServiceBusExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            var expectedMessage = $"Message processing error (Action=Complete, EntityPath=TestEntity, Endpoint=TestEndpoint)";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual(LogLevel.Error, logMessage.Level);
            Assert.AreSame(ex, logMessage.Exception);
            Assert.AreEqual(expectedMessage, logMessage.FormattedMessage);
        }
    }
}
