﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebJobs.ServiceBus.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Config
{
    public class ServiceBusHostBuilderExtensionsTests
    {
        private const string ExtensionPath = "AzureWebJobs:Extensions:ServiceBus";

        [Test]
        public void ConfigureOptions_AppliesValuesCorrectly_BackCompat()
        {
            ServiceBusOptions options = CreateOptionsFromConfigBackCompat();

            Assert.AreEqual(123, options.PrefetchCount);
            Assert.AreEqual(123, options.MaxConcurrentCalls);
            Assert.False(options.AutoCompleteMessages);
            Assert.AreEqual(TimeSpan.FromSeconds(15), options.MaxAutoLockRenewalDuration);
        }

        [Test]
        public void ConfigureOptions_Format_Returns_Expected_BackCompat()
        {
            ServiceBusOptions options = CreateOptionsFromConfigBackCompat();
            JObject jObject = new JObject
            {
                { ExtensionPath, JObject.Parse(((IOptionsFormatter)options).Format()) }
            };

            ServiceBusOptions result = TestHelpers.GetConfiguredOptions<ServiceBusOptions>(
                b =>
                {
                    b.AddServiceBus();
                },
                jsonStream: new BinaryData(jObject.ToString()).ToStream());

            Assert.AreEqual(123, result.PrefetchCount);

            Assert.AreEqual(123, result.MaxConcurrentCalls);
            Assert.False(result.AutoCompleteMessages);
            Assert.AreEqual(TimeSpan.FromSeconds(15), result.MaxAutoLockRenewalDuration);
        }

        [Test]
        public void ConfigureOptions_AppliesValuesCorrectly()
        {
            ServiceBusOptions options = CreateOptionsFromConfig();

            Assert.AreEqual(123, options.PrefetchCount);
            Assert.AreEqual(123, options.MaxConcurrentCalls);
            Assert.False(options.AutoCompleteMessages);
            Assert.AreEqual(TimeSpan.FromSeconds(15), options.MaxAutoLockRenewalDuration);
            Assert.AreEqual(ServiceBusTransportType.AmqpWebSockets, options.TransportType);
            Assert.AreEqual("http://proxyserver:8080/", ((WebProxy)options.WebProxy).Address.AbsoluteUri);
            Assert.AreEqual(10, options.ClientRetryOptions.MaxRetries);
        }

        [Test]
        public void ConfigureOptions_Format_Returns_Expected()
        {
            ServiceBusOptions options = CreateOptionsFromConfig();
            JObject jObject = new JObject
            {
                { ExtensionPath, JObject.Parse(((IOptionsFormatter)options).Format()) }
            };

            ServiceBusOptions result = TestHelpers.GetConfiguredOptions<ServiceBusOptions>(
                b =>
                {
                    b.AddServiceBus();
                },
                jsonStream: new BinaryData(jObject.ToString()).ToStream());

            Assert.AreEqual(123, result.PrefetchCount);

            Assert.AreEqual(123, result.MaxConcurrentCalls);
            Assert.False(result.AutoCompleteMessages);
            Assert.AreEqual(TimeSpan.FromSeconds(15), result.MaxAutoLockRenewalDuration);
            Assert.AreEqual("http://proxyserver:8080/", ((WebProxy)result.WebProxy).Address.AbsoluteUri);
            Assert.AreEqual(10, result.ClientRetryOptions.MaxRetries);
        }

        private static ServiceBusOptions CreateOptionsFromConfig()
        {
            var values = new Dictionary<string, string>
            {
                { $"{ExtensionPath}:PrefetchCount", "123" },
                { $"ConnectionStrings:ServiceBus", "TestConnectionString" },
                { $"{ExtensionPath}:MaxConcurrentCalls", "123" },
                { $"{ExtensionPath}:AutoCompleteMessages", "false" },
                { $"{ExtensionPath}:MaxAutoLockRenewalDuration", "00:00:15" },
                { $"{ExtensionPath}:MaxConcurrentSessions", "123" },
                { $"{ExtensionPath}:TransportType", "AmqpWebSockets" },
                { $"{ExtensionPath}:WebProxy", "http://proxyserver:8080/" },
                { $"{ExtensionPath}:ClientRetryOptions:MaxRetries", "10" },
            };

            ServiceBusOptions options = TestHelpers.GetConfiguredOptions<ServiceBusOptions>(b =>
            {
                b.AddServiceBus();
            }, values);
            return options;
        }

        private static ServiceBusOptions CreateOptionsFromConfigBackCompat()
        {
            var values = new Dictionary<string, string>
            {
                { $"{ExtensionPath}:PrefetchCount", "123" },
                { $"ConnectionStrings:ServiceBus", "TestConnectionString" },
                { $"{ExtensionPath}:MessageHandlerOptions:MaxConcurrentCalls", "123" },
                { $"{ExtensionPath}:MessageHandlerOptions:AutoComplete", "false" },
                { $"{ExtensionPath}:MessageHandlerOptions:MaxAutoRenewDuration", "00:00:15" },
                { $"{ExtensionPath}:SessionHandlerOptions:MaxConcurrentSessions", "123" },
                { $"{ExtensionPath}:BatchOptions:OperationTimeout","00:00:15" },
                { $"{ExtensionPath}:BatchOptions:MaxMessageCount", "123" },
                { $"{ExtensionPath}:BatchOptions:AutoComplete", "true" },
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

            Assert.AreEqual("options", exception.ParamName);
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
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost(b =>
                {
                    b.AddServiceBus();
                })
                .Build();

            // verify that the service bus config provider was registered
            var extensions = host.Services.GetService<IExtensionRegistry>();
            IExtensionConfigProvider[] configProviders = extensions.GetExtensions<IExtensionConfigProvider>().ToArray();

            // verify that the service bus config provider was registered
            var serviceBusExtensionConfig = configProviders.OfType<ServiceBusExtensionConfigProvider>().Single();
        }
    }
}
