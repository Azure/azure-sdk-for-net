// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebJobs.ServiceBus.Triggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Azure;
using Azure.Messaging.ServiceBus.Tests;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.ServiceBus.Tests;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Bindings
{
    public class ServiceBusTriggerAttributeBindingProviderTests
    {
        private readonly ServiceBusTriggerAttributeBindingProvider _provider;

        public ServiceBusTriggerAttributeBindingProviderTests()
        {
            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>(Constants.DefaultConnectionStringName, "defaultConnection"));

            Mock<INameResolver> mockResolver = new Mock<INameResolver>(MockBehavior.Strict);

            ServiceBusOptions options = new ServiceBusOptions();

            Mock<IConverterManager> convertManager = new Mock<IConverterManager>(MockBehavior.Default);
            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(options));
            var factory = new ServiceBusClientFactory(configuration, new Mock<AzureComponentFactory>().Object, provider, new AzureEventSourceLogForwarder(new NullLoggerFactory()), new OptionsWrapper<ServiceBusOptions>(options));
            _provider = new ServiceBusTriggerAttributeBindingProvider(mockResolver.Object, options, provider, NullLoggerFactory.Instance, convertManager.Object, factory);
        }

        [Test]
        public async Task TryCreateAsync_AccountOverride_OverrideIsApplied()
        {
            ParameterInfo parameter = GetType().GetMethod("TestJob_AccountOverride", BindingFlags.NonPublic | BindingFlags.Static).GetParameters()[0];
            TriggerBindingProviderContext context = new TriggerBindingProviderContext(parameter, CancellationToken.None);

            ITriggerBinding binding = await _provider.TryCreateAsync(context);

            Assert.NotNull(binding);
        }

        [Test]
        public async Task TryCreateAsync_DefaultAccount()
        {
            ParameterInfo parameter = GetType().GetMethod("TestJob", BindingFlags.NonPublic | BindingFlags.Static).GetParameters()[0];
            TriggerBindingProviderContext context = new TriggerBindingProviderContext(parameter, CancellationToken.None);

            ITriggerBinding binding = await _provider.TryCreateAsync(context);

            Assert.NotNull(binding);
        }

        internal static void TestJob_AccountOverride(
            [ServiceBusTriggerAttribute("test"),
             ServiceBusAccount(Constants.DefaultConnectionStringName)]
            ServiceBusMessage message)
        {
            message = new ServiceBusMessage();
        }

        internal static void TestJob(
            [ServiceBusTriggerAttribute("test", Connection = Constants.DefaultConnectionStringName)]
            ServiceBusMessage message)
        {
            message = new ServiceBusMessage();
        }
    }
}
