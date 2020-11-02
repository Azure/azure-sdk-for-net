// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Xunit;
using static Microsoft.Azure.EventHubs.EventData;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubTests
    {
        [Fact]
        public void GetStaticBindingContract_ReturnsExpectedValue()
        {
            var strategy = new EventHubTriggerBindingStrategy();
            var contract = strategy.GetBindingContract();

            Assert.Equal(7, contract.Count);
            Assert.Equal(typeof(PartitionContext), contract["PartitionContext"]);
            Assert.Equal(typeof(string), contract["Offset"]);
            Assert.Equal(typeof(long), contract["SequenceNumber"]);
            Assert.Equal(typeof(DateTime), contract["EnqueuedTimeUtc"]);
            Assert.Equal(typeof(IDictionary<string, object>), contract["Properties"]);
            Assert.Equal(typeof(IDictionary<string, object>), contract["SystemProperties"]);
        }

        [Fact]
        public void GetBindingContract_SingleDispatch_ReturnsExpectedValue()
        {
            var strategy = new EventHubTriggerBindingStrategy();
            var contract = strategy.GetBindingContract(true);

            Assert.Equal(7, contract.Count);
            Assert.Equal(typeof(PartitionContext), contract["PartitionContext"]);
            Assert.Equal(typeof(string), contract["Offset"]);
            Assert.Equal(typeof(long), contract["SequenceNumber"]);
            Assert.Equal(typeof(DateTime), contract["EnqueuedTimeUtc"]);
            Assert.Equal(typeof(IDictionary<string, object>), contract["Properties"]);
            Assert.Equal(typeof(IDictionary<string, object>), contract["SystemProperties"]);
        }

        [Fact]
        public void GetBindingContract_MultipleDispatch_ReturnsExpectedValue()
        {
            var strategy = new EventHubTriggerBindingStrategy();
            var contract = strategy.GetBindingContract(false);

            Assert.Equal(7, contract.Count);
            Assert.Equal(typeof(PartitionContext), contract["PartitionContext"]);
            Assert.Equal(typeof(string[]), contract["PartitionKeyArray"]);
            Assert.Equal(typeof(string[]), contract["OffsetArray"]);
            Assert.Equal(typeof(long[]), contract["SequenceNumberArray"]);
            Assert.Equal(typeof(DateTime[]), contract["EnqueuedTimeUtcArray"]);
            Assert.Equal(typeof(IDictionary<string, object>[]), contract["PropertiesArray"]);
            Assert.Equal(typeof(IDictionary<string, object>[]), contract["SystemPropertiesArray"]);
        }

        [Fact]
        public void GetBindingData_SingleDispatch_ReturnsExpectedValue()
        {
            var evt = new EventData(new byte[] { });
            IDictionary<string, object> sysProps = GetSystemProperties();

            TestHelpers.SetField(evt, "SystemProperties", sysProps);

            var input = EventHubTriggerInput.New(evt);
            input.PartitionContext = GetPartitionContext();

            var strategy = new EventHubTriggerBindingStrategy();
            var bindingData = strategy.GetBindingData(input);

            Assert.Equal(7, bindingData.Count);
            Assert.Same(input.PartitionContext, bindingData["PartitionContext"]);
            Assert.Equal(evt.SystemProperties.PartitionKey, bindingData["PartitionKey"]);
            Assert.Equal(evt.SystemProperties.Offset, bindingData["Offset"]);
            Assert.Equal(evt.SystemProperties.SequenceNumber, bindingData["SequenceNumber"]);
            Assert.Equal(evt.SystemProperties.EnqueuedTimeUtc, bindingData["EnqueuedTimeUtc"]);
            Assert.Same(evt.Properties, bindingData["Properties"]);
            IDictionary<string, object> bindingDataSysProps = bindingData["SystemProperties"] as Dictionary<string, object>;
            Assert.NotNull(bindingDataSysProps);
            Assert.Equal(bindingDataSysProps["PartitionKey"], bindingData["PartitionKey"]);
            Assert.Equal(bindingDataSysProps["Offset"], bindingData["Offset"]);
            Assert.Equal(bindingDataSysProps["SequenceNumber"], bindingData["SequenceNumber"]);
            Assert.Equal(bindingDataSysProps["EnqueuedTimeUtc"], bindingData["EnqueuedTimeUtc"]);
            Assert.Equal(bindingDataSysProps["iothub-connection-device-id"], "testDeviceId");
            Assert.Equal(bindingDataSysProps["iothub-enqueuedtime"], DateTime.MinValue);
        }

        private static IDictionary<string, object> GetSystemProperties(string partitionKey = "TestKey")
        {
            long testSequence = 4294967296;
            IDictionary<string, object> sysProps = TestHelpers.New<SystemPropertiesCollection>();
            sysProps["x-opt-partition-key"] = partitionKey;
            sysProps["x-opt-offset"] = "TestOffset";
            sysProps["x-opt-enqueued-time"] = DateTime.MinValue;
            sysProps["x-opt-sequence-number"] = testSequence;
            sysProps["iothub-connection-device-id"] = "testDeviceId";
            sysProps["iothub-enqueuedtime"] = DateTime.MinValue;
            return sysProps;
        }

        [Fact]
        public void GetBindingData_MultipleDispatch_ReturnsExpectedValue()
        {

            var events = new EventData[3]
            {
                new EventData(Encoding.UTF8.GetBytes("Event 1")),
                new EventData(Encoding.UTF8.GetBytes("Event 2")),
                new EventData(Encoding.UTF8.GetBytes("Event 3")),
            };

            var count = 0;
            foreach (var evt in events)
            {
                IDictionary<string, object> sysProps = GetSystemProperties($"pk{count++}");
                TestHelpers.SetField(evt, "SystemProperties", sysProps);
            }

            var input = new EventHubTriggerInput
            {
                Events = events,
                PartitionContext = GetPartitionContext(),
            };
            var strategy = new EventHubTriggerBindingStrategy();
            var bindingData = strategy.GetBindingData(input);

            Assert.Equal(7, bindingData.Count);
            Assert.Same(input.PartitionContext, bindingData["PartitionContext"]);

            // verify an array was created for each binding data type
            Assert.Equal(events.Length, ((string[])bindingData["PartitionKeyArray"]).Length);
            Assert.Equal(events.Length, ((string[])bindingData["OffsetArray"]).Length);
            Assert.Equal(events.Length, ((long[])bindingData["SequenceNumberArray"]).Length);
            Assert.Equal(events.Length, ((DateTime[])bindingData["EnqueuedTimeUtcArray"]).Length);
            Assert.Equal(events.Length, ((IDictionary<string, object>[])bindingData["PropertiesArray"]).Length);
            Assert.Equal(events.Length, ((IDictionary<string, object>[])bindingData["SystemPropertiesArray"]).Length);

            Assert.Equal(events[0].SystemProperties.PartitionKey, ((string[])bindingData["PartitionKeyArray"])[0]);
            Assert.Equal(events[1].SystemProperties.PartitionKey, ((string[])bindingData["PartitionKeyArray"])[1]);
            Assert.Equal(events[2].SystemProperties.PartitionKey, ((string[])bindingData["PartitionKeyArray"])[2]);
        }

        [Fact]
        public void TriggerStrategy()
        {
            string data = "123";

            var strategy = new EventHubTriggerBindingStrategy();
            EventHubTriggerInput triggerInput = strategy.ConvertFromString(data);

            var contract = strategy.GetBindingData(triggerInput);

            EventData single = strategy.BindSingle(triggerInput, null);
            string body = Encoding.UTF8.GetString(single.Body.Array);

            Assert.Equal(data, body);
            Assert.Null(contract["PartitionContext"]);
            Assert.Null(contract["partitioncontext"]); // case insensitive
        }

        // Validate that if connection string has EntityPath, that takes precedence over the parameter.
        [Theory]
        [InlineData("k1", "Endpoint=sb://test89123-ns-x.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=secretkey")]
        [InlineData("path2", "Endpoint=sb://test89123-ns-x.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=secretkey;EntityPath=path2")]
        public void EntityPathInConnectionString(string expectedPathName, string connectionString)
        {
            EventHubOptions options = new EventHubOptions();

            // Test sender
            options.AddSender("k1", connectionString);
            var client = options.GetEventHubClient("k1", null);
            Assert.Equal(expectedPathName, client.EventHubName);
        }

        // Validate that if connection string has EntityPath, that takes precedence over the parameter.
        [Theory]
        [InlineData("k1", "Endpoint=sb://test89123-ns-x.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=secretkey")]
        [InlineData("path2", "Endpoint=sb://test89123-ns-x.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=secretkey;EntityPath=path2")]
        public void GetEventHubClient_AddsConnection(string expectedPathName, string connectionString)
        {
            EventHubOptions options = new EventHubOptions();
            var client = options.GetEventHubClient("k1", connectionString);
            Assert.Equal(expectedPathName, client.EventHubName);
        }

        [Theory]
        [InlineData("e", "n1", "n1/e/")]
        [InlineData("e--1", "host_.path.foo", "host_.path.foo/e--1/")]
        [InlineData("Ab", "Cd", "cd/ab/")]
        [InlineData("A=", "Cd", "cd/a:3D/")]
        [InlineData("A:", "Cd", "cd/a:3A/")]
        public void EventHubBlobPrefix(string eventHubName, string serviceBusNamespace, string expected)
        {
            string actual = EventHubOptions.GetBlobPrefix(eventHubName, serviceBusNamespace);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(200)]
        public void EventHubBatchCheckpointFrequency(int num)
        {
            var options = new EventHubOptions();
            options.BatchCheckpointFrequency = num;
            Assert.Equal(num, options.BatchCheckpointFrequency);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void EventHubBatchCheckpointFrequency_Throws(int num)
        {
            var options = new EventHubOptions();
            Assert.Throws<InvalidOperationException>(() => options.BatchCheckpointFrequency = num);
        }

        [Fact]
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
                        { "AzureWebJobs:extensions:EventHubs:EventProcessorOptions:MaxBatchSize", "100" },
                        { "AzureWebJobs:extensions:EventHubs:EventProcessorOptions:PrefetchCount", "200" },
                        { "AzureWebJobs:extensions:EventHubs:BatchCheckpointFrequency", "5" },
                        { "AzureWebJobs:extensions:EventHubs:PartitionManagerOptions:LeaseDuration", "00:00:31" },
                        { "AzureWebJobs:extensions:EventHubs:PartitionManagerOptions:RenewInterval", "00:00:21" }
                    });
                })
                .Build();

            // Force the ExtensionRegistryFactory to run, which will initialize the EventHubConfiguration.
            var extensionRegistry = host.Services.GetService<IExtensionRegistry>();
            var options = host.Services.GetService<IOptions<EventHubOptions>>().Value;

            var eventProcessorOptions = options.EventProcessorOptions;
            Assert.Equal(100, eventProcessorOptions.MaxBatchSize);
            Assert.Equal(200, eventProcessorOptions.PrefetchCount);
            Assert.Equal(5, options.BatchCheckpointFrequency);
            Assert.Equal(31, options.PartitionManagerOptions.LeaseDuration.TotalSeconds);
            Assert.Equal(21, options.PartitionManagerOptions.RenewInterval.TotalSeconds);
        }

        internal static PartitionContext GetPartitionContext(string partitionId = null, string eventHubPath = null,
            string consumerGroupName = null, string owner = null)
        {
            var constructor = typeof(PartitionContext).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new Type[] { typeof(EventProcessorHost), typeof(string), typeof(string), typeof(string), typeof(CancellationToken) },
                null);
            var context = (PartitionContext)constructor.Invoke(new object[] { null, partitionId, eventHubPath, consumerGroupName, null });

            // Set a lease, which allows us to grab the "Owner"
            constructor = typeof(Lease).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null);
            var lease = (Lease)constructor.Invoke(new object[] { });
            lease.Owner = owner;

            var leaseProperty = typeof(PartitionContext).GetProperty("Lease", BindingFlags.Public | BindingFlags.Instance);
            leaseProperty.SetValue(context, lease);

            return context;
        }
    }
}
