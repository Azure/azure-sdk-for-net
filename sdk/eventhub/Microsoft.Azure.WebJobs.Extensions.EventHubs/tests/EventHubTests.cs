// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubTests
    {
        [Test]
        public void GetStaticBindingContract_ReturnsExpectedValue()
        {
            var strategy = new EventHubTriggerBindingStrategy();
            var contract = strategy.GetBindingContract();

            Assert.AreEqual(9, contract.Count);
            Assert.AreEqual(typeof(TriggerPartitionContext), contract["TriggerPartitionContext"]);
            Assert.AreEqual(typeof(PartitionContext), contract["PartitionContext"]);
            Assert.AreEqual(typeof(string), contract["Offset"]);
            Assert.AreEqual(typeof(string), contract["OffsetString"]);
            Assert.AreEqual(typeof(long), contract["SequenceNumber"]);
            Assert.AreEqual(typeof(DateTime), contract["EnqueuedTimeUtc"]);
            Assert.AreEqual(typeof(IDictionary<string, object>), contract["Properties"]);
            Assert.AreEqual(typeof(IDictionary<string, object>), contract["SystemProperties"]);
        }

        [Test]
        public void GetBindingContract_SingleDispatch_ReturnsExpectedValue()
        {
            var strategy = new EventHubTriggerBindingStrategy();
            var contract = strategy.GetBindingContract(true);

            Assert.AreEqual(9, contract.Count);
            Assert.AreEqual(typeof(TriggerPartitionContext), contract["TriggerPartitionContext"]);
            Assert.AreEqual(typeof(PartitionContext), contract["PartitionContext"]);
            Assert.AreEqual(typeof(string), contract["Offset"]);
            Assert.AreEqual(typeof(string), contract["OffsetString"]);
            Assert.AreEqual(typeof(long), contract["SequenceNumber"]);
            Assert.AreEqual(typeof(DateTime), contract["EnqueuedTimeUtc"]);
            Assert.AreEqual(typeof(IDictionary<string, object>), contract["Properties"]);
            Assert.AreEqual(typeof(IDictionary<string, object>), contract["SystemProperties"]);
        }

        [Test]
        public void GetBindingContract_MultipleDispatch_ReturnsExpectedValue()
        {
            var strategy = new EventHubTriggerBindingStrategy();
            var contract = strategy.GetBindingContract(false);

            Assert.AreEqual(9, contract.Count);
            Assert.AreEqual(typeof(TriggerPartitionContext), contract["TriggerPartitionContext"]);
            Assert.AreEqual(typeof(PartitionContext), contract["PartitionContext"]);
            Assert.AreEqual(typeof(string[]), contract["PartitionKeyArray"]);
            Assert.AreEqual(typeof(string[]), contract["OffsetArray"]);
            Assert.AreEqual(typeof(string[]), contract["OffsetStringArray"]);
            Assert.AreEqual(typeof(long[]), contract["SequenceNumberArray"]);
            Assert.AreEqual(typeof(DateTime[]), contract["EnqueuedTimeUtcArray"]);
            Assert.AreEqual(typeof(IDictionary<string, object>[]), contract["PropertiesArray"]);
            Assert.AreEqual(typeof(IDictionary<string, object>[]), contract["SystemPropertiesArray"]);
        }

        [Test]
        public void GetBindingData_SingleDispatch_ReturnsExpectedValue()
        {
            var evt = GetSystemProperties(new byte[] { });

            var input = EventHubTriggerInput.New(evt);
            input.ProcessorPartition = GetPartitionContext();

            var strategy = new EventHubTriggerBindingStrategy();
            var bindingData = strategy.GetBindingData(input);

            if (!long.TryParse(evt.OffsetString, NumberStyles.Integer, CultureInfo.InvariantCulture, out long offsetLong))
            {
                offsetLong = -1;
            }

            Assert.AreEqual(9, bindingData.Count);
            Assert.AreSame(input.ProcessorPartition.PartitionContext, bindingData["TriggerPartitionContext"]);
            Assert.AreSame(input.ProcessorPartition.PartitionContext, bindingData["PartitionContext"]);
            Assert.AreEqual(evt.PartitionKey, bindingData["PartitionKey"]);
            Assert.AreEqual(offsetLong.ToString(CultureInfo.InvariantCulture), bindingData["Offset"]);
            Assert.AreEqual(evt.OffsetString, bindingData["OffsetString"]);
            Assert.AreEqual(evt.SequenceNumber, bindingData["SequenceNumber"]);
            Assert.AreEqual(evt.EnqueuedTime.DateTime, bindingData["EnqueuedTimeUtc"]);
            Assert.AreSame(evt.Properties, bindingData["Properties"]);
            IDictionary<string, object> bindingDataSysProps = bindingData["SystemProperties"] as Dictionary<string, object>;
            Assert.NotNull(bindingDataSysProps);
            Assert.AreEqual(bindingDataSysProps["PartitionKey"], bindingData["PartitionKey"]);
            Assert.AreEqual(offsetLong.ToString(CultureInfo.InvariantCulture), bindingData["Offset"]);
            Assert.AreEqual(bindingDataSysProps["SequenceNumber"], bindingData["SequenceNumber"]);
            Assert.AreEqual(bindingDataSysProps["EnqueuedTimeUtc"], bindingData["EnqueuedTimeUtc"]);
            Assert.AreEqual(bindingDataSysProps["iothub-connection-device-id"], "testDeviceId");
            Assert.AreEqual(bindingDataSysProps["iothub-enqueuedtime"], DateTime.MinValue);
        }

        private static EventData GetSystemProperties(byte[] body, string partitionKey = "TestKey") =>
            EventHubsModelFactory.EventData(new BinaryData(body), partitionKey: partitionKey, offsetString: "140:1:12", enqueuedTime: DateTimeOffset.MinValue, sequenceNumber: 4294967296, systemProperties: new Dictionary<string, object>()
            {
                {"iothub-connection-device-id", "testDeviceId"},
                {"iothub-enqueuedtime", DateTime.MinValue}
            });

        [Test]
        public void GetBindingData_MultipleDispatch_ReturnsExpectedValue()
        {
            var events = new EventData[3]
            {
                GetSystemProperties(Encoding.UTF8.GetBytes("Event 1"), "pk0"),
                GetSystemProperties(Encoding.UTF8.GetBytes("Event 2"), "pk1"),
                GetSystemProperties(Encoding.UTF8.GetBytes("Event 3"), "pk2"),
            };

            var input = new EventHubTriggerInput
            {
                Events = events,
                ProcessorPartition = GetPartitionContext(),
            };
            var strategy = new EventHubTriggerBindingStrategy();
            var bindingData = strategy.GetBindingData(input);

            Assert.AreEqual(9, bindingData.Count);
            Assert.AreSame(input.ProcessorPartition.PartitionContext, bindingData["TriggerPartitionContext"]);
            Assert.AreSame(input.ProcessorPartition.PartitionContext, bindingData["PartitionContext"]);

            // verify an array was created for each binding data type
            Assert.AreEqual(events.Length, ((string[])bindingData["PartitionKeyArray"]).Length);
            Assert.AreEqual(events.Length, ((string[])bindingData["OffsetArray"]).Length);
            Assert.AreEqual(events.Length, ((string[])bindingData["OffsetStringArray"]).Length);
            Assert.AreEqual(events.Length, ((long[])bindingData["SequenceNumberArray"]).Length);
            Assert.AreEqual(events.Length, ((DateTime[])bindingData["EnqueuedTimeUtcArray"]).Length);
            Assert.AreEqual(events.Length, ((IDictionary<string, object>[])bindingData["PropertiesArray"]).Length);
            Assert.AreEqual(events.Length, ((IDictionary<string, object>[])bindingData["SystemPropertiesArray"]).Length);

            Assert.AreEqual(events[0].PartitionKey, ((string[])bindingData["PartitionKeyArray"])[0]);
            Assert.AreEqual(events[1].PartitionKey, ((string[])bindingData["PartitionKeyArray"])[1]);
            Assert.AreEqual(events[2].PartitionKey, ((string[])bindingData["PartitionKeyArray"])[2]);
        }

        [Test]
        public void TriggerStrategy()
        {
            string data = "123";

            var strategy = new EventHubTriggerBindingStrategy();

            EventHubTriggerInput triggerInput = strategy.ConvertFromString(data);
            var contract = strategy.GetBindingData(triggerInput);

            EventData single = strategy.BindSingle(triggerInput, null);
            string body = Encoding.UTF8.GetString(single.Body.ToArray());

            Assert.AreEqual(data, body);
            Assert.Null(contract["PartitionContext"]);
            Assert.Null(contract["partitioncontext"]); // case insensitive
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(200)]
        public void EventHubBatchCheckpointFrequency(int num)
        {
            var options = new EventHubOptions();
            options.BatchCheckpointFrequency = num;
            Assert.AreEqual(num, options.BatchCheckpointFrequency);
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void EventHubBatchCheckpointFrequency_Throws(int num)
        {
            var options = new EventHubOptions();
            Assert.Throws<InvalidOperationException>(() => options.BatchCheckpointFrequency = num);
        }

        [Test]
        public void InitializeFromHostMetadata()
        {
            // TODO: It's tough to wire all this up without using a new host.
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost(builder =>
                {
                    builder.AddEventHubs();
                })
                .ConfigureAppConfiguration(c =>
                {
                    c.AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { "AzureWebJobs:extensions:EventHubs:TargetUnprocessedEventThreshold", "300"},
                        { "AzureWebJobs:extensions:EventHubs:EventProcessorOptions:MaxBatchSize", "100" },
                        { "AzureWebJobs:extensions:EventHubs:EventProcessorOptions:PrefetchCount", "200" },
                        { "AzureWebJobs:extensions:EventHubs:BatchCheckpointFrequency", "5" },
                        { "AzureWebJobs:extensions:EventHubs:MinEventBatchSize", "90" },
                        { "AzureWebJobs:extensions:EventHubs:MaxWaitTime", "00:00:01" },
                        { "AzureWebJobs:extensions:EventHubs:PartitionManagerOptions:LeaseDuration", "00:00:31" },
                        { "AzureWebJobs:extensions:EventHubs:PartitionManagerOptions:RenewInterval", "00:00:21" },
                        { "AzureWebJobs:extensions:EventHubs:InitialOffsetOptions:Type", "FromEnd" },
                    });
                })
                .Build();

            // Force the ExtensionRegistryFactory to run, which will initialize the EventHubConfiguration.
            var extensionRegistry = host.Services.GetService<IExtensionRegistry>();
            var options = host.Services.GetService<IOptions<EventHubOptions>>().Value;

            var eventProcessorOptions = options.EventProcessorOptions;
            Assert.AreEqual(300, options.TargetUnprocessedEventThreshold);
            Assert.AreEqual(200, eventProcessorOptions.PrefetchCount);
            Assert.AreEqual(5, options.BatchCheckpointFrequency);
            Assert.AreEqual(100, options.MaxEventBatchSize);
            Assert.AreEqual(90, options.MinEventBatchSize);
            Assert.AreEqual(TimeSpan.FromSeconds(1), options.MaxWaitTime);
            Assert.AreEqual(31, options.EventProcessorOptions.PartitionOwnershipExpirationInterval.TotalSeconds);
            Assert.AreEqual(21, options.EventProcessorOptions.LoadBalancingUpdateInterval.TotalSeconds);
            Assert.AreEqual(EventPosition.Latest, eventProcessorOptions.DefaultStartingPosition);
        }

        [Test]
        public void InitializeFromCodeRespectsFinalOffsetOptions_FromStart()
        {
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost(builder =>
                {
                    builder.AddEventHubs(options => options.InitialOffsetOptions.Type = OffsetType.FromEnd);
                })
                .ConfigureServices(services =>
                    {
                        services.Configure<EventHubOptions>(options =>
                        {
                            options.InitialOffsetOptions.Type = OffsetType.FromStart;
                        });
                    })
                .Build();

            // Force the ExtensionRegistryFactory to run, which will initialize the EventHubConfiguration.
            var extensionRegistry = host.Services.GetService<IExtensionRegistry>();
            var options = host.Services.GetService<IOptions<EventHubOptions>>().Value;

            var eventProcessorOptions = options.EventProcessorOptions;
            Assert.AreEqual(EventPosition.Earliest, eventProcessorOptions.DefaultStartingPosition);
        }

        [Test]
        public void InitializeFromCodeRespectsFinalOffsetOptions_FromEnd()
        {
            var host = new HostBuilder()
                 .ConfigureDefaultTestHost(builder =>
                 {
                     builder.AddEventHubs(options => options.InitialOffsetOptions.Type = OffsetType.FromStart);
                 })
                 .ConfigureServices(services =>
                 {
                     services.Configure<EventHubOptions>(options =>
                     {
                         options.InitialOffsetOptions.Type = OffsetType.FromEnd;
                     });
                 })
                 .Build();

            // Force the ExtensionRegistryFactory to run, which will initialize the EventHubConfiguration.
            var extensionRegistry = host.Services.GetService<IExtensionRegistry>();
            var options = host.Services.GetService<IOptions<EventHubOptions>>().Value;

            var eventProcessorOptions = options.EventProcessorOptions;
            Assert.AreEqual(EventPosition.Latest, eventProcessorOptions.DefaultStartingPosition);
        }

        [Test]
        public void InitializeFromCodeRespectsFinalOffsetOptions_FromEnqueuedTime()
        {
            var host = new HostBuilder()
                 .ConfigureDefaultTestHost(builder =>
                 {
                     builder.AddEventHubs(options => options.InitialOffsetOptions.Type = OffsetType.FromStart);
                 })
                 .ConfigureServices(services =>
                 {
                     services.Configure<EventHubOptions>(options =>
                     {
                         options.InitialOffsetOptions.Type = OffsetType.FromEnqueuedTime;
                         options.InitialOffsetOptions.EnqueuedTimeUtc = DateTimeOffset.UtcNow;
                     });
                 })
                 .Build();

            // Force the ExtensionRegistryFactory to run, which will initialize the EventHubConfiguration.
            var extensionRegistry = host.Services.GetService<IExtensionRegistry>();
            var options = host.Services.GetService<IOptions<EventHubOptions>>().Value;

            var eventProcessorOptions = options.EventProcessorOptions;
            Assert.AreEqual(
                EventPosition.FromEnqueuedTime(options.InitialOffsetOptions.EnqueuedTimeUtc.Value),
                eventProcessorOptions.DefaultStartingPosition);
        }

        [Test]
        public void HostPartitionPopulatesPartitionContext()
        {
            var partition = GetPartitionContext();
            var processor = partition.ProcessorHost;
            var context = partition.PartitionContext;

            Assert.AreEqual(processor.FullyQualifiedNamespace, context.FullyQualifiedNamespace);
            Assert.AreEqual(processor.EventHubName, context.EventHubName);
            Assert.AreEqual(processor.ConsumerGroup, context.ConsumerGroup);
            Assert.AreEqual(partition.PartitionId, context.PartitionId);
        }

        internal static EventProcessorHostPartition GetPartitionContext(string partitionId = "0", string eventHubPath = "path",
            string consumerGroupName = "group")
        {
            var processor = new EventProcessorHost(consumerGroupName,
                "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=",
                eventHubPath,
                new EventProcessorOptions(),
                Int32.MaxValue, null);
            return new EventProcessorHostPartition(partitionId)
            {
                ProcessorHost = processor
            };
        }
    }
}
