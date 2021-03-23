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
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Config
{
    public class ServiceBusHostBuilderExtensionsTests
    {
        [Test]
        public void ConfigureOptions_AppliesValuesCorrectly_BackCompat()
        {
            ServiceBusOptions options = CreateOptionsFromConfigBackCompat();

            Assert.AreEqual(123, options.PrefetchCount);
            Assert.AreEqual("TestConnectionString", options.ConnectionString);
            Assert.AreEqual(123, options.MaxConcurrentCalls);
            Assert.False(options.AutoCompleteMessages);
            Assert.AreEqual(TimeSpan.FromSeconds(15), options.MaxAutoLockRenewalDuration);
        }

        [Test]
        public void ConfigureOptions_Format_Returns_Expected_BackCompat()
        {
            ServiceBusOptions options = CreateOptionsFromConfigBackCompat();

            string format = options.Format();
            JObject iObj = JObject.Parse(format);
            ServiceBusOptions result = iObj.ToObject<ServiceBusOptions>();

            Assert.AreEqual(123, result.PrefetchCount);
            // can't round trip the connection string
            Assert.IsNull(result.ConnectionString);
            Assert.AreEqual(123, result.MaxConcurrentCalls);
            Assert.False(result.AutoCompleteMessages);
            Assert.AreEqual(TimeSpan.FromSeconds(15), result.MaxAutoLockRenewalDuration);
        }

        [Test]
        public void ConfigureOptions_AppliesValuesCorrectly()
        {
            ServiceBusOptions options = CreateOptionsFromConfig();

            Assert.AreEqual(123, options.PrefetchCount);
            Assert.AreEqual("TestConnectionString", options.ConnectionString);
            Assert.AreEqual(123, options.MaxConcurrentCalls);
            Assert.False(options.AutoCompleteMessages);
            Assert.AreEqual(TimeSpan.FromSeconds(15), options.MaxAutoLockRenewalDuration);
        }

        [Test]
        public void ConfigureOptions_Format_Returns_Expected()
        {
            ServiceBusOptions options = CreateOptionsFromConfig();

            string format = options.Format();
            JObject iObj = JObject.Parse(format);
            ServiceBusOptions result = iObj.ToObject<ServiceBusOptions>();

            Assert.AreEqual(123, result.PrefetchCount);
            // can't round trip the connection string
            Assert.IsNull(result.ConnectionString);
            Assert.AreEqual(123, result.MaxConcurrentCalls);
            Assert.False(result.AutoCompleteMessages);
            Assert.AreEqual(TimeSpan.FromSeconds(15), result.MaxAutoLockRenewalDuration);
        }

        private static ServiceBusOptions CreateOptionsFromConfig()
        {
            string extensionPath = "AzureWebJobs:Extensions:ServiceBus";
            var values = new Dictionary<string, string>
            {
                { $"{extensionPath}:PrefetchCount", "123" },
                { $"ConnectionStrings:ServiceBus", "TestConnectionString" },
                { $"{extensionPath}:MaxConcurrentCalls", "123" },
                { $"{extensionPath}:AutoCompleteMessages", "false" },
                { $"{extensionPath}:MaxAutoLockRenewalDuration", "00:00:15" },
                { $"{extensionPath}:MaxConcurrentSessions", "123" },
            };

            ServiceBusOptions options = TestHelpers.GetConfiguredOptions<ServiceBusOptions>(b =>
            {
                b.AddServiceBus();
            }, values);
            return options;
        }

        private static ServiceBusOptions CreateOptionsFromConfigBackCompat()
        {
            string extensionPath = "AzureWebJobs:Extensions:ServiceBus";
            var values = new Dictionary<string, string>
            {
                { $"{extensionPath}:PrefetchCount", "123" },
                { $"ConnectionStrings:ServiceBus", "TestConnectionString" },
                { $"{extensionPath}:MessageHandlerOptions:MaxConcurrentCalls", "123" },
                { $"{extensionPath}:MessageHandlerOptions:AutoComplete", "false" },
                { $"{extensionPath}:MessageHandlerOptions:MaxAutoRenewDuration", "00:00:15" },
                { $"{extensionPath}:SessionHandlerOptions:MaxConcurrentSessions", "123" },
                { $"{extensionPath}:BatchOptions:OperationTimeout","00:00:15" },
                { $"{extensionPath}:BatchOptions:MaxMessageCount", "123" },
                { $"{extensionPath}:BatchOptions:AutoComplete", "true" },
            };

            ServiceBusOptions options = TestHelpers.GetConfiguredOptions<ServiceBusOptions>(b =>
            {
                b.AddServiceBus();
            }, values);
            return options;
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
        public void ReadDefaultConnectionString(string defaultConnectionString, string sefaultConectionSettingString, string expectedValue)
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
