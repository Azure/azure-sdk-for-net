// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubConfigurationTests
    {
        private ILoggerFactory _loggerFactory;
        private TestLoggerProvider _loggerProvider;
        private readonly string _template = " An exception of type '{0}' was thrown. This exception type is typically a result of Event Hub processor rebalancing or a transient error and can be safely ignored.";

        [SetUp]
        public void SetUp()
        {
            _loggerFactory = new LoggerFactory();

            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);
        }

        [Test]
        public void ConfigureOptions_AppliesValuesCorrectly()
        {
            EventHubOptions options = CreateOptions();

            Assert.AreEqual(123, options.MaxBatchSize);
            Assert.AreEqual(TimeSpan.FromSeconds(33), options.EventProcessorOptions.MaximumWaitTime);
            Assert.AreEqual(true, options.EventProcessorOptions.TrackLastEnqueuedEventProperties);
            Assert.AreEqual(123, options.EventProcessorOptions.PrefetchCount);
            Assert.AreEqual(true, options.InvokeProcessorAfterReceiveTimeout);
            Assert.AreEqual(5, options.BatchCheckpointFrequency);
            Assert.AreEqual(31, options.EventProcessorOptions.PartitionOwnershipExpirationInterval.TotalSeconds);
            Assert.AreEqual(21, options.EventProcessorOptions.LoadBalancingUpdateInterval.TotalSeconds);
            Assert.AreEqual("FromEnqueuedTime", options.InitialOffsetOptions.Type);
            Assert.AreEqual("2020-09-13T12:00Z", options.InitialOffsetOptions.EnqueuedTimeUTC);
        }

        [Test]
        public void ConfigureOptions_Format_Returns_Expected()
        {
            EventHubOptions options = CreateOptions();

            string format = options.Format();
            JObject iObj = JObject.Parse(format);
            EventHubOptions result = iObj.ToObject<EventHubOptions>();

            Assert.AreEqual(123, result.MaxBatchSize);
            Assert.AreEqual(5, result.BatchCheckpointFrequency);
            Assert.True(result.EventProcessorOptions.TrackLastEnqueuedEventProperties);
            Assert.True(result.InvokeProcessorAfterReceiveTimeout);
            Assert.AreEqual(123, result.EventProcessorOptions.PrefetchCount);
            Assert.AreEqual(TimeSpan.FromSeconds(33), result.EventProcessorOptions.MaximumWaitTime);
            Assert.AreEqual(TimeSpan.FromSeconds(31), result.EventProcessorOptions.PartitionOwnershipExpirationInterval);
            Assert.AreEqual(TimeSpan.FromSeconds(21), result.EventProcessorOptions.LoadBalancingUpdateInterval);
            Assert.AreEqual("FromEnqueuedTime", result.InitialOffsetOptions.Type);
            Assert.AreEqual("2020-09-13T12:00Z", result.InitialOffsetOptions.EnqueuedTimeUTC);
        }

        private EventHubOptions CreateOptions()
        {
            string extensionPath = "AzureWebJobs:Extensions:EventHubs";
            var values = new Dictionary<string, string>
            {
                { $"{extensionPath}:EventProcessorOptions:MaxBatchSize", "123" },
                { $"{extensionPath}:EventProcessorOptions:ReceiveTimeout", "00:00:33" },
                { $"{extensionPath}:EventProcessorOptions:EnableReceiverRuntimeMetric", "true" },
                { $"{extensionPath}:EventProcessorOptions:PrefetchCount", "123" },
                { $"{extensionPath}:EventProcessorOptions:InvokeProcessorAfterReceiveTimeout", "true" },
                { $"{extensionPath}:BatchCheckpointFrequency", "5" },
                { $"{extensionPath}:PartitionManagerOptions:LeaseDuration", "00:00:31" },
                { $"{extensionPath}:PartitionManagerOptions:RenewInterval", "00:00:21" },
                { $"{extensionPath}:InitialOffsetOptions:Type", "FromEnqueuedTime" },
                { $"{extensionPath}:InitialOffsetOptions:EnqueuedTimeUTC", "2020-09-13T12:00Z" },
            };

            return TestHelpers.GetConfiguredOptions<EventHubOptions>(b =>
            {
                b.AddEventHubs();
            }, values);
        }

        [Test]
        public void LogExceptionReceivedEvent_NonTransientEvent_LoggedAsError()
        {
            var ex = new EventHubsException(false, "");
            var e = new ExceptionReceivedEventArgs("TestHostName", "TestAction", "TestPartitionId", ex);
            EventHubExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            string expectedMessage = "EventProcessorHost error (Action='TestAction', HostName='TestHostName', PartitionId='TestPartitionId').";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();

            Assert.False(ex.IsTransient);
            Assert.AreEqual(LogLevel.Error, logMessage.Level);
            Assert.AreSame(ex, logMessage.Exception);
            Assert.AreEqual(expectedMessage, logMessage.FormattedMessage);
        }

        [Test]
        public void LogExceptionReceivedEvent_TransientEvent_LoggedAsVerbose()
        {
            var ex = new EventHubsException(true, "");
            var e = new ExceptionReceivedEventArgs("TestHostName", "TestAction", "TestPartitionId", ex);
            EventHubExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            string expectedMessage = "EventProcessorHost error (Action='TestAction', HostName='TestHostName', PartitionId='TestPartitionId').";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();

            Assert.True(ex.IsTransient);
            Assert.AreEqual(LogLevel.Information, logMessage.Level);
            Assert.AreSame(ex, logMessage.Exception);
            Assert.AreEqual(expectedMessage + string.Format(_template, typeof(EventHubsException).Name), logMessage.FormattedMessage);
        }

        [Test]
        public void LogExceptionReceivedEvent_OperationCanceledException_LoggedAsVerbose()
        {
            var ex = new OperationCanceledException("Testing");
            var e = new ExceptionReceivedEventArgs("TestHostName", "TestAction", "TestPartitionId", ex);
            EventHubExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            string expectedMessage = "EventProcessorHost error (Action='TestAction', HostName='TestHostName', PartitionId='TestPartitionId').";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual(LogLevel.Information, logMessage.Level);
            Assert.AreSame(ex, logMessage.Exception);
            Assert.AreEqual(expectedMessage + string.Format(_template, typeof(OperationCanceledException).Name), logMessage.FormattedMessage);
        }

        [Test]
        public void LogExceptionReceivedEvent_NonMessagingException_LoggedAsError()
        {
            var ex = new MissingMethodException("What method??");
            var e = new ExceptionReceivedEventArgs("TestHostName", "TestAction", "TestPartitionId", ex);
            EventHubExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            string expectedMessage = "EventProcessorHost error (Action='TestAction', HostName='TestHostName', PartitionId='TestPartitionId').";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual(LogLevel.Error, logMessage.Level);
            Assert.AreSame(ex, logMessage.Exception);
            Assert.AreEqual(expectedMessage, logMessage.FormattedMessage);
        }

        [Test]
        public void LogExceptionReceivedEvent_PartitionExceptions_LoggedAsInfo()
        {
            var ex = new EventHubsException(false, "New receiver with higher epoch of '30402' is created hence current receiver with epoch '30402' is getting disconnected.", EventHubsException.FailureReason.ConsumerDisconnected);
            var e = new ExceptionReceivedEventArgs("TestHostName", "TestAction", "TestPartitionId", ex);
            EventHubExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            string expectedMessage = "EventProcessorHost error (Action='TestAction', HostName='TestHostName', PartitionId='TestPartitionId').";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual(LogLevel.Information, logMessage.Level);
            Assert.AreSame(ex, logMessage.Exception);
            Assert.AreEqual(expectedMessage + string.Format(_template, typeof(EventHubsException).Name), logMessage.FormattedMessage);
        }

        [Test]
        public void LogExceptionReceivedEvent_AggregateExceptions_LoggedAsInfo()
        {
            var oce = new OperationCanceledException("Testing");

            var ex = new AggregateException(new Exception[] { oce });
            var e = new ExceptionReceivedEventArgs("TestHostName", "TestAction", "TestPartitionId", ex);
            EventHubExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            string expectedMessage = "EventProcessorHost error (Action='TestAction', HostName='TestHostName', PartitionId='TestPartitionId').";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual(LogLevel.Information, logMessage.Level);
            Assert.AreSame(oce, logMessage.Exception);
            Assert.AreEqual(expectedMessage + string.Format(_template, typeof(OperationCanceledException).Name), logMessage.FormattedMessage);
        }
    }
}