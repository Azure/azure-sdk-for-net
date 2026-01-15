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
            Assert.That(client.EventHubName, Is.EqualTo(expectedPathName));
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

            Assert.That(producer.EventHubName, Is.EqualTo("k1"));
            Assert.That(consumer.EventHubName, Is.EqualTo("k1"));
            Assert.That(host.EventHubName, Is.EqualTo("k1"));

            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo("test89123-ns-x.servicebus.windows.net"));
            Assert.That(consumer.FullyQualifiedNamespace, Is.EqualTo("test89123-ns-x.servicebus.windows.net"));
            Assert.That(host.FullyQualifiedNamespace, Is.EqualTo("test89123-ns-x.servicebus.windows.net"));
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

            Assert.That(producer.EventHubName, Is.EqualTo("k1"));
            Assert.That(consumer.EventHubName, Is.EqualTo("k1"));
            Assert.That(host.EventHubName, Is.EqualTo("k1"));

            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo("test89123-ns-x.servicebus.windows.net"));
            Assert.That(consumer.FullyQualifiedNamespace, Is.EqualTo("test89123-ns-x.servicebus.windows.net"));
            Assert.That(host.FullyQualifiedNamespace, Is.EqualTo("test89123-ns-x.servicebus.windows.net"));
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

            Assert.That(producer2, Is.SameAs(producer));
            Assert.That(consumer2, Is.SameAs(consumer));
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
            Assert.That(consumer4, Is.SameAs(consumer2));
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

            Assert.That(producer1.EventHubName, Is.EqualTo("k1"));
            Assert.That(producer2.EventHubName, Is.EqualTo("k1"));
            Assert.AreNotSame(producer1, producer2);

            Assert.That(producer3.EventHubName, Is.EqualTo("k1"));
            Assert.That(producer4.EventHubName, Is.EqualTo("k1"));
            Assert.AreNotSame(producer3, producer4);

            Assert.That(producer3, Is.SameAs(producer1));
            Assert.That(producer4, Is.SameAs(producer2));
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
            Assert.That(client.Name, Is.EqualTo("azure-webjobs-eventhub"));
            Assert.That(client.AccountName, Is.EqualTo("devstoreaccount1"));
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

            Assert.That(connectionOptions.CustomEndpointAddress, Is.EqualTo(testEndpoint));
            Assert.That(producer.EventHubName, Is.EqualTo(expectedPathName));

            EventHubProducerClientOptions producerOptions = (EventHubProducerClientOptions)typeof(EventHubProducerClient).GetProperty("Options", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(producer);
            Assert.That(producerOptions.RetryOptions.MaximumRetries, Is.EqualTo(10));
            Assert.That(producer.EventHubName, Is.EqualTo(expectedPathName));
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
            Assert.That(connectionOptions.CustomEndpointAddress, Is.EqualTo(testEndpoint));

            EventHubsRetryPolicy retryPolicy = (EventHubsRetryPolicy)typeof(EventHubConsumerClient)
                .GetProperty("RetryPolicy", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(consumerClient);

            // Reflection was still necessary here because BasicRetryOptions (which is the concrete derived type)
            // is internal.
            EventHubsRetryOptions retryOptions = (EventHubsRetryOptions)retryPolicy.GetType()
                .GetProperty("Options", BindingFlags.Public | BindingFlags.Instance)
                .GetValue(retryPolicy);
            Assert.That(retryOptions.MaximumRetries, Is.EqualTo(10));
            Assert.That(consumer.EventHubName, Is.EqualTo(expectedPathName));
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
            Assert.That(processorOptions.ConnectionOptions.CustomEndpointAddress, Is.EqualTo(testEndpoint));
            Assert.That(processorOptions.ConnectionOptions.TransportType, Is.EqualTo(EventHubsTransportType.AmqpWebSockets));
            Assert.That(((WebProxy)processorOptions.ConnectionOptions.Proxy).Address.AbsoluteUri, Is.EqualTo("http://proxyserver/"));
            Assert.That(processorOptions.RetryOptions.MaximumRetries, Is.EqualTo(10));
            Assert.That(processor.EventHubName, Is.EqualTo(expectedPathName));

            int batchSize = (int)typeof(EventProcessor<EventProcessorHostPartition>)
                .GetProperty("EventBatchMaximumCount", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(processor);
            Assert.That(batchSize, Is.EqualTo(20));
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

            Assert.That(processorOptions.LoadBalancingStrategy, Is.EqualTo(LoadBalancingStrategy.Greedy));
        }
    }
}