// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;    
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    using System.Threading;
    public partial class ScenarioTests 
    {
        [Fact]
        public void QueuesCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                // Create Namespace
                var namespaceName = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);

                var createNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new SBNamespace()
                    {
                        Location = location,
                        Sku = new SBSku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Create Queue
                var queueName = TestUtilities.GenerateName(ServiceBusManagementHelper.QueuesPrefix);
                
                var createQueueResponse = this.ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName,
                    new SBQueue() { EnableExpress = true, EnableBatchedOperations = true});

                Assert.NotNull(createQueueResponse);
                Assert.Equal(createQueueResponse.Name, queueName);
                Assert.True(createQueueResponse.EnableExpress);
                Assert.True(createQueueResponse.EnableBatchedOperations);

                // Get the created Queue
                var getQueueResponse = ServiceBusManagementClient.Queues.Get(resourceGroup, namespaceName, queueName);
                Assert.NotNull(getQueueResponse);
                Assert.Equal(EntityStatus.Active, getQueueResponse.Status);
                Assert.Equal(getQueueResponse.Name, queueName);
                  
                // Get all Queues
                var getQueueListAllResponse = ServiceBusManagementClient.Queues.ListByNamespace(resourceGroup, namespaceName);
                Assert.NotNull(getQueueListAllResponse);
                Assert.True(getQueueListAllResponse.Count() == 1);                
                Assert.True(getQueueListAllResponse.All(ns => ns.Id.Contains(resourceGroup)));


                // Create Queue1
                var queueName1 = TestUtilities.GenerateName(ServiceBusManagementHelper.QueuesPrefix);
                var createQueueResponse1 = this.ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName1,
                new SBQueue() { EnableExpress = true });


                // Update Queue. 
                var updateQueuesParameter = new SBQueue()
                {
                    EnableExpress = true,
                    MaxDeliveryCount = 5,
                    MaxSizeInMegabytes = 1024,
                    ForwardTo = queueName1,
                    ForwardDeadLetteredMessagesTo = queueName1
                };

                var updateQueueResponse = ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName, updateQueuesParameter);
                Assert.NotNull(updateQueueResponse);
                Assert.True(updateQueueResponse.EnableExpress);
                Assert.Equal(updateQueueResponse.ForwardTo, queueName1);
                Assert.Equal(updateQueueResponse.ForwardDeadLetteredMessagesTo, queueName1);

                var secondQueueName = TestUtilities.GenerateName(ServiceBusManagementHelper.QueuesPrefix);

                var secondQueueResponse = ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, secondQueueName, new SBQueue()
                {
                    LockDuration = new TimeSpan(0, 3, 0),
                    DefaultMessageTimeToLive = new TimeSpan(428, 3, 28, 0),
                    MaxSizeInMegabytes = 4096,
                    DuplicateDetectionHistoryTimeWindow = new TimeSpan(0, 10, 0),
                    DeadLetteringOnMessageExpiration = true,
                    RequiresDuplicateDetection = true,
                    MaxDeliveryCount = 8,
                    Status = EntityStatus.Active,
                    EnableBatchedOperations = false,
                    ForwardTo = queueName,
                    ForwardDeadLetteredMessagesTo = queueName
                });

                Assert.Equal(new TimeSpan(428, 3, 28, 0), secondQueueResponse.DefaultMessageTimeToLive);
                Assert.Equal(new TimeSpan(0, 3, 0), secondQueueResponse.LockDuration);
                Assert.False(secondQueueResponse.EnableBatchedOperations);
                Assert.Equal(8, secondQueueResponse.MaxDeliveryCount);
                Assert.Equal(new TimeSpan(0, 10, 0), secondQueueResponse.DuplicateDetectionHistoryTimeWindow);
                Assert.True(secondQueueResponse.RequiresDuplicateDetection);
                Assert.False(secondQueueResponse.RequiresSession);
                Assert.Equal(EntityStatus.Active, secondQueueResponse.Status);
                Assert.Equal(queueName, secondQueueResponse.ForwardDeadLetteredMessagesTo);
                Assert.Equal(queueName, secondQueueResponse.ForwardTo);

                var temp = secondQueueResponse;

                secondQueueResponse = ServiceBusManagementClient.Queues.Get(resourceGroup, namespaceName, secondQueueName);

                CompareQueues(temp, secondQueueResponse);

                // Delete Created Queue 
                ServiceBusManagementClient.Queues.Delete(resourceGroup, namespaceName, queueName);

                //Delete Namespace Async
                ServiceBusManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName, null, new CancellationToken()).ConfigureAwait(false);
            }
        }

        internal static void CompareQueues(SBQueue expected, SBQueue actual)
        {
            Assert.Equal(expected.DefaultMessageTimeToLive, actual.DefaultMessageTimeToLive);
            Assert.Equal(expected.LockDuration, actual.LockDuration);
            Assert.Equal(expected.EnableBatchedOperations, actual.EnableBatchedOperations);
            Assert.Equal(expected.MaxDeliveryCount, actual.MaxDeliveryCount);
            Assert.Equal(expected.DuplicateDetectionHistoryTimeWindow, actual.DuplicateDetectionHistoryTimeWindow);
            Assert.Equal(expected.RequiresDuplicateDetection, actual.RequiresDuplicateDetection);
            Assert.Equal(expected.RequiresSession, actual.RequiresSession);
            Assert.Equal(expected.Status, actual.Status);
            Assert.Equal(expected.ForwardDeadLetteredMessagesTo, actual.ForwardDeadLetteredMessagesTo);
            Assert.Equal(expected.ForwardTo, actual.ForwardTo);
            Assert.Equal(expected.EnablePartitioning, actual.EnablePartitioning);
            Assert.Equal(expected.AutoDeleteOnIdle, actual.AutoDeleteOnIdle);
        }
    }
}
