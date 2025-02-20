// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Processor;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Hosting;
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
        private const string ExtensionPath = "AzureWebJobs:Extensions:EventHubs";

        [SetUp]
        public void SetUp()
        {
            _loggerFactory = new LoggerFactory();

            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);
        }

        [Test]
        public void EventHubsOptions_SetsUpMinBatchSizeCorrectly()
        {
            var options = new EventHubOptions()
            {
                MaxEventBatchSize = 200,
                MinEventBatchSize = 100
            };
        }

        [Test]
        public void ConfigureOptions_CheckpointingEnabledByDefault()
        {
            EventHubOptions options = CreateOptionsFromConfigWithoutCheckpointEnabled();
            Assert.True(options.EnableCheckpointing);
        }

        [Test]
        public void ConfigureOptions_AppliesValuesCorrectly()
        {
            EventHubOptions options = CreateOptionsFromConfig();

            Assert.AreEqual(123, options.MaxEventBatchSize);
            Assert.AreEqual(100, options.MinEventBatchSize);
            Assert.AreEqual(TimeSpan.FromSeconds(60), options.MaxWaitTime);
            Assert.AreEqual(true, options.EventProcessorOptions.TrackLastEnqueuedEventProperties);
            Assert.AreEqual(123, options.EventProcessorOptions.PrefetchCount);
            Assert.AreEqual(5, options.BatchCheckpointFrequency);
            Assert.AreEqual(31, options.EventProcessorOptions.PartitionOwnershipExpirationInterval.TotalSeconds);
            Assert.AreEqual(21, options.EventProcessorOptions.LoadBalancingUpdateInterval.TotalSeconds);
            Assert.AreEqual("FromEnqueuedTime", options.InitialOffsetOptions.Type.ToString());
            Assert.AreEqual("2020-09-13 12:00:00Z", options.InitialOffsetOptions.EnqueuedTimeUtc.Value.ToString("u"));
            Assert.AreEqual(5, options.ClientRetryOptions.MaximumRetries);
            Assert.AreEqual(TimeSpan.FromSeconds(1), options.ClientRetryOptions.Delay);
            Assert.AreEqual(TimeSpan.FromMinutes(1), options.ClientRetryOptions.MaximumDelay);
            Assert.AreEqual(TimeSpan.FromSeconds(90), options.ClientRetryOptions.TryTimeout);
            Assert.AreEqual(EventHubsRetryMode.Fixed, options.ClientRetryOptions.Mode);
            Assert.AreEqual(EventHubsTransportType.AmqpWebSockets, options.TransportType);
            Assert.AreEqual("http://proxyserver:8080/", ((WebProxy) options.WebProxy).Address.AbsoluteUri);
            Assert.AreEqual("http://www.customendpoint.com/", options.CustomEndpointAddress.ToString());
            Assert.False(options.EnableCheckpointing);
        }

        [Test]
        public void ConfigureOptions_Format_Returns_Expected()
        {
            EventHubOptions options = CreateOptionsFromConfig();
            JObject jObject = new JObject
            {
                {ExtensionPath, JObject.Parse(((IOptionsFormatter) options).Format())}
            };

            EventHubOptions result = TestHelpers.GetConfiguredOptions<EventHubOptions>(
                b => { b.AddEventHubs(); },
                jsonStream: new BinaryData(jObject.ToString()).ToStream());

            Assert.AreEqual(123, result.MaxEventBatchSize);
            Assert.AreEqual(100, options.MinEventBatchSize);
            Assert.AreEqual(TimeSpan.FromSeconds(60), options.MaxWaitTime);
            Assert.AreEqual(5, result.BatchCheckpointFrequency);
            Assert.True(result.TrackLastEnqueuedEventProperties);
            Assert.AreEqual(123, result.PrefetchCount);
            Assert.AreEqual(TimeSpan.FromSeconds(31), result.PartitionOwnershipExpirationInterval);
            Assert.AreEqual(TimeSpan.FromSeconds(21), result.LoadBalancingUpdateInterval);
            Assert.AreEqual("FromEnqueuedTime", result.InitialOffsetOptions.Type.ToString());
            Assert.AreEqual("2020-09-13 12:00:00Z", result.InitialOffsetOptions.EnqueuedTimeUtc.Value.ToString("u"));
            Assert.AreEqual(5, result.ClientRetryOptions.MaximumRetries);
            Assert.AreEqual(TimeSpan.FromSeconds(1), result.ClientRetryOptions.Delay);
            Assert.AreEqual(TimeSpan.FromMinutes(1), result.ClientRetryOptions.MaximumDelay);
            Assert.AreEqual(TimeSpan.FromSeconds(90), result.ClientRetryOptions.TryTimeout);
            Assert.AreEqual(EventHubsRetryMode.Fixed, result.ClientRetryOptions.Mode);
            Assert.AreEqual(EventHubsTransportType.AmqpWebSockets, result.TransportType);
            Assert.AreEqual("http://proxyserver:8080/", ((WebProxy) result.WebProxy).Address.AbsoluteUri);
            Assert.AreEqual("http://www.customendpoint.com/", result.CustomEndpointAddress.AbsoluteUri);
            Assert.False(result.EnableCheckpointing);
        }

        [Test]
        public void ConfigureOptions_AppliesValuesCorrectly_BackCompat()
        {
            EventHubOptions options = CreateOptionsFromConfigBackCompat();

            Assert.AreEqual(300, options.TargetUnprocessedEventThreshold);
            Assert.AreEqual(123, options.MaxEventBatchSize);
            Assert.AreEqual(true, options.EventProcessorOptions.TrackLastEnqueuedEventProperties);
            Assert.AreEqual(123, options.EventProcessorOptions.PrefetchCount);
            Assert.AreEqual(5, options.BatchCheckpointFrequency);
            Assert.AreEqual(31, options.EventProcessorOptions.PartitionOwnershipExpirationInterval.TotalSeconds);
            Assert.AreEqual(21, options.EventProcessorOptions.LoadBalancingUpdateInterval.TotalSeconds);
            Assert.AreEqual("FromEnqueuedTime", options.InitialOffsetOptions.Type.ToString());
            Assert.AreEqual("2020-09-13 12:00:00Z", options.InitialOffsetOptions.EnqueuedTimeUtc.Value.ToString("u"));
            Assert.IsTrue(options.EnableCheckpointing);
        }

        [Test]
        public void ConfigureOptions_Format_Returns_Expected_BackCompat()
        {
            EventHubOptions options = CreateOptionsFromConfigBackCompat();

            JObject jObject = new JObject
            {
                {ExtensionPath, JObject.Parse(((IOptionsFormatter) options).Format())}
            };

            EventHubOptions result = TestHelpers.GetConfiguredOptions<EventHubOptions>(
                b => { b.AddEventHubs(); },
                jsonStream: new BinaryData(jObject.ToString()).ToStream());

            Assert.AreEqual(300, result.TargetUnprocessedEventThreshold);
            Assert.AreEqual(123, result.MaxEventBatchSize);
            Assert.AreEqual(5, result.BatchCheckpointFrequency);
            Assert.True(result.TrackLastEnqueuedEventProperties);
            Assert.AreEqual(123, result.PrefetchCount);
            Assert.AreEqual(TimeSpan.FromSeconds(31), result.PartitionOwnershipExpirationInterval);
            Assert.AreEqual(TimeSpan.FromSeconds(21), result.LoadBalancingUpdateInterval);
            Assert.AreEqual("FromEnqueuedTime", result.InitialOffsetOptions.Type.ToString());
            Assert.AreEqual("2020-09-13 12:00:00Z", result.InitialOffsetOptions.EnqueuedTimeUtc.Value.ToString("u"));
            Assert.IsTrue(options.EnableCheckpointing);
        }

        [Test]
        [TestCase("fromstart", OffsetType.FromStart)]
        [TestCase("FromStart", OffsetType.FromStart)]
        [TestCase("fromend", OffsetType.FromEnd)]
        [TestCase("FromEnd", OffsetType.FromEnd)]
        public void CanParseInitialOffsetFromConfig(string offsetType, OffsetType typeEnum)
        {
            string extensionPath = "AzureWebJobs:Extensions:EventHubs";
            var options = TestHelpers.GetConfiguredOptions<EventHubOptions>(
                b =>
                {
                    b.AddEventHubs();
                },
                new Dictionary<string, string> { { $"{extensionPath}:InitialOffsetOptions:Type", offsetType } });
            Assert.AreEqual(typeEnum, options.InitialOffsetOptions.Type);
        }

        [Test]
        [TestCase("fromEnqueuedTime", "2020-09-13T12:00Z")]
        [TestCase("fromenqueuedtime", "2020-09-13 12:00:00Z")]
        public void CanParseInitialOffsetFromConfig_EnqueuedTime(string offsetType, string enqueuedTime)
        {
            string extensionPath = "AzureWebJobs:Extensions:EventHubs";
            var options = TestHelpers.GetConfiguredOptions<EventHubOptions>(
                b =>
                {
                    b.AddEventHubs();
                },
                new Dictionary<string, string>
                {
                    { $"{extensionPath}:InitialOffsetOptions:Type", offsetType },
                    { $"{extensionPath}:InitialOffsetOptions:EnqueuedTimeUtc", enqueuedTime },
                });
            Assert.AreEqual(OffsetType.FromEnqueuedTime, options.InitialOffsetOptions.Type);
            Assert.AreEqual(DateTimeOffset.Parse(enqueuedTime), options.InitialOffsetOptions.EnqueuedTimeUtc);
        }

        [Test]
        public void ParseInitialOffsetWithNoTime_ThrowsInvalidOperationException()
        {
            string extensionPath = "AzureWebJobs:Extensions:EventHubs";
            Assert.That(
                () => TestHelpers.GetConfiguredOptions<EventHubOptions>(
                b =>
                {
                    b.AddEventHubs();
                },
                new Dictionary<string, string>
                {
                    { $"{extensionPath}:InitialOffsetOptions:Type", "fromEnqueuedTime" },
                }),
                Throws.InvalidOperationException);
        }

        [Test]
        public void ParseInitialOffsetWithInvalidType_ThrowsInvalidOperationException()
        {
            string extensionPath = "AzureWebJobs:Extensions:EventHubs";
            Assert.That(
                () => TestHelpers.GetConfiguredOptions<EventHubOptions>(
                    b =>
                    {
                        b.AddEventHubs();
                    },
                    new Dictionary<string, string>
                    {
                        { $"{extensionPath}:InitialOffsetOptions:Type", "fromSequence" },
                    }),
                Throws.InvalidOperationException);
        }

        [Test]
        public void ParseInitialOffsetWithInvalidTime_ThrowsInvalidOperationException()
        {
            Assert.That(
                () => TestHelpers.GetConfiguredOptions<EventHubOptions>(
                    b =>
                    {
                        b.AddEventHubs();
                    },
                    new Dictionary<string, string>
                    {
                        { $"{ExtensionPath}:InitialOffsetOptions:Type", "fromEnqueuedTime" },
                        { $"{ExtensionPath}:InitialOffsetOptions:EnqueuedTimeUtc", "not a valid time" },
                    }),
                Throws.InvalidOperationException);
        }

        [Test]
        public void SetMinBatchLargerThanMax_ThrowsInvalidOperationException()
        {
            string extensionPath = "AzureWebJobs:Extensions:EventHubs";
            Assert.That(
                () => TestHelpers.GetConfiguredOptions<EventHubOptions>(
                b =>
                {
                    b.AddEventHubs();
                },
                new Dictionary<string, string>
                {
                    { $"{extensionPath}:MaxEventBatchSize", "100" },
                    { $"{extensionPath}:MinEventBatchSize", "170" },
                }),
                Throws.InvalidOperationException);
        }

        private EventHubOptions CreateOptionsFromConfig()
        {
            string extensionPath = "AzureWebJobs:Extensions:EventHubs";
            var values = new Dictionary<string, string>
            {
                { $"{extensionPath}:MaxEventBatchSize", "123" },
                { $"{extensionPath}:MinEventBatchSize", "100" },
                { $"{extensionPath}:MaxWaitTime", "00:01:00" },
                { $"{extensionPath}:TrackLastEnqueuedEventProperties", "true" },
                { $"{extensionPath}:PrefetchCount", "123" },
                { $"{extensionPath}:BatchCheckpointFrequency", "5" },
                { $"{extensionPath}:PartitionOwnershipExpirationInterval", "00:00:31" },
                { $"{extensionPath}:LoadBalancingUpdateInterval", "00:00:21" },
                { $"{extensionPath}:LoadBalancingStrategy", "greedy" },
                { $"{extensionPath}:InitialOffsetOptions:Type", "FromEnqueuedTime" },
                { $"{extensionPath}:InitialOffsetOptions:EnqueuedTimeUTC", "2020-09-13 12:00:00Z" },
                { $"{extensionPath}:ClientRetryOptions:MaximumRetries", "5" },
                { $"{extensionPath}:ClientRetryOptions:Delay", "00:00:01" },
                { $"{extensionPath}:ClientRetryOptions:MaxDelay", "00:01:00" },
                { $"{extensionPath}:ClientRetryOptions:TryTimeout", "00:01:30" },
                { $"{extensionPath}:ClientRetryOptions:Mode", "0" },
                { $"{extensionPath}:TransportType", "amqpWebSockets" },
                { $"{extensionPath}:WebProxy", "http://proxyserver:8080/" },
                { $"{extensionPath}:CustomEndpointAddress", "http://www.customendpoint.com/" },
                { $"{extensionPath}:{nameof(EventHubOptions.EnableCheckpointing)}", "false" },
            };

            return TestHelpers.GetConfiguredOptions<EventHubOptions>(b =>
            {
                b.AddEventHubs();
            }, values);
        }

        private EventHubOptions CreateOptionsFromConfigBackCompat()
        {
            string extensionPath = "AzureWebJobs:Extensions:EventHubs";
            var values = new Dictionary<string, string>
            {
                { $"{extensionPath}:TargetUnprocessedEventThreshold", "300" },
                { $"{extensionPath}:EventProcessorOptions:MaxBatchSize", "123" },
                { $"{extensionPath}:EventProcessorOptions:ReceiveTimeout", "00:00:33" },
                { $"{extensionPath}:EventProcessorOptions:EnableReceiverRuntimeMetric", "true" },
                { $"{extensionPath}:EventProcessorOptions:PrefetchCount", "123" },
                { $"{extensionPath}:EventProcessorOptions:InvokeProcessorAfterReceiveTimeout", "true" },
                { $"{extensionPath}:BatchCheckpointFrequency", "5" },
                { $"{extensionPath}:PartitionManagerOptions:LeaseDuration", "00:00:31" },
                { $"{extensionPath}:PartitionManagerOptions:RenewInterval", "00:00:21" },
                { $"{extensionPath}:InitialOffsetOptions:Type", "FromEnqueuedTime" },
                { $"{extensionPath}:InitialOffsetOptions:EnqueuedTimeUTC", "2020-09-13 12:00:00Z" },
            };

            return TestHelpers.GetConfiguredOptions<EventHubOptions>(b =>
            {
                b.AddEventHubs();
            }, values);
        }

        private EventHubOptions CreateOptionsFromConfigWithoutCheckpointEnabled()
        {
            string extensionPath = "AzureWebJobs:Extensions:EventHubs";
            var values = new Dictionary<string, string>
            {
                { $"{extensionPath}:MaxEventBatchSize", "123" },
                { $"{extensionPath}:MinEventBatchSize", "100" },
                { $"{extensionPath}:MaxWaitTime", "00:01:00" },
                { $"{extensionPath}:TrackLastEnqueuedEventProperties", "true" },
                { $"{extensionPath}:PrefetchCount", "123" },
                { $"{extensionPath}:BatchCheckpointFrequency", "5" },
                { $"{extensionPath}:PartitionOwnershipExpirationInterval", "00:00:31" },
                { $"{extensionPath}:LoadBalancingUpdateInterval", "00:00:21" },
                { $"{extensionPath}:LoadBalancingStrategy", "greedy" },
                { $"{extensionPath}:InitialOffsetOptions:Type", "FromEnqueuedTime" },
                { $"{extensionPath}:InitialOffsetOptions:EnqueuedTimeUTC", "2020-09-13 12:00:00Z" },
                { $"{extensionPath}:ClientRetryOptions:MaximumRetries", "5" },
                { $"{extensionPath}:ClientRetryOptions:Delay", "00:00:01" },
                { $"{extensionPath}:ClientRetryOptions:MaxDelay", "00:01:00" },
                { $"{extensionPath}:ClientRetryOptions:TryTimeout", "00:01:30" },
                { $"{extensionPath}:ClientRetryOptions:Mode", "0" },
                { $"{extensionPath}:TransportType", "amqpWebSockets" },
                { $"{extensionPath}:WebProxy", "http://proxyserver:8080/" },
                { $"{extensionPath}:CustomEndpointAddress", "http://www.customendpoint.com/" },
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