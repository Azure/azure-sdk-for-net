// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class CustomQueueProcessorTests
    {
        private const string QueueName1 = "input1-customprocessortests";
        private const string QueueName2 = "input2-customprocessortests";
        private const string QueueName3 = "input3-customprocessortests";
        private const string TestQueueMessage = "ignore";
        private QueueServiceClient queueServiceClient;

        private static QueuesOptions ExpectedQueuesOptions1 = new QueuesOptions(); // defaults
        private static QueuesOptions ExpectedQueuesOptions2 = new QueuesOptions()
        {
            BatchSize = 1,
            MaxDequeueCount = 1,
            MaxPollingInterval = TimeSpan.FromSeconds(1),
            MessageEncoding = QueueMessageEncoding.None,
            NewBatchThreshold = 1,
            VisibilityTimeout = TimeSpan.FromSeconds(1),
        };
        private static QueuesOptions ExpectedQueuesOptions3 = new QueuesOptions()
        {
            BatchSize = 2,
            MaxDequeueCount = 2,
            MaxPollingInterval = TimeSpan.FromSeconds(2),
            MessageEncoding = QueueMessageEncoding.Base64,
            NewBatchThreshold = 2,
            VisibilityTimeout = TimeSpan.FromSeconds(2),
        };

        private static QueuesOptions ActualQueuesOptions1;
        private static QueuesOptions ActualQueuesOptions2;
        private static QueuesOptions ActualQueuesOptions3;

        [SetUp]
        public async Task SetUp()
        {
            queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            await queueServiceClient.GetQueueClient(QueueName1).DeleteIfExistsAsync();
            await queueServiceClient.GetQueueClient(QueueName1).CreateIfNotExistsAsync();
            await queueServiceClient.GetQueueClient(QueueName2).DeleteIfExistsAsync();
            await queueServiceClient.GetQueueClient(QueueName2).CreateIfNotExistsAsync();
            await queueServiceClient.GetQueueClient(QueueName3).DeleteIfExistsAsync();
            await queueServiceClient.GetQueueClient(QueueName3).CreateIfNotExistsAsync();
        }

        [Test]
        public async Task FactoriesShouldNotOverwriteSettings()
        {
            // make sure inputs are correct
            Assert.That(AreOptionsEqual(ExpectedQueuesOptions1, ExpectedQueuesOptions2), Is.False);
            Assert.That(AreOptionsEqual(ExpectedQueuesOptions1, ExpectedQueuesOptions3), Is.False);
            Assert.That(AreOptionsEqual(ExpectedQueuesOptions2, ExpectedQueuesOptions3), Is.False);

            // run triggers
            await queueServiceClient.GetQueueClient(QueueName1).SendMessageAsync(TestQueueMessage);
            await queueServiceClient.GetQueueClient(QueueName2).SendMessageAsync(TestQueueMessage);
            await queueServiceClient.GetQueueClient(QueueName3).SendMessageAsync(TestQueueMessage);

            await FunctionalTest.RunTriggerAsync<bool>(
                b => ConfigureStorage(b), typeof(SampleProgram), s => SampleProgram.TaskSource = s);

            // assert options were not overwritten
            Assert.That(AreOptionsEqual(ExpectedQueuesOptions1, ActualQueuesOptions1), Is.True);
            Assert.That(AreOptionsEqual(ExpectedQueuesOptions2, ActualQueuesOptions2), Is.True);
            Assert.That(AreOptionsEqual(ExpectedQueuesOptions3, ActualQueuesOptions3), Is.True);
        }

        private bool AreOptionsEqual(QueuesOptions queuesOptions1, QueuesOptions queuesOptions2)
        {
            return queuesOptions1.BatchSize == queuesOptions2.BatchSize
                && queuesOptions1.MaxDequeueCount == queuesOptions2.MaxDequeueCount
                 && queuesOptions1.MaxPollingInterval == queuesOptions2.MaxPollingInterval
                  && queuesOptions1.MessageEncoding == queuesOptions2.MessageEncoding
                   && queuesOptions1.NewBatchThreshold == queuesOptions2.NewBatchThreshold
                    && queuesOptions1.VisibilityTimeout == queuesOptions2.VisibilityTimeout;
        }

        private class CustomQueueProcessorFactory : IQueueProcessorFactory
        {
            public QueueProcessor Create(QueueProcessorOptions queueProcessorOptions)
            {
                QueuesOptions overrideOptions = null;
                switch (queueProcessorOptions.Queue.Name)
                {
                    case QueueName1:
                        ActualQueuesOptions1 = queueProcessorOptions.Options;
                        // defaults
                        break;
                    case QueueName2:
                        ActualQueuesOptions2 = queueProcessorOptions.Options;
                        overrideOptions = ExpectedQueuesOptions2;
                        break;
                    case QueueName3:
                        ActualQueuesOptions3 = queueProcessorOptions.Options;
                        overrideOptions = ExpectedQueuesOptions3;
                        break;
                }

                if (overrideOptions != null)
                {
                    queueProcessorOptions.Options.BatchSize = overrideOptions.BatchSize;
                    queueProcessorOptions.Options.MaxDequeueCount = overrideOptions.MaxDequeueCount;
                    queueProcessorOptions.Options.MaxPollingInterval = overrideOptions.MaxPollingInterval;
                    queueProcessorOptions.Options.MessageEncoding = overrideOptions.MessageEncoding;
                    queueProcessorOptions.Options.NewBatchThreshold = overrideOptions.NewBatchThreshold;
                    queueProcessorOptions.Options.VisibilityTimeout = overrideOptions.VisibilityTimeout;
                }

                return new QueueProcessor(queueProcessorOptions);
            }
        }

        private class SampleProgram
        {
            public static TaskCompletionSource<bool> TaskSource { get; set; }
            private static int counter = 0;

            public static void ProcessMessage1([QueueTrigger(QueueName1)] string message)
            {
                SetResult();
            }

            public static void ProcessMessage2([QueueTrigger(QueueName2)] string message)
            {
                SetResult();
            }

            public static void ProcessMessage3([QueueTrigger(QueueName3)] string message)
            {
                SetResult();
            }

            private static void SetResult()
            {
                int incremented = Interlocked.Increment(ref counter);
                if (incremented == 3)
                {
                    TaskSource.SetResult(true);
                }
            }
        }

        private void ConfigureStorage(IWebJobsBuilder builder)
        {
            builder.AddAzureStorageQueues();
            builder.UseQueueService(queueServiceClient);
            builder.Services.AddSingleton<IQueueProcessorFactory, CustomQueueProcessorFactory>();
        }
    }
}
