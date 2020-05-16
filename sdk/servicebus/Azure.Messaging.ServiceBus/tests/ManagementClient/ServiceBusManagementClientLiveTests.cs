// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            var queueName = "TestQueue";
            // using connection string
            // var client = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);

            // using AAD
            var client = new ServiceBusManagementClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
            try
            {
                var queueDescription = await client.CreateQueueAsync(queueName);
                Assert.AreEqual(queueDescription.Status, EntityStatus.Active);
            }
            catch
            {
                throw;
            }
            finally
            {
                await client.DeleteQueueAsync(queueName);
            }
        }
    }
}
