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

            Assert.That(contract.Count, Is.EqualTo(9));
            Assert.That(contract["TriggerPartitionContext"], Is.EqualTo(typeof(TriggerPartitionContext)));
            Assert.That(contract["PartitionContext"], Is.EqualTo(typeof(PartitionContext)));
            Assert.That(contract["Offset"], Is.EqualTo(typeof(string)));
            Assert.That(contract["OffsetString"], Is.EqualTo(typeof(string)));
            Assert.That(contract["SequenceNumber"], Is.EqualTo(typeof(long)));
            Assert.That(contract["EnqueuedTimeUtc"], Is.EqualTo(typeof(DateTime)));
            Assert.That(contract["Properties"], Is.EqualTo(typeof(IDictionary<string, object>)));
            Assert.That(contract["SystemProperties"], Is.EqualTo(typeof(IDictionary<string, object>)));
        }

        [Test]
        public void GetBindingContract_SingleDispatch_ReturnsExpectedValue()
        {
            var strategy = new EventHubTriggerBindingStrategy();
            var contract = strategy.GetBindingContract(true);

            Assert.That(contract.Count, Is.EqualTo(9));
            Assert.That(contract["TriggerPartitionContext"], Is.EqualTo(typeof(TriggerPartitionContext)));
            Assert.That(contract["PartitionContext"], Is.EqualTo(typeof(PartitionContext)));
            Assert.That(contract["Offset"], Is.EqualTo(typeof(string)));
            Assert.That(contract["OffsetString"], Is.EqualTo(typeof(string)));
            Assert.That(contract["SequenceNumber"], Is.EqualTo(typeof(long)));
            Assert.That(contract["EnqueuedTimeUtc"], Is.EqualTo(typeof(DateTime)));
            Assert.That(contract["Properties"], Is.EqualTo(typeof(IDictionary<string, object>)));
            Assert.That(contract["SystemProperties"], Is.EqualTo(typeof(IDictionary<string, object>)));
        }

        [Test]
        public void GetBindingContract_MultipleDispatch_ReturnsExpectedValue()
        {
            var strategy = new EventHubTriggerBindingStrategy();
            var contract = strategy.GetBindingContract(false);

            Assert.That(contract.Count, Is.EqualTo(9));
            Assert.That(contract["TriggerPartitionContext"], Is.EqualTo(typeof(TriggerPartitionContext)));
            Assert.That(contract["PartitionContext"], Is.EqualTo(typeof(PartitionContext)));
            Assert.That(contract["PartitionKeyArray"], Is.EqualTo(typeof(string[])));
            Assert.That(contract["OffsetArray"], Is.EqualTo(typeof(string[])));
            Assert.That(contract["OffsetStringArray"], Is.EqualTo(typeof(string[])));
            Assert.That(contract["SequenceNumberArray"], Is.EqualTo(typeof(long[])));
            Assert.That(contract["EnqueuedTimeUtcArray"], Is.EqualTo(typeof(DateTime[])));
            Assert.That(contract["PropertiesArray"], Is.EqualTo(typeof(IDictionary<string, object>[])));
            Assert.That(contract["SystemPropertiesArray"], Is.EqualTo(typeof(IDictionary<string, object>[])));
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

            Assert.That(bindingData.Count, Is.EqualTo(9));
            Assert.That(bindingData["TriggerPartitionContext"], Is.SameAs(input.ProcessorPartition.PartitionContext));
            Assert.That(bindingData["PartitionContext"], Is.SameAs(input.ProcessorPartition.PartitionContext));
            Assert.That(bindingData["PartitionKey"], Is.EqualTo(evt.PartitionKey));
            Assert.That(bindingData["Offset"], Is.EqualTo(offsetLong.ToString(CultureInfo.InvariantCulture)));
            Assert.That(bindingData["OffsetString"], Is.EqualTo(evt.OffsetString));
            Assert.That(bindingData["SequenceNumber"], Is.EqualTo(evt.SequenceNumber));
            Assert.That(bindingData["EnqueuedTimeUtc"], Is.EqualTo(evt.EnqueuedTime.DateTime));
            Assert.That(bindingData["Properties"], Is.SameAs(evt.Properties));
            IDictionary<string, object> bindingDataSysProps = bindingData["SystemProperties"] as Dictionary<string, object>;
            Assert.That(bindingDataSysProps, Is.Not.Null);
            Assert.That(bindingData["PartitionKey"], Is.EqualTo(bindingDataSysProps["PartitionKey"]));
            Assert.That(bindingData["Offset"], Is.EqualTo(offsetLong.ToString(CultureInfo.InvariantCulture)));
            Assert.That(bindingData["SequenceNumber"], Is.EqualTo(bindingDataSysProps["SequenceNumber"]));
            Assert.That(bindingData["EnqueuedTimeUtc"], Is.EqualTo(bindingDataSysProps["EnqueuedTimeUtc"]));
            Assert.That("testDeviceId", Is.EqualTo(bindingDataSysProps["iothub-connection-device-id"]));
            Assert.That(DateTime.MinValue, Is.EqualTo(bindingDataSysProps["iothub-enqueuedtime"]));
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

            Assert.That(bindingData.Count, Is.EqualTo(9));
            Assert.That(bindingData["TriggerPartitionContext"], Is.SameAs(input.ProcessorPartition.PartitionContext));
            Assert.That(bindingData["PartitionContext"], Is.SameAs(input.ProcessorPartition.PartitionContext));

            // verify an array was created for each binding data type
            Assert.That(((string[])bindingData["PartitionKeyArray"]).Length, Is.EqualTo(events.Length));
            Assert.That(((string[])bindingData["OffsetArray"]).Length, Is.EqualTo(events.Length));
            Assert.That(((string[])bindingData["OffsetStringArray"]).Length, Is.EqualTo(events.Length));
            Assert.That(((long[])bindingData["SequenceNumberArray"]).Length, Is.EqualTo(events.Length));
            Assert.That(((DateTime[])bindingData["EnqueuedTimeUtcArray"]).Length, Is.EqualTo(events.Length));
            Assert.That(((IDictionary<string, object>[])bindingData["PropertiesArray"]).Length, Is.EqualTo(events.Length));
            Assert.That(((IDictionary<string, object>[])bindingData["SystemPropertiesArray"]).Length, Is.EqualTo(events.Length));

            Assert.That(((string[])bindingData["PartitionKeyArray"])[0], Is.EqualTo(events[0].PartitionKey));
            Assert.That(((string[])bindingData["PartitionKeyArray"])[1], Is.EqualTo(events[1].PartitionKey));
            Assert.That(((string[])bindingData["PartitionKeyArray"])[2], Is.EqualTo(events[2].PartitionKey));
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

            Assert.That(body, Is.EqualTo(data));
            Assert.That(contract["PartitionContext"], Is.Null);
            Assert.That(contract["partitioncontext"], Is.Null); // case insensitive
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(200)]
        public void EventHubBatchCheckpointFrequency(int num)
        {
            var options = new EventHubOptions();
            options.BatchCheckpointFrequency = num;
            Assert.That(options.BatchCheckpointFrequency, Is.EqualTo(num));
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
            Assert.That(options.TargetUnprocessedEventThreshold, Is.EqualTo(300));
            Assert.That(eventProcessorOptions.PrefetchCount, Is.EqualTo(200));
            Assert.That(options.BatchCheckpointFrequency, Is.EqualTo(5));
            Assert.That(options.MaxEventBatchSize, Is.EqualTo(100));
            Assert.That(options.MinEventBatchSize, Is.EqualTo(90));
            Assert.That(options.MaxWaitTime, Is.EqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(options.EventProcessorOptions.PartitionOwnershipExpirationInterval.TotalSeconds, Is.EqualTo(31));
            Assert.That(options.EventProcessorOptions.LoadBalancingUpdateInterval.TotalSeconds, Is.EqualTo(21));
            Assert.That(eventProcessorOptions.DefaultStartingPosition, Is.EqualTo(EventPosition.Latest));
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
            Assert.That(eventProcessorOptions.DefaultStartingPosition, Is.EqualTo(EventPosition.Earliest));
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
            Assert.That(eventProcessorOptions.DefaultStartingPosition, Is.EqualTo(EventPosition.Latest));
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
            Assert.That(
                eventProcessorOptions.DefaultStartingPosition,
                Is.EqualTo(EventPosition.FromEnqueuedTime(options.InitialOffsetOptions.EnqueuedTimeUtc.Value)));
        }

        [Test]
        public void HostPartitionPopulatesPartitionContext()
        {
            var partition = GetPartitionContext();
            var processor = partition.ProcessorHost;
            var context = partition.PartitionContext;

            Assert.That(context.FullyQualifiedNamespace, Is.EqualTo(processor.FullyQualifiedNamespace));
            Assert.That(context.EventHubName, Is.EqualTo(processor.EventHubName));
            Assert.That(context.ConsumerGroup, Is.EqualTo(processor.ConsumerGroup));
            Assert.That(context.PartitionId, Is.EqualTo(partition.PartitionId));
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
