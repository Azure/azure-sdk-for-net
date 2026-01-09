// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
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

            Assert.Multiple(() =>
            {
                Assert.That(options.PrefetchCount, Is.EqualTo(123));
                Assert.That(options.MaxConcurrentCalls, Is.EqualTo(123));
                Assert.That(options.MaxMessageBatchSize, Is.EqualTo(123));
                Assert.That(options.AutoCompleteMessages, Is.False);
                Assert.That(options.MaxAutoLockRenewalDuration, Is.EqualTo(TimeSpan.FromSeconds(15)));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(result.PrefetchCount, Is.EqualTo(123));

                Assert.That(result.MaxConcurrentCalls, Is.EqualTo(123));
                Assert.That(result.AutoCompleteMessages, Is.False);
                Assert.That(result.MaxAutoLockRenewalDuration, Is.EqualTo(TimeSpan.FromSeconds(15)));
            });
        }

        [Test]
        public void ConfigureOptions_AppliesValuesCorrectly()
        {
            ServiceBusOptions options = CreateOptionsFromConfig();

            Assert.Multiple(() =>
            {
                Assert.That(options.PrefetchCount, Is.EqualTo(123));
                Assert.That(options.MaxConcurrentCalls, Is.EqualTo(123));
                Assert.That(options.MaxConcurrentSessions, Is.EqualTo(20));
                Assert.That(options.MaxConcurrentCallsPerSession, Is.EqualTo(5));
                Assert.That(options.MaxMessageBatchSize, Is.EqualTo(20));
                Assert.That(options.MinMessageBatchSize, Is.EqualTo(10));
                Assert.That(options.MaxBatchWaitTime, Is.EqualTo(TimeSpan.FromSeconds(1)));
                Assert.That(options.AutoCompleteMessages, Is.False);
                Assert.That(options.MaxAutoLockRenewalDuration, Is.EqualTo(TimeSpan.FromSeconds(15)));
                Assert.That(options.TransportType, Is.EqualTo(ServiceBusTransportType.AmqpWebSockets));
                Assert.That(((WebProxy)options.WebProxy).Address.AbsoluteUri, Is.EqualTo("http://proxyserver:8080/"));
                Assert.That(options.ClientRetryOptions.MaxRetries, Is.EqualTo(10));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(result.PrefetchCount, Is.EqualTo(123));

                Assert.That(result.MaxConcurrentCalls, Is.EqualTo(123));
                Assert.That(result.AutoCompleteMessages, Is.False);
                Assert.That(result.MaxAutoLockRenewalDuration, Is.EqualTo(TimeSpan.FromSeconds(15)));
                Assert.That(((WebProxy)result.WebProxy).Address.AbsoluteUri, Is.EqualTo("http://proxyserver:8080/"));
                Assert.That(result.ClientRetryOptions.MaxRetries, Is.EqualTo(10));
            });
        }

        [Test]
        public void ConfigureOptions_InfiniteTimeSpans_Format_Returns_Expected()
        {
            ServiceBusOptions options = CreateOptionsFromConfigInfiniteTimeSpans();
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

            Assert.Multiple(() =>
            {
                Assert.That(result.PrefetchCount, Is.EqualTo(123));

                Assert.That(result.MaxConcurrentCalls, Is.EqualTo(123));
                Assert.That(result.AutoCompleteMessages, Is.False);
                Assert.That(result.MaxAutoLockRenewalDuration, Is.EqualTo(Timeout.InfiniteTimeSpan));
                Assert.That(result.MaxBatchWaitTime, Is.EqualTo(Timeout.InfiniteTimeSpan));
                Assert.That(((WebProxy)result.WebProxy).Address.AbsoluteUri, Is.EqualTo("http://proxyserver:8080/"));
                Assert.That(result.ClientRetryOptions.MaxRetries, Is.EqualTo(10));
            });
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
                { $"{ExtensionPath}:MaxConcurrentSessions", "20" },
                { $"{ExtensionPath}:MaxConcurrentCallsPerSession", "5" },
                { $"{ExtensionPath}:TransportType", "AmqpWebSockets" },
                { $"{ExtensionPath}:MaxMessageBatchSize", "20" },
                { $"{ExtensionPath}:MinMessageBatchSize", "10" },
                { $"{ExtensionPath}:MaxBatchWaitTime", "00:00:01" },
                { $"{ExtensionPath}:WebProxy", "http://proxyserver:8080/" },
                { $"{ExtensionPath}:ClientRetryOptions:MaxRetries", "10" },
            };

            ServiceBusOptions options = TestHelpers.GetConfiguredOptions<ServiceBusOptions>(b =>
            {
                b.AddServiceBus();
            }, values);
            return options;
        }

        private static ServiceBusOptions CreateOptionsFromConfigInfiniteTimeSpans()
        {
            var values = new Dictionary<string, string>
            {
                { $"{ExtensionPath}:PrefetchCount", "123" },
                { $"ConnectionStrings:ServiceBus", "TestConnectionString" },
                { $"{ExtensionPath}:MaxConcurrentCalls", "123" },
                { $"{ExtensionPath}:AutoCompleteMessages", "false" },
                { $"{ExtensionPath}:MaxAutoLockRenewalDuration", "-00:00:00.0010000" },
                { $"{ExtensionPath}:MaxConcurrentSessions", "123" },
                { $"{ExtensionPath}:TransportType", "AmqpWebSockets" },
                { $"{ExtensionPath}:MaxMessageBatchSize", "20" },
                { $"{ExtensionPath}:MinMessageBatchSize", "10" },
                { $"{ExtensionPath}:MaxBatchWaitTime", "-00:00:00.0010000" },
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
        public void ConfigureOptionsThrowWhenMaxIsLessThanMinBatchSize()
        {
            string extensionPath = "AzureWebJobs:Extensions:ServiceBus";
            Assert.That(
                () => TestHelpers.GetConfiguredOptions<ServiceBusOptions>(
                b =>
                {
                    b.AddServiceBus();
                },
                new Dictionary<string, string>
                {
                    { $"{extensionPath}:MaxMessageBatchSize", "100" },
                    { $"{extensionPath}:MinMessageBatchSize", "170" },
                }),
                Throws.InvalidOperationException);
        }

        [Test]
        public void ConfigureOptionsThrowWhenMaxWaitTimeIsTooLarge()
        {
            string extensionPath = "AzureWebJobs:Extensions:ServiceBus";
            Assert.That(
                () => TestHelpers.GetConfiguredOptions<ServiceBusOptions>(
                b =>
                {
                    b.AddServiceBus();
                },
                new Dictionary<string, string>
                {
                    { $"{extensionPath}:MaxBatchWaitTime", "00:05:00" },
                }),
                Throws.InvalidOperationException);
        }

        [Test]
        public void AddServiceBus_ThrowArgumentNull_WhenServiceBusOptionsIsNull()
        {
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost(b =>
                {
                    b.AddServiceBus();
                })
                .ConfigureServices(s => s.AddSingleton<IOptions<ServiceBusOptions>>(p => null))
                .Build();

            var exception = Assert.Throws<ArgumentNullException>(() => host.Services.GetServices<IExtensionConfigProvider>());

            Assert.That(exception.ParamName, Is.EqualTo("options"));
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
