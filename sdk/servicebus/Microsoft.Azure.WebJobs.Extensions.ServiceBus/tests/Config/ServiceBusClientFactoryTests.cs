// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.Tests.Config
{
    public class ServiceBusClientFactoryTests
    {
        private const string ConnectionString = "Endpoint=sb://test89123-ns-x.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=secretkey";

        [Test]
        [TestCase("DefaultConnectionString", "DefaultConectionSettingString", "DefaultConnectionString")]
        [TestCase("DefaultConnectionString", null, "DefaultConnectionString")]
        [TestCase(null, "DefaultConectionSettingString", "DefaultConectionSettingString")]
        [TestCase(null, null, null)]
        public void ReadDefaultConnectionString(string defaultConnectionString, string defaultConnectionSettingString, string expectedValue)
        {
            var configuration = ConfigurationUtilities.CreateConfiguration(
                new KeyValuePair<string, string>("ConnectionStrings:" + Constants.DefaultConnectionStringName, defaultConnectionString),
                new KeyValuePair<string, string>(Constants.DefaultConnectionSettingStringName, defaultConnectionSettingString));

            var mockProvider = new Mock<MessagingProvider>(new OptionsWrapper<ServiceBusOptions>(new ServiceBusOptions()));
            mockProvider.Setup(
                p => p.CreateClient(expectedValue, It.IsAny<ServiceBusClientOptions>()))
                .Returns(Mock.Of<ServiceBusClient>());

            var factory = new ServiceBusClientFactory(configuration, Mock.Of<AzureComponentFactory>(), mockProvider.Object, new AzureEventSourceLogForwarder(new NullLoggerFactory()), new OptionsWrapper<ServiceBusOptions>(new ServiceBusOptions()));
            if (expectedValue == null)
            {
                Assert.That(
                    () => factory.CreateClientFromSetting(null),
                    Throws.InstanceOf<InvalidOperationException>());
            }
            else
            {
                factory.CreateClientFromSetting(null);
                mockProvider.VerifyAll();
            }
        }

        [Test]
        public void CreatesClientsFromConfigWithConnectionString()
        {
            ServiceBusOptions options = new ServiceBusOptions();
            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection", ConnectionString));

            var factory = ConfigurationUtilities.CreateFactory(configuration, options);
            var client = factory.CreateClientFromSetting("connection");
            var adminClient = factory.CreateAdministrationClient("connection");

            Assert.NotNull(client);
            Assert.NotNull(adminClient);
            Assert.AreEqual("test89123-ns-x.servicebus.windows.net", client.FullyQualifiedNamespace);
        }

        [Test]
        public void CreatesClientsFromConfigWithFullyQualifiedNamespace()
        {
            ServiceBusOptions options = new ServiceBusOptions();

            var componentFactoryMock = new Mock<AzureComponentFactory>();
            componentFactoryMock.Setup(c => c.CreateTokenCredential(
                    It.Is<IConfiguration>(c=> c["fullyQualifiedNamespace"] != null)))
                .Returns(new DefaultAzureCredential());

            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection:fullyQualifiedNamespace", "test89123-ns-x.servicebus.windows.net"));
            var factory = ConfigurationUtilities.CreateFactory(configuration, options, componentFactoryMock.Object);
            var client = factory.CreateClientFromSetting("connection");
            var adminClient = factory.CreateAdministrationClient("connection");

            Assert.NotNull(client);
            Assert.NotNull(adminClient);
            Assert.AreEqual("test89123-ns-x.servicebus.windows.net", client.FullyQualifiedNamespace);
        }

        [Test]
        public void FailsWhenConnectionStringUsedAsName()
        {
            ServiceBusOptions options = new ServiceBusOptions();

            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection", ConnectionString));
            var factory = ConfigurationUtilities.CreateFactory(configuration, options);

            var errorMessage = Assert.Throws<InvalidOperationException>(() => factory.CreateClientFromSetting(ConnectionString)).Message;
            StringAssert.DoesNotContain(ConnectionString, errorMessage);
            StringAssert.Contains("REDACTED", errorMessage);
        }
    }
}
