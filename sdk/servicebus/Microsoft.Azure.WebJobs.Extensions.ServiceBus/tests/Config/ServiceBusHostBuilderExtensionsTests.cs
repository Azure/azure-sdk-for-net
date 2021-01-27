// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Config
{
    public class ServiceBusHostBuilderExtensionsTests
    {
        [Test]
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

            Assert.AreEqual(123, options.PrefetchCount);
            Assert.AreEqual("TestConnectionString", options.ConnectionString);
            Assert.AreEqual(123, options.MessageHandlerOptions.MaxConcurrentCalls);
            Assert.False(options.MessageHandlerOptions.AutoComplete);
            Assert.AreEqual(TimeSpan.FromSeconds(15), options.MessageHandlerOptions.MaxAutoRenewDuration);
        }

        [Test]
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

            Assert.AreEqual("serviceBusOptions", exception.ParamName);
        }

        [Test]
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

        [Test]
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

            Assert.AreEqual(fakeConnStr, serviceBusExtensionConfig.Options.ConnectionString);
        }

        [Test]
        [TestCase("DefaultConnectionString", "DefaultConectionSettingString", "DefaultConnectionString")]
        [TestCase("DefaultConnectionString", null, "DefaultConnectionString")]
        [TestCase(null, "DefaultConectionSettingString", "DefaultConectionSettingString")]
        [TestCase(null, null, null)]
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

            Assert.AreEqual(options.ConnectionString, expectedValue);
        }
    }
}
