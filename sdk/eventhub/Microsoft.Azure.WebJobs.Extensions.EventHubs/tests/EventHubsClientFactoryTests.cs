// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Identity;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Producer;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubsClientFactoryTests
    {
        private const string ConnectionString = "Endpoint=sb://test89123-ns-x.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=secretkey";
        private const string ConnectionStringWithEventHub = "Endpoint=sb://test89123-ns-x.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=secretkey;EntityPath=path2";

        // Validate that if connection string has EntityPath, that takes precedence over the parameter.
        [TestCase("k1", ConnectionString)]
        [TestCase("path2", ConnectionStringWithEventHub)]
        public void GetEventHubClient_AddsConnection(string expectedPathName, string connectionString)
        {
            EventHubOptions options = new EventHubOptions();
            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection", connectionString));

            var factory = new EventHubClientFactory(configuration, Mock.Of<AzureComponentFactory>(), Options.Create(options), new DefaultNameResolver(configuration), new AzureEventSourceLogForwarder(new NullLoggerFactory()));

            var client = factory.GetEventHubProducerClient(expectedPathName, "connection");
            Assert.AreEqual(expectedPathName, client.EventHubName);
        }

        [Test]
        public void CreatesClientsFromConfigWithConnectionString()
        {
            EventHubOptions options = new EventHubOptions();
            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection", ConnectionString));

            var factory = new EventHubClientFactory(configuration, Mock.Of<AzureComponentFactory>(), Options.Create(options), new DefaultNameResolver(configuration), new AzureEventSourceLogForwarder(new NullLoggerFactory()));
            var producer = factory.GetEventHubProducerClient("k1", "connection");
            var consumer = factory.GetEventHubConsumerClient("k1", "connection", null);
            var host = factory.GetEventProcessorHost("k1", "connection", null);

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

            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection:fullyQualifiedNamespace", "test89123-ns-x.servicebus.windows.net"));

            var factory = new EventHubClientFactory(configuration, componentFactoryMock.Object, Options.Create(options), new DefaultNameResolver(configuration), new AzureEventSourceLogForwarder(new NullLoggerFactory()));
            var producer = factory.GetEventHubProducerClient("k1", "connection");
            var consumer = factory.GetEventHubConsumerClient("k1", "connection", null);
            var host = factory.GetEventProcessorHost("k1", "connection", null);

            Assert.AreEqual("k1", producer.EventHubName);
            Assert.AreEqual("k1", consumer.EventHubName);
            Assert.AreEqual("k1", host.EventHubName);

            Assert.AreEqual("test89123-ns-x.servicebus.windows.net", producer.FullyQualifiedNamespace);
            Assert.AreEqual("test89123-ns-x.servicebus.windows.net", consumer.FullyQualifiedNamespace);
            Assert.AreEqual("test89123-ns-x.servicebus.windows.net", host.FullyQualifiedNamespace);
        }

        [Test]
        public void ConsumersAndProducersAreCached()
        {
            EventHubOptions options = new EventHubOptions();
            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection", ConnectionString));

            var factory = new EventHubClientFactory(configuration, Mock.Of<AzureComponentFactory>(), Options.Create(options), new DefaultNameResolver(configuration), new AzureEventSourceLogForwarder(new NullLoggerFactory()));
            var producer = factory.GetEventHubProducerClient("k1", "connection");
            var consumer = factory.GetEventHubConsumerClient("k1", "connection", null);
            var producer2 = factory.GetEventHubProducerClient("k1", "connection");
            var consumer2 = factory.GetEventHubConsumerClient("k1", "connection", null);

            Assert.AreSame(producer, producer2);
            Assert.AreSame(consumer, consumer2);
        }

        [Test]
        public void UsesDefaultConnectionToStorageAccount()
        {
            EventHubOptions options = new EventHubOptions();

            var configuration = CreateConfiguration(new KeyValuePair<string, string>("AzureWebJobsStorage", "UseDevelopmentStorage=true"));

            var factoryMock = new Mock<AzureComponentFactory>();
            factoryMock.Setup(m => m.CreateClient(
                        typeof(BlobServiceClient),
                        It.Is<ConfigurationSection>(c => c.Path == "AzureWebJobsStorage"),
                        null, null))
                .Returns(new BlobServiceClient(configuration["AzureWebJobsStorage"]));

            var factory = new EventHubClientFactory(configuration, factoryMock.Object, Options.Create(options), new DefaultNameResolver(configuration), new AzureEventSourceLogForwarder(new NullLoggerFactory()));

            var client = factory.GetCheckpointStoreClient();
            Assert.AreEqual("azure-webjobs-eventhub", client.Name);
            Assert.AreEqual("devstoreaccount1", client.AccountName);
        }

        [TestCase("k1", ConnectionString)]
        [TestCase("path2", ConnectionStringWithEventHub)]
        public void RespectsConnectionOptionsForProducer(string expectedPathName, string connectionString)
        {
            var testEndpoint = new Uri("http://mycustomendpoint.com");
            EventHubOptions options = new EventHubOptions
            {
                ConnectionOptions = new EventHubConnectionOptions
                {
                    CustomEndpointAddress = testEndpoint
                },
                ClientRetryOptions = new EventHubsRetryOptions
                {
                    MaximumRetries = 10
                }
            };

            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection", connectionString));
            var factory = new EventHubClientFactory(configuration, Mock.Of<AzureComponentFactory>(), Options.Create(options), new DefaultNameResolver(configuration), new AzureEventSourceLogForwarder(new NullLoggerFactory()));

            var producer = factory.GetEventHubProducerClient(expectedPathName, "connection");
            EventHubConnection connection = (EventHubConnection)typeof(EventHubProducerClient).GetProperty("Connection", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(producer);
            EventHubConnectionOptions connectionOptions = (EventHubConnectionOptions)typeof(EventHubConnection).GetProperty("Options", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(connection);

            Assert.AreEqual(testEndpoint, connectionOptions.CustomEndpointAddress);
            Assert.AreEqual(expectedPathName, producer.EventHubName);

            EventHubProducerClientOptions producerOptions = (EventHubProducerClientOptions)typeof(EventHubProducerClient).GetProperty("Options", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(producer);
            Assert.AreEqual(10, producerOptions.RetryOptions.MaximumRetries);
            Assert.AreEqual(expectedPathName, producer.EventHubName);
        }

        [TestCase("k1", ConnectionString)]
        [TestCase("path2", ConnectionStringWithEventHub)]
        public void RespectsConnectionOptionsForConsumer(string expectedPathName, string connectionString)
        {
            var testEndpoint = new Uri("http://mycustomendpoint.com");
            EventHubOptions options = new EventHubOptions
            {
                ConnectionOptions = new EventHubConnectionOptions
                {
                    CustomEndpointAddress = testEndpoint
                },
                ClientRetryOptions = new EventHubsRetryOptions
                {
                    MaximumRetries = 10
                }
            };

            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection", connectionString));
            var factory = new EventHubClientFactory(configuration, Mock.Of<AzureComponentFactory>(), Options.Create(options), new DefaultNameResolver(configuration), new AzureEventSourceLogForwarder(new NullLoggerFactory()));

            var consumer = factory.GetEventHubConsumerClient(expectedPathName, "connection", "consumer");
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

        [TestCase("k1", ConnectionString)]
        [TestCase("path2", ConnectionStringWithEventHub)]
        public void RespectsConnectionOptionsForProcessor(string expectedPathName, string connectionString)
        {
            var testEndpoint = new Uri("http://mycustomendpoint.com");
            EventHubOptions options = new EventHubOptions
            {
                ConnectionOptions = new EventHubConnectionOptions
                {
                    CustomEndpointAddress = testEndpoint
                },
                ClientRetryOptions = new EventHubsRetryOptions
                {
                    MaximumRetries = 10
                }
            };

            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection", connectionString));
            var factory = new EventHubClientFactory(configuration, Mock.Of<AzureComponentFactory>(), Options.Create(options), new DefaultNameResolver(configuration), new AzureEventSourceLogForwarder(new NullLoggerFactory()));

            var processor = factory.GetEventProcessorHost(expectedPathName, "connection", "consumer");
            EventProcessorOptions processorOptions = (EventProcessorOptions)typeof(EventProcessor<EventProcessorHostPartition>)
                .GetProperty("Options", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(processor);
            Assert.AreEqual(testEndpoint, processorOptions.ConnectionOptions.CustomEndpointAddress);

            Assert.AreEqual(10, processorOptions.RetryOptions.MaximumRetries);
            Assert.AreEqual(expectedPathName, processor.EventHubName);
        }

        [Test]
        public void DefaultStrategyIsGreedy()
        {
            EventHubOptions options = new EventHubOptions();

            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection", ConnectionString));
            var factory = new EventHubClientFactory(configuration, Mock.Of<AzureComponentFactory>(), Options.Create(options), new DefaultNameResolver(configuration), new AzureEventSourceLogForwarder(new NullLoggerFactory()));

            var processor = factory.GetEventProcessorHost("connection", "connection", "consumer");
            EventProcessorOptions processorOptions = (EventProcessorOptions)typeof(EventProcessor<EventProcessorHostPartition>)
                .GetProperty("Options", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(processor);

            Assert.AreEqual(LoadBalancingStrategy.Greedy, processorOptions.LoadBalancingStrategy);
        }

        private IConfiguration CreateConfiguration(params KeyValuePair<string, string>[] data)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(data).Build();
        }
    }
}