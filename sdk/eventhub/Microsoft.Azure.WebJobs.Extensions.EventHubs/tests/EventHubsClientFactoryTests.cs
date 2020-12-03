// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Azure.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
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
        public void EntityPathInConnectionString(string expectedPathName, string connectionString)
        {
            EventHubOptions options = new EventHubOptions();

            // Test sender
            options.AddSender("k1", connectionString);

            var configuration = CreateConfiguration();
            var factory = new EventHubClientFactory(configuration, Mock.Of<AzureComponentFactory>(), Options.Create(options), new DefaultNameResolver(configuration));

            var client = factory.GetEventHubProducerClient("k1", null);
            Assert.AreEqual(expectedPathName, client.EventHubName);
        }

        // Validate that if connection string has EntityPath, that takes precedence over the parameter.
        [TestCase("k1", ConnectionString)]
        [TestCase("path2", ConnectionStringWithEventHub)]
        public void GetEventHubClient_AddsConnection(string expectedPathName, string connectionString)
        {
            EventHubOptions options = new EventHubOptions();
            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection", connectionString));

            var factory = new EventHubClientFactory(configuration, Mock.Of<AzureComponentFactory>(), Options.Create(options), new DefaultNameResolver(configuration));

            var client = factory.GetEventHubProducerClient("k1", "connection");
            Assert.AreEqual(expectedPathName, client.EventHubName);
        }

        [Test]
        public void CreatesClientsFromConfigWithConnectionString()
        {
            EventHubOptions options = new EventHubOptions();
            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection", ConnectionString));

            var factory = new EventHubClientFactory(configuration, Mock.Of<AzureComponentFactory>(), Options.Create(options), new DefaultNameResolver(configuration));
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

            var factory = new EventHubClientFactory(configuration, componentFactoryMock.Object, Options.Create(options), new DefaultNameResolver(configuration));
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

            var factory = new EventHubClientFactory(configuration, Mock.Of<AzureComponentFactory>(), Options.Create(options), new DefaultNameResolver(configuration));
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

            // Test sender
            options.AddReceiver("k1", ConnectionString);

            var configuration = CreateConfiguration(new KeyValuePair<string, string>("AzureWebJobsStorage", "UseDevelopmentStorage=true"));

            var factory = new EventHubClientFactory(configuration, Mock.Of<AzureComponentFactory>(), Options.Create(options), new DefaultNameResolver(configuration));

            var client = factory.GetCheckpointStoreClient("k1");
            Assert.AreEqual("azure-webjobs-eventhub", client.Name);
            Assert.AreEqual("devstoreaccount1", client.AccountName);
        }

        [Test]
        public void UsesRegisteredConnectionToStorageAccount()
        {
            EventHubOptions options = new EventHubOptions();

            // Test sender
            options.AddReceiver("k1",
                ConnectionString,
                "BlobEndpoint=http://blobs/;AccountName=test;AccountKey=abc2564=");

            var configuration = CreateConfiguration();

            var factory = new EventHubClientFactory(configuration, Mock.Of<AzureComponentFactory>(), Options.Create(options), new DefaultNameResolver(configuration));

            var client = factory.GetCheckpointStoreClient("k1");
            Assert.AreEqual("azure-webjobs-eventhub", client.Name);
            Assert.AreEqual("http://blobs/azure-webjobs-eventhub", client.Uri.ToString());
        }

        private IConfiguration CreateConfiguration(params KeyValuePair<string, string>[] data)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(data).Build();
        }
    }
}