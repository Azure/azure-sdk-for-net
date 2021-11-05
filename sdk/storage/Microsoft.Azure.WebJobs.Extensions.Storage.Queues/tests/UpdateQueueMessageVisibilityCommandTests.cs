// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Tests
{
    using global::Azure.Storage.Queues;
    using global::Azure.Storage.Queues.Models;
    using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
    using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
    using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateQueueMessageVisibilityCommandTests
    {
        private QueueServiceClient _queueServiceClient;

        [SetUp]
        public void SetUp()
        {
            _queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
        }

        [Test]
        public async Task CanExtendVisibilityTimeoutMultipleTimes()
        {
            // Arange
            string queueName = Guid.NewGuid().ToString();
            var queueClient = _queueServiceClient.GetQueueClient(queueName);
            await queueClient.CreateIfNotExistsAsync();
            await queueClient.SendMessageAsync("foo");
            QueueMessage message = await queueClient.ReceiveMessageAsync(visibilityTimeout: TimeSpan.FromSeconds(60));
            Mock<IDelayStrategy> delayStrategyMock = new Mock<IDelayStrategy>();
            delayStrategyMock.Setup(x => x.GetNextDelay(It.IsAny<bool>())).Returns(TimeSpan.FromMilliseconds(1));

            int counter = 0;
            Action<UpdateReceipt> onUpdateReceipt = updateReceipt => { counter++; };

            var command = new UpdateQueueMessageVisibilityCommand(queueClient, message, TimeSpan.FromSeconds(60), delayStrategyMock.Object, onUpdateReceipt);

            // Act
            var commandResult1 = await command.ExecuteAsync(CancellationToken.None);
            var commandResult2 = await command.ExecuteAsync(CancellationToken.None);

            // Assert
            // If renewal was successful then result should wait as much as IDelayStrategy decided (see mock above).
            // Otherwise if it failed due to non-transient reason (i.e. pop recepit got lost) it would delay infinitely leading to assertion error below.
            Assert.IsTrue(commandResult1.Wait.Wait(TimeSpan.FromSeconds(10)));
            Assert.IsTrue(commandResult2.Wait.Wait(TimeSpan.FromSeconds(10)));
            // Check the counter too
            Assert.AreEqual(2, counter);
        }
    }
}
