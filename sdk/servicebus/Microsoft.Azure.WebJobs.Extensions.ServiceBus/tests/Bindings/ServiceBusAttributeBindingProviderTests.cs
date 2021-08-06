// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.ServiceBus.Bindings;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Bindings
{
    public class ServiceBusAttributeBindingProviderTests
    {
        private readonly ServiceBusAttributeBindingProvider _provider;
        private readonly IConfiguration _configuration;

        public ServiceBusAttributeBindingProviderTests()
        {
            _configuration = new ConfigurationBuilder().AddInMemoryCollection(new KeyValuePair<string, string>[] { new("connection", "connectionString") }).Build();

            Mock<INameResolver> mockResolver = new Mock<INameResolver>(MockBehavior.Strict);
            ServiceBusOptions config = new ServiceBusOptions();
            var messagingProvider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(config));
            var factory = new ServiceBusClientFactory(
                _configuration,
                new Mock<AzureComponentFactory>().Object,
                messagingProvider,
                new AzureEventSourceLogForwarder(new NullLoggerFactory()),
                new OptionsWrapper<ServiceBusOptions>(config));
            _provider = new ServiceBusAttributeBindingProvider(mockResolver.Object, messagingProvider, factory);
        }

        [Test]
        public async Task TryCreateAsync_AccountOverride_OverrideIsApplied()
        {
            ParameterInfo parameter = GetType().GetMethod("TestJob_AccountOverride", BindingFlags.NonPublic | BindingFlags.Static).GetParameters()[0];
            BindingProviderContext context = new BindingProviderContext(parameter, new Dictionary<string, Type>(), CancellationToken.None);

            IBinding binding = await _provider.TryCreateAsync(context);

            Assert.NotNull(binding);
        }

        [Test]
        public async Task TryCreateAsync_DefaultAccount()
        {
            ParameterInfo parameter = GetType().GetMethod("TestJob", BindingFlags.NonPublic | BindingFlags.Static).GetParameters()[0];
            BindingProviderContext context = new BindingProviderContext(parameter, new Dictionary<string, Type>(), CancellationToken.None);

            IBinding binding = await _provider.TryCreateAsync(context);

            Assert.NotNull(binding);
        }

        internal static void TestJob_AccountOverride(
            [ServiceBusAttribute("test"),
             ServiceBusAccount(Constants.DefaultConnectionStringName)] out ServiceBusMessage message)
        {
            message = new ServiceBusMessage();
        }

        internal static void TestJob(
            [ServiceBusAttribute("test", Connection = Constants.DefaultConnectionStringName)]
            out ServiceBusMessage message)
        {
            message = new ServiceBusMessage();
        }
    }
}
