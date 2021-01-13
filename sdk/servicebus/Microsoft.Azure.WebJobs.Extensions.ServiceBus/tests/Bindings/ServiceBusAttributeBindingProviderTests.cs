// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.ServiceBus.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Bindings
{
    public class ServiceBusAttributeBindingProviderTests
    {
        private readonly ServiceBusAttributeBindingProvider _provider;
        private readonly IConfiguration _configuration;

        public ServiceBusAttributeBindingProviderTests()
        {
            _configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
            Mock<INameResolver> mockResolver = new Mock<INameResolver>(MockBehavior.Strict);
            ServiceBusOptions config = new ServiceBusOptions();
            _provider = new ServiceBusAttributeBindingProvider(mockResolver.Object, config, _configuration, new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(config)));
        }

        [Fact]
        public async Task TryCreateAsync_AccountOverride_OverrideIsApplied()
        {
            ParameterInfo parameter = GetType().GetMethod("TestJob_AccountOverride", BindingFlags.NonPublic | BindingFlags.Static).GetParameters()[0];
            BindingProviderContext context = new BindingProviderContext(parameter, new Dictionary<string, Type>(), CancellationToken.None);

            IBinding binding = await _provider.TryCreateAsync(context);

            Assert.NotNull(binding);
        }

        [Fact]
        public async Task TryCreateAsync_DefaultAccount()
        {
            ParameterInfo parameter = GetType().GetMethod("TestJob", BindingFlags.NonPublic | BindingFlags.Static).GetParameters()[0];
            BindingProviderContext context = new BindingProviderContext(parameter, new Dictionary<string, Type>(), CancellationToken.None);

            IBinding binding = await _provider.TryCreateAsync(context);

            Assert.NotNull(binding);
        }

        internal static void TestJob_AccountOverride(
            [ServiceBusAttribute("test"),
             ServiceBusAccount(Constants.DefaultConnectionStringName)] out Message message)
        {
            message = new Message();
        }

        internal static void TestJob(
            [ServiceBusAttribute("test", Connection = Constants.DefaultConnectionStringName)] out Message message)
        {
            message = new Message();
        }
    }
}
