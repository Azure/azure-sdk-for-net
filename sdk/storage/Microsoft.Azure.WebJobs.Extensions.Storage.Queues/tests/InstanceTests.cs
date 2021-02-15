// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class InstanceTests
    {
        private const string QueueName = "input-instancetests";
        private QueueServiceClient queueServiceClient;

        [SetUp]
        public void SetUp()
        {
            queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            queueServiceClient.GetQueueClient(QueueName).DeleteIfExists();
        }

        [Test]
        public async Task Trigger_CanBeInstanceMethod()
        {
            // Arrange
            string expectedGuid = Guid.NewGuid().ToString();
            await AddQueueMessageAsync(queueServiceClient, expectedGuid, QueueName);

            var prog = new InstanceProgram();

            IHost host = new HostBuilder()
               .ConfigureDefaultTestHost<InstanceProgram>(prog, builder =>
               {
                   builder.AddAzureStorageQueues()
                   .UseQueueService(queueServiceClient);
               })
               .Build();

            // Act
            var jobHost = host.GetJobHost<InstanceProgram>();
            var result = await jobHost.RunTriggerAsync<QueueMessage>();

            // Assert
            Assert.AreEqual(expectedGuid, result.MessageText);
        }

        private class InstanceProgram : IProgramWithResult<QueueMessage>
        {
            public TaskCompletionSource<QueueMessage> TaskSource { get; set; }

            public void Run([QueueTrigger(QueueName)] QueueMessage message)
            {
                this.TaskSource.TrySetResult(message);
            }
        }

        [Test]
        public async Task Trigger_CanBeAsyncInstanceMethod()
        {
            // Arrange
            string expectedGuid = Guid.NewGuid().ToString();
            await AddQueueMessageAsync(queueServiceClient, expectedGuid, QueueName);

            var prog = new InstanceAsyncProgram();
            IHost host = new HostBuilder()
               .ConfigureDefaultTestHost<InstanceAsyncProgram>(prog, builder =>
               {
                   builder.AddAzureStorageQueues()
                   .UseQueueService(queueServiceClient);
               })
               .Build();

            // Act
            var jobHost = host.GetJobHost<InstanceAsyncProgram>();
            var result = await jobHost.RunTriggerAsync<QueueMessage>();

            // Assert
            Assert.AreEqual(expectedGuid, result.MessageText);
        }

        private class InstanceAsyncProgram : IProgramWithResult<QueueMessage>
        {
            public TaskCompletionSource<QueueMessage> TaskSource { get; set; }

            public Task RunAsync([QueueTrigger(QueueName)] QueueMessage message)
            {
                this.TaskSource.TrySetResult(message);
                return Task.FromResult(0);
            }
        }

        // $$$ this test should apply to any trigger and be in the Unit tests.
        [Test]
        public async Task Trigger_IfClassIsDisposable_Disposes()
        {
            // Arrange
            await AddQueueMessageAsync(queueServiceClient, "ignore", QueueName);

            IHost host = new HostBuilder()
               .ConfigureDefaultTestHost<DisposeInstanceProgram>(builder =>
               {
                   builder.AddAzureStorageQueues();
                   builder.UseQueueService(queueServiceClient);
               })
               .Build();

            // Act & Assert
            var jobHost = host.GetJobHost<DisposeInstanceProgram>();
            var result = await jobHost.RunTriggerAsync<object>(DisposeInstanceProgram.TaskSource);
        }

        private sealed class DisposeInstanceProgram : IDisposable
        {
            public static TaskCompletionSource<object> TaskSource = new TaskCompletionSource<object>();

            public void Run([QueueTrigger(QueueName)] QueueMessage message)
            {
            }

            public void Dispose()
            {
                TaskSource.TrySetResult(null);
            }
        }

        // $$$ Not really a queue test
        [Test]
        public async Task Trigger_IfClassConstructorHasDependencies_CanUseCustomJobActivator()
        {
            // Arrange
            const string expectedResult = "abc";

            Mock<IFactory<string>> resultFactoryMock = new Mock<IFactory<string>>(MockBehavior.Strict);
            resultFactoryMock.Setup(f => f.Create()).Returns(expectedResult);
            IFactory<string> resultFactory = resultFactoryMock.Object;

            Mock<IJobActivator> activatorMock = new Mock<IJobActivator>(MockBehavior.Strict);
            activatorMock.Setup(a => a.CreateInstance<InstanceCustomActivatorProgram>())
                         .Returns(() => new InstanceCustomActivatorProgram(resultFactory));
            IJobActivator activator = activatorMock.Object;

            await AddQueueMessageAsync(queueServiceClient, "ignore", QueueName);

            IHost host = new HostBuilder()
              .ConfigureDefaultTestHost<InstanceCustomActivatorProgram>(builder =>
              {
                  builder.AddAzureStorageQueues();
                  builder.UseQueueService(queueServiceClient);
              }, null, activator)
              .Build();

            // Act
            var jobHost = host.GetJobHost<InstanceCustomActivatorProgram>();
            Assert.NotNull(jobHost);

            var result = await jobHost.RunTriggerAsync<string>(InstanceCustomActivatorProgram.TaskSource);

            // Assert
            Assert.AreSame(expectedResult, result);
        }

        private static async Task AddQueueMessageAsync(QueueServiceClient client, string message, string queueName)
        {
            var queue = client.GetQueueClient(queueName);
            await queue.CreateIfNotExistsAsync();
            await queue.ClearMessagesAsync();
            await queue.SendMessageAsync(message);
        }

        private class InstanceCustomActivatorProgram
        {
            private readonly IFactory<string> _resultFactory;

            public InstanceCustomActivatorProgram(IFactory<string> resultFactory)
            {
                _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
            }

            public static TaskCompletionSource<string> TaskSource { get; set; } = new TaskCompletionSource<string>();

            public void Run([QueueTrigger(QueueName)] QueueMessage ignore)
            {
                string result = _resultFactory.Create();
                TaskSource.TrySetResult(result);
            }
        }
    }
}
