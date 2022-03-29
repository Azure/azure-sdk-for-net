// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.ServiceBus.Tests;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.ServiceBus.Tests.Config
{
    public class ServiceBusClientFactoryTests
    {
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
    }
}
