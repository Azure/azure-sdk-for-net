// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.ScenarioTests
{
    public class QueuesEncodingTests
    {
        private const string OriginQueueName = "queue-scenariotests-origin";
        private const string DestinationQueueName = "queue-scenariotests-destination";
        private QueueServiceClient queueServiceClient;

        [SetUp]
        public void SetUp()
        {
            queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient(
                new QueueClientOptions() { MessageEncoding = QueueMessageEncoding.None });

            queueServiceClient.GetQueueClient(OriginQueueName).DeleteIfExists();
            queueServiceClient.GetQueueClient(DestinationQueueName).DeleteIfExists();
            queueServiceClient.GetQueueClient(OriginQueueName).CreateIfNotExists();
            queueServiceClient.GetQueueClient(DestinationQueueName).CreateIfNotExists();
        }

        [Test]
        public async Task EncodesBase64InputAndOutputByDefault()
        {
            // Arrange
            var content = Guid.NewGuid().ToString();
            var encodedContent = Convert.ToBase64String(Encoding.UTF8.GetBytes(content));

            await queueServiceClient.GetQueueClient(OriginQueueName).SendMessageAsync(encodedContent);

            // Act
            var result = await RunTriggerAsync<string>(typeof(OriginQueueToDestinationQueueStringProgram),
                (s) => OriginQueueToDestinationQueueStringProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(content, result);
        }

        [Test]
        public async Task EncodesBase64InputAndOutputIfOptionProvided()
        {
            // Arrange
            var content = Guid.NewGuid().ToString();
            var encodedContent = Convert.ToBase64String(Encoding.UTF8.GetBytes(content));

            await queueServiceClient.GetQueueClient(OriginQueueName).SendMessageAsync(encodedContent);

            // Act
            var result = await RunTriggerAsync<string>(typeof(OriginQueueToDestinationQueueStringProgram),
                (s) => OriginQueueToDestinationQueueStringProgram.TaskSource = s,
                QueueMessageEncoding.Base64);

            // Assert
            Assert.AreEqual(content, result);
        }

        [Test]
        public async Task CanHandleNonEncodedMessages()
        {
            // Arrange
            var content = Guid.NewGuid().ToString();

            await queueServiceClient.GetQueueClient(OriginQueueName).SendMessageAsync(content);

            // Act
            var result = await RunTriggerAsync<string>(typeof(OriginQueueToDestinationQueueStringProgram),
                (s) => OriginQueueToDestinationQueueStringProgram.TaskSource = s,
                QueueMessageEncoding.None);

            // Assert
            Assert.AreEqual(content, result);
        }

        private async Task<TResult> RunTriggerAsync<TResult>(Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource, QueueMessageEncoding? messageEncoding = default)
        {
            return await FunctionalTest.RunTriggerAsync<TResult>(b =>
            {
                b.Services.AddAzureClients(builder =>
                {
                    builder.ConfigureDefaults(options => options.Transport = AzuriteNUnitFixture.Instance.GetTransport());
                });
                if (!messageEncoding.HasValue)
                {
                    b.AddAzureStorageQueues();
                }
                else
                {
                    b.AddAzureStorageQueues(options => options.MessageEncoding = messageEncoding.Value);
                }
            }, programType, setTaskSource,
            settings: new Dictionary<string, string>() {
                // This takes precedence over env variables.
                { "ConnectionStrings:AzureWebJobsStorage", AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString }
            });
        }

        private class OriginQueueToDestinationQueueStringProgram
        {
            private const string CommittedQueueName = "committed";

            public static TaskCompletionSource<string> TaskSource { get; set; }

            public static void StepOne([QueueTrigger(OriginQueueName)] string messageIn, [Queue(DestinationQueueName)] out string messageOut)
            {
                messageOut = messageIn;
            }

            public static void StepTwo([QueueTrigger(DestinationQueueName)] string messageIn)
            {
                TaskSource.TrySetResult(messageIn);
            }
        }
    }
}
