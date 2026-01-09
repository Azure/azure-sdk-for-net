// Copyright (c) .NET Foundation. All rights reserved.
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
            Assert.Multiple(() =>
            {
                Assert.That(config.MaxConcurrentCalls, Is.EqualTo(16 * Utility.GetProcessorCount()));
                Assert.That(config.PrefetchCount, Is.EqualTo(0));
            });
        }

        [Test]
        public void PrefetchCount_GetSet()
        {
            ServiceBusOptions config = new ServiceBusOptions();
            Assert.That(config.PrefetchCount, Is.EqualTo(0));
            config.PrefetchCount = 100;
            Assert.That(config.PrefetchCount, Is.EqualTo(100));
        }

        [Test]
        public void LogExceptionReceivedEvent_NonTransientEvent_LoggedAsError()
        {
            var ex = new ServiceBusException(isTransient: false, message: "message");
            Assert.That(ex.IsTransient, Is.False);
            ProcessErrorEventArgs e = new ProcessErrorEventArgs(ex, ServiceBusErrorSource.Abandon, "TestEndpoint", "TestEntity", CancellationToken.None);
            ServiceBusExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            var expectedMessage = $"Message processing error (Action=Abandon, EntityPath=TestEntity, Endpoint=TestEndpoint)";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.Multiple(() =>
            {
                Assert.That(logMessage.Level, Is.EqualTo(LogLevel.Error));
                Assert.That(logMessage.Exception, Is.SameAs(ex));
                Assert.That(logMessage.FormattedMessage, Is.EqualTo(expectedMessage));
            });
        }

        [Test]
        public void LogExceptionReceivedEvent_TransientEvent_LoggedAsInformation()
        {
            var ex = new ServiceBusException(message: "message", isTransient: true);
            Assert.That(ex.IsTransient, Is.True);
            ProcessErrorEventArgs e = new ProcessErrorEventArgs(ex, ServiceBusErrorSource.Receive, "TestEndpoint", "TestEntity", CancellationToken.None);
            ServiceBusExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            var expectedMessage = $"Message processing error (Action=Receive, EntityPath=TestEntity, Endpoint=TestEndpoint)";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.Multiple(() =>
            {
                Assert.That(logMessage.Level, Is.EqualTo(LogLevel.Information));
                Assert.That(logMessage.Exception, Is.SameAs(ex));
                Assert.That(logMessage.FormattedMessage, Is.EqualTo(expectedMessage));
            });
        }

        [Test]
        public void LogExceptionReceivedEvent_NonMessagingException_LoggedAsError()
        {
            var ex = new MissingMethodException("What method??");
            ProcessErrorEventArgs e = new ProcessErrorEventArgs(ex, ServiceBusErrorSource.Complete, "TestEndpoint", "TestEntity", CancellationToken.None);
            ServiceBusExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            var expectedMessage = $"Message processing error (Action=Complete, EntityPath=TestEntity, Endpoint=TestEndpoint)";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.Multiple(() =>
            {
                Assert.That(logMessage.Level, Is.EqualTo(LogLevel.Error));
                Assert.That(logMessage.Exception, Is.SameAs(ex));
                Assert.That(logMessage.FormattedMessage, Is.EqualTo(expectedMessage));
            });
        }

        [Test]
        public void ToProcessorOptions_ReturnsExpectedValue()
        {
            ServiceBusOptions sbOptions = new ServiceBusOptions
            {
                AutoCompleteMessages = false,
                PrefetchCount = 123,
                MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(123),
                SessionIdleTimeout = TimeSpan.FromSeconds(123),
                MaxConcurrentCalls = 123
            };

            ServiceBusProcessorOptions processorOptions = sbOptions.ToProcessorOptions(true, false);
            Assert.Multiple(() =>
            {
                Assert.That(processorOptions.AutoCompleteMessages, Is.EqualTo(true));
                Assert.That(processorOptions.PrefetchCount, Is.EqualTo(sbOptions.PrefetchCount));
                Assert.That(processorOptions.MaxAutoLockRenewalDuration, Is.EqualTo(sbOptions.MaxAutoLockRenewalDuration));
                Assert.That(processorOptions.MaxConcurrentCalls, Is.EqualTo(sbOptions.MaxConcurrentCalls));
            });
        }

        [Test]
        public void ToProcessorOptions_InfiniteTimeSpans_ReturnsExpectedValue()
        {
            ServiceBusOptions sbOptions = new ServiceBusOptions
            {
                AutoCompleteMessages = false,
                PrefetchCount = 123,
                MaxAutoLockRenewalDuration = Timeout.InfiniteTimeSpan,
                SessionIdleTimeout = Timeout.InfiniteTimeSpan,
                MaxConcurrentCalls = 123
            };

            ServiceBusProcessorOptions processorOptions = sbOptions.ToProcessorOptions(true, false);
            Assert.Multiple(() =>
            {
                Assert.That(processorOptions.AutoCompleteMessages, Is.EqualTo(true));
                Assert.That(processorOptions.PrefetchCount, Is.EqualTo(sbOptions.PrefetchCount));
                Assert.That(processorOptions.MaxAutoLockRenewalDuration, Is.EqualTo(sbOptions.MaxAutoLockRenewalDuration));
                Assert.That(processorOptions.MaxConcurrentCalls, Is.EqualTo(sbOptions.MaxConcurrentCalls));
            });
        }

        [Test]
        [Category("DynamicConcurrency")]
        public void ToProcessorOptions_DynamicConcurrencyEnabled_ReturnsExpectedValue()
        {
            ServiceBusOptions sbOptions = new ServiceBusOptions
            {
                AutoCompleteMessages = false,
                PrefetchCount = 123,
                MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(123),
                MaxConcurrentCalls = 123
            };

            ServiceBusProcessorOptions processorOptions = sbOptions.ToProcessorOptions(true, true);
            Assert.Multiple(() =>
            {
                Assert.That(processorOptions.AutoCompleteMessages, Is.EqualTo(true));
                Assert.That(processorOptions.PrefetchCount, Is.EqualTo(sbOptions.PrefetchCount));
                Assert.That(processorOptions.MaxAutoLockRenewalDuration, Is.EqualTo(sbOptions.MaxAutoLockRenewalDuration));
                Assert.That(processorOptions.MaxConcurrentCalls, Is.EqualTo(1));
            });
        }

        [Test]
        public void ToSessionProcessorOptions_ReturnsExpectedValue()
        {
            ServiceBusOptions sbOptions = new ServiceBusOptions
            {
                AutoCompleteMessages = false,
                PrefetchCount = 123,
                MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(123),
                SessionIdleTimeout = TimeSpan.FromSeconds(123),
                MaxConcurrentSessions = 123,
                MaxConcurrentCallsPerSession = 5
            };

            ServiceBusSessionProcessorOptions processorOptions = sbOptions.ToSessionProcessorOptions(true, false);
            Assert.Multiple(() =>
            {
                Assert.That(processorOptions.AutoCompleteMessages, Is.EqualTo(true));
                Assert.That(processorOptions.PrefetchCount, Is.EqualTo(sbOptions.PrefetchCount));
                Assert.That(processorOptions.MaxAutoLockRenewalDuration, Is.EqualTo(sbOptions.MaxAutoLockRenewalDuration));
                Assert.That(processorOptions.SessionIdleTimeout, Is.EqualTo(sbOptions.SessionIdleTimeout));
                Assert.That(processorOptions.MaxConcurrentSessions, Is.EqualTo(sbOptions.MaxConcurrentSessions));
                Assert.That(processorOptions.MaxConcurrentCallsPerSession, Is.EqualTo(sbOptions.MaxConcurrentCallsPerSession));
            });
        }

        [Test]
        [Category("DynamicConcurrency")]
        public void ToSessionProcessorOptions_DynamicConcurrencyEnabled_ReturnsExpectedValue()
        {
            ServiceBusOptions sbOptions = new ServiceBusOptions
            {
                AutoCompleteMessages = false,
                PrefetchCount = 123,
                MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(123),
                SessionIdleTimeout = TimeSpan.FromSeconds(123),
                MaxConcurrentSessions = 123,
                MaxConcurrentCallsPerSession = 5
            };

            ServiceBusSessionProcessorOptions processorOptions = sbOptions.ToSessionProcessorOptions(true, true);
            Assert.Multiple(() =>
            {
                Assert.That(processorOptions.AutoCompleteMessages, Is.EqualTo(true));
                Assert.That(processorOptions.PrefetchCount, Is.EqualTo(sbOptions.PrefetchCount));
                Assert.That(processorOptions.MaxAutoLockRenewalDuration, Is.EqualTo(sbOptions.MaxAutoLockRenewalDuration));
                Assert.That(processorOptions.SessionIdleTimeout, Is.EqualTo(sbOptions.SessionIdleTimeout));
                Assert.That(processorOptions.MaxConcurrentSessions, Is.EqualTo(1));
                Assert.That(processorOptions.MaxConcurrentCallsPerSession, Is.EqualTo(1));
            });
        }
    }
}
