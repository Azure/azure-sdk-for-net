// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class BinderTests
    {
        private const string QueueName = "input-bindertests";
        private QueueServiceClient queueServiceClient;

        [SetUp]
        public void SetUp()
        {
            queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            queueServiceClient.GetQueueClient(QueueName).DeleteIfExists();
        }

        [Test]
        [Ignore("Flaky test, see:#51941")]
        public async Task Trigger_ViaIBinder_CannotBind()
        {
            // Arrange
            const string expectedContents = "abc";
            QueueClient queue = CreateQueue(queueServiceClient, QueueName);
            await queue.SendMessageAsync(expectedContents);

            // Act
            Exception exception = await RunTriggerFailureAsync<string>(typeof(BindToQueueTriggerViaIBinderProgram),
                (s) => BindToQueueTriggerViaIBinderProgram.TaskSource = s);

            // Assert
            Assert.AreEqual("No binding found for attribute 'Microsoft.Azure.WebJobs.QueueTriggerAttribute'.", exception.Message);
        }

        private static QueueClient CreateQueue(QueueServiceClient queueServiceClient, string queueName)
        {
            var queue = queueServiceClient.GetQueueClient(queueName);
            queue.CreateIfNotExists();
            return queue;
        }

        private async Task<Exception> RunTriggerFailureAsync<TResult>(Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.RunTriggerFailureAsync<TResult>(b => {
                b.AddAzureStorageQueues();
                b.UseQueueService(queueServiceClient);
            }, programType, setTaskSource);
        }

        private class BindToQueueTriggerViaIBinderProgram
        {
            public static TaskCompletionSource<string> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] QueueMessage message, IBinder binder)
            {
                TaskSource.TrySetResult(binder.Bind<string>(new QueueTriggerAttribute(QueueName)));
            }
        }
    }
}
