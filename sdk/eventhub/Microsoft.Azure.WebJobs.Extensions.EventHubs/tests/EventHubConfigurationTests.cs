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
            Assert.That(options.EnableCheckpointing, Is.True);
        }

        [Test]
        public void ConfigureOptions_AppliesValuesCorrectly()
        {
            EventHubOptions options = CreateOptionsFromConfig();

            Assert.Multiple(() =>
            {
                Assert.That(options.MaxEventBatchSize, Is.EqualTo(123));
                Assert.That(options.MinEventBatchSize, Is.EqualTo(100));
                Assert.That(options.MaxWaitTime, Is.EqualTo(TimeSpan.FromSeconds(60)));
                Assert.That(options.EventProcessorOptions.TrackLastEnqueuedEventProperties, Is.EqualTo(true));
                Assert.That(options.EventProcessorOptions.PrefetchCount, Is.EqualTo(123));
                Assert.That(options.BatchCheckpointFrequency, Is.EqualTo(5));
                Assert.That(options.EventProcessorOptions.PartitionOwnershipExpirationInterval.TotalSeconds, Is.EqualTo(31));
                Assert.That(options.EventProcessorOptions.LoadBalancingUpdateInterval.TotalSeconds, Is.EqualTo(21));
                Assert.That(options.InitialOffsetOptions.Type.ToString(), Is.EqualTo("FromEnqueuedTime"));
                Assert.That(options.InitialOffsetOptions.EnqueuedTimeUtc.Value.ToString("u"), Is.EqualTo("2020-09-13 12:00:00Z"));
                Assert.That(options.ClientRetryOptions.MaximumRetries, Is.EqualTo(5));
                Assert.That(options.ClientRetryOptions.Delay, Is.EqualTo(TimeSpan.FromSeconds(1)));
                Assert.That(options.ClientRetryOptions.MaximumDelay, Is.EqualTo(TimeSpan.FromMinutes(1)));
                Assert.That(options.ClientRetryOptions.TryTimeout, Is.EqualTo(TimeSpan.FromSeconds(90)));
                Assert.That(options.ClientRetryOptions.Mode, Is.EqualTo(EventHubsRetryMode.Fixed));
                Assert.That(options.TransportType, Is.EqualTo(EventHubsTransportType.AmqpWebSockets));
                Assert.That(((WebProxy)options.WebProxy).Address.AbsoluteUri, Is.EqualTo("http://proxyserver:8080/"));
                Assert.That(options.CustomEndpointAddress.ToString(), Is.EqualTo("http://www.customendpoint.com/"));
                Assert.That(options.EnableCheckpointing, Is.False);
            });
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

            Assert.That(result.MaxEventBatchSize, Is.EqualTo(123));
            Assert.That(options.MinEventBatchSize, Is.EqualTo(100));
            Assert.That(options.MaxWaitTime, Is.EqualTo(TimeSpan.FromSeconds(60)));
            Assert.That(result.BatchCheckpointFrequency, Is.EqualTo(5));
            Assert.That(result.TrackLastEnqueuedEventProperties, Is.True);
            Assert.That(result.PrefetchCount, Is.EqualTo(123));
            Assert.That(result.PartitionOwnershipExpirationInterval, Is.EqualTo(TimeSpan.FromSeconds(31)));
            Assert.That(result.LoadBalancingUpdateInterval, Is.EqualTo(TimeSpan.FromSeconds(21)));
            Assert.That(result.InitialOffsetOptions.Type.ToString(), Is.EqualTo("FromEnqueuedTime"));
            Assert.That(result.InitialOffsetOptions.EnqueuedTimeUtc.Value.ToString("u"), Is.EqualTo("2020-09-13 12:00:00Z"));
            Assert.That(result.ClientRetryOptions.MaximumRetries, Is.EqualTo(5));
            Assert.That(result.ClientRetryOptions.Delay, Is.EqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(result.ClientRetryOptions.MaximumDelay, Is.EqualTo(TimeSpan.FromMinutes(1)));
            Assert.That(result.ClientRetryOptions.TryTimeout, Is.EqualTo(TimeSpan.FromSeconds(90)));
            Assert.That(result.ClientRetryOptions.Mode, Is.EqualTo(EventHubsRetryMode.Fixed));
            Assert.That(result.TransportType, Is.EqualTo(EventHubsTransportType.AmqpWebSockets));
            Assert.That(((WebProxy)result.WebProxy).Address.AbsoluteUri, Is.EqualTo("http://proxyserver:8080/"));
            Assert.That(result.CustomEndpointAddress.AbsoluteUri, Is.EqualTo("http://www.customendpoint.com/"));
            Assert.That(result.EnableCheckpointing, Is.False);
        }

        [Test]
        public void ConfigureOptions_AppliesValuesCorrectly_BackCompat()
        {
            EventHubOptions options = CreateOptionsFromConfigBackCompat();

            Assert.That(options.TargetUnprocessedEventThreshold, Is.EqualTo(300));
            Assert.That(options.MaxEventBatchSize, Is.EqualTo(123));
            Assert.That(options.EventProcessorOptions.TrackLastEnqueuedEventProperties, Is.EqualTo(true));
            Assert.That(options.EventProcessorOptions.PrefetchCount, Is.EqualTo(123));
            Assert.That(options.BatchCheckpointFrequency, Is.EqualTo(5));
            Assert.That(options.EventProcessorOptions.PartitionOwnershipExpirationInterval.TotalSeconds, Is.EqualTo(31));
            Assert.That(options.EventProcessorOptions.LoadBalancingUpdateInterval.TotalSeconds, Is.EqualTo(21));
            Assert.That(options.InitialOffsetOptions.Type.ToString(), Is.EqualTo("FromEnqueuedTime"));
            Assert.That(options.InitialOffsetOptions.EnqueuedTimeUtc.Value.ToString("u"), Is.EqualTo("2020-09-13 12:00:00Z"));
            Assert.That(options.EnableCheckpointing, Is.True);
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

            Assert.That(result.TargetUnprocessedEventThreshold, Is.EqualTo(300));
            Assert.That(result.MaxEventBatchSize, Is.EqualTo(123));
            Assert.That(result.BatchCheckpointFrequency, Is.EqualTo(5));
            Assert.That(result.TrackLastEnqueuedEventProperties, Is.True);
            Assert.That(result.PrefetchCount, Is.EqualTo(123));
            Assert.That(result.PartitionOwnershipExpirationInterval, Is.EqualTo(TimeSpan.FromSeconds(31)));
            Assert.That(result.LoadBalancingUpdateInterval, Is.EqualTo(TimeSpan.FromSeconds(21)));
            Assert.That(result.InitialOffsetOptions.Type.ToString(), Is.EqualTo("FromEnqueuedTime"));
            Assert.That(result.InitialOffsetOptions.EnqueuedTimeUtc.Value.ToString("u"), Is.EqualTo("2020-09-13 12:00:00Z"));
            Assert.That(options.EnableCheckpointing, Is.True);
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
            Assert.That(options.InitialOffsetOptions.Type, Is.EqualTo(typeEnum));
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
            Assert.That(options.InitialOffsetOptions.Type, Is.EqualTo(OffsetType.FromEnqueuedTime));
            Assert.That(options.InitialOffsetOptions.EnqueuedTimeUtc, Is.EqualTo(DateTimeOffset.Parse(enqueuedTime)));
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

            Assert.Multiple(() =>
            {
                Assert.That(ex.IsTransient, Is.False);
                Assert.That(logMessage.Level, Is.EqualTo(LogLevel.Error));
                Assert.That(logMessage.Exception, Is.SameAs(ex));
                Assert.That(logMessage.FormattedMessage, Is.EqualTo(expectedMessage));
            });
        }

        [Test]
        public void LogExceptionReceivedEvent_TransientEvent_LoggedAsVerbose()
        {
            var ex = new EventHubsException(true, "");
            var e = new ExceptionReceivedEventArgs("TestHostName", "TestAction", "TestPartitionId", ex);
            EventHubExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            string expectedMessage = "EventProcessorHost error (Action='TestAction', HostName='TestHostName', PartitionId='TestPartitionId').";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();

            Assert.Multiple(() =>
            {
                Assert.That(ex.IsTransient, Is.True);
                Assert.That(logMessage.Level, Is.EqualTo(LogLevel.Information));
                Assert.That(logMessage.Exception, Is.SameAs(ex));
                Assert.That(logMessage.FormattedMessage, Is.EqualTo(expectedMessage + string.Format(_template, typeof(EventHubsException).Name)));
            });
        }

        [Test]
        public void LogExceptionReceivedEvent_OperationCanceledException_LoggedAsVerbose()
        {
            var ex = new OperationCanceledException("Testing");
            var e = new ExceptionReceivedEventArgs("TestHostName", "TestAction", "TestPartitionId", ex);
            EventHubExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            string expectedMessage = "EventProcessorHost error (Action='TestAction', HostName='TestHostName', PartitionId='TestPartitionId').";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.Multiple(() =>
            {
                Assert.That(logMessage.Level, Is.EqualTo(LogLevel.Information));
                Assert.That(logMessage.Exception, Is.SameAs(ex));
                Assert.That(logMessage.FormattedMessage, Is.EqualTo(expectedMessage + string.Format(_template, typeof(OperationCanceledException).Name)));
            });
        }

        [Test]
        public void LogExceptionReceivedEvent_NonMessagingException_LoggedAsError()
        {
            var ex = new MissingMethodException("What method??");
            var e = new ExceptionReceivedEventArgs("TestHostName", "TestAction", "TestPartitionId", ex);
            EventHubExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            string expectedMessage = "EventProcessorHost error (Action='TestAction', HostName='TestHostName', PartitionId='TestPartitionId').";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.Multiple(() =>
            {
                Assert.That(logMessage.Level, Is.EqualTo(LogLevel.Error));
                Assert.That(logMessage.Exception, Is.SameAs(ex));
                Assert.That(logMessage.FormattedMessage, Is.EqualTo(expectedMessage));
            });
        }

        [Test]
        public void LogExceptionReceivedEvent_PartitionExceptions_LoggedAsInfo()
        {
            var ex = new EventHubsException(false, "New receiver with higher epoch of '30402' is created hence current receiver with epoch '30402' is getting disconnected.", EventHubsException.FailureReason.ConsumerDisconnected);
            var e = new ExceptionReceivedEventArgs("TestHostName", "TestAction", "TestPartitionId", ex);
            EventHubExtensionConfigProvider.LogExceptionReceivedEvent(e, _loggerFactory);

            string expectedMessage = "EventProcessorHost error (Action='TestAction', HostName='TestHostName', PartitionId='TestPartitionId').";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.Multiple(() =>
            {
                Assert.That(logMessage.Level, Is.EqualTo(LogLevel.Information));
                Assert.That(logMessage.Exception, Is.SameAs(ex));
                Assert.That(logMessage.FormattedMessage, Is.EqualTo(expectedMessage + string.Format(_template, typeof(EventHubsException).Name)));
            });
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
            Assert.Multiple(() =>
            {
                Assert.That(logMessage.Level, Is.EqualTo(LogLevel.Information));
                Assert.That(logMessage.Exception, Is.SameAs(oce));
                Assert.That(logMessage.FormattedMessage, Is.EqualTo(expectedMessage + string.Format(_template, typeof(OperationCanceledException).Name)));
            });
        }
    }
}