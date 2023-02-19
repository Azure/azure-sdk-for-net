// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Azure;
using Azure.Core.TestFramework;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.WebJobs.Host;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Tests
{
    internal class QueueMetricsProviderTests : LiveTestBase<WebJobsTestEnvironment>
    {
        private ILoggerFactory _loggerFactory;
        private TestLoggerProvider _loggerProvider;
        private QueueMetricsProvider _metricsProvider;
        private Mock<QueueClient> _mockQueue;

        [SetUp]
        public void SetUp()
        {
            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);
            _mockQueue = new Mock<QueueClient>(new Uri("https://test.queue.core.windows.net/testqueue"), new QueueClientOptions());
            _mockQueue.Setup(x => x.Name).Returns("testqueue");
            _metricsProvider = new QueueMetricsProvider(_mockQueue.Object, _loggerFactory);
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Fixture = new TestFixture();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Fixture.Dispose();
        }

        public TestFixture Fixture { get; set; }

        [Test]
        public async Task GetMetrics_ReturnsExpectedResult()
        {
            QueueMetricsProvider _provider = new QueueMetricsProvider(Fixture.Queue, _loggerFactory);
            var metrics = await _provider.GetMetricsAsync();

            Assert.AreEqual(0, metrics.QueueLength);
            Assert.AreEqual(TimeSpan.Zero, metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // add some test messages
            for (int i = 0; i < 5; i++)
            {
                await Fixture.Queue.SendMessageAsync($"Message {i}");
            }

            await Task.Delay(TimeSpan.FromSeconds(5));

            metrics = await _provider.GetMetricsAsync();

            Assert.AreEqual(5, metrics.QueueLength);
            Assert.True(metrics.QueueTime.Ticks > 0);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // verify non-generic interface works as expected
            metrics = (QueueTriggerMetrics)(await _provider.GetMetricsAsync());
            Assert.AreEqual(5, metrics.QueueLength);
        }

        [Test]
        public async Task GetMetrics_HandlesStorageExceptions()
        {
            var exception = new RequestFailedException(
                500,
                "Things are very wrong.",
                default,
                new Exception());

            _mockQueue.Setup(p => p.GetPropertiesAsync(It.IsAny<CancellationToken>())).Throws(exception);

            var metrics = await _metricsProvider.GetMetricsAsync();

            Assert.AreEqual(0, metrics.QueueLength);
            Assert.AreEqual(TimeSpan.Zero, metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            var warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == Microsoft.Extensions.Logging.LogLevel.Warning);
            Assert.AreEqual("Error querying for queue scale status: Things are very wrong.", warning.FormattedMessage);
        }

        public class TestFixture : IDisposable
        {
            private const string TestQueuePrefix = "queuelistenertests";

            public TestFixture()
            {
                // Create a default host to get some default services
                IHost host = new HostBuilder()
                    .ConfigureDefaultTestHost(b =>
                    {
                        b.AddAzureStorageQueues();
                    })
                    .Build();

                var queueServiceClientProvider = host.Services.GetRequiredService<QueueServiceClientProvider>();
                QueueClient = queueServiceClientProvider.GetHost();

                string queueName = string.Format("{0}-{1}", TestQueuePrefix, Guid.NewGuid());
                Queue = QueueClient.GetQueueClient(queueName);
                Queue.CreateIfNotExistsAsync().Wait();

                string poisonQueueName = string.Format("{0}-poison", queueName);
                PoisonQueue = QueueClient.GetQueueClient(poisonQueueName);
                PoisonQueue.CreateIfNotExistsAsync().Wait();
            }

            public QueueClient Queue
            {
                get;
                private set;
            }

            public QueueClient PoisonQueue
            {
                get;
                private set;
            }

            public QueueServiceClient QueueClient
            {
                get;
                private set;
            }

            public QueueClient CreateNewQueue()
            {
                string queueName = string.Format("{0}-{1}", TestQueuePrefix, Guid.NewGuid());
                var queue = QueueClient.GetQueueClient(queueName);
                queue.CreateIfNotExistsAsync().Wait();
                return queue;
            }

            public void Dispose()
            {
                var result = QueueClient.GetQueues(prefix: TestQueuePrefix);
                var tasks = new List<Task>();

                foreach (var queue in result)
                {
                    tasks.Add(QueueClient.GetQueueClient(queue.Name).DeleteAsync());
                }

                Task.WaitAll(tasks.ToArray());
            }
        }
    }
}
