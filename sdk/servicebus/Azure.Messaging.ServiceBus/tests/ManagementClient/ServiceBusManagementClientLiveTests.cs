// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Management;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.ManagementClient
{
    public class ServiceBusManagementClientLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task CreateQueueTest()
        {
           // var queueName = "TestQueue";
            // using connection string
             // var client = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);

            // using AAD
             var client = new ServiceBusManagementClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
            try
            {
                await client.CreateTopicAsync("test");
                await client.CreateSubscriptionAsync("test", "Test1");
                await client.CreateSubscriptionAsync("test", "Test2");
                await client.CreateSubscriptionAsync("test", "Test3");
                await client.CreateSubscriptionAsync("test", "Test4");
                await client.CreateSubscriptionAsync("test", "Test5");
                // await client.CreateSubscriptionAsync("test", "Test6");

                List<string> names = new List<string>();
                await foreach (SubscriptionDescription queues in client.GetSubscriptionsAsync("test"))
                {
                    names.Add(queues.SubscriptionName);
                    Console.WriteLine(names);
                }

                Console.WriteLine(names);
                //QueueDescription queueDescription = await client.CreateQueueAsync(queueName);
                //queueDescription.EnableBatchedOperations = false;
                //await client.UpdateQueueAsync(queueDescription);

                //queueDescription = await client.GetQueueAsync(queueName);
                //Assert.AreEqual(queueDescription.EnableBatchedOperations, false);
            }
            catch
            {
                throw;
            }
            finally
            {
             //   await client.DeleteTopicAsync("Test");
            }
        }
    }
}
