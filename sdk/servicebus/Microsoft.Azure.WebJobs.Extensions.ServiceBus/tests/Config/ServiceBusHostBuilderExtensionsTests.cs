// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Xunit;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Config
{
    public class ServiceBusHostBuilderExtensionsTests
    {
        [Fact]
        public void ConfigureOptions_AppliesValuesCorrectly()
        {
            string extensionPath = "AzureWebJobs:Extensions:ServiceBus";
            var values = new Dictionary<string, string>
            {
                { $"{extensionPath}:PrefetchCount", "123" },
                { $"ConnectionStrings:ServiceBus", "TestConnectionString" },
                { $"{extensionPath}:MessageHandlerOptions:MaxConcurrentCalls", "123" },
                { $"{extensionPath}:MessageHandlerOptions:AutoComplete", "false" },
                { $"{extensionPath}:MessageHandlerOptions:MaxAutoRenewDuration", "00:00:15" }
            };

            ServiceBusOptions options = TestHelpers.GetConfiguredOptions<ServiceBusOptions>(b =>
            {
                b.AddServiceBus();
            }, values);

            Assert.Equal(123, options.PrefetchCount);
            Assert.Equal("TestConnectionString", options.ConnectionString);
            Assert.Equal(123, options.MessageHandlerOptions.MaxConcurrentCalls);
            Assert.False(options.MessageHandlerOptions.AutoComplete);
            Assert.Equal(TimeSpan.FromSeconds(15), options.MessageHandlerOptions.MaxAutoRenewDuration);
        }

        [Fact]
        public void AddServiceBus_ThrowsArgumentNull_WhenServiceBusOptionsIsNull()
        {
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost(b =>
                {
                    b.AddServiceBus();
                })
                .ConfigureServices(s => s.AddSingleton<IOptions<ServiceBusOptions>>(p => null))
                .Build();

            var exception = Assert.Throws<ArgumentNullException>(() => host.Services.GetServices<IExtensionConfigProvider>());

            Assert.Equal("serviceBusOptions", exception.ParamName);
        }

        [Fact]
        public void AddServiceBus_NoServiceBusOptions_PerformsExpectedRegistration()
        {
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost(b =>
                {
                    b.AddServiceBus();
                })
                .Build();

            var extensions = host.Services.GetService<IExtensionRegistry>();
            IExtensionConfigProvider[] configProviders = extensions.GetExtensions<IExtensionConfigProvider>().ToArray();

            // verify that the service bus config provider was registered
            var serviceBusExtensionConfig = configProviders.OfType<ServiceBusExtensionConfigProvider>().Single();
        }

        [Fact]
        public void AddServiceBus_ServiceBusOptionsProvided_PerformsExpectedRegistration()
        {
            string fakeConnStr = "test service bus connection";

            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost(b =>
                {
                    b.AddServiceBus();
                })
                .ConfigureServices(s =>
                {
                    s.Configure<ServiceBusOptions>(o =>
                    {
                        o.ConnectionString = fakeConnStr;
                    });
                })
                .Build();

            // verify that the service bus config provider was registered
            var extensions = host.Services.GetService<IExtensionRegistry>();
            IExtensionConfigProvider[] configProviders = extensions.GetExtensions<IExtensionConfigProvider>().ToArray();

            // verify that the service bus config provider was registered
            var serviceBusExtensionConfig = configProviders.OfType<ServiceBusExtensionConfigProvider>().Single();

            Assert.Equal(fakeConnStr, serviceBusExtensionConfig.Options.ConnectionString);
        }
        [Theory]
        [InlineData("DefaultConnectionString", "DefaultConectionSettingString", "DefaultConnectionString")]
        [InlineData("DefaultConnectionString", null, "DefaultConnectionString")]
        [InlineData(null, "DefaultConectionSettingString", "DefaultConectionSettingString")]
        [InlineData(null, null, null)]
        public void ReadDeafultConnectionString(string defaultConnectionString, string sefaultConectionSettingString, string expectedValue)
        {
            ServiceBusOptions options = TestHelpers.GetConfiguredOptions<ServiceBusOptions>(b =>
            {
                var test = b.Services.Single(x => x.ServiceType == typeof(IConfiguration));

                var envPrpvider = (test.ImplementationInstance as ConfigurationRoot).Providers
                    .Single(x => x.GetType() == typeof(EnvironmentVariablesConfigurationProvider));
                envPrpvider.Set("ConnectionStrings:" + Constants.DefaultConnectionStringName, defaultConnectionString);
                envPrpvider.Set(Constants.DefaultConnectionSettingStringName, sefaultConectionSettingString);

                b.AddServiceBus();
            }, new Dictionary<string, string>());

            Assert.Equal(options.ConnectionString, expectedValue);
        }
    }
}
