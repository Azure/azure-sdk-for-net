// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Management;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample07_CRUDOperations : ServiceBusLiveTestBase
    {
        [Test]
        public async Task CreateQueue()
        {
            string queueName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string connectionString = TestEnvironment.ServiceBusConnectionString;
            var client = new ServiceBusManagementClient(connectionString);
            #region Snippet:CreateQueue
            //@@ string connectionString = "<connection_string>";
            //@@ string queueName = "<queue_name>";
            //@@ var client = new ServiceBusClient(connectionString);
            var queueDescription = new QueueDescription(queueName)
            {
                AutoDeleteOnIdle = TimeSpan.FromDays(7),
                DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1),
                EnableBatchedOperations = true,
                DeadLetteringOnMessageExpiration = true,
                EnablePartitioning = false,
                ForwardDeadLetteredMessagesTo = null,
                ForwardTo = null,
                LockDuration = TimeSpan.FromSeconds(45),
                MaxDeliveryCount = 8,
                MaxSizeInMegabytes = 2048,
                RequiresDuplicateDetection = true,
                RequiresSession = true,
                UserMetadata = "some metadata"
            };

            queueDescription.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
                "allClaims",
                new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

            // The CreateQueueAsync method will return the created queue
            // which would include values for all of the
            // QueueDescription properties (the service will supply
            // default values for properties not included in the creation).
            QueueDescription createdQueue = await client.CreateQueueAsync(queueDescription);
            #endregion
            Assert.AreEqual(queueDescription, createdQueue);
        }

        [Test]
        public async Task GetUpdateDeleteQueue()
        {
            string queueName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string connectionString = TestEnvironment.ServiceBusConnectionString;
            var client = new ServiceBusManagementClient(connectionString);
            var qd = new QueueDescription(queueName);

            await client.CreateQueueAsync(qd);
            #region Snippet:GetQueue
            QueueDescription queueDescription = await client.GetQueueAsync(queueName);
            #endregion
            #region Snippet:UpdateQueue
            queueDescription.LockDuration = TimeSpan.FromSeconds(60);
            QueueDescription updatedQueue = await client.UpdateQueueAsync(queueDescription);
            #endregion
            Assert.AreEqual(TimeSpan.FromSeconds(60), updatedQueue.LockDuration);
            #region Snippet:DeleteQueue
            await client.DeleteQueueAsync(queueName);
            #endregion
            Assert.That(
                  async () =>
                  await client.GetQueueAsync(queueName),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));
        }
    }
}
