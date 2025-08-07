// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using Azure.Identity;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Producer;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.EventHubs.Tests;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubsClientFactoryTests
    {
        private const string ConnectionString = "Endpoint=sb://test89123-ns-x.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=secretkey";
        private const string AnotherConnectionString = "Endpoint=sb://test12345-ns-x.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=secretkey";
        private const string ConnectionStringWithEventHub = "Endpoint=sb://test89123-ns-x.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=secretkey;EntityPath=path2";

        // Validate that if connection string has EntityPath, that takes precedence over the parameter.
        [TestCase("k1", ConnectionString)]
        [TestCase("path2", ConnectionStringWithEventHub)]
        public void GetEventHubClient_AddsConnection(string expectedPathName, string connectionString)
        {
            EventHubOptions options = new EventHubOptions();
            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection", connectionString));

            var factory = ConfigurationUtilities.CreateFactory(configuration, options);

            var client = factory.GetEventHubProducerClient(expectedPathName, "connection");
            Assert.AreEqual(expectedPathName, client.EventHubName);
        }

        [Test]
        public void CreatesClientsFromConfigWithConnectionString()
        {
            EventHubOptions options = new EventHubOptions();
            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection", ConnectionString));

            var factory = ConfigurationUtilities.CreateFactory(configuration, options);
            var producer = factory.GetEventHubProducerClient("k1", "connection");
            var consumer = factory.GetEventHubConsumerClient("k1", "connection", null);
            var host = factory.GetEventProcessorHost("k1", "connection", null, true);

            Assert.AreEqual("k1", producer.EventHubName);
            Assert.AreEqual("k1", consumer.EventHubName);
            Assert.AreEqual("k1", host.EventHubName);

            Assert.AreEqual("test89123-ns-x.servicebus.windows.net", producer.FullyQualifiedNamespace);
            Assert.AreEqual("test89123-ns-x.servicebus.windows.net", consumer.FullyQualifiedNamespace);
            Assert.AreEqual("test89123-ns-x.servicebus.windows.net", host.FullyQualifiedNamespace);
        }

        [Test]
        public void CreatesClientsFromConfigWithFullyQualifiedNamespace()
        {
            EventHubOptions options = new EventHubOptions();
            var componentFactoryMock = new Mock<AzureComponentFactory>();
            componentFactoryMock.Setup(c => c.CreateTokenCredential(
                    It.Is<IConfiguration>(c=> c["fullyQualifiedNamespace"] != null)))
                .Returns(new DefaultAzureCredential());

            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection:fullyQualifiedNamespace", "test89123-ns-x.servicebus.windows.net"));

            var factory = ConfigurationUtilities.CreateFactory(configuration, options, componentFactoryMock.Object);
            var producer = factory.GetEventHubProducerClient("k1", "connection");
            var consumer = factory.GetEventHubConsumerClient("k1", "connection", null);
            var host = factory.GetEventProcessorHost("k1", "connection", null, true);

            Assert.AreEqual("k1", producer.EventHubName);
            Assert.AreEqual("k1", consumer.EventHubName);
            Assert.AreEqual("k1", host.EventHubName);

            Assert.AreEqual("test89123-ns-x.servicebus.windows.net", producer.FullyQualifiedNamespace);
            Assert.AreEqual("test89123-ns-x.servicebus.windows.net", consumer.FullyQualifiedNamespace);
            Assert.AreEqual("test89123-ns-x.servicebus.windows.net", host.FullyQualifiedNamespace);
        }

        [Test]
        public void FailsWhenConnectionStringUsedAsName()
        {
            EventHubOptions options = new EventHubOptions();

            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection", ConnectionString));
            var factory = ConfigurationUtilities.CreateFactory(configuration, options);

            var errorMessage = Assert.Throws<InvalidOperationException>(() => factory.GetEventHubProducerClient("k1", ConnectionString)).Message;
            StringAssert.DoesNotContain(ConnectionString, errorMessage);
            StringAssert.Contains("REDACTED", errorMessage);
        }

        [Test]
        public void ConsumersAndProducersAreCached()
        {
            EventHubOptions options = new EventHubOptions();
            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection", ConnectionString));

            var factory = ConfigurationUtilities.CreateFactory(configuration, options);
            var producer = factory.GetEventHubProducerClient("k1", "connection");
            var consumer = factory.GetEventHubConsumerClient("k1", "connection", null);
            var producer2 = factory.GetEventHubProducerClient("k1", "connection");
            var consumer2 = factory.GetEventHubConsumerClient("k1", "connection", null);

            Assert.AreSame(producer, producer2);
            Assert.AreSame(consumer, consumer2);
        }

        [Test]
        public void ConsumersWithSameNameAreProperlyCached()
        {
            EventHubOptions options = new EventHubOptions();

            var componentFactoryMock = new Mock<AzureComponentFactory>();
            componentFactoryMock.Setup(c => c.CreateTokenCredential(
                    It.Is<IConfiguration>(c => c["fullyQualifiedNamespace"] != null)))
                .Returns(new DefaultAzureCredential());

            var configuration = ConfigurationUtilities.CreateConfiguration(
                new KeyValuePair<string, string>("connection1", ConnectionString),
                new KeyValuePair<string, string>("connection2", AnotherConnectionString),
                new KeyValuePair<string, string>("connection3:fullyQualifiedNamespace", "test89123-ns-x.servicebus.windows.net"),
                new KeyValuePair<string, string>("connection4:fullyQualifiedNamespace", "test12345-ns-x.servicebus.windows.net"));

            var factory = ConfigurationUtilities.CreateFactory(configuration, options, componentFactoryMock.Object);
            var consumer1 = factory.GetEventHubConsumerClient("k1", "connection1", null);
            var consumer2 = factory.GetEventHubConsumerClient("k1", "connection2", "csg");
            var consumer3 = factory.GetEventHubConsumerClient("k1", "connection3", "csg");
            var consumer4 = factory.GetEventHubConsumerClient("k1", "connection4", "csg");

            // Create different consumers for different eventhub namespaces.
            Assert.AreNotSame(consumer1, consumer2);
            Assert.AreNotSame(consumer3, consumer4);
            // Create different consumers for different consumer groups.
            Assert.AreNotSame(consumer1, consumer3);
            // Use the same consumer client for the same namespace/eventhub/consumergroup
            Assert.AreSame(consumer2, consumer4);
        }

        [Test]
        public void ProducersWithSameNameAreProperlyCached()
        {
            EventHubOptions options = new EventHubOptions();

            var componentFactoryMock = new Mock<AzureComponentFactory>();
            componentFactoryMock.Setup(c => c.CreateTokenCredential(
                    It.Is<IConfiguration>(c => c["fullyQualifiedNamespace"] != null)))
                .Returns(new DefaultAzureCredential());

            var configuration = ConfigurationUtilities.CreateConfiguration(
                new KeyValuePair<string, string>("connection1", ConnectionString),
                new KeyValuePair<string, string>("connection2", AnotherConnectionString),
                new KeyValuePair<string, string>("connection3:fullyQualifiedNamespace", "test89123-ns-x.servicebus.windows.net"),
                new KeyValuePair<string, string>("connection4:fullyQualifiedNamespace", "test12345-ns-x.servicebus.windows.net"));

            var factory = ConfigurationUtilities.CreateFactory(configuration, options, componentFactoryMock.Object);
            var producer1 = factory.GetEventHubProducerClient("k1", "connection1");
            var producer2 = factory.GetEventHubProducerClient("k1", "connection2");
            var producer3 = factory.GetEventHubProducerClient("k1", "connection3");
            var producer4 = factory.GetEventHubProducerClient("k1", "connection4");

            Assert.AreEqual("k1", producer1.EventHubName);
            Assert.AreEqual("k1", producer2.EventHubName);
            Assert.AreNotSame(producer1, producer2);

            Assert.AreEqual("k1", producer3.EventHubName);
            Assert.AreEqual("k1", producer4.EventHubName);
            Assert.AreNotSame(producer3, producer4);

            Assert.AreSame(producer1, producer3);
            Assert.AreSame(producer2, producer4);
        }

        [Test]
        public void UsesDefaultConnectionToStorageAccount()
        {
            EventHubOptions options = new EventHubOptions();

            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("AzureWebJobsStorage", "UseDevelopmentStorage=true"));

            var factoryMock = new Mock<AzureComponentFactory>();
            factoryMock.Setup(m => m.CreateClient(
                        typeof(BlobServiceClient),
                        It.Is<ConfigurationSection>(c => c.Path == "AzureWebJobsStorage"),
                        null, null))
                .Returns(new BlobServiceClient(configuration["AzureWebJobsStorage"]));

            var factory = ConfigurationUtilities.CreateFactory(configuration, options, factoryMock.Object);

            var client = factory.GetCheckpointStoreClient();
            Assert.AreEqual("azure-webjobs-eventhub", client.Name);
            Assert.AreEqual("devstoreaccount1", client.AccountName);
        }

        [TestCase("k1", "k1", ConnectionString)]
        [TestCase("path2", "k1", ConnectionStringWithEventHub)]
        public void RespectsConnectionOptionsForProducer(string expectedPathName, string eventHubName, string connectionString)
        {
            var testEndpoint = new Uri("http://mycustomendpoint.com");
            EventHubOptions options = new EventHubOptions
            {
                CustomEndpointAddress = testEndpoint,
                ClientRetryOptions = new EventHubsRetryOptions
                {
                    MaximumRetries = 10
                }
            };

            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection", connectionString), new KeyValuePair<string, string>("eventHubName", eventHubName));
            var factory = ConfigurationUtilities.CreateFactory(configuration, options);

            var producer = factory.GetEventHubProducerClient(eventHubName, "connection");
            EventHubConnection connection = (EventHubConnection)typeof(EventHubProducerClient).GetProperty("Connection", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(producer);
            EventHubConnectionOptions connectionOptions = (EventHubConnectionOptions)typeof(EventHubConnection).GetProperty("Options", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(connection);

            Assert.AreEqual(testEndpoint, connectionOptions.CustomEndpointAddress);
            Assert.AreEqual(expectedPathName, producer.EventHubName);

            EventHubProducerClientOptions producerOptions = (EventHubProducerClientOptions)typeof(EventHubProducerClient).GetProperty("Options", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(producer);
            Assert.AreEqual(10, producerOptions.RetryOptions.MaximumRetries);
            Assert.AreEqual(expectedPathName, producer.EventHubName);
        }

        [TestCase("k1", "k1", ConnectionString)]
        [TestCase("path2", "k1", ConnectionStringWithEventHub)]
        public void RespectsConnectionOptionsForConsumer(string expectedPathName, string eventHubName, string connectionString)
        {
            var testEndpoint = new Uri("http://mycustomendpoint.com");
            EventHubOptions options = new EventHubOptions
            {
                CustomEndpointAddress = testEndpoint,
                ClientRetryOptions = new EventHubsRetryOptions
                {
                    MaximumRetries = 10
                }
            };

            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection", connectionString), new KeyValuePair<string, string>("eventHubName", eventHubName));
            var factory = ConfigurationUtilities.CreateFactory(configuration, options);

            var consumer = factory.GetEventHubConsumerClient(eventHubName, "connection", "consumer");
            var consumerClient = (EventHubConsumerClient)typeof(EventHubConsumerClientImpl)
                .GetField("_client", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(consumer);
            EventHubConnection connection = (EventHubConnection)typeof(EventHubConsumerClient)
                .GetProperty("Connection", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(consumerClient);
            EventHubConnectionOptions connectionOptions = (EventHubConnectionOptions)typeof(EventHubConnection)
                .GetProperty("Options", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(connection);
            Assert.AreEqual(testEndpoint, connectionOptions.CustomEndpointAddress);

            EventHubsRetryPolicy retryPolicy = (EventHubsRetryPolicy)typeof(EventHubConsumerClient)
                .GetProperty("RetryPolicy", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(consumerClient);

            // Reflection was still necessary here because BasicRetryOptions (which is the concrete derived type)
            // is internal.
            EventHubsRetryOptions retryOptions = (EventHubsRetryOptions)retryPolicy.GetType()
                .GetProperty("Options", BindingFlags.Public | BindingFlags.Instance)
                .GetValue(retryPolicy);
            Assert.AreEqual(10, retryOptions.MaximumRetries);
            Assert.AreEqual(expectedPathName, consumer.EventHubName);
        }

        [TestCase("k1", "k1", ConnectionString)]
        [TestCase("path2", "k1", ConnectionStringWithEventHub)]
        public void RespectsConnectionOptionsForProcessor(string expectedPathName, string eventHubName, string connectionString)
        {
            var testEndpoint = new Uri("http://mycustomendpoint.com");
            EventHubOptions options = new EventHubOptions
            {
                CustomEndpointAddress = testEndpoint,
                TransportType = EventHubsTransportType.AmqpWebSockets,
                WebProxy = new WebProxy("http://proxyserver/"),
                ClientRetryOptions = new EventHubsRetryOptions
                {
                    MaximumRetries = 10
                },
                MaxEventBatchSize = 20
            };

            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection", connectionString), new KeyValuePair<string, string>("eventHubName", eventHubName));
            var factory = ConfigurationUtilities.CreateFactory(configuration, options);

            var processor = factory.GetEventProcessorHost(eventHubName, "connection", "consumer", false);
            EventProcessorOptions processorOptions = (EventProcessorOptions)typeof(EventProcessor<EventProcessorHostPartition>)
                .GetProperty("Options", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(processor);
            Assert.AreEqual(testEndpoint, processorOptions.ConnectionOptions.CustomEndpointAddress);
            Assert.AreEqual(EventHubsTransportType.AmqpWebSockets, processorOptions.ConnectionOptions.TransportType);
            Assert.AreEqual("http://proxyserver/", ((WebProxy)processorOptions.ConnectionOptions.Proxy).Address.AbsoluteUri);
            Assert.AreEqual(10, processorOptions.RetryOptions.MaximumRetries);
            Assert.AreEqual(expectedPathName, processor.EventHubName);

            int batchSize = (int)typeof(EventProcessor<EventProcessorHostPartition>)
                .GetProperty("EventBatchMaximumCount", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(processor);
            Assert.AreEqual(20, batchSize);
        }

        [Test]
        public void DefaultStrategyIsGreedy()
        {
            EventHubOptions options = new EventHubOptions();

            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection", ConnectionString));
            var factory = ConfigurationUtilities.CreateFactory(configuration, options);

            var processor = factory.GetEventProcessorHost("connection", "connection", "consumer", true);
            EventProcessorOptions processorOptions = (EventProcessorOptions)typeof(EventProcessor<EventProcessorHostPartition>)
                .GetProperty("Options", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(processor);

            Assert.AreEqual(LoadBalancingStrategy.Greedy, processorOptions.LoadBalancingStrategy);
        }
    }
}