// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Tests
{
    /// <summary>
    /// Guards the contract that scale metrics read the queue with <see cref="QueueMessageEncoding.None"/>.
    /// Nothing in the type system enforces it - <see cref="QueueClient"/> does not expose its encoding -
    /// so a refactor that reuses the configured-encoding client would silently reintroduce the
    /// ambiguity between "nothing visible" and "messages present but undecodable".
    /// </summary>
    public class QueueScaleMetricsEncodingTests
    {
        [Test]
        public void GetRaw_OverridesOnlyTheEncoding()
        {
            using IHost host = new HostBuilder()
                .ConfigureDefaultTestHost(b => b.AddAzureStorageQueues())
                .Build();

            var configured = host.Services.GetRequiredService<IOptions<QueuesOptions>>().Value;
            var provider = new TestableQueueServiceClientProvider(host.Services);

            QueuesOptions raw = provider.GetRawOptions();

            Assert.AreEqual(QueueMessageEncoding.None, raw.MessageEncoding);
            Assert.AreEqual(configured.BatchSize, raw.BatchSize);
            Assert.AreEqual(configured.NewBatchThreshold, raw.NewBatchThreshold);
            Assert.AreEqual(configured.MaxDequeueCount, raw.MaxDequeueCount);
            Assert.AreEqual(configured.MaxPollingInterval, raw.MaxPollingInterval);
            Assert.AreEqual(configured.VisibilityTimeout, raw.VisibilityTimeout);
            Assert.AreNotSame(configured, raw, "The configured options are a DI singleton shared with message processing.");
            Assert.AreEqual(QueueMessageEncoding.Base64, configured.MessageEncoding, "Overriding the raw encoding must not mutate the configured options.");
        }

        [Test]
        public void GetRaw_OnSubstitutedProvider_ResolvesThroughTheSubstitute()
        {
            // The raw client is reached through QueueServiceClientProvider rather than its own DI
            // registration, so a host that swaps the provider does not have to know the raw path exists.
            QueueServiceClient expected = new QueueServiceClient("UseDevelopmentStorage=true");
            QueueServiceClientProvider provider = new FakeQueueServiceClientProvider(expected);

            Assert.AreSame(expected, provider.GetRaw(null, new DefaultNameResolver(new ConfigurationBuilder().Build())));
        }

        [Test]
        public void QueueServiceClientProvider_KeepsConfiguredEncoding()
        {
            // The message-processing client must not be affected by the metrics client.
            using IHost host = new HostBuilder()
                .ConfigureDefaultTestHost(b => b.AddAzureStorageQueues())
                .Build();

            Assert.AreEqual(
                QueueMessageEncoding.Base64,
                host.Services.GetRequiredService<IOptions<QueuesOptions>>().Value.MessageEncoding);
        }

        [Test]
        public async Task GetMetrics_UndecodableMessages_RawClientReportsThem_ConfiguredClientDoesNot()
        {
            string queueName = $"rawencoding-{Guid.NewGuid()}";
            var loggerFactory = new NullLoggerFactory();

            using IHost host = new HostBuilder()
                .ConfigureAppConfiguration(c => c.AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "ConnectionStrings:AzureWebJobsStorage", AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString }
                }))
                .ConfigureDefaultTestHost(b =>
                {
                    b.Services.AddAzureClients(builder =>
                        builder.ConfigureDefaults(options => options.Transport = AzuriteNUnitFixture.Instance.GetTransport()));
                    b.AddAzureStorageQueues();
                })
                .Build();

            var provider = new TestableQueueServiceClientProvider(host.Services);
            var resolver = new DefaultNameResolver(host.Services.GetRequiredService<IConfiguration>());

            // Resolved through GetRaw rather than hand-built, so the metrics path itself is under test.
            QueueClient rawClient = provider.GetRaw(null, resolver).GetQueueClient(queueName);
            QueueClient configuredClient = provider.Get(null, resolver).GetQueueClient(queueName);

            await rawClient.CreateIfNotExistsAsync();
            try
            {
                // Written without Base64 encoding, as a non-.NET producer would.
                await rawClient.SendMessageAsync("<<<not-base64>>>");

                var rawMetrics = await new QueueMetricsProvider("testFunctionId", rawClient, loggerFactory).GetMetricsAsync();
                var configuredMetrics = await new QueueMetricsProvider("testFunctionId", configuredClient, loggerFactory).GetMetricsAsync();

                Assert.Greater(rawMetrics.QueueLength, 0, "Raw client must see messages that cannot be decoded so the app scales out and the listener can poison them.");
                Assert.AreEqual(0, configuredMetrics.QueueLength, "Configured-encoding client cannot peek the message, which is why it must not be used for metrics.");
            }
            finally
            {
                await rawClient.DeleteIfExistsAsync();
            }
        }

        /// Builds the real provider from DI, and exposes the protected raw-options override for assertion.
        private sealed class TestableQueueServiceClientProvider : QueueServiceClientProvider
        {
            public TestableQueueServiceClientProvider(IServiceProvider services)
                : base(
                    services.GetRequiredService<IConfiguration>(),
                    services.GetRequiredService<AzureComponentFactory>(),
                    services.GetRequiredService<AzureEventSourceLogForwarder>(),
                    services.GetRequiredService<IOptions<QueuesOptions>>(),
                    services.GetRequiredService<ILoggerFactory>(),
                    services.GetRequiredService<ILogger<QueueServiceClient>>(),
                    services.GetRequiredService<IQueueProcessorFactory>(),
                    services.GetRequiredService<SharedQueueWatcher>())
            {
            }

            public QueuesOptions GetRawOptions() => CreateRawOptions();
        }
    }
}
